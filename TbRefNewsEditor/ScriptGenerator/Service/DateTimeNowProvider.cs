using System;
using ScriptGenerator.Extensibility;

namespace ScriptGenerator.Service
{
    public class DateTimeNowProvider : IDateTimeNowProvider
    {
        public DateTime Now => DateTime.Now;
    }
}