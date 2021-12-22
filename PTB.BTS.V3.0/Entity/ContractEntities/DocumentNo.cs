using System;
using System.Text;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class DocumentNo : EntityBase, IKey
	{

//		============================== Property ==============================
		private string no = NullConstant.STRING;
		public string No
		{
			get{return no;}
			set{no = value;}
		}

        //Todsporn Modified 25/2/2020 PO. Discount


        private string refer = NullConstant.STRING;
        public string Ref
        {
            get { return refer; }
            set { refer = value; }
        }
		
		
		private string year = NullConstant.STRING;
		public string Year
		{
			get{return year;}
			set{year = value;}
		}

		private string month = NullConstant.STRING;
		public string Month
		{
			get{return month;}
			set{month = value;}
		}

		private DOCUMENT_TYPE documentType;
		public DOCUMENT_TYPE DocumentType
		{
			get{return documentType;}
			set{documentType = value;}
		}

        private DocumentNo getLeasing;
        public DocumentNo GetLeasing
        {
            get { return getLeasing; }
            set { getLeasing = value; }
        }
        
        private string recipient;
        public string Recipient
        {
            get { return recipient; }
            set { recipient = value; }
        }      


//		============================== Constructor ==============================
		public DocumentNo(string value) : base()
		{
            recipient = value.Substring(0, 3);
			documentType = GetDocumentType(value.Substring(4,1));
			year = value.Substring(6,2);
			month = value.Substring(8,2);

            if (documentType == DOCUMENT_TYPE.BIZPAC_REF_NO)
            {
                no = value.Substring(10, 4);
            }
            else
            {
                no = value.Substring(10, 3);            
            }
		}

		public DocumentNo(DOCUMENT_TYPE documentType, string syear, string smonth, string runningNo) : base()
		{
            if (documentType == DOCUMENT_TYPE.BIZPAC_REF_NO)
            {
                recipient = "CNT";
                year = string.Format("{0:D2}", syear);
                month = string.Format("{0:D2}", smonth);
                no = string.Format("{0:D4}", runningNo);
            }
            else 
            { 
                recipient = "PTB";
                year = string.Format("{0:D2}", syear);
                month = string.Format("{0:D2}", smonth);
                no = string.Format("{0:D3}", runningNo);
            }
			this.documentType = documentType;
		}


		public DocumentNo(DOCUMENT_TYPE documentType, int iyear, int imonth, int runningNo) : base()
		{			
			if(iyear != NullConstant.INT)
			{
				int temp = (iyear % 100);
				year = string.Format("{0:D2}", temp);
			}
			if(imonth != NullConstant.INT)
			{
				month = string.Format("{0:D2}", imonth);
			}
			this.documentType = documentType;

            if (documentType == DOCUMENT_TYPE.BIZPAC_REF_NO)
            {
                recipient = "CNT";
                if (runningNo != NullConstant.INT)
                {
                    no = string.Format("{0:D4}", runningNo);
                }
            }
            else if (documentType == DOCUMENT_TYPE.LEASING_VEHICLE)
            {

                //Todsporn Modified 25/2/2020 PO. Discount
                recipient = "LC";
                if (runningNo != NullConstant.INT)
                {
                    no = string.Format("{0:D3}", runningNo);
                }
            }
            else
                     
            {
                recipient = "PTB";
                if (runningNo != NullConstant.INT)
                {
                    no = string.Format("{0:D3}", runningNo);
                }
            }
		}

        //D21018-BTS Contract Modification
        public DocumentNo(string documentType, string syear, string smonth, string runningNo) : base() 
        {
            DOCUMENT_TYPE docuType = GetDocumentType(documentType);
            FormatContractNo(docuType, syear, smonth, runningNo);
        }

        public void FormatContractNo(DOCUMENT_TYPE documentType, string syear, string smonth, string runningNo)
        {
            if (documentType == DOCUMENT_TYPE.BIZPAC_REF_NO)
            {
                recipient = "CNT";
                year = string.Format("{0:D2}", syear);
                month = string.Format("{0:D2}", smonth);
                no = string.Format("{0:D4}", runningNo);
            }
            else
            {
                recipient = "PTB";
                year = string.Format("{0:D2}", syear);
                month = string.Format("{0:D2}", smonth);
                no = string.Format("{0:D3}", runningNo);
            }
            this.documentType = documentType;
        }

		#region - Enum Function -

		private const string ACCIDENT = "A";
		private const string CONTRACT = "C";
		private const string MAINTENANCE = "M";
        private const string BIZPACREFNO = "Z";
        private const string QUOTATIONVEHICLE = "Q";
        private const string LEASINGVEHICLE = "L";
        private const string PURCHASINGVEHICLE = "P";
        
        //D21018-BTS Contract Modification
        private const string VEHICLE_RENEWAL = "R";
        private const string VEHICLE_TEMPORARY = "T";
        private const string DRIVER = "D";

		private DOCUMENT_TYPE GetDocumentType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case ACCIDENT : 
					return DOCUMENT_TYPE.ACCIDENT;
				case CONTRACT : 
					return DOCUMENT_TYPE.CONTRACT;
				case MAINTENANCE : 
					return DOCUMENT_TYPE.MAINTENANCE;
                case BIZPACREFNO:
                    return DOCUMENT_TYPE.BIZPAC_REF_NO;
                case QUOTATIONVEHICLE:
                    return DOCUMENT_TYPE.QUOTATION_VEHICLE;
                
                //Todsporn Modified 25/2/2020 PO. Discount

                case LEASINGVEHICLE:
                    return DOCUMENT_TYPE.QUOTATION_VEHICLE;
                case PURCHASINGVEHICLE:
                    return DOCUMENT_TYPE.PURCHASING_VEHICLE;

                //D21018-BTS Contract Modification
                case VEHICLE_RENEWAL:
                    return DOCUMENT_TYPE.CONTRACT_RENEWAL;
                case VEHICLE_TEMPORARY:
                    return DOCUMENT_TYPE.CONTRACT_TEMPORARY;
                case DRIVER:
                    return DOCUMENT_TYPE.CONTRACT_DRIVER;
                default:
                    return DOCUMENT_TYPE.NULL;

			}			
		}

		private string GetString(DOCUMENT_TYPE value)
		{
			switch (value)
			{
				case DOCUMENT_TYPE.ACCIDENT : 
					return ACCIDENT;
				case DOCUMENT_TYPE.CONTRACT : 
					return CONTRACT;
				case DOCUMENT_TYPE.MAINTENANCE : 
					return MAINTENANCE;
                case DOCUMENT_TYPE.BIZPAC_REF_NO:
                    return BIZPACREFNO;
                case DOCUMENT_TYPE.QUOTATION_VEHICLE:
                    return QUOTATIONVEHICLE;

                //Todsporn Modified 25/2/2020 PO. Discount
                case DOCUMENT_TYPE.LEASING_VEHICLE:
                    return QUOTATIONVEHICLE;

                case DOCUMENT_TYPE.PURCHASING_VEHICLE:
                    return PURCHASINGVEHICLE;

                //D21018-BTS Contract Modification
                case DOCUMENT_TYPE.CONTRACT_RENEWAL:
                    return VEHICLE_RENEWAL;
                case DOCUMENT_TYPE.CONTRACT_TEMPORARY:
                    return VEHICLE_TEMPORARY;
                case DOCUMENT_TYPE.CONTRACT_DRIVER:
                    return DRIVER;

				default : 
					return NullConstant.STRING;
			}
			
		}
		#endregion

//		============================== Public Property ==============================
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(recipient);
            stringBuilder.Append("-");
			stringBuilder.Append(GetString(documentType));
			stringBuilder.Append("-");
			stringBuilder.Append(year);
			stringBuilder.Append(month);
			stringBuilder.Append(no);
			string str = stringBuilder.ToString();
			stringBuilder = null;
			return str;
		}

//		============================== Public Method ==============================

		#region IKey Members
		public override string EntityKey
		{
			get
			{
				return this.ToString();
			}
		}
		#endregion


 




	}
}
