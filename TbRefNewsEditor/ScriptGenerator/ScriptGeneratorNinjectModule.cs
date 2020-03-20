using Ninject.Modules;
using ScriptGenerator.Extensibility;
using ScriptGenerator.Service;

namespace ScriptGenerator
{
    public class ScriptGeneratorNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITemplateRetriever>().To<TemplateRetriever>();
            Bind<IScriptGenerator>().To<Service.ScriptGenerator>();
            Bind<IDateTimeNowProvider>().To<DateTimeNowProvider>();
            Bind<IWeekRangeCalculator>().To<WeekRangeCalculator>();
        }
    }
}