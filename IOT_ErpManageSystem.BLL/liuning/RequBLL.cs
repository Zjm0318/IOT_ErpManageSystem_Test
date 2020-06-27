using System;
using System.Collections.Generic;
using System.Text;
using IOT_ErpManageSystem.DAL;
using IOT_ErpManageSystem.DAL.liuning;
using IOT_ErpManageSystem.Models;

namespace IOT_ErpManageSystem.BLL.liuning
{
    public class RequBLL : IRequBLL
    {
        //依赖注入
        private IRequDal _IRequDal;
        public RequBLL(IRequDal IRequDal)
        {
            _IRequDal = IRequDal;
        }

        //预购单模块
        #region
        //预购单显示
        public List<RequisitionOrder> GetRequList(string state, string time, string qgren, string shren, int pageindex, int pagesize, ref int rowcount)
        {
            return _IRequDal.GetRequList(state, time, qgren, shren, pageindex, pagesize,ref rowcount);
        }

        //获取员工信息
        public List<RoleModel> GetRoleList(string rolename, string rolecode)
        {
            return _IRequDal.GetRoleList(rolename,rolecode);
        }

        //修改状态 审核通过
        public int UpdRequState(string Id)
        {
            return _IRequDal.UpdRequState(Id);
        }

        //修改状态  审核未通过
        public int UpdRequState2(string Id)
        {
            return _IRequDal.UpdRequState2(Id);
        }

        //指派预购员工
        public int UpdRole(string RId, string QgId)
        {
            return _IRequDal.UpdRole(RId,QgId);
        }
        //撤回请购员工
        public int DelRole(string QgId)
        {
            return _IRequDal.DelRole(QgId);
        }

        //反填信息
        public List<RequisitionInfo> FanTRequ(string QId)
        {
            return _IRequDal.FanTRequ(QId);
        }
        //添加请购单信息

        public int AddRequ(RequisitionInfo m)
        {
            return _IRequDal.AddRequ(m);
        }

        //显示请购单商品信息
        public List<RequGoods> GetRequGoods(string Id)
        {
            return _IRequDal.GetRequGoods(Id);
        }

       //修改请购单信息
        public int UpdateRequ(RequisitionInfo m)
        {
            return _IRequDal.UpdateRequ(m);
        }
        #endregion

        #region
        //采购单显示
        public List<PurChaseOrder> GetPurList(string state, string time, string gname, string bgname, int pageindex, int pagesize, ref int rowcount)
        {
            return _IRequDal.GetPurList(state,time,gname,bgname,pageindex,pagesize,ref rowcount);
        }

        //审核通过
        public int UpdPurState1(string Id)
        {
            return _IRequDal.UpdPurState1(Id);
        }

        //审核未通过
        public int UpdPurState2(string Id)
        {
            return _IRequDal.UpdPurState2(Id);
        }

        //指派采购处理人
        public int ZhiPaiPur(string Id, string Cgclr)
        {
            return _IRequDal.ZhiPaiPur(Id,Cgclr);
        }

        //撤回采购人员
        public int DelPurRole(string Id)
        {
            return _IRequDal.DelPurRole(Id);
        }

        //反填采购信息
        public List<PurChaseInfo> FanTPur(string CId)
        {
            return _IRequDal.FanTPur(CId);
        }

        //查询请购单ID
        public List<RequisitionOrder> selectQgIdProc()
        {
            return _IRequDal.selectQgIdProc();
        }

        //查询供应商ID
        public List<SupplierInfo> selectGysIdProc()
        {
            return _IRequDal.selectGysIdProc();
        }

        //添加采购单信息
        public int AddPur(PurChaseInfo m)
        {
            return _IRequDal.AddPur(m);
        }

        //显示采购单商品信息
        public List<RequGoods> GetPurGoods(string Id)
        {
            return _IRequDal.GetPurGoods(Id);
        }

        //查询商品表ID
        public List<Models.GoodsInfo> GetGoodsId()
        {
            return _IRequDal.GetGoodsId();
        }
        //添加请购单,采购单与商品的中间表数据
        public int AddRequGoods(string QgId, string GId)
        {
            return _IRequDal.AddRequGoods(QgId,GId);
           
        }

        //根据ID删除相关的商品信息
        public int DeleteGoods(int RpgId)
        {
            return _IRequDal.DeleteGoods(RpgId);
        }


        //修改采购单信息
        public int UpdatePurInfo(PurChaseInfo m)
        {
            return _IRequDal.UpdatePurInfo(m);
        }




        #endregion

    }
}
