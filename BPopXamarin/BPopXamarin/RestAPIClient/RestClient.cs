using BPopXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using unirest_net.http;
using System.Text;
using System.Threading.Tasks;

namespace BPopXamarin.RestAPIClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "http://localhost:56116/"; // Put your main host url here
        private const string LoginWebServiceUrl = MainWebServiceUrl + "api/UsersLogin/"; // put your api extension url/uri here
        private const string RegisterWebServiceUrl = MainWebServiceUrl + "api/UsersRegister/";
        private const string UpdateWebServiceUrl = MainWebServiceUrl + "api/UsersUpdate/";
        private const string GetRandomQuestionAndAnswerURL = MainWebServiceUrl + "api/api/QandAGetQuestions/";
        private const string GetQuestionsAndAnswersURL = MainWebServiceUrl + "api/QandAs/";
        private const string UpdateGameWebServiceUrl = MainWebServiceUrl + "api/UpdateGameState/";

        // This code matches the HTTP Request that we included in our api controller
        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();
            // http://MainHost/api/UserCredentials/username=foo/password=foo. The api value and response value should match in order to return a true status code. 
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "studentID=" + username + "/" + "password=" + password);
            if (response.IsSuccessStatusCode)
            {
                Task<HttpResponse<string>> response2 = Unirest.get(LoginWebServiceUrl + "studentID=" + username + "/" + "password=" + password)
                            .asJsonAsync<string>();
                var obj = JsonConvert.DeserializeObject<Users>(response2.Result.Body);
                SessionUserCredentials.Name = obj.Name;
                SessionUserCredentials.Points = Convert.ToInt32(obj.Points);
                SessionUserCredentials.Team = obj.Team;
                SessionUserCredentials.Id = obj.Id;
            }

            return response.IsSuccessStatusCode; // return either true or false
        }

        public async Task<bool> checkRegister(string username, string password, string name)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(RegisterWebServiceUrl + "studentID=" + username + "/" + "password=" + password + "/" + "name=" + name);

            if (response.IsSuccessStatusCode)
            {
                Task<HttpResponse<string>> response2 = Unirest.get(LoginWebServiceUrl + "studentID=" + username + "/" + "password=" + password)
                            .asJsonAsync<string>();
                var obj = JsonConvert.DeserializeObject<Users>(response2.Result.Body);
                SessionUserCredentials.Name = obj.Name;
                SessionUserCredentials.Points = Convert.ToInt32(obj.Points);
                SessionUserCredentials.Team = obj.Team;
                SessionUserCredentials.Id = obj.Id;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateUser(string id, string team, string points)
        {
            var httpClient = new HttpClient();
            //api/UsersUpdate/Id={id}/Team={team}/Points={points}
            var response = await httpClient.GetAsync(UpdateWebServiceUrl + "Id=" + id + "/" + "Team=" + team + "/" + "Points=" + points);
            
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> getRandomQandA(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(GetRandomQuestionAndAnswerURL + "Id=" + id);

            if (response.IsSuccessStatusCode)
            {
                Task<HttpResponse<string>> response2 = Unirest.get(GetRandomQuestionAndAnswerURL)
                            .asJsonAsync<string>();
                var obj = JsonConvert.DeserializeObject<QandA>(response2.Result.Body);

                SessionQandA.Question = obj.Question;
                SessionQandA.ChoiceA = obj.ChoiceA;
                SessionQandA.ChoiceB = obj.ChoiceB;
                SessionQandA.ChoiceC = obj.ChoiceC;
                SessionQandA.ChoiceD = obj.ChoiceD;
                SessionQandA.Answer = obj.Answer;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<List<T>> getQandAList()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(GetQuestionsAndAnswersURL);

            var obj = JsonConvert.DeserializeObject <List<T>>(response);
            
            return obj;
        }

        public async Task<int> getQandACount()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(GetQuestionsAndAnswersURL);

            var obj = JsonConvert.DeserializeObject<List<string>>(response);

            return obj.Count;
        }

        public async Task<bool> updateGameState(string id, string begin)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(UpdateGameWebServiceUrl + "Id=" + id + "/" + "Begin=" + begin);

            return response.IsSuccessStatusCode;
        }
        public async Task<List<T>> checkIFBegin()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(MainWebServiceUrl+ "api/GameStartersAPI");
            
            var obj = JsonConvert.DeserializeObject<List<T>>(response);
            
            return obj;
        }
    }
}
