using BPopXamarin.Models;
using BPopXamarin.RestAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPopXamarin.ServicesHandler
{
    class QandAServices
    {
        GetQandAsClient<QandA> _restClient = new GetQandAsClient<QandA>();

        public async Task<List<QandA>> GetQuestionsAndAnswers()
        {
            var getQandAs = await _restClient.GetQuestionsAndAnswers();

            return getQandAs;
        }
    }
}
