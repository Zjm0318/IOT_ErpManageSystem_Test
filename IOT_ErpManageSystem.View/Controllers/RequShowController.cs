using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers
{
    public class RequShowController : Controller
    {

        //显示
        public IActionResult GetRequList()
        {
            return View();
        }
        //显示指派员工
        public IActionResult GetRoleList(string QgId)
        {
            ViewBag.QgId = QgId;
            return View();
        }

        //添加
        public IActionResult GetAddRequ()
        {
            return View();
        }

        //反填信息
        public IActionResult FanTRequList(string QId, string QgId)
        {
            ViewBag.QId = QId;
            ViewBag.QgId = QgId;
            return View();
        }
    }
}