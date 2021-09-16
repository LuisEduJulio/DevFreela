using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Projects
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
