using IOT_ErpManageSystem.BLL.IBLL;
using IOT_ErpManageSystem.DAL.IDall;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.BLL.BLL
{
    public class BLLs : IBLLs
    {
        private IDal _dal;
        public BLLs(IDal dal)
        {
            _dal = dal;
        }
        /// <summary>
        /// jwt登录
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Personal Log(Personal m)
        {
            return _dal.Log(m);
        }
        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Personal> ShowPer(string uid)
        {
            return _dal.ShowPer(uid);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Personal model)
        {
            return _dal.Update(model);
        }
        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserName(Personal model)
        {
            return _dal.UserName(model);
        }
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpIphone(Personal model)
        {
            return _dal.UpIphone(model);
        }
        /// <summary>
        /// 订单报表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="ddh"></param>
        /// <param name="userName"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public List<Order> ShowOrder(int pageIndex, int pageSize, string ddh, string userName, string time, int type, int from, ref int rowCount)
        {
            return _dal.ShowOrder(pageIndex,pageSize,ddh,userName,time,type,from,ref rowCount);
        }
        /// <summary>
        /// 显示订单来源
        /// </summary>
        /// <returns></returns>
        public List<OrderFrom> OrderFrom()
        {
            return _dal.OrderFrom();
        }
        /// <summary>
        /// 显示订单状态
        /// </summary>
        /// <returns></returns>
        public List<OrderState> OrderState()
        {
            return _dal.OrderState();
        }
        /// <summary>
        /// 删除订单表的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Dle(string id)
        {
            return _dal.Dle(id);
        }
        /// <summary>
        /// 显示商品表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="proBh"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<Models.GoodsInfo> GoodsPrice(int pageIndex, int pageSize, string proBh, ref int rowCount)
        {
            return _dal.GoodsPrice(pageIndex,pageSize,proBh,ref rowCount);
        }
        /// <summary>
        /// 显示添加的商品名称
        /// </summary>
        /// <returns></returns>
        public List<Models.GoodsInfo> ShowPrice()
        {
            return _dal.ShowPrice();
        }
        /// <summary>
        /// 添加商品表的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPrice(GoodsPrice model)
        {
            return _dal.AddPrice(model);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DleGoodsInfo(string id)
        {
            return _dal.DleGoodsInfo(id);
        }
        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Models.GoodsInfo> GoodsThree(string id)
        {
            return _dal.GoodsThree(id);
        }
        /// <summary>
        /// 查询商品类型
        /// </summary>
        /// <returns></returns>
        public List<GoodsType> Type()
        {
            return _dal.Type();
        }
        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpGoods(Models.GoodsInfo m)
        {
            return _dal.UpGoods(m);
        }
    }
}
