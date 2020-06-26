using IOT_ErpManageSystem.BLL.TuiHuo;
using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ErpManageSystem.API.ViewModel
{
    public class TuiHuoViewModel
    {
        public List<TuiHuo> list { get; set; }
        public int rowCount { get; set; }
    }
}
