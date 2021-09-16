using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [Route("api/projects")]
    public class UserSkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserSkillController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}