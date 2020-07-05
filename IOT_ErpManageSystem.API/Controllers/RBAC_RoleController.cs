using IOT_ErpManageSystem.API.DtoMoel;
using IOT_ErpManageSystem.BLL;
using IOT_ErpManageSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT_ErpManageSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RBAC_RoleController : ControllerBase
    {

        private RoleInterface _roleInterface;

        public RBAC_RoleController(RoleInterface roleInterface)
        {
            _roleInterface = roleInterface;
        }

        [HttpPost]
        //显示角色管理
        public ShowRole GetRole([FromForm]RBAC_Role model)
        {
            int Rowcount = 0;

            List<RBAC_Role> Rlist = _roleInterface.GetRole(model.PageIndex, model.PageSize, model.Role_Account, model.Role_Name, model.Job_Name, model.Role_State, ref Rowcount);
            int count = (Rowcount / model.PageSize) + (Rowcount % model.PageSize > 0 ? 1 : 0);

            foreach (var item in Rlist)
            {
                item.CreateDate = item.Role_Create.ToString("yyyy-MM-dd");
                item.Role_Tel = item.Role_Tel.Substring(0, 3) + "××××××××";
            }
            ShowRole show = new ShowRole();
            show.list = Rlist;
            show.Count = count;
            return show;
        }


        //获取部门数据
        [HttpGet]
        public List<RBAC_Dep> GetDep()
        {
            List<RBAC_Dep> dlist = _roleInterface.GetDep();
            return dlist;
        }

        //绑定职位
        [HttpGet]
        public List<RBAC_Job> GetJob(string RoleId)
        {

            List<RBAC_Job> jlist = _roleInterface.GetJob(RoleId);

            return jlist;
        }

        //获取职位数据
        [HttpGet]
        public List<RBAC_Job> GetAJob()
        {
            List<RBAC_Job> jlist = _roleInterface.GetAJob();
            return jlist;
        }


        //添加员工信息
        [HttpPost]
        public int Add_Role([FromForm]RBAC_Role model)
        {
            return _roleInterface.AddRole(model);
        }

        [HttpGet]
        //反填数据
        public RBAC_Role FanRole(string Id)
        {
            return _roleInterface.Role(Id);
        }

        //编辑员工信息
        [HttpPost]
        public int Update_Role([FromForm]RBAC_Role model)
        {
            return _roleInterface.UpdateRole(model);
        }
    }
}