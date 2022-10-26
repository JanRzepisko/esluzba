using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace esluzba.Controllers;

[ApiController]
[Authorize]
[Route("api/identity")]
public class IdentityController
{
    
}