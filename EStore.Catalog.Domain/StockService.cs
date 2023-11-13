using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Catalog.Domain.Events;
using EStore.Catalog.Domain.Interfaces;
using EStore.Core.DomainObjects;
using EStore.Core.Mediatr;

namespace EStore.Catalog.Domain
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;

        private  readonly  IMediatrHandler _mediatrEvents;
        public StockService(IProductRepository productRepository, IMediatrHandler mediatrHandler)
        {
            _productRepository = productRepository;
            _mediatrEvents = mediatrHandler;
        }

        public async Task<bool> StockDebit(Guid productId, int qty)
        {
            var product = await _productRepository.GetByID(productId);

            if (product == null) return false;

            if(!product.HasStock(qty)) return false;

            product.DebitStock(qty);

            //TODO: parametizer qty 
            if (product.QtyStock < 20)
            {
                await _mediatrEvents.PublishEvent(new EventProductDropStock(product.Id, product.QtyStock));
            }

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