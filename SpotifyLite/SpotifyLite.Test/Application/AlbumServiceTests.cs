using AutoMapper;
using Moq;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Domain.Album.ValueObject;

namespace SpotifyLite.Test.Application
{
    public class AlbumServiceTests
    {
        [Fact]
        public async Task DeveCriarAlbumComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            string dummyNome = "XTPO";
            DateTime dummyDate = DateTime.Now;
            string dummyBackdrop = "Lorem ipsum do album";
            string dummyNomeMusica = "Nome-Musica";
            int dummyNomeDuracao = 400;
            List<MusicaInputDto> dummyInputMusicas = new() { new MusicaInputDto(dummyNomeMusica, dummyNomeDuracao) };
            List<MusicaOutputDto> dummyOutputMusicas = new() { new MusicaOutputDto(guid, dummyNomeMusica, dummyNomeDuracao.ToString()) };
            AlbumInputDto dtoInput = new(dummyNome, dummyDate, dummyBackdrop, dummyInputMusicas);
            AlbumOutputDto dtoOutput = new(guid, dummyNome, dummyDate, dummyBackdrop, dummyOutputMusicas);
            Mock<IAlbumRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Album album = new()
            {
                Nome = dummyNome,
                DataLancamento = dummyDate,
                Backdrop = dummyBackdrop,
                Musicas = new List<Musica>() {
                    new Musica()
                    {
                        Nome = dummyNomeMusica,
                        Duracao = new Duracao(400)
                    }
                }
            };
            mockMapper.Setup(x => x.Map<Album>(dtoInput)).Returns(album);
            mockMapper.Setup(x => x.Map<AlbumOutputDto>(album)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Save(It.IsAny<Album>())).Returns(Task.FromResult(album));

            //Act
            var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dtoInput);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal(dummyNome, result.Nome);
            Assert.Equal(dummyDate, result.DataLancamento);
            Assert.Equal(dummyBackdrop, result.Backdrop);
            Assert.Equal(guid, result.Musicas[0].Id);
            Assert.Equal(dummyNomeMusica, result.Musicas[0].Nome);
            Assert.Equal(dummyNomeDuracao.ToString(), result.Musicas[0].Duracao);
        }

        [Fact]
        public async Task DeveObterAlbumComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            string dummyNome = "XTPO";
            DateTime dummyDate = DateTime.Now;
            string dummyBackdrop = "Lorem ipsum do album";
            string dummyNomeMusica = "Nome-Musica";
            int dummyNomeDuracao = 400;
            List<MusicaInputDto> dummyInputMusicas = new() { new MusicaInputDto(dummyNomeMusica, dummyNomeDuracao) };
            List<MusicaOutputDto> dummyOutputMusicas = new() { new MusicaOutputDto(guid, dummyNomeMusica, dummyNomeDuracao.ToString()) };
            AlbumInputDto dtoInput = new(dummyNome, dummyDate, dummyBackdrop, dummyInputMusicas);
            AlbumOutputDto dtoOutput = new(guid, dummyNome, dummyDate, dummyBackdrop, dummyOutputMusicas);
            Mock<IAlbumRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Album album = new()
            {
                Nome = dummyNome,
                DataLancamento = dummyDate,
                Backdrop = dummyBackdrop,
                Musicas = new List<Musica>() {
                    new Musica()
                    {
                        Nome = dummyNomeMusica,
                        Duracao = new Duracao(400)
                    }
                }
            };
            mockMapper.Setup(x => x.Map<Album>(dtoInput)).Returns(album);
            mockMapper.Setup(x => x.Map<AlbumOutputDto>(album)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(album));

            //Act
            var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            var result = await service.Obter(guid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal(dummyNome, result.Nome);
            Assert.Equal(dummyDate, result.DataLancamento);
            Assert.Equal(dummyBackdrop, result.Backdrop);
            Assert.Equal(guid, result.Musicas[0].Id);
            Assert.Equal(dummyNomeMusica, result.Musicas[0].Nome);
            Assert.Equal(dummyNomeDuracao.ToString(), result.Musicas[0].Duracao);
        }
    }
}
