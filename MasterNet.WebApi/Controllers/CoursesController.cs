using MasterNet.Application.Core;
using MasterNet.Application.Courses.CourseCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Courses.CourseCreate.CourseCreateCommand;
using static MasterNet.Application.Courses.CourseReportExcel.CourseReportExcelQuery;

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
    public async Task<Result<Guid>> CourseCreate(
        [FromForm] CourseCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CourseCreateCommandRequest(request);
        return await _sender.Send(command, cancellationToken);
    }

    [HttpGet("report")]
    public async Task<ActionResult> ReportCsv(CancellationToken cancellationToken)
    {
        var query = new CourseReportExcelQueryRequest();
        var result = await _sender.Send(query, cancellationToken);
        byte[] excelBytes = result.ToArray();

        return File(excelBytes, "text/csv", "cursos.csv");
    }
}