using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.API.Controllers.StorageManage
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IStorageManageController : ControllerBase
    {
        private IIStorageManage _storageManage;
        public IStorageManageController(IIStorageManage storageManage)
        {
            _storageManage = storageManage;

        }

        /// <summary>
        /// 获取入库信息，分页、查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="state"></param>
        /// <param name="cTime"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        [HttpPost]
        public ISDateModel GetInStorageList([FromForm]int pageIndex, [FromForm]int pageSize, [FromForm]int state, [FromForm]string cTime, [FromForm]string sName)
        {
            int rowCount = 0;
            List<tb_InStorage> list = _storageManage.GetInStorageList(pageIndex, pageSize, state, cTime, sName, ref rowCount);
            List<ISMShowModel> _list = new List<ISMShowModel>();
            foreach (var item in list)
            {
                ISMShowModel model = new ISMShowModel();
                model.Id = item.Id;
                model.InStorageTime = item.InStorageTime.ToString("yyyy/MM/dd");
                model.InStorageNo = item.InStorageNo;
                model.BuyListNo = item.BuyListNo;
                if (item.InStorageState == 1)
                {
                    model.InStorageState = "待入库";
                }
                else if (item.InStorageState == 2)
                {
                    model.InStorageState = "入库待确认";
                }
                else
                {
                    model.InStorageState = "已入库";
                }
                if (item.InStorageType == 1)
                {
                    model.InStorageType = "一般入库";
                }
                else
                {
                    model.InStorageType = "调拨入库";
                }
                model.StorageName = item.StorageName;
                model.Consignee = item.Consignee;
                model.StorageMan = item.StorageMan;
                model.GID = item.GID;
                _list.Add(model);
            }
            ISDateModel dModel = new ISDateModel();
            dModel.iSMShowList = _list;
            dModel.RowCount = rowCount;
            return dModel;
        }


        //确认入库
        [HttpGet]
        public int UpdateState(string iId)
        {
            iId = iId.Trim('/');
            return _storageManage.UpdateIStorageState(iId);
        }
    }
}