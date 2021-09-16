using MediatR;

namespace DevFreela.Application.Commands.ProjectComment
{
    public class CreateCommentCommand : IRequest
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}