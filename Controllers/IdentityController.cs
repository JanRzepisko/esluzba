using esluzba.DataAccess.Entities;
using esluzba.Services.Admin;
using esluzba.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace esluzba.Controllers;

[ApiController]
[Authorize]
[Route("api/identity")]
public class IdentityController
{
    private IAdminServices _AdminServices { get; set; }
    private IUserService _UserService { get; set; }
    
    public IdentityController(IAdminServices adminServices, IUserService userService)
    {
        _AdminServices = adminServices;
        _UserService = userService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public Task<IActionResult> RegisterAdmin([FromBody] Parish parish) => _AdminServices.Register(parish);
    
    [HttpPost("login")]
    [AllowAnonymous]
    public Task<IActionResult> LoginAdmin(string username, string password) => _AdminServices.Login(username, password);
}