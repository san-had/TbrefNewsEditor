using System.IO;
using System.Reflection;
using Ninject;
using NUnit.Framework;
using ScriptGenerator;
using ScriptGenerator.Dto;
using ScriptGenerator.Extensibility;

namespace ScriptGeneratorTest
{
    [TestFixture]
    public class ScriptGenerationTest
    {
        private const string ConstEventsFileName = "const_events.txt";
        private const string ConstNewsFileName = "const_news.txt";
        private const string Expected = "expected.txt";

        private IKernel kernel;

        [OneTimeSetUp]
        public void Init()
        {
            kernel = new StandardKernel();
            kernel.Load<ScriptGeneratorNinjectModule>();
        }

        [TestCase]
        public void FullGenerationTest()
        {
            var inputDto = LoadInputs();

            var scriptGenerator = kernel.Get<IScriptGenerator>();

            var actual = scriptGenerator.ScriptGeneration(inputDto).MainScript;

            var expected = ReadingConstant(Expected);

            Assert.AreEqual(expected, actual);
        }

        private InputDto LoadInputs()
        {
            var inputDto = new InputDto();
            inputDto.Verb = "\"Az Úr védelmez téged, az Úr a te oltalmad jobb kezed felől.\" Zsoltárok 121, 5";
            inputDto.Events = ReadingConstant(ConstEventsFileName);
            inputDto.News = ReadingConstant(ConstNewsFileName);
            return inputDto;
        }

        private string ReadingConstant(string fileName)
        {
            string templateString = string.Empty;

            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(exeDir);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", fileName);
            string fullPath = Path.GetFullPath(filePath);

            using (var streamReader = new StreamReader(File.OpenRead(fullPath), System.Text.Encoding.Default))
            {
                templateString = streamReader.ReadToEnd();
            }
            return templateString;
        }
    }
}