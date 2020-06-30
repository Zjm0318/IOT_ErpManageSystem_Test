using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers.StorageManage
{
    public class InStorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Emp()
        {
            return View();
        }
    }
}