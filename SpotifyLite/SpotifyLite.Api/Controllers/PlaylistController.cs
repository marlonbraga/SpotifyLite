using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Usuario.Dto;
using SpotifyLite.Application.Usuario.Handler.Command;
using SpotifyLite.Application.Usuario.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlaylistController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery(Name = "page")] string page = "1")
        {
            var result = await this.mediator.Send(new GetAllPlaylistQuery());
            return Ok(result);
        }

        [Route("{id?}")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await this.mediator.Send(new GetPlaylistQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PlaylistInputDto dto)
        {
            var result = await this.mediator.Send(new CreatePlaylistCommand(dto));
            return Created($"{result.Playlist.Id}", result.Playlist);
        }

        [Route("{id?}")]
        [HttpPut]
        public async Task<IActionResult> Editar(Guid id, PlaylistInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await this.mediator.Send(new EditPlaylistCommand(id, dto));

            return Ok(result);
        }

        [Route("{id?}")]
        [HttpDelete]
        public async Task<IActionResult> Deletar(Guid id)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            await this.mediator.Send(new DeletePlaylistCommand(id));

            return NoContent();
        }
    }
}
