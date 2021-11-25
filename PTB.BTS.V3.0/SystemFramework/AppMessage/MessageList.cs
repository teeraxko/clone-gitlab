using System;

namespace SystemFramework.AppMessage
{
	public class MessageList
	{
		protected MessageList()
		{
		}

		public enum Information
		{
			I0001, I0002, I0003, I0004, I0005, I0006
		}

		public enum Warning
		{
            W0001, W0002, W0003, W0004, W0005, W0006, W0007,
		}

		public enum Error
		{
			E0001,E0002,E0003,E0004,E0005,E0006,E0007,E0008,E0009,E0010,E0011,E0012,E0013,E0014,E0015,
			E0016,E0017,E0018,E0019,E0020,E0021,E0022,E0023,E0024,E0025,E0026,E0027,E0028,E0029,E0030,
			E0031,E0032,E0033,E0034,E0035,E0036,E0037,E0038,E0039,E0040,E0041,E0042,E0043,E0044,E0045,
            E0046,E0047,E0048,E0049,E0050,E0051,E0052,E0053,E0054,E0055,E0056,E0057,E0058
		}

		public enum Question
		{
			Q0001,Q0002,Q0003,Q0004,Q0005,Q0006,Q0007,Q0008,Q0009,Q0010,Q0011,Q0012,Q0013,Q0014,Q0015,
            Q0016,Q0017,Q0018,Q0019,Q0020
        }

		public static string GetMessage(Information information)
		{
			switch (information)
			{
				case Information.I0001:
					return "��÷ӧҹ��������ó�";
				case Information.I0002:
					return "Daily Process ��������ó�";
				case Information.I0003:
					return "Daily Process ���ѧ�ӧҹ ��س����ѡ����";
                case Information.I0004:
                    return "�����ŵԴź�������ö Connect �������к� Payroll�� ��سҵ�Ǩ�ͺ������ ���������١��ͧ";
                case Information.I0005:
                    return "��س� Print report ����ͧ�ش";
                case Information.I0006:
                    return "���������ç�Ѻ��͹������͡ ��سҡ����� �ӹǳ ��͹�ѹ�֡";

				default :
					return "";
			}
		}

		public static string GetMessage(Warning warning)
		{
			switch (warning)
			{
				case Warning.W0001:
                    return "��Һ�ԡ���� 0 㹡óշ�����ѭ��������ҹ�� ��ҹ�׹�ѹ�д��Թ��õ���������";
                case Warning.W0002:
                    return "��سҡ�˹��ٻẺ�����ǧ��������Ѻ�١��ҹ��";
                case Warning.W0003:
                    return "�Ţ����ҡ��ë������駹����¡����Ţ����ҡ��ë������駡�͹";
                case Warning.W0004:
                    return "�ѧ�����ӹǳ�ѵ�Ҥ�Һ�ԡ��";
                case Warning.W0005:
                    return "���ѵ�Ҥ�Һ�ԡ�÷��١�����͹��������� BizPac ���� ����㹪�ǧ�������ҷ�����͡ ��ҹ�׹�ѹ�д��Թ��õ���������";
                case Warning.W0006:
                    return "�ѭ�ҹ���ա�èѺ��� �к��зӡ������������Ңͧ�ѭ�ҷ��Ѻ���ѹ���� ��ҹ�׹�ѹ�д��Թ��õ��������� ?";
                case Warning.W0007:
                    return "��¡���ҡԨ����ɹ����١����¡������� ��ҹ�׹�ѹ�д��Թ��õ��������� ?";
                
				default :
					return "";
			}
		}

