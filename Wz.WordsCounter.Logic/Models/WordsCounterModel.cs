using System;
using System.Collections.Generic;
using System.Linq;
using Wz.WordsCounter.Logic.Interfaces;

namespace Wz.WordsCounter.Logic.Models
{
    public class WordsCounterModel : IWordsCounterModel
    {
        private readonly ISentenceValidator _sentenceValidator;

        public WordsCounterModel(ISentenceValidator sentenceValidator)
        {
            if (sentenceValidator == null)
            {
                throw new AggregateException($"Missing {nameof(ISentenceValidator)}");
            }
            _sentenceValidator = sentenceValidator;
        }

        public Dictionary<string, int> CountWords(string sentence)
        {
            if (_sentenceValidator.ValidateSentence(sentence))
            {
                var words = GetWordsFromSentence(sentence);
                var groupedWords = from word in words group word by word.ToLower() into wordGrouped select wordGrouped;
                return groupedWords.ToDictionary(item => item.Key, item => item.Count());
            }
            return null;
        }

        private static IEnumerable<string> GetWordsFromSentence(string sentence)
        {
            var invalidChars = new[]
            {'.', '!', ',', '?', ':', ';', '\\', '/', '\n', '\r', '~', '(', ')', '[', ']', '{', '}', '<', '>'};

            sentence = invalidChars.Aggregate(sentence, (current, item) => current.Replace(item.ToString(), " "));
            return
                sentence.Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.None)
                    .Where(item => !string.IsNullOrWhiteSpace(item));
        }
    }
}