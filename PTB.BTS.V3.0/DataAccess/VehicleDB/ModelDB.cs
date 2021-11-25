using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity.General;
using ictus.Common.Entity; 

namespace DataAccess.VehicleDB
{
	public class ModelDB : DataAccessBase
	{
		#region - Constant -		
		private const int BRAND_CODE = 0;
		private const int MODEL_CODE = 1;
        private const int VENDOR_CODE = 2;
        private const int MODEL_ENGLISH_NAME = 3;
		private const int MODEL_THAI_NAME = 4;
		private const int ENGINE_CC = 5;
		private const int GEAR_TYPE = 6;
		private const int BREAK_TYPE = 7;
		private const int GASOLINE_TYPE = 8;
		private const int MODEL_TYPE = 9;
		private const int NO_OF_SEAT = 10;
		#endregion

		#region - Private -
		private Model objModel;
		private BrandDB dbBrand;
		private GasolineTypeDB dbGasolineType;
		private ModelTypeDB dbModelType;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public ModelDB() : base()
		{
			dbBrand = new BrandDB();
			dbGasolineType = new GasolineTypeDB();
			dbModelType = new ModelTypeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return " SELECT Brand_Code, Model_Code, Vendor_Code, Model_English_Name, Model_Thai_Name, Engine_CC, Gear_Type, Break_Type, Gasoline_Type, Model_Type, No_Of_Seat FROM Model ";
		}

