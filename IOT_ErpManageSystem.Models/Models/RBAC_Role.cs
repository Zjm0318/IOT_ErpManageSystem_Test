using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class RBAC_Role
	 {
		 public Guid  ID { get; set; }
		 public string  Role_Code { get; set; }
		 public string  Role_Name { get; set; }
		 public string  Role_Account { get; set; }
		 public Guid  Dep_ID { get; set; }
		 public Guid  Job_ID { get; set; }
		 public string  Role_Tel { get; set; }
		 public int  Role_State { get; set; }
		 public DateTime  Role_Create { get; set; }
	 }
}
