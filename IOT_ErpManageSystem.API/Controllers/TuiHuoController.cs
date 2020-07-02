using IOT_ErpManageSystem.API.ViewModel;
using IOT_ErpManageSystem.BLL.TuiHuo;
using IOT_ErpManageSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TuiHuoController : ControllerBase
    {
        private ITuiHuoBLL _bll;
        public TuiHuoController(ITuiHuoBLL bll)
        {
            _bll = bll;
        }

        //显示
        [HttpPost]
        public TuiHuoViewModel GetTuiHuos([FromForm]TuiHuoModel m)
        {
            int rowCount = 0;
            //获取数据
            List<TuiHuo> lst = _bll.GetTuiHuos(m, ref rowCount);
            //总页数
            int count = (rowCount / m.PageSize) + (rowCount % m.PageSize > 0 ? 1 : 0);
            //实例化取值
            TuiHuoViewModel model = new TuiHuoViewModel
            {
                list = lst,
                rowCount = count,
            };
            //返回
            return model;
        }

        //显示仓库
        public List<tb_Storage> GetStorage()
        {
            return _bll.GetStorage();
        }

        //审核
        [HttpPost]
        public int ShenHe([FromForm]string id, [FromForm] string sta)
        {
            return _bll.ShenHe(id, sta);
        }

        //显示供应商
        public List<SupplierInfo> GetSuppliers()
        {
            return _bll.GetSuppliers();
        }

        //显示商品
        public List<GoodsModel> GetGoods()
        {
            return _bll.GetGoods();
        }

        //添加商品
        [HttpPost]
        public int AddGoods([FromForm]string id)
        {
            return _bll.AddGoods(id);
        }

        //显示退货商品
        public List<GoodsModel> GetShowGoods()
        {
            return _bll.GetShowGoods();
        }

        //添加退货表信息
        [HttpPost]
        public int AddTuiHuo([FromForm]TuiHouInfo m)
        {
            m.CreateTime = DateTime.Now;
            m.States = "0";
            return _bll.AddTuiHuo(m);
        }

        //删除退货商品
        [HttpPost]
        public int DeleteGoods([FromForm]string id)
        {
            return _bll.DeleteGoods(id);
        }
    }
}