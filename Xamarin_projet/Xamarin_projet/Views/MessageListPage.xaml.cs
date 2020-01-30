using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_projet.Views;

namespace Xamarin_projet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageListPage : ContentPage
    {
        public static ObservableCollection<Message> MessageList { get; set; }

        public MessageListPage()
        {
            InitializeComponent();
            MessageList = new ObservableCollection<Message>();
            Device.StartTimer(TimeSpan.FromSeconds(10), () => { RefreshListCallback(); return true; });
            listView.ItemTapped += ListView_ItemTapped;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           Navigation.PushModalAsync(new MessagePage((Message)e.Item));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            RefreshListCallback();
            listView.ItemsSource = MessageList;
        }

        async void RefreshList(object sender, EventArgs args)
        {
            RefreshListCallback();
        }
        async void RefreshListCallback()
        {
            MessageList = await App.MessageManager.GetMessagesAsync();
            List<Message> favList = await App.Database.GetMessagesAsync();
            if(favList.Count > 0)
            {
                foreach(Message m in favList)
                {
                    MessageList.Insert(0, m);
                }
                
            }
            listView.ItemsSource = MessageList;
            
        }
        /*
        async void OnAddItemClicked(object sender, EventArgs e)
        {

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
        */
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}

