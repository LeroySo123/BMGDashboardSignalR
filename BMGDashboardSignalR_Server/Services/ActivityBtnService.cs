using BMGDashboardSignalR_Server.Model;

namespace BMGDashboardSignalR_Server.Services
{
    public class ActivityBtnService
    {
        public List<ActivityBtn> GetActivityBtns()
        {
            DBService db = new DBService();
            return db.GetActivityBtns();
        }

        public string GetBtnTitleByID(string ID)
        {
            List<ActivityBtn> activityBtns = GetActivityBtns();
            return activityBtns.Where(x => x.ButtonID == int.Parse(ID)).Select(x => x.Text).FirstOrDefault();
        }
    }
}
