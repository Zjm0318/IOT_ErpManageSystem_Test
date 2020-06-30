using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.API.Controllers.StorageManage
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageStructureController : ControllerBase
    {
        private IStorageStructure _structure;
        public StorageStructureController(IStorageStructure structure)
        {
            _structure = structure;
        }
        /// <summary>
        /// 仓库结构分页显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public StorageStructDataModel GetStorageList(int pageIndex,int pageSize)
        {
            int RowCount = 0;
            List<tb_Storage> _list= _structure.GetSotrageList(pageIndex, pageSize, ref RowCount);
            StorageStructDataModel model = new StorageStructDataModel();
            model.list = _list;
            model.RowCount = RowCount;
            return model;
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<tb_Storage> GetStorList()
        {
            return _structure.GetStorList("tb_Storage");
        }
        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<tb_Area> GetAreaList()
        {
            return _structure.GetAreaList("tb_Area");
        }

        /// <summary>
        /// 添加区域
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddArea([FromForm]tb_Area model)
        {
            return _structure.AddArea(model);
        }
        /// <summary>
        /// 添加货架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddShelf([FromForm] tb_Shelf model)
        {
            int count = _structure.GetShelfCount("tb_Shelf");
            count = count + 1;
            string shelfNo = "HJ" + count.ToString().PadLeft(3, '0');
            model.ShelfNo = shelfNo;
            return _structure.AddShelf(model);
        }
    }
}