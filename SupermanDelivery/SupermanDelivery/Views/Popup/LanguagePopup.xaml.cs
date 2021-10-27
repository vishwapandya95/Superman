using Rg.Plugins.Popup.Pages;
using SupermanDelivery.Models;
using SupermanDelivery.Resx;
using SupermanDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupermanDelivery.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePopup : PopupPage
    {
        ObservableCollection<LanguageModel> langList;
        public LanguagePopup()
        {
            InitializeComponent();
            //this.BindingContext = loginViewModel;
            this.BindingContext = new LanguagePopupViewModel(this);
            //langList = new ObservableCollection<LanguageModel>();

            //Languagelist.ItemsSource = langList;
            CultureInfo language = new CultureInfo("gu");
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;
        }
    }
}