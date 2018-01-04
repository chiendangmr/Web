using HD.Web.Delay.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HD.Web.Delay.Business
{
    public class Util
    {
        public string GetTimeNow()
        {
            return DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
        }
        public void AddLog(string path, string content)
        {
            try
            {
                using (StreamWriter file =
                new StreamWriter(File.Create(path)))
                {
                    file.WriteLine(" -\n - " + GetTimeNow() + ":" + content + "\n");
                }
            }
            catch
            {

            }
        }
        public DateTime FromMS(double miliTime)
        {
            DateTime startTime = new DateTime(1970, 1, 1);

            TimeSpan time = TimeSpan.FromMilliseconds(miliTime);
            return startTime.Add(time);
        }
        public string GetNumber(string str)
        {
            var number = Regex.Match(str, @"\d+").Value;

            return number;
        }
        public Dictionary<string, string> GetPlayingTime(string videoFileName)
        {
            var tempDic = new Dictionary<string, string>();
            tempDic.Add("year", videoFileName.Substring(0, 4));
            tempDic.Add("month", videoFileName.Substring(4, 2));
            tempDic.Add("day", videoFileName.Substring(6, 2));
            tempDic.Add("hour", videoFileName.Substring(9, 2));
            tempDic.Add("min", videoFileName.Substring(11, 2));
            tempDic.Add("sec", videoFileName.Substring(13, 2));
            return tempDic;
        }
        #region Subtitle        

        public List<SubtitleFileItem> ReadCipFile(string fileName)
        {            
            var finalResult = new List<SubtitleFileItem>();
            return finalResult;
        }

        public List<SubtitleFileItem> ReadSrtFile(string fileName)
        {
            using (StreamReader file = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                string data = file.ReadToEnd();

                string htmlTagPattern = @"<.*?>";

                data = Regex.Replace(data, htmlTagPattern, string.Empty);
                data = data.Replace("\r\n", "\n").Replace("\n", "\r\n");

                Regex unit = new Regex(
                   @"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> " +
                   @"(?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?\r\n\r\n)",
                   RegexOptions.Compiled | RegexOptions.ECMAScript);
                var matchSubs = unit.Match(data);

                if (matchSubs.Success)
                {
                    List<SubtitleFileItem> lstItems = new List<SubtitleFileItem>();
                    while (matchSubs.Success)
                    {
                        var text = matchSubs.Groups["text"].Value.Trim();

                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            var start = TimeSpan.ParseExact(matchSubs.Groups["start"].Value, @"hh\:mm\:ss\,fff", null);
                            var end = TimeSpan.ParseExact(matchSubs.Groups["end"].Value, @"hh\:mm\:ss\,fff", null);

                            if (end > start)
                            {
                                lstItems.Add(new SubtitleFileItem()
                                {
                                    StartTime = (long)start.TotalMilliseconds,
                                    Duration = (int)(end - start).TotalMilliseconds,
                                    Position = 0,
                                    Text = text,
                                    Align = 0
                                });
                            }
                        }

                        matchSubs = matchSubs.NextMatch();
                    }

                    return lstItems;
                }
            }
            return null;
        }
        #endregion
    }
}
