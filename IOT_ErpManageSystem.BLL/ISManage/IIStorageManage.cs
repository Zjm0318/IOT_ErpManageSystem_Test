using IOT_ErpManageSystem.Models;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.BLL.ISManage
{
    public interface IIStorageManage
    {
        /// <summary>
        /// 获取入库信息
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="state">入库状态</param>
        /// <param name="cTime">创建时间</param>
        /// <param name="sName">供应商名称</param>
        /// <param name="bName">采购员名称</param>
        /// <returns></returns>
        List<tb_InStorage> GetInStorageList(int pageIndex, int pageSize, int state, string cTime, string sName, ref int rowCount);
        /// <summary>
        /// 修改入库状态
        /// </summary>
        /// <param name="isId"></param>
        /// <param name="isState"></param>
        /// <returns></returns>
        int UpdateIStorageState(string isId);
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        List<RBAC_Role> GetRoleList();
        /// <summary>
        /// 修改收货员
        /// </summary>
        /// <returns></returns>
        int UpdateIStorageSup();
    }
}
