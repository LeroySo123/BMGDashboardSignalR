namespace BMGDashboardSignalR_Server.Model
{
    public class DashboardActivity
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int ButtonID { get; set; }
        public string ActivityText { get; set; }
        public DateTime Time { get; set; }
    }
}
