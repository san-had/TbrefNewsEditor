using System;
using ScriptGenerator.Extensibility;

namespace ScriptGenerator.Service
{
    public class WeekRangeCalculator : IWeekRangeCalculator
    {
        public string CalculateWeekRange()
        {
            string weekRange = string.Empty;
            var nextMonday = DateTime.Now.AddDays(1);
            var nextSunday = DateTime.Now.AddDays(7);
            var nextMondayMonth = nextMonday.Month;
            var nextSundayMonth = nextSunday.Month;

            if (nextMondayMonth == nextSundayMonth)
            {
                string monthName = "március";
                weekRange = $"{monthName} {nextMonday.Day} - {nextSunday.Day}";
            }
            else
            {
                string nextMondayMonthName = "március";
                string nextSundayMonthName = "április";
                weekRange = $"{nextMondayMonthName} {nextMonday.Day} - {nextSundayMonthName} {nextSunday.Day}";
            }
            return weekRange;
        }
    }
}