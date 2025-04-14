using MasterNet.Application.Courses.CourseCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Courses.CourseCreate.CourseCreateCommand;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/controller")]
public class CoursesController : ControllerBase
{
    private readonly ISender _sender;

    public CoursesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("createCourse")]
    public async Task<ActionResult<Guid>> CourseCreate(
        [FromForm] CourseCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CourseCreateCommandRequest(request);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }
}