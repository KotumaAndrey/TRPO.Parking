using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TRPO.Parking.Repositories.Interfaces;
using TRPO.Parking.Logic.Interfaces;

namespace TRPO.Parking.Tests.Logic
{
    [TestClass]
    public class TestTest : BaseTest
    {
        private Mock<ITestRepoInterface> testRepoMock;
        private ITestLogicInterface logic;

        [TestInitialize]
        public new void Initialize()
        {
            InitAutofacContainerBuilder();
            // --- --- ---
            testRepoMock = RegisterMock<ITestRepoInterface>();
            // --- --- ---
            InitAutofacContainer();
            // --- --- ---
            logic = autofacContainer.Resolve<ITestLogicInterface>();
        }

        [TestMethod]
        public void TestMethod()
        {
            // Arrage
            const string testStr = "String for test logic test";
            testRepoMock.Setup(mock => mock.GetTestValue())
                .Returns(Task.FromResult(testStr));
            testRepoMock.Setup(mock => mock.GetGenders())
                .Returns(Task.FromResult(Enumerable.Empty<string>()));

            // Act
            var result = logic.GetTestValue().Result;

            // Assert
            string expectedString = testStr;
            int testStrLength = testStr.Length;

            testRepoMock.Verify(mock => mock.GetTestValue(), Times.Once);
            testRepoMock.Verify(mock => mock.GetGenders(), Times.Once);

            Assert.IsNotNull(result, "Метод вернул пустой объект.");

            Assert.IsNotNull(result.String, "Метод вернул объект c пустой строкой.");
            Assert.AreEqual(expectedString, result.String, "Метод вернул не правильную строку.");
            Assert.AreEqual(testStrLength, result.Length, "Метод вернул струку не правильной длины.");

            Assert.IsNotNull(result.Strings, "Метод вернул null перечисление.");
            Assert.AreEqual(0, result.Strings.Count(), "Метод вернул не пустое перечисление.");
        }
    }
}
