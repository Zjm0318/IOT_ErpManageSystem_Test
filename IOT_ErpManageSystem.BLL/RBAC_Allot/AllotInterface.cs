﻿using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using System;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.BLL.InRBAC_Role
{
    public interface AllotInterface
    {
        List<RBAC_Allots> GetAllot(int PageIndex, int PageSize, string AllotName, ref int RowsCount);
        //添加权限
        int AddAllot(RBAC_Allots model);
        //绑定权限
        List<RBAC_Quan> GetAllots(string Uid);
        //编辑权限
        int UpdaAllot(RBAC_Allots model);

        //获取所有菜单
        List<RBAC_Quan> ShowQuanInfo(int UId);
        //登录用户权限
        RBAC_Allots UserQuanInfo(Guid UId);

        RBAC_Allots Quan(string id);
        List<RBAC_Dep> GetDep();
        //添加部门
        int AddDep(RBAC_Dep model);
    }
}
