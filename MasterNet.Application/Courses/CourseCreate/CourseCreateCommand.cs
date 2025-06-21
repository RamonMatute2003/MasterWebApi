using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Courses.CourseCreate;

public class CourseCreateCommand
{
    public record CourseCreateCommandRequest(CourseCreateRequest CourseCreateRequest) : IRequest<Guid>;

    internal class CourseCreateCommandHandler
        : IRequestHandler<CourseCreateCommandRequest, Guid>
    {
        private readonly MasterNetDbContext _masterNetDbContext;

        public CourseCreateCommandHandler(MasterNetDbContext masterNetDbContext)
        {
            _masterNetDbContext = masterNetDbContext;
        }

        public async Task<Guid> Handle(
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
            await _masterNetDbContext.SaveChangesAsync(cancellationToken);

            return course.Id;
        }
    }
}