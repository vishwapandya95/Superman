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
    public partial class UploadDocumentsRCPage : ContentPage
    {
        public UploadDocumentsRCPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UploadDocumentsDLPage());
        }
    }
}