using BMGDashboardSignalR_Server.Model;

namespace BMGDashboardSignalR_Server.Services
{
    public class UserService
    {
        public string CheckLoginUserInform(UserInform data)
        {
            DBService db = new DBService();
            List<UserInform> userInformList = db.GetUserInforms();
            var userInform = userInformList.Where(x => x.UserName == data.UserName && x.Password == data.Password).Select(x => new { x.UserID, x.UserName }).FirstOrDefault();
            if (userInform != null)
                return "{ \"token\": \"" + userInform.UserID + ";" + userInform.UserName + "\" }";

            else
                return "{ \"token\": \"Fales\" }";
        }
    }
}
