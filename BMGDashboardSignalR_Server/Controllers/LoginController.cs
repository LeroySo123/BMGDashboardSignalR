using BMGDashboardSignalR_Server.Model;
using BMGDashboardSignalR_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMGDashboardSignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public string Login([FromBody] UserInform data)
        {
            UserService userService = new UserService();
            string str = userService.CheckLoginUserInform(data);
            return str;
        }
    }

}
