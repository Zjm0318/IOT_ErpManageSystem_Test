using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers
{
    public class PurShowController : Controller
    {
        //采购单显示
        public IActionResult GetPurList()
        {
            return View();
        }

        //反填采购单信息
        public IActionResult FanTPur(string CId, string Id)
        {
            ViewBag.CId = CId;
            ViewBag.Id = Id;
            return View();
        }

        //添加采购单信息
        public IActionResult AddPur()
        {
            return View();
        }
    }
}