using System;
namespace IOT_ErpManageSystem.Models
{
    public class RequisitionInfo
    {
        //编号
        public Guid QgId { get; set; }
        //请购信息ID
        public Guid QId { get; set; }
        //创建日期
        public DateTime CreateDate { get; set; }
        //到货地址
        public string DhAddress { get; set; }
        //请购人员
        public string QgName { get; set; }
        //所在部门
        public string DeptName { get; set; }
    }
}
