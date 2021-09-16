using DevFreela.Application.Commands.Skill;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.Skill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand>
    {
        public Task<Unit> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}