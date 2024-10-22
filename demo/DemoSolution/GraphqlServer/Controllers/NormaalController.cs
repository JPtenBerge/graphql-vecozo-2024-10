using Microsoft.AspNetCore.Mvc;

namespace GraphqlServer.Controllers;

[Route("api/normaal")]
public class NormaalController : ControllerBase
{
    public string Test()
    {
        return $"Normaal werkt! {DateTime.Now.ToLongTimeString()}";
    }
}
