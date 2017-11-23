using BPopXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPopXamarin.ServicesHandler;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BPopXamarin.RestAPIClient;

namespace BPopXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {        
        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            TextScore.Text = "Score: " + SessionUserCredentials.Points;
            getRandomTeam();
            getRandomQandA();
            ShowTimer();
        }

        Random rnd = new Random();
        private async void getRandomQandA()
        {
            LoginService service = new LoginService();
            var QAList = await service.GetQandAList();
            int count = QAList.Count;
            int randomIndex = rnd.Next(0, count);
            Text_questions.Text = QAList[randomIndex].Question;
            Btn_option1.Text = QAList[randomIndex].ChoiceA;
            Btn_option2.Text = QAList[randomIndex].ChoiceB;
            Btn_option3.Text = QAList[randomIndex].ChoiceC;
            Btn_option4.Text = QAList[randomIndex].ChoiceD;
            SessionQandA.Answer = QAList[randomIndex].Answer;
        }

        private void getRandomTeam()
        {
            string[] teams = { "Red", "Blue", "Yellow", "Green" };
            SessionUserCredentials.Team = teams[rnd.Next(0, 4)];
            TextTeam.Text = SessionUserCredentials.Team;
        }

        private async void ShowTimer()
        {
            String secs = "";

            for (int _seconds = 9; _seconds >= 0; _seconds--)
            {
                if (_seconds < 10)
                {
                    secs = Convert.ToString("0" + _seconds);
                }
                else
                {
                    secs = Convert.ToString(_seconds);
                }
                await Task.Delay(1000);

                _timer.Text = "Time: " + secs;
            }

            if (secs == "00")
            {
                hideQandA();
                LoginService services = new LoginService();
                var check = await services.CheckUpdateIfSuccess(SessionUserCredentials.Id.ToString(), SessionUserCredentials.Team, SessionUserCredentials.Points.ToString());
                await services.CheckUpdateGameIfSuccess("1", "stop");
                await Task.Delay(3000);
                await Navigation.PopModalAsync();
            }
        }

        private void Btn_option1_Clicked(object sender, EventArgs e)
        {
            checkAnswer("A");
        }

        private void Btn_option2_Clicked(object sender, EventArgs e)
        {
            checkAnswer("B");
        }

        private void Btn_option_Clicked(object sender, EventArgs e)
        {
            checkAnswer("C");
        }

        private void Btn_option4_Clicked(object sender, EventArgs e)
        {
            checkAnswer("D");
        }
        void checkAnswer(string answer)
        {
            if (answer == SessionQandA.Answer)
            {
                SessionUserCredentials.Points++;
                TextScore.Text = "Score: " + SessionUserCredentials.Points;
            }
            getRandomQandA();
        }

        private void hideQandA()
        {
            Text_questions.IsVisible = false;
            Btn_option1.IsVisible = false;
            Btn_option2.IsVisible = false;
            Btn_option3.IsVisible = false;
            Btn_option4.IsVisible = false;
        }
    }
}