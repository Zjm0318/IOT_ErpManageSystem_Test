using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ErpManageSystem.API.DtoMoel
{
    public class ShowRole
    {
	  public  List<RBAC_Role> list { get; set; }
       public int Count { get; set; }
         
        public List<RBAC_Allots> alist { get; set; }
	}
}
