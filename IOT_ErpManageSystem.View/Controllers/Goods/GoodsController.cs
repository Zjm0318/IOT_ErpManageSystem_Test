using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOT_ErpManageSystem.View.Controllers.Goods
{
    public class GoodsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddProperty()
        {
            return View();
        }

        public IActionResult GoodsPriceInfo()
        {
            return View();
        }
        public IActionResult AddPrice()
        {
            return View();
        }
    }
}
