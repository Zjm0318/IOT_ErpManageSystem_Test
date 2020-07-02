using IOT_ErpManageSystem.BLL.RBAC_Allot;
using IOT_ErpManageSystem.DAL.IDBHelp;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.BLL.InRBAC_Role
{
   public  interface AllotInterface
    {
        List<RBAC_Allots> GetAllot(int PageIndex, int PageSize, string AllotName, ref int RowsCount);
        //添加权限
        int AddAllot(RBAC_Allots model);
        //绑定权限
        List<RBAC_Quan> GetAllots(string Uid);
        //编辑权限
        int UpdaAllot(RBAC_Allots model);

        //获取所有菜单
        List<RBAC_Quan> ShowQuanInfo();

        //RBAC_Allots Quan(string id);
        List<RBAC_Dep> GetDep();
    }
}
