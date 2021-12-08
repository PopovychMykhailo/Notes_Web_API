using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionDetails
{
    public class GetApiVersionDetailsQueryHandler 
        : IRequestHandler<GetApiVersionDetailsQuery, ApiVersionDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApiVersionDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ApiVersionDetailsVm> Handle(GetApiVersionDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ApiVersions
                .FirstOrDefaultAsync(version => version.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(request), entity.Version);
            }

            return _mapper.Map<ApiVersionDetailsVm>(entity);
        }
    }
}
