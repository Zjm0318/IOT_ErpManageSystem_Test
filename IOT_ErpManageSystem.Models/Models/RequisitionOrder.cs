using System;
namespace IOT_ErpManageSystem.Models
{
    public class RequisitionOrder
    {
        //编号
        public Guid QgId { get; set; }
        //请购单信息id 外键
        public Guid QId { get; set; }
        //状态  0-待分配 1-审核通过 2-审核未通过
        public string States { get; set; }
        //请购负责人
        public Guid RId { get; set; }
        //请购审核人
        public string QGShr { get; set; }
        //创建日期
        public DateTime CreateDate { get; set; }
        //请购人员
        public string QgName { get; set; }
        //员工名称
        public string Role_Name { get; set; }

    }
}
