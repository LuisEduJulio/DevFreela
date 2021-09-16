using DevFreela.Application.Commands.ProjectComment;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.ProjectComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IProjectCommentRepository _projectCommentRepository;

        public CreateCommentCommandHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdUser, request.IdProject);

            await _projectCommentRepository.AddAsync(comment);

            return Task.FromResult(Unit.Value);
        }
    }
}