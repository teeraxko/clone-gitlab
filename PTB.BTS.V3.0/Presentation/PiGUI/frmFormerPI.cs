using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Facade.PiFacade;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
    public class frmFormerPI : frmPI
    {
        #region Windows Form Designer generated code
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private System.ComponentModel.Container components = null;

        private new void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }
        #endregion

        public frmFormerPI()
            : base()
        {
            InitializeComponent();
            cboDepartment.DropDownStyle = ComboBoxStyle.Simple;
            cboBank.DropDownStyle = ComboBoxStyle.Simple;
            cboDriverLicenseType.DropDownStyle = ComboBoxStyle.Simple;
            cboEngPrefix.DropDownStyle = ComboBoxStyle.Simple;
            cboGender.DropDownStyle = ComboBoxStyle.Simple;
            cboKindOfOT.DropDownStyle = ComboBoxStyle.Simple;
            cboKindOfStaff.DropDownStyle = ComboBoxStyle.Simple;
            cboMaritalStatus.DropDownStyle = ComboBoxStyle.Simple;
            cboMilitaryStatus.DropDownStyle = ComboBoxStyle.Simple;
            cboNationality.DropDownStyle = ComboBoxStyle.Simple;
            cboPosition.DropDownStyle = ComboBoxStyle.Simple;
            cboRace.DropDownStyle = ComboBoxStyle.Simple;
            cboReligion.DropDownStyle = ComboBoxStyle.Simple;
            cboSection.DropDownStyle = ComboBoxStyle.Simple;
            cboBloodGroup.DropDownStyle = ComboBoxStyle.Simple;
            //			cboShiftNo.DropDownStyle = ComboBoxStyle.Simple;
            cboSOccupation.DropDownStyle = ComboBoxStyle.Simple;
            cboSPrefix.DropDownStyle = ComboBoxStyle.Simple;
            cboThaiPrefix.DropDownStyle = ComboBoxStyle.Simple;
            cboTitle.DropDownStyle = ComboBoxStyle.Simple;
            cboWorkingStatus.DropDownStyle = ComboBoxStyle.Simple;
            cboHospital.DropDownStyle = ComboBoxStyle.Simple;
            mniAddchildren.Enabled = false;
            mniAddEducation.Enabled = false;
            mniAddSpecialAllowance.Enabled = false;
            mniAddworkbackground.Enabled = false;
            mniDeletechildren.Enabled = false;
            mniDeleteEducation.Enabled = false;
            mniDeleteSpecialAllowance.Enabled = false;
            mniDeleteworkbackground.Enabled = false;


            uctAge3.Enabled = false;
            UCTFather.uctAge1.Enabled = false;
            UCTMother.uctAge1.Enabled = false;
            UCTGuaruntor.uctAge1.Enabled = false;
            UCTReference.uctAge1.Enabled = false;


            UCTGuaruntor.cboGender.DropDownStyle = ComboBoxStyle.Simple;
            UCTGuaruntor.cboOccupation.DropDownStyle = ComboBoxStyle.Simple;
            UCTGuaruntor.cboRelationShip.DropDownStyle = ComboBoxStyle.Simple;
            UCTGuaruntor.uctAddress1.cboStreet.DropDownStyle = ComboBoxStyle.Simple;
            UCTGuaruntor.uctAddress1.cboSubDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTGuaruntor.uctAddress1.cboDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTGuaruntor.uctAddress1.cboProvince.DropDownStyle = ComboBoxStyle.Simple;

            UCTReference.cboGender.DropDownStyle = ComboBoxStyle.Simple;
            UCTReference.cboOccupation.DropDownStyle = ComboBoxStyle.Simple;
            UCTReference.cboRelationShip.DropDownStyle = ComboBoxStyle.Simple;
            UCTReference.uctAddress1.cboStreet.DropDownStyle = ComboBoxStyle.Simple;
            UCTReference.uctAddress1.cboSubDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTReference.uctAddress1.cboDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTReference.uctAddress1.cboProvince.DropDownStyle = ComboBoxStyle.Simple;

            UCTHAddress.cboStreet.DropDownStyle = ComboBoxStyle.Simple;
            UCTHAddress.cboSubDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTHAddress.cboDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTHAddress.cboProvince.DropDownStyle = ComboBoxStyle.Simple;

            UCTOAddress.cboStreet.DropDownStyle = ComboBoxStyle.Simple;
            UCTOAddress.cboSubDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTOAddress.cboDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTOAddress.cboProvince.DropDownStyle = ComboBoxStyle.Simple;


            UCTCurrentAddress.cboStreet.DropDownStyle = ComboBoxStyle.Simple;
            UCTCurrentAddress.cboSubDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTCurrentAddress.cboDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTCurrentAddress.cboProvince.DropDownStyle = ComboBoxStyle.Simple;

            UCTRegisterAddress.cboStreet.DropDownStyle = ComboBoxStyle.Simple;
            UCTRegisterAddress.cboSubDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTRegisterAddress.cboDistrict.DropDownStyle = ComboBoxStyle.Simple;
            UCTRegisterAddress.cboProvince.DropDownStyle = ComboBoxStyle.Simple;

            UCTFather.cboOccupation.DropDownStyle = ComboBoxStyle.Simple;
            UCTFather.cboPrefix.DropDownStyle = ComboBoxStyle.Simple;

            UCTMother.cboOccupation.DropDownStyle = ComboBoxStyle.Simple;
            UCTMother.cboPrefix.DropDownStyle = ComboBoxStyle.Simple;

            children.MenuItems.Clear();
            education.MenuItems.Clear();
            workingbackground.MenuItems.Clear();
            specialallowance.MenuItems.Clear();

            cmdOK.Visible = false;
            cmdCopy.Visible = false;

            visibleOK = false;

            UCTCurrentAddress.HasMobile = true;
            UCTRegisterAddress.HasMobile = true;
        }

        public override void RefreshForm()
        {
            base.RefreshForm();
            mdiParent.EnableDeleteCommand(false);
            MainMenuNewStatus = false;
            MainMenuDeleteStatus = false;
            IsMustQuestion = false;
        }

        protected override void Title()
        {
            this.Text = UserProfile.GetFormName("miPI", "miPIEmployeeFormerPI");
        }

        protected override void TitleEdit()
        {
            this.Text = "·°È‰¢" + UserProfile.GetFormName("miPI", "miPIEmployeeFormerPI"); ;
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIEmployeeFormerPI");
        }

        protected override void setDataSource()
        { }

        protected override void BaseNew()
        {
            facadePI = new FormerFacade();
        }

        protected override void nullException(EmpNotFoundException ex)
        {
            InitForm();
            Message(ex);
        }

        protected override void txtDriverLicenseNo_TextChanged(object sender, System.EventArgs e)
        {
            facadePI.EmployeeChange = true;
        }

        protected override void txtEmployeeNo_DoubleClick(object sender, System.EventArgs e)
        {
            frmFormerEmpList dialogFormerEmplist = new frmFormerEmpList();
            dialogFormerEmplist.ShowDialog();
            if (dialogFormerEmplist.Selected)
            {
                txtEmployeeNo.Text = dialogFormerEmplist.SelectedEmployee.EmployeeNo;
            }
        }
    }
}