using System.IO;
using ScriptGenerator.Dto;
using ScriptGenerator.Extensibility;

namespace ScriptGenerator.Service
{
    public class TemplateRetriever : ITemplateRetriever
    {
        private const string EventRow = "event_row_template.txt";
        private const string Events = "events_template.txt";
        private const string NewsRow = "news_row_template.txt";
        private const string News = "news_template.txt";
        private const string Main = "main_template.txt";

        public TemplateDto ReadingTemplates()
        {
            var templates = new string[]
            {
                EventRow,
                Events,
                NewsRow,
                News,
                Main
            };

            var templateDto = new TemplateDto();

            var properties = templateDto.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(templateDto, ReadingTemplate(templates[i]));
            }

            return templateDto;
        }

        private string ReadingTemplate(string fileName)
        {
            string templateString = string.Empty;

            string filePath = $".\\Resource\\{fileName}";
            string fullPath = Path.GetFullPath(filePath);

            using (var streamReader = new StreamReader(File.OpenRead(fullPath), System.Text.Encoding.Default))
            {
                templateString = streamReader.ReadToEnd();
            }
            return templateString;
        }
    }
}