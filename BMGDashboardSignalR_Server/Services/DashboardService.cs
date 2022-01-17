using BMGDashboardSignalR_Server.Model;
using Microsoft.AspNetCore.SignalR.Client;

namespace BMGDashboardSignalR_Server.Services
{
    public class DashboardService
    {
        static List<DashboardActivity> dashboardActivities = new List<DashboardActivity>();

        public async void UpdateUserActivity(string data)
        {

            //create the client connection to hub
            var connection = new HubConnectionBuilder().WithUrl("https://localhost:7091/MessageHub").Build();
            //start the connection
            await connection.StartAsync();

            string[] arrData = data.Split(';');
            ActivityBtnService activityBtnService = new ActivityBtnService();
            string btnText = activityBtnService.GetBtnTitleByID(arrData[0]);

            var dashboardActivitie = dashboardActivities.Where(x => x.UserID == int.Parse(arrData[1]) && x.UserName == arrData[2]).FirstOrDefault();

            if (dashboardActivitie == null)
            {
                dashboardActivities.Add(new DashboardActivity { ButtonID = int.Parse(arrData[0]), ActivityText = btnText, UserID = int.Parse(arrData[1]), UserName = arrData[2], Time = DateTime.Now });
            }
            else
            {
                dashboardActivitie.ButtonID = int.Parse(arrData[0]);
                dashboardActivitie.ActivityText = btnText;
                dashboardActivitie.Time = DateTime.Now;
            }


        }
    }
}
