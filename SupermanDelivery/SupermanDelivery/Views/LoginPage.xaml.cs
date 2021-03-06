using SupermanDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupermanDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(this);
        }

        private void TermsConditionTapped(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new TermsConditionsPage());
        }

        private void PrivacyPolicyTapped(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PrivacyPolicy());
        }
    }
}