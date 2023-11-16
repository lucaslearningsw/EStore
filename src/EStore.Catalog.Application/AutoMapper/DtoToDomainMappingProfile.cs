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
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProductDto, Product>()
                .ConstructUsing(p => new Product(p.Name, p.Description, p.Active, p.Price,p.CategoryId,p.DateTimeCreation,p.Image,
                    new Dimensions(p.Height, p.Width, p.Profundity)));

            CreateMap<CategoryDto, Category>()
                .ConstructUsing(c => new Category(c.Name, c.Code));
        }
    }
}
