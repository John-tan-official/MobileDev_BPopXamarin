using BPopXamarin.Models;
using BPopXamarin.RestAPIClient;
using BPopXamarin.ServicesHandler;
using BPopXamarin.ViewHandler;
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
    public partial class LobbyPage : ContentPage
    {
        public LobbyPage()
        {
            InitializeComponent();

            TextName.Text = SessionUserCredentials.Name;
            TextPoints.Text = SessionUserCredentials.Points.ToString();
            TextTeam.Text = SessionUserCredentials.Team;

            waitForStart();
        }
        private async void waitForStart()
        {
            LoginService service = new LoginService();
            bool started = true;
            while (started)
            {
                var obj = await service.CheckIfGameBegins();
                await Task.Delay(100);
                if (obj[0].Begin == "begin")
                {
                    await service.CheckUpdateGameIfSuccess("1", "stop");
                    started = false;
                    countdown();
                }
            }
        }
        private async void countdown()
        {
            SLInfo.IsVisible = false;
            SLBegins.IsVisible = true;
            for (int i = 3; i > 0; i--)
            {
                TextGameBegins.Text = "The Game Begins in: " + i.ToString();
                await Task.Delay(1000);
            }

            SLBegins.IsVisible = false;
            SLInfo.IsVisible = true;
            await Navigation.PushModalAsync(new BPopXamarin.Views.GamePage());
        }
    }
}