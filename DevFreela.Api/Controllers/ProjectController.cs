using DevFreela.Application.Commands.Projects;
using DevFreela.Application.Queries.Projects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            if (!projects.Any()) return NotFound();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProjectCommand command)
        {
            if (command.Title?.Length > 50) return BadRequest();

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdAsync), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description?.Length > 50) return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartAsync(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> FinishAsync(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}