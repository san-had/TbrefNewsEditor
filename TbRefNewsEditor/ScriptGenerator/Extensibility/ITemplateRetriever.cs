using ScriptGenerator.Dto;

namespace ScriptGenerator.Extensibility
{
    public interface ITemplateRetriever
    {
        TemplateDto ReadingTemplates();
    }
}