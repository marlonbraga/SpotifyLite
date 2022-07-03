using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Usuario.Dto;
using SpotifyLite.Application.Usuario.Handler.Command;
using SpotifyLite.Application.Usuario.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery(Name = "page")] string page="1")
        {
            var result = await this.mediator.Send(new GetAllUsuarioQuery());
            return Ok(result);
        }

        [Route("{id?}")]
        [HttpGet]
        public async Task<IActionResult> Obter(Guid id)
        {
            var result = await this.mediator.Send(new GetUsuarioQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await this.mediator.Send(new CreateUsuarioCommand(dto));

            return Created($"/{result.Usuario.Id}", result);
        }

        [Route("{id?}")]
        [HttpPut]
        public async Task<IActionResult> Editar(Guid id, UsuarioInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await this.mediator.Send(new EditUsuarioCommand(id, dto));

            return Ok(result);
        }

        [Route("{id?}")]
        [HttpDelete]
        public async Task<IActionResult> Deletar(Guid id)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            await this.mediator.Send(new DeleteUsuarioCommand(id));

            return NoContent();
        }
    }
}