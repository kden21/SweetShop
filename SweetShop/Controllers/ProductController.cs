using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetShop.DAL.Interfaces;
using SweetShop.Domain;
using SweetShop.Service.Interfaces;

namespace SweetShop.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _productService;
   
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync()
        {
            var response = await _productService.GetProducts();
            if(response.StatusCode == Domain.Enums.StatusCode.OK)
                return View(response.Data.ToList());
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> GetProduct(int id)
		{
            
            var response = await _productService.GetProduct(id);
            if(response.StatusCode == Domain.Enums.StatusCode.OK)
                return View(response.Data);
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
		{
            var response = await _productService.DeleteProduct(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
                return RedirectToAction("GetProducts");
            return RedirectToAction("Error", "Home");
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
		{
            if (id == 0)
                return View();
            var response = await _productService.GetProduct(id);
            if(response.StatusCode == Domain.Enums.StatusCode.OK)
		        return View(response.Data);
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(Product model)
        {
            if (ModelState.IsValid)
			{
                if(model.Id == 0)
                    await _productService.CreateProduct(model);
                else
                    await _productService.EditProduct(model.Id, model);                    
			}
            return RedirectToAction("GetProducts");
        }



        // GET: ProductController/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
