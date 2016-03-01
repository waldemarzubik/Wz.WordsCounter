using System.Linq;
using Wz.WordsCounter.Logic.Interfaces;

namespace Wz.WordsCounter.Wpf.ClientSpecific
{
    public class SentenceValidator : ISentenceValidator
    {
        public bool ValidateSentence(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return false;
            }

            var delimiters = new[] {'.', '!', '?'};
            return sentence.Count(delimiters.Contains) <= 1;
        }
    }
}