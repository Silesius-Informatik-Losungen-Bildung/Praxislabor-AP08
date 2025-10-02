using Microsoft.AspNetCore.Mvc;
using StempelAppCore.Models;

namespace StempelAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly ILogger<AssignmentController> _logger;

        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> Get()
        {
            var assignment1 = new Assignment()
            {
                UserId = 1,
                GPSLongitude = -122.4194,
                GPSLatitude = 37.7749,
            };
            var assignment2 = new Assignment()
            {
                UserId = 1,
                GPSLongitude = 11.424,
                GPSLatitude = -50.1123,
            };
            var assignment3 = new Assignment()
            {
                UserId = 1,
                GPSLongitude = 67.1111,
                GPSLatitude = 35.22,
            };
            var assignment4 = new Assignment()
            {
                UserId = 2,
                GPSLongitude = -99.22,
                GPSLatitude = -16.001,
            };
            var assignment5 = new Assignment()
            {
                UserId = 2,
                GPSLongitude = 69.420,
                GPSLatitude = 169.420,
            };

            var assignmentList = new List<Assignment>()
            {
                assignment1,
                assignment2,
                assignment3,
                assignment4,
                assignment5,
            };
            return assignmentList;
        }

        [HttpGet("{id}")]
        public ActionResult<Assignment> Get(int id)
        {
            var assignment = new Assignment()
            {
                UserId = 2,
                GPSLongitude = 69.420,
                GPSLatitude = 169.420,
            };
            return assignment;
        }

        [HttpPost]
        public async Task<ActionResult<Assignment>> Add()
        {
            // validate request
            // map to query
            // call userservice with query
            var assignment = new Assignment()
            {
                UserId = 3,
                GPSLatitude = 142.069,
                GPSLongitude = 42.069,
            };
            return Ok(assignment);
        }
    }
}
