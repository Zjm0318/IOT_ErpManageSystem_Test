using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class TuiHouInfo
	 {
		 public Guid  ID { get; set; }
		 public DateTime  CreateTime { get; set; }
		 public DateTime  TuiHuoTime { get; set; }
		 public Guid  GID { get; set; }
		 public string  THAddress { get; set; }
		 public string  THLxr { get; set; }
		 public string  TCangKu { get; set; }
	 }
}
