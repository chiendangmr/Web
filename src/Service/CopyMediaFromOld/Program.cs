using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;
using FluentFTP;
using MediaInfoDotNet;

namespace CopyMediaFromOld
{
    class Program
    {
        static string GetHex(long x, int length)
        {
            return x.ToString("x").PadLeft(length, '0').Substring(0, length);
        }

        static void Main(string[] args)
        {
            using (StreamWriter log = new StreamWriter(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Log.txt"), true, Encoding.UTF8))
            {
                try
                {
                    using (var db = new SqlConnection(AppSettings.Default.SqlConnectionString))
                    using (var ftp = new FtpClient(AppSettings.Default.FTPSourceIP, AppSettings.Default.FTPSourcePort, AppSettings.Default.FTPSourceUserName, AppSettings.Default.FTPSourcePassWord))
                    {
                        long lastIDClip = 0;
                        var invalidFileNameChars = Path.GetInvalidFileNameChars();

                        while (true)
                        {
                            try
                            {
                                var clip = db.Query<DAO.tblClip>(@"Select top 1 tblBang.MaBang,
	                                tblClips.IDClip,
	                                tblClips.RealTCIn,
	                                tblClips.RealTCOut,
                                    tblClips.TCIn,
                                    tblClips.TCOut,
                                    tblClips.HasDownLoad,
	                                tblClips.RecordDate
                                From tblBang
                                Inner Join tblClips On tblBang.IDClip = tblClips.IDClip
                                Where tblClips.IDClip > @LastID
                                    And (tblBang.KetQuaDuyet = 1 or tblBang.KetQuaDuyet = 3)
	                                And (tblClips.HasDownLoad = 0 Or tblClips.HasTimecode = 0)",
                                new { LastID = lastIDClip }).FirstOrDefault();
                                if (clip == null)
                                {
                                    lastIDClip = 0;
                                    Console.WriteLine("Sleep");
                                    Thread.Sleep(3600000);
                                }
                                else
                                {
                                    lastIDClip = clip.IDClip;
                                    if (!clip.HasDownLoad)
                                    {
                                        try
                                        {
                                            Console.WriteLine();
                                            string mess = $"Cần copy media của băng {clip.MaBang} - clip {clip.IDClip}";
                                            Console.WriteLine(mess);
                                            log.WriteLine(mess);
                                            Console.WriteLine("Kiểm tra file trên ftp server");
                                            // Check FTP connect
                                            if (!ftp.IsConnected)
                                                ftp.Connect();
                                            if (!ftp.IsConnected)
                                                throw new Exception("Mất kết nối tới ftp server");
                                            // Check source file
                                            string fileNameOnServer = GetHex(clip.IDClip, 8) + ".mxf";
                                            if (!ftp.FileExists(fileNameOnServer))
                                            {
                                                db.Execute("Update tblClips Set HasDownload = 1 Where IDClip = @IDClip", new { IDClip = clip.IDClip });
                                                throw new Exception("Không có file trên server");
                                            }
                                            // Get dest file name
                                            string fileNameOnNas = string.Join("", clip.MaBang.Select(c => invalidFileNameChars.Contains(c) ? "?" : c.ToString()))
                                                + "_" + GetHex(clip.IDClip, 8)
                                                + "_" + clip.RealTCIn.Replace(':', '.')
                                                + "_" + clip.RealTCOut.Replace(':', '.')
                                                + "_" + clip.TCIn.Replace(':', '.')
                                                + "_" + clip.TCOut.Replace(':', '.')
                                                + ".mxf";
                                            string destFilePath = Path.Combine(AppSettings.Default.DestDirectory, fileNameOnNas);
                                            // Delete if exists
                                            if (File.Exists(destFilePath))
                                                File.Delete(destFilePath);
                                            Console.WriteLine("Bắt đầu download:");
                                            // Copy
                                            try
                                            {
                                                if (!ftp.DownloadFile(destFilePath, fileNameOnServer, true, FtpVerify.None, new ProcessLog()))
                                                {
                                                    throw new Exception("Không download được");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                bool error = true;
                                                if (File.Exists(destFilePath))
                                                {
                                                    var mediaInfo = new MediaFile(destFilePath);
                                                    if (mediaInfo.Video.Count > 0 && mediaInfo.Video[0].Duration > 0)
                                                        error = false;
                                                    else
                                                    {
                                                        try
                                                        {
                                                            File.Delete(destFilePath);
                                                        }
                                                        catch { }
                                                    }
                                                }

                                                if (error)
                                                {
                                                    Console.WriteLine();
                                                    throw ex;
                                                }
                                            }
                                            Console.WriteLine();
                                            var sourceSize = ftp.GetFileSize(fileNameOnServer);
                                            var destSize = new FileInfo(destFilePath).Length;
                                            if ((float)Math.Abs(sourceSize - destSize) * 100.0f / sourceSize > AppSettings.Default.MaxErrorSizePer)
                                                throw new Exception($"Download sai kích thước: Nguồn {sourceSize} - Đích {destSize}");

                                            Console.WriteLine("Download thành công");
                                            db.Execute("Update tblClips Set HasDownload = 1, HasTimecode = 1 Where IDClip = @IDClip", new { IDClip = clip.IDClip });
                                            Console.WriteLine("Thành công");
                                            log.WriteLine("Thành công");
                                        }
                                        catch (Exception ex)
                                        {
                                            string mess = $"Copy media của băng {clip.MaBang} lỗi: {ex.Message}";
                                            Console.WriteLine(mess);
                                            log.WriteLine(mess);
                                            Thread.Sleep(1000);
                                        }
                                    }
                                    else
                                    {
                                        // Get dest file name
                                        string fileNameOnNasOld = string.Join("", clip.MaBang.Select(c => invalidFileNameChars.Contains(c) ? "?" : c.ToString()))
                                            + "_" + GetHex(clip.IDClip, 8)
                                            + "_" + clip.RealTCIn.Replace(':', '.')
                                            + "_" + clip.RealTCOut.Replace(':', '.');
                                        string destFilePathOld = Path.Combine(AppSettings.Default.DestDirectory, fileNameOnNasOld + ".mxf");
                                        if (File.Exists(destFilePathOld))
                                        {
                                            string fileNameOnNas = fileNameOnNasOld
                                                + "_" + clip.TCIn.Replace(':', '.')
                                                + "_" + clip.TCOut.Replace(':', '.');
                                            string destFilePath = Path.Combine(AppSettings.Default.DestDirectory, fileNameOnNas + ".mxf");
                                            if (File.Exists(destFilePath))
                                                File.Delete(destFilePath);
                                            File.Move(destFilePathOld, destFilePath);
                                        }

                                        db.Execute(@"Update tblClips Set HasTimecode = 1 Where IDClip = @IDClip", new { IDClip = clip.IDClip });
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                string error = string.Format("[Error] {0}", ex.Message);
                                Console.WriteLine(error);
                                log.WriteLine(error);

                                Thread.Sleep(5000);
                            }
                        }
                    }
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
    }

    class ProcessLog : IProgress<double>
    {
        public void Report(double value)
        {
            Console.Write($"\r Dang download:{value.ToString("000.00")}%");
        }
    }
}
