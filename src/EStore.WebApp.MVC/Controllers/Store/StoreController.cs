using EStore.Catalog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStore.WebApp.MVC.Controllers.Store
{
    public class StoreController : Controller
    {

        private readonly IProductAppService _productAppService;

        public StoreController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }

        [HttpGet]
        [Route("store-products/{id}")]
        public async Task<IActionResult> ProductDetails(Guid id)
        {
            return View(await _productAppService.GetById(id));
        }


    }
}
