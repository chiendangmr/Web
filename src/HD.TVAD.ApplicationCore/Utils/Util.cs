using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.ApplicationCore.Util
{
    public static class Util
    {
		public static string GetValueToSort(object obj)
		{
			var str = obj == null ? "" : obj.ToString();
			if (str == "")
				str = "!";

			List<string> lstWord = new List<string>();
			while (str.Length > 0)
			{
				var first = str[0];
				var isDigit = first >= '0' && first <= '9';
				int next = 1;
				for (; next < str.Length; ++next)
				{
					var cDigit = str[next] >= '0' && str[next] <= '9';
					if (isDigit != cDigit)
						break;
				}
				lstWord.Add(str.Substring(0, next));
				str = str.Substring(next);
			}
			while (lstWord.Count < 5)
				lstWord.Add("!");

			return string.Join("", lstWord.Select(s =>
			{
				if (s.Length >= 10)
					return s;

				string add = "";
				for (int i = 0; i < 10 - s.Length; ++i)
					add += "!";

				var isDigit = s[0] >= '0' && s[0] <= '9';
				if (!isDigit)
					return s + add;

				return add + s;
			}));
		}
		public static decimal? ToPercent(this decimal? rate)
		{
			var result = rate / 100;

			return result;
		}
		public static decimal ToPercent(this decimal rate)
		{
			var result = rate / 100;

			return result;
		}
		public static decimal? ToDisplayPercent(this decimal? rate)
		{
			var result = rate * 100;

			return result;
		}
		public static decimal ToDisplayPercent(this decimal rate)
		{
			var result = rate * 100;

			return result;
		}
	}
}
