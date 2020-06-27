using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_ErpManageSystem.BLL.liuning;
using IOT_ErpManageSystem.DAL.liuning;
using IOT_ErpManageSystem.Models;
using IOT_ErpManageSystem.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_ErpManageSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]                                               
    [ApiController]
    public class RequListController : ControllerBase
    {
        //依赖注入
        public IRequBLL _IRequBLL;
        public RequListController(IRequBLL IRequBLL) {
            _IRequBLL = IRequBLL;
        }

        //预购单模块
        #region
        //预购单显示
        [HttpGet]
        public PageModel<RequisitionOrder> GetRequList(string state="",string time="",string qgren="",string shren="",int pageindex=0, int pagesize=0)
        {
            int rowcount = 0;
            List<RequisitionOrder> list = _IRequBLL.GetRequList(state,time,qgren,shren,pageindex,pagesize,ref rowcount);
            //计算总页数
            int code =0;
            double b = double.Parse(pagesize.ToString());
            b = Math.Ceiling(double.Parse(rowcount.ToString())/b);
            code = int.Parse(b.ToString());

            PageModel<RequisitionOrder> model = new PageModel<RequisitionOrder>() {
                list = list,
                rowcount = code
            };
            return model;
        }

        //修改状态  审核通过
        [HttpGet]
        public int UpdateState(string Id)
        {
            int flag = _IRequBLL.UpdRequState(Id);
            return flag;
        }

        //修改状态 审核未通过
        [HttpGet]
        public int UpdateState2(string Id)
        {
            int flag = _IRequBLL.UpdRequState2(Id);
            return flag;
        }

        
        //获取员工信息
        [HttpGet]
        public List<RoleModel> GetRoleList(string rolename, string rolecode)
        {
            List<RoleModel> list = _IRequBLL.GetRoleList(rolename,rolecode);
            return list;
        }

        //指派预购员工
        [HttpGet]
        public int UpdateRole(string RId,string QgId)
        {
            int flag = _IRequBLL.UpdRole(RId,QgId);
            return flag;
        }

        //撤回请购员工
        [HttpGet]
        public int DelRole(string QgId)
        {
            int flag = _IRequBLL.DelRole(QgId);
            return flag;
        }
        //反填信息
        [HttpGet]
        public RequisitionInfo FanTRequ(string QId)
        {
            List<RequisitionInfo> list = _IRequBLL.FanTRequ(QId);
           
            var list1 = list.FirstOrDefault();
            return list1;
        }

        //添加请购单信息
        [HttpPost]
        public int AddRequInfo([FromForm]RequisitionInfo m)
        {
            int flag = _IRequBLL.AddRequ(m);
            return flag;
        }
        //显示请购单商品信息
        [HttpGet]
        public List<RequGoods> GetRequGoods(string Id)
        {
            List<RequGoods> list = _IRequBLL.GetRequGoods(Id);
            return list;
        }

        //修改请购单信息
        [HttpPost]
        public int UpdateRequ([FromForm]RequisitionInfo m)
        {
            int flag = _IRequBLL.UpdateRequ(m);
            return flag;
        }

        #endregion

        //采购单模块
        #region
        //采购单显示
        [HttpGet]
           public PageModel<PurChaseOrder> GetPurList(string state, string time, string gname, string bgname, int pageindex, int pagesize)
        {
            int rowcount = 0;
            List<PurChaseOrder> list = _IRequBLL.GetPurList(state, time, gname, bgname, pageindex, pagesize, ref rowcount);
            int code = 0;
            double b = double.Parse(pagesize.ToString());
            b = Math.Ceiling(double.Parse(rowcount.ToString())/b);
            code = int.Parse(b.ToString());
            PageModel<PurChaseOrder> model = new PageModel<PurChaseOrder>() {
                list = list,
                rowcount=code
            };
          

            return model;
        }

        //审核通过
        [HttpGet]
        public int UpdPurState1(string Id)
        {
            int flag = _IRequBLL.UpdPurState1(Id);
            return flag;
        }
        //审核未通过
        [HttpGet]
        public int UpdPurState2(string Id)
        {
            int flag = _IRequBLL.UpdPurState2(Id);
            return flag;
        }

        //指派采购处理人
        public int ZhiPaiPur(string Id,string Cgclr)
        {
            int flag = _IRequBLL.ZhiPaiPur(Id,Cgclr);
            return flag;
        }

        //撤回采购处理人
        public int CheHuiPur(string Id)
        {
            int flag = _IRequBLL.DelPurRole(Id);
            return flag;
        }

        //反填信息
        [HttpGet]
        public PurChaseInfo FanTPur(string CId)
        {
            List<PurChaseInfo> list = _IRequBLL.FanTPur(CId);

            var list1 = list.FirstOrDefault();
            return list1;
        }

        //查询请购单ID
        [HttpGet]
        public List<RequisitionOrder> selectQgId()
        {
            List<RequisitionOrder> list = _IRequBLL.selectQgIdProc();
            return list;
        }
        //查询供应商ID
        [HttpGet]
        public List<SupplierInfo> selectGysId()
        {
            List<SupplierInfo> list = _IRequBLL.selectGysIdProc();
            return list;
        }
        //添加采购单信息
        [HttpPost]
        public int AddPur([FromForm]PurChaseInfo m)
        {
            m.CreateTime = DateTime.Now;
            int flag = _IRequBLL.AddPur(m);
            return flag;
        }

        //显示采购单商品信息
        [HttpGet]
        public List<RequGoods> GetPurGoods(string Id)
        {
            List<RequGoods> list = _IRequBLL.GetPurGoods(Id);
            return list;
        }

        //查询商品表ID
        [HttpGet]
        public List<Models.GoodsInfo> GetChaGoodsID()
        {
            List<Models.GoodsInfo> list = _IRequBLL.GetGoodsId();
           
            return list;
        }
        //添加请购单,采购单与商品的中间表数据
        [HttpPost]
        public int AddRequGoods([FromForm]RequPurGood m)
        {
            string qgid = m.QPId.ToString();
            string gid = m.GId.ToString();
             int flag = _IRequBLL.AddRequGoods(qgid, gid);
            return flag;
        }

        //根据ID删除相关的商品信息
        [HttpGet]
        public int DeleteGoods(int RpgId)
        {
            int flag = _IRequBLL.DeleteGoods(RpgId);
            return flag;
        }

        //修改采购单信息
        [HttpPost]
        public int UpdatePurInfo([FromForm]PurChaseInfo m)
        {
            int flag = _IRequBLL.UpdatePurInfo(m);
            return flag;
        }
        #endregion

    }
}