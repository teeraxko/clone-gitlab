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
	public class DualFieldGUIEntryBase : EntryFormBase
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
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtENName;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTHName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtENName = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(280, 136);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "¡��ԡ";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(192, 136);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "��ŧ";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// txtCode
			// 
			this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtCode.Location = new System.Drawing.Point(224, 24);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(48, 20);
			this.txtCode.TabIndex = 1;
			this.txtCode.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// txtTHName
			// 
			this.txtTHName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtTHName.Location = new System.Drawing.Point(224, 56);
			this.txtTHName.MaxLength = 50;
			this.txtTHName.Name = "txtTHName";
			this.txtTHName.Size = new System.Drawing.Size(304, 20);
			this.txtTHName.TabIndex = 2;
			this.txtTHName.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "label2";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtCode);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtTHName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtENName);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(536, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 18);
			this.label3.TabIndex = 9;
			this.label3.Text = "label3";
			// 
			// txtENName
			// 
			this.txtENName.Location = new System.Drawing.Point(224, 88);
			this.txtENName.MaxLength = 50;
			this.txtENName.Name = "txtENName";
			this.txtENName.Size = new System.Drawing.Size(304, 20);
			this.txtENName.TabIndex = 3;
			this.txtENName.Text = "";
			// 
			// DualFieldGUIEntryBase
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(554, 168);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "DualFieldGUIEntryBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DualFieldGUIEntryBase_Paint);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		protected bool isReadonly = false;
		private DualFieldGUIMainBase parentForm;
        private ictus.Common.Entity.General.DualFieldBase objDualField;
		#endregion

		protected int maxLength
		{
			set
			{
				txtCode.MaxLength = value;
			}
		}
		protected string lable1
		{
			set
			{
				label1.Text = value;
			}
		}
		protected string lable2
		{
			set
			{
				label2.Text = value;

			}
		}
		protected string lable3
		{
			set
			{
				label3.Text = value;

			}
		}
        protected virtual ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return null;
		}
		protected virtual void setFocusCode()
		{
			txtCode.Focus();
		}
		protected virtual void setFocusTHName()
		{
			txtTHName.Focus();
		}
		
		//		============================== Property ==============================

        public ictus.Common.Entity.General.DualFieldBase getDualFieldBase()
		{
			objDualField = getNew();
			objDualField.Code = txtCode.Text;
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = txtTHName.Text;
            description.English = txtENName.Text;
            objDualField.AName = description;
			
			return objDualField;
		}
		public void setDualFieldBase(DualFieldBase value)
		{
			objDualField = value;
			txtCode.Text = GUIFunction.GetString(objDualField.Code);
			txtTHName.Text = GUIFunction.GetString(objDualField.AName.Thai);
			txtENName.Text = GUIFunction.GetString(objDualField.AName.English);
		}
		//		============================== Constructor ==============================

		public DualFieldGUIEntryBase(DualFieldGUIMainBase parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
		}
		
		//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtCode.Enabled = enable;
		}
		private void clearForm()
		{
			txtCode.Text = "";
			txtENName.Text = "";
			txtTHName.Text = "";
			txtCode.Focus();
		}
		private bool ValidateCode()
		{
			if(txtCode.Text.Trim() == "") 
			{
				Message(MessageList.Error.E0002, "����" );
				txtCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateTHName()
		{
			if(txtTHName.Text.Trim() == "") 
			{
				Message(MessageList.Error.E0002, "����������" );
				txtTHName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			setFocusCode();
			enableKeyField(true);
			InitFocusCode();
		}
		public void InitEditAction(DualFieldBase aDualFieldBase)
		{
			baseEDIT();
			clearForm();
			setDualFieldBase(aDualFieldBase);
			enableKeyField(false);
			InitFocusTHName();

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void InitFocusCode()
		{
			txtCode.Focus();
		}
		public void InitFocusTHName()
		{
			txtTHName.Focus();
		}
		//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				if (ValidateCode() && ValidateTHName() && parentForm.AddRow(getDualFieldBase()))
				{
					clearForm();
				}
			}
			catch(DuplicateException dup)
			{
				Message(dup);
				if(dup.IsThai)
				{
					setSelected(txtTHName);
				}
				else
				{
					setSelected(txtENName);
				}
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				setSelected(txtCode);
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
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
				if (ValidateCode() && ValidateTHName() && parentForm.UpdateRow(getDualFieldBase()))
				{
					this.Hide();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(DuplicateException dup)
			{
				Message(dup);
				if(dup.IsThai)
				{
					setSelected(txtTHName);
				}
				else
				{
					setSelected(txtENName);
				}
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

		private void DualFieldGUIEntryBase_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
				{
					txtCode.Focus();
					if (txtCode.Text != "" && txtTHName.Text == "")
						txtTHName.Focus();
					break;
				}
				case ActionType.EDIT :
				{
					txtTHName.Focus();
					break;
				}
			}
		}

		
	}
}
