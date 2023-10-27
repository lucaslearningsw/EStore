using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Core.DomainObjects;

namespace EStore.Catalog.Domain
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;


        public StockService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> StockDebit(Guid productId, int qty)
        {
            var product = await _productRepository.GetByID(productId);

            if (product == null) return false;

            if(!product.HasStock(qty)) return false;

            product.DebitStock(qty);

            _productRepository.Update(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> StockReplenishment(Guid productId, int qty)
        {
            var product = await _productRepository.GetByID(productId);

            if (product == null) return false;

            product.ReplaceStock(qty);

            _productRepository.Update(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
           _productRepository.Dispose();
        }
    }
}