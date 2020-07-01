using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
    public class RBAC_Allots
    {
        public string ID { get; set; }
        public string Allot_Code { get; set; }
        public string Allot_Name { get; set; }
        public string Allot_Grade { get; set; }
        public string Allot_BaoId { get; set; }

        public string Quan_Name { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Dep_Name { get; set; }
    }
}
