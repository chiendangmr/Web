using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Contract;
using Microsoft.CSharp;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using HD.TVAD.Entities.Entities.System;
using HD.TVAD.Entities.Entities.Price;
using HD.TVAD.Entities.Entities.Schedule;

namespace CopyMetadataOldToNew
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contextOld = new HD.TVADOld.Entities.Context.TVAdContext(AppSettings.Default.OldDBConnectionString))
            using (var contextNew = new HD.TVAD.Entities.Context.TVAdContext(AppSettings.Default.NewDBConnectionString))
            using (var newConnection = new SqlConnection(contextNew.Database.GetDbConnection().ConnectionString))
            using (var oldConnection = new SqlConnection(contextOld.Database.GetDbConnection().ConnectionString))
            {
                var newBlocks = contextNew.System_SpotBlocks.ToList();

                #region Sync block
                if (true)
                {
                    var oldBlocks = contextOld.Blocks.ToList();
                    int nb = 0;
                    foreach (var block in oldBlocks)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldBlocks.Count} block");
                        var newBlock = newBlocks.FirstOrDefault(b => b.Duration == block.Duration);
                        if (newBlock == null)
                        {
                            newBlock = new HD.TVAD.Entities.Entities.System.SpotBlock()
                            {
                                Duration = block.Duration,
                                Description = block.Description
                            };
                            newBlocks.Add(newBlock);

                            newConnection.Execute(@"Insert Into System.SpotBlocks(Id, Duration, Description)
                                Values(@Id, @Duration, @Description)",
                                new
                                {
                                    newBlock.Id,
                                    newBlock.Duration,
                                    newBlock.Description
                                });
                        }
                        else if (newBlock.Description != block.Description)
                        {
                            newBlock.Description = block.Description;

                            newConnection.Execute(@"Update System.SpotBlocks Set Description = @Description
                                Where Id = @Id",
                                new
                                {
                                    newBlock.Id,
                                    newBlock.Description
                                });
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                var newChannels = contextNew.System_Channels
                    .Include(c => c.TimeBandBase).ToList();

                #region Sync Channels
                if (true)
                {
                    var oldChannels = contextOld.Channels.ToList();
                    int nb = 0;
                    foreach (var channel in oldChannels)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldChannels.Count} channel");

                        var newChannel = newChannels.FirstOrDefault(c => c.OldId == channel.Id);
                        if (newChannel == null)
                        {
                            newChannel = new HD.TVAD.Entities.Entities.System.Channel { OldId = channel.Id };
                            newChannel.TimeBandBase.Channel = newChannel;
                            newChannel.TimeBandBase.Name = channel.Name;

                            newConnection.Execute(@"Insert Into System.TimeBandBases(Id, Name)
                                Values(@Id, @Name)

                                Insert Into System.Channels(Id, OldId)
                                Values(@Id, @OldId)",
                                new
                                {
                                    newChannel.TimeBandBase.Id,
                                    newChannel.TimeBandBase.Name,
                                    newChannel.OldId
                                });

                            newChannels.Add(newChannel);
                        }
                        else
                        {
                            bool changedBase = false;
                            if (newChannel.TimeBandBase.Name != channel.Name)
                            {
                                newChannel.TimeBandBase.Name = channel.Name;
                                changedBase = true;
                            }

                            if (changedBase)
                            {
                                newConnection.Execute(@"Update System.TimeBandBases Set Name = @Name
                                    Where Id = @Id",
                                    new
                                    {
                                        newChannel.TimeBandBase.Id,
                                        newChannel.TimeBandBase.Name
                                    });
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Booking type
                if (true)
                {
                    Dictionary<BookingTypeEnum, string> bookingTypes = new Dictionary<BookingTypeEnum, string>();
                    foreach (BookingTypeEnum bookingType in Enum.GetValues(typeof(BookingTypeEnum)))
                    {
                        bookingTypes.Add(bookingType, bookingType.ToString());
                    }

                    // Remove all booking type not in booking type
                    newConnection.Execute(@"Delete Booking.BookingTypes Where Id not in(" + string.Join(",", bookingTypes.Select(t => (int)t.Key)) + ")");

                    var dbBookingTypes = contextNew.Booking_Types.ToList();

                    // Add or update booking type
                    int nb = 0;
                    foreach (var bookingType in bookingTypes.OrderBy(p => p.Value))
                    {
                        Console.Write($"\rProcessing {++nb} / {bookingTypes.Count} booking type");

                        var parentName = "";
                        var lastIndex = bookingType.Value.LastIndexOf('_');
                        if (lastIndex >= 0)
                            parentName = bookingType.Value.Substring(0, lastIndex);

                        var bookingTypeOld = dbBookingTypes.FirstOrDefault(t => t.Id == bookingType.Key);

                        BookingTypeEnum? parentId = parentName == "" ? null : (BookingTypeEnum?)bookingTypes.First(t => t.Value == parentName).Key;
                        if (parentId == null && bookingType.Key != BookingTypeEnum.All)
                            parentId = BookingTypeEnum.All;

                        if (bookingTypeOld == null)
                        {
                            bookingTypeOld = new BookingType()
                            {
                                Id = bookingType.Key,
                                Name = GetDisplayName((BookingTypeEnum)bookingType.Key),
                                Description = GetDisplayName((BookingTypeEnum)bookingType.Key),
                                ParentId = parentId
                            };
                            newConnection.Execute(@"Insert Into Booking.BookingTypes(Id, Name, Description, ParentId)
                                Values(@Id, @Name, @Description, @ParentId)",
                                new
                                {
                                    bookingTypeOld.Id,
                                    bookingTypeOld.Name,
                                    bookingTypeOld.Description,
                                    bookingTypeOld.ParentId
                                });
                            dbBookingTypes.Add(bookingTypeOld);
                        }
                        else if (bookingTypeOld.Name != GetDisplayName((BookingTypeEnum)bookingType.Key)
                            || bookingTypeOld.ParentId != parentId)
                        {
                            bookingTypeOld.Name = GetDisplayName((BookingTypeEnum)bookingType.Key);
                            bookingTypeOld.ParentId = parentId;

                            newConnection.Execute(@"Update Booking.BookingTypes Name = @Name
                                    , ParentId = @ParentId
                                Where Id = @Id",
                                new
                                {
                                    bookingTypeOld.Id,
                                    bookingTypeOld.Name,
                                    bookingTypeOld.ParentId
                                });
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                contextNew.Booking_TimeBandSliceDurations.Load();
                contextNew.Booking_TimeBandSliceDurationByTypes.Load();
                contextNew.System_TimeBandSliceDescriptions.Load();
                contextNew.System_TimeBands
                    .Include(t => t.TimeBandBase)
                    .Include(t => t.TimeOfDays)
                    .Include(t => t.Descriptions)
                    .Include(t => t.DayOfWeeks)
                    .Include(t => t.Slices)
                    .Include(t => t.Prices)
                    .Include(t => t.PositionRates)
                    .Load();
                var newTimeBands = contextNew.System_TimeBands.Local.ToList();

                #region Sync TimeBand
                if (true)
                {
                    contextOld.TimeBandSliceDescriptions.Load();
                    contextOld.TimeBands
                        .Include(t => t.Channel)
                        .Include(t => t.Descriptions)
                        .Include(t => t.Slices)
                        .Include(t => t.Prices)
                        .Include(t => t.PositionRates)
                        .Load();
                    var oldTimeBands = contextOld.TimeBands.Local.ToList();

                    int nb = 0;
                    foreach (var timeBand in oldTimeBands)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldTimeBands.Count} timeband");

                        var newChannel = newChannels.First(c => c.OldId == timeBand.Channel.Id);

                        // Time of day
                        var startTimeOfDay = timeBand.StartTimeOfDay != null ? timeBand.StartTimeOfDay.Value.TimeOfDay : TimeSpan.FromSeconds(0);
                        startTimeOfDay = TimeSpan.FromMinutes((int)startTimeOfDay.TotalMinutes);
                        var endTimeOfDay = timeBand.EndTimeOfDay != null ? timeBand.EndTimeOfDay.Value.TimeOfDay : TimeSpan.FromDays(1);
                        endTimeOfDay = TimeSpan.FromMinutes((int)endTimeOfDay.TotalMinutes);
                        if (endTimeOfDay <= startTimeOfDay)
                            endTimeOfDay += TimeSpan.FromDays(1);
                        int timeOfDayDuration = (int)(endTimeOfDay - startTimeOfDay).TotalSeconds;

                        // Day of weeks
                        if (timeBand.DayOfWeeks == null)
                            timeBand.DayOfWeeks = HD.TVADOld.Entities.Entities.DayOfWeek.None;

                        var newTimeBand = newTimeBands.FirstOrDefault(t => t.OldId == timeBand.Id);

                        if (newTimeBand == null)
                        {
                            newTimeBand = new HD.TVAD.Entities.Entities.System.TimeBand { OldId = timeBand.Id };
                            newTimeBand.TimeBandBase.TimeBand = newTimeBand;

                            newTimeBand.TimeBandBase.Name = timeBand.Name;
                            newTimeBand.TimeBandBase.Description = timeBand.Description;

                            newTimeBand.TimeBandBase.Parent = newChannel.TimeBandBase;
                            newTimeBand.TimeBandBase.ParentId = newChannel.Id;
                            newChannel.TimeBandBase.Childrens.Add(newTimeBand.TimeBandBase);

                            newConnection.Execute(@"Insert Into System.TimeBandBases(Id, Name, Description, ParentId)
                                Values(@Id, @Name, @Description, @ParentId)

                                Insert Into System.TimeBands(Id, OldId)
                                Values(@Id, @OldId)",
                                new
                                {
                                    newTimeBand.TimeBandBase.Id,
                                    newTimeBand.TimeBandBase.Name,
                                    newTimeBand.TimeBandBase.Description,
                                    newTimeBand.TimeBandBase.ParentId,
                                    newTimeBand.OldId
                                });

                            // Time of day
                            var timeOfDay = new HD.TVAD.Entities.Entities.System.TimeBandTime
                            {
                                TimeBand = newTimeBand,
                                TimeBandId = newTimeBand.Id,
                                StartDate = new DateTime(2017, 1, 1),
                                StartTimeOfDay = startTimeOfDay,
                                Duration = timeOfDayDuration
                            };
                            newTimeBand.TimeOfDays.Add(timeOfDay);

                            newConnection.Execute(@"Insert Into System.TimeBandTimes(Id, TimeBandId, StartDate, StartTimeOfDay, Duration)
                                Values(@Id, @TimeBandId, @StartDate, @StartTimeOfDay, @Duration)",
                                new
                                {
                                    timeOfDay.Id,
                                    timeOfDay.TimeBandId,
                                    timeOfDay.StartDate,
                                    timeOfDay.StartTimeOfDay,
                                    timeOfDay.Duration
                                });

                            // Descriptions
                            foreach (var description in timeBand.Descriptions)
                            {
                                var newDes = new HD.TVAD.Entities.Entities.System.TimeBandDescription
                                {
                                    TimeBandId = newTimeBand.Id,
                                    TimeBand = newTimeBand,
                                    StartDate = description.StartDate.Date,
                                    EndDate = description.EndDate == null ? null : (DateTime?)description.EndDate.Value.Date,
                                    Description = description.Description
                                };
                                newTimeBand.Descriptions.Add(newDes);

                                newConnection.Execute(@"Insert Into System.TimeBandDescriptions(Id, TimeBandId, StartDate, EndDate, Description)
                                    Values(@Id, @TimeBandId, @StartDate, @EndDate, @Description)",
                                    new
                                    {
                                        newDes.Id,
                                        newDes.TimeBandId,
                                        newDes.StartDate,
                                        newDes.EndDate,
                                        newDes.Description
                                    });
                            }

                            // Day of weeks
                            if (timeBand.DayOfWeeks != HD.TVADOld.Entities.Entities.DayOfWeek.None)
                            {
                                var dayOfWeek = new HD.TVAD.Entities.Entities.System.TimeBandDay
                                {
                                    TimeBandId = newTimeBand.Id,
                                    TimeBand = newTimeBand,
                                    StartDate = new DateTime(2017, 1, 1),
                                    DayOfWeeks = (HD.TVAD.Entities.Entities.System.DayOfWeek)timeBand.DayOfWeeks
                                };
                                newTimeBand.DayOfWeeks.Add(dayOfWeek);

                                newConnection.Execute(@"Insert Into System.TimeBandDays(Id, TimeBandId, StartDate, DayOfWeeks)
                                    Values(@Id, @TimeBandId, @StartDate, @DayOfWeeks)",
                                    new
                                    {
                                        dayOfWeek.Id,
                                        dayOfWeek.TimeBandId,
                                        dayOfWeek.StartDate,
                                        dayOfWeek.DayOfWeeks
                                    });
                            }

                            // Timeband slice
                            foreach (var slice in timeBand.Slices)
                            {
                                var newSlice = new HD.TVAD.Entities.Entities.System.TimeBandSlice
                                {
                                    TimeBandId = newTimeBand.Id,
                                    TimeBand = newTimeBand,
                                    Name = slice.SliceId.ToString()
                                };
                                newTimeBand.Slices.Add(newSlice);

                                newConnection.Execute(@"Insert Into System.TimeBandSlices(Id, TimeBandId, Name)
                                    Values(@Id, @TimeBandId, @Name)",
                                    new
                                    {
                                        newSlice.Id,
                                        newSlice.TimeBandId,
                                        newSlice.Name
                                    });

                                if (slice.MaxDurationForBooking != null || slice.MaxDurationForSponsor != null)
                                {
                                    int maxDuration = (slice.MaxDurationForBooking ?? 0) + (slice.MaxDurationForSponsor ?? 0);
                                    if (maxDuration > 0)
                                    {
                                        int maxDurationForBooking = slice.MaxDurationForBooking ?? 0;
                                        if (slice.DurationAddingForBooking != null)
                                            maxDurationForBooking += slice.DurationAddingForBooking.Value;
                                        int maxDurationForSponsor = slice.MaxDurationForSponsor ?? 0;
                                        if (slice.DurationAddingForSponsor != null)
                                            maxDurationForSponsor += slice.DurationAddingForSponsor.Value;
                                        var duration = new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDuration
                                        {
                                            TimeBandSliceId = newSlice.Id,
                                            TimeBandSlice = newSlice,
                                            StartDate = new DateTime(2017, 1, 1),
                                            Duration = maxDuration
                                        };
                                        newSlice.Durations.Add(duration);

                                        newConnection.Execute(@"Insert Into Booking.TimeBandSliceDurations(Id, TimeBandSliceId, StartDate, Duration)
                                            Values(@Id, @TimeBandSliceId, @StartDate, @Duration)",
                                            new
                                            {
                                                duration.Id,
                                                duration.TimeBandSliceId,
                                                duration.StartDate,
                                                duration.Duration
                                            });

                                        duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                        {
                                            TypeId = (int)HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.All,
                                            TimeBandSliceDurationId = duration.Id,
                                            DurationBase = duration,
                                            Duration = maxDuration
                                        });

                                        duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                        {
                                            TypeId = HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.Contract,
                                            TimeBandSliceDurationId = duration.Id,
                                            DurationBase = duration,
                                            Duration = maxDuration
                                        });

                                        duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                        {
                                            TypeId = HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.Contract_Booking,
                                            TimeBandSliceDurationId = duration.Id,
                                            DurationBase = duration,
                                            Duration = maxDurationForBooking
                                        });

                                        duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                        {
                                            TypeId = HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.Contract_Sponsor,
                                            TimeBandSliceDurationId = duration.Id,
                                            DurationBase = duration,
                                            Duration = maxDurationForSponsor
                                        });

                                        foreach (var durationByType in duration.DurationByTypes)
                                        {
                                            newConnection.Execute(@"Insert Into Booking.TimeBandSliceDurationByTypes(Id, TypeId, TimeBandSliceDurationId, Duration)
                                                Values(@Id, @TypeId, @TimeBandSliceDurationId, @Duration)",
                                            new
                                            {
                                                durationByType.Id,
                                                durationByType.TypeId,
                                                durationByType.TimeBandSliceDurationId,
                                                durationByType.Duration
                                            });
                                        }
                                    }
                                }

                                foreach (var des in slice.Descriptions)
                                {
                                    newSlice.Descriptions.Add(new HD.TVAD.Entities.Entities.System.TimeBandSliceDescription
                                    {
                                        TimeBandSliceId = newSlice.Id,
                                        Slice = newSlice,
                                        DayOfWeeks = (HD.TVAD.Entities.Entities.System.DayOfWeek)des.DayOfWeeks,
                                        StartDate = des.StartDate.Date,
                                        EndDate = des.EndDate == null ? null : (DateTime?)des.EndDate.Value.Date,
                                        Description = des.Description
                                    });
                                }

                                foreach (var newDes in newSlice.Descriptions)
                                {
                                    newConnection.Execute(@"Insert Into System.TimeBandSliceDescriptions(Id, TimeBandSliceId, DayOfWeeks, StartDate, EndDate, Description)
                                        Values(@Id, @TimeBandSliceId, @DayOfWeeks, @StartDate, @EndDate, @Description)",
                                        new
                                        {
                                            newDes.Id,
                                            newDes.TimeBandSliceId,
                                            newDes.DayOfWeeks,
                                            newDes.StartDate,
                                            newDes.EndDate,
                                            newDes.Description
                                        });
                                }
                            }

                            // Price
                            foreach (var price in timeBand.Prices)
                            {
                                var newBlock = newBlocks.FirstOrDefault(b => b.Duration == price.BlockDuration);
                                if (newBlock != null)
                                {
                                    var newPrice = new HD.TVAD.Entities.Entities.Price.TimeBandPrice
                                    {
                                        TimeBandId = newTimeBand.Id,
                                        TimeBand = newTimeBand,
                                        SpotBlockId = newBlock.Id,
                                        SpotBlock = newBlock,
                                        StartDate = price.StartDate.Date,
                                        Price = price.Price
                                    };
                                    newTimeBand.Prices.Add(newPrice);
                                    newBlock.Prices.Add(newPrice);
                                }
                            }
                            foreach (var newPrice in newTimeBand.Prices)
                            {
                                newConnection.Execute(@"Insert Into Price.TimeBandPrices(Id, TimeBandId, SpotBlockId, StartDate, Price)
                                    Values(@Id, @TimeBandId, @SpotBlockId, @StartDate, @Price)",
                                    new
                                    {
                                        newPrice.Id,
                                        newPrice.TimeBandId,
                                        newPrice.SpotBlockId,
                                        newPrice.StartDate,
                                        newPrice.Price
                                    });
                            }

                            // Position rate
                            foreach (var positionRate in timeBand.PositionRates)
                            {
                                newTimeBand.PositionRates.Add(new HD.TVAD.Entities.Entities.Price.PositionRate
                                {
                                    TimeBandId = newTimeBand.Id,
                                    TimeBand = newTimeBand,
                                    StartDate = positionRate.StartDate.Date,
                                    EndDate = positionRate.EndDate == null ? null : (DateTime?)positionRate.EndDate.Value.Date,
                                    Rate = positionRate.Rate
                                });
                            }
                            foreach (var newPositionRate in newTimeBand.PositionRates)
                            {
                                newConnection.Execute(@"Insert Into Price.PositionRates(Id, TimeBandId, StartDate, EndDate, Rate)
                                    Values(@Id, @TimeBandId, @StartDate, @EndDate, @Rate)",
                                    new
                                    {
                                        newPositionRate.Id,
                                        newPositionRate.TimeBandId,
                                        newPositionRate.StartDate,
                                        newPositionRate.EndDate,
                                        newPositionRate.Rate
                                    });
                            }

                            newTimeBands.Add(newTimeBand);
                        }
                        else
                        {
                            bool changedTimeBandBase = false;
                            if (newTimeBand.TimeBandBase.ParentId != newChannel.Id)
                            {
                                newTimeBand.TimeBandBase.ParentId = newChannel.Id;
                                changedTimeBandBase = true;
                            }

                            if (newTimeBand.TimeBandBase.Name != timeBand.Name)
                            {
                                newTimeBand.TimeBandBase.Name = timeBand.Name;
                                changedTimeBandBase = true;
                            }

                            if (newTimeBand.TimeBandBase.Description != timeBand.Description)
                            {
                                newTimeBand.TimeBandBase.Description = timeBand.Description;
                                changedTimeBandBase = true;
                            }

                            if (changedTimeBandBase)
                            {
                                newConnection.Execute(@"Update System.TimeBandBases Set Name = @Name
                                        , Description = @Description
                                        , ParentId = @ParentId
                                    Where Id = @Id",
                                new
                                {
                                    newTimeBand.TimeBandBase.Id,
                                    newTimeBand.TimeBandBase.Name,
                                    newTimeBand.TimeBandBase.Description,
                                    newTimeBand.TimeBandBase.ParentId
                                });
                            }

                            // Time of day
                            var oldTimeBandTime = newTimeBand.TimeOfDays.FirstOrDefault(t => t.StartTimeOfDay == startTimeOfDay || t.StartDate == new DateTime(2017, 1, 1));
                            if (oldTimeBandTime == null)
                            {
                                oldTimeBandTime = new HD.TVAD.Entities.Entities.System.TimeBandTime
                                {
                                    TimeBandId = newTimeBand.Id,
                                    TimeBand = newTimeBand,
                                    StartDate = new DateTime(2017, 1, 1),
                                    StartTimeOfDay = startTimeOfDay,
                                    Duration = timeOfDayDuration
                                };
                                newTimeBand.TimeOfDays.Add(oldTimeBandTime);

                                newConnection.Execute(@"Insert Into System.TimeBandTimes(Id, TimeBandId, StartDate, StartTimeOfDay, Duration)
                                    Values(@Id, @TimeBandId, @StartDate, @StartTimeOfDay, @Duration)",
                                new
                                {
                                    oldTimeBandTime.Id,
                                    oldTimeBandTime.TimeBandId,
                                    oldTimeBandTime.StartDate,
                                    oldTimeBandTime.StartTimeOfDay,
                                    oldTimeBandTime.Duration
                                });
                            }
                            else if (oldTimeBandTime.StartTimeOfDay != startTimeOfDay || oldTimeBandTime.Duration != timeOfDayDuration)
                            {
                                oldTimeBandTime.StartTimeOfDay = startTimeOfDay;
                                oldTimeBandTime.Duration = timeOfDayDuration;

                                newConnection.Execute(@"Update System.TimeBandTimes Set StartTimeOfDay = @StartTimeOfDay
                                        , Duration = @Duration
                                    Where Id = @Id",
                                    new
                                    {
                                        oldTimeBandTime.Id,
                                        oldTimeBandTime.StartTimeOfDay,
                                        oldTimeBandTime.Duration
                                    });
                            }

                            // Description
                            foreach (var description in timeBand.Descriptions)
                            {
                                var oldDescription = newTimeBand.Descriptions.FirstOrDefault(d => d.StartDate == description.StartDate.Date);
                                if (oldDescription == null)
                                {
                                    oldDescription = new HD.TVAD.Entities.Entities.System.TimeBandDescription
                                    {
                                        TimeBandId = newTimeBand.Id,
                                        TimeBand = newTimeBand,
                                        StartDate = description.StartDate.Date,
                                        EndDate = description.EndDate == null ? null : (DateTime?)description.EndDate.Value.Date,
                                        Description = description.Description
                                    };
                                    newTimeBand.Descriptions.Add(oldDescription);

                                    newConnection.Execute(@"Insert Into System.TimeBandDescriptions(Id, TimeBandId, StartDate, EndDate, Description)
                                        Values(@Id, @TimeBandId, @StartDate, @EndDate, @Description)",
                                    new
                                    {
                                        oldDescription.Id,
                                        oldDescription.TimeBandId,
                                        oldDescription.StartDate,
                                        oldDescription.EndDate,
                                        oldDescription.Description
                                    });
                                }
                                else
                                {
                                    bool changed = false;
                                    if (oldDescription.EndDate != (description.EndDate == null ? null : (DateTime?)description.EndDate.Value.Date))
                                    {
                                        oldDescription.EndDate = description.EndDate == null ? null : (DateTime?)description.EndDate.Value.Date;
                                        changed = true;
                                    }

                                    if (oldDescription.Description != description.Description)
                                    {
                                        oldDescription.Description = description.Description;
                                        changed = true;
                                    }

                                    if (changed)
                                    {
                                        newConnection.Execute(@"Update System.TimeBandDescriptions Set EndDate = @EndDate
                                                , Description = @Description
                                            Where Id = @Id",
                                            new
                                            {
                                                oldDescription.Id,
                                                oldDescription.EndDate,
                                                oldDescription.Description
                                            });
                                    }
                                }
                            }

                            // Day of weeks
                            if (timeBand.DayOfWeeks != HD.TVADOld.Entities.Entities.DayOfWeek.None)
                            {
                                var oldTimeBandDay = newTimeBand.DayOfWeeks.FirstOrDefault(t => (byte)t.DayOfWeeks == (byte)timeBand.DayOfWeeks || t.StartDate == new DateTime(2017, 1, 1));
                                if (oldTimeBandDay == null)
                                {
                                    oldTimeBandDay = new HD.TVAD.Entities.Entities.System.TimeBandDay
                                    {
                                        TimeBandId = newTimeBand.Id,
                                        TimeBand = newTimeBand,
                                        StartDate = new DateTime(2017, 1, 1),
                                        DayOfWeeks = (HD.TVAD.Entities.Entities.System.DayOfWeek)timeBand.DayOfWeeks
                                    };
                                    newTimeBand.DayOfWeeks.Add(oldTimeBandDay);

                                    newConnection.Execute(@"Insert Into System.TimeBandDays(Id, TimeBandId, StartDate, DayOfWeeks)
                                        Values(@Id, @TimeBandId, @StartDate, @DayOfWeeks)",
                                        new
                                        {
                                            oldTimeBandDay.Id,
                                            oldTimeBandDay.TimeBandId,
                                            oldTimeBandDay.StartDate,
                                            oldTimeBandDay.DayOfWeeks
                                        });
                                }
                                else if ((byte)oldTimeBandDay.DayOfWeeks != (byte)timeBand.DayOfWeeks)
                                {
                                    oldTimeBandDay.DayOfWeeks = (HD.TVAD.Entities.Entities.System.DayOfWeek)timeBand.DayOfWeeks;
                                    newConnection.Execute(@"Update System.TimeBandDays Set DayOfWeeks = @DayOfWeeks Where Id = @Id",
                                        new
                                        {
                                            oldTimeBandDay.Id,
                                            oldTimeBandDay.DayOfWeeks
                                        });
                                }
                            }

                            // Slice
                            foreach (var slice in timeBand.Slices)
                            {
                                var newSlice = newTimeBand.Slices.FirstOrDefault(s => s.Name == slice.SliceId.ToString());
                                if (newSlice == null)
                                {
                                    newSlice = new HD.TVAD.Entities.Entities.System.TimeBandSlice
                                    {
                                        TimeBandId = newTimeBand.Id,
                                        TimeBand = newTimeBand,
                                        Name = slice.SliceId.ToString()
                                    };
                                    newTimeBand.Slices.Add(newSlice);

                                    newConnection.Execute(@"Insert Into System.TimeBandSlices(Id, TimeBandId, Name)
                                        Values(@Id, @TimeBandId, @Name)",
                                        new
                                        {
                                            newSlice.Id,
                                            newSlice.TimeBandId,
                                            newSlice.Name
                                        });

                                    if (slice.MaxDurationForBooking != null || slice.MaxDurationForSponsor != null)
                                    {
                                        int maxDuration = (slice.MaxDurationForBooking ?? 0) + (slice.MaxDurationForSponsor ?? 0);
                                        if (maxDuration > 0)
                                        {
                                            int maxDurationForBooking = slice.MaxDurationForBooking ?? 0;
                                            if (slice.DurationAddingForBooking != null)
                                                maxDurationForBooking += slice.DurationAddingForBooking.Value;
                                            int maxDurationForSponsor = slice.MaxDurationForSponsor ?? 0;
                                            if (slice.DurationAddingForSponsor != null)
                                                maxDurationForSponsor += slice.DurationAddingForSponsor.Value;
                                            var duration = new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDuration
                                            {
                                                TimeBandSliceId = newSlice.Id,
                                                TimeBandSlice = newSlice,
                                                StartDate = new DateTime(2017, 1, 1),
                                                Duration = maxDuration
                                            };
                                            newSlice.Durations.Add(duration);

                                            newConnection.Execute(@"Insert Into Booking.TimeBandSliceDurations(Id, TimeBandSliceId, StartDate, Duration)
                                                Values(@Id, @TimeBandSliceId, @StartDate, @Duration)",
                                                new
                                                {
                                                    duration.Id,
                                                    duration.TimeBandSliceId,
                                                    duration.StartDate,
                                                    duration.Duration
                                                });

                                            duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                            {
                                                TypeId = (int)HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.All,
                                                TimeBandSliceDurationId = duration.Id,
                                                DurationBase = duration,
                                                Duration = maxDuration
                                            });

                                            duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                            {
                                                TypeId = HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.Contract,
                                                TimeBandSliceDurationId = duration.Id,
                                                DurationBase = duration,
                                                Duration = maxDuration
                                            });

                                            duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                            {
                                                TypeId = HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.Contract_Booking,
                                                TimeBandSliceDurationId = duration.Id,
                                                DurationBase = duration,
                                                Duration = maxDurationForBooking
                                            });

                                            duration.DurationByTypes.Add(new HD.TVAD.Entities.Entities.Booking.TimeBandSliceDurationByType
                                            {
                                                TypeId = HD.TVAD.Entities.Entities.Booking.BookingTypeEnum.Contract_Sponsor,
                                                TimeBandSliceDurationId = duration.Id,
                                                DurationBase = duration,
                                                Duration = maxDurationForSponsor
                                            });

                                            foreach (var durationByType in duration.DurationByTypes)
                                            {
                                                newConnection.Execute(@"Insert Into Booking.TimeBandSliceDurationByTypes(Id, TypeId, TimeBandSliceDurationId, Duration)
                                                Values(@Id, @TypeId, @TimeBandSliceDurationId, @Duration)",
                                                new
                                                {
                                                    durationByType.Id,
                                                    durationByType.TypeId,
                                                    durationByType.TimeBandSliceDurationId,
                                                    durationByType.Duration
                                                });
                                            }
                                        }
                                    }

                                    foreach (var des in slice.Descriptions)
                                    {
                                        newSlice.Descriptions.Add(new HD.TVAD.Entities.Entities.System.TimeBandSliceDescription
                                        {
                                            TimeBandSliceId = newSlice.Id,
                                            Slice = newSlice,
                                            DayOfWeeks = (HD.TVAD.Entities.Entities.System.DayOfWeek)des.DayOfWeeks,
                                            StartDate = des.StartDate.Date,
                                            EndDate = des.EndDate == null ? null : (DateTime?)des.EndDate.Value.Date,
                                            Description = des.Description
                                        });
                                    }

                                    foreach (var newDes in newSlice.Descriptions)
                                    {
                                        newConnection.Execute(@"Insert Into System.TimeBandSliceDescriptions(Id, TimeBandSliceId, DayOfWeeks, StartDate, EndDate, Description)
                                        Values(@Id, @TimeBandSliceId, @DayOfWeeks, @StartDate, @EndDate, @Description)",
                                            new
                                            {
                                                newDes.Id,
                                                newDes.TimeBandSliceId,
                                                newDes.DayOfWeeks,
                                                newDes.StartDate,
                                                newDes.EndDate,
                                                newDes.Description
                                            });
                                    }
                                }
                                else
                                {
                                    foreach (var des in slice.Descriptions)
                                    {
                                        var oldDes = newSlice.Descriptions.FirstOrDefault(d => d.StartDate == des.StartDate.Date && (int)d.DayOfWeeks == (int)des.DayOfWeeks);
                                        if (oldDes == null)
                                        {
                                            oldDes = new HD.TVAD.Entities.Entities.System.TimeBandSliceDescription
                                            {
                                                TimeBandSliceId = newSlice.Id,
                                                Slice = newSlice,
                                                DayOfWeeks = (HD.TVAD.Entities.Entities.System.DayOfWeek)des.DayOfWeeks,
                                                StartDate = des.StartDate.Date,
                                                EndDate = des.EndDate == null ? null : (DateTime?)des.EndDate.Value.Date,
                                                Description = des.Description
                                            };
                                            newSlice.Descriptions.Add(oldDes);

                                            newConnection.Execute(@"Insert Into System.TimeBandSliceDescriptions(Id, TimeBandSliceId, DayOfWeeks, StartDate, EndDate, Description)
                                                Values(@Id, @TimeBandSliceId, @DayOfWeeks, @StartDate, @EndDate, @Description)",
                                                new
                                                {
                                                    oldDes.Id,
                                                    oldDes.TimeBandSliceId,
                                                    oldDes.DayOfWeeks,
                                                    oldDes.StartDate,
                                                    oldDes.EndDate,
                                                    oldDes.Description
                                                });
                                        }
                                    }
                                }
                            }

                            // Price
                            foreach (var price in timeBand.Prices)
                            {
                                var newBlock = newBlocks.FirstOrDefault(b => b.Duration == price.BlockDuration);
                                if (newBlock != null)
                                {
                                    var oldPrice = newTimeBand.Prices.FirstOrDefault(p => p.SpotBlockId == newBlock.Id && p.StartDate == price.StartDate.Date);
                                    if (oldPrice == null)
                                    {
                                        oldPrice = new HD.TVAD.Entities.Entities.Price.TimeBandPrice
                                        {
                                            TimeBandId = newTimeBand.Id,
                                            TimeBand = newTimeBand,
                                            SpotBlockId = newBlock.Id,
                                            SpotBlock = newBlock,
                                            StartDate = price.StartDate.Date,
                                            Price = price.Price
                                        };
                                        newTimeBand.Prices.Add(oldPrice);
                                        newBlock.Prices.Add(oldPrice);

                                        newConnection.Execute(@"Insert Into Price.TimeBandPrices(Id, TimeBandId, SpotBlockId, StartDate, Price)
                                            Values(@Id, @TimeBandId, @SpotBlockId, @StartDate, @Price)",
                                            new
                                            {
                                                oldPrice.Id,
                                                oldPrice.TimeBandId,
                                                oldPrice.SpotBlockId,
                                                oldPrice.StartDate,
                                                oldPrice.Price
                                            });
                                    }
                                    else if (oldPrice.Price != price.Price)
                                    {
                                        oldPrice.Price = price.Price;

                                        newConnection.Execute(@"Update Price.TimeBandPrices Set Price = @Price
                                            Where Id = @Id",
                                            new
                                            {
                                                oldPrice.Id,
                                                oldPrice.Price
                                            });
                                    }
                                }
                            }

                            // Position rate
                            foreach (var positionRate in timeBand.PositionRates)
                            {
                                var oldRate = newTimeBand.PositionRates.FirstOrDefault(r => r.StartDate == positionRate.StartDate.Date);
                                if (oldRate == null)
                                {
                                    oldRate = new HD.TVAD.Entities.Entities.Price.PositionRate
                                    {
                                        TimeBandId = newTimeBand.Id,
                                        TimeBand = newTimeBand,
                                        StartDate = positionRate.StartDate.Date,
                                        EndDate = positionRate.EndDate == null ? null : (DateTime?)positionRate.EndDate.Value.Date,
                                        Rate = positionRate.Rate
                                    };
                                    newTimeBand.PositionRates.Add(oldRate);

                                    newConnection.Execute(@"Insert Into Price.PositionRates(Id, TimeBandId, StartDate, EndDate, Rate)
                                        Values(@Id, @TimeBandId, @StartDate, @EndDate, @Rate)",
                                        new
                                        {
                                            oldRate.Id,
                                            oldRate.TimeBandId,
                                            oldRate.StartDate,
                                            oldRate.EndDate,
                                            oldRate.Rate
                                        });
                                }
                                else
                                {
                                    bool changed = false;
                                    if (oldRate.Rate != positionRate.Rate)
                                    {
                                        oldRate.Rate = positionRate.Rate;
                                        changed = true;
                                    }

                                    if (oldRate.EndDate != (positionRate.EndDate == null ? null : (DateTime?)positionRate.EndDate.Value.Date))
                                    {
                                        oldRate.EndDate = positionRate.EndDate == null ? null : (DateTime?)positionRate.EndDate.Value.Date;
                                        changed = true;
                                    }

                                    if (changed)
                                    {
                                        newConnection.Execute(@"Update Price.PositionRates Set EndDate = @EndDate
                                                , Rate = @Rate
                                            Where Id = @Id",
                                            new
                                            {
                                                oldRate.Id,
                                                oldRate.EndDate,
                                                oldRate.Rate
                                            });
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Position rate
                if (true)
                {
                    var oldPositionRates = contextOld.PositionRates.ToList();
                    var newPositionRates = contextNew.Price_PositionRates.ToList();
                    int nb = 0;
                    foreach (var positionRate in oldPositionRates)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldPositionRates.Count}");
                        positionRate.Rate /= 100.0M;
                        var newPositionRate = newPositionRates.FirstOrDefault(r => r.TimeBandId == null && r.StartDate == positionRate.StartDate.Date);
                        if (newPositionRate == null)
                        {
                            newPositionRate = new HD.TVAD.Entities.Entities.Price.PositionRate
                            {
                                TimeBand = null,
                                TimeBandId = null,
                                StartDate = positionRate.StartDate.Date,
                                EndDate = null,
                                Rate = positionRate.Rate
                            };

                            newConnection.Execute(@"Insert Into Price.PositionRates(Id, StartDate, EndDate, Rate)
                                Values(@Id, @StartDate, @EndDate, @Rate)",
                                new
                                {
                                    newPositionRate.Id,
                                    newPositionRate.StartDate,
                                    newPositionRate.EndDate,
                                    newPositionRate.Rate
                                });

                            newPositionRates.Add(newPositionRate);
                        }
                        else
                        {
                            bool changed = false;
                            if (newPositionRate.Rate != positionRate.Rate)
                            {
                                newPositionRate.Rate = positionRate.Rate;
                                changed = true;
                            }
                            if (newPositionRate.EndDate != null)
                            {
                                newPositionRate.EndDate = null;
                                changed = true;
                            }

                            if (changed)
                            {
                                newConnection.Execute(@"Update Price.PositionRates Set StartDate = @StartDate,
                                        EndDate = @EndDate,
                                        Rate = @Rate
                                    Where Id = @Id",
                                new
                                {
                                    newPositionRate.Id,
                                    newPositionRate.StartDate,
                                    newPositionRate.EndDate,
                                    newPositionRate.Rate
                                });
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Customer type
                if (true)
                {
                    Dictionary<CustomerTypeEnum, string> customerTypes = new Dictionary<CustomerTypeEnum, string>();
                    foreach (CustomerTypeEnum customerType in Enum.GetValues(typeof(CustomerTypeEnum)))
                    {
                        customerTypes.Add(customerType, GetDisplayName(customerType));
                    }

                    // Delete all customer type not in type
                    newConnection.Execute(@"Delete Contract.CustomerTypes Where Id not in(" + string.Join(",", customerTypes.Select(t => (int)t.Key)) + ")");

                    // Get all customer type in db
                    var dbCustomerTypes = contextNew.Contract_CustomerTypes.ToList();

                    int nb = 0;
                    // Add or update customer type
                    foreach (var customerType in customerTypes)
                    {
                        Console.Write($"\rProcessing {++nb} / {customerTypes.Count} customer type");

                        var typeOld = dbCustomerTypes.FirstOrDefault(t => t.Id == customerType.Key);

                        if (typeOld == null)
                        {
                            typeOld = new CustomerType
                            {
                                Id = customerType.Key,
                                Name = customerType.Value,
                                Description = customerType.Value
                            };
                            dbCustomerTypes.Add(typeOld);

                            newConnection.Execute(@"Insert Into Contract.CustomerTypes(Id, Name, Description)
                                Values(@Id, @Name, @Description)",
                                new
                                {
                                    typeOld.Id,
                                    typeOld.Name,
                                    typeOld.Description
                                });
                        }
                        else if (typeOld.Name != customerType.Value)
                        {
                            typeOld.Name = customerType.Value;
                            newConnection.Execute(@"Update Contract.CustomerTypes Set Name = @Name Where Id = @Id",
                                new
                                {
                                    typeOld.Id,
                                    typeOld.Name
                                });
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                var newPartnerCustomers = contextNew
                    .Contract_PartnerCustomers
                    .Include(c => c.BaseCustomer)
                    .Include(c => c.Discounts)
                    .ToList();

                #region Partner customer
                if (true)
                {
                    var oldPartnerCustomers = contextOld.PartnerCustomers
                        .Include(c => c.Discounts)
                        .ToList();

                    int nb = 0;
                    foreach (var customer in oldPartnerCustomers)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldPartnerCustomers.Count} partner customer");
                        if (customer.Code != null)
                        {
                            if (customer.Type == null)
                                customer.Type = HD.TVADOld.Entities.Entities.PartnerCustomerTypeEnum.NoPermanent;
                            if (customer.Name == null)
                                customer.Name = "";

                            var newCustomer = newPartnerCustomers.FirstOrDefault(c => c.OldId == customer.Id);
                            if (newCustomer == null)
                            {
                                newCustomer = new PartnerCustomer
                                {
                                    Code = customer.Code,
                                    PhoneNumber = customer.PhoneNumber,
                                    FaxNumber = customer.FaxNumber,
                                    RepresentivePerson = customer.RepresentivePerson,
                                    PositionOfRepresentivePerson = customer.PositionOfRepresentivePerson,
                                    AccountNumber = customer.AccountNumber,
                                    TaxNumber = customer.TaxNumber,
                                    OldId = customer.Id
                                };
                                newCustomer.BaseCustomer.TypeId = (CustomerTypeEnum)customer.Type;
                                newCustomer.BaseCustomer.Name = customer.Name;
                                newCustomer.BaseCustomer.Address = customer.Address;
                                newCustomer.BaseCustomer.PartnerCustomer = newCustomer;

                                newConnection.Execute(@"Insert Into Contract.Customers(Id, TypeId, Name, Address)
                                    Values(@Id, @TypeId, @Name, @Address)

                                    Insert Into Contract.CustomerPartners(Id, Code, PhoneNumber, FaxNumber, RepresentivePerson
                                        , PositionOfRepresentivePerson, AccountNumber, TaxNumber, OldId)
                                    Values(@Id, @Code, @PhoneNumber, @FaxNumber, @RepresentivePerson
                                        , @PositionOfRepresentivePerson, @AccountNumber, @TaxNumber, @OldId)",
                                        new
                                        {
                                            newCustomer.BaseCustomer.Id,
                                            newCustomer.BaseCustomer.TypeId,
                                            newCustomer.BaseCustomer.Name,
                                            newCustomer.BaseCustomer.Address,
                                            newCustomer.Code,
                                            newCustomer.PhoneNumber,
                                            newCustomer.FaxNumber,
                                            newCustomer.RepresentivePerson,
                                            newCustomer.PositionOfRepresentivePerson,
                                            newCustomer.AccountNumber,
                                            newCustomer.TaxNumber,
                                            newCustomer.OldId
                                        });
                                newPartnerCustomers.Add(newCustomer);
                            }
                            else
                            {
                                bool changedBase = false;
                                if ((int)newCustomer.BaseCustomer.TypeId != (int)customer.Type)
                                {
                                    newCustomer.BaseCustomer.TypeId = (CustomerTypeEnum)customer.Type;
                                    changedBase = true;
                                }
                                if (newCustomer.BaseCustomer.Name != customer.Name && !string.IsNullOrWhiteSpace(customer.Name))
                                {
                                    newCustomer.BaseCustomer.Name = customer.Name;
                                    changedBase = true;
                                }
                                if (newCustomer.BaseCustomer.Address != customer.Address)
                                {
                                    newCustomer.BaseCustomer.Address = customer.Address;
                                    changedBase = true;
                                }
                                bool changed = false;
                                if (newCustomer.Code != customer.Code && !string.IsNullOrWhiteSpace(customer.Code))
                                {
                                    newCustomer.Code = customer.Code;
                                    changed = true;
                                }
                                if (newCustomer.PhoneNumber != customer.PhoneNumber)
                                {
                                    newCustomer.PhoneNumber = customer.PhoneNumber;
                                    changed = true;
                                }
                                if (newCustomer.FaxNumber != customer.FaxNumber)
                                {
                                    newCustomer.FaxNumber = customer.FaxNumber;
                                    changed = true;
                                }
                                if (newCustomer.RepresentivePerson != customer.RepresentivePerson)
                                {
                                    newCustomer.RepresentivePerson = customer.RepresentivePerson;
                                    changed = true;
                                }
                                if (newCustomer.PositionOfRepresentivePerson != customer.PositionOfRepresentivePerson)
                                {
                                    newCustomer.PositionOfRepresentivePerson = customer.PositionOfRepresentivePerson;
                                    changed = true;
                                }
                                if (newCustomer.AccountNumber != customer.AccountNumber)
                                {
                                    newCustomer.AccountNumber = customer.AccountNumber;
                                    changed = true;
                                }
                                if (newCustomer.TaxNumber != customer.TaxNumber)
                                {
                                    newCustomer.TaxNumber = customer.TaxNumber;
                                    changed = true;
                                }

                                if (changedBase)
                                {
                                    newConnection.Execute(@"Update Contract.Customers Set TypeId = @TypeId,
                                            Name = @Name,
                                            Address = @Address
                                        Where Id = @Id",
                                        new
                                        {
                                            newCustomer.BaseCustomer.Id,
                                            newCustomer.BaseCustomer.TypeId,
                                            newCustomer.BaseCustomer.Name,
                                            newCustomer.BaseCustomer.Address
                                        });
                                }

                                if (changed)
                                {
                                    newConnection.Execute(@"Update Contract.CustomerPartners Set Code = @Code,
                                            PhoneNumber = PhoneNumber,
                                            FaxNumber = @FaxNumber,
                                            RepresentivePerson = @RepresentivePerson,
                                            PositionOfRepresentivePerson = @PositionOfRepresentivePerson,
                                            AccountNumber = @AccountNumber,
                                            TaxNumber = @TaxNumber
                                        Where Id = @Id",
                                        new
                                        {
                                            newCustomer.Id,
                                            newCustomer.Code,
                                            newCustomer.PhoneNumber,
                                            newCustomer.FaxNumber,
                                            newCustomer.RepresentivePerson,
                                            newCustomer.PositionOfRepresentivePerson,
                                            newCustomer.AccountNumber,
                                            newCustomer.TaxNumber
                                        });
                                }
                            }

                            // Discount
                            foreach (var discount in customer.Discounts)
                            {
                                var newDiscount = newCustomer.Discounts.FirstOrDefault(d => d.StartDate == discount.StartDate.Date);
                                if (newDiscount == null)
                                {
                                    newDiscount = new DiscountCustomer
                                    {
                                        Customer = newCustomer,
                                        CustomerId = newCustomer.Id,

                                        StartDate = discount.StartDate.Date,
                                        EndDate = discount.EndDate,
                                        Rate = discount.Rate / 100.0M,
                                        Description = discount.Description
                                    };
                                    newCustomer.Discounts.Add(newDiscount);

                                    newConnection.Execute(@"Insert Into Price.DiscountCustomers(Id, CustomerId, StartDate, EndDate, Rate, Description)
                                            Values(@Id, @CustomerId, @StartDate, @EndDate, @Rate, @Description)",
                                            new
                                            {
                                                newDiscount.Id,
                                                newDiscount.CustomerId,
                                                newDiscount.StartDate,
                                                newDiscount.EndDate,
                                                newDiscount.Rate,
                                                newDiscount.Description
                                            });
                                }
                                else
                                {
                                    bool changed = false;
                                    if (newDiscount.EndDate != (discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date))
                                    {
                                        newDiscount.EndDate = discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date;
                                        changed = true;
                                    }

                                    if (newDiscount.Rate != discount.Rate / 100.0M)
                                    {
                                        newDiscount.Rate = discount.Rate / 100.0M;
                                        changed = true;
                                    }

                                    if (changed)
                                    {
                                        newConnection.Execute(@"Update Price.DiscountCustomers Set EndDate = @EndDate
                                                , Rate = @Rate
                                            Where Id = @Id",
                                            new
                                            {
                                                newDiscount.Id,
                                                newDiscount.EndDate,
                                                newDiscount.Rate
                                            });
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                var newSponsorPrograms = contextNew.System_SponsorPrograms
                    .Include(p => p.Discounts)
                    .ToList();

                #region Sponsor program
                if (true)
                {
                    var oldSponsorPrograms = contextOld.SponsorPrograms
                        .Include(p => p.Discounts)
                        .ToList();

                    int nb = 0;
                    foreach (var program in oldSponsorPrograms)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldSponsorPrograms.Count} sponsor program");
                        var newProgram = newSponsorPrograms.FirstOrDefault(p => p.OldId == program.Id);
                        if (newProgram == null)
                        {
                            newProgram = new HD.TVAD.Entities.Entities.System.SponsorProgram
                            {
                                Code = program.Code,
                                Name = program.Name,
                                Description = program.Description,
                                EndDate = program.EndDate,
                                OldId = program.Id
                            };
                            newConnection.Execute(@"Insert Into System.SponsorPrograms(Id, Code, Name, Description, EndDate, OldId)
                                Values(@Id, @Code, @Name, @Description, @EndDate, @OldId)",
                                new
                                {
                                    newProgram.Id,
                                    newProgram.Code,
                                    newProgram.Name,
                                    newProgram.Description,
                                    newProgram.EndDate,
                                    newProgram.OldId
                                });
                            newSponsorPrograms.Add(newProgram);
                        }
                        else
                        {
                            bool changed = false;
                            if (newProgram.Code != program.Code)
                            {
                                newProgram.Code = program.Code;
                                changed = true;
                            }
                            if (newProgram.Name != program.Name)
                            {
                                newProgram.Name = program.Name;
                                changed = true;
                            }
                            if (newProgram.Description != program.Description)
                            {
                                newProgram.Description = program.Description;
                                changed = true;
                            }
                            if (newProgram.EndDate != program.EndDate)
                            {
                                newProgram.EndDate = program.EndDate;
                                changed = true;
                            }
                            if (changed)
                            {
                                newConnection.Execute(@"Update System.SponsorPrograms Set Code = @Code
                                    , Name = @Name
                                    , Description = @Description
                                    , EndDate = @EndDate
                                Where Id = @Id",
                                new
                                {
                                    newProgram.Id,
                                    newProgram.Code,
                                    newProgram.Name,
                                    newProgram.Description,
                                    newProgram.EndDate
                                });
                            }
                        }

                        // Discount
                        foreach (var discount in program.Discounts)
                        {
                            var newDiscount = newProgram.Discounts.FirstOrDefault(d => d.StartDate == discount.StartDate.Date);
                            if (newDiscount == null)
                            {
                                newDiscount = new DiscountSponsorProgram
                                {
                                    SponsorProgram = newProgram,
                                    ProgramId = newProgram.Id,

                                    StartDate = discount.StartDate.Date,
                                    EndDate = discount.EndDate,
                                    Rate = discount.Rate / 100.0M,
                                    Description = discount.Description
                                };
                                newProgram.Discounts.Add(newDiscount);

                                newConnection.Execute(@"Insert Into Price.DiscountSponsorPrograms(Id, ProgramId, StartDate, EndDate, Rate, Description)
                                    Values(@Id, @ProgramId, @StartDate, @EndDate, @Rate, @Description)",
                                    new
                                    {
                                        newDiscount.Id,
                                        newDiscount.ProgramId,
                                        newDiscount.StartDate,
                                        newDiscount.EndDate,
                                        newDiscount.Rate,
                                        newDiscount.Description
                                    });
                            }
                            else
                            {
                                bool changed = false;
                                if (newDiscount.Rate != discount.Rate / 100.0M)
                                {
                                    newDiscount.Rate = discount.Rate / 100.0M;
                                    changed = true;
                                }

                                if (newDiscount.EndDate != (discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date))
                                {
                                    newDiscount.EndDate = discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date;
                                    changed = true;
                                }

                                if (changed)
                                {
                                    newConnection.Execute(@"Update Price.DiscountSponsorPrograms Set EndDate = @EndDate
                                            , Rate = @Rate
                                        Where Id = @Id",
                                        new
                                        {
                                            newDiscount.Id,
                                            newDiscount.EndDate,
                                            newDiscount.Rate
                                        });
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                var newRegisters = contextNew.MediaAsset_Registers.ToList();

                #region Sync Register
                if (true)
                {
                    var oldRegisters = contextOld.Registers.Where(r => r.Name != null).ToList();
                    int nb = 0;
                    foreach (var register in oldRegisters)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldRegisters.Count} register");
                        var newRegister = newRegisters.FirstOrDefault(r => r.OldId == register.Id);
                        if (newRegister == null)
                        {
                            newRegister = new HD.TVAD.Entities.Entities.MediaAsset.Register
                            {
                                Code = register.Code,
                                Name = register.Name,
                                OldId = register.Id
                            };
                            newConnection.Execute(@"Insert Into Asset.Registers(Id, Code, Name, OldId)
                                Values(@Id, @Code, @Name, @OldId)",
                                new
                                {
                                    newRegister.Id,
                                    newRegister.Code,
                                    newRegister.Name,
                                    newRegister.OldId
                                });
                            newRegisters.Add(newRegister);
                        }
                        else
                        {
                            bool changed = false;
                            if (newRegister.Code != register.Code)
                            {
                                newRegister.Code = register.Code;
                                changed = true;
                            }
                            if (newRegister.Name != register.Name)
                            {
                                newRegister.Name = register.Name;
                                changed = true;
                            }
                            if (changed)
                            {
                                newConnection.Execute(@"Update Asset.Registers Set Code = @Code, Name = @Name, OldId = @OldId
                                    Where Id = @Id",
                                    new
                                    {
                                        newRegister.Id,
                                        newRegister.Code,
                                        newRegister.Name,
                                        newRegister.OldId
                                    });
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                var newProducers = contextNew.MediaAsset_Producers.ToList();

                var newContents = contextNew.MediaAsset_Contents
                    .Include(c => c.Register)
                    .Include(c => c.Producer)
                    .ToList();

                #region Sync content
                if (false)
                {
                    var oldContents = contextOld.Contents.ToList();

                    int nb = 0;
                    foreach (var content in oldContents)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldContents.Count} content");
                        HD.TVAD.Entities.Entities.MediaAsset.Register newRegister = null;
                        if (content.RegisterId != null)
                            newRegister = newRegisters.FirstOrDefault(r => r.OldId == content.RegisterId);
                        HD.TVAD.Entities.Entities.MediaAsset.Producer newProducer = null;
                        if (!string.IsNullOrWhiteSpace(content.ProducerName))
                        {
                            newProducer = newProducers.FirstOrDefault(p => p.Name.ToLower() == content.ProducerName.Trim().ToLower());
                            if (newProducer == null)
                            {
                                newProducer = new HD.TVAD.Entities.Entities.MediaAsset.Producer
                                {
                                    Name = content.ProducerName.Trim()
                                };
                                newConnection.Execute(@"Insert Into Asset.Producers(Id, Name)Values(@Id, @Name)", new { newProducer.Id, newProducer.Name });
                                newProducers.Add(newProducer);
                            }
                        }

                        var newContent = newContents.FirstOrDefault(c => c.OldId == content.Id);

                        var approve = content.Approve;
                        if (approve == HD.TVADOld.Entities.Entities.ContentApproveEnum.Approve)
                            content.ApproveEndDate = null;
                        if (approve == HD.TVADOld.Entities.Entities.ContentApproveEnum.TemporaryApprove)
                            approve = HD.TVADOld.Entities.Entities.ContentApproveEnum.Approve;
                        if (newContent == null)
                        {
                            newContent = new HD.TVAD.Entities.Entities.MediaAsset.Content
                            {
                                Code = content.Code,
                                ProductName = content.ProductName ?? "",
                                ProductModel = content.ProductModel,
                                BlockDuration = content.BlockDuration,
                                CreateTime = content.CreateTime ?? new DateTime(2017, 1, 1),
                                EndDate = content.EndDate,
                                TypeId = content.Code.StartsWith("ĐG") ? AppSettings.Default.ContentTypeDOCId : AppSettings.Default.ContentTypeTVCId,
                                Register = newRegister,
                                RegisterId = newRegister == null ? null : (Guid?)newRegister.Id,
                                Producer = newProducer,
                                ProducerId = newProducer == null ? null : (Guid?)newProducer.Id,
                                Approve = approve == null ? null : (bool?)(approve == HD.TVADOld.Entities.Entities.ContentApproveEnum.Approve ? true : false),
                                ApproveEndDate = content.ApproveEndDate,
                                ApproveComment = content.ApproveComment,
                                ApproveTime = content.ApproveTime,
                                OldId = content.Id
                            };
                            newConnection.Execute(@"Insert Into MediaAssets.Content(Id, Code, ProductName, ProductModel, BlockDuration, CreateTime
                                        , EndDate, TypeId, RegisterId, ProducerId, Approve, ApproveEndDate, ApproveComment, ApproveTime, OldId)
                                    Values(@Id, @Code, @ProductName, @ProductModel, @BlockDuration, @CreateTime
                                        , @EndDate, @TypeId, @RegisterId, @ProducerId, @Approve, @ApproveEndDate, @ApproveComment, @ApproveTime, @OldId)",
                                    new
                                    {
                                        newContent.Id,
                                        newContent.Code,
                                        newContent.ProductName,
                                        newContent.ProductModel,
                                        newContent.BlockDuration,
                                        newContent.CreateTime,
                                        newContent.EndDate,
                                        newContent.TypeId,
                                        newContent.RegisterId,
                                        newContent.ProducerId,
                                        newContent.Approve,
                                        newContent.ApproveEndDate,
                                        newContent.ApproveComment,
                                        newContent.ApproveTime,
                                        newContent.OldId
                                    });
                            newContents.Add(newContent);
                        }
                        else
                        {
                            bool change = false;
                            if (newContent.Code != content.Code)
                            {
                                newContent.Code = content.Code;
                                change = true;
                            }

                            if (newContent.ProductName != (content.ProductName ?? ""))
                            {
                                newContent.ProductName = content.ProductName ?? "";
                                change = true;
                            }

                            if (newContent.ProductModel != content.ProductModel)
                            {
                                newContent.ProductModel = content.ProductModel;
                                change = true;
                            }

                            if (newContent.BlockDuration != content.BlockDuration)
                            {
                                newContent.BlockDuration = content.BlockDuration;
                                change = true;
                            }

                            if (newContent.Register != newRegister)
                            {
                                newContent.Register = newRegister;
                                newContent.RegisterId = newRegister == null ? null : (Guid?)newRegister.Id;
                                change = true;
                            }

                            if (newContent.Producer != newProducer)
                            {
                                newContent.Producer = newProducer;
                                newContent.ProducerId = newProducer == null ? null : (Guid?)newProducer.Id;
                                change = true;
                            }

                            if (newContent.Approve != (approve == null ? null : (bool?)(approve == HD.TVADOld.Entities.Entities.ContentApproveEnum.Approve ? true : false)))
                            {
                                newContent.Approve = approve == null ? null : (bool?)(approve == HD.TVADOld.Entities.Entities.ContentApproveEnum.Approve ? true : false);
                                change = true;
                            }

                            if (newContent.ApproveEndDate != content.ApproveEndDate)
                            {
                                newContent.ApproveEndDate = content.ApproveEndDate;
                                change = true;
                            }

                            if (newContent.ApproveComment != content.ApproveComment)
                            {
                                newContent.ApproveComment = content.ApproveComment;
                                change = true;
                            }

                            if (newContent.ApproveTime != content.ApproveTime)
                            {
                                newContent.ApproveTime = content.ApproveTime;
                                change = true;
                            }

                            if (change)
                            {
                                newConnection.Execute(@"Update MediaAssets.Content Set Code = @Code
                                            , ProductName = @ProductName
                                            , ProductModel  = @ProductModel
                                            , BlockDuration = @BlockDuration
                                            , CreateTime = @CreateTime
                                            , EndDate = @EndDate
                                            , TypeId = @TypeId
                                            , RegisterId = @RegisterId
                                            , ProducerId = @ProducerId
                                            , Approve = @Approve
                                            , ApproveEndDate = @ApproveEndDate
                                            , ApproveComment = @ApproveComment
                                            , ApproveTime = @ApproveTime
                                        Where Id = @Id",
                                    new
                                    {
                                        newContent.Id,
                                        newContent.Code,
                                        newContent.ProductName,
                                        newContent.ProductModel,
                                        newContent.BlockDuration,
                                        newContent.CreateTime,
                                        newContent.EndDate,
                                        newContent.TypeId,
                                        newContent.RegisterId,
                                        newContent.ProducerId,
                                        newContent.Approve,
                                        newContent.ApproveEndDate,
                                        newContent.ApproveComment,
                                        newContent.ApproveTime
                                    });
                            }
                        }

                        if (!contextNew.Workflow_Workflows.Any(w => w.ExternalId == newContent.Id))
                        {
                            var attachResult = AttachWorkflow(newContent.Id);
                            if (attachResult.State == WorkflowResultState.None)
                                Console.WriteLine($"Could not run attach workflow for content {newContent.Id} - {newContent.Code}: {attachResult.Message}");
                            else if (attachResult.State == WorkflowResultState.Failed)
                                Console.WriteLine($"Failed to attach workflow for content {newContent.Id} - {newContent.Code}: {attachResult.Message}");
                        }
                    }

                    Console.WriteLine();
                }
                #endregion

                #region Content timeband lock
                if (false)
                {
                    var oldContentTimeBandLocks = contextOld.ContentTimeBandLocks
                        .Include(l => l.Content)
                        .ToList();
                    var newContentTimeBandLooks = contextNew
                        .Booking_ContentTimeBandLocks
                        .Include(b => b.Content)
                        .Include(b => b.TimeBand)
                        .ToList();

                    int nbAdd = 0;
                    foreach (var oldLock in oldContentTimeBandLocks)
                    {
                        Console.Write($"\rProcessing {++nbAdd}/{oldContentTimeBandLocks.Count} content timeband lock");
                        var newContent = newContents.FirstOrDefault(c => c.OldId == oldLock.Content.Id);
                        if (newContent != null)
                        {
                            var newTimeBand = newTimeBands.FirstOrDefault(t => t.OldId == oldLock.TimeBandId);
                            if (newTimeBand != null)
                            {
                                var newLock = newContentTimeBandLooks.FirstOrDefault(l => l.ContentId == newContent.Id && l.TimeBandId == newTimeBand.Id);
                                if (newLock == null)
                                {
                                    newLock = new HD.TVAD.Entities.Entities.Booking.ContentTimeBandLock
                                    {
                                        Content = newContent,
                                        ContentId = newContent.Id,
                                        TimeBand = newTimeBand,
                                        TimeBandId = newTimeBand.Id
                                    };
                                    newContent.TimeBandLocks.Add(newLock);
                                    newTimeBand.ContentLocks.Add(newLock);
                                    newConnection.Execute("Insert Into Booking.ContentTimeBandLocks(Id, ContentId, TimeBandId)Values(@Id, @ContentId, @TimeBandId)",
                                        new
                                        {
                                            newLock.Id,
                                            newLock.ContentId,
                                            newLock.TimeBandId
                                        });
                                    newContentTimeBandLooks.Add(newLock);
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Content channel lock
                if (false)
                {
                    contextOld.Channels.Load();
                    contextOld.Contents.Load();
                    contextOld.TimeBands.Load();
                    contextOld.ContentChannelLocks.Load();
                    contextOld.ContentChannelLock_TimeBandNoLocks.Load();

                    var oldContentChannelLocks = contextOld.ContentChannelLocks.Local.ToList();
                    var oldContentChannelLock_TimeBandNoLocks = contextOld.ContentChannelLock_TimeBandNoLocks.ToList();

                    var newContentChannelLocks = contextNew.Booking_ContentChannelLocks
                        .Include(l => l.ChildrenNoLocks)
                        .ToList();

                    int nb = 0;
                    foreach (var channelLock in oldContentChannelLocks)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldContentChannelLocks.Count} content channel lock");

                        var newContent = newContents.FirstOrDefault(c => c.OldId == channelLock.Content.Id);
                        if (newContent != null)
                        {
                            var newChannel = newChannels.FirstOrDefault(c => c.OldId == channelLock.Channel.Id);
                            if (newChannel != null)
                            {
                                var newLock = newContentChannelLocks.FirstOrDefault(l => l.ContentId == newContent.Id && l.ChannelId == newChannel.Id);
                                if (newLock == null)
                                {
                                    newLock = new ContentChannelLock
                                    {
                                        Content = newContent,
                                        ContentId = newContent.Id,
                                        Channel = newChannel,
                                        ChannelId = newChannel.Id
                                    };
                                    newContent.ChannelLocks.Add(newLock);
                                    newChannel.ContentLocks.Add(newLock);

                                    newConnection.Execute(@"Insert Into Booking.ContentChannelLocks(Id, ContentId, ChannelId)
                                        Values(@Id, @ContentId, @ChannelId)",
                                        new
                                        {
                                            newLock.Id,
                                            newLock.ContentId,
                                            newLock.ChannelId
                                        });

                                    var timeBandsOfChannel = channelLock.Channel.TimeBands;
                                    if (timeBandsOfChannel.Count > 0)
                                    {
                                        var timeBandNoLocks = oldContentChannelLock_TimeBandNoLocks.Where(l => l.Content == channelLock.Content && timeBandsOfChannel.Contains(l.TimeBand)).ToList();
                                        if (timeBandNoLocks.Count > 0)
                                        {
                                            foreach (var noLock in timeBandNoLocks)
                                            {
                                                var newTimeBand = newTimeBands.FirstOrDefault(t => t.OldId == noLock.TimeBand.Id);
                                                if (newTimeBand != null)
                                                {
                                                    var newNoLock = new ContentChannelLock_TimeBandBaseNoLock
                                                    {
                                                        ChannelLock = newLock,
                                                        ChannelLockId = newLock.Id,
                                                        TimeBandBase = newTimeBand.TimeBandBase,
                                                        TimeBandBaseId = newTimeBand.TimeBandBase.Id
                                                    }; ;
                                                    newLock.ChildrenNoLocks.Add(newNoLock);
                                                    newTimeBand.TimeBandBase.NoLockInChannelLocks.Add(newNoLock);

                                                    newConnection.Execute(@"Insert Into Booking.ContentChannelLock_TimeBandBaseNoLocks(LockId, TimeBandBaseId)
                                                        Values(@LockId, @TimeBandBaseId)",
                                                        new
                                                        {
                                                            LockId = newNoLock.ChannelLockId,
                                                            newNoLock.TimeBandBaseId
                                                        });
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Sponsor type
                if (true)
                {
                    Dictionary<SponsorTypeEnum, string> sponsorTypes = new Dictionary<SponsorTypeEnum, string>();
                    foreach (SponsorTypeEnum sponsorType in Enum.GetValues(typeof(SponsorTypeEnum)))
                    {
                        sponsorTypes.Add(sponsorType, GetDisplayName(sponsorType));
                    }

                    // Delete all sponsor type not in type
                    newConnection.Execute(@"Delete Contract.SponsorTypes Where Id not in(" + string.Join(",", sponsorTypes.Select(t => (int)t.Key)) + ")");

                    // Get all sponsor type in db
                    var dbSponsorTypes = contextNew.Contract_SponsorTypes.ToList();

                    int nb = 0;
                    // Add or update sponsor type
                    foreach (var sponsorType in sponsorTypes)
                    {
                        Console.Write($"\rProcessing {++nb} / {sponsorTypes.Count} sponsor type");

                        var typeOld = dbSponsorTypes.FirstOrDefault(t => t.Id == sponsorType.Key);

                        if (typeOld == null)
                        {
                            typeOld = new SponsorType
                            {
                                Id = sponsorType.Key,
                                Name = sponsorType.Value
                            };
                            dbSponsorTypes.Add(typeOld);

                            newConnection.Execute(@"Insert Into Contract.SponsorTypes(Id, Name)
                                Values(@Id, @Name)",
                                new
                                {
                                    typeOld.Id,
                                    typeOld.Name
                                });
                        }
                        else if (typeOld.Name != sponsorType.Value)
                        {
                            typeOld.Name = sponsorType.Value;
                            newConnection.Execute(@"Update Contract.SponsorTypes Set Name = @Name Where Id = @Id",
                                new
                                {
                                    typeOld.Id,
                                    typeOld.Name
                                });
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                contextNew.Price_RetailTypes.Load();
                var newPriceTypeDetails = contextNew.Price_TypeDetails
                    .Include(d => d.PriceType)
                    .Include(d => d.RateSpotBlock)
                    .Include(d => d.Retail)
                    .ToList();

                #region Price type
                if (true)
                {
                    Dictionary<PriceTypeEnum, string> priceTypes = new Dictionary<PriceTypeEnum, string>();
                    foreach (PriceTypeEnum priceType in Enum.GetValues(typeof(PriceTypeEnum)))
                    {
                        priceTypes.Add(priceType, GetDisplayName(priceType));
                    }

                    // Remove all price type not in price type
                    newConnection.Execute(@"Delete Price.PriceTypes Where Id not in(" + string.Join(",", priceTypes.Select(t => (int)t.Key)) + ")");

                    var dbPriceTypes = contextNew.Price_PriceTypes
                        .Include(t => t.Details)
                        .Include(t => t.BookingTypes)
                        .ToList();

                    // Add or update price type
                    int nb = 0;
                    foreach (var priceType in priceTypes.OrderBy(p => p.Value))
                    {
                        Console.Write($"\rProcessing {++nb} / {priceTypes.Count} price type");

                        var priceTypeOld = dbPriceTypes.FirstOrDefault(t => t.Id == priceType.Key);

                        if (priceTypeOld == null)
                        {
                            priceTypeOld = new PriceType
                            {
                                Id = priceType.Key,
                                Name = priceType.Value,
                                Description = priceType.Value
                            };
                            newConnection.Execute(@"Insert Into Price.PriceTypes(Id, Name, Description)
                                Values(@Id, @Name, @Description)",
                                new
                                {
                                    priceTypeOld.Id,
                                    priceTypeOld.Name,
                                    priceTypeOld.Description
                                });
                            dbPriceTypes.Add(priceTypeOld);

                            if (priceTypeOld.Id == PriceTypeEnum.Free
                                || priceTypeOld.Id == PriceTypeEnum.Ceiling
                                || priceTypeOld.Id == PriceTypeEnum.Special)
                            {
                                var detail = new PriceTypeDetail
                                {
                                    TypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Name = priceTypeOld.Name
                                };
                                priceTypeOld.Details.Add(detail);
                                newPriceTypeDetails.Add(detail);

                                newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                    Values(@Id, @TypeId, @Name)",
                                    new
                                    {
                                        detail.Id,
                                        detail.TypeId,
                                        detail.Name
                                    });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.Rate)
                            {
                                foreach (var block in newBlocks)
                                {
                                    var detail = new RateSpotBlock
                                    {
                                        SpotBlock = block,
                                        SpotBlockId = block.Id
                                    };
                                    detail.BaseType.TypeId = priceTypeOld.Id;
                                    detail.BaseType.PriceType = priceTypeOld;
                                    detail.BaseType.Name = $"By rate of block {block.Duration} seconds";
                                    priceTypeOld.Details.Add(detail.BaseType);
                                    newPriceTypeDetails.Add(detail.BaseType);

                                    newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                        Values(@Id, @TypeId, @Name)

                                        Insert Into Price.RateSpotBlocks(Id, SpotBlockId)
                                        Values(@Id, @SpotBlockId)",
                                        new
                                        {
                                            detail.BaseType.Id,
                                            detail.BaseType.TypeId,
                                            detail.BaseType.Name,
                                            detail.SpotBlockId
                                        });
                                }
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.RateByBlock)
                            {
                                var block10 = newBlocks.First(b => b.Duration == 10);

                                var detail = new RateSpotBlock
                                {
                                    SpotBlock = block10,
                                    SpotBlockId = block10.Id,
                                    Rate = 0.6M
                                };
                                detail.BaseType.TypeId = priceTypeOld.Id;
                                detail.BaseType.PriceType = priceTypeOld;
                                detail.BaseType.Name = $"60% price of block {block10.Duration} seconds";
                                priceTypeOld.Details.Add(detail.BaseType);
                                newPriceTypeDetails.Add(detail.BaseType);

                                newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                        Values(@Id, @TypeId, @Name)

                                        Insert Into Price.RateSpotBlocks(Id, SpotBlockId, Rate)
                                        Values(@Id, @SpotBlockId, @Rate)",
                                    new
                                    {
                                        detail.BaseType.Id,
                                        detail.BaseType.TypeId,
                                        detail.BaseType.Name,
                                        detail.SpotBlockId,
                                        detail.Rate
                                    });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.Retail)
                            {
                                var oldRetailTypies = contextOld.RetailTypies.ToList().Where(t => t.Id == HD.TVADOld.Entities.Entities.RetailTypeEnum.Notify
                                        || t.Id == HD.TVADOld.Entities.Entities.RetailTypeEnum.Simple).ToList();
                                foreach (var oldType in oldRetailTypies)
                                {
                                    var detail = new RetailType
                                    {
                                        Description = oldType.Description,
                                        OldId = (int)oldType.Id
                                    };
                                    detail.BaseType.TypeId = priceTypeOld.Id;
                                    detail.BaseType.PriceType = priceTypeOld;
                                    detail.BaseType.Name = oldType.Id.ToString();
                                    priceTypeOld.Details.Add(detail.BaseType);
                                    newPriceTypeDetails.Add(detail.BaseType);
                                    newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                            Values(@Id, @TypeId, @Name)

                                            Insert Into Price.RetailTypes(Id, Description, OldId)
                                            Values(@Id, @Description, @OldId)",
                                        new
                                        {
                                            detail.Id,
                                            detail.BaseType.TypeId,
                                            detail.BaseType.Name,
                                            detail.Description,
                                            detail.OldId
                                        });
                                }
                            }

                            // Booking apply

                            if (priceTypeOld.Id == PriceTypeEnum.Free)
                            {
                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Contract,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 10
                                });

                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Retail,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 0
                                });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.Ceiling)
                            {
                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Contract,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 0
                                });

                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Retail,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 2
                                });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.Rate)
                            {
                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Contract,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 1
                                });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.RateByBlock)
                            {
                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Contract,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 2
                                });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.Retail)
                            {
                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Retail,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 1
                                });
                            }

                            if (priceTypeOld.Id == PriceTypeEnum.Special)
                            {
                                priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                {
                                    BookingTypeId = BookingTypeEnum.Retail,
                                    PriceTypeId = priceTypeOld.Id,
                                    PriceType = priceTypeOld,
                                    Index = 3
                                });
                            }

                            foreach (var apply in priceTypeOld.BookingTypes)
                            {
                                newConnection.Execute(@"Insert Into Booking.BookingType_PriceTypes(BookingTypeId, PriceTypeId, [Index])
                                        Values(@BookingTypeId, @PriceTypeId, @Index)",
                                    new
                                    {
                                        apply.BookingTypeId,
                                        apply.PriceTypeId,
                                        apply.Index
                                    });
                            }
                        }
                        else
                        {
                            if (priceTypeOld.Name != priceType.Value)
                            {
                                priceTypeOld.Name = priceType.Value;

                                newConnection.Execute(@"Update Price.PriceTypes Set Name = @Name
                                        , Description = @Description
                                    Where Id = @Id",
                                    new
                                    {
                                        priceTypeOld.Id,
                                        priceTypeOld.Name
                                    });
                            }

                            if (priceTypeOld.Details.Count == 0)
                            {
                                if (priceTypeOld.Id == PriceTypeEnum.Free
                                    || priceTypeOld.Id == PriceTypeEnum.Ceiling
                                    || priceTypeOld.Id == PriceTypeEnum.Special)
                                {
                                    var detail = new PriceTypeDetail
                                    {
                                        TypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Name = priceTypeOld.Name
                                    };
                                    priceTypeOld.Details.Add(detail);
                                    newPriceTypeDetails.Add(detail);

                                    newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                        Values(@Id, @TypeId, @Name)",
                                        new
                                        {
                                            detail.Id,
                                            detail.TypeId,
                                            detail.Name
                                        });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.Rate)
                                {
                                    foreach (var block in newBlocks)
                                    {
                                        var detail = new RateSpotBlock
                                        {
                                            SpotBlock = block,
                                            SpotBlockId = block.Id
                                        };
                                        detail.BaseType.TypeId = priceTypeOld.Id;
                                        detail.BaseType.PriceType = priceTypeOld;
                                        detail.BaseType.Name = $"By rate of block {block.Duration} seconds";
                                        priceTypeOld.Details.Add(detail.BaseType);
                                        newPriceTypeDetails.Add(detail.BaseType);

                                        newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                        Values(@Id, @TypeId, @Name)

                                        Insert Into Price.RateSpotBlocks(Id, SpotBlockId)
                                        Values(@Id, @SpotBlockId)",
                                            new
                                            {
                                                detail.BaseType.Id,
                                                detail.BaseType.TypeId,
                                                detail.BaseType.Name,
                                                detail.SpotBlockId
                                            });
                                    }
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.RateByBlock)
                                {
                                    var block10 = newBlocks.First(b => b.Duration == 10);

                                    var detail = new RateSpotBlock
                                    {
                                        SpotBlock = block10,
                                        SpotBlockId = block10.Id,
                                        Rate = 0.6M
                                    };
                                    detail.BaseType.TypeId = priceTypeOld.Id;
                                    detail.BaseType.PriceType = priceTypeOld;
                                    detail.BaseType.Name = $"60% price of block {block10.Duration} seconds";
                                    priceTypeOld.Details.Add(detail.BaseType);
                                    newPriceTypeDetails.Add(detail.BaseType);

                                    newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                        Values(@Id, @TypeId, @Name)

                                        Insert Into Price.RateSpotBlocks(Id, SpotBlockId)
                                        Values(@Id, @SpotBlockId)",
                                        new
                                        {
                                            detail.BaseType.Id,
                                            detail.BaseType.TypeId,
                                            detail.BaseType.Name,
                                            detail.SpotBlockId
                                        });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.Retail)
                                {
                                    var oldRetailTypies = contextOld.RetailTypies.ToList().Where(t => t.Id == HD.TVADOld.Entities.Entities.RetailTypeEnum.Notify
                                        || t.Id == HD.TVADOld.Entities.Entities.RetailTypeEnum.Simple).ToList();
                                    foreach (var oldType in oldRetailTypies)
                                    {
                                        var detail = new RetailType
                                        {
                                            Description = oldType.Description,
                                            OldId = (int)oldType.Id
                                        };
                                        detail.BaseType.TypeId = priceTypeOld.Id;
                                        detail.BaseType.PriceType = priceTypeOld;
                                        detail.BaseType.Name = oldType.Id.ToString();
                                        priceTypeOld.Details.Add(detail.BaseType);
                                        newPriceTypeDetails.Add(detail.BaseType);
                                        newConnection.Execute(@"Insert Into Price.TypeDetails(Id, TypeId, Name)
                                            Values(@Id, @TypeId, @Name)

                                            Insert Into Price.RetailTypes(Id, Description, OldId)
                                            Values(@Id, @Description, @OldId)",
                                            new
                                            {
                                                detail.Id,
                                                detail.BaseType.TypeId,
                                                detail.BaseType.Name,
                                                detail.Description,
                                                detail.OldId
                                            });
                                    }
                                }
                            }

                            if (priceTypeOld.BookingTypes.Count == 0)
                            {
                                if (priceTypeOld.Id == PriceTypeEnum.Free)
                                {
                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Contract,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 10
                                    });

                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Retail,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 0
                                    });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.Ceiling)
                                {
                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Contract,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 0
                                    });

                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Retail,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 2
                                    });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.Rate)
                                {
                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Contract,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 1
                                    });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.RateByBlock)
                                {
                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Contract,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 2
                                    });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.Retail)
                                {
                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Retail,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 1
                                    });
                                }

                                if (priceTypeOld.Id == PriceTypeEnum.Special)
                                {
                                    priceTypeOld.BookingTypes.Add(new BookingType_PriceType
                                    {
                                        BookingTypeId = BookingTypeEnum.Retail,
                                        PriceTypeId = priceTypeOld.Id,
                                        PriceType = priceTypeOld,
                                        Index = 3
                                    });
                                }

                                foreach (var apply in priceTypeOld.BookingTypes)
                                {
                                    newConnection.Execute(@"Insert Into Booking.BookingType_PriceTypes(BookingTypeId, PriceTypeId, [Index])
                                        Values(@BookingTypeId, @PriceTypeId, @Index)",
                                        new
                                        {
                                            apply.BookingTypeId,
                                            apply.PriceTypeId,
                                            apply.Index
                                        });
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Retail price
                if (true)
                {
                    var oldPrices = contextOld.RetailPrices
                        .Include(p => p.RetailType)
                        .ToList();

                    var newPrices = contextNew.Price_RetailPrices
                        .Include(p => p.RetailType)
                        .ToList();
                    int nb = 0;
                    foreach (var priceOld in oldPrices)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldPrices.Count} retail prices");

                        var newPrice = newPrices.FirstOrDefault(p => p.RetailType.OldId == (int)priceOld.RetailType.Id && p.StartDate == priceOld.StartDate.Date);
                        if (newPrice == null)
                        {
                            newPrice = new RetailPrice
                            {
                                RetailType = newPriceTypeDetails.First(p => p.Retail != null && p.Retail.OldId == (int)priceOld.RetailType.Id).Retail,
                                StartDate = priceOld.StartDate.Date,
                                Price = priceOld.Price
                            };
                            newPrice.RetailTypeId = newPrice.RetailType.Id;
                            newPrice.RetailType.Prices.Add(newPrice);
                            newPrices.Add(newPrice);

                            newConnection.Execute(@"Insert Into Price.RetailPrices(Id, RetailTypeId, StartDate, Price)
                                Values(@Id, @RetailTypeId, @StartDate, @Price)",
                                new
                                {
                                    newPrice.Id,
                                    newPrice.RetailTypeId,
                                    newPrice.StartDate,
                                    newPrice.Price
                                });
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                contextNew.Schedule_Spots.Load();
                contextNew.Booking_AnnexContractContents
                    .Include(a => a.Bookings)
                    .Load();
                contextNew.Price_DiscountAnnexContracts
                    .Include(d => d.TimeBandBases)
                    .Load();
                contextNew.Price_AnnexContractPrice_TimeBands.Load();
                contextNew.Booking_AnnexContractPartners
                    .Include(a => a.AnnexContractBase)
                    .Include(a => a.PriceAtSignDates)
                    .Include(a => a.Prices)
                    .Load();
                contextNew.Booking_AnnexContractRetails
                    .Include(a => a.AnnexContractBase)
                    .Load();
                var newSpots = contextNew.Schedule_Spots.Local.ToList();
                var newAnnexContractPartners = contextNew.Booking_AnnexContractPartners.Local.ToList();
                var newAnnexContractRetails = contextNew.Booking_AnnexContractRetails.Local.ToList();

                foreach (var spot in newSpots)
                {
                    if (spot.TimeBandSlice == null)
                    {
                        spot.TimeBandSlice = newTimeBands.First(t => t.Slices.Any(s => s.Id == spot.TimeBandSliceId)).Slices.First(s => s.Id == spot.TimeBandSliceId);
                        if (!spot.TimeBandSlice.Spots.Contains(spot))
                            spot.TimeBandSlice.Spots.Add(spot);
                    }
                }

                foreach (var annex in newAnnexContractPartners)
                {
                    if (annex.AnnexContractBase.Customer == null)
                        annex.AnnexContractBase.Customer = newPartnerCustomers.First(c => c.Id == annex.AnnexContractBase.CustomerId).BaseCustomer;
                    if (annex.SponsorProgramId != null && annex.SponsorProgram == null)
                        annex.SponsorProgram = newSponsorPrograms.First(p => p.Id == annex.SponsorProgramId);
                    foreach (var content in annex.AnnexContractBase.Contents)
                    {
                        if (content.Content == null)
                            content.Content = newContents.First(c => c.Id == content.ContentId);
                    }
                    foreach (var price in annex.Prices)
                    {
                        foreach (var blockPrice in price.Prices)
                        {
                            if (blockPrice.TimeBandId != null && blockPrice.TimeBand == null)
                            {
                                blockPrice.TimeBand = newTimeBands.First(t => t.Id == blockPrice.TimeBandId);
                                blockPrice.TimeBand.AnnexContractPrices.Add(blockPrice);
                            }
                        }
                    }
                }

                #region Annex contract partner
                if (false)
                {
                    contextOld.Spots.Load();
                    contextOld.AnnexContractPartnerSpotBookings.Load();
                    contextOld.Contents.Load();
                    contextOld.TimeBands.Load();
                    contextOld.AnnexContractPartnerPrice_TimeBands.Load();
                    contextOld.AnnexContractPartnerPrice_Blocks.Load();
                    contextOld.AnnexContractPartners
                        .Where(a => a.Code != null && a.CustomerId != null)
                        .Include(a => a.Customer)
                        .Include(a => a.SponsorProgram)
                        .Include(a => a.Contents)
                        .Include(a => a.Discounts)
                        .Include(a => a.DiscountByTimeBands)
                        .Include(a => a.PriceAtSignDates)
                        .Include(a => a.Prices)
                        .Load();
                    var oldAnnexContractPartners = contextOld.AnnexContractPartners.Local.ToList();

                    int nb = 0;
                    foreach (var oldAnnexContractPartner in oldAnnexContractPartners)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldAnnexContractPartners.Count} annex contract partner");

                        if (oldAnnexContractPartner.ReceiveDate == null)
                            oldAnnexContractPartner.ReceiveDate = new DateTime(2017, 1, 1);
                        if (oldAnnexContractPartner.SignDate == null)
                            oldAnnexContractPartner.SignDate = oldAnnexContractPartner.ReceiveDate;
                        if (oldAnnexContractPartner.Type == null || oldAnnexContractPartner.Type == HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.None)
                            oldAnnexContractPartner.Type = oldAnnexContractPartner.SponsorProgram == null ? HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Booking : HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Sponsor;
                        if (oldAnnexContractPartner.Type == HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Sponsor
                            && oldAnnexContractPartner.SponsorProgram == null)
                            oldAnnexContractPartner.Type = HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Booking;
                        if (oldAnnexContractPartner.Type == HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Sponsor)
                        {
                            if (oldAnnexContractPartner.SponsorType == null || oldAnnexContractPartner.SponsorType == HD.TVADOld.Entities.Entities.SponsorTypeEnum.None)
                                oldAnnexContractPartner.SponsorType = HD.TVADOld.Entities.Entities.SponsorTypeEnum.Copyright;
                            if (oldAnnexContractPartner.BookInSponsor == null)
                                oldAnnexContractPartner.BookInSponsor = true;
                        }

                        var newCustomer = newPartnerCustomers.FirstOrDefault(p => p.OldId == oldAnnexContractPartner.CustomerId);
                        if (newCustomer != null)
                        {
                            SponsorProgram newSponsorProgram = null;
                            SponsorTypeEnum? newSponsorTypeId = null;
                            if (oldAnnexContractPartner.Type == HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Sponsor)
                            {
                                newSponsorProgram = newSponsorPrograms.FirstOrDefault(p => p.OldId == oldAnnexContractPartner.SponsorProgramId);
                                if (newSponsorProgram == null)
                                    continue;

                                newSponsorTypeId = oldAnnexContractPartner.SponsorType == HD.TVADOld.Entities.Entities.SponsorTypeEnum.Copyright ? SponsorTypeEnum.Copyright : SponsorTypeEnum.Production;
                            }

                            BookingTypeEnum newBookingTypeId = oldAnnexContractPartner.Type == HD.TVADOld.Entities.Entities.AnnextContractPartnerTypeEnum.Booking ? BookingTypeEnum.Contract_Booking
                                : oldAnnexContractPartner.BookInSponsor.Value ? BookingTypeEnum.Contract_Sponsor_InProgram
                                : BookingTypeEnum.Contract_Sponsor_OutProgram;

                            var newAnnexContractPartner = newAnnexContractPartners.FirstOrDefault(a => a.OldId == oldAnnexContractPartner.Id);
                            if (newAnnexContractPartner == null)
                            {
                                newAnnexContractPartner = new AnnexContractPartner
                                {
                                    SignDate = oldAnnexContractPartner.SignDate.Value,
                                    ScheduleCampaign = oldAnnexContractPartner.ScheduleCampaign,
                                    Content = oldAnnexContractPartner.Content,

                                    SponsorProgram = newSponsorProgram,
                                    SponsorProgramId = newSponsorProgram == null ? null : (Guid?)newSponsorProgram.Id,

                                    SponsorTypeId = newSponsorTypeId,
                                    OldId = oldAnnexContractPartner.Id
                                };

                                newAnnexContractPartners.Add(newAnnexContractPartner);
                                if (newSponsorProgram != null)
                                    newSponsorProgram.AnnexContractPartners.Add(newAnnexContractPartner);

                                newAnnexContractPartner.AnnexContractBase.Customer = newCustomer.BaseCustomer;
                                newAnnexContractPartner.AnnexContractBase.CustomerId = newCustomer.Id;

                                newAnnexContractPartner.AnnexContractBase.Code = oldAnnexContractPartner.Code;
                                newAnnexContractPartner.AnnexContractBase.BookingTypeId = newBookingTypeId;
                                newAnnexContractPartner.AnnexContractBase.ReceiveDate = oldAnnexContractPartner.ReceiveDate.Value;

                                newCustomer.BaseCustomer.AnnexContracts.Add(newAnnexContractPartner.AnnexContractBase);

                                newConnection.Execute(@"Insert Into Booking.AnnexContracts(Id, CustomerId, Code, BookingTypeId, ReceiveDate)
                                    Values(@Id, @CustomerId, @Code, @BookingTypeId, @ReceiveDate)

                                    Insert Into Booking.AnnexContractPartners(Id, SignDate, ScheduleCampaign, Content, SponsorProgramId, SponsorTypeId, OldId)
                                    Values(@Id, @SignDate, @ScheduleCampaign, @Content, @SponsorProgramId, @SponsorTypeId, @OldId)",
                                    new
                                    {
                                        newAnnexContractPartner.AnnexContractBase.Id,
                                        newAnnexContractPartner.AnnexContractBase.CustomerId,
                                        newAnnexContractPartner.AnnexContractBase.Code,
                                        newAnnexContractPartner.AnnexContractBase.BookingTypeId,
                                        newAnnexContractPartner.AnnexContractBase.ReceiveDate,
                                        newAnnexContractPartner.SignDate,
                                        newAnnexContractPartner.ScheduleCampaign,
                                        newAnnexContractPartner.Content,
                                        newAnnexContractPartner.SponsorProgramId,
                                        newAnnexContractPartner.SponsorTypeId,
                                        newAnnexContractPartner.OldId
                                    });

                                // Content
                                foreach (var oldAnnexContent in oldAnnexContractPartner.Contents)
                                {
                                    if (oldAnnexContent.PriceTypeId == null)
                                        oldAnnexContent.PriceTypeId = 0;

                                    var newContent = newContents.Find(c => c.OldId == oldAnnexContent.Content.Id);
                                    PriceTypeDetail priceDetail = null;
                                    if (oldAnnexContent.PriceTypeId == -1) // Cận trên
                                        priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Ceiling);
                                    else if (oldAnnexContent.PriceTypeId == -2) // 60% của 10s
                                    {
                                        priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.RateByBlock
                                            && t.RateSpotBlock != null && t.RateSpotBlock.Rate == 0.6M && t.RateSpotBlock.SpotBlock.Duration == 10);
                                    }
                                    else if (oldAnnexContent.PriceTypeId > 0) // Tỉ lệ 1 block
                                    {
                                        priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Rate
                                            && t.RateSpotBlock != null && t.RateSpotBlock.SpotBlock.Duration == oldAnnexContent.PriceTypeId);
                                    }
                                    if (priceDetail == null) // Miễn phí
                                        priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Free);

                                    var newAnnexContent = new AnnexContractContent
                                    {
                                        AnnexContract = newAnnexContractPartner.AnnexContractBase,
                                        AnnexContractId = newAnnexContractPartner.AnnexContractBase.Id,

                                        Content = newContent,
                                        ContentId = newContent.Id,

                                        PriceTypeDetail = priceDetail,
                                        PriceTypeDetailId = priceDetail.Id,

                                        Contents = oldAnnexContent.Contents
                                    };
                                    newAnnexContractPartner.AnnexContractBase.Contents.Add(newAnnexContent);
                                    newContent.AnnexContracts.Add(newAnnexContent);
                                    priceDetail.AnnexContractContents.Add(newAnnexContent);

                                    newConnection.Execute(@"Insert Into Booking.AnnexContractAssets(Id, AnnexContractId, ContentId, PriceTypeDetailId, Contents)
                                        Values(@Id, @AnnexContractId, @ContentId, @PriceTypeDetailId, @Contents)",
                                        new
                                        {
                                            newAnnexContent.Id,
                                            newAnnexContent.AnnexContractId,
                                            newAnnexContent.ContentId,
                                            newAnnexContent.PriceTypeDetailId,
                                            newAnnexContent.Contents
                                        });

                                    int index = 0;
                                    foreach (var booking in oldAnnexContent.Bookings.OrderBy(b => b.Index))
                                    {
                                        booking.Index = index++;
                                    }

                                    // Booking
                                    foreach (var oldBooking in oldAnnexContent.Bookings)
                                    {
                                        var newSlice = newTimeBands.First(t => t.OldId == oldBooking.Spot.TimeBandSlice.TimeBand.Id)
                                            .Slices.First(s => s.Name == oldBooking.Spot.TimeBandSlice.SliceId.ToString());

                                        var newSpot = newSlice.Spots.FirstOrDefault(s => s.BroadcastDate == oldBooking.Spot.BroadcastDate.Date);
                                        if (newSpot == null)
                                        {
                                            newSpot = new HD.TVAD.Entities.Entities.Schedule.Spot
                                            {
                                                BroadcastDate = oldBooking.Spot.BroadcastDate.Date,
                                                TimeBandSlice = newSlice,
                                                TimeBandSliceId = newSlice.Id,
                                                Description = oldBooking.Spot.Description
                                            };
                                            newSlice.Spots.Add(newSpot);
                                            newSpots.Add(newSpot);

                                            newConnection.Execute(@"Insert Into Schedule.Spots(Id, BroadcastDate, TimeBandSliceId, Description)
                                                Values(@Id, @BroadcastDate, @TimeBandSliceId, @Description)",
                                                new
                                                {
                                                    newSpot.Id,
                                                    newSpot.BroadcastDate,
                                                    newSpot.TimeBandSliceId,
                                                    newSpot.Description
                                                });
                                        }

                                        SpotBooking newBooking = null;
                                        if (oldBooking.Approve == true)
                                        {
                                            var spotContentByBooking = new SpotContentByBooking();
                                            newBooking = spotContentByBooking.Booking;

                                            newBooking.AnnexContractContent = newAnnexContent;
                                            newBooking.AnnexContractContentId = newAnnexContent.Id;

                                            newBooking.Spot = newSpot;
                                            newBooking.SpotId = newSpot.Id;

                                            newBooking.Position = (int)oldBooking.Index;
                                            newBooking.PositionCost = oldBooking.PositionCost;
                                            newBooking.CardRateSet = oldBooking.CardRateSet;
                                            newBooking.PositionRateSet = oldBooking.PositionRateSet;
                                            newBooking.DiscountRateSet = oldBooking.DiscountRateSet;
                                            newBooking.OriginalPriceDate = oldBooking.OriginalPriceDate == null ? null : (DateTime?)oldBooking.OriginalPriceDate.Value.Date;
                                            newBooking.OriginalPriceRate = oldBooking.OriginalPriceRate == null ? null : (decimal?)oldBooking.OriginalPriceRate.Value / 100.0M;
                                            newBooking.OriginalPriceType = (OriginalPriceTypeEnum?)oldBooking.OriginalPriceType;

                                            spotContentByBooking.BaseSpotContent.Spot = newSpot;
                                            spotContentByBooking.BaseSpotContent.SpotId = newSpot.Id;
                                            spotContentByBooking.BaseSpotContent.Index = (int)oldBooking.Index;

                                            newConnection.Execute(@"Insert Into Booking.SpotBookings(Id, AnnexContractAssetId, SpotId
                                                    , Position, PositionCost, CardRateSet, PositionRateSet, DiscountRateSet
                                                    , OriginalPriceDate, OriginalPriceRate, OriginalPriceType)
                                                Values(@Id, @AnnexContractContentId, @SpotId
                                                    , @Position, @PositionCost, @CardRateSet, @PositionRateSet, @DiscountRateSet
                                                    , @OriginalPriceDate, @OriginalPriceRate, @OriginalPriceType)

                                                Insert Into Schedule.SpotAssets(Id, SpotId, [Index]) Values(@Id, @SpotId, @Position)

                                                Insert Into Schedule.SpotAssetByBookings(Id) Values(@Id)",
                                                new
                                                {
                                                    newBooking.Id,
                                                    newBooking.AnnexContractContentId,
                                                    newBooking.SpotId,
                                                    newBooking.Position,
                                                    newBooking.PositionCost,
                                                    newBooking.CardRateSet,
                                                    newBooking.PositionRateSet,
                                                    newBooking.DiscountRateSet,
                                                    newBooking.OriginalPriceDate,
                                                    newBooking.OriginalPriceRate,
                                                    newBooking.OriginalPriceType
                                                });
                                        }
                                        else
                                        {
                                            newBooking = new SpotBooking
                                            {
                                                AnnexContractContent = newAnnexContent,
                                                AnnexContractContentId = newAnnexContent.Id,

                                                Spot = newSpot,
                                                SpotId = newSpot.Id,

                                                Position = (int)oldBooking.Index,
                                                PositionCost = oldBooking.PositionCost,
                                                CardRateSet = oldBooking.CardRateSet,
                                                PositionRateSet = oldBooking.PositionRateSet,
                                                DiscountRateSet = oldBooking.DiscountRateSet,
                                                OriginalPriceDate = oldBooking.OriginalPriceDate == null ? null : (DateTime?)oldBooking.OriginalPriceDate.Value.Date,
                                                OriginalPriceRate = oldBooking.OriginalPriceRate == null ? null : (decimal?)oldBooking.OriginalPriceRate.Value / 100.0M,
                                                OriginalPriceType = (OriginalPriceTypeEnum?)oldBooking.OriginalPriceType
                                            };

                                            newConnection.Execute(@"Insert Into Booking.SpotBookings(Id, AnnexContractAssetId, SpotId
                                                    , Position, PositionCost, CardRateSet, PositionRateSet, DiscountRateSet
                                                    , OriginalPriceDate, OriginalPriceRate, OriginalPriceType)
                                                Values(@Id, @AnnexContractContentId, @SpotId
                                                    , @Position, @PositionCost, @CardRateSet, @PositionRateSet, @DiscountRateSet
                                                    , @OriginalPriceDate, @OriginalPriceRate, @OriginalPriceType)",
                                                    new
                                                    {
                                                        newBooking.Id,
                                                        newBooking.AnnexContractContentId,
                                                        newBooking.SpotId,
                                                        newBooking.Position,
                                                        newBooking.PositionCost,
                                                        newBooking.CardRateSet,
                                                        newBooking.PositionRateSet,
                                                        newBooking.DiscountRateSet,
                                                        newBooking.OriginalPriceDate,
                                                        newBooking.OriginalPriceRate,
                                                        newBooking.OriginalPriceType
                                                    });
                                        }

                                        newAnnexContent.Bookings.Add(newBooking);
                                        newSpot.Bookings.Add(newBooking);
                                    }
                                }
                            }
                            else
                            {
                                bool changed = false;
                                if (newAnnexContractPartner.SignDate != oldAnnexContractPartner.SignDate)
                                {
                                    newAnnexContractPartner.SignDate = oldAnnexContractPartner.SignDate.Value;
                                    changed = true;
                                }

                                if (newAnnexContractPartner.ScheduleCampaign != oldAnnexContractPartner.ScheduleCampaign)
                                {
                                    newAnnexContractPartner.ScheduleCampaign = oldAnnexContractPartner.ScheduleCampaign;
                                    changed = true;
                                }

                                if (newAnnexContractPartner.Content != oldAnnexContractPartner.Content)
                                {
                                    newAnnexContractPartner.Content = oldAnnexContractPartner.Content;
                                    changed = true;
                                }

                                if (newAnnexContractPartner.SponsorProgramId != (newSponsorProgram == null ? null : (Guid?)newSponsorProgram.Id))
                                {
                                    newAnnexContractPartner.SponsorProgramId = newSponsorProgram == null ? null : (Guid?)newSponsorProgram.Id;
                                    newAnnexContractPartner.SponsorProgram = newSponsorProgram;
                                    changed = true;
                                }

                                if (newAnnexContractPartner.SponsorTypeId != newSponsorTypeId)
                                {
                                    newAnnexContractPartner.SponsorTypeId = newSponsorTypeId;
                                    changed = true;
                                }

                                if (changed)
                                {
                                    newConnection.Execute(@"Update Booking.AnnexContractPartners Set SignDate = @SignDate
                                            , ScheduleCampaign = @ScheduleCampaign
                                            , Content = @Content
                                            , SponsorProgramId = @SponsorProgramId
                                            , SponsorTypeId = @SponsorTypeId
                                        Where Id = @Id",
                                    new
                                    {
                                        newAnnexContractPartner.Id,
                                        newAnnexContractPartner.SignDate,
                                        newAnnexContractPartner.ScheduleCampaign,
                                        newAnnexContractPartner.Content,
                                        newAnnexContractPartner.SponsorProgramId,
                                        newAnnexContractPartner.SponsorTypeId,
                                        newAnnexContractPartner.OldId
                                    });
                                }

                                bool changedBase = false;
                                if (newAnnexContractPartner.AnnexContractBase.CustomerId != newCustomer.Id)
                                {
                                    newAnnexContractPartner.AnnexContractBase.Customer = newCustomer.BaseCustomer;
                                    newAnnexContractPartner.AnnexContractBase.CustomerId = newCustomer.Id;
                                    changedBase = true;
                                }

                                if (newAnnexContractPartner.AnnexContractBase.Code != oldAnnexContractPartner.Code)
                                {
                                    newAnnexContractPartner.AnnexContractBase.Code = oldAnnexContractPartner.Code;
                                    changedBase = true;
                                }

                                if (newAnnexContractPartner.AnnexContractBase.BookingTypeId != newBookingTypeId)
                                {
                                    newAnnexContractPartner.AnnexContractBase.BookingTypeId = newBookingTypeId;
                                    changedBase = true;
                                }

                                if (newAnnexContractPartner.AnnexContractBase.ReceiveDate != oldAnnexContractPartner.ReceiveDate)
                                {
                                    newAnnexContractPartner.AnnexContractBase.ReceiveDate = oldAnnexContractPartner.ReceiveDate.Value;
                                    changedBase = true;
                                }

                                if (changedBase)
                                {
                                    newConnection.Execute(@"Update Booking.AnnexContracts Set CustomerId = @CustomerId
                                            , Code = @Code
                                            , BookingTypeId = @BookingTypeId
                                            , ReceiveDate = @ReceiveDate
                                        Where Id = @Id",
                                        new
                                        {
                                            newAnnexContractPartner.AnnexContractBase.Id,
                                            newAnnexContractPartner.AnnexContractBase.CustomerId,
                                            newAnnexContractPartner.AnnexContractBase.Code,
                                            newAnnexContractPartner.AnnexContractBase.BookingTypeId,
                                            newAnnexContractPartner.AnnexContractBase.ReceiveDate
                                        });
                                }

                                // Content
                                foreach (var oldAnnexContent in oldAnnexContractPartner.Contents)
                                {
                                    var newAnnexContent = newAnnexContractPartner.AnnexContractBase.Contents
                                        .FirstOrDefault(a => a.Content.OldId == oldAnnexContent.Content.Id);
                                    if (newAnnexContent == null)
                                    {
                                        if (oldAnnexContent.PriceTypeId == null)
                                            oldAnnexContent.PriceTypeId = 0;

                                        var newContent = newContents.Find(c => c.OldId == oldAnnexContent.Content.Id);
                                        PriceTypeDetail priceDetail = null;
                                        if (oldAnnexContent.PriceTypeId == -1) // Cận trên
                                            priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Ceiling);
                                        else if (oldAnnexContent.PriceTypeId == -2) // 60% của 10s
                                        {
                                            priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.RateByBlock
                                                && t.RateSpotBlock != null && t.RateSpotBlock.Rate == 0.6M && t.RateSpotBlock.SpotBlock.Duration == 10);
                                        }
                                        else if (oldAnnexContent.PriceTypeId > 0) // Tỉ lệ 1 block
                                        {
                                            priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Rate
                                                && t.RateSpotBlock != null && t.RateSpotBlock.SpotBlock.Duration == oldAnnexContent.PriceTypeId);
                                        }
                                        if (priceDetail == null) // Miễn phí
                                            priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Free);

                                        newAnnexContent = new AnnexContractContent
                                        {
                                            AnnexContract = newAnnexContractPartner.AnnexContractBase,
                                            AnnexContractId = newAnnexContractPartner.AnnexContractBase.Id,

                                            Content = newContent,
                                            ContentId = newContent.Id,

                                            PriceTypeDetail = priceDetail,
                                            PriceTypeDetailId = priceDetail.Id,

                                            Contents = oldAnnexContent.Contents
                                        };
                                        newAnnexContractPartner.AnnexContractBase.Contents.Add(newAnnexContent);
                                        newContent.AnnexContracts.Add(newAnnexContent);
                                        priceDetail.AnnexContractContents.Add(newAnnexContent);

                                        newConnection.Execute(@"Insert Into Booking.AnnexContractAssets(Id, AnnexContractId, ContentId, PriceTypeDetailId, Contents)
                                            Values(@Id, @AnnexContractId, @ContentId, @PriceTypeDetailId, @Contents)",
                                            new
                                            {
                                                newAnnexContent.Id,
                                                newAnnexContent.AnnexContractId,
                                                newAnnexContent.ContentId,
                                                newAnnexContent.PriceTypeDetailId,
                                                newAnnexContent.Contents
                                            });
                                    }

                                    if (newAnnexContent.Bookings.Count == 0)
                                    {
                                        // Booking
                                        foreach (var oldBooking in oldAnnexContent.Bookings)
                                        {
                                            var newSlice = newTimeBands.First(t => t.OldId == oldBooking.Spot.TimeBandSlice.TimeBand.Id)
                                                .Slices.First(s => s.Name == oldBooking.Spot.TimeBandSlice.SliceId.ToString());

                                            var newSpot = newSlice.Spots.FirstOrDefault(s => s.BroadcastDate == oldBooking.Spot.BroadcastDate.Date);
                                            if (newSpot == null)
                                            {
                                                newSpot = new HD.TVAD.Entities.Entities.Schedule.Spot
                                                {
                                                    BroadcastDate = oldBooking.Spot.BroadcastDate.Date,
                                                    TimeBandSlice = newSlice,
                                                    TimeBandSliceId = newSlice.Id,
                                                    Description = oldBooking.Spot.Description
                                                };
                                                newSlice.Spots.Add(newSpot);
                                                newSpots.Add(newSpot);

                                                newConnection.Execute(@"Insert Into Schedule.Spots(Id, BroadcastDate, TimeBandSliceId, Description)
                                                    Values(@Id, @BroadcastDate, @TimeBandSliceId, @Description)",
                                                    new
                                                    {
                                                        newSpot.Id,
                                                        newSpot.BroadcastDate,
                                                        newSpot.TimeBandSliceId,
                                                        newSpot.Description
                                                    });
                                            }

                                            SpotBooking newBooking = null;
                                            if (oldBooking.Approve == true)
                                            {
                                                var spotContentByBooking = new SpotContentByBooking();
                                                newBooking = spotContentByBooking.Booking;

                                                newBooking.AnnexContractContent = newAnnexContent;
                                                newBooking.AnnexContractContentId = newAnnexContent.Id;

                                                newBooking.Spot = newSpot;
                                                newBooking.SpotId = newSpot.Id;

                                                newBooking.Position = (int)oldBooking.Index;
                                                newBooking.PositionCost = oldBooking.PositionCost;
                                                newBooking.CardRateSet = oldBooking.CardRateSet;
                                                newBooking.PositionRateSet = oldBooking.PositionRateSet;
                                                newBooking.DiscountRateSet = oldBooking.DiscountRateSet;
                                                newBooking.OriginalPriceDate = oldBooking.OriginalPriceDate == null ? null : (DateTime?)oldBooking.OriginalPriceDate.Value.Date;
                                                newBooking.OriginalPriceRate = oldBooking.OriginalPriceRate == null ? null : (decimal?)oldBooking.OriginalPriceRate.Value / 100.0M;
                                                newBooking.OriginalPriceType = (OriginalPriceTypeEnum?)oldBooking.OriginalPriceType;

                                                spotContentByBooking.BaseSpotContent.Spot = newSpot;
                                                spotContentByBooking.BaseSpotContent.SpotId = newSpot.Id;
                                                spotContentByBooking.BaseSpotContent.Index = (int)oldBooking.Index;

                                                newConnection.Execute(@"Insert Into Booking.SpotBookings(Id, AnnexContractAssetId, SpotId
                                                        , Position, PositionCost, CardRateSet, PositionRateSet, DiscountRateSet
                                                        , OriginalPriceDate, OriginalPriceRate, OriginalPriceType)
                                                    Values(@Id, @AnnexContractContentId, @SpotId
                                                        , @Position, @PositionCost, @CardRateSet, @PositionRateSet, @DiscountRateSet
                                                        , @OriginalPriceDate, @OriginalPriceRate, @OriginalPriceType)

                                                    Insert Into Schedule.SpotAssets(Id, SpotId, [Index]) Values(@Id, @SpotId, @Position)

                                                    Insert Into Schedule.SpotAssetByBookings(Id) Values(@Id)",
                                                    new
                                                    {
                                                        newBooking.Id,
                                                        newBooking.AnnexContractContentId,
                                                        newBooking.SpotId,
                                                        newBooking.Position,
                                                        newBooking.PositionCost,
                                                        newBooking.CardRateSet,
                                                        newBooking.PositionRateSet,
                                                        newBooking.DiscountRateSet,
                                                        newBooking.OriginalPriceDate,
                                                        newBooking.OriginalPriceRate,
                                                        newBooking.OriginalPriceType
                                                    });
                                            }
                                            else
                                            {
                                                newBooking = new SpotBooking
                                                {
                                                    AnnexContractContent = newAnnexContent,
                                                    AnnexContractContentId = newAnnexContent.Id,

                                                    Spot = newSpot,
                                                    SpotId = newSpot.Id,

                                                    Position = (int)oldBooking.Index,
                                                    PositionCost = oldBooking.PositionCost,
                                                    CardRateSet = oldBooking.CardRateSet,
                                                    PositionRateSet = oldBooking.PositionRateSet,
                                                    DiscountRateSet = oldBooking.DiscountRateSet,
                                                    OriginalPriceDate = oldBooking.OriginalPriceDate == null ? null : (DateTime?)oldBooking.OriginalPriceDate.Value.Date,
                                                    OriginalPriceRate = oldBooking.OriginalPriceRate == null ? null : (decimal?)oldBooking.OriginalPriceRate.Value / 100.0M,
                                                    OriginalPriceType = (OriginalPriceTypeEnum?)oldBooking.OriginalPriceType
                                                };

                                                newConnection.Execute(@"Insert Into Booking.SpotBookings(Id, AnnexContractAssetId, SpotId
                                                        , Position, PositionCost, CardRateSet, PositionRateSet, DiscountRateSet
                                                        , OriginalPriceDate, OriginalPriceRate, OriginalPriceType)
                                                    Values(@Id, @AnnexContractContentId, @SpotId
                                                        , @Position, @PositionCost, @CardRateSet, @PositionRateSet, @DiscountRateSet
                                                        , @OriginalPriceDate, @OriginalPriceRate, @OriginalPriceType)",
                                                            new
                                                            {
                                                                newBooking.Id,
                                                                newBooking.AnnexContractContentId,
                                                                newBooking.SpotId,
                                                                newBooking.Position,
                                                                newBooking.PositionCost,
                                                                newBooking.CardRateSet,
                                                                newBooking.PositionRateSet,
                                                                newBooking.DiscountRateSet,
                                                                newBooking.OriginalPriceDate,
                                                                newBooking.OriginalPriceRate,
                                                                newBooking.OriginalPriceType
                                                            });
                                            }

                                            newAnnexContent.Bookings.Add(newBooking);
                                            newSpot.Bookings.Add(newBooking);
                                        }
                                    }
                                }
                            }

                            // Discount
                            foreach (var discount in oldAnnexContractPartner.Discounts)
                            {
                                var newDiscount = newAnnexContractPartner.AnnexContractBase.Discounts.FirstOrDefault(d => d.StartDate == discount.StartDate.Date);
                                if (newDiscount == null)
                                {
                                    newDiscount = new DiscountAnnexContract
                                    {
                                        AnnexContract = newAnnexContractPartner.AnnexContractBase,
                                        AnnexContractId = newAnnexContractPartner.AnnexContractBase.Id,

                                        StartDate = discount.StartDate.Date,
                                        EndDate = discount.EndDate,
                                        Rate = discount.Rate / 100.0M,
                                        Description = discount.Description
                                    };
                                    newAnnexContractPartner.AnnexContractBase.Discounts.Add(newDiscount);

                                    newConnection.Execute(@"Insert Into Price.DiscountAnnexContracts(Id, AnnexContractId, StartDate, EndDate, Rate, Description)
                                        Values(@Id, @AnnexContractId, @StartDate, @EndDate, @Rate, @Description)",
                                        new
                                        {
                                            newDiscount.Id,
                                            newDiscount.AnnexContractId,
                                            newDiscount.StartDate,
                                            newDiscount.EndDate,
                                            newDiscount.Rate,
                                            newDiscount.Description
                                        });
                                }
                                else
                                {
                                    bool changed = false;
                                    if (newDiscount.EndDate != (discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date))
                                    {
                                        newDiscount.EndDate = discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date;
                                        changed = true;
                                    }

                                    if (newDiscount.Rate != discount.Rate / 100.0M)
                                    {
                                        newDiscount.Rate = discount.Rate / 100.0M;
                                        changed = true;
                                    }

                                    if (changed)
                                    {
                                        newConnection.Execute(@"Update Price.DiscountAnnexContracts Set EndDate = @EndDate
                                                , Rate = @Rate
                                            Where Id = @Id",
                                            new
                                            {
                                                newDiscount.Id,
                                                newDiscount.EndDate,
                                                newDiscount.Rate
                                            });
                                    }
                                }
                            }

                            // Discount by timeband
                            foreach (var discount in oldAnnexContractPartner.DiscountByTimeBands)
                            {
                                var newDiscount = newAnnexContractPartner.AnnexContractBase.Discounts.FirstOrDefault(d => d.StartDate == discount.StartDate.Date);
                                if (newDiscount == null)
                                {
                                    newDiscount = new DiscountAnnexContract
                                    {
                                        AnnexContract = newAnnexContractPartner.AnnexContractBase,
                                        AnnexContractId = newAnnexContractPartner.AnnexContractBase.Id,

                                        StartDate = discount.StartDate.Date,
                                        EndDate = discount.EndDate,
                                        Rate = discount.Rate / 100.0M,
                                        Description = discount.Description
                                    };
                                    newAnnexContractPartner.AnnexContractBase.Discounts.Add(newDiscount);

                                    newConnection.Execute(@"Insert Into Price.DiscountAnnexContracts(Id, AnnexContractId, StartDate, EndDate, Rate, Description)
                                        Values(@Id, @AnnexContractId, @StartDate, @EndDate, @Rate, @Description)",
                                        new
                                        {
                                            newDiscount.Id,
                                            newDiscount.AnnexContractId,
                                            newDiscount.StartDate,
                                            newDiscount.EndDate,
                                            newDiscount.Rate,
                                            newDiscount.Description
                                        });
                                }
                                else
                                {
                                    bool changed = false;
                                    if (newDiscount.EndDate != (discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date))
                                    {
                                        newDiscount.EndDate = discount.EndDate == null ? null : (DateTime?)discount.EndDate.Value.Date;
                                        changed = true;
                                    }

                                    if (newDiscount.Rate != discount.Rate / 100.0M)
                                    {
                                        newDiscount.Rate = discount.Rate / 100.0M;
                                        changed = true;
                                    }

                                    if (changed)
                                    {
                                        newConnection.Execute(@"Update Price.DiscountAnnexContracts Set EndDate = @EndDate
                                            , Rate = @Rate
                                        Where Id = @Id",
                                            new
                                            {
                                                newDiscount.Id,
                                                newDiscount.EndDate,
                                                newDiscount.Rate
                                            });
                                    }
                                }

                                var newTimeBand = newTimeBands.First(t => t.OldId == discount.TimeBandId);
                                if (!newDiscount.TimeBandBases.Any(t => t.Id == newTimeBand.Id))
                                {
                                    var newTimeBandApply = new DiscountAnnexContract_TimeBandBase
                                    {
                                        Discount = newDiscount,
                                        DiscountId = newDiscount.Id,

                                        TimeBandBase = newTimeBand.TimeBandBase,
                                        TimeBandBaseId = newTimeBand.TimeBandBase.Id
                                    };
                                    newDiscount.TimeBandBases.Add(newTimeBandApply);
                                    newTimeBand.TimeBandBase.DiscountAnnexContracts.Add(newTimeBandApply);

                                    newConnection.Execute(@"Insert Into Price.DiscountAnnexContract_TimeBandBases(Id, DiscountId, TimeBandBaseId)
                                        Values(@Id, @DiscountId, @TimeBandBaseId)",
                                        new
                                        {
                                            newTimeBandApply.Id,
                                            newTimeBandApply.DiscountId,
                                            newTimeBandApply.TimeBandBaseId
                                        });
                                }
                            }

                            // Price at sign date
                            foreach (var priceAtSignDate in oldAnnexContractPartner.PriceAtSignDates)
                            {
                                var newPriceAtSignDate = newAnnexContractPartner.PriceAtSignDates.FirstOrDefault(p => p.StartDate == priceAtSignDate.StartDate.Date);
                                if (newPriceAtSignDate == null)
                                {
                                    newPriceAtSignDate = new AnnexContractPartnerPriceAtSignDate
                                    {
                                        AnnexContract = newAnnexContractPartner,
                                        AnnexContractId = newAnnexContractPartner.Id,

                                        StartDate = priceAtSignDate.StartDate.Date,
                                        EndDate = priceAtSignDate.EndDate
                                    };
                                    newAnnexContractPartner.PriceAtSignDates.Add(newPriceAtSignDate);

                                    newConnection.Execute(@"Insert Into Price.AnnexContractPartnerPriceAtSignDates(Id, AnnexContractId, StartDate, EndDate)
                                        Values(@Id, @AnnexContractId, @StartDate, @EndDate)",
                                        new
                                        {
                                            newPriceAtSignDate.Id,
                                            newPriceAtSignDate.AnnexContractId,
                                            newPriceAtSignDate.StartDate,
                                            newPriceAtSignDate.EndDate
                                        });
                                }
                                else if (newPriceAtSignDate.EndDate != (priceAtSignDate.EndDate == null ? null : (DateTime?)priceAtSignDate.EndDate.Value.Date))
                                {
                                    newPriceAtSignDate.EndDate = priceAtSignDate.EndDate == null ? null : (DateTime?)priceAtSignDate.EndDate.Value.Date;
                                    newConnection.Execute(@"Update Price.AnnexContractPartnerPriceAtSignDates Set EndDate = @EndDate
                                        Where Id = @Id",
                                        new
                                        {
                                            newPriceAtSignDate.Id,
                                            newPriceAtSignDate.EndDate
                                        });
                                }
                            }

                            // Price
                            foreach (var oldAnnexContractPrice in oldAnnexContractPartner.Prices)
                            {
                                var newAnnexContractPrice = newAnnexContractPartner.Prices.FirstOrDefault(p => p.StartDate == oldAnnexContractPrice.StartDate.Date);
                                if (newAnnexContractPrice == null)
                                {
                                    newAnnexContractPrice = new HD.TVAD.Entities.Entities.Price.AnnexContractPrice
                                    {
                                        AnnexContract = newAnnexContractPartner,
                                        AnnexContractId = newAnnexContractPartner.Id,

                                        StartDate = oldAnnexContractPrice.StartDate.Date,
                                        EndDate = oldAnnexContractPrice.EndDate
                                    };
                                    newAnnexContractPartner.Prices.Add(newAnnexContractPrice);

                                    newConnection.Execute(@"Insert Into Price.AnnexContractPrices(Id, AnnexContractId, StartDate, EndDate)
                                        Values(@Id, @AnnexContractId, @StartDate, @EndDate)",
                                        new
                                        {
                                            newAnnexContractPrice.Id,
                                            newAnnexContractPrice.AnnexContractId,
                                            newAnnexContractPrice.StartDate,
                                            newAnnexContractPrice.EndDate
                                        });

                                    if (oldAnnexContractPrice.TimeBands.Count == 0)
                                        oldAnnexContractPrice.TimeBands.Add(null);

                                    foreach (var oldTimeBand in oldAnnexContractPrice.TimeBands)
                                    {
                                        TimeBand newTimeBand = null;
                                        if (oldTimeBand != null)
                                            newTimeBand = newTimeBands.First(t => t.OldId == oldTimeBand.TimeBand.Id);

                                        var priceTimeBand = new AnnexContractPrice_TimeBand
                                        {
                                            AnnexContractPrice = newAnnexContractPrice,
                                            PriceId = newAnnexContractPrice.Id,

                                            TimeBand = newTimeBand,
                                            TimeBandId = newTimeBand == null ? null : (Guid?)newTimeBand.Id,

                                            PositionRateUnit = oldAnnexContractPrice.PositionRateUnit
                                        };
                                        newAnnexContractPrice.Prices.Add(priceTimeBand);
                                        if (newTimeBand != null)
                                            newTimeBand.AnnexContractPrices.Add(priceTimeBand);
                                        newConnection.Execute(@"Insert Into Price.AnnexContractPrice_TimeBands(Id, PriceId, TimeBandId, PositionRateUnit)
                                            Values(@Id, @PriceId, @TimeBandId, @PositionRateUnit)",
                                            new
                                            {
                                                priceTimeBand.Id,
                                                priceTimeBand.PriceId,
                                                priceTimeBand.TimeBandId,
                                                priceTimeBand.PositionRateUnit
                                            });

                                        foreach (var oldBlock in oldAnnexContractPrice.Blocks)
                                        {
                                            var newBlock = newBlocks.FirstOrDefault(b => b.Duration == oldBlock.BlockDuration);
                                            if (newBlock != null)
                                            {
                                                var newBlockPrice = new AnnexContractPrice_SpotBlock
                                                {
                                                    PriceTimeBand = priceTimeBand,
                                                    PriceTimeBandId = priceTimeBand.Id,

                                                    SpotBlock = newBlock,
                                                    SpotBlockId = newBlock.Id,

                                                    Price = oldBlock.Price
                                                };
                                                priceTimeBand.Prices.Add(newBlockPrice);
                                                priceTimeBand.Prices.Add(newBlockPrice);
                                            }
                                        }

                                        foreach (var newBlockPrice in priceTimeBand.Prices)
                                        {
                                            newConnection.Execute(@"Insert Into Price.AnnexContractPrice_SpotBlocks(Id, PriceTimeBandId, SpotBlockId, Price)
                                                Values(@Id, @PriceTimeBandId, @SpotBlockId, @Price)",
                                                new
                                                {
                                                    newBlockPrice.Id,
                                                    newBlockPrice.PriceTimeBandId,
                                                    newBlockPrice.SpotBlockId,
                                                    newBlockPrice.Price
                                                });
                                        }
                                    }
                                }
                            }

                            foreach (var content in newAnnexContractPartner.AnnexContractBase.Contents)
                            {
                                foreach (var booking in content.Bookings)
                                {
                                    newConnection.Execute(@"EXEC sp_CalcBookingPrice @Id", new { Id = booking.Id });
                                }
                            }

                            // Check price
                            var newPrice = newConnection.Query<AnnexContractPrice>(@"Select SUM(RateCard) CardRate, SUM(PositionRate) PositionRate, SUM(DiscountRate) DiscountRate
                                From
		                        (
			                        Select SpotBookings.Id, TimeBandBases.Name as TimeBand, Content.Code
                                        , dbo.fn_SpotBookingCardRate(SpotBookings.Id) as RateCard
                                        , dbo.fn_SpotBookingPositionRate(SpotBookings.Id) as PositionRate
                                        , dbo.fn_SpotBookingDiscountRate(SpotBookings.Id) as DiscountRate
			                        From Booking.AnnexContracts
			                        Inner Join Booking.AnnexContractAssets On AnnexContractAssets.AnnexContractId = AnnexContracts.Id
			                        Inner Join Booking.SpotBookings On SpotBookings.AnnexContractAssetId = AnnexContractAssets.Id
			                        Inner Join MediaAssets.Content On AnnexContractAssets.ContentId = Content.Id
			                        Inner Join Schedule.Spots On SpotBookings.SpotId = Spots.Id
			                        Inner Join System.TimeBandSlices On TimeBandSlices.Id = Spots.TimeBandSliceId
			                        Inner Join System.TimeBands On TimeBandSlices.TimeBandId = TimeBands.Id
			                        Inner Join System.TimeBandBases On TimeBands.Id = TimeBandBases.Id
			                        Where AnnexContracts.Id = @Id
		                        ) as STable", new { newAnnexContractPartner.Id }).First();

                            var oldPrice = oldConnection.Query<AnnexContractPrice>(@"Select SUM(RateCard) CardRate, SUM(PositionRate) PositionRate, SUM(DiscountRate) DiscountRate
                                From
                                (
	                                Select dbo.DonGiaPhatSong(tblPhatSong.IDPhatSong) RateCard, dbo.TienViTriPhatSong(tblPhatSong.IDPhatSong) PositionRate, dbo.TienGiamGiaPhatSong(tblPhatSong.IDPhatSong) DiscountRate
	                                From tblPhatSong
	                                Where IDPhuLucHopDong = @Id
                                ) As STable", new { oldAnnexContractPartner.Id }).First();

                            if (newPrice.CardRate == null)
                                newPrice.CardRate = 0;
                            if (newPrice.PositionRate == null)
                                newPrice.PositionRate = 0;
                            if (newPrice.DiscountRate == null)
                                newPrice.DiscountRate = 0;

                            if (oldPrice.CardRate == null)
                                oldPrice.CardRate = 0;
                            if (oldPrice.PositionRate == null)
                                oldPrice.PositionRate = 0;
                            if (oldPrice.DiscountRate == null)
                                oldPrice.DiscountRate = 0;

                            if (newPrice.CardRate != oldPrice.CardRate
                                || newPrice.PositionRate != oldPrice.PositionRate
                                || newPrice.DiscountRate != oldPrice.DiscountRate)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Annex contract {oldAnnexContractPartner.Code} error price");
                            }
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                var newRetailCustomers = contextNew.Contract_RetailCustomers
                    .Include(c => c.BaseCustomer)
                    .ToList();

                #region Annex contract retail
                if (true)
                {
                    contextOld.Spots.Load();
                    contextOld.Contents.Load();
                    contextOld.TimeBands.Load();
                    contextOld.AnnexContractRetailSpotBookings.Load();
                    contextOld.AnnexContractRetails
                        .Include(a => a.Contents)
                        .Load();
                    var oldAnnexContractRetails = contextOld.AnnexContractRetails.Local.ToList();
                    int nb = 0;
                    foreach (var oldAnnexContract in oldAnnexContractRetails)
                    {
                        Console.Write($"\rProcessing {++nb} / {oldAnnexContractRetails.Count} retail annex contract");

                        if (oldAnnexContract.CustomerName == null)
                            oldAnnexContract.CustomerName = "";
                        if (oldAnnexContract.ReceiveDate == null)
                            oldAnnexContract.ReceiveDate = new DateTime(2017, 1, 1);

                        var newCustomer = newRetailCustomers.FirstOrDefault(c => c.BaseCustomer.Name == oldAnnexContract.CustomerName);
                        if (newCustomer == null)
                        {
                            newCustomer = new RetailCustomer();
                            newCustomer.BaseCustomer.TypeId = CustomerTypeEnum.Retail;
                            newCustomer.BaseCustomer.Name = oldAnnexContract.CustomerName;
                            newCustomer.BaseCustomer.Address = oldAnnexContract.Address;

                            newRetailCustomers.Add(newCustomer);

                            newConnection.Execute(@"Insert Into Contract.Customers(Id, TypeId, Name, Address)
                                Values(@Id, @TypeId, @Name, @Address)

                                Insert Into Contract.RetailCustomers(Id)
                                Values(@Id)",
                                new
                                {
                                    newCustomer.Id,
                                    newCustomer.BaseCustomer.TypeId,
                                    newCustomer.BaseCustomer.Name,
                                    newCustomer.BaseCustomer.Address
                                });
                        }

                        var newAnnexContractRetail = newAnnexContractRetails.FirstOrDefault(a => a.OldId == oldAnnexContract.Id);
                        if (newAnnexContractRetail == null)
                        {
                            newAnnexContractRetail = new AnnexContractRetail
                            {
                                OldId = oldAnnexContract.Id
                            };
                            newAnnexContractRetail.AnnexContractBase.Customer = newCustomer.BaseCustomer;
                            newAnnexContractRetail.AnnexContractBase.CustomerId = newCustomer.BaseCustomer.Id;
                            newCustomer.BaseCustomer.AnnexContracts.Add(newAnnexContractRetail.AnnexContractBase);

                            newAnnexContractRetail.AnnexContractBase.Code = oldAnnexContract.Code;
                            if (newAnnexContractPartners.Any(a => a.AnnexContractBase.Code == newAnnexContractRetail.AnnexContractBase.Code))
                                newAnnexContractRetail.AnnexContractBase.Code += "_";
                            newAnnexContractRetail.AnnexContractBase.BookingTypeId = BookingTypeEnum.Retail;
                            newAnnexContractRetail.AnnexContractBase.ReceiveDate = oldAnnexContract.ReceiveDate.Value;
                            newAnnexContractRetail.AnnexContractBase.Creater = oldAnnexContract.Creater;

                            newAnnexContractRetails.Add(newAnnexContractRetail);

                            newConnection.Execute(@"Insert Into Booking.AnnexContracts(Id, CustomerId, Code, BookingTypeId, ReceiveDate, Creater)
                                Values(@Id, @CustomerId, @Code, @BookingTypeId, @ReceiveDate, @Creater)

                                Insert Into Booking.RetailContracts(Id, OldId)
                                Values(@Id, @OldId)",
                                new
                                {
                                    newAnnexContractRetail.AnnexContractBase.Id,
                                    newAnnexContractRetail.AnnexContractBase.CustomerId,
                                    newAnnexContractRetail.AnnexContractBase.Code,
                                    newAnnexContractRetail.AnnexContractBase.BookingTypeId,
                                    newAnnexContractRetail.AnnexContractBase.ReceiveDate,
                                    newAnnexContractRetail.AnnexContractBase.Creater,
                                    newAnnexContractRetail.OldId
                                });
                        }
                        else
                        {
                            bool changedBase = false;

                            if (newAnnexContractRetail.AnnexContractBase.CustomerId != newCustomer.BaseCustomer.Id)
                            {
                                if (newAnnexContractRetail.AnnexContractBase.Customer != null
                                    && newAnnexContractRetail.AnnexContractBase.Customer.AnnexContracts.Contains(newAnnexContractRetail.AnnexContractBase))
                                    newAnnexContractRetail.AnnexContractBase.Customer.AnnexContracts.Remove(newAnnexContractRetail.AnnexContractBase);

                                newAnnexContractRetail.AnnexContractBase.CustomerId = newCustomer.BaseCustomer.Id;
                                newAnnexContractRetail.AnnexContractBase.Customer = newCustomer.BaseCustomer;
                                newCustomer.BaseCustomer.AnnexContracts.Add(newAnnexContractRetail.AnnexContractBase);

                                changedBase = true;
                            }

                            if (newAnnexContractRetail.AnnexContractBase.Code != oldAnnexContract.Code)
                            {
                                newAnnexContractRetail.AnnexContractBase.Code = oldAnnexContract.Code;
                                changedBase = true;
                            }

                            if (newAnnexContractRetail.AnnexContractBase.ReceiveDate != oldAnnexContract.ReceiveDate.Value)
                            {
                                newAnnexContractRetail.AnnexContractBase.ReceiveDate = oldAnnexContract.ReceiveDate.Value;
                                changedBase = true;
                            }

                            if (newAnnexContractRetail.AnnexContractBase.Creater != oldAnnexContract.Creater)
                            {
                                newAnnexContractRetail.AnnexContractBase.Creater = oldAnnexContract.Creater;
                                changedBase = true;
                            }

                            if (changedBase)
                            {
                                newConnection.Execute(@"Update Booking.AnnexContractPartners Set CustomerId = @CustomerId
                                        , Code = @Code
                                        , ReceiveDate = @ReceiveDate
                                        , Creater = @Creater
                                    Where Id = @Id",
                                    new
                                    {
                                        newAnnexContractRetail.AnnexContractBase.Id,
                                        newAnnexContractRetail.AnnexContractBase.CustomerId,
                                        newAnnexContractRetail.AnnexContractBase.Code,
                                        newAnnexContractRetail.AnnexContractBase.ReceiveDate,
                                        newAnnexContractRetail.AnnexContractBase.Creater
                                    });
                            }
                        }

                        // Content
                        foreach (var oldAnnexContent in oldAnnexContract.Contents)
                        {
                            var newAnnexContent = newAnnexContractRetail
                                .AnnexContractBase
                                .Contents
                                .FirstOrDefault(c => c.Content.OldId == oldAnnexContent.Content.Id);

                            if (newAnnexContent == null)
                            {
                                var newContent = newContents.Find(c => c.OldId == oldAnnexContent.Content.Id);
                                PriceTypeDetail priceDetail = null;
                                if (oldAnnexContent.RetailTypeId == HD.TVADOld.Entities.Entities.RetailTypeEnum.Ceiling) // Cận trên
                                    priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Ceiling);
                                else if (oldAnnexContent.RetailTypeId == HD.TVADOld.Entities.Entities.RetailTypeEnum.Special) // Giá trực tiếp
                                    priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Special);
                                else if (oldAnnexContent.RetailTypeId == HD.TVADOld.Entities.Entities.RetailTypeEnum.Notify) // Thông báo
                                    priceDetail = newPriceTypeDetails.First(t => t.Retail != null && t.Retail.OldId == (int)oldAnnexContent.RetailTypeId);
                                else if (oldAnnexContent.RetailTypeId == HD.TVADOld.Entities.Entities.RetailTypeEnum.Simple) // Tin đơn giản
                                    priceDetail = newPriceTypeDetails.First(t => t.Retail != null && t.Retail.OldId == (int)oldAnnexContent.RetailTypeId);
                                if (priceDetail == null) // Miễn phí
                                    priceDetail = newPriceTypeDetails.First(t => t.TypeId == PriceTypeEnum.Free);

                                newAnnexContent = new AnnexContractContent
                                {
                                    AnnexContract = newAnnexContractRetail.AnnexContractBase,
                                    AnnexContractId = newAnnexContractRetail.AnnexContractBase.Id,

                                    Content = newContent,
                                    ContentId = newContent.Id,

                                    PriceTypeDetail = priceDetail,
                                    PriceTypeDetailId = priceDetail.Id,

                                    Contents = oldAnnexContent.Contents,
                                    Price = priceDetail.TypeId == PriceTypeEnum.Special ? oldAnnexContent.Price : null
                                };
                                newAnnexContractRetail.AnnexContractBase.Contents.Add(newAnnexContent);
                                newContent.AnnexContracts.Add(newAnnexContent);
                                priceDetail.AnnexContractContents.Add(newAnnexContent);

                                newConnection.Execute(@"Insert Into Booking.AnnexContractAssets(Id, AnnexContractId, ContentId, PriceTypeDetailId, Contents)
                                            Values(@Id, @AnnexContractId, @ContentId, @PriceTypeDetailId, @Contents)",
                                    new
                                    {
                                        newAnnexContent.Id,
                                        newAnnexContent.AnnexContractId,
                                        newAnnexContent.ContentId,
                                        newAnnexContent.PriceTypeDetailId,
                                        newAnnexContent.Contents
                                    });
                            }

                            if (newAnnexContent.Bookings.Count == 0)
                            {
                                // Booking
                                foreach (var oldBooking in oldAnnexContent.Bookings)
                                {
                                    var newSlice = newTimeBands.First(t => t.OldId == oldBooking.Spot.TimeBandSlice.TimeBand.Id)
                                        .Slices.First(s => s.Name == oldBooking.Spot.TimeBandSlice.SliceId.ToString());

                                    var newSpot = newSlice.Spots.FirstOrDefault(s => s.BroadcastDate == oldBooking.Spot.BroadcastDate.Date);
                                    if (newSpot == null)
                                    {
                                        newSpot = new HD.TVAD.Entities.Entities.Schedule.Spot
                                        {
                                            BroadcastDate = oldBooking.Spot.BroadcastDate.Date,
                                            TimeBandSlice = newSlice,
                                            TimeBandSliceId = newSlice.Id,
                                            Description = oldBooking.Spot.Description
                                        };
                                        newSlice.Spots.Add(newSpot);
                                        newSpots.Add(newSpot);

                                        newConnection.Execute(@"Insert Into Schedule.Spots(Id, BroadcastDate, TimeBandSliceId, Description)
                                                    Values(@Id, @BroadcastDate, @TimeBandSliceId, @Description)",
                                            new
                                            {
                                                newSpot.Id,
                                                newSpot.BroadcastDate,
                                                newSpot.TimeBandSliceId,
                                                newSpot.Description
                                            });
                                    }

                                    SpotBooking newBooking = null;
                                    if (oldBooking.Approve == true)
                                    {
                                        var spotContentByBooking = new SpotContentByBooking();
                                        newBooking = spotContentByBooking.Booking;

                                        newBooking.AnnexContractContent = newAnnexContent;
                                        newBooking.AnnexContractContentId = newAnnexContent.Id;

                                        newBooking.Spot = newSpot;
                                        newBooking.SpotId = newSpot.Id;

                                        newBooking.Position = (int)oldBooking.Index;

                                        spotContentByBooking.BaseSpotContent.Spot = newSpot;
                                        spotContentByBooking.BaseSpotContent.SpotId = newSpot.Id;
                                        spotContentByBooking.BaseSpotContent.Index = (int)oldBooking.Index;

                                        newConnection.Execute(@"Insert Into Booking.SpotBookings(Id, AnnexContractAssetId, SpotId, Position)
                                                    Values(@Id, @AnnexContractContentId, @SpotId, @Position)

                                                    Insert Into Schedule.SpotAssets(Id, SpotId, [Index]) Values(@Id, @SpotId, @Position)

                                                    Insert Into Schedule.SpotAssetByBookings(Id) Values(@Id)",
                                            new
                                            {
                                                newBooking.Id,
                                                newBooking.AnnexContractContentId,
                                                newBooking.SpotId,
                                                newBooking.Position
                                            });
                                    }
                                    else
                                    {
                                        newBooking = new SpotBooking
                                        {
                                            AnnexContractContent = newAnnexContent,
                                            AnnexContractContentId = newAnnexContent.Id,

                                            Spot = newSpot,
                                            SpotId = newSpot.Id,

                                            Position = (int)oldBooking.Index
                                        };

                                        newConnection.Execute(@"Insert Into Booking.SpotBookings(Id, AnnexContractAssetId, SpotId, Position)
                                                    Values(@Id, @AnnexContractContentId, @SpotId, @Position)",
                                                    new
                                                    {
                                                        newBooking.Id,
                                                        newBooking.AnnexContractContentId,
                                                        newBooking.SpotId,
                                                        newBooking.Position
                                                    });
                                    }

                                    newAnnexContent.Bookings.Add(newBooking);
                                    newSpot.Bookings.Add(newBooking);
                                }
                            }
                        }

                        foreach (var content in newAnnexContractRetail.AnnexContractBase.Contents)
                        {
                            foreach (var booking in content.Bookings)
                            {
                                newConnection.Execute(@"EXEC sp_CalcBookingPrice @Id", new { Id = booking.Id });
                            }
                        }

                        // Check price
                        var newPrice = newConnection.Query<AnnexContractPrice>(@"Select SUM(RateCard) CardRate, SUM(PositionRate) PositionRate, SUM(DiscountRate) DiscountRate
                                From
		                        (
			                        Select SpotBookings.Id, TimeBandBases.Name as TimeBand, Content.Code
                                        , dbo.fn_SpotBookingCardRate(SpotBookings.Id) as RateCard
                                        , dbo.fn_SpotBookingPositionRate(SpotBookings.Id) as PositionRate
                                        , dbo.fn_SpotBookingDiscountRate(SpotBookings.Id) as DiscountRate
			                        From Booking.AnnexContracts
			                        Inner Join Booking.AnnexContractAssets On AnnexContractAssets.AnnexContractId = AnnexContracts.Id
			                        Inner Join Booking.SpotBookings On SpotBookings.AnnexContractAssetId = AnnexContractAssets.Id
			                        Inner Join MediaAssets.Content On AnnexContractAssets.ContentId = Content.Id
			                        Inner Join Schedule.Spots On SpotBookings.SpotId = Spots.Id
			                        Inner Join System.TimeBandSlices On TimeBandSlices.Id = Spots.TimeBandSliceId
			                        Inner Join System.TimeBands On TimeBandSlices.TimeBandId = TimeBands.Id
			                        Inner Join System.TimeBandBases On TimeBands.Id = TimeBandBases.Id
			                        Where AnnexContracts.Id = @Id
		                        ) as STable", new { newAnnexContractRetail.Id }).First();

                        var oldPrice = oldConnection.Query<AnnexContractPrice>(@"Select SUM(RateCard) CardRate
                                From
                                (
	                                Select dbo.ThanhTienPhatSongThuLe(tblPhatSongHopDongThuLe.IDPhatSong) RateCard
	                                From tblPhatSongHopDongThuLe
	                                Where IDHopDong = @Id
                                ) As STable", new { oldAnnexContract.Id }).First();

                        if (newPrice.CardRate == null)
                            newPrice.CardRate = 0;
                        if (newPrice.PositionRate == null)
                            newPrice.PositionRate = 0;
                        if (newPrice.DiscountRate == null)
                            newPrice.DiscountRate = 0;

                        if (oldPrice.CardRate == null)
                            oldPrice.CardRate = 0;
                        if (oldPrice.PositionRate == null)
                            oldPrice.PositionRate = 0;
                        if (oldPrice.DiscountRate == null)
                            oldPrice.DiscountRate = 0;

                        if (newPrice.CardRate != oldPrice.CardRate
                            || newPrice.PositionRate != oldPrice.PositionRate
                            || newPrice.DiscountRate != oldPrice.DiscountRate)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Annex contract {oldAnnexContract.Code} error price");
                        }
                    }
                    Console.WriteLine();
                }
                #endregion
            }

            Console.WriteLine("Completed");
            Console.ReadKey();
        }

        static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }

        enum WorkflowResultState : int
        {
            None = 0,
            Success = 3,
            Failed = 4
        }

        class WorkflowResult
        {
            public WorkflowResultState State { get; set; } = WorkflowResultState.None;

            public string Message { get; set; }

            public Guid WorkflowId { get; set; }
        }

        static WorkflowResult AttachWorkflow(Guid contentId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppSettings.Default.WorkflowAPIAddress);

                    // We want the response to be JSON.
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var credentials = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("contentId", contentId.ToString()),
                            new KeyValuePair<string, string>("workflowDiagramId", AppSettings.Default.WorkflowDiagramId.ToString())
                        });

                    // Post to the Server and parse the response.
                    var response = client.PostAsync("Attach", credentials).Result;

                    try
                    {
                        // Parsing the returned_result to TokenResponse
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var result = JsonConvert.DeserializeObject<WorkflowResult>(response.Content.ReadAsStringAsync().Result);
                            return result;
                        }
                        else
                        {
                            throw new Exception("HTTP Status: " + response.StatusCode.ToString() + " - Reason: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                return new WorkflowResult
                {
                    Message = ex.Message
                };
            }
        }

        class AnnexContractPrice
        {
            public decimal? CardRate { get; set; }

            public decimal? PositionRate { get; set; }

            public decimal? DiscountRate { get; set; }
        }
    }
}
