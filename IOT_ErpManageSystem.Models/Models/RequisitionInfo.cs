using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class RequisitionInfo
	 {
		 public Guid  QId { get; set; }
		 public DateTime  CreateDate { get; set; }
		 public string  DhAddress { get; set; }
		 public string  QgName { get; set; }
		 public string  DeptName { get; set; }
	 }
}
