using AutoMapper;
using Moq;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Domain.Album.ValueObject;

namespace SpotifyLite.Test.Application
{
    public class MusicaServiceTests
    {
        [Fact]
        public async Task DeveCriarMusicaComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            string nome = "XTPO";
            int duracao = 336;
            MusicaInputDto dtoInput = new(nome, duracao);
            MusicaOutputDto dtoOutput = new(guid, nome, duracao.ToString());
            Mock<IMusicaRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Musica musica = new()
            {
                Duracao = new Duracao(duracao),
                Nome = nome
            };
            mockMapper.Setup(x => x.Map<Musica>(dtoInput)).Returns(musica);
            mockMapper.Setup(x => x.Map<MusicaOutputDto>(musica)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Save(It.IsAny<Musica>())).Returns(Task.FromResult(musica));

            //Act
            var service = new MusicaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dtoInput);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal(nome, result.Nome);
            Assert.Equal(duracao.ToString(), result.Duracao);
        }

        [Fact]
        public async Task DeveObterMusicaComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            string nome = "XTPO";
            int duracao = 336;
            MusicaInputDto dtoInput = new(nome, duracao);
            MusicaOutputDto dtoOutput = new(guid, nome, duracao.ToString());
            Mock<IMusicaRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Musica musica = new()
            {
                Duracao = new Duracao(duracao),
                Nome = nome
            };
            mockMapper.Setup(x => x.Map<Musica>(dtoInput)).Returns(musica);
            mockMapper.Setup(x => x.Map<MusicaOutputDto>(musica)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(musica));

            //Act
            var service = new MusicaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Obter(guid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal(nome, result.Nome);
            Assert.Equal(duracao.ToString(), result.Duracao);
        }
    }
}
