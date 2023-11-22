using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Catalog.Application.Dtos;

namespace EStore.Catalog.Application.Services
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductDto>> GetByCategory(Guid id);

        Task<IEnumerable<ProductDto>> GetAll();

        Task<ProductDto> GetById(Guid id);

        Task<IEnumerable<CategoryDto>> GetAllCategories();


        Task AddProduct(ProductDto productDto);

        Task UpdateProduct(ProductDto productDto);

        Task<ProductDto> ReplenishmentStock(Guid id, int qty);

        Task<ProductDto> DebitStock(Guid id, int qty);
    }
}
