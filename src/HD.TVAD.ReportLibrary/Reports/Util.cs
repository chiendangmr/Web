using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public static class Util
	{
		public static Bitmap MakeWatermark() {

			Bitmap bmp = new Bitmap(536, 658);
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			g.DrawString("PHÒNG KINH DOANH QUẢNG CÁO", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(49, 0));

			g.DrawString("NGƯỜI LÀM LIST", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(57, 160));
			g.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), new Font("Times New Roman", 12), Brushes.Black, new PointF(70, 180));
			g.DrawString(DateTime.Now.ToString("hh:mm tt"), new Font("Times New Roman", 12), Brushes.Black, new PointF(70, 200));

			g.DrawString("KỸ THUẬT", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(57, 350));

			g.DrawString("NGƯỜI OTK", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(57, 540));
			g.Dispose();

			return bmp;
		}

		public static Bitmap MakeWatermarkForSimplySpotSchedule()
		{

			Bitmap bmp = new Bitmap(536, 658);
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			g.DrawString("NGƯỜI LÀM LIST", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(57, 60));
			g.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), new Font("Times New Roman", 12), Brushes.Black, new PointF(70, 80));
			g.DrawString(DateTime.Now.ToString("hh:mm tt"), new Font("Times New Roman", 12), Brushes.Black, new PointF(70, 100));

			g.DrawString("KỸ THUẬT", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(57, 300));

			g.DrawString("NGƯỜI OTK", new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new PointF(57, 540));
			g.Dispose();

			return bmp;
		}
		public static string GetTextDate(DateTime date)
		{
			var dayOfWeek = date.DayOfWeek;
			var dayOfWeekText = "";
			switch (dayOfWeek)
			{
				case DayOfWeek.Sunday:
					dayOfWeekText = "CHỦ NHẬT";
					break;
				case DayOfWeek.Monday:
					dayOfWeekText = "THỨ HAI";
					break;
				case DayOfWeek.Tuesday:
					dayOfWeekText = "THỨ BA";
					break;
				case DayOfWeek.Wednesday:
					dayOfWeekText = "THỨ TƯ";
					break;
				case DayOfWeek.Thursday:
					dayOfWeekText = "THỨ NĂM";
					break;
				case DayOfWeek.Friday:
					dayOfWeekText = "THỨ SÁU";
					break;
				case DayOfWeek.Saturday:
					dayOfWeekText = "THỨ BẢY";
					break;
				default:
					break;
			}
			var dateText = date.ToString("dd/MM/yyyy");
			return dayOfWeekText + " " + dateText;
		}
	}
}
