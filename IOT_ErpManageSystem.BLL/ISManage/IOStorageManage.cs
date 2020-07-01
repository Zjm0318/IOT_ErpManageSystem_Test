using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Dto;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IOT_ErpManageSystem.BLL.ISManage
{
    public interface IOStorageManage
    {
        /// <summary>
        /// 出库信息显示 查询 分页
        /// </summary>
        /// <returns></returns>
        List<tb_OutStorage> GetOSMShowList(int pageIndex, int pageSize, string dId, string oTime, string oStorageId, string orderNo, ref int RowCount);

        /// <summary>
        ///获取配送方式信息
        /// </summary>
        /// <returns></returns>
        List<tb_DisPatching> GetTb_DisList(string tbName);
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        List<tb_Storage> GetTb_StoragesList(string tbName);
        /// <summary>
        /// 修改出库状态
        /// </summary>
        /// <param name="oId">出库表Id</param>
        /// <returns></returns>
        int UpdateState(string oId);
        /// <summary>
        /// 添加出库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddOutStorage(tb_OutStorage model);


    }
}
