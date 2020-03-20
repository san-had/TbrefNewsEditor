using System.Globalization;
using ScriptGenerator.Extensibility;

namespace ScriptGenerator.Service
{
    public class WeekRangeCalculator : IWeekRangeCalculator
    {
        private readonly IDateTimeNowProvider dateTimeNowProvider;

        public WeekRangeCalculator(IDateTimeNowProvider dateTimeNowProvider)
        {
            this.dateTimeNowProvider = dateTimeNowProvider;
        }

        public string CalculateWeekRange()
        {
            string weekRange = string.Empty;
            var nextMonday = dateTimeNowProvider.Now.AddDays(1);
            var nextSunday = dateTimeNowProvider.Now.AddDays(7);
            var nextMondayMonth = nextMonday.Month;
            var nextSundayMonth = nextSunday.Month;

            var cultureInfo = new CultureInfo("hu-HU");
            if (nextMondayMonth == nextSundayMonth)
            {
                string monthName = nextMonday.ToString("MMMM", cultureInfo);
                weekRange = $"{monthName} {nextMonday.Day} - {nextSunday.Day}";
            }
            else
            {
                string nextMondayMonthName = nextMonday.ToString("MMMM", cultureInfo);
                string nextSundayMonthName = nextSunday.ToString("MMMM", cultureInfo); ;
                weekRange = $"{nextMondayMonthName} {nextMonday.Day} - {nextSundayMonthName} {nextSunday.Day}";
            }
            return weekRange;
        }
    }
}