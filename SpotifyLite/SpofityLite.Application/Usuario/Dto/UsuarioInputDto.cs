using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Dto
{
    public record UsuarioInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")] string Nome,
        [Required(ErrorMessage = "Email é obrigatório")] string Email,
        [Required(ErrorMessage = "Password é obrigatório")] string Password);
    public record UsuarioOutputDto(Guid Id, string Nome, string Email, string Password);

}