using AutoMapper;
using Moq;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;

namespace SpotifyLite.Test.Application
{
    public class BandaServiceTests
    {
        [Fact]
        public async Task DeveCriarBandaComSucesso()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            BandaInputDto dtoInput = new("XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            BandaOutputDto dtoOutput = new(guid, "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            Mock<IBandaRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Banda banda = new()
            {
                Descricao = "Lorem Ipsom",
                Foto = "lorem ipsum",
                Nome = "Xpto"
            };
            mockMapper.Setup(x => x.Map<Banda>(dtoInput)).Returns(banda);
            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Save(It.IsAny<Banda>())).Returns(Task.FromResult(banda));

            //Act
            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dtoInput);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal("XTPO", result.Nome);
            Assert.Equal("https://xpto.com/foto.png", result.Foto);
            Assert.Equal("Lorem ipsum da banda", result.Descricao);
        }

        [Fact]
        public async Task DeveObterBandaComSucesso()
        {
            //Arrange
            Guid guid = new();
            BandaInputDto dtoInput = new("XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            BandaOutputDto dtoOutput = new(guid, "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            Mock<IBandaRepository> mockRepository = new();
            Mock<IMapper> mockMapper = new();
            Banda banda = new()
            {
                Descricao = "Lorem ipsum da banda",
                Foto = "https://xpto.com/foto.png",
                Nome = "XTPO"
            };
            mockMapper.Setup(x => x.Map<Banda>(dtoInput)).Returns(banda);
            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(dtoOutput);
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(banda));

            //Act
            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Obter(guid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
            Assert.Equal("XTPO", result.Nome);
            Assert.Equal("https://xpto.com/foto.png", result.Foto);
            Assert.Equal("Lorem ipsum da banda", result.Descricao);
        }
    }
}
