using BMGDashboardSignalR_Server.Model;
using BMGDashboardSignalR_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMGDashboardSignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UserService _userService;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }

        [HttpPost]
        public string Login([FromBody] UserInform data)
        {
            string returnUserInform = _userService.CheckLoginUserInform(data);
            return returnUserInform;
        }
    }

}
