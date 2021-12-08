using System.Collections.Generic;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionList
{
    public class ApiVersionListVm
    {
        public IList<ApiVersionLookupDto> ApiVersions { get; set; }
    }
}
