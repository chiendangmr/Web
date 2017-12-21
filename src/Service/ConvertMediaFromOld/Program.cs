using MediaInfoDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace ConvertMediaFromOld
{
    class Program
    {
        static string GetHex(long x, int length)
        {
            return x.ToString("x").PadLeft(length, '0').Substring(0, length);
        }

        static long GetLong(string hex)
        {
            return long.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }

        static void Main(string[] args)
        {
            using (StreamWriter log = new StreamWriter(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Log.txt"), true, Encoding.UTF8))
            {
                try
                {
                    HDConvert.FFMpeg.OnLog += new EventHandler<HDConvert.FFMpegLogArgs>((o, e) =>
                      {
                          if (!string.IsNullOrWhiteSpace(e.Message))
                          {
                              log.WriteLine(e.Message);
                              Console.WriteLine(e.Message);
                          }
                      });

                    Stopwatch processTimer = new Stopwatch();
                    processTimer.Start();
                    uint lastFrames = 0;
                    string currentMaBang = "";
                    HDConvert.FFMpeg.OnTranscodeProgress += new EventHandler<HDConvert.TranscodeProgressArgs>((o, e) =>
                      {
                          if (processTimer.ElapsedMilliseconds >= 1000)
                          {
                              var totalFrames = e.CurrentFrames - lastFrames;
                              var fps = (double)totalFrames * 1000.0 / processTimer.ElapsedMilliseconds;
                              var speed = fps / 25.0;

                              Console.Out.Write($"\r{currentMaBang} frame={e.CurrentFrames}/{e.TotalFrames} fps={fps.ToString("0.##")} speed={speed.ToString("0.##")}x\t\t\t");

                              lastFrames = e.CurrentFrames;
                              processTimer.Restart();
                          }
                      });

                    // Get source files
                    var sources = Directory.GetFiles(AppSettings.Default.SourceDirectory, "*.mxf");
                    foreach (var source in sources)
                    {
                        try
                        {
                            string sourceFileName = Path.GetFileNameWithoutExtension(source);

                            string maBang = sourceFileName.Substring(0, sourceFileName.IndexOf('_'));
                            sourceFileName = sourceFileName.Substring(maBang.Length + 1);

                            string clipIDHex = sourceFileName.Substring(0, sourceFileName.IndexOf('_'));
                            sourceFileName = sourceFileName.Substring(clipIDHex.Length + 1);

                            string realTcInStr = sourceFileName.Substring(0, sourceFileName.IndexOf('_'));
                            sourceFileName = sourceFileName.Substring(realTcInStr.Length + 1);

                            string realTcOutStr = sourceFileName.Substring(0, sourceFileName.IndexOf('_'));
                            sourceFileName = sourceFileName.Substring(realTcOutStr.Length + 1);

                            string tcInStr = sourceFileName.Substring(0, sourceFileName.IndexOf('_'));
                            sourceFileName = sourceFileName.Substring(tcInStr.Length + 1);

                            string tcOutStr = sourceFileName;

                            realTcInStr = realTcInStr.Replace('.', ':');
                            realTcOutStr = realTcOutStr.Replace('.', ':');
                            tcInStr = tcInStr.Replace('.', ':');
                            tcOutStr = tcOutStr.Replace('.', ':');

                            var info = new FileInfo(source);
                            var destFile = maBang
                                + "_" + clipIDHex
                                + "_" + realTcInStr.Replace(':', '.')
                                + "_" + realTcOutStr.Replace(':', '.')
                                + "_" + info.LastWriteTime.ToString("ddMMHHmmss");
                            if (tcInStr != realTcInStr || tcOutStr != realTcOutStr)
                            {
                                destFile += "_" + tcInStr.Replace(':', '.')
                                    + "_" + tcOutStr.Replace(':', '.');
                            }
                            string dest422 = Path.Combine(AppSettings.Default.Out422Directory, destFile + "_422.mxf");
                            string dest420 = Path.Combine(AppSettings.Default.Out420Directory, destFile + "_420.mxf");
                            string destLowres = Path.Combine(AppSettings.Default.LowresDirectory, destFile + "_Lowres.mp4");
                            if (!File.Exists(dest422) || !File.Exists(dest420))
                            {
                                string d422Tmp = Path.Combine(AppSettings.Default.Out422Directory, "tmp422.mxf");
                                string d420Tmp = Path.Combine(AppSettings.Default.Out420Directory, "tmp420.mxf");
                                string lowTmp = Path.Combine(AppSettings.Default.LowresDirectory, "tmpLow.mp4");
                                if (File.Exists(d422Tmp))
                                    File.Delete(d422Tmp);
                                if (File.Exists(d420Tmp))
                                    File.Delete(d420Tmp);
                                if (File.Exists(lowTmp))
                                    File.Delete(lowTmp);

                                long startMilliseconds = 0;
                                long durationMilliseconds = 0;
                                if (tcInStr != realTcInStr || tcOutStr != realTcOutStr)
                                {
                                    TimeSpan realTcInTime = TimeSpan.ParseExact(realTcInStr, @"hh\:mm\:ss\:ff", null);
                                    realTcInTime += TimeSpan.FromMilliseconds(realTcInTime.Milliseconds * 3);
                                    if (tcInStr != realTcInStr)
                                    {
                                        TimeSpan tcInTime = TimeSpan.ParseExact(tcInStr, @"hh\:mm\:ss\:ff", null);
                                        tcInTime += TimeSpan.FromMilliseconds(tcInTime.Milliseconds * 3);

                                        startMilliseconds = (long)(tcInTime - realTcInTime).TotalMilliseconds;
                                    }
                                    if (tcOutStr != realTcOutStr)
                                    {
                                        TimeSpan tcOutTime = TimeSpan.ParseExact(tcOutStr, @"hh\:mm\:ss\:ff", null);
                                        tcOutTime += TimeSpan.FromMilliseconds(tcOutTime.Milliseconds * 3);

                                        var endMilliseconds = (long)Math.Ceiling((tcOutTime - realTcInTime).TotalMilliseconds);
                                        durationMilliseconds = endMilliseconds + 40 - startMilliseconds;
                                    }
                                }

                                log.WriteLine("Start convert file \"" + source + "\"");
                                currentMaBang = maBang;
                                if (HDConvert.FFMpeg.Convert(source, 25, 1, AppSettings.Default.MinVolume, AppSettings.Default.MaxVolume, startMilliseconds, durationMilliseconds,
                                    true, d422Tmp, 1920, 1080, true, true, 12, 3, 1, false, 50000000,
                                    true, lowTmp, 704, 396, @"drawtext=fontsize=15:fontfile=consola.ttf:timecode='00\:00\:00\:00':rate=25:text='TC\:':fontcolor='white':borderw=1:bordercolor='black':x=(w-text_w)/2:y=10", 500000, 50, 3,
                                    true, d420Tmp, 12, 3, 1, true, 35000000))
                                {
                                    Console.WriteLine("Check dest file");
                                    var infoSource = new MediaFile(source);
                                    var sourceDur = durationMilliseconds == 0 ? infoSource.Video[0].Duration : durationMilliseconds;

                                    var infoDest422 = new MediaFile(d422Tmp);
                                    if (infoDest422 == null || infoDest422.Video.Count == 0 || Math.Abs(sourceDur - infoDest422.Video[0].Duration) > 1000)
                                        throw new Exception($"File output 422 lỗi: Video count: {infoDest422.Video.Count} - SourceDur: {sourceDur} - DestDur: {infoDest422.Video[0].Duration}");

                                    var infoDest420 = new MediaFile(d420Tmp);
                                    if (infoDest420 == null || infoDest420.Video.Count == 0 || Math.Abs(sourceDur - infoDest420.Video[0].Duration) > 1000)
                                        throw new Exception("File output 420 lỗi");

                                    var infoLow = new MediaFile(lowTmp);
                                    if (infoLow == null || infoLow.Video.Count == 0 || Math.Abs(sourceDur - infoLow.Video[0].Duration) > 1000)
                                    {
                                        log.WriteLine("File output lowres lỗi");
                                        Console.WriteLine("File output lowres lỗi");
                                        File.Delete(lowTmp);
                                    }

                                    Console.WriteLine("Rename");

                                    if (File.Exists(dest422))
                                        File.Delete(dest422);
                                    if (File.Exists(dest420))
                                        File.Delete(dest420);
                                    if (File.Exists(destLowres))
                                        File.Delete(destLowres);

                                    File.Move(d422Tmp, dest422);
                                    File.Move(d420Tmp, dest420);
                                    if (File.Exists(lowTmp))
                                        File.Move(lowTmp, destLowres);

                                    log.WriteLine("Completed!");
                                    Console.WriteLine("Completed!");
                                }
                                else
                                {
                                    log.WriteLine("Transcode error");
                                    Console.WriteLine("Transcode error");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.WriteLine($"Lỗi: {ex.Message}");
                            Console.WriteLine($"Lỗi: {ex.Message}");
                        }
                    }

                    Thread.Sleep(300000);
                }
                catch (Exception ex)
                {
                    string error = string.Format("[Error] {0}", ex.Message);
                    Console.WriteLine(error);
                    log.WriteLine(error);
                }
                finally
                {
                    log.Flush();
                    log.Close();
                }
            }
        }

        private static void FFMpeg_OnTranscodeProgress(object sender, HDConvert.TranscodeProgressArgs e)
        {
            Console.Write("\rTranscoding: {0}%\t\t", (double)e.CurrentFrames * 100.0 / (double)e.TotalFrames);
        }

        private static void FFMpeg_OnLog(object sender, HDConvert.FFMpegLogArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
