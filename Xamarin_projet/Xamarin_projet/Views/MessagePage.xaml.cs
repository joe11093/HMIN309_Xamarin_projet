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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Msg.Favorite)
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
                if(data.StudentId == Msg.StudentId)
                {
                    MessagesOfUser.Add(data);
                }
            }
            lvMessagesOfUser.ItemsSource = this.MessagesOfUser;
        }

        private void btnFavorite_Clicked(object sender, EventArgs e)
        {
            
            if (Msg.Favorite)
            {
                Msg.Favorite = false;
                fakeToast.Text = "Removed from Favorites";
                btnFavorite.Text = "Favorite";
                
            }
            else
            {
                Msg.Favorite = true;
                fakeToast.Text = "Added to Favorites";
                btnFavorite.Text = "Unfavorite";
                
            }
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}