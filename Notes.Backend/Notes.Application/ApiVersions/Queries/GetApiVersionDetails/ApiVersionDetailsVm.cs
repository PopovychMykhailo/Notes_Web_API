using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.ApiVersions.Queries.GetApiVersionDetails
{
    public class ApiVersionDetailsVm : IMapWith<ApiVersion>
    {
        public Guid Id { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApiVersionDetailsVm, ApiVersion>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(apiV => apiV.Id))
                .ForMember(vm => vm.Version, opt => opt.MapFrom(apiV => apiV.Version))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(apiV => apiV.Description));
        }
    }
}
