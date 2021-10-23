using Rg.Plugins.Popup.Extensions;
using SupermanDelivery.Views;
using SupermanDelivery.Views.Popup;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SupermanDelivery.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel(ContentPage view)
        {
            m_view = view;
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var popup = new LanguagePopup();
            await m_view.Navigation.PushPopupAsync(popup);
        }
    }
}
