using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class PurChaseInfo
	 {
		 public Guid  ID { get; set; }
		 public DateTime  CreateTime { get; set; }
		 public Guid  QID { get; set; }
		 public Guid  GID { get; set; }
		 public int  IsShui { get; set; }
		 public string  ShuiLv { get; set; }
	 }
}
