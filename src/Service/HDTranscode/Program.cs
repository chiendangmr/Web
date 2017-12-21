using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HDTranscode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                    throw new Exception("No arguments");
                else
                {
                    List<string> parameters = args.ToList();

                    string input = null;
                    var index = parameters.FindIndex(str => str.ToLower() == "-i");
                    if (index < 0)
                        throw new Exception("No input");
                    if (parameters.Count > index + 1)
                    {
                        input = parameters[index + 1];
                        if (input.StartsWith("-"))
                            input = null;
                    }
                    if (string.IsNullOrWhiteSpace(input))
                        throw new Exception("Input file name invalid");
                    parameters.RemoveRange(index, 2);

                    int frameRateNum = 25;
                    int frameRateDen = 1;
                    index = parameters.FindIndex(str => str.ToLower() == "-framerate" || str.ToLower() == "-fps");
                    if (index >= 0)
                    {
                        string rateStr = "";
                        if (parameters.Count > index + 1)
                            rateStr = parameters[index + 1];
                        if (!HDConvert.FFMpeg.ParseFramerate(rateStr, out frameRateNum, out frameRateDen))
                            throw new Exception("Invalid framerate option");
                        parameters.RemoveRange(index, 2);
                    }

                    long startMilliseconds = 0;
                    long durationMilliseconds = 0;
                    index = parameters.FindIndex(str => str.ToLower() == "-ss");
                    if (index >= 0)
                    {
                        string startStr = "";
                        if (parameters.Count > index + 1)
                            startStr = parameters[index + 1];
                        if (!long.TryParse(startStr, out startMilliseconds))
                            throw new Exception("Invalid start time option");
                        parameters.RemoveRange(index, 2);
                    }
                    index = parameters.FindIndex(str => str.ToLower() == "-t");
                    if (index >= 0)
                    {
                        string durStr = "";
                        if (parameters.Count > index + 1)
                            durStr = parameters[index + 1];
                        if (!long.TryParse(durStr, out durationMilliseconds))
                            throw new Exception("Invalid duration option");
                        parameters.RemoveRange(index, 2);
                    }

                    int minVolume = 0;
                    int maxVolume = 0;
                    index = parameters.FindIndex(str => str.ToLower() == "-minvolume");
                    if (index >= 0)
                    {
                        string volumeStr = "";
                        if (parameters.Count > index + 1)
                            volumeStr = parameters[index + 1];
                        if (!int.TryParse(volumeStr, out minVolume))
                            throw new Exception("Invalid min volume option");
                        parameters.RemoveRange(index, 2);
                    }
                    index = parameters.FindIndex(str => str.ToLower() == "-maxvolume");
                    if (index >= 0)
                    {
                        string volumeStr = "";
                        if (parameters.Count > index + 1)
                            volumeStr = parameters[index + 1];
                        if (!int.TryParse(volumeStr, out maxVolume))
                            throw new Exception("Invalid max volume option");
                        parameters.RemoveRange(index, 2);
                    }

                    List<string> highres1Options = new List<string>();
                    List<string> highres2Options = new List<string>();
                    List<string> lowresOptions = new List<string>();
                    int highres1Index = parameters.FindIndex(str => str.ToLower() == "-highres");
                    int highres2Index = -1;
                    if (highres1Index >= 0)
                        highres2Index = parameters.FindIndex(highres1Index + 1, str => str.ToLower() == "-highres");
                    int lowresIndex = parameters.FindIndex(str => str.ToLower() == "-lowres");
                    if (highres1Index < 0 && lowresIndex < 0)
                        throw new Exception("No output");

                    if (highres1Index >= 0)
                    {
                        int count = parameters.Count - highres1Index;
                        if (highres2Index >= 0 || lowresIndex >= 0)
                        {
                            var nextIndex = highres2Index;
                            if (lowresIndex >= 0 && lowresIndex < nextIndex)
                                nextIndex = lowresIndex;
                            if (nextIndex > highres1Index)
                                count = nextIndex - highres1Index;
                        }
                        highres1Options.AddRange(parameters.Skip(highres1Index).Take(count));
                        parameters.RemoveRange(highres1Index, count);
                    }

                    if (highres2Index >= 0)
                    {
                        highres2Index = parameters.FindIndex(str => str.ToLower() == "-highres");
                        lowresIndex = parameters.FindIndex(str => str.ToLower() == "-lowres");
                        int count = parameters.Count - highres2Index;
                        if (lowresIndex > highres2Index)
                            count = lowresIndex - highres2Index;
                        highres2Options.AddRange(parameters.Skip(highres2Index).Take(count));
                        parameters.RemoveRange(highres2Index, count);
                    }

                    lowresIndex = parameters.FindIndex(str => str.ToLower() == "-lowres");
                    if (lowresIndex >= 0)
                    {
                        int count = parameters.Count - lowresIndex;
                        lowresOptions.AddRange(parameters.Skip(lowresIndex).Take(count));
                        parameters.RemoveRange(lowresIndex, count);
                    }

                    string highres1 = null;
                    int highres1Width = 0;
                    int highres1Height = 0;
                    bool highres1Interlace = false;
                    bool highres1TopFieldFirst = false;
                    int highres1Gop = 12;
                    int highres1BFrames = 2;
                    int highres1CloseGop = 0;
                    bool highres1_420 = false;
                    int highres1Bitrate = 50000000;
                    if (highres1Options.Count > 0)
                    {
                        // File name
                        index = highres1Options.FindIndex(str => str.ToLower() == "-highres");
                        if (highres1Options.Count > index + 1)
                        {
                            highres1 = highres1Options[index + 1];
                            if (highres1.StartsWith("-"))
                                highres1 = null;
                        }
                        if (string.IsNullOrWhiteSpace(highres1))
                            throw new Exception("Invalid highres file name option");
                        highres1Options.RemoveRange(index, 2);
                        // Size
                        index = highres1Options.FindIndex(str => str.ToLower() == "-s");
                        if (index >= 0)
                        {
                            string sizeStr = "";
                            if (highres1Options.Count > index + 1)
                                sizeStr = highres1Options[index + 1];
                            if (!HDConvert.FFMpeg.ParseVideoSize(sizeStr, out highres1Width, out highres1Height) || highres1Width <= 0 || highres1Height <= 0)
                                throw new Exception("Invalid highres option");
                            highres1Options.RemoveRange(index, 2);
                        }
                        // Interlace
                        index = highres1Options.FindIndex(str => str.ToLower() == "-interlace");
                        if (index >= 0)
                        {
                            highres1Interlace = true;
                            highres1Options.RemoveAt(index);
                        }
                        // Top field first
                        index = highres1Options.FindIndex(str => str.ToLower() == "-tff");
                        if (index >= 0)
                        {
                            highres1TopFieldFirst = true;
                            highres1Options.RemoveAt(index);
                        }
                        // Gop length
                        index = highres1Options.FindIndex(str => str.ToLower() == "-g");
                        if (index >= 0)
                        {
                            string gopStr = "";
                            if (highres1Options.Count > index + 1)
                                gopStr = highres1Options[index + 1];
                            if (!int.TryParse(gopStr, out highres1Gop) || highres1Gop < 0)
                                throw new Exception("Invalid highres gop length option");
                            highres1Options.RemoveRange(index, 2);
                        }
                        // Bframes
                        index = highres1Options.FindIndex(str => str.ToLower() == "-bf" || str.ToLower() == "-bframes");
                        if (index >= 0)
                        {
                            string bfStr = "";
                            if (highres1Options.Count > index + 1)
                                bfStr = highres1Options[index + 1];
                            if (!int.TryParse(bfStr, out highres1BFrames) || highres1BFrames < 0)
                                throw new Exception("Invalid highres bframes option");
                            highres1Options.RemoveRange(index, 2);
                        }
                        // Close gop
                        index = highres1Options.FindIndex(str => str.ToLower() == "-cgop");
                        if (index >= 0)
                        {
                            string cgopStr = "";
                            if (highres1Options.Count > index + 1)
                                cgopStr = highres1Options[index + 1];
                            if (!int.TryParse(cgopStr, out highres1CloseGop) || highres1CloseGop < 0)
                                throw new Exception("Invalid highres close gop option");
                            highres1Options.RemoveRange(index, 2);
                        }
                        // Pixel format
                        index = highres1Options.FindIndex(str => str.ToLower() == "-pix_fmt");
                        if (index >= 0)
                        {
                            string pixFmtStr = "";
                            if (highres1Options.Count > index + 1)
                                pixFmtStr = highres1Options[index + 1];
                            if (pixFmtStr == "yuv422p")
                                highres1_420 = false;
                            else if (pixFmtStr == "yuv420p")
                                highres1_420 = true;
                            else
                                throw new Exception("Only support highres output format yuv422p or yuv420p");

                            highres1Options.RemoveRange(index, 2);
                        }
                        // Bitrate
                        index = highres1Options.FindIndex(str => str.ToLower() == "-b" || str.ToLower() == "-b:v");
                        if (index >= 0)
                        {
                            string bStr = "";
                            if (highres1Options.Count > index + 1)
                                bStr = highres1Options[index + 1];
                            bStr = bStr.Replace("k", "0000").Replace("K", "0000").Replace("m", "00000000").Replace("M", "00000000");
                            if (!int.TryParse(bStr, out highres1Bitrate) || highres1Bitrate <= 0)
                                throw new Exception("Invalid highres bitrate option");

                            highres1Options.RemoveRange(index, 2);
                        }
                    }

                    string highres2 = null;
                    int highres2Width = 0;
                    int highres2Height = 0;
                    bool highres2Interlace = false;
                    bool highres2TopFieldFirst = false;
                    int highres2Gop = 12;
                    int highres2BFrames = 2;
                    int highres2CloseGop = 0;
                    bool highres2_420 = false;
                    int highres2Bitrate = 50000000;
                    if (highres2Options.Count > 0)
                    {
                        // File name
                        index = highres2Options.FindIndex(str => str.ToLower() == "-highres");
                        if (highres2Options.Count > index + 1)
                        {
                            highres2 = highres2Options[index + 1];
                            if (highres2.StartsWith("-"))
                                highres2 = null;
                        }
                        if (string.IsNullOrWhiteSpace(highres2))
                            throw new Exception("Invalid highres file name option");
                        highres2Options.RemoveRange(index, 2);
                        // Size
                        index = highres2Options.FindIndex(str => str.ToLower() == "-s");
                        if (index >= 0)
                        {
                            string sizeStr = "";
                            if (highres2Options.Count > index + 1)
                                sizeStr = highres2Options[index + 1];
                            if (!HDConvert.FFMpeg.ParseVideoSize(sizeStr, out highres2Width, out highres2Height) || highres2Width <= 0 || highres2Height <= 0)
                                throw new Exception("Invalid highres option");
                            highres2Options.RemoveRange(index, 2);
                        }
                        // Interlace
                        index = highres2Options.FindIndex(str => str.ToLower() == "-interlace");
                        if (index >= 0)
                        {
                            highres2Interlace = true;
                            highres2Options.RemoveAt(index);
                        }
                        // Top field first
                        index = highres2Options.FindIndex(str => str.ToLower() == "-tff");
                        if (index >= 0)
                        {
                            highres2TopFieldFirst = true;
                            highres2Options.RemoveAt(index);
                        }
                        // Gop length
                        index = highres2Options.FindIndex(str => str.ToLower() == "-g");
                        if (index >= 0)
                        {
                            string gopStr = "";
                            if (highres2Options.Count > index + 1)
                                gopStr = highres2Options[index + 1];
                            if (!int.TryParse(gopStr, out highres2Gop) || highres2Gop < 0)
                                throw new Exception("Invalid highres gop length option");
                            highres2Options.RemoveRange(index, 2);
                        }
                        // Bframes
                        index = highres2Options.FindIndex(str => str.ToLower() == "-bf" || str.ToLower() == "-bframes");
                        if (index >= 0)
                        {
                            string bfStr = "";
                            if (highres2Options.Count > index + 1)
                                bfStr = highres2Options[index + 1];
                            if (!int.TryParse(bfStr, out highres2BFrames) || highres2BFrames < 0)
                                throw new Exception("Invalid highres bframes option");
                            highres2Options.RemoveRange(index, 2);
                        }
                        // Close gop
                        index = highres2Options.FindIndex(str => str.ToLower() == "-cgop");
                        if (index >= 0)
                        {
                            string cgopStr = "";
                            if (highres2Options.Count > index + 1)
                                cgopStr = highres2Options[index + 1];
                            if (!int.TryParse(cgopStr, out highres2CloseGop) || highres2CloseGop < 0)
                                throw new Exception("Invalid highres close gop option");
                            highres2Options.RemoveRange(index, 2);
                        }
                        // Pixel format
                        index = highres2Options.FindIndex(str => str.ToLower() == "-pix_fmt");
                        if (index >= 0)
                        {
                            string pixFmtStr = "";
                            if (highres2Options.Count > index + 1)
                                pixFmtStr = highres2Options[index + 1];
                            if (pixFmtStr == "yuv422p")
                                highres2_420 = false;
                            else if (pixFmtStr == "yuv420p")
                                highres2_420 = true;
                            else
                                throw new Exception("Only support highres output format yuv422p or yuv420p");

                            highres2Options.RemoveRange(index, 2);
                        }
                        // Bitrate
                        index = highres2Options.FindIndex(str => str.ToLower() == "-b" || str.ToLower() == "-b:v");
                        if (index >= 0)
                        {
                            string bStr = "";
                            if (highres2Options.Count > index + 1)
                                bStr = highres2Options[index + 1];
                            bStr = bStr.Replace("k", "0000").Replace("K", "0000").Replace("m", "00000000").Replace("M", "00000000");
                            if (!int.TryParse(bStr, out highres2Bitrate) || highres2Bitrate <= 0)
                                throw new Exception("Invalid highres bitrate option");

                            highres2Options.RemoveRange(index, 2);
                        }
                    }

                    string lowres = null;
                    int lowresWidth = 0;
                    int lowresHeight = 0;
                    string lowresFilter = null;
                    int lowresBitrate = 500000;
                    int lowresGop = 150;
                    int lowresBFrames = 2;
                    if (lowresOptions.Count > 0)
                    {
                        // File name
                        index = lowresOptions.FindIndex(str => str.ToLower() == "-lowres");
                        if (lowresOptions.Count > index + 1)
                        {
                            lowres = lowresOptions[index + 1];
                            if (lowres.StartsWith("-"))
                                lowres = null;
                        }
                        if (string.IsNullOrWhiteSpace(lowres))
                            throw new Exception("Invalid lowres file name option");
                        lowresOptions.RemoveRange(index, 2);
                        // Size
                        index = lowresOptions.FindIndex(str => str.ToLower() == "-s");
                        if (index >= 0)
                        {
                            string sizeStr = "";
                            if (lowresOptions.Count > index + 1)
                                sizeStr = lowresOptions[index + 1];
                            if (!HDConvert.FFMpeg.ParseVideoSize(sizeStr, out lowresWidth, out lowresHeight) || (lowresWidth < 0 && lowresWidth != -1) || (lowresHeight < 0 && lowresHeight != -1))
                            {
                                var nums = sizeStr.Split(new char[] { 'x', ':' });
                                if (nums.Length == 2)
                                {
                                    int.TryParse(nums[0], out lowresWidth);
                                    int.TryParse(nums[1], out lowresHeight);
                                }
                                if ((lowresWidth < 0 && lowresWidth != -1) || (lowresHeight < 0 && lowresHeight != -1))
                                    throw new Exception("Invalid lowres size option");
                            }
                            lowresOptions.RemoveRange(index, 2);
                        }
                        // Filter
                        index = lowresOptions.FindIndex(str => str.ToLower() == "-vf");
                        if (index >= 0)
                        {
                            if (lowresOptions.Count > index + 1)
                            {
                                lowresFilter = lowresOptions[index + 1];
                                if (lowresFilter.StartsWith("-i"))
                                    lowresFilter = "";
                            }
                            if (string.IsNullOrWhiteSpace(lowresFilter))
                                throw new Exception("Invalid lowres video filter option");

                            lowresOptions.RemoveRange(index, 2);
                        }
                        // Bitrate
                        index = lowresOptions.FindIndex(str => str.ToLower() == "-b" || str.ToLower() == "-b:v");
                        if (index >= 0)
                        {
                            string bStr = "";
                            if (lowresOptions.Count > index + 1)
                                bStr = lowresOptions[index + 1];
                            bStr = bStr.Replace("k", "0000").Replace("K", "0000").Replace("m", "00000000").Replace("M", "00000000");
                            if (!int.TryParse(bStr, out lowresBitrate) || lowresBitrate <= 0)
                                throw new Exception("Invalid lowres bitrate option");

                            lowresOptions.RemoveRange(index, 2);
                        }
                        // Gop length
                        index = lowresOptions.FindIndex(str => str.ToLower() == "-g");
                        if (index >= 0)
                        {
                            string gopStr = "";
                            if (lowresOptions.Count > index + 1)
                                gopStr = lowresOptions[index + 1];
                            if (!int.TryParse(gopStr, out lowresGop) || lowresGop < 0)
                                throw new Exception("Invalid lowres gop length option");
                            lowresOptions.RemoveRange(index, 2);
                        }
                        // Bframes
                        index = lowresOptions.FindIndex(str => str.ToLower() == "-bf" || str.ToLower() == "-bframes");
                        if (index >= 0)
                        {
                            string bfStr = "";
                            if (lowresOptions.Count > index + 1)
                                bfStr = lowresOptions[index + 1];
                            if (!int.TryParse(bfStr, out lowresBFrames) || lowresBFrames < 0)
                                throw new Exception("Invalid lowres bframes option");
                            lowresOptions.RemoveRange(index, 2);
                        }
                    }

                    parameters.AddRange(highres1Options);
                    parameters.AddRange(highres2Options);
                    parameters.AddRange(lowresOptions);
                    if (parameters.Count > 0)
                    {
                        foreach (var param in parameters)
                            Console.Out.WriteLine($"Unknow option {param}");
                    }

                    HDConvert.FFMpeg.OnLog += new EventHandler<HDConvert.FFMpegLogArgs>((o, e) =>
                      {
                          if (!string.IsNullOrWhiteSpace(e.Message))
                          {
                              if (e.Message.Contains("[error]"))
                                  Console.Error.WriteLine(e.Message);
                              else
                                  Console.Out.WriteLine(e.Message);
                          }
                      });

                    Stopwatch processTimer = new Stopwatch();
                    processTimer.Start();
                    uint lastFrames = 0;
                    HDConvert.FFMpeg.OnTranscodeProgress += new EventHandler<HDConvert.TranscodeProgressArgs>((o, e) =>
                      {
                          if (processTimer.ElapsedMilliseconds >= 1000)
                          {
                              var totalFrames = e.CurrentFrames - lastFrames;
                              var fps = (double)totalFrames * 1000.0 / processTimer.ElapsedMilliseconds;
                              var speed = fps * frameRateDen / frameRateNum;

                              Console.Out.Write($"\rframe={e.CurrentFrames}/{e.TotalFrames} fps={fps.ToString("0.##")} speed={speed.ToString("0.##")}x\t\t\t");

                              lastFrames = e.CurrentFrames;
                              processTimer.Restart();
                          }
                      });

                    Console.Out.WriteLine($"Start convert \"{input}\" from {startMilliseconds}ms, duration {durationMilliseconds}ms");

                    var result = HDConvert.FFMpeg.Convert(input,
                        frameRateNum, frameRateDen, minVolume, maxVolume, startMilliseconds, durationMilliseconds,
                        !string.IsNullOrWhiteSpace(highres1), highres1, highres1Width, highres1Height, highres1Interlace, highres1TopFieldFirst, highres1Gop, highres1BFrames + 1, highres1CloseGop, highres1_420, highres1Bitrate,
                        !string.IsNullOrWhiteSpace(lowres), lowres, lowresWidth, lowresHeight, lowresFilter, lowresBitrate, lowresGop, lowresBFrames + 1,
                        !string.IsNullOrWhiteSpace(highres2), highres2, highres2Gop, highres2BFrames + 1, highres2CloseGop, highres2_420, highres2Bitrate);
                    if (!result)
                        throw new Exception("Transcode failed");
                    Console.Out.WriteLine("Completed");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[error] {ex.Message}");
            }
        }
    }
}
