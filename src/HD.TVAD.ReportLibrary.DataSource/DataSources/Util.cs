using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.ReportLibrary.DataSource
{
    public static class Util
    {
		public static string SplitLetter(string timBandName)
		{
			var result = "";
			foreach (var charter in timBandName)
			{
				if (IsEnglishLetter(charter))
					result += charter;
				else
					break;
			}
			return result;
		}
		public static bool IsEnglishLetter(char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}
		public static decimal SplitNumber(string timBandName) // BUG : 1.1.1.1.2....
		{
			try
			{
				var digitText = "";
				foreach (var charter in timBandName)
				{
					if (!IsEnglishLetter(charter))
						digitText += charter;
				}
				var digit = Decimal.Parse(digitText);
				return digit;

			}
			catch (Exception)
			{
				return 0;
			}
		}
		public static int ToInt(string timBandSliceName)
		{
			try
			{
				var digit = Int32.Parse(timBandSliceName);
				return digit;
			}
			catch (Exception)
			{
				return 0;
			}
		}

	}
}
