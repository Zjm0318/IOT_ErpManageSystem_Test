using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.API.DtoMoel;
using IOT_ErpManageSystem.BLL.InRBAC_Role;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            List<RBAC_Allots> slist = _allotinterface.GetAllot(model.PageIndex, model.PageSize,model.Dep_Name, ref Rowcount);
            int count = (Rowcount/model.PageSize)+(Rowcount%model.PageSize>0?1:0);

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

        //[HttpGet]
        //public List<RBAC_Quan> ShowQuanInfo(int Uid)
        //{
        //    return _allotinterface.ShowQuanInfo(Uid);
        //}
    }
}