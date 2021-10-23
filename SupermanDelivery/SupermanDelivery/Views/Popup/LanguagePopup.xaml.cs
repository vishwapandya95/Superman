using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupermanDelivery.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePopup : PopupPage
    {
        List<string> langList;
        public LanguagePopup()
        {
            InitializeComponent();
            langList = new List<string>();
            langList.Add("English");
            langList.Add("Hindi");
            langList.Add("Gujarati");
            Languagelist.ItemsSource = langList;
        }
    }
}