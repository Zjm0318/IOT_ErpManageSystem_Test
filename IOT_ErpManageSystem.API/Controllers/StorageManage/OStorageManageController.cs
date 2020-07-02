using IOT_ErpManageSystem.BLL.ISManage;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.API.Controllers.StorageManage
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OStorageManageController : ControllerBase
    {
        private IOStorageManage _oStorageManage;
        public OStorageManageController(IOStorageManage oStorageManage)
        {
            _oStorageManage = oStorageManage;

        }
        /// <summary>
        /// 获取配送方式
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<tb_DisPatching> GetTbDisList()
        {
            string tbName = "tb_DisPatching";
            return _oStorageManage.GetTb_DisList(tbName);
        }
        /// <summary>
        /// 获取仓库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<tb_Storage> GetStorageList()
        {
            string tbName = "tb_Storage";
            return _oStorageManage.GetTb_StoragesList(tbName);
        }

        //获取出库信息
        public OSDateModel GetOsmList([FromForm]int pageIndex, [FromForm]int pageSize, [FromForm]string disPath, [FromForm]string oTime, [FromForm]string Sid, [FromForm]string orderNo)
        {
            int RowCount = 0;
            List<tb_OutStorage> list = _oStorageManage.GetOSMShowList(pageIndex, pageSize, disPath, oTime, Sid, orderNo, ref RowCount);
            List<OSMShowModel> _list = new List<OSMShowModel>();
            foreach (var item in list)
            {
                OSMShowModel model = new OSMShowModel();
                model.Id = item.Id;
                model.OutTime = item.OutTime.ToString("yyyy-MM-dd");
                model.OrderNo = item.OrderNo;
                model.Dispatching = item.Dispatching;
                model.Consignee = item.Consignee;
                model.CPhoneNum = item.CPhoneNum;
                model.DispatchingArea = item.DispatchingArea;
                model.StorageName = item.StorageName;
                model.StorageMan = item.StorageMan;
                model.DBMan = item.DBMan;
                model.OutState = item.OutState;
                _list.Add(model);
            }
            OSDateModel Dmodel = new OSDateModel();
            Dmodel.list = _list;
            Dmodel.RowCount = RowCount;
            return Dmodel;
        }

        //出库确认
        public int UpdateState(string oId)
        {
            oId = oId.Trim('/');
            return _oStorageManage.UpdateState(oId);
        }
        [HttpPost]
        public int AddOutStorage([FromForm]tb_OutStorage model)
        {
            string osNo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            model.OStorageNo = "CK" + osNo;
            model.DBMan = "李四";
            model.OutState = 2;
            return _oStorageManage.AddOutStorage(model);
        }
    }
}