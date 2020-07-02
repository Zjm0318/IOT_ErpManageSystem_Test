using Microsoft.AspNetCore.Mvc;
using System;

namespace IOT_ErpManageSystem.View.Controllers.StorageManage
{
    public class OutStorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddOutStorage()
        {
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            ViewBag.Time = time;
            return View();
        }
    }
}