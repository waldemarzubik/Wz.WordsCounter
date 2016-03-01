using NUnit.Framework;
using Wz.WordsCounter.Wpf.ClientSpecific;

namespace Wz.WordsCounter.Tests.ModelsTests
{
    [TestFixture]
    public class SentenceValidatorTests
    {
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(null, false)]
        [TestCase("This is valid statement.", true)]
        [TestCase("Is this a valid statement?", true)]
        [TestCase("Valid statement!", true)]
        [TestCase("Valid statement!", true)]
        [TestCase("First sentence. second sentence?", false)]
        public void SentenceValidation(string sentence, bool expectedResult)
        {
            //Arrange
            var validationModel = new SentenceValidator();

            //Act
            var result = validationModel.ValidateSentence(sentence);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}