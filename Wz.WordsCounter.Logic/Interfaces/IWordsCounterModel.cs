using System.Collections.Generic;

namespace Wz.WordsCounter.Logic.Interfaces
{
    public interface IWordsCounterModel
    {
        Dictionary<string, int> CountWords(string sentence);
    }
}