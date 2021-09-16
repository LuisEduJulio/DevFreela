using DevFreela.Application.Commands.Projects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.CommandHandlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}