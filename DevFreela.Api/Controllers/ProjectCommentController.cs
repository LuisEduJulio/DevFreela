using DevFreela.Application.Commands.ProjectComment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostCommentAsync(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}