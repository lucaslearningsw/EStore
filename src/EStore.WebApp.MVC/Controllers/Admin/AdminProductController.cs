using EStore.Catalog.Application.Dtos;
using EStore.Catalog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public AdminProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("admin-product")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }

        [HttpGet]
        [Route("new-product")]
        public async Task<IActionResult> NewProduct()
        {
            return View(await FillCategories(new ProductDto()));
        }

        [HttpPost]
        [Route("new-product")]
        public async Task<IActionResult> NewProduct(ProductDto productDto)
        {

            if(!ModelState.IsValid) return View(await FillCategories(productDto));

            await _productAppService.AddProduct(productDto);

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            return View(await FillCategories(await _productAppService.GetById(id)));

        }

        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto productDto)
        {
            var product = await _productAppService.GetById(id);
            productDto.QtyStock = product.QtyStock;

            ModelState.Remove("QtyStock");
            if(!ModelState.IsValid) return View(await FillCategories(productDto));

            await _productAppService.UpdateProduct(productDto);
            
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("update-stock-product")]
        public async Task<IActionResult> UpdateStock(Guid id, int qty)
        {
            if (qty > 0)
            {
                await _productAppService.ReplenishmentStock(id, qty);
            }
            else 
            {
                await _productAppService.DebitStock(id, qty);
            }

            return View("index",await _productAppService.GetAll());
        }


        [HttpGet]
        [Route("update-stock-product")]
        public async Task<IActionResult> UpdateStock(Guid id)
        {
            
            return View("Stock", await _productAppService.GetById(id));
        }



        private async Task<ProductDto> FillCategories(ProductDto productDto)
        {
            productDto.Categories = await _productAppService.GetAllCategories();
            return productDto;
        }
    }
}
