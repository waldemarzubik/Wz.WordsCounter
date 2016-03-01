using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Wz.WordsCounter.Logic.Interfaces;
using Wz.WordsCounter.Logic.Models;
using Wz.WordsCounter.Logic.ViewModels;
using Wz.WordsCounter.Logic.ViewModels.Implementation;
using Wz.WordsCounter.Wpf.ClientSpecific;

namespace Wz.WordsCounter.Wpf
{
    public class ViewModelLocator
    {
        public IMainViewModel MainViewModel
        {
            get { return ServiceLocator.Current.GetInstance<IMainViewModel>(); }
        } 

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ISentenceValidator, SentenceValidator>();
            SimpleIoc.Default.Register<IWordsCounterModel, WordsCounterModel>();

            //viewmodels
            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();
        }
    }
}