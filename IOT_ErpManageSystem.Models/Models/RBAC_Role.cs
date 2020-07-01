using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class RBAC_Role
	 {
		 public string   ID { get; set; }
		 public string  Role_Code { get; set; }
		 public string  Role_Name { get; set; }
		 public string  Role_Account { get; set; }
		 public string  Dep_ID { get; set; }
		 public string  Job_ID { get; set; }

		
		public string  Role_Tel { get; set; }
		 public int  Role_State { get; set; }
		 public DateTime  Role_Create { get; set; }
		 public string State { get; set; }
		 public string CreateDate { get; set; }
		 public string Dep_Name { get; set; }
		 public string Job_Name { get; set; }
		 public int PageIndex { get; set; }
		 public int PageSize { get; set; }

		 public string RoleSex { get; set; }

	}
}
