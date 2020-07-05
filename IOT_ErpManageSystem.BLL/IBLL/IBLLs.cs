using IOT_ErpManageSystem.Models;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.BLL.IBLL
{
    public interface IBLLs
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
        List<Models.GoodsInfo> GoodsPrice(int pageIndex, int pageSize, string proBh, ref int rowCount);
        //添加显示商品信息
        List<Models.GoodsInfo> ShowPrice();
        //添加价格本
        int AddPrice(GoodsPrice model);
        //编辑
        public List<Models.GoodsInfo> GoodsThree(string id);
        //查询类型
        List<GoodsType> Type();
        //修改商品表
        int UpGoods(Models.GoodsInfo m);
        //判断价格是否有此商品
        List<GoodsPrice> Price();
        //关闭订单
        int UpState(int id);
    }
}
