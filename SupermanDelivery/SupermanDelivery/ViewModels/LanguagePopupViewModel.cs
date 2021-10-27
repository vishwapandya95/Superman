using SupermanDelivery.Models;
using SupermanDelivery.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SupermanDelivery.ViewModels
{
    public class LanguagePopupViewModel:BaseViewModel
    {
        private ObservableCollection<LanguageModel> langList;

        public ObservableCollection<LanguageModel> LangList
        {
            get { return langList; }
            set { langList = value; RaisePropertyChanged(() => LangList); }
        }

        private LanguageModel selectedLanguage;

        public LanguageModel SelectedLanguage
        {
            get { return selectedLanguage; }
            set { selectedLanguage = value; RaisePropertyChanged(() => SelectedLanguage); }
        }

        public LanguagePopupViewModel(ContentPage view)
        {
            m_view = view;
            LangList = new ObservableCollection<LanguageModel>();
            LangList.Add(new LanguageModel { LanguageId = 0, Language = "English" });
            LangList.Add(new LanguageModel { LanguageId = 1, Language = "Hindi" });
            LangList.Add(new LanguageModel { LanguageId = 2, Language = "Gujarati" });

        }
        public ICommand ReloadDataCommand { get { return new Command(ReloadDataCommandEvent); } }

        private async void ReloadDataCommandEvent()
        {
            try
            {
                await m_view.Navigation.PopAsync();
                PushContentPage(new DriverDetailPage());
            }
            catch (Exception ex)
            {
               
            }
        }
        public ICommand SelectLanguageCommand { get { return new Command(async () => await SelectLanguageCommandAction()); } }

        private async Task SelectLanguageCommandAction()
        {
            try
            {
                await m_view.Navigation.PopAsync();
                PushContentPage(new DriverDetailPage());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
