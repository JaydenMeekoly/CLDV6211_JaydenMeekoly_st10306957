using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class UserController : Controller
    {
        public Table_1 tbl1 = new Table_1();

        [HttpPost]
        public ActionResult About(Table_1 Users)
        {
            var result = tbl1.InsertUser(Users);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult About()
        {
            return View("~/Views/Users/About.cshtml",tbl1);
        }
        
    }
}
