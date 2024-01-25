using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorSozluk.Api.WebApi.Controllers;
[Route("Api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public Guid? UserId=>new (HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
   
}