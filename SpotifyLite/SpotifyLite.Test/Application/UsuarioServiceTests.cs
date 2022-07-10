using AutoMapper;
using Moq;
using SpofityLite.Application.Usuario.Dto;
using SpofityLite.Application.Usuario.Service;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using SpotifyLite.Domain.Account.ValueObject;

namespace SpotifyLite.Test.Application
{
    public class UsuarioServiceTests
    {
        [Fact]
        public async Task DeveCriarUsuarioComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            string nome = "Tibúrcio";
            string email = "tibu@email.com";
            string password = "*********";
            UsuarioInputDto dtoInput = new(nome, email, password);
            UsuarioOutputDto dtoOutput = new(guid, nome, email, password);
            Mock<IUsuarioRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Usuario usuario = new()
            {
                Nome = nome,
                Email = new Email(email),
                Password = new Password(password)
            };
            mockMapper.Setup(x => x.Map<Usuario>(dtoInput)).Returns(usuario);
            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Save(It.IsAny<Usuario>())).Returns(Task.FromResult(usuario));

            //Act
            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dtoInput);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal(nome, result.Nome);
            Assert.Equal(email, result.Email);
            Assert.Equal(password, result.Password);
        }

        [Fact]
        public async Task DeveObterUsuarioComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            string nome = "Tibúrcio";
            string email = "tibu@email.com";
            string password = "********";
            UsuarioInputDto dtoInput = new(nome, email, password);
            UsuarioOutputDto dtoOutput = new(guid, nome, email, password);
            Mock<IUsuarioRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Usuario usuario = new()
            {
                Nome = nome,
                Email = new Email(email),
                Password = new Password(password)
            };
            mockMapper.Setup(x => x.Map<Usuario>(dtoInput)).Returns(usuario);
            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(usuario));

            //Act
            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.Obter(guid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal(nome, result.Nome);
            Assert.Equal(email, result.Email);
            Assert.Equal(password, result.Password);
        }
    }
}
