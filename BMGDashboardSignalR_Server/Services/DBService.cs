using BMGDashboardSignalR_Server.Model;
using Newtonsoft.Json;

namespace BMGDashboardSignalR_Server.Services
{
    public class DBService
    {
        private string _UserInformPath = "Database\\UserInformation.json";
        private string _ActivityBtnPath = "Database\\ActivityButton.json";

        //get user information
        public List<UserInform> GetUserInforms()
        {
            return JsonConvert.DeserializeObject<List<UserInform>>(File.ReadAllText(_UserInformPath));

        }

        //get activity button
        public List<ActivityBtn> GetActivityBtns()
        {
            return JsonConvert.DeserializeObject<List<ActivityBtn>>(File.ReadAllText(_ActivityBtnPath));
        }
    }
}