		public static string GetMessage(Error error)
		{
			switch (error)
			{

				case Error.E0001:
					return "{0}��ͧ���¡���{1}";
				case Error.E0002:
					return "��سҡ�͡{0}";
				case Error.E0003:
					return "����¡�ù��㹰ҹ���������� ��سҡ�͡�����������ա����";
				case Error.E0004:
					return "��辺{0}";
				case Error.E0005:
					return "��س����͡{0}";
				case Error.E0006:
					return "���������١��ͧ";
				case Error.E0007:
					return "��ѡ�ҹ����� ������Է������Ѻ{0}";
				case Error.E0008:
					return "��سҡ������ӹǳ��������§�����ա����";
				case Error.E0009:
					return "�ӹǹ���駵�ͧ�ҡ���� 1";
				case Error.E0010:
					return "����¡�ù������ ��س����͡�����������ա����";
				case Error.E0011:
					return "{0}��ͧ���¡���������ҡѺ{1}";
				case Error.E0012:
					return "�������ö{0} ���ͧ�ҡ{1} ��س�{2}";
				case Error.E0013:
					return "�������ö{0} ���ͧ�ҡ{1}";
				case Error.E0014:
					return "�������ö{0}";
				case Error.E0015:
					return "�ӹǹö��ѭ�����١��ͧ";
				case Error.E0016:
					return "�ѭ�ҩ�Ѻ����ѧ����ҹ���͹��ѵ�";
				case Error.E0017:
					return "��سҡ������ӹǳ";
				case Error.E0018:
					return "{0}��ͧ�ҡ����������ҡѺ{1}";
				case Error.E0019:
					return "{0}���١��ͧ";
				case Error.E0020:
					return "��س�ź������㹵��ҧ��Ҫ��������͹ ��͹����¹�ŧ����Ѻ�Դ�ͺ����������";
				case Error.E0021:
					return "{0}��ͧ��ҡѺ{1}";
				case Error.E0022:
					return "��س�ź������㹵��ҧ��Ҫ��������͹ ���������ա���ѡ��� Excess";
				case Error.E0023:
					return "�ٻẺ�ѹ������١��ͧ";
				case Error.E0024:
					return "����ͼԴ��Ҵ㹰ҹ������";
				case Error.E0025:
					return "{0}��ͧ�ҡ����{1}";
				case Error.E0026:
					return "���͹حҵ��������ʹ�� ���ͧ�ҡ�����ʢͧ�к�";
				case Error.E0027:
					return "�к��Ѵ��ͧ��سҵԴ��� ICTUS: \n";
				case Error.E0028:
					return "��㺡ӡѺ���չ��㹰ҹ���������� ";
				case Error.E0029:
					return "��س�����¹������ö";
				case Error.E0030:
					return "�ѹ�����§ҹ��ͧ������������Ңͧ�ѭ��";
				case Error.E0031:
					return "�վ�ѡ�ҹ����蹷ӧҹ㹪�ǧ���Ҵѧ���������";
				case Error.E0032:
					return "�Ţ�.�.�. {0} ���  ��سҡ�͡�Ţ�.�.�.����";
				case Error.E0033:
					return "���Ţ�.�.�. {0} ���㹰ҹ����������";
				case Error.E0034:
					return "��س�������¡��㹡�������";
				case Error.E0035:
					return "�ӴѺ��� ��� ��س���䢢���������";
				case Error.E0036:
					return "��س�������¡�ë���";
				case Error.E0037:
					return "ö�ѹ�������ش�����ҹ(Terminate) 㹪�ǧ���Ҵѧ���������\n�������ö�觫������ا㹪�ǧ���ҹ����";
				case Error.E0038:
					return "��/��͹ ����ѡ��� excess �����͹ ���";
				case Error.E0039:
					return "�������� ��س����͡����������";
				case Error.E0040:
					return "����ź��������ѡ�ҹ�Ѻö�͡�ҡ�к�";
				case Error.E0041:
					return "�ѵ�Ҥ�Һ�ԡ�� ����ѹ �ҡ�Թ����˹����";
				case Error.E0042:
					return "��سҡ��������ҧ��¡��";
				case Error.E0043:
					return "��س�����¹��������ѡ�ҹ Service Staff";
				case Error.E0044:
					return "��س�ź��ѡ�ҹ spare �����᷹��͹";
				case Error.E0045:
					return "�ѹ�����§ҹ��ͧ������������ҷ�� ��ѡ�ҹ����� Main �ӧҹ";
				case Error.E0046:
					return "{0}��ͧ���������ҧ{1}";
				case Error.E0047:
					return "�ѹ�ҫ�� ��س����͡�ѹ������";
				case Error.E0048:
					return "�ѹ�Ҿѡ��͹��������͡Ѻ��ǧ�ѹ�ҷ���к�";
				case Error.E0049:
					return "�������ö�ѹ�֡�������� ���ͧ�ҡ�ѹ�ҵç�Ѻ�ѹ��ش";
				case Error.E0050:
					return "����¡�÷��س��ӡ���һ������������� ��س����͡�����������ա����";
				case Error.E0051:
					return "�س������Ѻ͹حҵ���� Daily Process";
				case Error.E0052:
					return "�� ��/��͹ ����ѡ��� Excess �ͧ��ѡ�ҹ������� ���¡���غѵ��˵����";
                case Error.E0053:
                    return "{0}��� ��س����{0}����";
                case Error.E0054:
                    return "�ѹ����˹������١��ҵ�ͧ������������Ңͧ�ѭ��";
                case Error.E0055:
                    return "��ǧ���ҷ���˹������١����Դ������������ӡѹ";
                case Error.E0056:
                    return "��ͧ���͡ Customer Accepted ��͹���ҧ���觫���";
                case Error.E0057:
                    return "�����١�����ѭ�� �Ѻ�����١��ҷ���к��˹���кؽ������ç�ѹ";
                case Error.E0058:
                    return "��س�{0}";
				default :
					return "";
			}
		}

