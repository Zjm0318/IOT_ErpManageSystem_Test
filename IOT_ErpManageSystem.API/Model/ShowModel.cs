using IOT_ErpManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_ErpManageSystem.API.Model
{
    public class ShowModel
    {
        public List<Order> list { get; set; }
        public int Count { get; set; }
    }
}
