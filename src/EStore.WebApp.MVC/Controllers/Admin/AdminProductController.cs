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

            ModelState.Remove("Image");
            ModelState.Remove("ImageUpload");
            if (!ModelState.IsValid) return View(await FillCategories(productDto));
            var imgId = Guid.NewGuid() + "_";
            if (!await UploadFile(productDto.ImageUpload, imgId))
            {
                return View(productDto);
            }

            productDto.Image = imgId + productDto.ImageUpload.FileName;

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

            if (id != productDto.Id) return NotFound(); 

            var productUpdated = await _productAppService.GetById(id);

            productDto.Image = productUpdated.Image;
            productDto.QtyStock = productUpdated.QtyStock;
            ModelState.Remove("QtyStock");


            if (!ModelState.IsValid) return View(await FillCategories(productDto));


            if (productDto.ImageUpload != null)
            {
                var imgId = Guid.NewGuid() + "_";
                if (!await UploadFile(productDto.ImageUpload, imgId))
                {
                    return View(productDto);
                }

                productUpdated.Image = imgId + productDto.ImageUpload.FileName;
            }


            await _productAppService.UpdateProduct(productUpdated);
            
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



        private async Task<bool> UploadFile(IFormFile imagemUpload, string imgId)
        {
            if (imagemUpload.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageS", imgId + imagemUpload.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imagemUpload.CopyToAsync(stream);
            }

            return true;
        }
    }
}
