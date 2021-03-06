using BMGDashboardSignalR_Server.Model;
using BMGDashboardSignalR_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMGDashboardSignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityBtnController : ControllerBase
    {
        private readonly ILogger<ActivityBtnController> _logger;
        private readonly ActivityBtnService _activityBtnService;
        private readonly DashboardService _dashboardService;


        public ActivityBtnController(ILogger<ActivityBtnController> logger)
        {
            _logger = logger;
            _activityBtnService = new ActivityBtnService();
            _dashboardService = new DashboardService();
        }

        //for get the button
        [HttpGet]
        public IEnumerable<ActivityBtn> Get()
        {
            return _activityBtnService.GetActivityBtns();
        }

        //for get user click button
        [HttpPost("ClickActivityBtn")]
        public IActionResult ClickActivityBtn([FromBody] string data)
        {
            _dashboardService.UpdateUserActivity(data);
            return Ok();
        }
    }
}
