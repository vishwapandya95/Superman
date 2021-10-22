using SupermanDelivery.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SupermanDelivery.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}