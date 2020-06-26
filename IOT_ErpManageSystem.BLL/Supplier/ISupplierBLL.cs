using System;
using System.Collections.Generic;
using System.Text;
using IOT_ErpManageSystem.DAL;
using IOT_ErpManageSystem.Models;

namespace IOT_ErpManageSystem.BLL.Supplier
{
    public interface ISupplierBLL
    {
        //显示、查询
        List<SupplierInfo> GetSupplier(SupperModel m, ref int rowCount);
        //显示反填数据
        SupAndCon ShowSupAndCon(string id);
        //添加
        int AddSupplier(SupplierInfo supplier,ContactsInfo contacts);
        //修改
        int EditSupplier(SupplierInfo supplier, ContactsInfo contacts);
    }
}
