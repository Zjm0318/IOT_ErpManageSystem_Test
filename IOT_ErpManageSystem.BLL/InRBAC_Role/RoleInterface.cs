using IOT_ErpManageSystem.DAL.IDBHelp;
using System;
using System.Collections.Generic;
using System.Text;
using IOT_ErpManageSystem.DAL;
using IOT_ErpManageSystem.Models;
namespace IOT_ErpManageSystem.BLL
{
   public interface RoleInterface
    {
        //显示角色数据
        List<RBAC_Role> GetRole(int PageIndex,int PageSize,string RoleZhang,string RoleName,string RoleJob,int RoleState,ref int RowsCount);

        //添加员工
        int AddRole(RBAC_Role model);
        //显示部门
        List<RBAC_Dep> GetDep();
        //职位绑定
        List<RBAC_Job> GetJob(string RoleId);
        //显示职位
        List<RBAC_Job> GetAJob();
        //修改员工
        int UpdateRole(RBAC_Role model);
        RBAC_Role role(string id);
    }
}
