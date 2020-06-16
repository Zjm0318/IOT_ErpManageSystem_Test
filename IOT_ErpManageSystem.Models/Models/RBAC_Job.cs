using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class RBAC_Job
	 {
		 public Guid  Job_ID { get; set; }
		 public string  Job_Name { get; set; }
		 public string  Job_Super { get; set; }
	 }
}
