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
    public partial class ConnectToHostPage : ContentPage
    {
        public ConnectToHostPage()
        {
            InitializeComponent();
        }

        private void ButtonConnect_Clicked(object sender, EventArgs e)
        {
            //connect to host
            //go to login/register page
        }
    }
}