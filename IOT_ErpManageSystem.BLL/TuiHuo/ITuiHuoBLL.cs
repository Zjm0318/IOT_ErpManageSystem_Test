using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.BLL.TuiHuo
{
    public interface ITuiHuoBLL
    {
        //显示退货信息
        List<TuiHuo> GetTuiHuos(TuiHuoModel m,ref int rowCount);
        //显示仓库
        List<tb_Storage> GetStorage();
        //显示供应商
        List<SupplierInfo> GetSuppliers();
        //显示商品
        List<GoodsModel> GetGoods();
        //添加商品
        int AddGoods(string id);
        //显示退货商品
        List<GoodsModel> GetShowGoods();
        //删除退货商品
        int DeleteGoods(string id);
        //添加退货表信息
        int AddTuiHuo(TuiHouInfo m);
        //审核
        int ShenHe(string id,string sta);
    }
}
