using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EStore.Catalog.Application.Dtos;
using EStore.Catalog.Domain;

namespace EStore.Catalog.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Height, o => o.MapFrom(s => s.Dimensions.Height))
                .ForMember(d => d.Profundity, o => o.MapFrom(s => s.Dimensions.Profundity))
                .ForMember(d => d.Width, o => o.MapFrom(s => s.Dimensions.Width));

            CreateMap<Category, CategoryDto>();
        }
    }

}
