using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.BLL.ISManage
{
    public interface IStorageStructure
    {
        /// <summary>
        /// 获取所有仓库信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
         List<tb_Storage> GetSotrageList(int pageIndex,int pageSize,ref int RowCount);
        /// <summary>
        /// 获取仓库信息 
        /// </summary>
        /// <returns></returns>
         List<tb_Storage> GetStorList(string tbName);
        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
         List<tb_Area> GetAreaList(string tbName);
        /// <summary>
        /// 新增区域
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddArea(tb_Area model);
        /// <summary>
        /// 新增货架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddShelf(tb_Shelf model);

        int GetShelfCount(string tbName);
    }
}
