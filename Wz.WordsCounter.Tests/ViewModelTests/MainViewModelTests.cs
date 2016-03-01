using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Wz.WordsCounter.Logic.Interfaces;
using Wz.WordsCounter.Logic.ViewModels.Implementation;

namespace Wz.WordsCounter.Tests.ViewModelTests
{
    [TestFixture]
    public class MainViewModelTests
    {
        [Test]
        public void PropertiesTest()
        {
            //Arrange
            var wordsCounterModelMock = new Mock<IWordsCounterModel>();
            var viewModel = new MainViewModel(wordsCounterModelMock.Object);

            //Act
            var dummyData = new Dictionary<string, int> {{"a", 3}};
            viewModel.Words = dummyData;

            //Assert
            Assert.AreEqual(dummyData, viewModel.Words);
        }

        [Test]
        public void WordsCounterExecuted()
        {
            //Arrange
            var wordsCounterModelMock = new Mock<IWordsCounterModel>();
            wordsCounterModelMock.Setup(x => x.CountWords(It.IsAny<string>())).Verifiable();
            var viewModel = new MainViewModel(wordsCounterModelMock.Object);

            //Act
            viewModel.CountWordsCommand.Execute(It.IsAny<string>());

            //Assert
            wordsCounterModelMock.Verify();
        }
    }
}