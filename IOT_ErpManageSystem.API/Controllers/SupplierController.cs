using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_ErpManageSystem.BLL;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.BLL.Supplier;
using IOT_ErpManageSystem.API.SupplierViewModel;

namespace IOT_ErpManageSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierBLL _bll;
        public SupplierController(ISupplierBLL bll)
        {
            _bll = bll;
        }

        //显示、查询供应商
        [HttpPost]
        public SupperViewModel GetSuppliers([FromForm]SupperModel m)
        {
            //定义
            int rowCount = 0;
            //获取数据
            List<SupplierInfo> lst = _bll.GetSupplier(m, ref rowCount);
            //总页数
            int count = (rowCount / m.PageSize) + (rowCount % m.PageSize > 0 ? 1 : 0);
            //实例化取值
            SupperViewModel model = new SupperViewModel
            {
                list = lst,
                rowCount = count,
            };
            //返回
            return model;
        }

        //获取反填数据
        [HttpGet]
        public SupAndCon ShowSup(string id)
        {
            return _bll.ShowSupAndCon(id);
        }

        //添加供应商和联系人
        [HttpPost]
        public int AddSup([FromForm]SupplierInfo supplier, [FromForm]ContactsInfo contacts)
        {
            //获取当前系统时间
            supplier.CreateDate = DateTime.Now;
            return _bll.AddSupplier(supplier, contacts);
        }

        //修改
        [HttpPost]
        public int EditSup([FromForm]SupplierInfo supplier, [FromForm]ContactsInfo contacts)
        {
            return _bll.EditSupplier(supplier, contacts);
        }
    }
}