using BMGDashboardSignalR_Server.Model;
using BMGDashboardSignalR_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMGDashboardSignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityBtnController : ControllerBase
    {
        private readonly ILogger<ActivityBtnController> _logger;
        private readonly ActivityBtnService _activityBtnService;

        public ActivityBtnController(ILogger<ActivityBtnController> logger)
        {
            _logger = logger;
            _activityBtnService = new ActivityBtnService();
        }

        [HttpGet]
        public IEnumerable<ActivityBtn> Get()
        {
            return _activityBtnService.GetActivityBtns();
        }
    }
}
