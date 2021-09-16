using DevFreela.Application.Commands.UserSkill;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.UserSkill
{
    public class UpdateUserSkillCommandHandler : IRequestHandler<UpdateUserSkillCommand>
    {
        public Task<Unit> Handle(UpdateUserSkillCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}