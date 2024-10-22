using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraphqlServer.Controllers;

[Route("api/auth")]
[Authorize]
public class AuthController : ControllerBase
{
    public string Test()
    {
        return $"Auth werkt! {DateTime.Now.ToLongTimeString()} - is authed? {User.Identity.IsAuthenticated} - {User.Identity?.Name}";
    }
}
