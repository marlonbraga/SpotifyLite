using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class CreateMusicaCommand : IRequest<CreateMusicaCommandResponse>
    {
        public MusicaInputDto Musica { get; set; }

        public CreateMusicaCommand(MusicaInputDto Musica)
        {
            this.Musica = Musica;
        }
    }

    public class CreateMusicaCommandResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public CreateMusicaCommandResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
