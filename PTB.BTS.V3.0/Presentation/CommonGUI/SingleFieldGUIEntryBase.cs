using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;

using Facade.CommonFacade;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

using ictus.Common.Entity.General;

namespace Presentation.CommonGUI
{
	public class SingleFieldGUIEntryBase : EntryFormBase
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		protected System.Windows.Forms.TextBox txtName;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// cmdOK
			// 
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(188, 72);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 2;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(268, 72);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(13, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(560, 56);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtName.HideSelection = false;
			this.txtName.Location = new System.Drawing.Point(112, 22);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(432, 22);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// SingleFieldGUIEntryBase
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(586, 112);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SingleFieldGUIEntryBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.SingleFieldGUIEntryBase_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SingleFieldGUIEntryBase_Paint);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		protected bool isReadonly = false;
		private SingleFieldGUIMainBase parentForm;
        private ictus.Common.Entity.General.SingleFieldBase objSingleField;
		protected string lable
		{
			set
			{
				label1.Text = value;
			}
		}

		protected int Maxlength
		{
			set
			{
				txtName.MaxLength = value;
			}
		}

		#endregion

        protected virtual ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return null;
		}

//		============================== Property ==============================
        public ictus.Common.Entity.General.SingleFieldBase getSingleFieldBase()
		{
			objSingleField = getNew();
			objSingleField.Name =  txtName.Text;     
			return objSingleField;
		}
		public void setSingleFieldBase(SingleFieldBase value)
		{
			objSingleField = value;
			txtName.Text = GUIFunction.GetString(objSingleField.Name);
			txtName.Focus();
		}
	
//		============================== Constructor ==============================
		public SingleFieldGUIEntryBase() : base()
		{}
		
		public SingleFieldGUIEntryBase(SingleFieldGUIMainBase parentForm):base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			txtName.Focus();
		}
//		============================== private method ==============================
		private void clearForm()
		{
			txtName.Text = "";
		}

		private bool ValidateForm()
		{
			if(txtName.Text.Trim() == "") 
			{
				Message(MessageList.Error.E0002, "ข้อมูล" );
				txtName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
//		============================== public method ==============================
		public void SetFocus()
		{
			this.txtName.Focus();
		}
		
		public void InitAddAction()
		{
			baseADD();
			clearForm();
		}

		public void InitEditAction(SingleFieldBase aSingleFieldBase)
		{
			baseEDIT();
			clearForm();
			setSingleFieldBase(aSingleFieldBase);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm()&& parentForm.AddRow(getSingleFieldBase()))
				{
					clearForm();
					SetFocus();
				}

			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
		}

		private void EditEvent()
		{
			try
			{
				if (ValidateForm()&& parentForm.UpdateRow(getSingleFieldBase()))
				{
					this.Hide();
				}

			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}	
		}

//		============================== event ==============================

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
		
			switch (action)
			{					
				case ActionType.ADD :
					AddEvent();
					break;
				case ActionType.EDIT :
					EditEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void SingleFieldGUIEntryBase_Load(object sender, System.EventArgs e)
		{
		
		}

		private void SingleFieldGUIEntryBase_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			txtName.Focus();
		}

	}
}
