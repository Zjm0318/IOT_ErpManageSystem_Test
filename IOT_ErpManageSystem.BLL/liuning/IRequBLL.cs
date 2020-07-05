using IOT_ErpManageSystem.Models;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.BLL.liuning
{
    public interface IRequBLL
    {

        #region 预购单
        //预购单显示
        List<RequisitionOrder> GetRequList(string state, string time, string qgren, string shren, int pageindex, int pagesize, ref int rowcount);
        //修改状态
        int UpdRequState(string Id);

        //修改状态 审核未成功
        int UpdRequState2(string Id);
        //显示员工信息
        List<RoleModel> GetRoleList(string rolename, string rolecode);
        //指派请购人员工
        int UpdRole(string RId, string QgId);
        //撤回请购人员工
        int DelRole(string QgId);
        //反填信息
        List<RequisitionInfo> FanTRequ(string QId);
        //添加请购单信息
        int AddRequ(RequisitionInfo m);
        //显示请购单商品信息
        List<RequGoods> GetRequGoods(string Id);

        //查询商品ID
        List<Models.GoodsInfo> GetGoodsId();

        //查询商品信息
        List<RequGoods> SelectGoods();

        //添加请购单,采购单与商品的中间表数据
        int AddRequGood(string GId, int Num);

        //根据ID删除相关的商品信息
        int DeleteGoods(int RpgId);
        //修改请购单信息
        int UpdateRequ(RequisitionInfo m);

        //查询员工名称
        public List<RBAC_Role> SelectRole();
        //查询部门名称
        public List<RBAC_Dep> SelectDep();

        #endregion
        #region 采购单
        //采购单显示
        List<PurChaseOrder> GetPurList(string state, string time, string gname, string bgname, int pageindex, int pagesize, ref int rowcount);
        //审核通过
        int UpdPurState1(string Id);
        //审核未通过
        int UpdPurState2(string Id);
        //指派采购处理人
        int ZhiPaiPur(string Id, string Cgclr);
        //撤回请购人员工
        int DelPurRole(string Id);
        //反填采购信息
        List<PurChaseInfo> FanTPur(string CId);
        //查询请购单ID
        List<RequisitionOrder> SelectQgIdProc();
        //查询供应商ID
        List<SupplierInfo> SelectGysIdProc();
        //添加采购单信息
        int AddPur(PurChaseInfo m);
        //显示请购单商品信息
        List<RequGoods> GetPurGoods(string Id);
        //修改采购单信息
        int UpdatePurInfo(PurChaseInfo m);
        #endregion
    }
}
