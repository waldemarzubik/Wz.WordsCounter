using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wz.WordsCounter.Logic.Interfaces
{
    public interface ISentenceValidator
    {
        bool ValidateSentence(string sentence);
    }
}
