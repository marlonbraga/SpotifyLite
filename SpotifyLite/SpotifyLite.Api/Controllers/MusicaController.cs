using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMediator mediator;

        public MusicaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await this.mediator.Send(new GetAllMusicaQuery());
            return Ok(result);
        }

        [Route("{id?}")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await this.mediator.Send(new GetMusicaQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(MusicaInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await this.mediator.Send(new CreateMusicaCommand(dto));

            return Created($"/{result.Musica.Id}", result);
        }

        [Route("{id?}")]
        [HttpPut]
        public async Task<IActionResult> Editar(Guid id, MusicaInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await this.mediator.Send(new EditMusicaCommand(id, dto));

            return Ok(result);
        }

        [Route("{id?}")]
        [HttpDelete]
        public async Task<IActionResult> Deletar(Guid id)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            await this.mediator.Send(new DeleteMusicaCommand(id));

            return NoContent();
        }
    }
}
