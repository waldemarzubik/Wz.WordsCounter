using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Wz.WordsCounter.Logic.Interfaces;
using Wz.WordsCounter.Logic.Models;

namespace Wz.WordsCounter.Tests.ModelsTests
{
    [TestFixture]
    public class WordsCounterModelTests
    {
        [Test, TestCaseSource(typeof (TestCaseData), "TestCases")]
        public void ProperWordsCountIsReturnedBasedOnSentence(TestData data)
        {
            //Arrange
            var sentenceValidatorModelMock = new Mock<ISentenceValidator>();
            sentenceValidatorModelMock.Setup(x => x.ValidateSentence(It.IsAny<string>())).Returns(true).Verifiable();
            var wordsCounterModel = new WordsCounterModel(sentenceValidatorModelMock.Object);

            //Act
            var result = wordsCounterModel.CountWords(data.Sentence);

            //Assert
            sentenceValidatorModelMock.Verify();
            CollectionAssert.AreEquivalent(result, data.Result);
        }
    }

    public class TestCaseData
    {
        public static IEnumerable<TestData> TestCases
        {
            get
            {
                yield return
                    new TestData("This is an example.",
                        new Dictionary<string, int> {{"this", 1}, {"is", 1}, {"an", 1}, {"example", 1}});
                yield return
                    new TestData("This,is;/an\\(<example.",
                        new Dictionary<string, int> {{"this", 1}, {"is", 1}, {"an", 1}, {"example", 1}});
                yield return
                    new TestData("This \t \r is an \n example.",
                        new Dictionary<string, int> {{"this", 1}, {"is", 1}, {"an", 1}, {"example", 1}});
                yield return
                    new TestData("This IS is an EXample example.",
                        new Dictionary<string, int> {{"this", 1}, {"is", 2}, {"an", 1}, {"example", 2}});
            }
        }
    }

    public class TestData
    {
        public TestData(string sentence, Dictionary<string, int> result)
        {
            Sentence = sentence;
            Result = result;
        }

        public string Sentence { get; set; }

        public Dictionary<string, int> Result { get; set; }
    }
}