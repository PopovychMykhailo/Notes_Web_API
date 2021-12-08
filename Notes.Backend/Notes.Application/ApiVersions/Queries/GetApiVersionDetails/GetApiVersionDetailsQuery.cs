using MediatR;
using System;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionDetails
{
    public class GetApiVersionDetailsQuery : IRequest<ApiVersionDetailsVm>
    {
        public Guid Id { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}
