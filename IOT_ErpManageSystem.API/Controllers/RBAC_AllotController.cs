﻿using IOT_ErpManageSystem.API.DtoMoel;
using IOT_ErpManageSystem.BLL.InRBAC_Role;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RBAC_AllotController : ControllerBase
    {
        private AllotInterface _allotinterface;

        public RBAC_AllotController(AllotInterface allotinterface)
        {
            _allotinterface = allotinterface;
        }

        [HttpPost]
        public ShowRole GetAllot([FromForm]RBAC_Allots model)
        {
            int Rowcount = 0;
            List<RBAC_Allots> slist = _allotinterface.GetAllot(model.PageIndex, model.PageSize, model.Dep_Name, ref Rowcount);
            int count = (Rowcount / model.PageSize) + (Rowcount % model.PageSize > 0 ? 1 : 0);

            ShowRole show = new ShowRole();
            show.alist = slist;
            show.Count = count;
            return show;
        }

        //添加权限
        [HttpPost]
        public int Add_Allot([FromForm]RBAC_Allots model)
        {
            return _allotinterface.AddAllot(model);
        }

        //权限绑定
        [HttpGet]
        public List<RBAC_Quan> GetQuan(string Uid)
        {
            List<RBAC_Quan> jlist = _allotinterface.GetAllots(Uid);
            return jlist;
        }


        [HttpGet]
        //反填数据权限
        public RBAC_Allots FanRole(string Id)
        {
            return _allotinterface.Quan(Id);
        }

        //编辑权限信息
        [HttpPost]
        public int Update_Role([FromForm]RBAC_Allots model)
        {
            return _allotinterface.UpdaAllot(model);
        }

        //获取部门数据
        [HttpGet]
        public List<RBAC_Dep> GetDep()
        {
            List<RBAC_Dep> dlist = _allotinterface.GetDep();
            return dlist;
        }

        //所有权限
        [HttpGet]
        public List<RBAC_Quan> ShowQuanInfo(int Uid)
        {
            return _allotinterface.ShowQuanInfo(Uid);
        }

        //登录用户权限
        [HttpGet]
        public RBAC_Allots UserQuanInfo(string token)
        {
            JWTHelper jwt = new JWTHelper();
            string json = jwt.GetPayload(token);
            Personal model = JsonConvert.DeserializeObject<Personal>(json);
            if (model != null)
            {
                return _allotinterface.UserQuanInfo(model.UID);
            }
            else
            {
                return null;
            }
        }
        //添加部门
        [HttpPost]
         public int AddDep([FromForm]RBAC_Dep model)
        {
            return _allotinterface.AddDep(model);
        }
    }
}