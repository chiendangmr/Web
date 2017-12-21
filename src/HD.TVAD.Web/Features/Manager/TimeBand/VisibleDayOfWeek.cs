using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBands
{
	[Flags]
	public enum VisibleDayOfWeek
	{
		None = 0,
		Mon = 1,
		Tue = 2,
		Wed = 4,
		Thu = 8,
		Fri = 16,
		Sat = 32,
		Sun = 64
	}
}
