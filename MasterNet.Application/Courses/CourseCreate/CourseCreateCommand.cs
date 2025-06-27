using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Courses.CourseCreate;

public class CourseCreateCommand
{
    public record CourseCreateCommandRequest(CourseCreateRequest CourseCreateRequest) 
        : IRequest<Result<Guid>>;

    internal class CourseCreateCommandHandler
        : IRequestHandler<CourseCreateCommandRequest, Result<Guid>>
    {
        private readonly MasterNetDbContext _masterNetDbContext;

        public CourseCreateCommandHandler(MasterNetDbContext masterNetDbContext)
        {
            _masterNetDbContext = masterNetDbContext;
        }

        public async Task<Result<Guid>> Handle(
            CourseCreateCommandRequest request, 
            CancellationToken cancellationToken
        )
        {
            var course = new Course
            {
                Id = new Guid(),
                Title = request.CourseCreateRequest.Title,
                Description = request.CourseCreateRequest.Description,
                PublicationDate = request.CourseCreateRequest.DatePublication,
            };

            _masterNetDbContext.Add(course);
            bool result = await _masterNetDbContext.SaveChangesAsync(cancellationToken) > 0;

            return result
                ? Result<Guid>.Success(course.Id)
                : Result<Guid>.Failure("No se pudo insertar el curso");
        }
    }
}