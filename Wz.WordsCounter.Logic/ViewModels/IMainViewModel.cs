using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Wz.WordsCounter.Logic.ViewModels
{
    public interface IMainViewModel
    {
        string Sentence { get; set; }

        Dictionary<string, int> Words { get; }

        RelayCommand<string> CountWordsCommand { get; }
    }
}