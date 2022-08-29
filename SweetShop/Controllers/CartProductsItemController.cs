using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Domain;
using SweetShop.Service.Implementations;

namespace SweetShop.Controllers
{
    public class CartProductsItemController : Controller
    {
        public readonly CartProductsItemService _cartProductsItemService;

        public CartProductsItemController(CartProductsItemService cartProductsItemService)
        {
            _cartProductsItemService = cartProductsItemService;
        }

        [HttpGet]
        public async Task<ActionResult> Create(int entityProduct, int count, int cartProductsId)
        {
            var response = await _cartProductsItemService.CreateCartProductsItem(entityProduct, count, cartProductsId);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
                return RedirectToAction("GetCartProducts", "CartProducts");//перенаправить на  добавление в корзину
            return RedirectToAction("Error", "Home");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _cartProductsItemService.DeleteCartProductsItem(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
                return RedirectToAction("GetCartProducts", "CartProducts");
            return RedirectToAction("Error", "Home");
        }


        // GET: CartProductsItemController
        /*public ActionResult Index()
        {
            return View();
        }

        // GET: CartProductsItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartProductsItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartProductsItemController/Create
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

        // GET: CartProductsItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartProductsItemController/Edit/5
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

        // GET: CartProductsItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartProductsItemController/Delete/5
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
