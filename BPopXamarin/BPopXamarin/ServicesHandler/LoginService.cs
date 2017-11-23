using BPopXamarin.Models;
using BPopXamarin.RestAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPopXamarin.ServicesHandler
{
    class LoginService
    {
        // fetch the RestClient<T>
        RestClient<Users> _restClient = new RestClient<Users>();

        // Boolean function with the following parameters of username & password.
        public async Task<bool> CheckLoginIfExists(string studentID, string password)
        {
            var check = await _restClient.checkLogin(studentID, password);
            return check;
        }
        public async Task<bool> CheckRegisterIfSuccess(string studentID, string password, string name)
        {
            var check = await _restClient.checkRegister(studentID, password, name);
            return check;
        }
        public async Task<bool> CheckUpdateIfSuccess(string id, string team, string points)
        {
            var check = await _restClient.updateUser(id, team, points);
            return check;
        }
        public async Task<bool> CheckUpdateGameIfSuccess(string id, string begin)
        {
            var check = await _restClient.updateGameState(id, begin);
            return check;
        }
        RestClient<GameStarter> _RestClient = new RestClient<GameStarter>();
        public async Task<List<GameStarter>> CheckIfGameBegins()
        {
            var check = await _RestClient.checkIFBegin();
            return check;
        }
        RestClient<QandA> restClient = new RestClient<QandA>();
        public async Task<int> GetQandACount()
        {
            return await restClient.getQandACount();           
        }
        public async Task<bool> GetRandomQandA(int id)
        {
            var check = await restClient.getRandomQandA(id);
            return check;
        }
        public async Task<List<QandA>> GetQandAList()
        {
            var QandAList = await restClient.getQandAList();
            return QandAList;
        }
    }
}
