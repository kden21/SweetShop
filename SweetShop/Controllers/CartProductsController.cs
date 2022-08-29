using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Service.Implementations;

namespace SweetShop.Controllers
{
    public class CartProductsController : Controller
    {
        readonly CartProductsService _cartProductsServise;
        public CartProductsController(CartProductsService cartProductsServise)
        {
            _cartProductsServise = cartProductsServise;
        }

        [HttpGet]
        public async Task<ActionResult> GetCartProducts(int id = 1)
        {
            var response = await _cartProductsServise.GetCart(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
                return View(response.Data);
            return RedirectToAction("Error", "Home");
        }





        // GET: CartProducts
        /*public ActionResult Index()
        {
            return View();
        }

        // GET: CartProducts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartProducts/Create
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

        // GET: CartProducts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartProducts/Edit/5
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

        // GET: CartProducts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartProducts/Delete/5
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
