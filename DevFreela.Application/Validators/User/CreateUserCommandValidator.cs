using DevFreela.Application.Commands.Projects;
using FluentValidation;

namespace DevFreela.Application.Validators.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
        }
    }
}