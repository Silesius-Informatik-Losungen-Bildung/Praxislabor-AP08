using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StempelAppCore.Models.Interfaces;
using StempelAppCore.Models.Requests.User;
using StempelAppCore.Models.Responses.User;

namespace StempelAppWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet("default")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<UserListResponse>> ListUsers([FromBody] UserListRequest request)
        {
            var response = await _service.GetUsersAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }

        [HttpGet]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<UserGetResponse>> GetUser([FromQuery] UserGetRequest request)
        {
            var response = await _service.GetUserAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }

        [HttpPost("add")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<UserCreateResponse>> CreateUser([FromBody] UserCreateRequest request)
        {
            var response = await _service.CreateNewUserAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "SuperUser, CustomerAdmin, BuildingOwner")]
        public async Task<ActionResult<UserUpdateResponse>> UpdateUser([FromBody] UserUpdateRequest request)
        {
            var response = await _service.UpdateUserAsync(request);

            if (response.IsSuccess)
                return Ok(response);
            else return BadRequest(response.Message);
        }
    }
}
