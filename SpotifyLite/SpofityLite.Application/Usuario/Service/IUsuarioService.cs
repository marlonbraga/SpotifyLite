using SpofityLite.Application.Usuario.Dto;

namespace SpofityLite.Application.Usuario.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Obter(Guid id);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<UsuarioOutputDto> Editar(Guid id, UsuarioInputDto dto);
        Task Deletar(Guid id);
    }
}