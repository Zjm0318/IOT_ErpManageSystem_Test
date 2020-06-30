using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class PurChaseOrder
	 {
		//编号
		public Guid  ID { get; set; }
		//采购信息表外键
		public Guid  CID { get; set; }
		//状态  0:待分配 1:审核通过 2:审核未通过
		public string  IsState { get; set; }
		//采购处理人ID
		public Guid  CGClr { get; set; }
		//采购审核人ID
		public string  CGShr { get; set; }
		//财务审核人
		public string  CWShr { get; set; }
		//创建日期
		public DateTime CreateTime { get; set; }
		//供应商编号
		public string GID { get; set; }
		//供应商来源
		public string GLaiYuan { get; set; }
		//编辑人
		public string BgName { get; set; }
		//员工名称
		public string Role_Name { get; set; }
	}
}
