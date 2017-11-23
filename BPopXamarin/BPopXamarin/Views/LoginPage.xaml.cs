﻿using BPopXamarin.Models;
using BPopXamarin.ServicesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BPopXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(EntryUsername.Text, EntryPassword.Text);

            if (getLoginDetails)
            {
                await DisplayAlert("Login success", "You are logged in: " + SessionUserCredentials.Name, "Okay", "Cancel");
                await Navigation.PushModalAsync(new BPopXamarin.Views.LobbyPage());
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }

        async private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BPopXamarin.Views.RegisterPage());
        }
    }
}