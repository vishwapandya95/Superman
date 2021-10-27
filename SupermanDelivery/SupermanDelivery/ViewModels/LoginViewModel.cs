using Rg.Plugins.Popup.Extensions;
using SupermanDelivery.Models;
using SupermanDelivery.Resx;
using SupermanDelivery.Views;
using SupermanDelivery.Views.Popup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SupermanDelivery.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ObservableCollection<LanguageModel> langList;

        public ObservableCollection<LanguageModel> LangList
        {
            get { return langList; }
            set { langList = value; RaisePropertyChanged(() => LangList); }
        }


        public LoginViewModel(ContentPage view)
        {
            m_view = view;
            //LangList = new ObservableCollection<LanguageModel>();
            //LangList.Add(new LanguageModel { LanguageId = 0, Language = "English" });
            //LangList.Add(new LanguageModel { LanguageId = 1, Language = "Hindi" });
            //LangList.Add(new LanguageModel { LanguageId = 2, Language = "Gujarati" });

        }

        public ICommand LoginCommand { get { return new Command(async () => await LoginCommandAction()); } }

        private async Task LoginCommandAction()
        {
            try
            {
                CultureInfo language = new CultureInfo("gu");
                Thread.CurrentThread.CurrentUICulture = language;
                AppResources.Culture = language;
                PushContentPage(new DriverDetailPage());
                //var popup = new LanguagePopup();
                //await m_view.Navigation.PushPopupAsync(popup);
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

        //public ICommand SelectLanguageCommand { get { return new Command<LanguageModel>(async (LanguageModel) => await SelectLanguageCommandAction(LanguageModel)); } }

        //private async Task SelectLanguageCommandAction(LanguageModel languageModel)
        //{
        //    try
        //    {
               
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        
    }
}
