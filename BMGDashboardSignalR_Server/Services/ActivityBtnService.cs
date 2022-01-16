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
    }
}
