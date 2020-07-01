using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ErpManageSystem.API.Model
{
    public class PriceModel
    {
        public List<GoodsInfo> list { get; set; }
        public int Count { get; set; }
    }
}
