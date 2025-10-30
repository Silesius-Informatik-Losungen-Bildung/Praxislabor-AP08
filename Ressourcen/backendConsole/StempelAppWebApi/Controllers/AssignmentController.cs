using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StempelAppCore.Models.Interfaces;
using StempelAppCore.Models.Requests.Assignment;
using StempelAppCore.Models.Responses.Assignment;

namespace StempelAppWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _service;

        public AssignmentController(IAssignmentService service)
        {
            _service = service;
        }

        [HttpGet("default")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner, CleaningPersonnel")]
        public async Task<ActionResult<AssignmentListResponse>> List(AssignmentListRequest request)
        {
            var response = await _service.GetAssignmentsAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }

        [HttpGet]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner, CleaningPersonnel")]
        public async Task<ActionResult<AssignmentGetResponse>> Get([FromQuery] AssignmentGetRequest request)
        {
            var response = await _service.GetAssignmentAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);

        }

        [HttpPost("add")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<AssignmentCreateResponse>> Add([FromBody] AssignmentCreateRequest request)
        {
            var response = await _service.CreateNewAssignmentAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<AssignmentUpdateResponse>> Update([FromBody] AssignmentUpdateRequest request)
        {
            var response = await _service.UpdateAssignmentAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<AssignmentDeleteResponse>> Delete([FromBody] AssignmentDeleteRequest request)
        {
            var response = await _service.DeleteAssignmentAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }
    }
}
