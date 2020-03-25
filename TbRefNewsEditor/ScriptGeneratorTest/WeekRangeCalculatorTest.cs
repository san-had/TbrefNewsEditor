using System;
using Moq;
using Ninject;
using NUnit.Framework;
using ScriptGenerator.Extensibility;
using ScriptGenerator.Service;

namespace ScriptGeneratorTest
{
    [TestFixture]
    public class WeekRangeCalculatorTest
    {
        private IKernel kernel;
        private Mock<IDateTimeNowProvider> dateTimeNowProviderMock;
        private IWeekRangeCalculator weekRangeCalculator;

        [OneTimeSetUp]
        public void Init()
        {
            kernel = new StandardKernel();
            dateTimeNowProviderMock = new Mock<IDateTimeNowProvider>();
            kernel.Bind<IDateTimeNowProvider>().ToConstant(dateTimeNowProviderMock.Object);
            kernel.Bind<IWeekRangeCalculator>().To<WeekRangeCalculator>();
            weekRangeCalculator = kernel.Get<IWeekRangeCalculator>();
        }

        [TestCase(2020, 3, 15, "március 16 - 22", TestName = "Range inside the month")]
        [TestCase(2020, 3, 29, "március 30 - április 5", TestName = "Range outside the month")]
        [TestCase(2020, 3, 31, "április 1 - 7", TestName = "Range inside the month with next week new month")]
        public void WeekRangeTest(int year, int month, int day, string expected)
        {
            dateTimeNowProviderMock.SetupGet(x => x.Now).Returns(new DateTime(year, month, day));
            kernel.Rebind<IDateTimeNowProvider>().ToConstant(dateTimeNowProviderMock.Object);

            string actual = weekRangeCalculator.CalculateWeekRange();

            Assert.AreEqual(expected, actual);
        }
    }
}