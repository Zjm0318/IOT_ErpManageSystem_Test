﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_ErpManageSystem.BLL;
using IOT_ErpManageSystem.Models;
using Microsoft.AspNetCore.Cors;
using IOT_ErpManageSystem.BLL.IBLL;
using Newtonsoft.Json;
using IOT_ErpManageSystem.API.Model;

namespace IOT_ErpManageSystem.API.Controllers
{
    [EnableCors("getd")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IBLLs _bll;
        public DefaultController(IBLLs bll)
        {
            _bll = bll;
        }
        /// <summary>
        /// jwt登录
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public string Log([FromForm]Personal m)
        {
            Personal model = _bll.Log(m);
            if(model!=null)
            {
                JWTHelper jwt = new JWTHelper();
                Dictionary<string, object> keys = new Dictionary<string, object>();
                keys.Add("UID", model.UID);
                keys.Add("UserName", model.UserName);
                keys.Add("Pwd", model.Pwd);
                string token = jwt.GetToken(keys,30000);
                return token;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public Personal ShowPer(string token)
        {
            JWTHelper jwt = new JWTHelper();
            string json = jwt.GetPayload(token);
            Personal model = JsonConvert.DeserializeObject<Personal>(json);
            if(model!=null)
            {
                return _bll.ShowPer(model.UID.ToString()).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update([FromForm]Personal model)
        {
            return _bll.Update(model);
        }
        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public int UpName([FromForm]Personal model)
        {
            return _bll.UserName(model);
        }
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public int UpPhone([FromForm]Personal model)
        {
            return _bll.UpIphone(model);
        }
        /// <summary>
        /// 显示订单报表
        /// </summary>
        [HttpGet]
        public ShowModel ShowOrder(int pageIndex, int pageSize, string ddh, string userName, string time, int type, int from)
        {
            int rowCount = 0;
            List<Order> lit = _bll.ShowOrder(pageIndex, pageSize, ddh, userName, time, type, from, ref rowCount);
            int count = (rowCount / pageSize) + (rowCount % pageSize > 0 ? 1 : 0);
            foreach (var item in lit)
            {
                item.Time = item.SubmitTime.ToString("yyyy-MM-dd");
            }
            ShowModel m = new ShowModel();
            m.list = lit;
            m.Count = count;
            return m;
        }
        /// <summary>
        /// 显示订单来源
        /// </summary>
        /// <returns></returns>
        public List<OrderFrom> OrderFrom()
        {
            return _bll.OrderFrom();
        }
        /// <summary>
        /// 显示订单状态
        /// </summary>
        /// <returns></returns>
        public List<OrderState> OrderState()
        {
            return _bll.OrderState();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public int Del([FromForm]string id)
        {
            return _bll.Dle(id);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public int DelGoods([FromForm]string id)
        {
            var iid = id.Trim('/');
            return _bll.DleGoodsInfo(iid);
        }
        /// <summary>
        /// 商品价格本
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="proBh"></param>
        /// <returns></returns>
        [HttpGet]
        public PriceModel GoodsPrice(int pageIndex, int pageSize, string proBh)
        {
            int rowCount = 0;
            List<GoodsInfo> lit = _bll.GoodsPrice(pageIndex, pageSize,proBh, ref rowCount);
            int count = (rowCount / pageSize) + (rowCount % pageSize > 0 ? 1 : 0);
            PriceModel m = new PriceModel();
            m.list = lit;
            m.Count = count;
            return m;
        }
        /// <summary>
        /// 显示添加商品的名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<GoodsInfo> ShowPrice()
        {
            return _bll.ShowPrice();
        }
        /// <summary>
        /// 添加价格本
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddPrice([FromForm]GoodsPrice m)
        {
            return _bll.AddPrice(m);
        }
        [HttpGet]
        public GoodsInfo GoodsThree(string id)
        {
            return _bll.GoodsThree(id).FirstOrDefault();
        }
        [HttpGet]
        public List<GoodsType> Type()
        {
            return _bll.Type();
        }
        /// <summary>
        /// 修改商品表的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateGoods([FromForm]GoodsInfo model)
        {
            GoodsInfo m = new GoodsInfo()
            {
                Id = model.Id,
                GoodsName = model.GoodsName,
                GoodsBrand = model.GoodsBrand,
                TypeId = model.TypeId,
                GoodsRule = model.GoodsRule,
                SKU = model.SKU,
                GoodsPrices = model.GoodsPrices,
                PriceId = model.PId,
                JinHPrice = model.JinHPrice
            };
            return _bll.UpGoods(m);
        }
    }
}