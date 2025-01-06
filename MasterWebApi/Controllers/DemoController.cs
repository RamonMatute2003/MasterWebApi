using Microsoft.AspNetCore.Mvc;

namespace MasterWebApi.Controllers;

[ApiController]
[Route("Demo")]
public class DemoController : ControllerBase
{
    [HttpGet("getstring")]
    public string GetName()
    {
        return "Ariel";
    }
}