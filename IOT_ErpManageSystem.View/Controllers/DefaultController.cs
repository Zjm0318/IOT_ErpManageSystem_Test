using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.View.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //jwt登录
        public IActionResult Log()
        {
            return View();
        }
        //个人信息
        public IActionResult Personage()
        {
            return View();
        }
        //订单报表
        public IActionResult Order()
        {
            return View();
        }
        //商品价格本
        public IActionResult ProPrice()
        {
            return View();
        }
        //添加商品价格本
        public IActionResult AddPrice()
        {
            return View();
        }
        public IActionResult Update(string GId, string PId)
        {
            GId = GId.Trim('/');
            ViewBag.gId = GId;
            PId = PId.Trim('/');
            ViewBag.pId = PId;
            return View();
        }
    }
}