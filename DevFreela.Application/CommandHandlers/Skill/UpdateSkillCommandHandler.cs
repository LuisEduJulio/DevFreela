using DevFreela.Application.Commands.Skill;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.Skill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand>
    {
        public Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}