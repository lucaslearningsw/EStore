using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Core.Data;

namespace EStore.Catalog.Domain
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByID(Guid id);
        Task<IEnumerable<Product>> GetByCategory(Guid id);
        Task<IEnumerable<Category>> GetCategorys();

        void Add(Product product);
        void Update(Product product);
        void Add(Category category);
        void Update(Category category);
    }
}
