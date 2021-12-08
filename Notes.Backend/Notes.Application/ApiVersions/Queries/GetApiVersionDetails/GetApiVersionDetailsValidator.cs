using System;
using FluentValidation;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionDetails
{
    public class GetApiVersionDetailsValidator : AbstractValidator<GetApiVersionDetailsQuery>
    {
        public GetApiVersionDetailsValidator()
        {
            RuleFor(version => version.Id).NotEqual(Guid.Empty);
        }
    }
}
