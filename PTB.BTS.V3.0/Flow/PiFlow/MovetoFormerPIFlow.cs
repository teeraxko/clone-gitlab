using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	public class MovetoFormerPIFlow : FlowBase
	{
		#region - Private -
			private PiTransactionDB dbPiTransaction;
			private FormerTransactionDB dbFormerTransaction;
		#endregion

//		================================Constructor=====================
		public MovetoFormerPIFlow(Company value) : base()
		{
			dbPiTransaction = new PiTransactionDB(value);
			dbFormerTransaction = new FormerTransactionDB(value);
		}

		private bool moveToFormer(Employee value)
		{
			dbPiTransaction.ReNew(value.Company);
			dbPiTransaction.AEmployeeInfo.EmployeeNo = value.EmployeeNo;
			dbPiTransaction.FillList();

			dbFormerTransaction.ReNew(value.Company);
			dbFormerTransaction.AEmployeeInfo = dbPiTransaction.AEmployeeInfo;
			dbFormerTransaction.AEmployeeAddress = dbPiTransaction.AEmployeeAddress;
			dbFormerTransaction.AEmployeeFather = dbPiTransaction.AEmployeeFather;
			dbFormerTransaction.AEmployeeMother = dbPiTransaction.AEmployeeMother;
			dbFormerTransaction.AReferencePerson = dbPiTransaction.AReferencePerson;
			dbFormerTransaction.AGuarantor = dbPiTransaction.AGuarantor;
			dbFormerTransaction.AEmployeeSpouse = dbPiTransaction.AEmployeeSpouse;
			dbFormerTransaction.ASalary = dbPiTransaction.ASalary;
			dbFormerTransaction.AEmployeeChildrenList = dbPiTransaction.AEmployeeChildrenList;
			dbFormerTransaction.AEmployeeEducation = dbPiTransaction.AEmployeeEducation;
			dbFormerTransaction.AEmployeeSpecialAllowance = dbPiTransaction.AEmployeeSpecialAllowance;
			dbFormerTransaction.AEmployeeWorkBackground = dbPiTransaction.AEmployeeWorkBackground;

			TableAccess tableAccess = new TableAccess();
			tableAccess.OpenTransaction();

			bool result = false;
			try
			{
				if(dbFormerTransaction.InsertTransaction(tableAccess))
				{
					if(dbPiTransaction.DeleteTransaction(tableAccess))
					{
						result = true;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;

				}
				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
				tableAccess = null;
			}
			return result;
		}

//		============================== Public Method ==============================
		public bool MoveEmployee(EmployeeList objEmployeeList)
		{
			bool result = true;

			for(int i=0; i<objEmployeeList.Count; i++)
			{
				result &= moveToFormer(objEmployeeList[i]);
			}
			return result;	
		}
	}
}
