using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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