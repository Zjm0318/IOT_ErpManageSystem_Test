using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_ErpManageSystem.Models
{
	 public class PurChaseOrder
	 {
		//���
		public Guid  ID { get; set; }
		//�ɹ���Ϣ�����
		public Guid  CID { get; set; }
		//״̬  0:������ 1:���ͨ�� 2:���δͨ��
		public string  IsState { get; set; }
		//�ɹ�������ID
		public Guid  CGClr { get; set; }
		//�ɹ������ID
		public string  CGShr { get; set; }
		//���������
		public string  CWShr { get; set; }
		//��������
		public DateTime CreateTime { get; set; }
		//��Ӧ�̱��
		public string GID { get; set; }
		//��Ӧ����Դ
		public string GLaiYuan { get; set; }
		//�༭��
		public string BgName { get; set; }
		//Ա������
		public string Role_Name { get; set; }
	}
}
