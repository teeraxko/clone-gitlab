using System;

using Entity.CommonEntity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class RepairingSpareParts : EntityBase, IKey
	{
//		============================== Property ==============================
		private SpareParts aSpareParts;
		public SpareParts ASpareParts
		{
			set{aSpareParts = value;}
			get{return aSpareParts;}
		}

		private string description = NullConstant.STRING;
		public string Description
		{
			set{description = value.Trim();}
			get{return description;}
		}

		private EXPENSE_STATUS_TYPE expenseStatus = EXPENSE_STATUS_TYPE.NULL;
		public EXPENSE_STATUS_TYPE ExpenseStatus
		{
			set{expenseStatus = value;}
			get{return expenseStatus;}
		}

//		===============================Constructor=========================
		public RepairingSpareParts() : base()
		{}

		#region IKey Members
		public override string EntityKey
		{
			get
			{return aSpareParts.EntityKey;}
		}
		#endregion
	}
}
