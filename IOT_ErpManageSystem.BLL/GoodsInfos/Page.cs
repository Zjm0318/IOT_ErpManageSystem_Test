using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_ErpManageSystem.BLL.GoodsInfos
{
    public class Page
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string goodsId { get; set; }
        public string goodsName { get; set; }
        public string goodsBrand { get; set; }
    }
}
