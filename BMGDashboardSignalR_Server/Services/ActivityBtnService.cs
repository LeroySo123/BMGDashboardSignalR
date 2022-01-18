using BMGDashboardSignalR_Server.Model;

namespace BMGDashboardSignalR_Server.Services
{
    public class ActivityBtnService
    {
        //for get all activity button
        public List<ActivityBtn> GetActivityBtns()
        {
            DBService db = new DBService();
            return db.GetActivityBtns();
        }

        //for get button text by id
        public string GetBtnTextByID(string ID)
        {
            List<ActivityBtn> activityBtns = GetActivityBtns();
            return activityBtns.Where(x => x.ButtonID == int.Parse(ID)).Select(x => x.Text).FirstOrDefault();
        }
    }
}
