using DevFreela.Application.Commands.UserSkill;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.UserSkill
{
    public class CreateUserSkillCommandHandler : IRequestHandler<CreateUserSkillCommand>
    {
        public Task<Unit> Handle(CreateUserSkillCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}