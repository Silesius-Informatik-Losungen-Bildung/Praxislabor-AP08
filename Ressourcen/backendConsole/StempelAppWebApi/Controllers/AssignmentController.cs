using Microsoft.AspNetCore.Mvc;
using StempelAppCore.Models.Domain;

namespace StempelAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly ILogger<AssignmentController> _logger;

        [HttpGet]
        public ActionResult<IEnumerable<UserAssignment>> Get()
        {
            var demoLocData1 = new LocationData()
            {
                GPSLongitude = -122.4194,
                GPSLatitude = 37.7749,
            };

            var demoLocData2 = new LocationData()
            {
                GPSLongitude = 11.424,
                GPSLatitude = -50.1123,
            };

            var assignment1 = new UserAssignment()
            {
                UserId = 1,
                Location = demoLocData1,
            };
            var assignment2 = new UserAssignment()
            {
                UserId = 1,
                Location = demoLocData2,
            };

            var assignmentList = new List<UserAssignment>()
            {
                assignment1,
                assignment2,
            };
            return assignmentList;
        }

        [HttpGet("{id}")]
        public ActionResult<UserAssignment> Get(int id)
        {
            var demoLocData = new LocationData()
            {
                GPSLongitude = -122.4194,
                GPSLatitude = 37.7749,
            };

            var assignment = new UserAssignment()
            {
                UserId = 1,
                Location = demoLocData,
            };

            return assignment;
        }

        [HttpPost]
        public async Task<ActionResult<UserAssignment>> Add()
        {
            var demoLocData = new LocationData()
            {
                GPSLongitude = -122.4194,
                GPSLatitude = 37.7749,
            };

            var assignment = new UserAssignment()
            {
                UserId = 1,
                Location = demoLocData,
            };

            return Ok(assignment);
        }
    }
}
