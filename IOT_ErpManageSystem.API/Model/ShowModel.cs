using IOT_ErpManageSystem.Models;
using System.Collections.Generic;

namespace IOT_ErpManageSystem.API.Model
{
    public class ShowModel
    {
        public List<Order> list { get; set; }
        public int Count { get; set; }
    }
}
