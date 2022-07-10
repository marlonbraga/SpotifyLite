using MediatR;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;

namespace SpofityLite.Application.Album.Handler
{
    public class BandaHandler : IRequestHandler<CreateBandaCommand, CreateBandaCommandResponse>,
                                IRequestHandler<GetAllBandaQuery, GetAllBandaQueryResponse>,
                                IRequestHandler<GetBandaQuery, GetBandaQueryResponse>,
                                IRequestHandler<DeleteBandaCommand, DeleteBandaCommandResponse>,
                                IRequestHandler<EditBandaCommand, EditBandaCommandResponse>
    {
        private readonly IBandaService _bandaService;

        public BandaHandler(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public async Task<CreateBandaCommandResponse> Handle(CreateBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Criar(request.Banda);
            return new CreateBandaCommandResponse(result);
        }

        public async Task<GetAllBandaQueryResponse> Handle(GetAllBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.ObterTodos();
            return new GetAllBandaQueryResponse(result);
        }

        public async Task<GetBandaQueryResponse> Handle(GetBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Obter(request.IdBanda);
            return new GetBandaQueryResponse(result);
        }

        public async Task<DeleteBandaCommandResponse> Handle(DeleteBandaCommand request, CancellationToken cancellationToken)
        {
            await this._bandaService.Deletar(request.IdBanda);
            return new DeleteBandaCommandResponse();
        }

        public async Task<EditBandaCommandResponse> Handle(EditBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Editar(request.IdBanda, request.Banda);
            return new EditBandaCommandResponse(result);
        }
    }
}
