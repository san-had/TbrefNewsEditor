using System;

namespace ScriptGenerator.Extensibility
{
    public interface IDateTimeNowProvider
    {
        DateTime Now { get; }
    }
}