using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                .Returns(testStr);

            // Act
            var result = logic.GetTestValue();

            // Assert
            string expectedString = testStr;
            int expectedLength = testStr.Length;

            testRepoMock.Verify(mock => mock.GetTestValue(), Times.Once);
            Assert.IsNotNull(result, "Метод вернул пустой объект.");
            Assert.IsNotNull(result.String, "Метод вернул пустой c пустой строкой.");
            Assert.AreEqual(result.String, expectedString, "Метод не правильную строку.");
            Assert.AreEqual(result.Length, expectedLength, "Метод не правильную длину строки.");
        }
    }
}
