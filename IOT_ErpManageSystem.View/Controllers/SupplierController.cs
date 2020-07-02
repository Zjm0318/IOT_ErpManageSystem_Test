using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers
{
    public class SupplierController : Controller
    {
        //显示
        public IActionResult Index()
        {
            return View();
        }

        //添加
        public IActionResult Add()
        {
            return View();
        }

        //修改
        public IActionResult Edit(string id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}