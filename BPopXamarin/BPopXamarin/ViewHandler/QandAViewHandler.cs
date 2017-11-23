using BPopXamarin.Models;
using BPopXamarin.ServicesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPopXamarin.ViewHandler
{
    class QandAViewHandler
    {
        //get questions from api
        QandAServices _qandaServices = new QandAServices();

        private List<QandA> _listOfQandA;

        private List<QandA> ListOfQandA
        {
            get { return _listOfQandA; }
            set
            {
                _listOfQandA = value;
            }
        }
        public async Task InitializeGetQandA()
        {
            ListOfQandA = await _qandaServices.GetQuestionsAndAnswers();
            SessionQandA.QandAs = ListOfQandA;
        }
        public void getRandomQandASet()
        {
            Random rnd = new Random();
            
        }
    }
}
