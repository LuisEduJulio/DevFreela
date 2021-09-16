using DevFreela.Application.Commands.Skill;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.Skill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, int>
    {
        public Task<int> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}