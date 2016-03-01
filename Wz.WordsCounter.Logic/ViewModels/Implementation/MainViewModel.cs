using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Wz.WordsCounter.Logic.Interfaces;

namespace Wz.WordsCounter.Logic.ViewModels.Implementation
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IWordsCounterModel _wordsCounterModel;
        private Dictionary<string, int> _words;
        private string _sentence;

        public MainViewModel(IWordsCounterModel wordsCounterModel)
        {
            _wordsCounterModel = wordsCounterModel;
            CountWordsCommand = new RelayCommand<string>(CountWords);
        }

        public string Sentence
        {
            get { return _sentence; }
            set
            {
                _sentence = value;
                RaisePropertyChanged(() => Sentence);
                Words = null;
            }
        }

        public Dictionary<string, int> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                RaisePropertyChanged(() => Words);
            }
        }

        public RelayCommand<string> CountWordsCommand { get; }

        private void CountWords(string sentence)
        {
            Words = _wordsCounterModel.CountWords(sentence);
        }
    }
}