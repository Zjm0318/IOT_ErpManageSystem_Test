using System;
namespace IOT_ErpManageSystem.Models
{
    public class PurChaseInfo
    {
        //采购信息ID
        public Guid ID { get; set; }
        //创建日期
        public DateTime CreateTime { get; set; }
        //请购单信息表ID
        public Guid QID { get; set; }
        //供应商ID
        public Guid GysId { get; set; }
        public string GID { get; set; }
        //供应商名称
        public string GLaiYuan { get; set; }
        //是否含税
        public int IsShui { get; set; }
        //税率
        public string ShuiLv { get; set; }
        //地址
        public string Address { get; set; }
        //编辑人
        public string BgName { get; set; }
        //部门
        public string BgDept { get; set; }
    }
}
