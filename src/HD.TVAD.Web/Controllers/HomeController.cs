using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.Web.Features.Manager;
using Microsoft.Extensions.Logging;
using HD.TVAD.Web.Models;
using Microsoft.Extensions.Options;
using HD.Web.Delay;
using System.IO;
using HD.Web.Delay.Business;
using System.Data.SqlClient;
using Dapper;
using HD.Web.Delay.Models.DAO;

namespace HD.TVAD.Web.Controllers
{
    public class HomeController : TVADController
    {
        private readonly IOptions<Settings> _settings;
        private string logFile;
        public string _SubFolder;
        public string _CaptureLowresFolder;
        public string _connectionString;
        public string _logFolder;
        public int _channelId;
        public int _displaySubScheduleTime;
        public string _VideoFile;
        private Util _util;
        public HomeController(IOptions<Settings> settings)
        {
            _settings = settings;
            _util = new Util();
            _SubFolder = _settings.Value.AppSettings.SubFolder;
            _CaptureLowresFolder = _settings.Value.AppSettings.CaptureLowresFolder;
            _channelId = _settings.Value.AppSettings.ChannelId;
            _displaySubScheduleTime = _settings.Value.AppSettings.DisplaySubScheduleTime;
            _connectionString = _settings.Value.AppSettings.connString;
            _logFolder = _settings.Value.AppSettings.LogFolder;
            _VideoFile = GetVideoToPlay();

            //Kiểm tra quá 50 file logs thì xóa 20 files đầu
            string[] files = Directory.GetFiles(_logFolder, "*.txt", SearchOption.TopDirectoryOnly);
            if (files.Count() > 50)
            {
                for (var i = 0; i < 20; i++)
                {
                    System.IO.File.Delete(files[i]);
                }
            }

            logFile = Path.Combine(_logFolder, DateTime.Now.ToString("yyyyMMdd") + ".txt");
            if (!System.IO.File.Exists(logFile))
            {
                System.IO.File.Create(logFile).Dispose();
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult TimeSlider()
        {
            return View();
        }

        #region Khu vực các action về Video và Sub
        public ActionResult MapVideoToSubTime(string subTimelineIdStr, string subTimelineItemIdStr)
        {
            bool success = false;
            using (var db = new SqlConnection(_connectionString))
            {
                try
                {
                    var subTimelineIdNum = int.Parse(_util.GetNumber(subTimelineIdStr));
                    var currentStartTime = db.Query<DateTime>(@"select StartTime from SubtitleTimeLine where TimeLineId=@timelineId", new
                    {
                        timelineId = subTimelineIdNum
                    }).FirstOrDefault();
                    //get time of current sub item on DB
                    var subTimelineItemIdNum = int.Parse(_util.GetNumber(subTimelineItemIdStr));
                    var currentSubItemStartTime = db.Query<long>(@"select StartTime from SubtitleFileItem where ItemId=@itemId", new
                    {
                        itemId = subTimelineItemIdNum
                    }).FirstOrDefault();
                    var tempVideoTime = currentStartTime.AddMilliseconds(currentSubItemStartTime);
                    //find the video file nearest this time
                    var tempLowresFile = db.Query<RecordLowres>(@"select * from RecordLowres where ChannelId=@channelId", new
                    {
                        channelId = _channelId
                    }).Where(a => a.RecordTime <= tempVideoTime).OrderBy(a => a.RecordTime).LastOrDefault();
                    _VideoFile = tempLowresFile.FileName;
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    _util.AddLog(logFile, "Loi trong MapVideoToSubTime: " + ex.ToString());
                }
                return Json(success);
            }
        }

        public string GetVideoToPlay()
        {
            List<RecordLowres> currentVideo = new List<RecordLowres>();
            using (var db = new SqlConnection(_connectionString))
            {
                try
                {
                    currentVideo = db.Query<RecordLowres>(@"select * from RecordLowres where ChannelId=@channelId and Deleted=@deleted and Duration>0", new
                    {
                        channelId = _channelId,
                        deleted = false
                    }).OrderBy(a => a.RecordTime).ToList();
                }
                catch { }
            }
            int i = (int)currentVideo.LongCount();
            return currentVideo[i - 2].FileName;
        }

        public ActionResult GetAllVideo(string dirName)
        {
            List<RecordLowres> allVideo = new List<RecordLowres>();
            using (var db = new SqlConnection(_connectionString))
            {
                try
                {
                    allVideo = db.Query<RecordLowres>(@"select * from RecordLowres where Deleted=@deleted and Duration >0", new
                    {
                        deleted = false
                    }).ToList();
                }
                catch (Exception ex)
                {
                    _util.AddLog(logFile, ex.ToString());
                    return Json(ex);
                }
            }
            return Json(allVideo);
        }

        public ActionResult GetNextVideoFromCurrentSrc(string currentSrc)
        {
            string videoName = "";
            string currentVideoName = currentSrc.Substring(currentSrc.Length - "2016_12/20161206_142435.mp4".Length);
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    try
                    {
                        var tempRecordId = db.Query<int>(@"select RecordId from RecordLowres WHERE FileName=@fileName and ChannelId=@channelId",
                                new
                                {
                                    fileName = currentVideoName.Replace("/", "\\"),
                                    channelId = _channelId
                                }).FirstOrDefault();
                        videoName = db.Query<string>(@"select FileName from RecordLowres WHERE RecordId=@recordId and ChannelId=@channelId",
                                new
                                {
                                    recordId = tempRecordId + 1,
                                    channelId = _channelId
                                }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        _util.AddLog(logFile, "Loi trong GetNextVideoFromCurrentSrc DB: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                _util.AddLog(logFile, "Loi trong GetNextVideoFromCurrentSrc: " + ex.ToString());
            }
            return Json(videoName);
        }
        public ActionResult GetBackVideoFromCurrentSrc(string currentSrc)
        {
            string videoName = "";
            string currentVideoName = currentSrc.Substring(currentSrc.Length - "2016_12/20161206_142435.mp4".Length);
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    try
                    {
                        var tempRecordId = db.Query<int>(@"select RecordId from RecordLowres WHERE FileName=@fileName and ChannelId=@channelId",
                                new
                                {
                                    fileName = currentVideoName.Replace("/", "\\"),
                                    channelId = _channelId
                                }).FirstOrDefault();
                        videoName = db.Query<string>(@"select FileName from RecordLowres WHERE RecordId=@recordId and ChannelId=@channelId",
                                new
                                {
                                    recordId = tempRecordId - 1,
                                    channelId = _channelId
                                }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        _util.AddLog(logFile,"Loi trong GetNextVideoFromCurrentSrc DB: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                _util.AddLog(logFile, "Loi trong GetNextVideoFromCurrentSrc: " + ex.ToString());
            }
            return Json(videoName);
        }
        public ActionResult SetVideoToPlay(double timespan)
        {
            var videoTime = _util.FromMS(timespan);
            var videoFile = new VideoFile();
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    try
                    {
                        var tempRecord = db.Query<RecordLowres>(@"select * from RecordLowres WHERE RecordTime<=@recordTime",
                                new
                                {
                                    recordTime = videoTime
                                }).Where(a => a.RecordTime.Date == videoTime.Date).OrderBy(a => a.RecordTime).LastOrDefault();
                        videoFile.FileName = tempRecord.FileName;
                        var timeDic = _util.GetPlayingTime(Path.GetFileNameWithoutExtension(videoFile.FileName));
                        string subTimelineStartTime = timeDic["year"] + "-" + timeDic["month"] + "-" + timeDic["day"] + " " + timeDic["hour"] + ":" + timeDic["min"] + ":" + timeDic["sec"];
                        var timelineStartTimeNow = DateTime.ParseExact(subTimelineStartTime, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                        var tempTime = (timelineStartTimeNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
                        videoFile.CurrentTime = (timespan - tempTime) / 1000;
                    }
                    catch (Exception ex)
                    {
                        _util.AddLog(logFile, "Loi trong SetVideoToPlay DB: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                _util.AddLog(logFile, "Loi trong SetVideoToPlay: " + ex.ToString());
            }
            return Json(videoFile);
        }
        #endregion

        #region Khu vực các action về folder và file
        public ActionResult CreateDir(string dirName)
        {
            bool success = false;
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    try
                    {
                        int currentChannelId = db.Query<int>(@"Select ChannelId from CurrentItem where CurrentType=0").FirstOrDefault();
                        db.Execute(@"Insert Into SubtitleCategory(CategoryName, ChannelId) Values(@categoryName, @channelId)",
                                new
                                {
                                    categoryName = dirName,
                                    channelId = currentChannelId
                                });
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        _util.AddLog(logFile,"Loi trong CreateDir DB: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                _util.AddLog(logFile, "Loi trong CreateDir: " + ex.ToString());
            }
            return Json(success);
        }

        public ActionResult CreateChildDir(string dirName, string parentDirIdStr)
        {
            bool success = false;
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    try
                    {
                        int currentChannelId = db.Query<int>(@"Select ChannelId from CurrentItem where CurrentType=0").FirstOrDefault();
                        var parentDirId = int.Parse(_util.GetNumber(parentDirIdStr));
                        db.Execute(@"Insert Into SubtitleCategory(CategoryName, ChannelId, CategoryParrentId) Values(@categoryName, @channelId, @parentId)",
                                new
                                {
                                    categoryName = dirName,
                                    channelId = currentChannelId,
                                    parentId = parentDirId
                                });
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        _util.AddLog(logFile, "Loi trong CreateChildDir DB: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                _util.AddLog(logFile, "Loi trong CreateChildDir: " + ex.ToString());
            }
            return Json(success);
        }

        public ActionResult AddFile(string filePath, string currentCategoryIdStr, bool isSetTimeCodeTo0)
        {
            bool success = false;
            string tempPath = Path.Combine(_SubFolder, Path.GetFileName(filePath));
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Insert file into SubtitleFile table                        
                        var currentCategoryId = int.Parse(_util.GetNumber(currentCategoryIdStr));
                        db.Execute(@"insert Into SubtitleFile(ProgramName, CategoryId) Values(@programName, @categoryId)",
                            new
                            {
                                programName = Path.GetFileNameWithoutExtension(filePath),
                                categoryId = currentCategoryId
                            });

                        //Insert file into SubtitleFileItem table
                        var lstSubs = ReadSubFile(tempPath);
                        var currentFileId = db.Query<int>("select FileId from SubtitleFile where ProgramName=@proName and CategoryId=@cateId",
                            new
                            {
                                proName = Path.GetFileNameWithoutExtension(filePath),
                                cateId = currentCategoryId
                            }).FirstOrDefault();
                        var tempTime = lstSubs[0].StartTime;
                        foreach (var temp in lstSubs)
                        {
                            if (isSetTimeCodeTo0)
                            {
                                temp.StartTime -= tempTime;
                            }
                            db.Execute(@"Insert Into SubtitleFileItem(FileId, StartTime, Duration, Text, Position, Align) Values(@fileId, @startTime, @duration, @text, @position, @align)",
                                new
                                {
                                    fileId = currentFileId,
                                    text = temp.Text,
                                    align = temp.Align,
                                    duration = temp.Duration,
                                    startTime = temp.StartTime,
                                    position = temp.Position
                                });
                        }
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        _util.AddLog(logFile,"Loi trong AddFile Db: " + ex.ToString());
                    }
                }


            }
            catch (Exception ex)
            {
                success = false;
                _util.AddLog(logFile,"Loi khi AddFile: " + ex.ToString());
            }
            return Json(success);
        }
        #endregion
        public List<SubtitleFileItem> ReadSubFile(string fileName)
        {
            try
            {
                switch (Path.GetExtension(fileName).ToLower())
                {
                    case ".cip":
                        return _util.ReadCipFile(fileName);

                    case ".srt":
                        return _util.ReadSrtFile(fileName);
                }
            }
            catch (Exception ex)
            {
                _util.AddLog(logFile, "Loi trong ReadSubFile: " + ex.ToString());
            }

            throw new Exception("File type does not support");
        }
    }
}