		private string getSQLInsert(Model aModel, Vendor vendor)
		{
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Model (Brand_Code, Model_Code, Vendor_Code, Model_English_Name, Model_Thai_Name, Engine_CC, Gear_Type, Break_Type, Gasoline_Type, Model_Type, No_Of_Seat, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Brand_Code
			stringBuilder.Append(GetDB(aModel.ABrand.Code));
			stringBuilder.Append(", ");

			//Model_Code			
			stringBuilder.Append(GetDB(aModel.Code));
			stringBuilder.Append(", ");

            //Vendor_Code
            stringBuilder.Append(GetDB(vendor.Code));
            stringBuilder.Append(", ");

			//Model_English_Name
			stringBuilder.Append(GetDB(aModel.AName.English));
			stringBuilder.Append(", ");

			//Model_Thai_Name
			stringBuilder.Append(GetDB(aModel.AName.Thai));
			stringBuilder.Append(", ");

			//Engine_CC
			stringBuilder.Append(GetDB(aModel.EngineCC));
			stringBuilder.Append(", ");

			//Gear_Type
			stringBuilder.Append(GetDB(aModel.GearType));
			stringBuilder.Append(", ");

			//Break_Type
			stringBuilder.Append(GetDB(aModel.BreakType));
			stringBuilder.Append(", ");

			//Gasoline_Type
			stringBuilder.Append(GetDB(aModel.AGasolineType.Code));
			stringBuilder.Append(", ");

			//Model_Type
			stringBuilder.Append(GetDB(aModel.AModelType.Code));
			stringBuilder.Append(", ");

			//No_Of_Seat
			stringBuilder.Append(GetDB(aModel.NoOfSeat));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Model aModel, Vendor vendor)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Model SET ");
			stringBuilder.Append("Brand_Code = ");
			stringBuilder.Append(GetDB(aModel.ABrand.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Model_Code = ");
			stringBuilder.Append(GetDB(aModel.Code));
			stringBuilder.Append(", ");

            stringBuilder.Append("Vendor_Code = ");
            stringBuilder.Append(GetDB(vendor.Code));
            stringBuilder.Append(", ");

			stringBuilder.Append("Model_English_Name = ");
			stringBuilder.Append(GetDB(aModel.AName.English));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Model_Thai_Name = ");
			stringBuilder.Append(GetDB(aModel.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Engine_CC = ");
			stringBuilder.Append(GetDB(aModel.EngineCC));
			stringBuilder.Append(", ");

			stringBuilder.Append("Gear_Type = ");
			stringBuilder.Append(GetDB(aModel.GearType));
			stringBuilder.Append(", ");

			stringBuilder.Append("Break_Type = ");
			stringBuilder.Append(GetDB(aModel.BreakType));
			stringBuilder.Append(", ");

			stringBuilder.Append("Gasoline_Type = ");
			stringBuilder.Append(GetDB(aModel.AGasolineType.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Model_Type = ");
			stringBuilder.Append(GetDB(aModel.AModelType.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("No_Of_Seat = ");
			stringBuilder.Append(GetDB(aModel.NoOfSeat));
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Model ";
		}

		private string getListCondition(Brand value)
		{
			if (IsNotNULL(value.Code))
			{
				StringBuilder stringBuilder = new StringBuilder(" AND (Brand_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
				return stringBuilder.ToString();
			}
			return "";
		}

		private string getKeyCondition(Model value)
		{
			if (IsNotNULL(value.Code))
			{
				StringBuilder stringBuilder = new StringBuilder(" AND (Model_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
				return stringBuilder.ToString();
			}
			return "";
		}

		private string getOrderby()
		{
			return " ORDER BY Model_Code ";
		}
		#endregion

		#region - Fill -
		private void fillModel(ref Model aModel, SqlDataReader dataReader)
		{
			Brand brand = (Brand)dbBrand.GetMTB((string)dataReader[BRAND_CODE]);
			fillModel(ref aModel, brand, dataReader);
		}

		private void fillModel(ref Model aModel, Brand aBrand, SqlDataReader dataReader)
		{
			aModel.ABrand = aBrand;
			aModel.Code = (string)dataReader[MODEL_CODE];
			aModel.AName.English = 	(string)dataReader[MODEL_ENGLISH_NAME];
			aModel.AName.Thai = (string)dataReader[MODEL_THAI_NAME];
			aModel.EngineCC = dataReader.GetInt16(ENGINE_CC);
			aModel.GearType = CTFunction.GetGeartype((string)dataReader[GEAR_TYPE]);
			aModel.BreakType = CTFunction.GetBreaktype((string)dataReader[BREAK_TYPE]);
			aModel.AGasolineType = (GasolineType)dbGasolineType.GetMTB((string)dataReader[GASOLINE_TYPE]);
			aModel.AModelType = (ModelType)dbModelType.GetMTB((string)dataReader[MODEL_TYPE]);
			aModel.NoOfSeat = dataReader.GetByte(NO_OF_SEAT);
		}

		private bool fillModelList(ref ModelList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objModel = new Model();
					fillModel(ref objModel, value.ABrand, dataReader);
					value.Add(objModel);
				}
				objModel = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		private bool fillModel(ref Model value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillModel(ref value, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}			
			return result;				
		}
		#endregion

//		============================== Public Method ==============================
		public Model GetModel(string modelCode, string brandNo)
		{
			objModel = new Model();
			Brand objBrand = new Brand();
			objBrand.Code = brandNo;
			objModel.Code = modelCode;
			objModel.ABrand = objBrand;
			objBrand = null;

			if(FillModel(ref objModel))
			{
				return objModel;		
			}
			else
			{
				objModel = null;
				return null;
			}
		}

		internal Model GetDBModel(string modelCode, string brandNo)
		{
			objModel = new Model();
			Brand objBrand = new Brand();
			objBrand.Code = brandNo;
			objModel.Code = modelCode;
			objModel.ABrand = objBrand;
			objBrand = null;

			if(FillModel(ref objModel))
			{
				return objModel;		
			}
			else
			{
				objModel.Code = NullConstant.STRING;
				objModel.ABrand.Code = NullConstant.STRING;

				return objModel;
			}
		}

        public Vendor GetSpecificVendor(Model model, Company company)
        {
            Vendor vendor = new Vendor();
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition());
            stringBuilder.Append(getListCondition(model.ABrand));
            stringBuilder.Append(getKeyCondition(model));

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
            try
            {
                if (dataReader.Read())
                {
                    using (VendorDB dbVendor = new VendorDB())
                    {
                        vendor = dbVendor.GetDBVendor((string)dataReader[VENDOR_CODE], company);
                    }
                }
                else
                {
                    vendor = null;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }

            stringBuilder = null;
            return vendor;				
        }

		public bool FillModel(ref Model value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getListCondition(value.ABrand));
			stringBuilder.Append(getKeyCondition(value));

			return fillModel(ref value, stringBuilder.ToString());
		}

		public bool FillModelList(ref ModelList aModelList)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getListCondition(aModelList.ABrand));
			stringBuilder.Append(getOrderby());

			return fillModelList(ref aModelList, stringBuilder.ToString());
		}

		public bool FillModelList(ref ModelList aModelList, Model aModel)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getListCondition(aModelList.ABrand));
			stringBuilder.Append(getKeyCondition(aModel));
			stringBuilder.Append(getOrderby());

			return fillModelList(ref aModelList, stringBuilder.ToString());
		}

		public bool InsertModel(Model aModel, Vendor vendor)
		{
            if (tableAccess.ExecuteSQL(getSQLInsert(aModel, vendor)) > 0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateModel(Model value, Vendor vendor)
		{
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, vendor));
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getListCondition(value.ABrand));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteModel(Model value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getListCondition(value.ABrand));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbBrand.Dispose();
						dbGasolineType.Dispose();
						dbModelType.Dispose();

						dbBrand = null;
						dbGasolineType = null;;
						dbModelType = null;
						objModel = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
