using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.Models
{
   public class RoleModel
    {
        public Guid ID { get; set; }
        public string Role_Code { get; set; }
        public string Role_Name { get; set; }
        public string Job_Name { get; set; }
    }
}
