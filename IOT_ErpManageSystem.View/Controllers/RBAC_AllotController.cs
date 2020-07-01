using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers
{
    public class RBAC_AllotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //员工添加
        public IActionResult Add()
        {
            return View();
        }

        //员工编辑
        public IActionResult Edit(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}