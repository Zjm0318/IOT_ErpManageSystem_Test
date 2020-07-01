using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ErpManageSystem.API.Controllers.GoodsInfo
{
    public class ShowInfo
    {
        public List<IOT_ErpManageSystem.Models.GoodsInfo> list { get; set; }
        public int count { get; set; }
        public List<GoodsPrice> plist { get; set; }
    }
}
