using SpotifyLite.Domain.Album;
using System.ComponentModel.DataAnnotations;

namespace SpofityLite.Application.Usuario.Dto
{
    public record UsuarioInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")] string Nome,
        [Required(ErrorMessage = "Email é obrigatório")] string Email,
        [Required(ErrorMessage = "Password é obrigatório")] string Password);
    public record UsuarioOutputDto(Guid Id, string Nome, string Email, string Password);

    public record PlaylistInputDto(List<Musica> Musicas);
    public record PlaylistOutputDto(Guid Id, List<Musica> Musicas);
}