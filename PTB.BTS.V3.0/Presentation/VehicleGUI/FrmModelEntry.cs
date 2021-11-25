using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Facade.CommonFacade;
using Entity.VehicleEntities;
using SystemFramework.AppConfig;
using SystemFramework.AppException;
using System.Data.SqlClient;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI
{
    public partial class FrmModelEntry : EntryFormBase
    {
        #region - private -
        private bool isReadonly = true;
        private FrmModel parentForm;
        #endregion

        //============================== Constructor ==============================
        public FrmModelEntry(FrmModel parentForm)
            : base()
        {
            InitializeComponent();
            this.parentForm = parentForm;
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleModel");

            try
            {
                cboModelType.DataSource = parentForm.FacadeModel.DataSourceModelType;
                cboGearType.DataSource = parentForm.FacadeModel.DataSourceGearType;
                cboGasolineType.DataSource = parentForm.FacadeModel.DataSourceGasolineType;
                cboBreakType.DataSource = parentForm.FacadeModel.DataSourceBreakType;
                cboVendor.DataSource = parentForm.FacadeModel.DataSourceVendor;
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        //============================== private method ==============================
        private void enableKeyField(bool enable)
        {
            txtBrandCode.Enabled = enable;
            txtModelCode.Enabled = enable;
        }

        private void clearForm()
        {
            txtModelCode.Text = "";
            txtThaiModelName.Text = "";
            txtEngModelName.Text = "";
            fpiEngineCC.Text = "0";
            fpiNoOfSeat.Text = "0";
            InitCombo();
            txtModelCode.Focus();
        }

        private void setBrand()
        {
            txtBrandCode.Text = parentForm.Brand.Code;
            txtBrandName.Text = parentForm.Brand.AName.English;
        }

        private void setModel(Model value)
        {
            txtModelCode.Text = value.Code;
            txtThaiModelName.Text = value.AName.Thai;
            txtEngModelName.Text = value.AName.English;
            cboModelType.Text = value.AModelType.AName.Thai;
            cboGearType.Text = GUIFunction.GetString(value.GearType);
            cboBreakType.Text = GUIFunction.GetString(value.BreakType);
            cboGasolineType.Text = value.AGasolineType.AName.Thai;
            fpiEngineCC.Text = GUIFunction.GetString(value.EngineCC);
            fpiNoOfSeat.Text = GUIFunction.GetString(value.NoOfSeat);
        }

        private void setVendor(Model value)
        {
            Vendor vendor = parentForm.FacadeModel.GetSpecificVendor(value);

            if (vendor != null)
            {
                cboVendor.Text = vendor.ToString();
            }
            else
            {
                cboVendor.SelectedIndex = -1;
            }       
        }

        private Model getModel()
        {
            Model objModel = new Model();
            objModel.ABrand.Code = txtBrandCode.Text;
            objModel.Code = txtModelCode.Text;
            objModel.AName.Thai = txtThaiModelName.Text;
            objModel.AName.English = txtEngModelName.Text;
            objModel.AModelType = (ModelType)cboModelType.SelectedItem;
            objModel.GearType = CTFunction.GetGearType(cboGearType.Text);
            objModel.BreakType = CTFunction.GetBreakType(cboBreakType.Text);
            objModel.AGasolineType = (GasolineType)cboGasolineType.SelectedItem;
            objModel.EngineCC = Convert.ToInt32(fpiEngineCC.Text);
            objModel.NoOfSeat = Convert.ToInt32(fpiNoOfSeat.Text);
            return objModel;
        }

        private Vendor getVendor()
        {
            Vendor vendor = new Vendor();

            if (cboVendor.Text == "")
            {
                return vendor;
            }
            else
            {
                return (Vendor)cboVendor.SelectedItem;
            }
        }

        #region - Validate -
        private bool validateForm()
        {
            return validate1() && validate2() && validate3() && validate4() && validate5() && validate6() && validate7() && validate8() && validate9();
        }

        private bool validate1()
        {
            if (txtModelCode.Text == "")
            {
                Message(MessageList.Error.E0002, "รหัสรุ่น");
                txtModelCode.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate2()
        {
            if (txtThaiModelName.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อรุ่น(ภาษาไทย)");
                txtThaiModelName.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate3()
        {
            if (txtEngModelName.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อรุ่น(ภาษาอังกฤษ)");
                txtEngModelName.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate4()
        {
            if (cboModelType.Text == "")
            {
                Message(MessageList.Error.E0005, "ประเภทรุ่น");
                cboModelType.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate5()
        {
            if (cboGearType.Text == "")
            {
                Message(MessageList.Error.E0005, "ประเภทเกียร์");
                cboGearType.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate6()
        {
            if (cboBreakType.Text == "")
            {
                Message(MessageList.Error.E0005, "ประเภทเบรค");
                cboBreakType.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate7()
        {
            if (cboGasolineType.Text == "")
            {
                Message(MessageList.Error.E0005, "ประเภทเชื้อเพลิง");
                cboGasolineType.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate8()
        {
            if (fpiEngineCC.Text == "0")
            {
                Message(MessageList.Error.E0002, "ซีซี");
                fpiEngineCC.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate9()
        {
            if (fpiNoOfSeat.Text == "0")
            {
                Message(MessageList.Error.E0002, "จำนวนที่นั่ง");
                fpiNoOfSeat.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        //============================== public method ==============================
        public void InitAddAction()
        {
            baseADD();
            clearForm();

            setBrand();
            enableKeyField(true);
            txtBrandCode.Enabled = false;
            this.Text = "เพิ่มข้อมูลรุ่นรถ";
        }

        public void InitEditAction(Model model)
        {
            baseEDIT();
            clearForm();
            setBrand();
            setModel(model);
            setVendor(model);
            enableKeyField(false);
            this.Text = "แก้ไขข้อมูลรุ่นรถ";

            if (isReadonly)
            {
                btnOK.Enabled = false;
            }
        }

        public void InitCombo()
        {
            cboModelType.SelectedIndex = -1;
            cboGearType.SelectedIndex = -1;
            cboBreakType.SelectedIndex = -1;
            cboGasolineType.SelectedIndex = -1;
        }

        public void ThaiModelName()
        {
            txtThaiModelName.Focus();
        }

        //============================== Base event ==============================
        private void AddEvent()
        {
            try
            {
                if (validateForm() && parentForm.AddRow(getModel(), getVendor()))
                {
                    clearForm();
                    InitAddAction();
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
                txtModelCode.Focus();
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void EditEvent()
        {
            try
            {
                if (validateForm() && parentForm.UpdateRow(getModel(), getVendor()))
                {
                    this.Hide();
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        //================================= event ================================
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    AddEvent();
                    break;
                case ActionType.EDIT:
                    EditEvent();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmModelEntry_Load(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    InitAddAction();
                    break;
            }
        }
    }
}