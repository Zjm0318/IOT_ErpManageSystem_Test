using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.Models
{
   public class PageModel<T>
    {
        public List<T> list { get; set; }
        public int rowcount { get; set; }
    }
}
