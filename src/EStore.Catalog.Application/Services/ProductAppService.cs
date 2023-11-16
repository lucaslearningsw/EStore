using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EStore.Catalog.Application.Dtos;
using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Interfaces;
using EStore.Core.DomainObjects;

namespace EStore.Catalog.Application.Services
{
    public class ProductAppService : IProductAppService
    {
       
        private readonly IProductRepository _productRepository;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public ProductAppService(IProductRepository productRepository,
                               IStockService stockService, IMapper mapper)
        {
            _productRepository = productRepository;
            _stockService = stockService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetByCategory(Guid id)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetByCategory(id));
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll());
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetByID(id));
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _productRepository.GetCategories());
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task<ProductDto> ReplenishmentStock(Guid id, int qty)
        {

            if (!await _stockService.ReplenishmentStock(id, qty))
            {
                throw new DomainException("Falha ao repor estoque");
            }

            return _mapper.Map<ProductDto>(await _productRepository.GetByID(id));
        }

        public async Task<ProductDto> DebitStock(Guid id, int qty)
        {
            if (!await _stockService.DebitStock(id, qty))
            {
                throw new DomainException("Falha ao debitar estoque"); 
            }

            return _mapper.Map<ProductDto>(await _productRepository.GetByID(id));
        }

        public void Dispose()
        {
           _productRepository?.Dispose();
           _stockService?.Dispose();
        }
    }
}
