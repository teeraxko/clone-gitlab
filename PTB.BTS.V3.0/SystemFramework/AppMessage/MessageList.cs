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
					return "การทำงานเสร็จสมบูรณ์";
				case Information.I0002:
					return "Daily Process เสร็จสมบูรณ์";
				case Information.I0003:
					return "Daily Process กำลังทำงาน กรุณารอสักครู่";
                case Information.I0004:
                    return "ข้อมูลติดลบไม่สามารถ Connect เข้าสู่ระบบ Payrollได้ กรุณาตรวจสอบข้อมูล และแก้ไขให้ถูกต้อง";
                case Information.I0005:
                    return "กรุณา Print report ทั้งสองชุด";
                case Information.I0006:
                    return "ข้อมูลไม่ตรงกับเดือนที่เลือก กรุณากดปุ่ม คำนวณ ก่อนบันทึก";

				default :
					return "";
			}
		}

		public static string GetMessage(Warning warning)
		{
			switch (warning)
			{
				case Warning.W0001:
                    return "ค่าบริการเป็น 0 ในกรณีที่เป็นสัญญาเหมาเท่านั้น ท่านยืนยันจะดำเนินการต่อหรือไม่";
                case Warning.W0002:
                    return "กรุณากำหนดรูปแบบค่าล่วงเวลาสำหรับลูกค้านี้";
                case Warning.W0003:
                    return "เลขไมล์จากการซ่อมครั้งนี้น้อยกว่าเลขไมล์จากการซ่อมครั้งก่อน";
                case Warning.W0004:
                    return "ยังไม่ได้คำนวณอัตราค่าบริการ";
                case Warning.W0005:
                    return "มีอัตราค่าบริการที่ถูกถ่ายโอนข้อมูลเข้า BizPac แล้ว อยู่ในช่วงระยะเวลาที่เลือก ท่านยืนยันจะดำเนินการต่อหรือไม่";
                case Warning.W0006:
                    return "สัญญานี้มีการจับคู่ ระบบจะทำการแก้ไขระยะเวลาของสัญญาที่จับคู่กันอยู่ ท่านยืนยันจะดำเนินการต่อหรือไม่ ?";
                case Warning.W0007:
                    return "รายการลากิจพิเศษนี้ได้ถูกทำรายการไปแล้ว ท่านยืนยันจะดำเนินการต่อหรือไม่ ?";
                
				default :
					return "";
			}
		}

		public static string GetMessage(Error error)
		{
			switch (error)
			{

				case Error.E0001:
					return "{0}ต้องน้อยกว่า{1}";
				case Error.E0002:
					return "กรุณากรอก{0}";
				case Error.E0003:
					return "มีรายการนี้ในฐานข้อมูลแล้ว กรุณากรอกข้อมูลใหม่อีกครั้ง";
				case Error.E0004:
					return "ไม่พบ{0}";
				case Error.E0005:
					return "กรุณาเลือก{0}";
				case Error.E0006:
					return "ข้อมูลไม่ถูกต้อง";
				case Error.E0007:
					return "พนักงานคนนี้ ไม่มีสิทธิ์ได้รับ{0}";
				case Error.E0008:
					return "กรุณากดปุ่มคำนวณเบี้ยเลี้ยงใหม่อีกครั้ง";
				case Error.E0009:
					return "จำนวนครั้งต้องมากกว่า 1";
				case Error.E0010:
					return "มีรายการนี้แล้ว กรุณาเลือกข้อมูลใหม่อีกครั้ง";
				case Error.E0011:
					return "{0}ต้องน้อยกว่าหรือเท่ากับ{1}";
				case Error.E0012:
					return "ไม่สามารถ{0} เนื่องจาก{1} กรุณา{2}";
				case Error.E0013:
					return "ไม่สามารถ{0} เนื่องจาก{1}";
				case Error.E0014:
					return "ไม่สามารถ{0}";
				case Error.E0015:
					return "จำนวนรถในสัญญาไม่ถูกต้อง";
				case Error.E0016:
					return "สัญญาฉบับนี้ยังไม่ผ่านการอนุมัติ";
				case Error.E0017:
					return "กรุณากดปุ่มคำนวณ";
				case Error.E0018:
					return "{0}ต้องมากกว่าหรือเท่ากับ{1}";
				case Error.E0019:
					return "{0}ไม่ถูกต้อง";
				case Error.E0020:
					return "กรุณาลบข้อมูลในตารางค่าชำระรายเดือน ก่อนเปลี่ยนแปลงผู้รับผิดชอบค่าเสียหาย";
				case Error.E0021:
					return "{0}ต้องเท่ากับ{1}";
				case Error.E0022:
					return "กรุณาลบข้อมูลในตารางค่าชำระรายเดือน เมื่อไม่มีการหักค่า Excess";
				case Error.E0023:
					return "รูปแบบวันที่ไม่ถูกต้อง";
				case Error.E0024:
					return "พบข้อผิดพลาดในฐานข้อมูล";
				case Error.E0025:
					return "{0}ต้องมากกว่า{1}";
				case Error.E0026:
					return "ไม่อนุญาตให้ใช้รหัสนี้ เนื่องจากเป็นรหัสของระบบ";
				case Error.E0027:
					return "ระบบขัดข้องกรุณาติดต่อ ICTUS: \n";
				case Error.E0028:
					return "มีใบกำกับภาษีนี้ในฐานข้อมูลแล้ว ";
				case Error.E0029:
					return "กรุณาเปลี่ยนประเภทรถ";
				case Error.E0030:
					return "วันที่จ่ายงานต้องอยู่ในระยะเวลาของสัญญา";
				case Error.E0031:
					return "มีพนักงานคนอื่นทำงานในช่วงเวลาดังกล่าวแล้ว";
				case Error.E0032:
					return "เลขพ.ร.บ. {0} ซ้ำ  กรุณากรอกเลขพ.ร.บ.ใหม่";
				case Error.E0033:
					return "มีเลขพ.ร.บ. {0} นี้ในฐานข้อมูลแล้ว";
				case Error.E0034:
					return "กรุณาเพิ่มรายการในกรมธรรม์";
				case Error.E0035:
					return "ลำดับที่ ซ้ำ กรุณาแก้ไขข้อมูลใหม่";
				case Error.E0036:
					return "กรุณาเพิ่มรายการซ่อม";
				case Error.E0037:
					return "รถคันนี้สิ้นสุดการใช้งาน(Terminate) ในช่วงเวลาดังกล่าวแล้ว\nไม่สามารถส่งซ่อมบำรุงในช่วงเวลานั้นได้";
				case Error.E0038:
					return "ปี/เดือน ที่หักค่า excess รายเดือน ซ้ำ";
				case Error.E0039:
					return "อะไหล่ซ้ำ กรุณาเลือกอะไหล่ใหม่";
				case Error.E0040:
					return "ห้ามลบประเภทพนักงานขับรถออกจากระบบ";
				case Error.E0041:
					return "อัตราค่าบริการ รายวัน มากเกินที่กำหนดไว้";
				case Error.E0042:
					return "กรุณากดปุ่มสร้างรายการ";
				case Error.E0043:
					return "กรุณาเปลี่ยนประเภทพนักงาน Service Staff";
				case Error.E0044:
					return "กรุณาลบพนักงาน spare ที่มาแทนก่อน";
				case Error.E0045:
					return "วันที่จ่ายงานต้องอยู่ในระยะเวลาที่ พนักงานที่เป็น Main ทำงาน";
				case Error.E0046:
					return "{0}ต้องอยู่ระหว่าง{1}";
				case Error.E0047:
					return "วันลาซ้ำ กรุณาเลือกวันลาใหม่";
				case Error.E0048:
					return "วันลาพักร้อนเหลือไม่พอกับช่วงวันลาที่ระบุ";
				case Error.E0049:
					return "ไม่สามารถบันทึกข้อมูลได้ เนื่องจากวันลาตรงกับวันหยุด";
				case Error.E0050:
					return "มีรายการที่คุณได้ทำการลาประเภทอื่นไปแล้ว กรุณาเลือกข้อมูลใหม่อีกครั้ง";
				case Error.E0051:
					return "คุณไม่ได้รับอนุญาตให้ทำ Daily Process";
				case Error.E0052:
					return "มี ปี/เดือน ที่หักค่า Excess ของพนักงานคนนี้ซ้ำ ในรายการอุบัติเหตุอื่น";
                case Error.E0053:
                    return "{0}ซ้ำ กรุณาแก้ไข{0}ใหม่";
                case Error.E0054:
                    return "วันที่กำหนดฝ่ายลูกค้าต้องอยู่ในระยะเวลาของสัญญา";
                case Error.E0055:
                    return "ช่วงเวลาที่กำหนดฝ่ายลูกค้าเกิดการเหลื่อมล้ำกัน";
                case Error.E0056:
                    return "ต้องเลือก Customer Accepted ก่อนสร้างใบสั่งซื้อ";
                case Error.E0057:
                    return "ฝ่ายลูกค้าในสัญญา กับฝ่ายลูกค้าที่ระบุในหน้าระบุฝ่ายไม่ตรงกัน";
                case Error.E0058:
                    return "กรุณา{0}";
				default :
					return "";
			}
		}

		public static string GetMessage(Question question)
		{
			switch (question)
			{
				case Question.Q0001:
					return "คุณต้องการลบรายการนี้ใช่หรือไม่?";
				case Question.Q0002:
					return "เมื่อ{0}แล้วจะไม่สามารถ{1}คุณยืนยันที่จะ{2}ใช่หรือไม่";
				case Question.Q0003:
					return "คุณต้องการบันทึกข้อมูลรายการนี้ก่อนหรือไม่?";
				case Question.Q0004:
					return "คุณต้องการลบ{0} ใช่หรือไม่?";
				case Question.Q0005:
					return "คุณต้องการUpdateภาษีรถยนต์ใช่หรือไม่";
				case Question.Q0006:
					return "เนื่องจากอุบัติเหตุครั้งนี้ไม่ได้ระบุว่ามีการซ่อม \nดังนั้น ระบบจะทำการลบรายการซ่อมที่มีอยู่ออกไป \nคุณยืนยันที่จะทำงานต่อหรือไม่";
				case Question.Q0007:
					return "เนื่องจากอุบัติเหตุครั้งนี้ไม่ได้ระบุว่ามีค่าชำระรายเดือนของพนักงาน \nดังนั้น ระบบจะทำการลบข้อมูลชำระรายเดือนของพนักงานที่มีอยู่ออกไป \nคุณยืนยันที่จะทำงานต่อหรือไม่";
				case Question.Q0008:
					return "เนื่องจากมีรายการค่าบริการอยู่แล้วระบบจะทำการลบข้อมูลบริการที่มีอยู่ออกไป คุณยืนยันที่จะทำงานต่อหรือไม่";
				case Question.Q0009:
					return "คุณต้องการอนุมัติสัญญาฉบับนี้ใช่หรือไม่?";
				case Question.Q0010:
					return "มีวันหยุดถูกระบุอยู่ในช่วงวันลา คุณยืนยันที่จะทำงานต่อหรือไม่ ?";
				case Question.Q0011:
					return "คุณยืนยันที่จะทำ Daily Process ใช่หรือไม่?";
                case Question.Q0012 :
                    return "รถคันนี้มีประกันกับกรมธรรม์ฉบับอื่นในช่วงเวลานี้แล้ว คุณยืนยันที่จะทำงานต่อหรือไม่ ?";
                case Question.Q0013:
                    return "คุณต้องการยกเลิกการถ่ายโอนข้อมูลใช่หรือไม่ ?";
                case Question.Q0014:
                    return "คุณต้องการถ่ายโอนข้อมูลใช่หรือไม่ ?";
                case Question.Q0015:
                    return "คุณต้องการยกเลิกใบสั่งซื้อฉบับนี้ใช่หรือไม่ ?";
                case Question.Q0016:
                    return "คุณต้องการสร้าง{0}ใช่หรือไม่ ?";
                case Question.Q0017:
                    return "ระบบจะทำการบันทึกข้อมูลก่อนการพิมพ์ คุณยืนยันที่จะทำงานต่อหรือไม่ ?";
                case Question.Q0018:
                    return "คุณต้องการบันทึก{0}ใช่หรือไม่ ?";
                case Question.Q0019:
                    return "เนื่องจาก {0} คุณยืนยันที่จะทำงานต่อหรือไม่ ?";
                case Question.Q0020:
                    return "ข้อมูลกำลังอยู่ระหว่างการแก้ไข ท่านต้องการบันทึกข้อมูลก่อนหรือไม่ ?";
				default :
					return "";
			}
		}

	}
}