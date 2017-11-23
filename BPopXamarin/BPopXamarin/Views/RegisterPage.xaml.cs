using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BPopXamarin.Models;
using BPopXamarin.ServicesHandler;

namespace BPopXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Users users = new Users();
            LoginService services = new LoginService();
            var getRegisterDetails = await services.CheckRegisterIfSuccess(EntryUsername.Text, EntryPassword.Text, EntryName.Text);

            if (getRegisterDetails)
            {
                await DisplayAlert("Registration success", "You are now Registerd: " + SessionUserCredentials.Name, "Okay", "Cancel");
                await Navigation.PushModalAsync(new BPopXamarin.Views.LobbyPage());
            }
            else
            {
                await DisplayAlert("Registration failed", "Username already exists", "Okay", "Cancel");
            }
        }

        async private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}