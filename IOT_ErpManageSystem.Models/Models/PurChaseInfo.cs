using System;
namespace IOT_ErpManageSystem.Models
{
    public class PurChaseInfo
    {
        //�ɹ���ϢID
        public Guid ID { get; set; }
        //��������
        public DateTime CreateTime { get; set; }
        //�빺����Ϣ��ID
        public Guid QID { get; set; }
        //��Ӧ��ID
        public Guid GysId { get; set; }
        public string GID { get; set; }
        //��Ӧ������
        public string GLaiYuan { get; set; }
        //�Ƿ�˰
        public int IsShui { get; set; }
        //˰��
        public string ShuiLv { get; set; }
        //��ַ
        public string Address { get; set; }
        //�༭��
        public string BgName { get; set; }
        //����
        public string BgDept { get; set; }
    }
}
