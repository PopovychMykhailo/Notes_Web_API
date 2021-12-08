using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionList
{
    public class GetApiVersionListQueryHandler :
        IRequestHandler<GetApiVersionListQuery, ApiVersionListVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApiVersionListQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ApiVersionListVm> Handle(GetApiVersionListQuery request
            , CancellationToken cancellationToken)
        {
            var apiVersionList = await _dbContext.ApiVersions
                .ProjectTo<ApiVersionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new ApiVersionListVm() { ApiVersions = apiVersionList };
        }

    }
}
