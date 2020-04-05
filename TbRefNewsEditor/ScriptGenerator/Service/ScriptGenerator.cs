using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptGenerator.Dto;
using ScriptGenerator.Extensibility;

namespace ScriptGenerator.Service
{
    public class ScriptGenerator : IScriptGenerator
    {
        private const string oddRowStyle = "background-color:#F6F6F6";

        private readonly ITemplateRetriever templateRetriever;
        private readonly IWeekRangeCalculator weekRangeCalculator;

        public ScriptGenerator(ITemplateRetriever templateRetriever, IWeekRangeCalculator weekRangeCalculator)
        {
            this.templateRetriever = templateRetriever;
            this.weekRangeCalculator = weekRangeCalculator;
        }

        public ScriptDto ScriptGeneration(InputDto inputDto)
        {
            var templateDto = templateRetriever.ReadingTemplates();

            var scriptDto = new ScriptDto();

            scriptDto.WeekRange = weekRangeCalculator.CalculateWeekRange();

            //scriptDto.EventsScript = GenerateEvents(inputDto, templateDto);

            scriptDto.NewsScript = GenerateNews(inputDto, templateDto);

            scriptDto.MainScript = GenerateMain(inputDto, templateDto, scriptDto);

            return scriptDto;
        }

        private string GenerateEvents(InputDto inputDto, TemplateDto templateDto)
        {
            var eventsList = PopulateEventList(inputDto.Events);

            StringBuilder eventsRowBuilder = new StringBuilder();

            for (int i = 0; i < eventsList.Count; i++)
            {
                string style = string.Empty;
                if (eventsList[i].StyleIndex % 2 == 1)
                {
                    style = oddRowStyle;
                }
                string row = string.Format(templateDto.EventsRowTemplate, style, eventsList[i].Day, eventsList[i].Event);
                eventsRowBuilder.Append(row);
            }

            string eventsScript = string.Format(templateDto.EventsTemplate, eventsRowBuilder.ToString());

            return eventsScript;
        }

        private List<EventDto> PopulateEventList(string events)
        {
            string[] WeekDays = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap" };

            List<string> rows = new List<string>();
            rows.AddRange(events.Split(System.Environment.NewLine.ToCharArray()));

            List<EventDto> eventsList = new List<EventDto>();
            int styleIndex = -1;
            foreach (var row in rows.Where(r => r != string.Empty))
            {
                var rowArray = row.Split(':');
                var eventDto = new EventDto()
                {
                    Day = rowArray[0]
                };
                if (WeekDays.Contains(eventDto.Day))
                {
                    eventDto.Event = $"{rowArray[1]}:{rowArray[2]}";
                    styleIndex++;
                    eventDto.StyleIndex = styleIndex;
                }
                else
                {
                    eventDto.Day = string.Empty;
                    eventDto.Event = $"{rowArray[0]}:{rowArray[1]}";
                    eventDto.StyleIndex = styleIndex;
                }
                eventsList.Add(eventDto);
            }

            return eventsList;
        }

        private string GenerateNews(InputDto inputDto, TemplateDto templateDto)
        {
            List<string> rows = new List<string>();
            rows.AddRange(inputDto.News.Split(System.Environment.NewLine.ToCharArray()));
            rows = rows.Where(r => r != string.Empty).ToList();

            StringBuilder newsRowBuilder = new StringBuilder();

            int index = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                index = i + 1;
                string style = string.Empty;
                if (index % 2 == 0)
                {
                    style = oddRowStyle;
                }
                string row = string.Format(templateDto.NewsRowTemplate, style, index.ToString(), rows[i]);
                newsRowBuilder.Append(row);
            }

            string newsScript = string.Format(templateDto.NewsTemplate, newsRowBuilder.ToString());

            return newsScript;
        }

        private string GenerateMain(InputDto inputDto, TemplateDto templateDto, ScriptDto scriptDto)
        {
            string mainScript = string.Format(
                templateDto.MainTemplate,
                inputDto.Verb,
                scriptDto.WeekRange,
                //scriptDto.EventsScript,
                scriptDto.NewsScript,
                inputDto.Youtube,
                inputDto.YoutubeText);
            return mainScript;
        }
    }
}