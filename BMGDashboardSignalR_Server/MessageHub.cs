using BMGDashboardSignalR_Server.Model;
using Microsoft.AspNetCore.SignalR;

namespace BMGDashboardSignalR_Server
{
    public class MessageHub:Hub
    {
        //for signalR connect to Web
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        //for receive meassage to send to Web
        public async Task SendMessage(List<DashboardActivity> data)
        {
            await Clients.All.SendAsync("DashboardActivity", data);
        }
    }
}
