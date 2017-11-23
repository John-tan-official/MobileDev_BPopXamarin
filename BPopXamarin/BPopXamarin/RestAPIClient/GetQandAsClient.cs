using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BPopXamarin.RestAPIClient
{
    class GetQandAsClient<T>
    {
        private const string MainWebServiceUrl = "http://localhost:56116/"; // Put your main host url here
        private const string LoginWebServiceUrl = MainWebServiceUrl + "api/QandAs/"; // put your api extension url/uri here
        private const string WebServiceURL = "http://182.18.242.75:8080/lpudemo/api/apiLpustudents/";

        HttpClient _httpClient = new HttpClient();

        public async Task<List<T>> GetQuestionsAndAnswers()
        {
            var json = await _httpClient.GetStringAsync(MainWebServiceUrl + LoginWebServiceUrl);

            var getQuestionsAndAnswers = JsonConvert.DeserializeObject<List<T>>(json);

            return getQuestionsAndAnswers;
        }
    }
}
