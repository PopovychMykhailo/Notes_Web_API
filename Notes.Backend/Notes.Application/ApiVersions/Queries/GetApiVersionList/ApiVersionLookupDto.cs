using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionList
{
    public class ApiVersionLookupDto : IMapWith<ApiVersion>
    {
        public Guid Id { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApiVersion, ApiVersionLookupDto>()
                .ForMember(vDto => vDto.Id, opt => opt.MapFrom(v => v.Id))
                .ForMember(vDto => vDto.Version, opt => opt.MapFrom(v => v.Version))
                .ForMember(vDto => vDto.Description, opt => opt.MapFrom(v => v.Description));
        }
    }
}
