
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodtbl = new productTable();



        [HttpPost]
        public IActionResult MyWork(productTable products)
        {
            var result2 = prodtbl.Insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}