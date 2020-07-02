using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers
{
    public class RBAC_RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //添加权限
        public IActionResult Add()
        {
            return View();
        }

        //编辑权限
        public IActionResult Edit(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }

    }
}