		public static string GetMessage(Question question)
		{
			switch (question)
			{
				case Question.Q0001:
					return "�س��ͧ���ź��¡�ù�����������?";
				case Question.Q0002:
					return "�����{0}���Ǩ��������ö{1}�س�׹�ѹ����{2}���������";
				case Question.Q0003:
					return "�س��ͧ��úѹ�֡��������¡�ù���͹�������?";
				case Question.Q0004:
					return "�س��ͧ���ź{0} ���������?";
				case Question.Q0005:
					return "�س��ͧ���Update����ö¹�����������";
				case Question.Q0006:
					return "���ͧ�ҡ�غѵ��˵ؤ��駹��������к�����ա�ë��� \n�ѧ��� �к��зӡ��ź��¡�ë�������������͡� \n�س�׹�ѹ���зӧҹ����������";
				case Question.Q0007:
					return "���ͧ�ҡ�غѵ��˵ؤ��駹��������к�����դ�Ҫ��������͹�ͧ��ѡ�ҹ \n�ѧ��� �к��зӡ��ź�����Ū��������͹�ͧ��ѡ�ҹ����������͡� \n�س�׹�ѹ���зӧҹ����������";
				case Question.Q0008:
					return "���ͧ�ҡ����¡�ä�Һ�ԡ�����������к��зӡ��ź�����ź�ԡ�÷���������͡� �س�׹�ѹ���зӧҹ����������";
				case Question.Q0009:
					return "�س��ͧ���͹��ѵ��ѭ�ҩ�Ѻ������������?";
				case Question.Q0010:
					return "���ѹ��ش�١�к�����㹪�ǧ�ѹ�� �س�׹�ѹ���зӧҹ���������� ?";
				case Question.Q0011:
					return "�س�׹�ѹ���з� Daily Process ���������?";
                case Question.Q0012 :
                    return "ö�ѹ����ջ�Сѹ�Ѻ�������쩺Ѻ���㹪�ǧ���ҹ������ �س�׹�ѹ���зӧҹ���������� ?";
                case Question.Q0013:
                    return "�س��ͧ���¡��ԡ��ö����͹��������������� ?";
                case Question.Q0014:
                    return "�س��ͧ��ö����͹��������������� ?";
                case Question.Q0015:
                    return "�س��ͧ���¡��ԡ���觫��ͩ�Ѻ������������ ?";
                case Question.Q0016:
                    return "�س��ͧ������ҧ{0}��������� ?";
                case Question.Q0017:
                    return "�к��зӡ�úѹ�֡�����š�͹��þ���� �س�׹�ѹ���зӧҹ���������� ?";
                case Question.Q0018:
                    return "�س��ͧ��úѹ�֡{0}��������� ?";
                case Question.Q0019:
                    return "���ͧ�ҡ {0} �س�׹�ѹ���зӧҹ���������� ?";
                case Question.Q0020:
                    return "�����š��ѧ���������ҧ������ ��ҹ��ͧ��úѹ�֡�����š�͹������� ?";
				default :
					return "";
			}
		}

	}
}