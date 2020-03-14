using ScriptGenerator.Dto;

namespace ScriptGenerator.Extensibility
{
    public interface IScriptGenerator
    {
        ScriptDto ScriptGeneration(InputDto inputDto);
    }
}