﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_projet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageListPage : ContentPage
    {
        public MessageListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            label1.Text = "OnAppearing()";
            listView.ItemsSource = await App.MessageManager.GetMessagesAsync();
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

