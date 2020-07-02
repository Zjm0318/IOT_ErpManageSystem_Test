using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.DAL.IDall
{
    public interface IDal
    {
        //jwt登录
        Personal Log(Personal m);
        //个人信息
        List<Personal> ShowPer(string uid);
        //修改密码
        int Update(Personal model);
        //修改手机号
        int UpIphone(Personal model);
        //修改用户名
        int UserName(Personal model);
        //显示订单报表
        List<Order> ShowOrder(int pageIndex, int pageSize, string ddh, string userName, string time, int type, int from, ref int rowCount);
        //订单来源
        List<OrderFrom> OrderFrom();
        //订单状态
        List<OrderState> OrderState();
        //删除
        int Dle(string id);
        //显示商品价格本
        List<GoodsInfo> GoodsPrice(int pageIndex, int pageSize,string proBh, ref int rowCount);
        //添加显示商品信息
        List<GoodsInfo> ShowPrice();
        //添加价格本
        int AddPrice(GoodsPrice model);
        //删除
        int DleGoodsInfo(string id);
        //编辑
        public List<GoodsInfo> GoodsThree(string id);
        //查询类型
        List<GoodsType> Type();
        //修改商品表
        int UpGoods(GoodsInfo m);
    }
}
