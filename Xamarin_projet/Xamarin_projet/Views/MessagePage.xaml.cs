using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_projet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        public Message Msg { get; private set; }
        ObservableCollection<Message> Messages;
        ObservableCollection<Message> MessagesOfUser;
        public MessagePage(Message m)
        {
            InitializeComponent();
            this.Messages = new ObservableCollection<Message>();
            this.MessagesOfUser = new ObservableCollection<Message>();
            this.Msg = m;
            labelSender.Text = m.StudentId.ToString();
            labelMessage.Text = m.StudentMessage;
            LoadMessagesOfUser();

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            displayDbSize();
            Message foundMessage = await App.Database.GetMessageAsync(this.Msg.Id);
            if (foundMessage != null)
            {
                btnFavorite.Text = "Unfavorite";
            }
            else
            {
                btnFavorite.Text = "Favorite";
            }

        }

        public async void LoadMessagesOfUser()
        {
            this.Messages = await App.MessageManager.GetMessagesAsync();
            
            foreach(var data in Messages)
            {
                if(data.StudentId == Msg.StudentId && data.Id != this.Msg.Id)
                {
                    MessagesOfUser.Add(data);
                }
            }
            lvMessagesOfUser.ItemsSource = this.MessagesOfUser;
        }

        private async void btnFavorite_Clicked(object sender, EventArgs e)
        {
            Message foundMessage = await App.Database.GetMessageAsync(this.Msg.Id);
            if (foundMessage != null)
            {
                Msg.Favorite = false;
                btnFavorite.Text = "Favorite";
                await App.Database.DeleteItemAsync(this.Msg);
                List<Message> listFavMessages = await App.Database.GetMessagesAsync();
                displayDbSize();
            }
            else
            {
                Msg.Favorite = true;
                btnFavorite.Text = "Unfavorite";
                await App.Database.SaveItemAsync(this.Msg);
                Message added = await App.Database.GetMessageAsync(this.Msg.Id);
                List<Message> listFavMessages = await App.Database.GetMessagesAsync();
                displayDbSize();

            }
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void displayDbSize()
        {
            List<Message> dbMessages = await App.Database.GetMessagesAsync();
            fakeToast.Text = "Number of favorited Messages: " + dbMessages.Count;
        }
    }
}