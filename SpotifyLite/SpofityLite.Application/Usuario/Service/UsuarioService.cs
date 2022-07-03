using AutoMapper;
using SpofityLite.Application.Usuario.Dto;
using SpotifyLite.Domain.Account.Repository;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<SpotifyLite.Domain.Account.Usuario>(dto);

            await this.usuarioRepository.Save(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Editar(Guid id, UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<SpotifyLite.Domain.Account.Usuario>(dto);
            usuario.Id = id;
            await this.usuarioRepository.Update(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Obter(Guid id)
        {
            var result = await this.usuarioRepository.Get(id);

            return this.mapper.Map<UsuarioOutputDto>(result);
        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var result = await this.usuarioRepository.GetAll();

            return this.mapper.Map<List<UsuarioOutputDto>>(result);
        }

        public async Task Deletar(Guid id)
        {
            var usuario = await this.usuarioRepository.Get(id);
            await this.usuarioRepository.Delete(usuario);
        }
    }
}