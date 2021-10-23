using SupermanDelivery.Models;
using SupermanDelivery.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SupermanDelivery.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        protected ContentPage m_view;
        protected void PushContentPage(ContentPage pageToPush)
        {
            //Push or Navigate to some page
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { m_view.Navigation.PushAsync(pageToPush); });

        }
        protected void PushTabbedPage(TabbedPage pageToPush)
        {
            //Push or Navigate to some page
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { m_view.Navigation.PushAsync(pageToPush); });

        }

        protected void PopContentPage()
        {
            try
            {
                //Pop out some Page     
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { m_view.Navigation.PopAsync(); });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void RaisePropertyChanged(String property)
        {
            //Raise the Property when any property is changed
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            MemberExpression expression = propertyExpression.Body as MemberExpression;
            RaisePropertyChanged(expression.Member.Name);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
