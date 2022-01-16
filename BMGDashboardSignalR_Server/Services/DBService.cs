using BMGDashboardSignalR_Server.Model;
using Newtonsoft.Json;

namespace BMGDashboardSignalR_Server.Services
{
    public class DBService
    {
        private string _UserInformPath = "Database\\UserInformation.json";
        private string _ActivityBtnPath = "Database\\ActivityButton.json";

        public List<UserInform> GetUserInforms()
        {
            return JsonConvert.DeserializeObject<List<UserInform>>(File.ReadAllText(_UserInformPath));

        }

        public List<ActivityBtn> GetActivityBtns()
        {
            return JsonConvert.DeserializeObject<List<ActivityBtn>>(File.ReadAllText(_ActivityBtnPath));
        }
    }
}
