using FluentValidation;
using System;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionList
{
    public class GetApiVersionListQueryValidator : AbstractValidator<GetApiVersionListQuery>
    {
        public GetApiVersionListQueryValidator()
        {
            //RuleFor(apiVersionList => apiVersionList.!= null);
        }
    }
}
