using System;
using System.IO;
using System.Reflection;
using Moq;
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

            var dateTimeNowProviderMock = new Mock<IDateTimeNowProvider>();
            dateTimeNowProviderMock.SetupGet(x => x.Now).Returns(new DateTime(2020, 4, 5));
            kernel.Rebind<IDateTimeNowProvider>().ToConstant(dateTimeNowProviderMock.Object);

            var scriptGenerator = kernel.Get<IScriptGenerator>();

            var actual = scriptGenerator.ScriptGeneration(inputDto).MainScript;

            var expected = ReadingConstant(Expected);

            Assert.AreEqual(expected, actual);
        }

        private InputDto LoadInputs()
        {
            var inputDto = new InputDto();
            inputDto.Verb = "„Ne félj és ne rettegj, mert veled van Istened, az Úr mindenütt, amerre csak jársz.” Józsué 1,9";
            inputDto.Events = ReadingConstant(ConstEventsFileName);
            inputDto.News = ReadingConstant(ConstNewsFileName);
            inputDto.Youtube = "https://youtu.be/ZFwxgWDG6jA";
            inputDto.YoutubeText = "Április 5-i 10:00 órás virágvasárnapi istentisztelet";
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