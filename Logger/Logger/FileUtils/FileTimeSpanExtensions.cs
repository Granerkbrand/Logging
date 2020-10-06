using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logging.Logger.FileUtils
{
    public static class FileTimeSpanExtensions
    {

        public static string GetDateTimeString(this FileTimeSpan fileTimeSpan)
        {
            var date = DateTime.Now;

            return fileTimeSpan switch
            {
                FileTimeSpan.DAY => date.ToString("dd"),
                FileTimeSpan.WEEK => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString(),
                FileTimeSpan.MONTH => date.ToString("MM"),
                FileTimeSpan.YEAR => date.ToString("yyyy"),
                FileTimeSpan.INFINITY => "",
                _ => "",
            };
        }

    }
}
