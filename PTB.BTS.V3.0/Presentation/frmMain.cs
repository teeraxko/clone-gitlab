    using System;
using System.Windows.Forms;
using System.Diagnostics;

using Presentation.AttendanceGUI;
using Presentation.PiGUI;
using Presentation.ContractGUI;
using Presentation.VehicleGUI;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

using Presentation.ContractGUI.ContractChargeRateGUI;
using Presentation.ContractGUI.ContractVDOGUI;
using PresentationBase.CommonGUIBase;

using PTB.BTS.BTS2BizPacPresentation.ConnectBizPac;
using PTB.BTS.BTS2BizPacPresentation.CancelBizPac;

using Report.GUI.PI;

using PTB.PIS.Welfare.WindowsApp.MedicalAidGUI;
using PTB.PIS.Welfare.WindowsApp.ContributionGUI;
using PTB.PIS.Welfare.WindowsApp.LoanGUI;
using PTB.PIS.Welfare.ReportApp.GUI.MedicalAidGUI;
using PTB.PIS.Welfare.ReportApp.GUI.LoanGUI;
using PTB.PIS.Welfare.ReportApp.GUI.ContributionGUI;
using PTB.PIS.Welfare.WindowsApp.BizPacGUI;
using Report.GUI.Vehicle;
using Presentation.VehicleGUI.Leasing;
using Presentation.VehicleGUI.VehicleLeasingGUI;
using Report.GUI.Contract;
using Presentation.VehicleGUI.ProfitLostGUI;
using Presentation.VehicleGUI.ProfitCalculationGUI;
using Report.GUI.Attendance;
using Report.GUI.Welfare.MedicalAidGUI;
using Presentation.WelfareGUI;

namespace Presentation
{
    public class frmMain : Presentation.CommonGUI.FormBase
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
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.ToolBar toolBarMainMenu;
        private System.Windows.Forms.ImageList imgListMainMenu;
        private System.Windows.Forms.StatusBar stbMain;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem113;
        private System.Windows.Forms.ToolBarButton tlbNew;
        private System.Windows.Forms.ToolBarButton tlbPrint;
        private System.Windows.Forms.ToolBarButton tlbExit;
        private System.Windows.Forms.ToolBarButton tlbSep1;
        private System.Windows.Forms.ToolBarButton tlbDelete;
        private System.Windows.Forms.ToolBarButton tlbSep2;
        private System.Windows.Forms.ToolBarButton tlbRefresh;
        private System.Windows.Forms.ToolBarButton tlbSep3;
        private System.Windows.Forms.MainMenu mmMenu;
        private System.Windows.Forms.MenuItem miFile;
        private System.Windows.Forms.MenuItem miFileNew;
        private System.Windows.Forms.MenuItem miFileDelete;
        private System.Windows.Forms.MenuItem miFileRefresh;
        private System.Windows.Forms.MenuItem miFilePrint;
        private System.Windows.Forms.MenuItem miFileExit;
        private System.Windows.Forms.MenuItem miPI;
        private System.Windows.Forms.MenuItem miAttendance;
        private System.Windows.Forms.MenuItem miContract;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem miPIMap;
        private System.Windows.Forms.MenuItem miPIPosition;
        private System.Windows.Forms.MenuItem miPIEmployee;
        private System.Windows.Forms.MenuItem miVehicle;
        private System.Windows.Forms.MenuItem miVehicleSetting;
        private System.Windows.Forms.MenuItem miVehicleVehicle;
        private System.Windows.Forms.MenuItem miVehicleMaintenance;
        private System.Windows.Forms.MenuItem miVehicleDocument;
        private System.Windows.Forms.MenuItem miContractSetting;
        private System.Windows.Forms.MenuItem miContractCustomer;
        private System.Windows.Forms.MenuItem miContractAssignmentHistory;
        private System.Windows.Forms.MenuItem miAttendanceSetting;
        private System.Windows.Forms.MenuItem miAttendanceWorkingTime;
        private System.Windows.Forms.MenuItem miBatchProcess;
        private System.Windows.Forms.MenuItem miBatchProcessMonthly;
        private System.Windows.Forms.MenuItem miBatchProcessYearly;
        private System.Windows.Forms.MenuItem miPIMapCompany;
        private System.Windows.Forms.MenuItem miPIMapDepartment;
        private System.Windows.Forms.MenuItem miPIMapSection;
        private System.Windows.Forms.MenuItem miPIPositionPosition;
        private System.Windows.Forms.MenuItem miPIPositionTitle;
        private System.Windows.Forms.MenuItem miPIEmployeePI;
        private System.Windows.Forms.MenuItem miPIEmployeeFormerPI;
        private System.Windows.Forms.MenuItem miPIEmployeeMoveToFormerPI;
        private System.Windows.Forms.MenuItem miVehicleSettingAccidentPlace;
        private System.Windows.Forms.MenuItem miVehicleSettingPoliceStation;
        private System.Windows.Forms.MenuItem miVehicleVehicleVendor;
        private System.Windows.Forms.MenuItem miVehicleVehicleBrand;
        private System.Windows.Forms.MenuItem miVehicleVehicleModel;
        private System.Windows.Forms.MenuItem miVehicleVehicleColor;
        private System.Windows.Forms.MenuItem miVehicleVehicleVehicle;
        private System.Windows.Forms.MenuItem miVehicleMaintenanceGarage;
        private System.Windows.Forms.MenuItem miVehicleMaintenanceAccidentHistory;
        private System.Windows.Forms.MenuItem miVehicleMaintenanceHistory;
        private System.Windows.Forms.MenuItem miVehicleDocumentInsurance;
        private System.Windows.Forms.MenuItem miVehicleDocumentInsuranceTypeOne;
        private System.Windows.Forms.MenuItem miVehicleDocumentVehicleTax;
        private System.Windows.Forms.MenuItem miVehicleDocumentVehicleTaxPlateNo;
        private System.Windows.Forms.MenuItem miContractDocument;
        private System.Windows.Forms.MenuItem miContractSettingContractCancelReason;
        private System.Windows.Forms.MenuItem miContractCustomerData;
        private System.Windows.Forms.MenuItem miContractCustomerDepartment;
        private System.Windows.Forms.MenuItem miContractDocumentApprove;
        private System.Windows.Forms.MenuItem miContractDocumentCancel;
        private System.Windows.Forms.MenuItem miContractDocumentVDContractMatching;
        private System.Windows.Forms.MenuItem miContractAssignmentHistoryServiceStaffAssignment;
        private System.Windows.Forms.MenuItem miContractAssignmentHistoryVehicelAssignment;
        private System.Windows.Forms.MenuItem miVehicleMaintenanceSpareParts;
        private System.Windows.Forms.MenuItem miConfig;
        private System.Windows.Forms.MenuItem miConfigPI;
        private System.Windows.Forms.MenuItem miConfigKindOfStaff;
        private System.Windows.Forms.MenuItem miConfigMaritalStatus;
        private System.Windows.Forms.MenuItem miConfigMilitaryStatus;
        private System.Windows.Forms.MenuItem miConfigPositionGroup;
        private System.Windows.Forms.MenuItem miConfigPositionType;
        private System.Windows.Forms.MenuItem miConfigWorkingStatus;
        private System.Windows.Forms.MenuItem miConfigVehicle;
        private System.Windows.Forms.MenuItem miConfigGasolineType;
        private System.Windows.Forms.MenuItem miConfigKindOfVehicle;
        private System.Windows.Forms.MenuItem miConfigModelType;
        private System.Windows.Forms.MenuItem miConfigVehicleStatus;
        private System.Windows.Forms.MenuItem miConfigVehicleTax;
        private System.Windows.Forms.MenuItem miConfigVehicleVAT;
        private System.Windows.Forms.MenuItem miConfigContract;
        private System.Windows.Forms.MenuItem miConfigContractStatus;
        private System.Windows.Forms.MenuItem miConfigContractType;
        private System.Windows.Forms.MenuItem miConfigCustomerGroup;
        private System.Windows.Forms.MenuItem miConfigPaymentType;
        private System.Windows.Forms.MenuItem miConfigAttendance;
        private System.Windows.Forms.MenuItem mimiConfigPassword;
        private System.Windows.Forms.MenuItem miConfigChangePassword;
        private System.Windows.Forms.MenuItem miConfigAdmin;
        private System.Windows.Forms.MenuItem miConfigUser;
        private System.Windows.Forms.MenuItem miConfigPermission;
        private System.Windows.Forms.MenuItem miConfigSystemTable;
        private System.Windows.Forms.MenuItem miConfigKindOfContract;
        private System.Windows.Forms.MenuItem miContractSettingServiceStaffType;
        private System.Windows.Forms.MenuItem miContractDocumentServiceStaffMatchToContract;
        private System.Windows.Forms.MenuItem miConfigLogIn;
        private System.Windows.Forms.MenuItem miPIiMaster;
        private System.Windows.Forms.MenuItem miPIMasterPrefix;
        private System.Windows.Forms.MenuItem miPIMasterNationality;
        private System.Windows.Forms.MenuItem miPIMasterRace;
        private System.Windows.Forms.MenuItem miPIMasterReligion;
        private System.Windows.Forms.MenuItem miPIMasterOccupation;
        private System.Windows.Forms.MenuItem miPIMasterRelationship;
        private System.Windows.Forms.MenuItem miPIMasterBank;
        private System.Windows.Forms.MenuItem miPIMasterBloodGroup;
        private System.Windows.Forms.MenuItem miPIMasterPlaceProvince;
        private System.Windows.Forms.MenuItem miPIMasterEducation;
        private System.Windows.Forms.MenuItem miPIMasterEducationInstitute;
        private System.Windows.Forms.MenuItem miPIMasterPlaceDistrict;
        private System.Windows.Forms.MenuItem miPIMasterPlaceSubDistrict;
        private System.Windows.Forms.MenuItem miPIMasterPlaceStreet;
        private System.Windows.Forms.MenuItem miPIMasterEducationFaculty;
        private System.Windows.Forms.MenuItem miPIMasterEducationMajor;
        private System.Windows.Forms.MenuItem miPIMasterPlace;
        private System.Windows.Forms.MenuItem miPIMasterEducationLevel;
        private System.Windows.Forms.MenuItem miVehicleDocumentCompulsory;
        private System.Windows.Forms.MenuItem miVehicleDocumentCompulsoryPlate;
        private System.Windows.Forms.MenuItem miVehicleDocumentCompulsoryMonth;
        private System.Windows.Forms.MenuItem miVehicleDocumentVehicleTaxMonth;
        private System.Windows.Forms.MenuItem miVehicleDocumentMaintainInsuranceTypeOne;
        private System.Windows.Forms.MenuItem miVehicleDocumentCreateInsuranceTypeOne;
        private System.Windows.Forms.StatusBarPanel stp;
        private System.Windows.Forms.StatusBarPanel stpUser;
        private System.Windows.Forms.MenuItem miContractVehicle;
        private System.Windows.Forms.MenuItem miContractOtherServiceStaft;
        private System.Windows.Forms.MenuItem miContractDriver;
        private System.Windows.Forms.MenuItem miGenEmployeeWorkSchedule;
        private System.Windows.Forms.MenuItem miVehicleVehicleSpare;
        private System.Windows.Forms.MenuItem miDriverExcess;
        private System.Windows.Forms.MenuItem miContractDocumentLeasingHistoryOfActiveVehicle;
        private System.Windows.Forms.MenuItem miContractDocumentExpiredVehicleContract;
        private System.Windows.Forms.MenuItem miOTPattern;
        private System.Windows.Forms.MenuItem miOTPatternGeneralCondition;
        private System.Windows.Forms.MenuItem miOTPatternSpecificCondition;
        private System.Windows.Forms.MenuItem miEmployeeWorkSchedule;
        private System.Windows.Forms.MenuItem miHolidayConditionSpecific;
        private System.Windows.Forms.MenuItem miEmployeeTelephoneBenefit;
        private System.Windows.Forms.MenuItem miEmployeeMiscBenefit;
        private System.Windows.Forms.MenuItem miAttendanceEmployeeBenefit;
        private System.Windows.Forms.MenuItem miContractDocumentInComplete;
        private System.Windows.Forms.MenuItem miVehicleMaintenancebyGarage;
        private System.Windows.Forms.MenuItem miOvertimeVariant;
        private System.Windows.Forms.MenuItem miVehicleVehicleRepairedVehicle;
        private System.Windows.Forms.MenuItem miOtherBenefitRate;
        private System.Windows.Forms.MenuItem miTelephoneCondition;
        private System.Windows.Forms.MenuItem miEmployeeExtraBenefit;
        private System.Windows.Forms.MenuItem miEmployeeExtraAGTBenefit;
        private System.Windows.Forms.MenuItem miEmployeeFoodBenefit;
        private System.Windows.Forms.MenuItem miTaxiCondition;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem miBenefitAdjustment;
        private System.Windows.Forms.MenuItem miVehicleVehicleRepairedVehiclByFinishDate;
        private System.Windows.Forms.MenuItem miGenerateOtherBenefit;
        private System.Windows.Forms.MenuItem miWorkingTimeConditionSpecific;
        private System.Windows.Forms.MenuItem miEmployeePrivateLeave;
        private System.Windows.Forms.MenuItem miEmployeeSickLeave;
        private System.Windows.Forms.MenuItem miEmployeeSpecialLeave;
        private System.Windows.Forms.MenuItem miDisease;
        private System.Windows.Forms.MenuItem miLeaveReason;
        private System.Windows.Forms.MenuItem miSpecialLeave;
        private System.Windows.Forms.MenuItem miAttEmpAnnualLeave;
        private System.Windows.Forms.MenuItem miGenAnnualLeaveDay;
        private System.Windows.Forms.MenuItem miAttendanceBenefit;
        private System.Windows.Forms.MenuItem miAttendanceLeave;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem miContractDocumentLongTermContract;
        private System.Windows.Forms.MenuItem miLeaveReport;
        private System.Windows.Forms.MenuItem miTraditionalHoliday;
        private System.Windows.Forms.MenuItem miHolidayCondition;
        private System.Windows.Forms.MenuItem miWorkingTimeTable;
        private System.Windows.Forms.MenuItem miWorkingTimeCondition;
        private System.Windows.Forms.MenuItem miTraditionalHolidayPattern;
        private System.Windows.Forms.MenuItem miPayrollBenefit;
        private System.Windows.Forms.MenuItem miBatchProcessDaily;
        private System.Windows.Forms.MenuItem miTimeRecordOfDriver;
        private System.Windows.Forms.MenuItem miTimeCardForCharge;
        private System.Windows.Forms.MenuItem miTimeCardForPayment;
        private System.Windows.Forms.MenuItem miNonPayrollBenefit;
        private System.Windows.Forms.MenuItem miAttendanceSaleAnnualLeave;
        private System.Windows.Forms.MenuItem miVehicleVehicleRepairingHistoryByModel;
        private System.Windows.Forms.MenuItem miVehicleVehicleRepairingHistoryByCustomer;
        private System.Windows.Forms.MenuItem miVehicleVehicleRepairingHistoryBySpareParts;
        private System.Windows.Forms.MenuItem miContractVehicleCharge;
        private System.Windows.Forms.MenuItem miContractVehicleMatchWithDriverCheckList;
        private System.Windows.Forms.MenuItem miContractDriverMatchWithVehicleCheckList;
        private System.Windows.Forms.MenuItem miVehicleAccident;
        private System.Windows.Forms.MenuItem miVehicleVehicleRepairingHistoryByPlateNo;
        private System.Windows.Forms.MenuItem miContractDocumentSpareDriver;
        private System.Windows.Forms.MenuItem miContractDocumentServiceStaffContract;
        private System.Windows.Forms.MenuItem miContractNoAccidentReward;
        private System.Windows.Forms.StatusBarPanel stpFormID;
        private System.Windows.Forms.StatusBarPanel stpCount;
        private System.Windows.Forms.MenuItem miDriverExcessDeductionByMonth;
        private System.Windows.Forms.MenuItem miPIEmployeePrint;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem miPIEmployeeReport;
        private System.Windows.Forms.MenuItem miVehicleMaintenanceTotalAmountMaintenance;
        private System.Windows.Forms.MenuItem miVehicleMaintenanceRepairingHistorybyVehicle;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem miContractAssignmentHistorybyDriver;
        private System.Windows.Forms.MenuItem miPINonEmployeeReport;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem miVehicleDocumentCompulsoryInsurancenbyPlate;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem miVehicleAccidentByEmpNo;
        private System.Windows.Forms.MenuItem miVehicleAccidentByPlateNo;
        private System.Windows.Forms.MenuItem miAttendanceLeavePrivateLeaveReport;
        private System.Windows.Forms.MenuItem miContractVehicleAssignmentbyPlate;
        private System.Windows.Forms.MenuItem miAttendanceLeaveAnnualLeaveReport;
        private System.Windows.Forms.MenuItem miAttendanceLeaveSickLeaveReport;
        private System.Windows.Forms.MenuItem miContractVehicleMatchWithDriver;
        private System.Windows.Forms.MenuItem miContractContractMatchWithDriver;
        private System.Windows.Forms.MenuItem miPIEmployeePictureReport;
        private System.Windows.Forms.MenuItem miPIRetireStaff;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem miConfigApplicationFunctionPermission;
        private System.Windows.Forms.MenuItem miContractAssignmentHistoryVehicleSpareAssignment;
        private System.Windows.Forms.MenuItem miAbsentRewardFamilyCarDriver;
        private System.Windows.Forms.MenuItem miPIPersonalData;
        private System.Windows.Forms.MenuItem miEmployeeMiscDeducttion;
        private System.Windows.Forms.MenuItem miContractDocumentExpiredVehicle;
        private System.Windows.Forms.MenuItem miContractDocumentExpiredDriver;
        private System.Windows.Forms.StatusBarPanel stpUserDomain;
        private MenuItem miSAPConnect;
        private MenuItem miBizPacConnectVehicleRepairing;
        private MenuItem miVehicleMaintenanceExcessInsurance;
        private MenuItem miVehicleAccidentExcessInsurance;
        private MenuItem miBizPacConnectVehicleExcess;
        private MenuItem miBPConnectCompulsoryInsurance;
        private MenuItem miBizPacConnectInsuranceTypeOne;
        private MenuItem miBizPacConnectVehicleContractCharge;
        private MenuItem miBizPacConnectDriverContractCharge;
        private MenuItem miBizPacConnectServiceStaffContractCharge;
        private MenuItem miContractSettingMinimumOTCharge;
        private MenuItem miContractSettingServiceStaffCharge;
        private MenuItem miContractSettingServiceStaffChargeContract;
        private MenuItem miWelfare;
        private MenuItem miWelfareSetting;
        private MenuItem miWelfareSettingHospital;
        private MenuItem miWelfareSettingContribution;
        private MenuItem miWelfareSettingLoanReasonList;
        private MenuItem miWelfareMedicalAid;
        private MenuItem miWelfareMedicalAidListByEmp;
        private MenuItem miWelfareMedicalAidListByHospital;
        private MenuItem miWelfareContribution;
        private MenuItem miWelfareContributionEmpList;
        private MenuItem miWelfareLoan;
        private MenuItem miWelfareLoanAppList;
        private MenuItem menuItem19;
        private MenuItem miWelfareMedicalAidReport;
        private MenuItem miWelfareMedicalAidAttReport;
        private MenuItem miWelfareMedicalAidNoAttReport;
        private MenuItem menuItem23;
        private MenuItem miWelfareContributionReport;
        private MenuItem menuItem17;
        private MenuItem miWelfareLoanReport;
        private MenuItem miWelfareLoanByEmpReport;
        private MenuItem miWelfareLoanOffsetReport;
        private MenuItem miBizPacConnectLoan;
        private MenuItem miBizPacConnectMedicalAid;
        private MenuItem miBizPacConnectContribution;
        private MenuItem miBizPacConnectMedicalAidNoAtt;
        private MenuItem miContractSettingCustomerChargeAdjustDriver;
        private MenuItem miSAPVehicleDocument;
        private MenuItem miBPPreConnectCompulsory;
        private MenuItem miBPPreConnectInsurance;
        private MenuItem miBPWelfare;
        private MenuItem miBPContract;
        private MenuItem miBPMaintenance;
        private MenuItem menuItem21;
        private MenuItem miBizPacCancelLoan;
        private MenuItem miBizPacCancelContribution;
        private MenuItem miBizPacCancelMedicalAid;
        private MenuItem miBizPacConnectVehicleCancelCharge;
        private MenuItem menuItem25;
        private MenuItem miBizPacCancelVehicleRepairing;
        private MenuItem miBizPacCancelVehicleExcess;
        private MenuItem menuItem30;
        private MenuItem miBizPacCancelCompulsoryInsurance;
        private MenuItem miBizPacCancelInsuranceTypeOne;
        private MenuItem menuItem27;
        private MenuItem miBizPacCancelDriverContractCharge;
        private MenuItem miBizPacCancelServiceStaffContractCharge;
        private MenuItem miBPPreConnectVehicleRepairing;
        private MenuItem miBPPreConnectVehicleExcess;
        private MenuItem miBPPreConnectVehicleCharge;
        private MenuItem miBPPreConnectDriverCharge;
        private MenuItem miContractSettingCustomerChargeAdjustOtherSS;
        private MenuItem miContractDocumentSpecialCharge;
        private MenuItem miVehicleNoVehicleAssign;
        private MenuItem miBPRerunVehicleCharge;
        private MenuItem miBPRerunDriverCharge;
        private MenuItem miBPRerunOtherSSCharge;
        private MenuItem menuItem18;
        private MenuItem miPIExpiredDrivingLicense;
        private MenuItem miPIProbationEmployee;
        private MenuItem miPISalaryEmployee;
        private MenuItem miPIHireDate;
        private MenuItem miContractDocumentCustomerSpecialCharge;
        private MenuItem miContractDocumentChargeDiff;
        private MenuItem miVehicleAvgMaintenance;
        private MenuItem miPIEmployeeSearch;
        private MenuItem miVehicleAvgMaintenanceCust;
        private MenuItem miVehicleBidder;
        private MenuItem miContractDocumentPenaltyCharge;
        private MenuItem miContractSettingCompensate;
        private MenuItem miAttendanceLeaveEmployeeLeaveReport;
        private MenuItem miVehicleMainVehicle;
        private MenuItem miPIExpiredIDCard;
        private MenuItem miEmployeeOverNightTripBenefit;
        private MenuItem miPIEmployeeRegist;
        private MenuItem miSpecialAllowance;
        private MenuItem miEmployeeReceiveGold;
        private MenuItem miSSHospital;
        private MenuItem miVehicleRepairingNoneTaxInvoice;
        private MenuItem miWelfareMedicalAidListInsurancePaid;
        private MenuItem miVehicleLeasingCalculation;
        private MenuItem miQuotation;
        private MenuItem miPO;
        private MenuItem miVehicleLeasingCar;
        private MenuItem miContractDocumentCarAgreement;
        //D21018-BTS Modification
        private MenuItem miContractDocumentCompanyAgreement;
        private MenuItem miSellingPlan;
        private MenuItem miVehicleVehicleSetting;
        private MenuItem miVehicleSellingPlanSellingPlan;
        private MenuItem miVehicleSellingPlanVehicleSelling;
        private MenuItem miComparisonMaintenance;
        private MenuItem miContractDocumentRenewalNotice;
        private MenuItem miContractDocumentDriverAgreement;
        private MenuItem menuItem22;
        private MenuItem menuItem20;
        private MenuItem miPIEmployeeProvidentFundResign;
        private MenuItem miPIImportEmployeeSalary;
        private MenuItem miPIPersonnalDataWelfare;
        private MenuItem miAttendanceLeaveSpecialLeaveReport;
        private MenuItem miPIEmployeeProvidentFund;
        private MenuItem miGenerateMealBenefit;
        private MenuItem menuItem24;
        private MenuItem miWelfareBenefit;
        private MenuItem miBizPacConnectContributionN;
        private MenuItem miBPPreConnectOfficeCharge;
        private MenuItem miPIExportEmployeeData;
        private MenuItem menuItem26;
        private MenuItem miContractListExpectedIncomeReport;
        private System.ComponentModel.IContainer components;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mmMenu = new System.Windows.Forms.MainMenu(this.components);
            this.miFile = new System.Windows.Forms.MenuItem();
            this.miFileNew = new System.Windows.Forms.MenuItem();
            this.miFileDelete = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.miFileRefresh = new System.Windows.Forms.MenuItem();
            this.miFilePrint = new System.Windows.Forms.MenuItem();
            this.menuItem113 = new System.Windows.Forms.MenuItem();
            this.miFileExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miPI = new System.Windows.Forms.MenuItem();
            this.miPIiMaster = new System.Windows.Forms.MenuItem();
            this.miPIMasterPrefix = new System.Windows.Forms.MenuItem();
            this.miPIMasterRace = new System.Windows.Forms.MenuItem();
            this.miPIMasterNationality = new System.Windows.Forms.MenuItem();
            this.miPIMasterReligion = new System.Windows.Forms.MenuItem();
            this.miPIMasterOccupation = new System.Windows.Forms.MenuItem();
            this.miPIMasterRelationship = new System.Windows.Forms.MenuItem();
            this.miPIMasterBank = new System.Windows.Forms.MenuItem();
            this.miPIMasterBloodGroup = new System.Windows.Forms.MenuItem();
            this.miSpecialAllowance = new System.Windows.Forms.MenuItem();
            this.miPIMasterPlace = new System.Windows.Forms.MenuItem();
            this.miPIMasterPlaceProvince = new System.Windows.Forms.MenuItem();
            this.miPIMasterPlaceDistrict = new System.Windows.Forms.MenuItem();
            this.miPIMasterPlaceSubDistrict = new System.Windows.Forms.MenuItem();
            this.miPIMasterPlaceStreet = new System.Windows.Forms.MenuItem();
            this.miPIMasterEducation = new System.Windows.Forms.MenuItem();
            this.miPIMasterEducationInstitute = new System.Windows.Forms.MenuItem();
            this.miPIMasterEducationLevel = new System.Windows.Forms.MenuItem();
            this.miPIMasterEducationFaculty = new System.Windows.Forms.MenuItem();
            this.miPIMasterEducationMajor = new System.Windows.Forms.MenuItem();
            this.miPIMap = new System.Windows.Forms.MenuItem();
            this.miPIMapCompany = new System.Windows.Forms.MenuItem();
            this.miPIMapDepartment = new System.Windows.Forms.MenuItem();
            this.miPIMapSection = new System.Windows.Forms.MenuItem();
            this.miPIPosition = new System.Windows.Forms.MenuItem();
            this.miPIPositionPosition = new System.Windows.Forms.MenuItem();
            this.miPIPositionTitle = new System.Windows.Forms.MenuItem();
            this.miPIEmployee = new System.Windows.Forms.MenuItem();
            this.miPIEmployeePI = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeFormerPI = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeMoveToFormerPI = new System.Windows.Forms.MenuItem();
            this.miPIImportEmployeeSalary = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeReport = new System.Windows.Forms.MenuItem();
            this.miPIEmployeePictureReport = new System.Windows.Forms.MenuItem();
            this.miPIEmployeePrint = new System.Windows.Forms.MenuItem();
            this.miPINonEmployeeReport = new System.Windows.Forms.MenuItem();
            this.miPIRetireStaff = new System.Windows.Forms.MenuItem();
            this.miPIPersonalData = new System.Windows.Forms.MenuItem();
            this.miPIExpiredDrivingLicense = new System.Windows.Forms.MenuItem();
            this.miPIProbationEmployee = new System.Windows.Forms.MenuItem();
            this.miPISalaryEmployee = new System.Windows.Forms.MenuItem();
            this.miPIHireDate = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeSearch = new System.Windows.Forms.MenuItem();
            this.miPIExpiredIDCard = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeRegist = new System.Windows.Forms.MenuItem();
            this.miPIPersonnalDataWelfare = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeProvidentFund = new System.Windows.Forms.MenuItem();
            this.miPIEmployeeProvidentFundResign = new System.Windows.Forms.MenuItem();
            this.miPIExportEmployeeData = new System.Windows.Forms.MenuItem();
            this.miWelfare = new System.Windows.Forms.MenuItem();
            this.miWelfareSetting = new System.Windows.Forms.MenuItem();
            this.miWelfareSettingContribution = new System.Windows.Forms.MenuItem();
            this.miWelfareSettingLoanReasonList = new System.Windows.Forms.MenuItem();
            this.miWelfareSettingHospital = new System.Windows.Forms.MenuItem();
            this.miSSHospital = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAid = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAidListByEmp = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAidListByHospital = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAidReport = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAidAttReport = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAidNoAttReport = new System.Windows.Forms.MenuItem();
            this.miWelfareMedicalAidListInsurancePaid = new System.Windows.Forms.MenuItem();
            this.miWelfareContribution = new System.Windows.Forms.MenuItem();
            this.miWelfareContributionEmpList = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.miWelfareContributionReport = new System.Windows.Forms.MenuItem();
            this.miWelfareLoan = new System.Windows.Forms.MenuItem();
            this.miWelfareLoanAppList = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.miWelfareLoanReport = new System.Windows.Forms.MenuItem();
            this.miWelfareLoanByEmpReport = new System.Windows.Forms.MenuItem();
            this.miWelfareLoanOffsetReport = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.miWelfareBenefit = new System.Windows.Forms.MenuItem();
            this.miVehicle = new System.Windows.Forms.MenuItem();
            this.miVehicleSetting = new System.Windows.Forms.MenuItem();
            this.miVehicleSettingPoliceStation = new System.Windows.Forms.MenuItem();
            this.miVehicleSettingAccidentPlace = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicle = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleSetting = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleColor = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleModel = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleBrand = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleVendor = new System.Windows.Forms.MenuItem();
            this.miVehicleBidder = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.miVehicleLeasingCalculation = new System.Windows.Forms.MenuItem();
            this.miQuotation = new System.Windows.Forms.MenuItem();
            this.miPO = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleVehicle = new System.Windows.Forms.MenuItem();
            this.miSellingPlan = new System.Windows.Forms.MenuItem();
            this.miVehicleSellingPlanSellingPlan = new System.Windows.Forms.MenuItem();
            this.miVehicleSellingPlanVehicleSelling = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleSpare = new System.Windows.Forms.MenuItem();
            this.miVehicleNoVehicleAssign = new System.Windows.Forms.MenuItem();
            this.miVehicleMainVehicle = new System.Windows.Forms.MenuItem();
            this.miVehicleLeasingCar = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenance = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceSpareParts = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceGarage = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceHistory = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceAccidentHistory = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.miVehicleAccident = new System.Windows.Forms.MenuItem();
            this.miVehicleAccidentByPlateNo = new System.Windows.Forms.MenuItem();
            this.miVehicleAccidentByEmpNo = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenancebyGarage = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceTotalAmountMaintenance = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleRepairedVehiclByFinishDate = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleRepairedVehicle = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceRepairingHistorybyVehicle = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleRepairingHistoryByModel = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleRepairingHistoryByCustomer = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleRepairingHistoryBySpareParts = new System.Windows.Forms.MenuItem();
            this.miVehicleVehicleRepairingHistoryByPlateNo = new System.Windows.Forms.MenuItem();
            this.miVehicleAccidentExcessInsurance = new System.Windows.Forms.MenuItem();
            this.miVehicleAvgMaintenance = new System.Windows.Forms.MenuItem();
            this.miVehicleAvgMaintenanceCust = new System.Windows.Forms.MenuItem();
            this.miVehicleRepairingNoneTaxInvoice = new System.Windows.Forms.MenuItem();
            this.miComparisonMaintenance = new System.Windows.Forms.MenuItem();
            this.miVehicleDocument = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentInsurance = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentInsuranceTypeOne = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentMaintainInsuranceTypeOne = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentCreateInsuranceTypeOne = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentCompulsory = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentCompulsoryPlate = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentCompulsoryMonth = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentCompulsoryInsurancenbyPlate = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentVehicleTax = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentVehicleTaxPlateNo = new System.Windows.Forms.MenuItem();
            this.miVehicleDocumentVehicleTaxMonth = new System.Windows.Forms.MenuItem();
            this.miVehicleMaintenanceExcessInsurance = new System.Windows.Forms.MenuItem();
            this.miContract = new System.Windows.Forms.MenuItem();
            this.miContractSetting = new System.Windows.Forms.MenuItem();
            this.miContractSettingContractCancelReason = new System.Windows.Forms.MenuItem();
            this.miContractSettingServiceStaffType = new System.Windows.Forms.MenuItem();
            this.miContractSettingServiceStaffChargeContract = new System.Windows.Forms.MenuItem();
            this.miContractSettingServiceStaffCharge = new System.Windows.Forms.MenuItem();
            this.miContractSettingMinimumOTCharge = new System.Windows.Forms.MenuItem();
            this.miContractSettingCompensate = new System.Windows.Forms.MenuItem();
            this.miContractCustomer = new System.Windows.Forms.MenuItem();
            this.miContractCustomerData = new System.Windows.Forms.MenuItem();
            this.miContractCustomerDepartment = new System.Windows.Forms.MenuItem();
            this.miContractDocument = new System.Windows.Forms.MenuItem();
            this.miContractVehicle = new System.Windows.Forms.MenuItem();
            this.miContractDriver = new System.Windows.Forms.MenuItem();
            this.miContractOtherServiceStaft = new System.Windows.Forms.MenuItem();
            this.miContractDocumentApprove = new System.Windows.Forms.MenuItem();
            this.miContractDocumentCancel = new System.Windows.Forms.MenuItem();
            this.miContractDocumentServiceStaffMatchToContract = new System.Windows.Forms.MenuItem();
            this.miContractDocumentVDContractMatching = new System.Windows.Forms.MenuItem();
            this.miContractSettingCustomerChargeAdjustOtherSS = new System.Windows.Forms.MenuItem();
            this.miContractSettingCustomerChargeAdjustDriver = new System.Windows.Forms.MenuItem();
            this.miContractDocumentSpecialCharge = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.miContractDocumentLeasingHistoryOfActiveVehicle = new System.Windows.Forms.MenuItem();
            this.miContractDocumentExpiredVehicleContract = new System.Windows.Forms.MenuItem();
            this.miContractDocumentInComplete = new System.Windows.Forms.MenuItem();
            this.miContractDocumentLongTermContract = new System.Windows.Forms.MenuItem();
            this.miContractDocumentSpareDriver = new System.Windows.Forms.MenuItem();
            this.miContractDocumentServiceStaffContract = new System.Windows.Forms.MenuItem();
            this.miContractDocumentExpiredVehicle = new System.Windows.Forms.MenuItem();
            this.miContractDocumentExpiredDriver = new System.Windows.Forms.MenuItem();
            this.miContractDocumentCustomerSpecialCharge = new System.Windows.Forms.MenuItem();
            this.miContractDocumentChargeDiff = new System.Windows.Forms.MenuItem();
            this.miContractDocumentPenaltyCharge = new System.Windows.Forms.MenuItem();
            this.miContractListExpectedIncomeReport = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.miContractDocumentRenewalNotice = new System.Windows.Forms.MenuItem();
            this.miContractDocumentDriverAgreement = new System.Windows.Forms.MenuItem();
            this.miContractDocumentCarAgreement = new System.Windows.Forms.MenuItem();
            this.miContractDocumentCompanyAgreement = new System.Windows.Forms.MenuItem();
            this.miContractAssignmentHistory = new System.Windows.Forms.MenuItem();
            this.miContractAssignmentHistoryVehicelAssignment = new System.Windows.Forms.MenuItem();
            this.miContractAssignmentHistoryServiceStaffAssignment = new System.Windows.Forms.MenuItem();
            this.miContractAssignmentHistoryVehicleSpareAssignment = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.miContractVehicleAssignmentbyPlate = new System.Windows.Forms.MenuItem();
            this.miContractDriverMatchWithVehicleCheckList = new System.Windows.Forms.MenuItem();
            this.miContractAssignmentHistorybyDriver = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.miContractVehicleCharge = new System.Windows.Forms.MenuItem();
            this.miContractVehicleMatchWithDriverCheckList = new System.Windows.Forms.MenuItem();
            this.miContractVehicleMatchWithDriver = new System.Windows.Forms.MenuItem();
            this.miContractContractMatchWithDriver = new System.Windows.Forms.MenuItem();
            this.miContractNoAccidentReward = new System.Windows.Forms.MenuItem();
            this.miAttendance = new System.Windows.Forms.MenuItem();
            this.miAttendanceSetting = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miTraditionalHoliday = new System.Windows.Forms.MenuItem();
            this.miHolidayCondition = new System.Windows.Forms.MenuItem();
            this.miHolidayConditionSpecific = new System.Windows.Forms.MenuItem();
            this.miDisease = new System.Windows.Forms.MenuItem();
            this.miSpecialLeave = new System.Windows.Forms.MenuItem();
            this.miLeaveReason = new System.Windows.Forms.MenuItem();
            this.miGenAnnualLeaveDay = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.miWorkingTimeTable = new System.Windows.Forms.MenuItem();
            this.miWorkingTimeCondition = new System.Windows.Forms.MenuItem();
            this.miWorkingTimeConditionSpecific = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miOtherBenefitRate = new System.Windows.Forms.MenuItem();
            this.miOTPattern = new System.Windows.Forms.MenuItem();
            this.miOvertimeVariant = new System.Windows.Forms.MenuItem();
            this.miOTPatternGeneralCondition = new System.Windows.Forms.MenuItem();
            this.miOTPatternSpecificCondition = new System.Windows.Forms.MenuItem();
            this.miTelephoneCondition = new System.Windows.Forms.MenuItem();
            this.miTaxiCondition = new System.Windows.Forms.MenuItem();
            this.miAttendanceLeave = new System.Windows.Forms.MenuItem();
            this.miEmployeeSickLeave = new System.Windows.Forms.MenuItem();
            this.miEmployeePrivateLeave = new System.Windows.Forms.MenuItem();
            this.miEmployeeSpecialLeave = new System.Windows.Forms.MenuItem();
            this.miAttEmpAnnualLeave = new System.Windows.Forms.MenuItem();
            this.miAttendanceSaleAnnualLeave = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.miLeaveReport = new System.Windows.Forms.MenuItem();
            this.miAttendanceLeaveSickLeaveReport = new System.Windows.Forms.MenuItem();
            this.miAttendanceLeavePrivateLeaveReport = new System.Windows.Forms.MenuItem();
            this.miAttendanceLeaveSpecialLeaveReport = new System.Windows.Forms.MenuItem();
            this.miAttendanceLeaveAnnualLeaveReport = new System.Windows.Forms.MenuItem();
            this.miAttendanceLeaveEmployeeLeaveReport = new System.Windows.Forms.MenuItem();
            this.miAttendanceWorkingTime = new System.Windows.Forms.MenuItem();
            this.miGenEmployeeWorkSchedule = new System.Windows.Forms.MenuItem();
            this.miEmployeeWorkSchedule = new System.Windows.Forms.MenuItem();
            this.miAttendanceBenefit = new System.Windows.Forms.MenuItem();
            this.miEmployeeTelephoneBenefit = new System.Windows.Forms.MenuItem();
            this.miEmployeeFoodBenefit = new System.Windows.Forms.MenuItem();
            this.miEmployeeExtraBenefit = new System.Windows.Forms.MenuItem();
            this.miEmployeeMiscBenefit = new System.Windows.Forms.MenuItem();
            this.miEmployeeMiscDeducttion = new System.Windows.Forms.MenuItem();
            this.miAttendanceEmployeeBenefit = new System.Windows.Forms.MenuItem();
            this.miBenefitAdjustment = new System.Windows.Forms.MenuItem();
            this.miGenerateOtherBenefit = new System.Windows.Forms.MenuItem();
            this.miGenerateMealBenefit = new System.Windows.Forms.MenuItem();
            this.miEmployeeExtraAGTBenefit = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.miTimeRecordOfDriver = new System.Windows.Forms.MenuItem();
            this.miTimeCardForCharge = new System.Windows.Forms.MenuItem();
            this.miTimeCardForPayment = new System.Windows.Forms.MenuItem();
            this.miEmployeeOverNightTripBenefit = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.miDriverExcess = new System.Windows.Forms.MenuItem();
            this.miDriverExcessDeductionByMonth = new System.Windows.Forms.MenuItem();
            this.miPayrollBenefit = new System.Windows.Forms.MenuItem();
            this.miNonPayrollBenefit = new System.Windows.Forms.MenuItem();
            this.miAbsentRewardFamilyCarDriver = new System.Windows.Forms.MenuItem();
            this.miEmployeeReceiveGold = new System.Windows.Forms.MenuItem();
            this.miSAPConnect = new System.Windows.Forms.MenuItem();
            this.miBPWelfare = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectLoan = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectContribution = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectContributionN = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectMedicalAid = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectMedicalAidNoAtt = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelLoan = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelContribution = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelMedicalAid = new System.Windows.Forms.MenuItem();
            this.miSAPVehicleDocument = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectCompulsory = new System.Windows.Forms.MenuItem();
            this.miBPConnectCompulsoryInsurance = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectInsurance = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectInsuranceTypeOne = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelCompulsoryInsurance = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelInsuranceTypeOne = new System.Windows.Forms.MenuItem();
            this.miBPMaintenance = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectVehicleRepairing = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectVehicleRepairing = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectVehicleExcess = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectVehicleExcess = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelVehicleRepairing = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelVehicleExcess = new System.Windows.Forms.MenuItem();
            this.miBPContract = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectVehicleCharge = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectVehicleContractCharge = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectDriverCharge = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectDriverContractCharge = new System.Windows.Forms.MenuItem();
            this.miBPPreConnectOfficeCharge = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectServiceStaffContractCharge = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.miBizPacConnectVehicleCancelCharge = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelDriverContractCharge = new System.Windows.Forms.MenuItem();
            this.miBizPacCancelServiceStaffContractCharge = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.miBPRerunVehicleCharge = new System.Windows.Forms.MenuItem();
            this.miBPRerunDriverCharge = new System.Windows.Forms.MenuItem();
            this.miBPRerunOtherSSCharge = new System.Windows.Forms.MenuItem();
            this.miBatchProcess = new System.Windows.Forms.MenuItem();
            this.miBatchProcessDaily = new System.Windows.Forms.MenuItem();
            this.miBatchProcessMonthly = new System.Windows.Forms.MenuItem();
            this.miBatchProcessYearly = new System.Windows.Forms.MenuItem();
            this.miConfig = new System.Windows.Forms.MenuItem();
            this.mimiConfigPassword = new System.Windows.Forms.MenuItem();
            this.miConfigChangePassword = new System.Windows.Forms.MenuItem();
            this.miConfigLogIn = new System.Windows.Forms.MenuItem();
            this.miConfigAdmin = new System.Windows.Forms.MenuItem();
            this.miConfigUser = new System.Windows.Forms.MenuItem();
            this.miConfigPermission = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.miConfigApplicationFunctionPermission = new System.Windows.Forms.MenuItem();
            this.miConfigSystemTable = new System.Windows.Forms.MenuItem();
            this.miConfigPI = new System.Windows.Forms.MenuItem();
            this.miConfigKindOfStaff = new System.Windows.Forms.MenuItem();
            this.miConfigMaritalStatus = new System.Windows.Forms.MenuItem();
            this.miConfigMilitaryStatus = new System.Windows.Forms.MenuItem();
            this.miConfigPositionGroup = new System.Windows.Forms.MenuItem();
            this.miConfigPositionType = new System.Windows.Forms.MenuItem();
            this.miConfigWorkingStatus = new System.Windows.Forms.MenuItem();
            this.miConfigVehicle = new System.Windows.Forms.MenuItem();
            this.miConfigGasolineType = new System.Windows.Forms.MenuItem();
            this.miConfigKindOfVehicle = new System.Windows.Forms.MenuItem();
            this.miConfigModelType = new System.Windows.Forms.MenuItem();
            this.miConfigVehicleStatus = new System.Windows.Forms.MenuItem();
            this.miConfigVehicleTax = new System.Windows.Forms.MenuItem();
            this.miConfigVehicleVAT = new System.Windows.Forms.MenuItem();
            this.miConfigContract = new System.Windows.Forms.MenuItem();
            this.miConfigContractStatus = new System.Windows.Forms.MenuItem();
            this.miConfigContractType = new System.Windows.Forms.MenuItem();
            this.miConfigCustomerGroup = new System.Windows.Forms.MenuItem();
            this.miConfigKindOfContract = new System.Windows.Forms.MenuItem();
            this.miConfigPaymentType = new System.Windows.Forms.MenuItem();
            this.miConfigAttendance = new System.Windows.Forms.MenuItem();
            this.miTraditionalHolidayPattern = new System.Windows.Forms.MenuItem();
            this.imgListMainMenu = new System.Windows.Forms.ImageList(this.components);
            this.stbMain = new System.Windows.Forms.StatusBar();
            this.stpFormID = new System.Windows.Forms.StatusBarPanel();
            this.stp = new System.Windows.Forms.StatusBarPanel();
            this.stpCount = new System.Windows.Forms.StatusBarPanel();
            this.stpUser = new System.Windows.Forms.StatusBarPanel();
            this.stpUserDomain = new System.Windows.Forms.StatusBarPanel();
            this.toolBarMainMenu = new System.Windows.Forms.ToolBar();
            this.tlbSep1 = new System.Windows.Forms.ToolBarButton();
            this.tlbNew = new System.Windows.Forms.ToolBarButton();
            this.tlbDelete = new System.Windows.Forms.ToolBarButton();
            this.tlbSep2 = new System.Windows.Forms.ToolBarButton();
            this.tlbRefresh = new System.Windows.Forms.ToolBarButton();
            this.tlbPrint = new System.Windows.Forms.ToolBarButton();
            this.tlbSep3 = new System.Windows.Forms.ToolBarButton();
            this.tlbExit = new System.Windows.Forms.ToolBarButton();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stpFormID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stpCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stpUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stpUserDomain)).BeginInit();
            this.SuspendLayout();
            // 
            // mmMenu
            // 
            this.mmMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFile,
            this.miPI,
            this.miWelfare,
            this.miVehicle,
            this.miContract,
            this.miAttendance,
            this.miSAPConnect,
            this.miBatchProcess,
            this.miConfig});
            // 
            // miFile
            // 
            this.miFile.Index = 0;
            this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileNew,
            this.miFileDelete,
            this.menuItem5,
            this.miFileRefresh,
            this.miFilePrint,
            this.menuItem113,
            this.miFileExit,
            this.menuItem3});
            this.miFile.Text = "แฟ้ม";
            // 
            // miFileNew
            // 
            this.miFileNew.Index = 0;
            this.miFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.miFileNew.Text = "สร้าง";
            this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
            // 
            // miFileDelete
            // 
            this.miFileDelete.Index = 1;
            this.miFileDelete.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.miFileDelete.Text = "ลบ";
            this.miFileDelete.Click += new System.EventHandler(this.miFileDelete_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // miFileRefresh
            // 
            this.miFileRefresh.Index = 3;
            this.miFileRefresh.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.miFileRefresh.Text = "ดึงข้อมูลใหม่";
            this.miFileRefresh.Click += new System.EventHandler(this.miFileRefresh_Click);
            // 
            // miFilePrint
            // 
            this.miFilePrint.Index = 4;
            this.miFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.miFilePrint.Text = "พิมพ์";
            this.miFilePrint.Click += new System.EventHandler(this.miFilePrint_Click);
            // 
            // menuItem113
            // 
            this.menuItem113.Index = 5;
            this.menuItem113.Text = "-";
            // 
            // miFileExit
            // 
            this.miFileExit.Index = 6;
            this.miFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.miFileExit.Text = "ออก";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 7;
            this.menuItem3.Text = "-";
            // 
            // miPI
            // 
            this.miPI.Index = 1;
            this.miPI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIiMaster,
            this.miPIMap,
            this.miPIPosition,
            this.miPIEmployee});
            this.miPI.Text = "ข้อมูลพนักงาน";
            // 
            // miPIiMaster
            // 
            this.miPIiMaster.Index = 0;
            this.miPIiMaster.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIMasterPrefix,
            this.miPIMasterRace,
            this.miPIMasterNationality,
            this.miPIMasterReligion,
            this.miPIMasterOccupation,
            this.miPIMasterRelationship,
            this.miPIMasterBank,
            this.miPIMasterBloodGroup,
            this.miSpecialAllowance,
            this.miPIMasterPlace,
            this.miPIMasterEducation});
            this.miPIiMaster.Text = "ตั้งค่าทั่วไป";
            // 
            // miPIMasterPrefix
            // 
            this.miPIMasterPrefix.Index = 0;
            this.miPIMasterPrefix.Text = "คำนำหน้าชื่อ";
            this.miPIMasterPrefix.Visible = false;
            this.miPIMasterPrefix.Click += new System.EventHandler(this.miPIMasterPrefix_Click);
            // 
            // miPIMasterRace
            // 
            this.miPIMasterRace.Index = 1;
            this.miPIMasterRace.Text = "เชื้อชาติ";
            this.miPIMasterRace.Visible = false;
            this.miPIMasterRace.Click += new System.EventHandler(this.miPIMasterRace_Click);
            // 
            // miPIMasterNationality
            // 
            this.miPIMasterNationality.Index = 2;
            this.miPIMasterNationality.Text = "สัญชาติ";
            this.miPIMasterNationality.Visible = false;
            this.miPIMasterNationality.Click += new System.EventHandler(this.miPIMasterNationality_Click);
            // 
            // miPIMasterReligion
            // 
            this.miPIMasterReligion.Index = 3;
            this.miPIMasterReligion.Text = "ศาสนา";
            this.miPIMasterReligion.Visible = false;
            this.miPIMasterReligion.Click += new System.EventHandler(this.miPIMasterReligion_Click);
            // 
            // miPIMasterOccupation
            // 
            this.miPIMasterOccupation.Index = 4;
            this.miPIMasterOccupation.Text = "อาชีพ";
            this.miPIMasterOccupation.Visible = false;
            this.miPIMasterOccupation.Click += new System.EventHandler(this.miPIMasterOccupation_Click);
            // 
            // miPIMasterRelationship
            // 
            this.miPIMasterRelationship.Index = 5;
            this.miPIMasterRelationship.Text = "ความสัมพันธ์";
            this.miPIMasterRelationship.Visible = false;
            this.miPIMasterRelationship.Click += new System.EventHandler(this.miPIMasterRelationship_Click);
            // 
            // miPIMasterBank
            // 
            this.miPIMasterBank.Index = 6;
            this.miPIMasterBank.Text = "ธนาคาร";
            this.miPIMasterBank.Visible = false;
            this.miPIMasterBank.Click += new System.EventHandler(this.miPIMasterBank_Click);
            // 
            // miPIMasterBloodGroup
            // 
            this.miPIMasterBloodGroup.Index = 7;
            this.miPIMasterBloodGroup.Text = "หมู่เลือด";
            this.miPIMasterBloodGroup.Visible = false;
            this.miPIMasterBloodGroup.Click += new System.EventHandler(this.miPIMasterBloodGroup_Click);
            // 
            // miSpecialAllowance
            // 
            this.miSpecialAllowance.Index = 8;
            this.miSpecialAllowance.Text = "Special Allowance";
            this.miSpecialAllowance.Visible = false;
            this.miSpecialAllowance.Click += new System.EventHandler(this.miSpecialAllowance_Click);
            // 
            // miPIMasterPlace
            // 
            this.miPIMasterPlace.Index = 9;
            this.miPIMasterPlace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIMasterPlaceProvince,
            this.miPIMasterPlaceDistrict,
            this.miPIMasterPlaceSubDistrict,
            this.miPIMasterPlaceStreet});
            this.miPIMasterPlace.Text = "สถานที่ตั้ง";
            // 
            // miPIMasterPlaceProvince
            // 
            this.miPIMasterPlaceProvince.Index = 0;
            this.miPIMasterPlaceProvince.Text = "จังหวัด";
            this.miPIMasterPlaceProvince.Visible = false;
            this.miPIMasterPlaceProvince.Click += new System.EventHandler(this.miPIMasterPlaceProvince_Click);
            // 
            // miPIMasterPlaceDistrict
            // 
            this.miPIMasterPlaceDistrict.Index = 1;
            this.miPIMasterPlaceDistrict.Text = "เขต\r\n";
            this.miPIMasterPlaceDistrict.Visible = false;
            this.miPIMasterPlaceDistrict.Click += new System.EventHandler(this.miPIMasterPlaceDistrict_Click);
            // 
            // miPIMasterPlaceSubDistrict
            // 
            this.miPIMasterPlaceSubDistrict.Index = 2;
            this.miPIMasterPlaceSubDistrict.Text = "แขวง\r\n";
            this.miPIMasterPlaceSubDistrict.Visible = false;
            this.miPIMasterPlaceSubDistrict.Click += new System.EventHandler(this.miPIMasterPlaceSubDistrict_Click);
            // 
            // miPIMasterPlaceStreet
            // 
            this.miPIMasterPlaceStreet.Index = 3;
            this.miPIMasterPlaceStreet.Text = "ถนน\r\n";
            this.miPIMasterPlaceStreet.Visible = false;
            this.miPIMasterPlaceStreet.Click += new System.EventHandler(this.miPIMasterPlaceStreet_Click);
            // 
            // miPIMasterEducation
            // 
            this.miPIMasterEducation.Index = 10;
            this.miPIMasterEducation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIMasterEducationInstitute,
            this.miPIMasterEducationLevel,
            this.miPIMasterEducationFaculty,
            this.miPIMasterEducationMajor});
            this.miPIMasterEducation.Text = "การศึกษา";
            // 
            // miPIMasterEducationInstitute
            // 
            this.miPIMasterEducationInstitute.Index = 0;
            this.miPIMasterEducationInstitute.Text = "สถาบันการศึกษา\r\n";
            this.miPIMasterEducationInstitute.Visible = false;
            this.miPIMasterEducationInstitute.Click += new System.EventHandler(this.miPIMasterEducationInstitute_Click);
            // 
            // miPIMasterEducationLevel
            // 
            this.miPIMasterEducationLevel.Index = 1;
            this.miPIMasterEducationLevel.Text = "วุฒิการศึกษา\r\n";
            this.miPIMasterEducationLevel.Visible = false;
            this.miPIMasterEducationLevel.Click += new System.EventHandler(this.miPIMasterEducationLevel_Click);
            // 
            // miPIMasterEducationFaculty
            // 
            this.miPIMasterEducationFaculty.Index = 2;
            this.miPIMasterEducationFaculty.Text = "คณะ\r\n";
            this.miPIMasterEducationFaculty.Visible = false;
            this.miPIMasterEducationFaculty.Click += new System.EventHandler(this.miPIMasterEducationFaculty_Click);
            // 
            // miPIMasterEducationMajor
            // 
            this.miPIMasterEducationMajor.Index = 3;
            this.miPIMasterEducationMajor.Text = "วิชาเอก\r\n";
            this.miPIMasterEducationMajor.Visible = false;
            this.miPIMasterEducationMajor.Click += new System.EventHandler(this.miPIMasterEducationMajor_Click);
            // 
            // miPIMap
            // 
            this.miPIMap.Index = 1;
            this.miPIMap.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIMapCompany,
            this.miPIMapDepartment,
            this.miPIMapSection});
            this.miPIMap.Text = "ผังองค์กร";
            // 
            // miPIMapCompany
            // 
            this.miPIMapCompany.Index = 0;
            this.miPIMapCompany.Text = "บริษัท";
            this.miPIMapCompany.Visible = false;
            this.miPIMapCompany.Click += new System.EventHandler(this.miPIMapCompany_Click);
            // 
            // miPIMapDepartment
            // 
            this.miPIMapDepartment.Index = 1;
            this.miPIMapDepartment.Text = "ฝ่าย";
            this.miPIMapDepartment.Visible = false;
            this.miPIMapDepartment.Click += new System.EventHandler(this.miPIMapDepartment_Click);
            // 
            // miPIMapSection
            // 
            this.miPIMapSection.Index = 2;
            this.miPIMapSection.Text = "ส่วนงาน";
            this.miPIMapSection.Visible = false;
            this.miPIMapSection.Click += new System.EventHandler(this.miPIMapSection_Click);
            // 
            // miPIPosition
            // 
            this.miPIPosition.Index = 2;
            this.miPIPosition.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIPositionPosition,
            this.miPIPositionTitle});
            this.miPIPosition.Text = "ตำแหน่ง";
            // 
            // miPIPositionPosition
            // 
            this.miPIPositionPosition.Index = 0;
            this.miPIPositionPosition.Text = "ตำแหน่ง (Position)";
            this.miPIPositionPosition.Visible = false;
            this.miPIPositionPosition.Click += new System.EventHandler(this.miPIPositionPosition_Click);
            // 
            // miPIPositionTitle
            // 
            this.miPIPositionTitle.Index = 1;
            this.miPIPositionTitle.Text = "ตำแหน่ง (Title)";
            this.miPIPositionTitle.Visible = false;
            this.miPIPositionTitle.Click += new System.EventHandler(this.miPIPositionTitle_Click);
            // 
            // miPIEmployee
            // 
            this.miPIEmployee.Index = 3;
            this.miPIEmployee.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miPIEmployeePI,
            this.miPIEmployeeFormerPI,
            this.miPIEmployeeMoveToFormerPI,
            this.miPIImportEmployeeSalary,
            this.menuItem6,
            this.miPIEmployeeReport,
            this.miPIEmployeePictureReport,
            this.miPIEmployeePrint,
            this.miPINonEmployeeReport,
            this.miPIRetireStaff,
            this.miPIPersonalData,
            this.miPIExpiredDrivingLicense,
            this.miPIProbationEmployee,
            this.miPISalaryEmployee,
            this.miPIHireDate,
            this.miPIEmployeeSearch,
            this.miPIExpiredIDCard,
            this.miPIEmployeeRegist,
            this.miPIPersonnalDataWelfare,
            this.miPIEmployeeProvidentFund,
            this.miPIEmployeeProvidentFundResign,
            this.miPIExportEmployeeData});
            this.miPIEmployee.Text = "ข้อมูลพนักงาน";
            // 
            // miPIEmployeePI
            // 
            this.miPIEmployeePI.Index = 0;
            this.miPIEmployeePI.Text = "พนักงานปัจจุบัน";
            this.miPIEmployeePI.Visible = false;
            this.miPIEmployeePI.Click += new System.EventHandler(this.miPIEmployeePI_Click);
            // 
            // miPIEmployeeFormerPI
            // 
            this.miPIEmployeeFormerPI.Index = 1;
            this.miPIEmployeeFormerPI.Text = "พนักงานที่พ้นสภาพการทำงานแล้ว";
            this.miPIEmployeeFormerPI.Visible = false;
            this.miPIEmployeeFormerPI.Click += new System.EventHandler(this.miPIEmployeeFormerPI_Click);
            // 
            // miPIEmployeeMoveToFormerPI
            // 
            this.miPIEmployeeMoveToFormerPI.Index = 2;
            this.miPIEmployeeMoveToFormerPI.Text = "ย้ายพนักงานที่พ้นสภาพออกจากพนักงานปัจจุบัน";
            this.miPIEmployeeMoveToFormerPI.Visible = false;
            this.miPIEmployeeMoveToFormerPI.Click += new System.EventHandler(this.miPIEmployeeMoveToFormerPI_Click);
            // 
            // miPIImportEmployeeSalary
            // 
            this.miPIImportEmployeeSalary.Index = 3;
            this.miPIImportEmployeeSalary.Text = "ส่งข้อมูลเงินเดือนพนักงานเข้าสู่ระบบ";
            this.miPIImportEmployeeSalary.Visible = false;
            this.miPIImportEmployeeSalary.Click += new System.EventHandler(this.miPIImportEmployeeSalary_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // miPIEmployeeReport
            // 
            this.miPIEmployeeReport.Index = 5;
            this.miPIEmployeeReport.Text = "รายงานข้อมูลพนักงาน";
            this.miPIEmployeeReport.Visible = false;
            this.miPIEmployeeReport.Click += new System.EventHandler(this.miPIEmployeeReport_Click);
            // 
            // miPIEmployeePictureReport
            // 
            this.miPIEmployeePictureReport.Index = 6;
            this.miPIEmployeePictureReport.Text = "รายงานรายชื่อพนักงานพร้อมรูปถ่าย";
            this.miPIEmployeePictureReport.Visible = false;
            this.miPIEmployeePictureReport.Click += new System.EventHandler(this.miPIEmployeePictureReport_Click);
            // 
            // miPIEmployeePrint
            // 
            this.miPIEmployeePrint.Index = 7;
            this.miPIEmployeePrint.Text = "รายงานแบบสำรวจข้อมูลพนักงานประจำปี";
            this.miPIEmployeePrint.Visible = false;
            this.miPIEmployeePrint.Click += new System.EventHandler(this.miPIEmployeePrint_Click);
            // 
            // miPINonEmployeeReport
            // 
            this.miPINonEmployeeReport.Index = 8;
            this.miPINonEmployeeReport.Text = "รายงานข้อมูลพนักงานที่พ้นสภาพการทำงานแล้ว";
            this.miPINonEmployeeReport.Visible = false;
            this.miPINonEmployeeReport.Click += new System.EventHandler(this.miPINonEmployeeReport_Click);
            // 
            // miPIRetireStaff
            // 
            this.miPIRetireStaff.Index = 9;
            this.miPIRetireStaff.Text = "รายงานรายชื่อพนักงานเกษียณอายุ";
            this.miPIRetireStaff.Visible = false;
            this.miPIRetireStaff.Click += new System.EventHandler(this.miPIRetireStaff_Click);
            // 
            // miPIPersonalData
            // 
            this.miPIPersonalData.Index = 10;
            this.miPIPersonalData.Text = "รายงานข้อมูลพนักงานรายบุคคล";
            this.miPIPersonalData.Visible = false;
            this.miPIPersonalData.Click += new System.EventHandler(this.miPIPersonalData_Click);
            // 
            // miPIExpiredDrivingLicense
            // 
            this.miPIExpiredDrivingLicense.Index = 11;
            this.miPIExpiredDrivingLicense.Text = "รายงานข้อมูลใบขับขี่ของพนักงาน";
            this.miPIExpiredDrivingLicense.Visible = false;
            this.miPIExpiredDrivingLicense.Click += new System.EventHandler(this.miPIExpiredDrivingLicense_Click);
            // 
            // miPIProbationEmployee
            // 
            this.miPIProbationEmployee.Index = 12;
            this.miPIProbationEmployee.Text = "รายงานข้อมูล Probation";
            this.miPIProbationEmployee.Visible = false;
            this.miPIProbationEmployee.Click += new System.EventHandler(this.miPIProbationEmployee_Click);
            // 
            // miPISalaryEmployee
            // 
            this.miPISalaryEmployee.Index = 13;
            this.miPISalaryEmployee.Text = "รายงานข้อมูลเงินเดือนของพนักงาน";
            this.miPISalaryEmployee.Visible = false;
            this.miPISalaryEmployee.Click += new System.EventHandler(this.miPISalaryEmployee_Click);
            // 
            // miPIHireDate
            // 
            this.miPIHireDate.Index = 14;
            this.miPIHireDate.Text = "รายงานข้อมูลวันที่เริ่มทำงานของพนักงาน";
            this.miPIHireDate.Visible = false;
            this.miPIHireDate.Click += new System.EventHandler(this.miPIHireDate_Click);
            // 
            // miPIEmployeeSearch
            // 
            this.miPIEmployeeSearch.Index = 15;
            this.miPIEmployeeSearch.Text = "รายงานค้นหาพนักงาน";
            this.miPIEmployeeSearch.Visible = false;
            this.miPIEmployeeSearch.Click += new System.EventHandler(this.miPIEmployeeSearch_Click);
            // 
            // miPIExpiredIDCard
            // 
            this.miPIExpiredIDCard.Index = 16;
            this.miPIExpiredIDCard.Text = "รายงานข้อมูลบัตรประชาชนของพนักงาน";
            this.miPIExpiredIDCard.Visible = false;
            this.miPIExpiredIDCard.Click += new System.EventHandler(this.miPIExpiredIDCard_Click);
            // 
            // miPIEmployeeRegist
            // 
            this.miPIEmployeeRegist.Index = 17;
            this.miPIEmployeeRegist.Text = "รายงานทะเบียนลูกจ้าง";
            this.miPIEmployeeRegist.Visible = false;
            this.miPIEmployeeRegist.Click += new System.EventHandler(this.miPIEmployeeRegist_Click);
            // 
            // miPIPersonnalDataWelfare
            // 
            this.miPIPersonnalDataWelfare.Index = 18;
            this.miPIPersonnalDataWelfare.Text = "รายงานข้อมูลสวัสดิการพนักงาน";
            this.miPIPersonnalDataWelfare.Visible = false;
            this.miPIPersonnalDataWelfare.Click += new System.EventHandler(this.miPIPersonnalDataWelfare_Click);
            // 
            // miPIEmployeeProvidentFund
            // 
            this.miPIEmployeeProvidentFund.Index = 19;
            this.miPIEmployeeProvidentFund.Text = "รายงานข้อมูลพนักงานที่อยู่ในกองทุนสำรองเลี้ยงชีพ";
            this.miPIEmployeeProvidentFund.Visible = false;
            this.miPIEmployeeProvidentFund.Click += new System.EventHandler(this.miPIEmployeeProvidentFund_Click);
            // 
            // miPIEmployeeProvidentFundResign
            // 
            this.miPIEmployeeProvidentFundResign.Index = 20;
            this.miPIEmployeeProvidentFundResign.Text = "รายงานข้อมูลพนักงานที่ออกจากกองทุนสำรองเลี้ยงชีพ";
            this.miPIEmployeeProvidentFundResign.Visible = false;
            this.miPIEmployeeProvidentFundResign.Click += new System.EventHandler(this.miPIEmployeeProvidentFundResign_Click);
            // 
            // miPIExportEmployeeData
            // 
            this.miPIExportEmployeeData.Index = 21;
            this.miPIExportEmployeeData.Text = "Export Employee Data";
            this.miPIExportEmployeeData.Click += new System.EventHandler(this.miPIExportEmployeeData_Click);
            // 
            // miWelfare
            // 
            this.miWelfare.Index = 2;
            this.miWelfare.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miWelfareSetting,
            this.miWelfareMedicalAid,
            this.miWelfareContribution,
            this.miWelfareLoan,
            this.menuItem24,
            this.miWelfareBenefit});
            this.miWelfare.Text = "ข้อมูลสวัสดิการ";
            // 
            // miWelfareSetting
            // 
            this.miWelfareSetting.Index = 0;
            this.miWelfareSetting.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miWelfareSettingContribution,
            this.miWelfareSettingLoanReasonList,
            this.miWelfareSettingHospital,
            this.miSSHospital});
            this.miWelfareSetting.Text = "ตั้งค่าทั่วไป";
            // 
            // miWelfareSettingContribution
            // 
            this.miWelfareSettingContribution.Index = 0;
            this.miWelfareSettingContribution.Text = "เงินช่วยเหลือ";
            this.miWelfareSettingContribution.Visible = false;
            this.miWelfareSettingContribution.Click += new System.EventHandler(this.miWelfareSettingContribution_Click);
            // 
            // miWelfareSettingLoanReasonList
            // 
            this.miWelfareSettingLoanReasonList.Index = 1;
            this.miWelfareSettingLoanReasonList.Text = "เงินกู้";
            this.miWelfareSettingLoanReasonList.Visible = false;
            this.miWelfareSettingLoanReasonList.Click += new System.EventHandler(this.miWelfareSettingLoanReasonList_Click);
            // 
            // miWelfareSettingHospital
            // 
            this.miWelfareSettingHospital.Index = 2;
            this.miWelfareSettingHospital.Text = "โรงพยาบาลคู่สัญญา";
            this.miWelfareSettingHospital.Visible = false;
            this.miWelfareSettingHospital.Click += new System.EventHandler(this.miWelfareSettingHospital_Click);
            // 
            // miSSHospital
            // 
            this.miSSHospital.Index = 3;
            this.miSSHospital.Text = "โรงพยาบาลประกันสังคม";
            this.miSSHospital.Visible = false;
            this.miSSHospital.Click += new System.EventHandler(this.miSSHospital_Click);
            // 
            // miWelfareMedicalAid
            // 
            this.miWelfareMedicalAid.Index = 1;
            this.miWelfareMedicalAid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miWelfareMedicalAidListByEmp,
            this.miWelfareMedicalAidListByHospital,
            this.menuItem19,
            this.miWelfareMedicalAidReport,
            this.miWelfareMedicalAidAttReport,
            this.miWelfareMedicalAidNoAttReport,
            this.miWelfareMedicalAidListInsurancePaid});
            this.miWelfareMedicalAid.Text = "ข้อมูลการรักษาพยาบาล";
            // 
            // miWelfareMedicalAidListByEmp
            // 
            this.miWelfareMedicalAidListByEmp.Index = 0;
            this.miWelfareMedicalAidListByEmp.Text = "รายการรักษาพยาบาลตามพนักงาน";
            this.miWelfareMedicalAidListByEmp.Visible = false;
            this.miWelfareMedicalAidListByEmp.Click += new System.EventHandler(this.miWelfareMedicalAidListByEmp_Click);
            // 
            // miWelfareMedicalAidListByHospital
            // 
            this.miWelfareMedicalAidListByHospital.Index = 1;
            this.miWelfareMedicalAidListByHospital.Text = "รายการรักษาพยาบาลตามโรงพยาบาล";
            this.miWelfareMedicalAidListByHospital.Visible = false;
            this.miWelfareMedicalAidListByHospital.Click += new System.EventHandler(this.miWelfareMedicalAidListByHospital_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 2;
            this.menuItem19.Text = "-";
            // 
            // miWelfareMedicalAidReport
            // 
            this.miWelfareMedicalAidReport.Index = 3;
            this.miWelfareMedicalAidReport.Text = "รายงานข้อมูลค่ารักษาพยาบาลทั้งหมด";
            this.miWelfareMedicalAidReport.Visible = false;
            this.miWelfareMedicalAidReport.Click += new System.EventHandler(this.miWelfareMedicalAidReport_Click);
            // 
            // miWelfareMedicalAidAttReport
            // 
            this.miWelfareMedicalAidAttReport.Index = 4;
            this.miWelfareMedicalAidAttReport.Text = "รายงานข้อมูลค่ารักษาพยาบาลที่ใช้ใบส่งตัว";
            this.miWelfareMedicalAidAttReport.Visible = false;
            this.miWelfareMedicalAidAttReport.Click += new System.EventHandler(this.miWelfareMedicalAidAttReport_Click);
            // 
            // miWelfareMedicalAidNoAttReport
            // 
            this.miWelfareMedicalAidNoAttReport.Index = 5;
            this.miWelfareMedicalAidNoAttReport.Text = "รายงานข้อมูลค่ารักษาพยาบาลที่ไม่ใช้ใบส่งตัว";
            this.miWelfareMedicalAidNoAttReport.Visible = false;
            this.miWelfareMedicalAidNoAttReport.Click += new System.EventHandler(this.miWelfareMedicalAidNoAttReport_Click);
            // 
            // miWelfareMedicalAidListInsurancePaid
            // 
            this.miWelfareMedicalAidListInsurancePaid.Index = 6;
            this.miWelfareMedicalAidListInsurancePaid.Text = "รายงานข้อมูลค่ารักษาพยาบาลแยก (พนักงาน,ครอบครัว)";
            this.miWelfareMedicalAidListInsurancePaid.Visible = false;
            this.miWelfareMedicalAidListInsurancePaid.Click += new System.EventHandler(this.miWelfareMedicalAidListInsurancePaid_Click);
            // 
            // miWelfareContribution
            // 
            this.miWelfareContribution.Index = 2;
            this.miWelfareContribution.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miWelfareContributionEmpList,
            this.menuItem23,
            this.miWelfareContributionReport});
            this.miWelfareContribution.Text = "ข้อมูลเงินช่วยเหลือ";
            // 
            // miWelfareContributionEmpList
            // 
            this.miWelfareContributionEmpList.Index = 0;
            this.miWelfareContributionEmpList.Text = "รายการเงินช่วยเหลือตามพนักงาน";
            this.miWelfareContributionEmpList.Visible = false;
            this.miWelfareContributionEmpList.Click += new System.EventHandler(this.miWelfareContributionEmpList_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 1;
            this.menuItem23.Text = "-";
            // 
            // miWelfareContributionReport
            // 
            this.miWelfareContributionReport.Index = 2;
            this.miWelfareContributionReport.Text = "รายงานข้อมูลเงินช่วยเหลือของพนักงาน";
            this.miWelfareContributionReport.Click += new System.EventHandler(this.miWelfareContributionReport_Click);
            // 
            // miWelfareLoan
            // 
            this.miWelfareLoan.Index = 3;
            this.miWelfareLoan.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miWelfareLoanAppList,
            this.menuItem17,
            this.miWelfareLoanReport,
            this.miWelfareLoanByEmpReport,
            this.miWelfareLoanOffsetReport});
            this.miWelfareLoan.Text = "ข้อมูลเงินกู้";
            // 
            // miWelfareLoanAppList
            // 
            this.miWelfareLoanAppList.Index = 0;
            this.miWelfareLoanAppList.Text = "รายการเงินกู้ตามพนักงาน";
            this.miWelfareLoanAppList.Visible = false;
            this.miWelfareLoanAppList.Click += new System.EventHandler(this.miWelfareLoanAppList_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 1;
            this.menuItem17.Text = "-";
            // 
            // miWelfareLoanReport
            // 
            this.miWelfareLoanReport.Index = 2;
            this.miWelfareLoanReport.Text = "รายงานข้อมูลการกู้เงินของพนักงาน";
            this.miWelfareLoanReport.Visible = false;
            this.miWelfareLoanReport.Click += new System.EventHandler(this.miWelfareLoanReport_Click);
            // 
            // miWelfareLoanByEmpReport
            // 
            this.miWelfareLoanByEmpReport.Index = 3;
            this.miWelfareLoanByEmpReport.Text = "รายงานข้อมูลเงินกู้ใหม่ตามพนักงาน";
            this.miWelfareLoanByEmpReport.Visible = false;
            this.miWelfareLoanByEmpReport.Click += new System.EventHandler(this.miWelfareLoanByEmpReport_Click);
            // 
            // miWelfareLoanOffsetReport
            // 
            this.miWelfareLoanOffsetReport.Index = 4;
            this.miWelfareLoanOffsetReport.Text = "รายงานข้อมูล Offset ของพนักงาน";
            this.miWelfareLoanOffsetReport.Visible = false;
            this.miWelfareLoanOffsetReport.Click += new System.EventHandler(this.miWelfareLoanOffsetReport_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 4;
            this.menuItem24.Text = "-";
            // 
            // miWelfareBenefit
            // 
            this.miWelfareBenefit.Index = 5;
            this.miWelfareBenefit.Text = "รายงาน Welfare Benefit";
            this.miWelfareBenefit.Visible = false;
            this.miWelfareBenefit.Click += new System.EventHandler(this.miWelfareBenefit_Click);
            // 
            // miVehicle
            // 
            this.miVehicle.Index = 3;
            this.miVehicle.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleSetting,
            this.miVehicleVehicle,
            this.miVehicleMaintenance,
            this.miVehicleDocument});
            this.miVehicle.Text = "ข้อมูลรถยนต์";
            // 
            // miVehicleSetting
            // 
            this.miVehicleSetting.Index = 0;
            this.miVehicleSetting.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleSettingPoliceStation,
            this.miVehicleSettingAccidentPlace});
            this.miVehicleSetting.Text = "ตั้งค่าทั่วไป";
            // 
            // miVehicleSettingPoliceStation
            // 
            this.miVehicleSettingPoliceStation.Index = 0;
            this.miVehicleSettingPoliceStation.Text = "สถานีตำรวจ\r\n";
            this.miVehicleSettingPoliceStation.Visible = false;
            this.miVehicleSettingPoliceStation.Click += new System.EventHandler(this.miVehicleSettingPoliceStation_Click);
            // 
            // miVehicleSettingAccidentPlace
            // 
            this.miVehicleSettingAccidentPlace.Index = 1;
            this.miVehicleSettingAccidentPlace.Text = "สถานที่เกิดอุบัติเหตุ\r\n";
            this.miVehicleSettingAccidentPlace.Visible = false;
            this.miVehicleSettingAccidentPlace.Click += new System.EventHandler(this.miVehicleSettingAccidentPlace_Click);
            // 
            // miVehicleVehicle
            // 
            this.miVehicleVehicle.Index = 1;
            this.miVehicleVehicle.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleVehicleSetting,
            this.menuItem20,
            this.miVehicleLeasingCalculation,
            this.miQuotation,
            this.miPO,
            this.miVehicleVehicleVehicle,
            this.miSellingPlan,
            this.menuItem7,
            this.miVehicleVehicleSpare,
            this.miVehicleNoVehicleAssign,
            this.miVehicleMainVehicle,
            this.miVehicleLeasingCar,
            this.menuItem26});
            this.miVehicleVehicle.Text = "รถยนต์";
            // 
            // miVehicleVehicleSetting
            // 
            this.miVehicleVehicleSetting.Index = 0;
            this.miVehicleVehicleSetting.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleVehicleColor,
            this.miVehicleVehicleModel,
            this.miVehicleVehicleBrand,
            this.miVehicleVehicleVendor,
            this.miVehicleBidder});
            this.miVehicleVehicleSetting.Text = "ตั้งค่าทั่วไป";
            // 
            // miVehicleVehicleColor
            // 
            this.miVehicleVehicleColor.Index = 0;
            this.miVehicleVehicleColor.Text = "สี\r\n";
            this.miVehicleVehicleColor.Visible = false;
            this.miVehicleVehicleColor.Click += new System.EventHandler(this.miVehicleVehicleColor_Click);
            // 
            // miVehicleVehicleModel
            // 
            this.miVehicleVehicleModel.Index = 1;
            this.miVehicleVehicleModel.Text = "รุ่น\r\n";
            this.miVehicleVehicleModel.Visible = false;
            this.miVehicleVehicleModel.Click += new System.EventHandler(this.miVehicleVehicleModel_Click);
            // 
            // miVehicleVehicleBrand
            // 
            this.miVehicleVehicleBrand.Index = 2;
            this.miVehicleVehicleBrand.Text = "ยี่ห้อ\r\n";
            this.miVehicleVehicleBrand.Visible = false;
            this.miVehicleVehicleBrand.Click += new System.EventHandler(this.miVehicleVehicleBrand_Click);
            // 
            // miVehicleVehicleVendor
            // 
            this.miVehicleVehicleVendor.Index = 3;
            this.miVehicleVehicleVendor.Text = "ผู้จำหน่าย\r\n";
            this.miVehicleVehicleVendor.Visible = false;
            this.miVehicleVehicleVendor.Click += new System.EventHandler(this.miVehicleVehicleVendor_Click);
            // 
            // miVehicleBidder
            // 
            this.miVehicleBidder.Index = 4;
            this.miVehicleBidder.Text = "ผู้ประมูล";
            this.miVehicleBidder.Visible = false;
            this.miVehicleBidder.Click += new System.EventHandler(this.miVehicleBidder_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            this.menuItem20.Text = "-";
            // 
            // miVehicleLeasingCalculation
            // 
            this.miVehicleLeasingCalculation.Index = 2;
            this.miVehicleLeasingCalculation.Text = "คำนวณค่าเช่า";
            this.miVehicleLeasingCalculation.Visible = false;
            this.miVehicleLeasingCalculation.Click += new System.EventHandler(this.miVehicleLeasingCalculation_Click);
            // 
            // miQuotation
            // 
            this.miQuotation.Index = 3;
            this.miQuotation.Text = "ใบเสนอราคา";
            this.miQuotation.Visible = false;
            this.miQuotation.Click += new System.EventHandler(this.miQuotation_Click);
            // 
            // miPO
            // 
            this.miPO.Index = 4;
            this.miPO.Text = "ใบสั่งซื้อ";
            this.miPO.Visible = false;
            this.miPO.Click += new System.EventHandler(this.miPO_Click);
            // 
            // miVehicleVehicleVehicle
            // 
            this.miVehicleVehicleVehicle.Index = 5;
            this.miVehicleVehicleVehicle.Text = "ข้อมูลรถยนต์\r\n";
            this.miVehicleVehicleVehicle.Visible = false;
            this.miVehicleVehicleVehicle.Click += new System.EventHandler(this.miVehicleVehicleVehicle_Click);
            // 
            // miSellingPlan
            // 
            this.miSellingPlan.Index = 6;
            this.miSellingPlan.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleSellingPlanSellingPlan,
            this.miVehicleSellingPlanVehicleSelling});
            this.miSellingPlan.Text = "ข้อมูลขายรถยนต์";
            // 
            // miVehicleSellingPlanSellingPlan
            // 
            this.miVehicleSellingPlanSellingPlan.Index = 0;
            this.miVehicleSellingPlanSellingPlan.Text = "แผนการขายรถยนต์";
            this.miVehicleSellingPlanSellingPlan.Visible = false;
            this.miVehicleSellingPlanSellingPlan.Click += new System.EventHandler(this.miVehicleSellingPlanSellingPlan_Click);
            // 
            // miVehicleSellingPlanVehicleSelling
            // 
            this.miVehicleSellingPlanVehicleSelling.Index = 1;
            this.miVehicleSellingPlanVehicleSelling.Text = "รายงานรถขาย";
            this.miVehicleSellingPlanVehicleSelling.Visible = false;
            this.miVehicleSellingPlanVehicleSelling.Click += new System.EventHandler(this.miVehicleSellingPlanVehicleSelling_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // miVehicleVehicleSpare
            // 
            this.miVehicleVehicleSpare.Index = 8;
            this.miVehicleVehicleSpare.Text = "รายงานรถ Spare";
            this.miVehicleVehicleSpare.Visible = false;
            this.miVehicleVehicleSpare.Click += new System.EventHandler(this.miVehicleVehicleSpare_Click);
            // 
            // miVehicleNoVehicleAssign
            // 
            this.miVehicleNoVehicleAssign.Index = 9;
            this.miVehicleNoVehicleAssign.Text = "รายงานรถขาย ถูกโจรกรรม และ เสียหายจนใช้การไม่ได้";
            this.miVehicleNoVehicleAssign.Visible = false;
            this.miVehicleNoVehicleAssign.Click += new System.EventHandler(this.miVehicleNoVehicleAssign_Click);
            // 
            // miVehicleMainVehicle
            // 
            this.miVehicleMainVehicle.Index = 10;
            this.miVehicleMainVehicle.Text = "รายงานรถยนต์ให้เช่า";
            this.miVehicleMainVehicle.Visible = false;
            this.miVehicleMainVehicle.Click += new System.EventHandler(this.miVehicleMainVehicle_Click);
            // 
            // miVehicleLeasingCar
            // 
            this.miVehicleLeasingCar.Index = 11;
            this.miVehicleLeasingCar.Text = "รายงานแยกประเภทค่าเช่า";
            this.miVehicleLeasingCar.Visible = false;
            this.miVehicleLeasingCar.Click += new System.EventHandler(this.miVehicleLeasingCar_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 12;
            this.menuItem26.Text = "รายงานการซื้อรถยนต์";
            this.menuItem26.Click += new System.EventHandler(this.miVehicleDiscountCar_Click);
            // 
            // miVehicleMaintenance
            // 
            this.miVehicleMaintenance.Index = 2;
            this.miVehicleMaintenance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleMaintenanceSpareParts,
            this.miVehicleMaintenanceGarage,
            this.miVehicleMaintenanceHistory,
            this.miVehicleMaintenanceAccidentHistory,
            this.menuItem8,
            this.miVehicleAccident,
            this.miVehicleAccidentByPlateNo,
            this.miVehicleAccidentByEmpNo,
            this.miVehicleMaintenancebyGarage,
            this.miVehicleMaintenanceTotalAmountMaintenance,
            this.miVehicleVehicleRepairedVehiclByFinishDate,
            this.miVehicleVehicleRepairedVehicle,
            this.miVehicleMaintenanceRepairingHistorybyVehicle,
            this.miVehicleVehicleRepairingHistoryByModel,
            this.miVehicleVehicleRepairingHistoryByCustomer,
            this.miVehicleVehicleRepairingHistoryBySpareParts,
            this.miVehicleVehicleRepairingHistoryByPlateNo,
            this.miVehicleAccidentExcessInsurance,
            this.miVehicleAvgMaintenance,
            this.miVehicleAvgMaintenanceCust,
            this.miVehicleRepairingNoneTaxInvoice,
            this.miComparisonMaintenance});
            this.miVehicleMaintenance.Text = "ซ่อมบำรุง";
            // 
            // miVehicleMaintenanceSpareParts
            // 
            this.miVehicleMaintenanceSpareParts.Index = 0;
            this.miVehicleMaintenanceSpareParts.Text = "อะไหล่\r\n";
            this.miVehicleMaintenanceSpareParts.Visible = false;
            this.miVehicleMaintenanceSpareParts.Click += new System.EventHandler(this.miVehicleMaintenanceSpareParts_Click);
            // 
            // miVehicleMaintenanceGarage
            // 
            this.miVehicleMaintenanceGarage.Index = 1;
            this.miVehicleMaintenanceGarage.Text = "ศูนย์บริการ";
            this.miVehicleMaintenanceGarage.Visible = false;
            this.miVehicleMaintenanceGarage.Click += new System.EventHandler(this.miVehicleMaintenanceGarage_Click);
            // 
            // miVehicleMaintenanceHistory
            // 
            this.miVehicleMaintenanceHistory.Index = 2;
            this.miVehicleMaintenanceHistory.Text = "ประวัติการซ่อม\r\n";
            this.miVehicleMaintenanceHistory.Visible = false;
            this.miVehicleMaintenanceHistory.Click += new System.EventHandler(this.miVehicleMaintenanceHistory_Click);
            // 
            // miVehicleMaintenanceAccidentHistory
            // 
            this.miVehicleMaintenanceAccidentHistory.Index = 3;
            this.miVehicleMaintenanceAccidentHistory.Text = "ประวัติอุบัติเหตุ\r\n";
            this.miVehicleMaintenanceAccidentHistory.Visible = false;
            this.miVehicleMaintenanceAccidentHistory.Click += new System.EventHandler(this.miVehicleMaintenanceAccidentHistory_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.Text = "-";
            // 
            // miVehicleAccident
            // 
            this.miVehicleAccident.Index = 5;
            this.miVehicleAccident.Text = "รายงานอุบัติเหตุ";
            this.miVehicleAccident.Visible = false;
            this.miVehicleAccident.Click += new System.EventHandler(this.miVehicleAccident_Click);
            // 
            // miVehicleAccidentByPlateNo
            // 
            this.miVehicleAccidentByPlateNo.Index = 6;
            this.miVehicleAccidentByPlateNo.Text = "รายงานประวัติอุบัติเหตุทั้งหมดของรถแต่ละคัน";
            this.miVehicleAccidentByPlateNo.Visible = false;
            this.miVehicleAccidentByPlateNo.Click += new System.EventHandler(this.miVehicleAccidentByPlateNo_Click);
            // 
            // miVehicleAccidentByEmpNo
            // 
            this.miVehicleAccidentByEmpNo.Index = 7;
            this.miVehicleAccidentByEmpNo.Text = "รายงานประวัติอุบัติเหตุทั้งหมดของพนักงานแต่ละคน";
            this.miVehicleAccidentByEmpNo.Visible = false;
            this.miVehicleAccidentByEmpNo.Click += new System.EventHandler(this.miVehicleAccidentByEmpNo_Click);
            // 
            // miVehicleMaintenancebyGarage
            // 
            this.miVehicleMaintenancebyGarage.Index = 8;
            this.miVehicleMaintenancebyGarage.Text = "รายงานค่าซ่อมของศูนย์ซ่อมต่างๆ";
            this.miVehicleMaintenancebyGarage.Visible = false;
            this.miVehicleMaintenancebyGarage.Click += new System.EventHandler(this.miVehicleMaintenancebyGarage_Click);
            // 
            // miVehicleMaintenanceTotalAmountMaintenance
            // 
            this.miVehicleMaintenanceTotalAmountMaintenance.Index = 9;
            this.miVehicleMaintenanceTotalAmountMaintenance.Text = "รายงานค่าซ่อมรถยนต์ (ค่าซ่อมทั้งหมด)";
            this.miVehicleMaintenanceTotalAmountMaintenance.Visible = false;
            this.miVehicleMaintenanceTotalAmountMaintenance.Click += new System.EventHandler(this.miVehicleMaintenanceTotalAmountMaintenance_Click);
            // 
            // miVehicleVehicleRepairedVehiclByFinishDate
            // 
            this.miVehicleVehicleRepairedVehiclByFinishDate.Index = 10;
            this.miVehicleVehicleRepairedVehiclByFinishDate.Text = "รายงานรถที่ซ่อมรายวัน";
            this.miVehicleVehicleRepairedVehiclByFinishDate.Visible = false;
            this.miVehicleVehicleRepairedVehiclByFinishDate.Click += new System.EventHandler(this.miVehicleVehicleRepairedVehiclByFinishDate_Click);
            // 
            // miVehicleVehicleRepairedVehicle
            // 
            this.miVehicleVehicleRepairedVehicle.Index = 11;
            this.miVehicleVehicleRepairedVehicle.Text = "รายงานรถที่อยู่ระหว่างซ่อมบำรุง";
            this.miVehicleVehicleRepairedVehicle.Visible = false;
            this.miVehicleVehicleRepairedVehicle.Click += new System.EventHandler(this.miVehicleVehicleRepairedVehicle_Click);
            // 
            // miVehicleMaintenanceRepairingHistorybyVehicle
            // 
            this.miVehicleMaintenanceRepairingHistorybyVehicle.Index = 12;
            this.miVehicleMaintenanceRepairingHistorybyVehicle.Text = "รายงานประวัติการซ่อมทั้งหมดของรถแต่ละคัน";
            this.miVehicleMaintenanceRepairingHistorybyVehicle.Visible = false;
            this.miVehicleMaintenanceRepairingHistorybyVehicle.Click += new System.EventHandler(this.miVehicleMaintenanceRepairingHistorybyVehicle_Click);
            // 
            // miVehicleVehicleRepairingHistoryByModel
            // 
            this.miVehicleVehicleRepairingHistoryByModel.Index = 13;
            this.miVehicleVehicleRepairingHistoryByModel.Text = "รายงานประวัติการซ่อมตามรุ่นรถ";
            this.miVehicleVehicleRepairingHistoryByModel.Visible = false;
            this.miVehicleVehicleRepairingHistoryByModel.Click += new System.EventHandler(this.miVehicleVehicleRepairingHistoryByModel_Click);
            // 
            // miVehicleVehicleRepairingHistoryByCustomer
            // 
            this.miVehicleVehicleRepairingHistoryByCustomer.Index = 14;
            this.miVehicleVehicleRepairingHistoryByCustomer.Text = "รายงานประวัติการซ่อมตามลูกค้า";
            this.miVehicleVehicleRepairingHistoryByCustomer.Visible = false;
            this.miVehicleVehicleRepairingHistoryByCustomer.Click += new System.EventHandler(this.miVehicleVehicleRepairingHistoryByCustomer_Click);
            // 
            // miVehicleVehicleRepairingHistoryBySpareParts
            // 
            this.miVehicleVehicleRepairingHistoryBySpareParts.Index = 15;
            this.miVehicleVehicleRepairingHistoryBySpareParts.Text = "รายงานประวัติการซ่อมตามรายการอะไหล่";
            this.miVehicleVehicleRepairingHistoryBySpareParts.Visible = false;
            this.miVehicleVehicleRepairingHistoryBySpareParts.Click += new System.EventHandler(this.miVehicleVehicleRepairingHistoryBySpareParts_Click);
            // 
            // miVehicleVehicleRepairingHistoryByPlateNo
            // 
            this.miVehicleVehicleRepairingHistoryByPlateNo.Index = 16;
            this.miVehicleVehicleRepairingHistoryByPlateNo.Text = "รายงานประวัติการซ่อมตามหมายเลขทะเบียน";
            this.miVehicleVehicleRepairingHistoryByPlateNo.Visible = false;
            this.miVehicleVehicleRepairingHistoryByPlateNo.Click += new System.EventHandler(this.miVehicleVehicleRepairingHistoryByPlateNo_Click);
            // 
            // miVehicleAccidentExcessInsurance
            // 
            this.miVehicleAccidentExcessInsurance.Index = 17;
            this.miVehicleAccidentExcessInsurance.Text = "รายงานค่า Excess";
            this.miVehicleAccidentExcessInsurance.Click += new System.EventHandler(this.miVehicleAccidentExcessInsurance_Click);
            // 
            // miVehicleAvgMaintenance
            // 
            this.miVehicleAvgMaintenance.Index = 18;
            this.miVehicleAvgMaintenance.Text = "รายงานรายงานเฉลี่ยค่าซ่อม แยกตามรุ่นรถ";
            this.miVehicleAvgMaintenance.Visible = false;
            this.miVehicleAvgMaintenance.Click += new System.EventHandler(this.miVehicleAvgMaintenance_Click);
            // 
            // miVehicleAvgMaintenanceCust
            // 
            this.miVehicleAvgMaintenanceCust.Index = 19;
            this.miVehicleAvgMaintenanceCust.Text = "รายงานรายงานเฉลี่ยค่าซ่อม แยกตามผู้เช่า";
            this.miVehicleAvgMaintenanceCust.Click += new System.EventHandler(this.miVehicleAvgMaintenanceCust_Click);
            // 
            // miVehicleRepairingNoneTaxInvoice
            // 
            this.miVehicleRepairingNoneTaxInvoice.Index = 20;
            this.miVehicleRepairingNoneTaxInvoice.Text = "รายงานใบสั่งซ่อมรถยนต์ที่ยังไม่มีใบกำกับภาษี";
            this.miVehicleRepairingNoneTaxInvoice.Visible = false;
            this.miVehicleRepairingNoneTaxInvoice.Click += new System.EventHandler(this.miVehicleRepairingNoneTaxInvoice_Click);
            // 
            // miComparisonMaintenance
            // 
            this.miComparisonMaintenance.Index = 21;
            this.miComparisonMaintenance.Text = "รายงานเปรียบเทียบค่าซ่อมบำรุง";
            this.miComparisonMaintenance.Visible = false;
            this.miComparisonMaintenance.Click += new System.EventHandler(this.miComparisonMaintenance_Click);
            // 
            // miVehicleDocument
            // 
            this.miVehicleDocument.Index = 3;
            this.miVehicleDocument.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleDocumentInsurance,
            this.miVehicleDocumentInsuranceTypeOne,
            this.miVehicleDocumentCompulsory,
            this.miVehicleDocumentVehicleTax,
            this.miVehicleMaintenanceExcessInsurance});
            this.miVehicleDocument.Text = "เอกสารเกี่ยวกับรถยนต์";
            // 
            // miVehicleDocumentInsurance
            // 
            this.miVehicleDocumentInsurance.Index = 0;
            this.miVehicleDocumentInsurance.Text = "บริษัทประกันภัย\r\n";
            this.miVehicleDocumentInsurance.Visible = false;
            this.miVehicleDocumentInsurance.Click += new System.EventHandler(this.miVehicleDocumentInsurance_Click);
            // 
            // miVehicleDocumentInsuranceTypeOne
            // 
            this.miVehicleDocumentInsuranceTypeOne.Index = 1;
            this.miVehicleDocumentInsuranceTypeOne.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleDocumentMaintainInsuranceTypeOne,
            this.miVehicleDocumentCreateInsuranceTypeOne});
            this.miVehicleDocumentInsuranceTypeOne.Text = "ประกันภัยชั้นหนึ่ง\r\n";
            // 
            // miVehicleDocumentMaintainInsuranceTypeOne
            // 
            this.miVehicleDocumentMaintainInsuranceTypeOne.Index = 0;
            this.miVehicleDocumentMaintainInsuranceTypeOne.Text = "ข้อมูลประกันภัยชั้นหนึ่ง";
            this.miVehicleDocumentMaintainInsuranceTypeOne.Visible = false;
            this.miVehicleDocumentMaintainInsuranceTypeOne.Click += new System.EventHandler(this.miVehicleDocumentMaintainInsuranceTypeOne_Click);
            // 
            // miVehicleDocumentCreateInsuranceTypeOne
            // 
            this.miVehicleDocumentCreateInsuranceTypeOne.Index = 1;
            this.miVehicleDocumentCreateInsuranceTypeOne.Text = "ระบุรถในประกันภัยชั้นหนึ่ง";
            this.miVehicleDocumentCreateInsuranceTypeOne.Visible = false;
            this.miVehicleDocumentCreateInsuranceTypeOne.Click += new System.EventHandler(this.miVehicleDocumentCreateInsuranceTypeOne_Click);
            // 
            // miVehicleDocumentCompulsory
            // 
            this.miVehicleDocumentCompulsory.Index = 2;
            this.miVehicleDocumentCompulsory.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleDocumentCompulsoryPlate,
            this.miVehicleDocumentCompulsoryMonth,
            this.menuItem15,
            this.miVehicleDocumentCompulsoryInsurancenbyPlate});
            this.miVehicleDocumentCompulsory.Text = "พรบ.\r\n";
            // 
            // miVehicleDocumentCompulsoryPlate
            // 
            this.miVehicleDocumentCompulsoryPlate.Index = 0;
            this.miVehicleDocumentCompulsoryPlate.Text = "ข้อมูลพรบ.ตามป้ายทะเบียน\r\n";
            this.miVehicleDocumentCompulsoryPlate.Visible = false;
            this.miVehicleDocumentCompulsoryPlate.Click += new System.EventHandler(this.miVehicleDocumentCompulsoryPlate_Click);
            // 
            // miVehicleDocumentCompulsoryMonth
            // 
            this.miVehicleDocumentCompulsoryMonth.Index = 1;
            this.miVehicleDocumentCompulsoryMonth.Text = "ต่อพรบ.ตามเดือน/ปีที่หมดอายุ\r\n";
            this.miVehicleDocumentCompulsoryMonth.Visible = false;
            this.miVehicleDocumentCompulsoryMonth.Click += new System.EventHandler(this.miVehicleDocumentCompulsoryMonth_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 2;
            this.menuItem15.Text = "-";
            // 
            // miVehicleDocumentCompulsoryInsurancenbyPlate
            // 
            this.miVehicleDocumentCompulsoryInsurancenbyPlate.Index = 3;
            this.miVehicleDocumentCompulsoryInsurancenbyPlate.Text = "รายงาน ข้อมูลพรบ. ตามป้ายทะเบียน";
            this.miVehicleDocumentCompulsoryInsurancenbyPlate.Visible = false;
            this.miVehicleDocumentCompulsoryInsurancenbyPlate.Click += new System.EventHandler(this.miVehicleDocumentCompulsoryInsurancenbyPlate_Click);
            // 
            // miVehicleDocumentVehicleTax
            // 
            this.miVehicleDocumentVehicleTax.Index = 3;
            this.miVehicleDocumentVehicleTax.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miVehicleDocumentVehicleTaxPlateNo,
            this.miVehicleDocumentVehicleTaxMonth});
            this.miVehicleDocumentVehicleTax.Text = "ภาษีรถยนต์\r\n";
            // 
            // miVehicleDocumentVehicleTaxPlateNo
            // 
            this.miVehicleDocumentVehicleTaxPlateNo.Index = 0;
            this.miVehicleDocumentVehicleTaxPlateNo.Text = "ข้อมูลภาษีรถยนต์ตามป้ายทะเบียน\r\n";
            this.miVehicleDocumentVehicleTaxPlateNo.Visible = false;
            this.miVehicleDocumentVehicleTaxPlateNo.Click += new System.EventHandler(this.miVehicleDocumentVehicleTaxPlateNo_Click);
            // 
            // miVehicleDocumentVehicleTaxMonth
            // 
            this.miVehicleDocumentVehicleTaxMonth.Index = 1;
            this.miVehicleDocumentVehicleTaxMonth.Text = "ต่อภาษีรถยนต์ตามเดือน/ปีที่หมดอายุ\r\n";
            this.miVehicleDocumentVehicleTaxMonth.Visible = false;
            this.miVehicleDocumentVehicleTaxMonth.Click += new System.EventHandler(this.miVehicleDocumentVehicleTaxMonth_Click);
            // 
            // miVehicleMaintenanceExcessInsurance
            // 
            this.miVehicleMaintenanceExcessInsurance.Index = 4;
            this.miVehicleMaintenanceExcessInsurance.Text = "ค่า Excess";
            this.miVehicleMaintenanceExcessInsurance.Visible = false;
            this.miVehicleMaintenanceExcessInsurance.Click += new System.EventHandler(this.miVehicleMaintenanceExcessInsurance_Click);
            // 
            // miContract
            // 
            this.miContract.Index = 4;
            this.miContract.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miContractSetting,
            this.miContractCustomer,
            this.miContractDocument,
            this.miContractAssignmentHistory,
            this.menuItem11,
            this.miContractVehicleCharge,
            this.miContractVehicleMatchWithDriverCheckList,
            this.miContractVehicleMatchWithDriver,
            this.miContractContractMatchWithDriver,
            this.miContractNoAccidentReward});
            this.miContract.Text = "ข้อมูลเอกสารสัญญา";
            // 
            // miContractSetting
            // 
            this.miContractSetting.Index = 0;
            this.miContractSetting.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miContractSettingContractCancelReason,
            this.miContractSettingServiceStaffType,
            this.miContractSettingServiceStaffChargeContract,
            this.miContractSettingServiceStaffCharge,
            this.miContractSettingMinimumOTCharge,
            this.miContractSettingCompensate});
            this.miContractSetting.Text = "ตั้งค่าทั่วไป";
            // 
            // miContractSettingContractCancelReason
            // 
            this.miContractSettingContractCancelReason.Index = 0;
            this.miContractSettingContractCancelReason.Text = "เหตุผลในการยกเลิกสัญญา\r\n";
            this.miContractSettingContractCancelReason.Visible = false;
            this.miContractSettingContractCancelReason.Click += new System.EventHandler(this.miContractSettingContractCancelReason_Click);
            // 
            // miContractSettingServiceStaffType
            // 
            this.miContractSettingServiceStaffType.Index = 1;
            this.miContractSettingServiceStaffType.Text = "ประเภทพนักงาน(Service Staff)";
            this.miContractSettingServiceStaffType.Visible = false;
            this.miContractSettingServiceStaffType.Click += new System.EventHandler(this.miContractSettingServiceStaffType_Click);
            // 
            // miContractSettingServiceStaffChargeContract
            // 
            this.miContractSettingServiceStaffChargeContract.Index = 2;
            this.miContractSettingServiceStaffChargeContract.Text = "กำหนดอัตราค่าบริการตามสัญญา";
            this.miContractSettingServiceStaffChargeContract.Visible = false;
            this.miContractSettingServiceStaffChargeContract.Click += new System.EventHandler(this.miContractSettingServiceStaffChargeContract_Click);
            // 
            // miContractSettingServiceStaffCharge
            // 
            this.miContractSettingServiceStaffCharge.Index = 3;
            this.miContractSettingServiceStaffCharge.Text = "กำหนดอัตราค่าบริการตามประเภทพนักงานบริการ";
            this.miContractSettingServiceStaffCharge.Visible = false;
            this.miContractSettingServiceStaffCharge.Click += new System.EventHandler(this.miContractSettingServiceStaffCharge_Click);
            // 
            // miContractSettingMinimumOTCharge
            // 
            this.miContractSettingMinimumOTCharge.Index = 4;
            this.miContractSettingMinimumOTCharge.Text = "กำหนดอัตราค่าล่วงเวลาขั้นต่ำสำหรับพนักงานบริการ";
            this.miContractSettingMinimumOTCharge.Visible = false;
            this.miContractSettingMinimumOTCharge.Click += new System.EventHandler(this.miContractSettingMinimumOTCharge_Click);
            // 
            // miContractSettingCompensate
            // 
            this.miContractSettingCompensate.Index = 5;
            this.miContractSettingCompensate.Text = "ค่าชดเชย";
            this.miContractSettingCompensate.Visible = false;
            this.miContractSettingCompensate.Click += new System.EventHandler(this.miContractSettingCompensate_Click);
            // 
            // miContractCustomer
            // 
            this.miContractCustomer.Index = 1;
            this.miContractCustomer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miContractCustomerData,
            this.miContractCustomerDepartment});
            this.miContractCustomer.Text = "ลูกค้า";
            // 
            // miContractCustomerData
            // 
            this.miContractCustomerData.Index = 0;
            this.miContractCustomerData.Text = "ข้อมูลลูกค้า\r\n";
            this.miContractCustomerData.Visible = false;
            this.miContractCustomerData.Click += new System.EventHandler(this.miContractCustomerData_Click);
            // 
            // miContractCustomerDepartment
            // 
            this.miContractCustomerDepartment.Index = 1;
            this.miContractCustomerDepartment.Text = "ฝ่ายลูกค้า";
            this.miContractCustomerDepartment.Visible = false;
            this.miContractCustomerDepartment.Click += new System.EventHandler(this.miContractCustomerDepartment_Click);
            // 
            // miContractDocument
            // 
            this.miContractDocument.Index = 2;
            this.miContractDocument.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miContractVehicle,
            this.miContractDriver,
            this.miContractOtherServiceStaft,
            this.miContractDocumentApprove,
            this.miContractDocumentCancel,
            this.miContractDocumentServiceStaffMatchToContract,
            this.miContractDocumentVDContractMatching,
            this.miContractSettingCustomerChargeAdjustOtherSS,
            this.miContractSettingCustomerChargeAdjustDriver,
            this.miContractDocumentSpecialCharge,
            this.menuItem10,
            this.miContractDocumentLeasingHistoryOfActiveVehicle,
            this.miContractDocumentExpiredVehicleContract,
            this.miContractDocumentInComplete,
            this.miContractDocumentLongTermContract,
            this.miContractDocumentSpareDriver,
            this.miContractDocumentServiceStaffContract,
            this.miContractDocumentExpiredVehicle,
            this.miContractDocumentExpiredDriver,
            this.miContractDocumentCustomerSpecialCharge,
            this.miContractDocumentChargeDiff,
            this.miContractDocumentPenaltyCharge,
            this.miContractListExpectedIncomeReport,
            this.menuItem22,
            this.miContractDocumentRenewalNotice,
            this.miContractDocumentDriverAgreement,
            this.miContractDocumentCarAgreement,
            this.miContractDocumentCompanyAgreement});
            this.miContractDocument.Text = "เอกสารสัญญา";
            // 
            // miContractVehicle
            // 
            this.miContractVehicle.Index = 0;
            this.miContractVehicle.Text = "ข้อมูลเอกสารสัญญาสำหรับรถยนต์";
            this.miContractVehicle.Visible = false;
            this.miContractVehicle.Click += new System.EventHandler(this.miContractVehicle_Click);
            // 
            // miContractDriver
            // 
            this.miContractDriver.Index = 1;
            this.miContractDriver.Text = "ข้อมูลเอกสารสัญญาสำหรับพนักงานขับรถ";
            this.miContractDriver.Visible = false;
            this.miContractDriver.Click += new System.EventHandler(this.miContractDriver_Click);
            // 
            // miContractOtherServiceStaft
            // 
            this.miContractOtherServiceStaft.Index = 2;
            this.miContractOtherServiceStaft.Text = "ข้อมูลเอกสารสัญญาสำหรับพนักงานบริการอื่น ๆ";
            this.miContractOtherServiceStaft.Visible = false;
            this.miContractOtherServiceStaft.Click += new System.EventHandler(this.miContractOtherServiceStaft_Click);
            // 
            // miContractDocumentApprove
            // 
            this.miContractDocumentApprove.Index = 3;
            this.miContractDocumentApprove.Text = "อนุมัติสัญญา\r\n";
            this.miContractDocumentApprove.Visible = false;
            this.miContractDocumentApprove.Click += new System.EventHandler(this.miContractDocumentApprove_Click);
            // 
            // miContractDocumentCancel
            // 
            this.miContractDocumentCancel.Index = 4;
            this.miContractDocumentCancel.Text = "ยกเลิกสัญญา\r\n";
            this.miContractDocumentCancel.Visible = false;
            this.miContractDocumentCancel.Click += new System.EventHandler(this.miContractDocumentCancel_Click);
            // 
            // miContractDocumentServiceStaffMatchToContract
            // 
            this.miContractDocumentServiceStaffMatchToContract.Index = 5;
            this.miContractDocumentServiceStaffMatchToContract.Text = "ระบุพนักงานในสัญญา\r\n";
            this.miContractDocumentServiceStaffMatchToContract.Visible = false;
            this.miContractDocumentServiceStaffMatchToContract.Click += new System.EventHandler(this.miContractDocumentServiceStaffMatchToContract_Click);
            // 
            // miContractDocumentVDContractMatching
            // 
            this.miContractDocumentVDContractMatching.Index = 6;
            this.miContractDocumentVDContractMatching.Text = "จับคู่สัญญารถยนต์กับสัญญาพนักงานขับรถ\r\n";
            this.miContractDocumentVDContractMatching.Visible = false;
            this.miContractDocumentVDContractMatching.Click += new System.EventHandler(this.miContractDocumentVDContractMatching_Click);
            // 
            // miContractSettingCustomerChargeAdjustOtherSS
            // 
            this.miContractSettingCustomerChargeAdjustOtherSS.Index = 7;
            this.miContractSettingCustomerChargeAdjustOtherSS.Text = "ปรับปรุงยอดค่าบริการของพนักงานอื่นๆ";
            this.miContractSettingCustomerChargeAdjustOtherSS.Visible = false;
            this.miContractSettingCustomerChargeAdjustOtherSS.Click += new System.EventHandler(this.miContractSettingCustomerChargeAdjustOtherSS_Click);
            // 
            // miContractSettingCustomerChargeAdjustDriver
            // 
            this.miContractSettingCustomerChargeAdjustDriver.Index = 8;
            this.miContractSettingCustomerChargeAdjustDriver.Text = "ปรับปรุงยอดค่าบริการของพนักงานขับรถ";
            this.miContractSettingCustomerChargeAdjustDriver.Visible = false;
            this.miContractSettingCustomerChargeAdjustDriver.Click += new System.EventHandler(this.miContractSettingCustomerChargeAdjustDriver_Click);
            // 
            // miContractDocumentSpecialCharge
            // 
            this.miContractDocumentSpecialCharge.Index = 9;
            this.miContractDocumentSpecialCharge.Text = "ปรับปรุงยอดค่าโทรศัพท์, ค่าใช้จ่ายพิเศษของพนักงาน";
            this.miContractDocumentSpecialCharge.Visible = false;
            this.miContractDocumentSpecialCharge.Click += new System.EventHandler(this.miContractDocumentSpecialCharge_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 10;
            this.menuItem10.Text = "-";
            // 
            // miContractDocumentLeasingHistoryOfActiveVehicle
            // 
            this.miContractDocumentLeasingHistoryOfActiveVehicle.Index = 11;
            this.miContractDocumentLeasingHistoryOfActiveVehicle.Text = "รายงานประวัติการเช่ารถ (เฉพาะรถยนต์ปัจจุบัน)";
            this.miContractDocumentLeasingHistoryOfActiveVehicle.Visible = false;
            this.miContractDocumentLeasingHistoryOfActiveVehicle.Click += new System.EventHandler(this.miContractDocumentLeasingHistoryOfActiveVehicle_Click);
            // 
            // miContractDocumentExpiredVehicleContract
            // 
            this.miContractDocumentExpiredVehicleContract.Index = 12;
            this.miContractDocumentExpiredVehicleContract.Text = "รายงานรถหมดสัญญา(สัญญาระยะยาว)";
            this.miContractDocumentExpiredVehicleContract.Visible = false;
            this.miContractDocumentExpiredVehicleContract.Click += new System.EventHandler(this.miContractDocumentExpiredVehicleContract_Click);
            // 
            // miContractDocumentInComplete
            // 
            this.miContractDocumentInComplete.Index = 13;
            this.miContractDocumentInComplete.Text = "รายงานเอกสารสัญญาที่มีการจ่ายงานไม่สมบูรณ์";
            this.miContractDocumentInComplete.Visible = false;
            this.miContractDocumentInComplete.Click += new System.EventHandler(this.miContractDocumentInComplete_Click);
            // 
            // miContractDocumentLongTermContract
            // 
            this.miContractDocumentLongTermContract.Index = 14;
            this.miContractDocumentLongTermContract.Text = "รายงานพนักงานขับรถตามบริษัทลูกค้า(สัญญาระยะยาว)";
            this.miContractDocumentLongTermContract.Visible = false;
            this.miContractDocumentLongTermContract.Click += new System.EventHandler(this.miContractDocumentLongTermContract_Click);
            // 
            // miContractDocumentSpareDriver
            // 
            this.miContractDocumentSpareDriver.Index = 15;
            this.miContractDocumentSpareDriver.Text = "รายงานพนักงานขับรถ Spare";
            this.miContractDocumentSpareDriver.Visible = false;
            this.miContractDocumentSpareDriver.Click += new System.EventHandler(this.miContractDocumentSpareDriver_Click);
            // 
            // miContractDocumentServiceStaffContract
            // 
            this.miContractDocumentServiceStaffContract.Index = 16;
            this.miContractDocumentServiceStaffContract.Text = "รายงานเอกสารสัญญาสำหรับพนักงาน";
            this.miContractDocumentServiceStaffContract.Visible = false;
            this.miContractDocumentServiceStaffContract.Click += new System.EventHandler(this.miContractDocumentServiceStaffContract_Click);
            // 
            // miContractDocumentExpiredVehicle
            // 
            this.miContractDocumentExpiredVehicle.Index = 17;
            this.miContractDocumentExpiredVehicle.Text = "รายงานรถหมดสัญญา";
            this.miContractDocumentExpiredVehicle.Visible = false;
            this.miContractDocumentExpiredVehicle.Click += new System.EventHandler(this.miContractDocumentExpiredVehicle_Click);
            // 
            // miContractDocumentExpiredDriver
            // 
            this.miContractDocumentExpiredDriver.Index = 18;
            this.miContractDocumentExpiredDriver.Text = "รายงานพนักงานขับรถหมดสัญญา";
            this.miContractDocumentExpiredDriver.Visible = false;
            this.miContractDocumentExpiredDriver.Click += new System.EventHandler(this.miContractDocumentExpiredDriver_Click);
            // 
            // miContractDocumentCustomerSpecialCharge
            // 
            this.miContractDocumentCustomerSpecialCharge.Index = 19;
            this.miContractDocumentCustomerSpecialCharge.Text = "รายงานค่าโทรศัพท์, ค่าใช้จ่ายพิเศษของพนักงาน";
            this.miContractDocumentCustomerSpecialCharge.Visible = false;
            this.miContractDocumentCustomerSpecialCharge.Click += new System.EventHandler(this.miContractDocumentCustomerSpecialCharge_Click);
            // 
            // miContractDocumentChargeDiff
            // 
            this.miContractDocumentChargeDiff.Index = 20;
            this.miContractDocumentChargeDiff.Text = "รายงานผลต่างค่าเช่า";
            this.miContractDocumentChargeDiff.Visible = false;
            this.miContractDocumentChargeDiff.Click += new System.EventHandler(this.miContractDocumentChargeDiff_Click);
            // 
            // miContractDocumentPenaltyCharge
            // 
            this.miContractDocumentPenaltyCharge.Index = 21;
            this.miContractDocumentPenaltyCharge.Text = "Penalty Charge";
            this.miContractDocumentPenaltyCharge.Visible = false;
            this.miContractDocumentPenaltyCharge.Click += new System.EventHandler(this.miContractDocumentPenaltyCharge_Click);
            // 
            // miContractListExpectedIncomeReport
            // 
            this.miContractListExpectedIncomeReport.Index = 22;
            this.miContractListExpectedIncomeReport.Text = "รายงานรายการรถเช่า/รายได้คาดว่าจะได้รับ";
            this.miContractListExpectedIncomeReport.Click += new System.EventHandler(this.miContractListExpectedIncomeReport_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 23;
            this.menuItem22.Text = "-";
            // 
            // miContractDocumentRenewalNotice
            // 
            this.miContractDocumentRenewalNotice.Index = 24;
            this.miContractDocumentRenewalNotice.Text = "ออกจดหมายเตือนต่อสัญญา";
            this.miContractDocumentRenewalNotice.Visible = false;
            this.miContractDocumentRenewalNotice.Click += new System.EventHandler(this.miContractDocumentRenewalNotice_Click);
            // 
            // miContractDocumentDriverAgreement
            // 
            this.miContractDocumentDriverAgreement.Index = 25;
            this.miContractDocumentDriverAgreement.Text = "ออกสัญญาพนักงานขับรถ";
            this.miContractDocumentDriverAgreement.Visible = false;
            this.miContractDocumentDriverAgreement.Click += new System.EventHandler(this.miContractDocumentDriverAgreement_Click);
            // 
            // miContractDocumentCarAgreement
            // 
            this.miContractDocumentCarAgreement.Index = 26;
            this.miContractDocumentCarAgreement.Text = "ออกสัญญารถเช่า";
            this.miContractDocumentCarAgreement.Visible = false;
            this.miContractDocumentCarAgreement.Click += new System.EventHandler(this.miContractDocumentCarAgreement_Click);
            // 
            // miContractDocumentCompanyAgreement
            // 
            this.miContractDocumentCompanyAgreement.Index = 27;
            this.miContractDocumentCompanyAgreement.Text = "ออกสัญญารถเช่า (บริษัท)";
            this.miContractDocumentCompanyAgreement.Visible = false;
            this.miContractDocumentCompanyAgreement.Click += new System.EventHandler(this.miContractDocumentCompanyAgreement_Click);
            // 
            // miContractAssignmentHistory
            // 
            this.miContractAssignmentHistory.Index = 3;
            this.miContractAssignmentHistory.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miContractAssignmentHistoryVehicelAssignment,
            this.miContractAssignmentHistoryServiceStaffAssignment,
            this.miContractAssignmentHistoryVehicleSpareAssignment,
            this.menuItem14,
            this.miContractVehicleAssignmentbyPlate,
            this.miContractDriverMatchWithVehicleCheckList,
            this.miContractAssignmentHistorybyDriver});
            this.miContractAssignmentHistory.Text = "ประวัติการจ่ายงาน";
            // 
            // miContractAssignmentHistoryVehicelAssignment
            // 
            this.miContractAssignmentHistoryVehicelAssignment.Index = 0;
            this.miContractAssignmentHistoryVehicelAssignment.Text = "การจ่ายงานให้รถยนต์\r\n";
            this.miContractAssignmentHistoryVehicelAssignment.Visible = false;
            this.miContractAssignmentHistoryVehicelAssignment.Click += new System.EventHandler(this.miContractAssignmentHistoryVehicelAssignment_Click);
            // 
            // miContractAssignmentHistoryServiceStaffAssignment
            // 
            this.miContractAssignmentHistoryServiceStaffAssignment.Index = 1;
            this.miContractAssignmentHistoryServiceStaffAssignment.Text = "การจ่ายงานให้พนักงานบริการ\r\n";
            this.miContractAssignmentHistoryServiceStaffAssignment.Visible = false;
            this.miContractAssignmentHistoryServiceStaffAssignment.Click += new System.EventHandler(this.miContractAssignmentHistoryServiceStaffAssignment_Click);
            // 
            // miContractAssignmentHistoryVehicleSpareAssignment
            // 
            this.miContractAssignmentHistoryVehicleSpareAssignment.Index = 2;
            this.miContractAssignmentHistoryVehicleSpareAssignment.Text = "การจ่ายงานภายในให้รถ Spare";
            this.miContractAssignmentHistoryVehicleSpareAssignment.Visible = false;
            this.miContractAssignmentHistoryVehicleSpareAssignment.Click += new System.EventHandler(this.miContractAssignmentHistoryVehicleSpareAssignment_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "-";
            // 
            // miContractVehicleAssignmentbyPlate
            // 
            this.miContractVehicleAssignmentbyPlate.Index = 4;
            this.miContractVehicleAssignmentbyPlate.Text = "รายงานประวัติการจ่ายงานทั้งหมดของรถยนต์\r\n";
            this.miContractVehicleAssignmentbyPlate.Visible = false;
            this.miContractVehicleAssignmentbyPlate.Click += new System.EventHandler(this.miContractVehicleAssignmentbyPlate_Click);
            // 
            // miContractDriverMatchWithVehicleCheckList
            // 
            this.miContractDriverMatchWithVehicleCheckList.Index = 5;
            this.miContractDriverMatchWithVehicleCheckList.Text = "รายงานการจ่ายงานให้คนขับรถตามเลขที่สัญญา";
            this.miContractDriverMatchWithVehicleCheckList.Visible = false;
            this.miContractDriverMatchWithVehicleCheckList.Click += new System.EventHandler(this.miContractDriverMatchWithVehicleCheckList_Click);
            // 
            // miContractAssignmentHistorybyDriver
            // 
            this.miContractAssignmentHistorybyDriver.Index = 6;
            this.miContractAssignmentHistorybyDriver.Text = "รายงานประวัติการจ่ายงานทั้งหมดของพนักงานแต่ละคน ";
            this.miContractAssignmentHistorybyDriver.Visible = false;
            this.miContractAssignmentHistorybyDriver.Click += new System.EventHandler(this.miContractAssignmentHistorybyDriver_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.Text = "-";
            // 
            // miContractVehicleCharge
            // 
            this.miContractVehicleCharge.Index = 5;
            this.miContractVehicleCharge.Text = "รายงานแสดงค่าเช่ารถรายเดือน";
            this.miContractVehicleCharge.Visible = false;
            this.miContractVehicleCharge.Click += new System.EventHandler(this.miContractVehicleCharge_Click);
            // 
            // miContractVehicleMatchWithDriverCheckList
            // 
            this.miContractVehicleMatchWithDriverCheckList.Index = 6;
            this.miContractVehicleMatchWithDriverCheckList.Text = "รายงานการให้เช่ารถพร้อมพนักงานขับรถ";
            this.miContractVehicleMatchWithDriverCheckList.Visible = false;
            this.miContractVehicleMatchWithDriverCheckList.Click += new System.EventHandler(this.miContractVehicleMatchWithDriverCheckList_Click);
            // 
            // miContractVehicleMatchWithDriver
            // 
            this.miContractVehicleMatchWithDriver.Index = 7;
            this.miContractVehicleMatchWithDriver.Text = "รายงานรถพร้อมคนขับตามสถานะปัจจุบัน";
            this.miContractVehicleMatchWithDriver.Visible = false;
            this.miContractVehicleMatchWithDriver.Click += new System.EventHandler(this.miContractVehicleMatchWithDriver_Click);
            // 
            // miContractContractMatchWithDriver
            // 
            this.miContractContractMatchWithDriver.Index = 8;
            this.miContractContractMatchWithDriver.Text = "รายงานพนักงานขับรถตามสถานะปัจจุบัน";
            this.miContractContractMatchWithDriver.Visible = false;
            this.miContractContractMatchWithDriver.Click += new System.EventHandler(this.miContractContractMatchWithDriver_Click);
            // 
            // miContractNoAccidentReward
            // 
            this.miContractNoAccidentReward.Index = 9;
            this.miContractNoAccidentReward.Text = "รายงาน Name List For No Accident Reward";
            this.miContractNoAccidentReward.Visible = false;
            this.miContractNoAccidentReward.Click += new System.EventHandler(this.miContractNoAccidentReward_Click);
            // 
            // miAttendance
            // 
            this.miAttendance.Index = 5;
            this.miAttendance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAttendanceSetting,
            this.miAttendanceLeave,
            this.miAttendanceWorkingTime,
            this.miAttendanceBenefit,
            this.menuItem12,
            this.miDriverExcess,
            this.miDriverExcessDeductionByMonth,
            this.miPayrollBenefit,
            this.miNonPayrollBenefit,
            this.miAbsentRewardFamilyCarDriver,
            this.miEmployeeReceiveGold});
            this.miAttendance.Text = "ข้อมูลการปฏิบัติงาน";
            // 
            // miAttendanceSetting
            // 
            this.miAttendanceSetting.Index = 0;
            this.miAttendanceSetting.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem2});
            this.miAttendanceSetting.Text = "ตั่งค่าทั่วไป";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTraditionalHoliday,
            this.miHolidayCondition,
            this.miHolidayConditionSpecific,
            this.miDisease,
            this.miSpecialLeave,
            this.miLeaveReason,
            this.miGenAnnualLeaveDay});
            this.menuItem1.Text = "วันหยุด";
            // 
            // miTraditionalHoliday
            // 
            this.miTraditionalHoliday.Index = 0;
            this.miTraditionalHoliday.Text = "กำหนดวันหยุดนักขัตฤกษ์";
            this.miTraditionalHoliday.Visible = false;
            this.miTraditionalHoliday.Click += new System.EventHandler(this.miTraditionalHoliday_Click);
            // 
            // miHolidayCondition
            // 
            this.miHolidayCondition.Index = 1;
            this.miHolidayCondition.Text = "กำหนดเงื่อนไขวันหยุด";
            this.miHolidayCondition.Visible = false;
            this.miHolidayCondition.Click += new System.EventHandler(this.miHolidayCondition_Click);
            // 
            // miHolidayConditionSpecific
            // 
            this.miHolidayConditionSpecific.Index = 2;
            this.miHolidayConditionSpecific.Text = "กำหนดเงื่อนไขวันหยุดตามพนักงาน";
            this.miHolidayConditionSpecific.Visible = false;
            this.miHolidayConditionSpecific.Click += new System.EventHandler(this.miHolidayConditionSpecific_Click);
            // 
            // miDisease
            // 
            this.miDisease.Index = 3;
            this.miDisease.Text = "ชื่อโรค";
            this.miDisease.Visible = false;
            this.miDisease.Click += new System.EventHandler(this.miDisease_Click);
            // 
            // miSpecialLeave
            // 
            this.miSpecialLeave.Index = 4;
            this.miSpecialLeave.Text = "เหตุผลการลากิจพิเศษ";
            this.miSpecialLeave.Visible = false;
            this.miSpecialLeave.Click += new System.EventHandler(this.miSpecialLeave_Click);
            // 
            // miLeaveReason
            // 
            this.miLeaveReason.Index = 5;
            this.miLeaveReason.Text = "เหตุผลการลากิจ, พักร้อน";
            this.miLeaveReason.Visible = false;
            this.miLeaveReason.Click += new System.EventHandler(this.miLeaveReason_Click);
            // 
            // miGenAnnualLeaveDay
            // 
            this.miGenAnnualLeaveDay.Index = 6;
            this.miGenAnnualLeaveDay.Text = "สร้างวันลาพักร้อนประจำปี";
            this.miGenAnnualLeaveDay.Visible = false;
            this.miGenAnnualLeaveDay.Click += new System.EventHandler(this.miGenAnnualLeaveDay_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miWorkingTimeTable,
            this.miWorkingTimeCondition,
            this.miWorkingTimeConditionSpecific});
            this.menuItem4.Text = "เวลาทำงาน";
            // 
            // miWorkingTimeTable
            // 
            this.miWorkingTimeTable.Index = 0;
            this.miWorkingTimeTable.Text = "กำหนดรูปแบบเวลาทำงาน";
            this.miWorkingTimeTable.Visible = false;
            this.miWorkingTimeTable.Click += new System.EventHandler(this.miWorkingTimeTable_Click);
            // 
            // miWorkingTimeCondition
            // 
            this.miWorkingTimeCondition.Index = 1;
            this.miWorkingTimeCondition.Text = "กำหนดเงื่อนไขเวลาทำงาน";
            this.miWorkingTimeCondition.Visible = false;
            this.miWorkingTimeCondition.Click += new System.EventHandler(this.miWorkingTimeCondition_Click);
            // 
            // miWorkingTimeConditionSpecific
            // 
            this.miWorkingTimeConditionSpecific.Index = 2;
            this.miWorkingTimeConditionSpecific.Text = "กำนหดเงื่อนไขเวลาทำงานตามพนักงาน";
            this.miWorkingTimeConditionSpecific.Visible = false;
            this.miWorkingTimeConditionSpecific.Click += new System.EventHandler(this.miWorkingTimeConditionSpecific_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miOtherBenefitRate,
            this.miOTPattern,
            this.miOvertimeVariant,
            this.miOTPatternGeneralCondition,
            this.miOTPatternSpecificCondition,
            this.miTelephoneCondition,
            this.miTaxiCondition});
            this.menuItem2.Text = "รายได้อื่นๆ";
            // 
            // miOtherBenefitRate
            // 
            this.miOtherBenefitRate.Index = 0;
            this.miOtherBenefitRate.Text = "กำหนดอัตรารายได้อื่นๆ";
            this.miOtherBenefitRate.Visible = false;
            this.miOtherBenefitRate.Click += new System.EventHandler(this.miOtherBenefitRate_Click);
            // 
            // miOTPattern
            // 
            this.miOTPattern.Index = 1;
            this.miOTPattern.Text = "กำหนดรูปแบบค่าล่วงเวลา";
            this.miOTPattern.Visible = false;
            this.miOTPattern.Click += new System.EventHandler(this.miOTPattern_Click);
            // 
            // miOvertimeVariant
            // 
            this.miOvertimeVariant.Index = 2;
            this.miOvertimeVariant.Text = "กำหนดรูปแบบค่าล่วงเวลา - Family Car";
            this.miOvertimeVariant.Visible = false;
            this.miOvertimeVariant.Click += new System.EventHandler(this.miOvertimeVariant_Click);
            // 
            // miOTPatternGeneralCondition
            // 
            this.miOTPatternGeneralCondition.Index = 3;
            this.miOTPatternGeneralCondition.Text = "กำหนดเงื่อนไขรูปแบบค่าล่วงเวลา";
            this.miOTPatternGeneralCondition.Visible = false;
            this.miOTPatternGeneralCondition.Click += new System.EventHandler(this.miOTPatternGeneralCondition_Click);
            // 
            // miOTPatternSpecificCondition
            // 
            this.miOTPatternSpecificCondition.Index = 4;
            this.miOTPatternSpecificCondition.Text = "กำหนดเงื่อนไขรูปแบบค่าลวงเวลาตามพนักงาน";
            this.miOTPatternSpecificCondition.Visible = false;
            this.miOTPatternSpecificCondition.Click += new System.EventHandler(this.miOTPatternSpecificCondition_Click);
            // 
            // miTelephoneCondition
            // 
            this.miTelephoneCondition.Index = 5;
            this.miTelephoneCondition.Text = "กำหนดเงื่อนไขค่าโทรศัพท์";
            this.miTelephoneCondition.Visible = false;
            this.miTelephoneCondition.Click += new System.EventHandler(this.miTelephoneCondition_Click);
            // 
            // miTaxiCondition
            // 
            this.miTaxiCondition.Index = 6;
            this.miTaxiCondition.Text = "กำหนดเงื่อนไขค่า Taxi";
            this.miTaxiCondition.Visible = false;
            this.miTaxiCondition.Click += new System.EventHandler(this.miTaxiCondition_Click);
            // 
            // miAttendanceLeave
            // 
            this.miAttendanceLeave.Index = 1;
            this.miAttendanceLeave.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miEmployeeSickLeave,
            this.miEmployeePrivateLeave,
            this.miEmployeeSpecialLeave,
            this.miAttEmpAnnualLeave,
            this.miAttendanceSaleAnnualLeave,
            this.menuItem16,
            this.miLeaveReport,
            this.miAttendanceLeaveSickLeaveReport,
            this.miAttendanceLeavePrivateLeaveReport,
            this.miAttendanceLeaveSpecialLeaveReport,
            this.miAttendanceLeaveAnnualLeaveReport,
            this.miAttendanceLeaveEmployeeLeaveReport});
            this.miAttendanceLeave.Text = "วันหยุด";
            // 
            // miEmployeeSickLeave
            // 
            this.miEmployeeSickLeave.Index = 0;
            this.miEmployeeSickLeave.Text = "ข้อมูลการลาป่วย";
            this.miEmployeeSickLeave.Visible = false;
            this.miEmployeeSickLeave.Click += new System.EventHandler(this.miEmployeeSickLeave_Click);
            // 
            // miEmployeePrivateLeave
            // 
            this.miEmployeePrivateLeave.Index = 1;
            this.miEmployeePrivateLeave.Text = "ข้อมูลการลากิจ";
            this.miEmployeePrivateLeave.Visible = false;
            this.miEmployeePrivateLeave.Click += new System.EventHandler(this.miEmployeePrivateLeave_Click);
            // 
            // miEmployeeSpecialLeave
            // 
            this.miEmployeeSpecialLeave.Index = 2;
            this.miEmployeeSpecialLeave.Text = "ข้อมูลการลากิจพิเศษ";
            this.miEmployeeSpecialLeave.Visible = false;
            this.miEmployeeSpecialLeave.Click += new System.EventHandler(this.miEmployeeSpecialLeave_Click);
            // 
            // miAttEmpAnnualLeave
            // 
            this.miAttEmpAnnualLeave.Index = 3;
            this.miAttEmpAnnualLeave.Text = "ข้อมูลการลาพักร้อนประจำปี";
            this.miAttEmpAnnualLeave.Visible = false;
            this.miAttEmpAnnualLeave.Click += new System.EventHandler(this.miAttEmpAnnualLeave_Click);
            // 
            // miAttendanceSaleAnnualLeave
            // 
            this.miAttendanceSaleAnnualLeave.Index = 4;
            this.miAttendanceSaleAnnualLeave.Text = "ข้อมูลการขายวันหยุดพักร้อน";
            this.miAttendanceSaleAnnualLeave.Visible = false;
            this.miAttendanceSaleAnnualLeave.Click += new System.EventHandler(this.miAttendanceSaleAnnualLeave_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 5;
            this.menuItem16.Text = "-";
            // 
            // miLeaveReport
            // 
            this.miLeaveReport.Index = 6;
            this.miLeaveReport.Text = "รายงานการลา รายเดือน";
            this.miLeaveReport.Visible = false;
            this.miLeaveReport.Click += new System.EventHandler(this.miLeaveReport_Click);
            // 
            // miAttendanceLeaveSickLeaveReport
            // 
            this.miAttendanceLeaveSickLeaveReport.Index = 7;
            this.miAttendanceLeaveSickLeaveReport.Text = "รายงานการลาป่วย รายเดือน";
            this.miAttendanceLeaveSickLeaveReport.Visible = false;
            this.miAttendanceLeaveSickLeaveReport.Click += new System.EventHandler(this.miAttendanceLeaveSickLeaveReport_Click);
            // 
            // miAttendanceLeavePrivateLeaveReport
            // 
            this.miAttendanceLeavePrivateLeaveReport.Index = 8;
            this.miAttendanceLeavePrivateLeaveReport.Text = "รายงานการลากิจ รายเดือน";
            this.miAttendanceLeavePrivateLeaveReport.Visible = false;
            this.miAttendanceLeavePrivateLeaveReport.Click += new System.EventHandler(this.miAttendanceLeavePrivateLeaveReport_Click);
            // 
            // miAttendanceLeaveSpecialLeaveReport
            // 
            this.miAttendanceLeaveSpecialLeaveReport.Index = 9;
            this.miAttendanceLeaveSpecialLeaveReport.Text = "รายงานการลากิจพิเศษ รายเดือน";
            this.miAttendanceLeaveSpecialLeaveReport.Visible = false;
            this.miAttendanceLeaveSpecialLeaveReport.Click += new System.EventHandler(this.miAttendanceLeaveSpecialLeaveReport_Click);
            // 
            // miAttendanceLeaveAnnualLeaveReport
            // 
            this.miAttendanceLeaveAnnualLeaveReport.Index = 10;
            this.miAttendanceLeaveAnnualLeaveReport.Text = "รายงานการลาพักร้อน รายเดือน";
            this.miAttendanceLeaveAnnualLeaveReport.Visible = false;
            this.miAttendanceLeaveAnnualLeaveReport.Click += new System.EventHandler(this.miAttendanceLeaveAnnualLeaveReport_Click);
            // 
            // miAttendanceLeaveEmployeeLeaveReport
            // 
            this.miAttendanceLeaveEmployeeLeaveReport.Index = 11;
            this.miAttendanceLeaveEmployeeLeaveReport.Text = "รายงานการลา รายปี";
            this.miAttendanceLeaveEmployeeLeaveReport.Click += new System.EventHandler(this.miAttendanceLeaveEmployeeLeaveReport_Click);
            // 
            // miAttendanceWorkingTime
            // 
            this.miAttendanceWorkingTime.Index = 2;
            this.miAttendanceWorkingTime.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miGenEmployeeWorkSchedule,
            this.miEmployeeWorkSchedule});
            this.miAttendanceWorkingTime.Text = "เวลาทำงาน";
            // 
            // miGenEmployeeWorkSchedule
            // 
            this.miGenEmployeeWorkSchedule.Index = 0;
            this.miGenEmployeeWorkSchedule.Text = "สร้างตารางเวลาทำงานประจำเดือน";
            this.miGenEmployeeWorkSchedule.Visible = false;
            this.miGenEmployeeWorkSchedule.Click += new System.EventHandler(this.miGenEmployeeWorkSchedule_Click);
            // 
            // miEmployeeWorkSchedule
            // 
            this.miEmployeeWorkSchedule.Index = 1;
            this.miEmployeeWorkSchedule.Text = "ตารางเวลาทำงานสำหรับพนักงาน";
            this.miEmployeeWorkSchedule.Visible = false;
            this.miEmployeeWorkSchedule.Click += new System.EventHandler(this.miEmployeeWorkSchedule_Click);
            // 
            // miAttendanceBenefit
            // 
            this.miAttendanceBenefit.Index = 3;
            this.miAttendanceBenefit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miEmployeeTelephoneBenefit,
            this.miEmployeeFoodBenefit,
            this.miEmployeeExtraBenefit,
            this.miEmployeeMiscBenefit,
            this.miEmployeeMiscDeducttion,
            this.miAttendanceEmployeeBenefit,
            this.miBenefitAdjustment,
            this.miGenerateOtherBenefit,
            this.miGenerateMealBenefit,
            this.miEmployeeExtraAGTBenefit,
            this.menuItem13,
            this.miTimeRecordOfDriver,
            this.miTimeCardForCharge,
            this.miTimeCardForPayment,
            this.miEmployeeOverNightTripBenefit});
            this.miAttendanceBenefit.Text = "รายได้อื่นๆ";
            // 
            // miEmployeeTelephoneBenefit
            // 
            this.miEmployeeTelephoneBenefit.Index = 0;
            this.miEmployeeTelephoneBenefit.Text = "ค่าโทรศัพท์ตามพนักงาน";
            this.miEmployeeTelephoneBenefit.Visible = false;
            this.miEmployeeTelephoneBenefit.Click += new System.EventHandler(this.miEmployeeTelephoneBenefit_Click);
            // 
            // miEmployeeFoodBenefit
            // 
            this.miEmployeeFoodBenefit.Index = 1;
            this.miEmployeeFoodBenefit.Text = "ค่าอาหารตามพนักงาน";
            this.miEmployeeFoodBenefit.Visible = false;
            this.miEmployeeFoodBenefit.Click += new System.EventHandler(this.miEmployeeFoodBenefit_Click);
            // 
            // miEmployeeExtraBenefit
            // 
            this.miEmployeeExtraBenefit.Index = 2;
            this.miEmployeeExtraBenefit.Text = "ค่าเบี้ยขยันตามพนักงาน";
            this.miEmployeeExtraBenefit.Visible = false;
            this.miEmployeeExtraBenefit.Click += new System.EventHandler(this.miEmployeeExtraBenefit_Click);
            // 
            // miEmployeeMiscBenefit
            // 
            this.miEmployeeMiscBenefit.Index = 3;
            this.miEmployeeMiscBenefit.Text = "รายได้อื่นๆ ตามพนักงาน";
            this.miEmployeeMiscBenefit.Visible = false;
            this.miEmployeeMiscBenefit.Click += new System.EventHandler(this.miEmployeeMiscBenefit_Click);
            // 
            // miEmployeeMiscDeducttion
            // 
            this.miEmployeeMiscDeducttion.Index = 4;
            this.miEmployeeMiscDeducttion.Text = "รายการหักเงินตามพนักงาน";
            this.miEmployeeMiscDeducttion.Visible = false;
            this.miEmployeeMiscDeducttion.Click += new System.EventHandler(this.miEmployeeMiscDeducttion_Click);
            // 
            // miAttendanceEmployeeBenefit
            // 
            this.miAttendanceEmployeeBenefit.Index = 5;
            this.miAttendanceEmployeeBenefit.Text = "OT, Taxi, Trip ตามพนักงาน";
            this.miAttendanceEmployeeBenefit.Visible = false;
            this.miAttendanceEmployeeBenefit.Click += new System.EventHandler(this.miAttendanceEmployeeBenefit_Click);
            // 
            // miBenefitAdjustment
            // 
            this.miBenefitAdjustment.Index = 6;
            this.miBenefitAdjustment.Text = "เงินขาดเงินเกินตามพนักงาน";
            this.miBenefitAdjustment.Visible = false;
            this.miBenefitAdjustment.Click += new System.EventHandler(this.miBenefitAdjustment_Click);
            // 
            // miGenerateOtherBenefit
            // 
            this.miGenerateOtherBenefit.Index = 7;
            this.miGenerateOtherBenefit.Text = "คำนวณค่าเบี้ยขยัน, ค่าโทรศัพท์";
            this.miGenerateOtherBenefit.Visible = false;
            this.miGenerateOtherBenefit.Click += new System.EventHandler(this.miGenerateOtherBenefit_Click);
            // 
            // miGenerateMealBenefit
            // 
            this.miGenerateMealBenefit.Index = 8;
            this.miGenerateMealBenefit.Text = "คำนวณค่า Meal Allowance";
            this.miGenerateMealBenefit.Visible = false;
            this.miGenerateMealBenefit.Click += new System.EventHandler(this.miMealAllowance_Click);
            // 
            // miEmployeeExtraAGTBenefit
            // 
            this.miEmployeeExtraAGTBenefit.Index = 9;
            this.miEmployeeExtraAGTBenefit.Text = "EmployeeExtraAGTBenefit";
            this.miEmployeeExtraAGTBenefit.Visible = false;
            this.miEmployeeExtraAGTBenefit.Click += new System.EventHandler(this.miEmployeeExtraAGTBenefit_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 10;
            this.menuItem13.Text = "-";
            // 
            // miTimeRecordOfDriver
            // 
            this.miTimeRecordOfDriver.Index = 11;
            this.miTimeRecordOfDriver.Text = "รายงาน Time Record Of Driver";
            this.miTimeRecordOfDriver.Visible = false;
            this.miTimeRecordOfDriver.Click += new System.EventHandler(this.miTimeRecordOfDriver_Click);
            // 
            // miTimeCardForCharge
            // 
            this.miTimeCardForCharge.Index = 12;
            this.miTimeCardForCharge.Text = "รายงาน Time Card For Charge";
            this.miTimeCardForCharge.Visible = false;
            this.miTimeCardForCharge.Click += new System.EventHandler(this.miTimeCardForCharge_Click);
            // 
            // miTimeCardForPayment
            // 
            this.miTimeCardForPayment.Index = 13;
            this.miTimeCardForPayment.Text = "รายงาน Time Card For Payment";
            this.miTimeCardForPayment.Visible = false;
            this.miTimeCardForPayment.Click += new System.EventHandler(this.miTimeCardForPayment_Click);
            // 
            // miEmployeeOverNightTripBenefit
            // 
            this.miEmployeeOverNightTripBenefit.Index = 14;
            this.miEmployeeOverNightTripBenefit.Text = "รายงาน Employee OverNight Trip Benefit";
            this.miEmployeeOverNightTripBenefit.Click += new System.EventHandler(this.miEmployeeOverNightTripBenefit_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 4;
            this.menuItem12.Text = "-";
            // 
            // miDriverExcess
            // 
            this.miDriverExcess.Index = 5;
            this.miDriverExcess.Text = "รายงานการหัก ค่า Excess";
            this.miDriverExcess.Visible = false;
            this.miDriverExcess.Click += new System.EventHandler(this.miDriverExcess_Click);
            // 
            // miDriverExcessDeductionByMonth
            // 
            this.miDriverExcessDeductionByMonth.Index = 6;
            this.miDriverExcessDeductionByMonth.Text = "รายงานการหัก ค่า Excess ประจำเดือน";
            this.miDriverExcessDeductionByMonth.Visible = false;
            this.miDriverExcessDeductionByMonth.Click += new System.EventHandler(this.miDriverExcessDeductionByMonth_Click);
            // 
            // miPayrollBenefit
            // 
            this.miPayrollBenefit.Index = 7;
            this.miPayrollBenefit.Text = "รายงาน PayrollBenefit";
            this.miPayrollBenefit.Visible = false;
            this.miPayrollBenefit.Click += new System.EventHandler(this.miPayrollBenefit_Click);
            // 
            // miNonPayrollBenefit
            // 
            this.miNonPayrollBenefit.Index = 8;
            this.miNonPayrollBenefit.Text = "รายงาน NonPayrollBenefit";
            this.miNonPayrollBenefit.Visible = false;
            this.miNonPayrollBenefit.Click += new System.EventHandler(this.miNonPayrollBenefit_Click);
            // 
            // miAbsentRewardFamilyCarDriver
            // 
            this.miAbsentRewardFamilyCarDriver.Index = 9;
            this.miAbsentRewardFamilyCarDriver.Text = "รายงานเบี้ยขยัน";
            this.miAbsentRewardFamilyCarDriver.Visible = false;
            this.miAbsentRewardFamilyCarDriver.Click += new System.EventHandler(this.miAbsentRewardFamilyCarDriver_Click);
            // 
            // miEmployeeReceiveGold
            // 
            this.miEmployeeReceiveGold.Index = 10;
            this.miEmployeeReceiveGold.Text = "รายงานรายชื่อพนักงานผู้มีสิทธิ์ได้รับทอง";
            this.miEmployeeReceiveGold.Visible = false;
            this.miEmployeeReceiveGold.Click += new System.EventHandler(this.miEmployeeReceiveGold_Click);
            // 
            // miSAPConnect
            // 
            this.miSAPConnect.Index = 6;
            this.miSAPConnect.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBPWelfare,
            this.miSAPVehicleDocument,
            this.miBPMaintenance,
            this.miBPContract});
            this.miSAPConnect.Text = "ถ่ายโอนข้อมูลเข้า SAP";
            // 
            // miBPWelfare
            // 
            this.miBPWelfare.Index = 0;
            this.miBPWelfare.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBizPacConnectLoan,
            this.miBizPacConnectContribution,
            this.miBizPacConnectContributionN,
            this.miBizPacConnectMedicalAid,
            this.miBizPacConnectMedicalAidNoAtt,
            this.menuItem21,
            this.miBizPacCancelLoan,
            this.miBizPacCancelContribution,
            this.miBizPacCancelMedicalAid});
            this.miBPWelfare.Text = "ถ่ายโอนข้อมูล สวัสดิการ";
            // 
            // miBizPacConnectLoan
            // 
            this.miBizPacConnectLoan.Index = 0;
            this.miBizPacConnectLoan.Text = "ถ่ายโอนข้อมูล เงินกู้";
            this.miBizPacConnectLoan.Click += new System.EventHandler(this.miBizPacConnectLoan_Click);
            // 
            // miBizPacConnectContribution
            // 
            this.miBizPacConnectContribution.Index = 1;
            this.miBizPacConnectContribution.Text = "ถ่ายโอนข้อมูลเงินช่วยเหลือแบบเข้าบัญชี";
            this.miBizPacConnectContribution.Click += new System.EventHandler(this.miBizPacConnectContribution_Click);
            // 
            // miBizPacConnectContributionN
            // 
            this.miBizPacConnectContributionN.Index = 2;
            this.miBizPacConnectContributionN.Text = "ถ่ายโอนข้อมูลเงินช่วยเหลือแบบไม่เข้าบัญชี";
            this.miBizPacConnectContributionN.Click += new System.EventHandler(this.miBizPacConnectContributionN_Click);
            // 
            // miBizPacConnectMedicalAid
            // 
            this.miBizPacConnectMedicalAid.Index = 3;
            this.miBizPacConnectMedicalAid.Text = "ถ่ายโอนข้อมูลค่ารักษาพยาบาล (มีใบส่งตัว)";
            this.miBizPacConnectMedicalAid.Click += new System.EventHandler(this.miBizPacConnectMedicalAid_Click);
            // 
            // miBizPacConnectMedicalAidNoAtt
            // 
            this.miBizPacConnectMedicalAidNoAtt.Index = 4;
            this.miBizPacConnectMedicalAidNoAtt.Text = "ถ่ายโอนข้อมูลค่ารักษาพยาบาล (ไม่มีใบส่งตัว)";
            this.miBizPacConnectMedicalAidNoAtt.Click += new System.EventHandler(this.miBizPacConnectMedicalAidNoAtt_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 5;
            this.menuItem21.Text = "-";
            // 
            // miBizPacCancelLoan
            // 
            this.miBizPacCancelLoan.Index = 6;
            this.miBizPacCancelLoan.Text = "ยกเลิกถ่ายโอนข้อมูล เงินกู้";
            this.miBizPacCancelLoan.Click += new System.EventHandler(this.miBizPacCancelLoan_Click);
            // 
            // miBizPacCancelContribution
            // 
            this.miBizPacCancelContribution.Index = 7;
            this.miBizPacCancelContribution.Text = "ยกเลิกถ่ายโอนข้อมูลเงินช่วยเหลือ";
            this.miBizPacCancelContribution.Click += new System.EventHandler(this.miBizPacCancelContribution_Click);
            // 
            // miBizPacCancelMedicalAid
            // 
            this.miBizPacCancelMedicalAid.Index = 8;
            this.miBizPacCancelMedicalAid.Text = "ยกเลิกถ่ายโอนข้อมูลค่ารักษาพยาบาล";
            this.miBizPacCancelMedicalAid.Click += new System.EventHandler(this.miBizPacCancelMedicalAid_Click);
            // 
            // miSAPVehicleDocument
            // 
            this.miSAPVehicleDocument.Index = 1;
            this.miSAPVehicleDocument.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBPPreConnectCompulsory,
            this.miBPConnectCompulsoryInsurance,
            this.miBPPreConnectInsurance,
            this.miBizPacConnectInsuranceTypeOne,
            this.menuItem30,
            this.miBizPacCancelCompulsoryInsurance,
            this.miBizPacCancelInsuranceTypeOne});
            this.miSAPVehicleDocument.Text = "ถ่ายโอนข้อมูล เอกสารรถยนต์";
            // 
            // miBPPreConnectCompulsory
            // 
            this.miBPPreConnectCompulsory.Index = 0;
            this.miBPPreConnectCompulsory.Text = "ทดสอบถ่ายโอนข้อมูล พรบ.";
            this.miBPPreConnectCompulsory.Click += new System.EventHandler(this.miSAPPreConnectCompulsory_Click);
            // 
            // miBPConnectCompulsoryInsurance
            // 
            this.miBPConnectCompulsoryInsurance.Index = 1;
            this.miBPConnectCompulsoryInsurance.Text = "ถ่ายโอนข้อมูล พรบ.";
            this.miBPConnectCompulsoryInsurance.Visible = false;
            this.miBPConnectCompulsoryInsurance.Click += new System.EventHandler(this.miSAPConnectCompulsoryInsurance_Click);
            // 
            // miBPPreConnectInsurance
            // 
            this.miBPPreConnectInsurance.Index = 2;
            this.miBPPreConnectInsurance.Text = "ทดสอบถ่ายโอนข้อมูล ประกันภัยชั้นหนึ่ง";
            this.miBPPreConnectInsurance.Click += new System.EventHandler(this.miBPPreConnectInsurance_Click);
            // 
            // miBizPacConnectInsuranceTypeOne
            // 
            this.miBizPacConnectInsuranceTypeOne.Index = 3;
            this.miBizPacConnectInsuranceTypeOne.Text = "ถ่ายโอนข้อมูล ประกันภัยชั้นหนึ่ง";
            this.miBizPacConnectInsuranceTypeOne.Visible = false;
            this.miBizPacConnectInsuranceTypeOne.Click += new System.EventHandler(this.miBizPacConnectInsuranceTypeOne_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 4;
            this.menuItem30.Text = "-";
            // 
            // miBizPacCancelCompulsoryInsurance
            // 
            this.miBizPacCancelCompulsoryInsurance.Index = 5;
            this.miBizPacCancelCompulsoryInsurance.Text = "ยกเลิกถ่ายโอนข้อมูล พรบ.";
            this.miBizPacCancelCompulsoryInsurance.Click += new System.EventHandler(this.miBizPacCancelCompulsoryInsurance_Click);
            // 
            // miBizPacCancelInsuranceTypeOne
            // 
            this.miBizPacCancelInsuranceTypeOne.Index = 6;
            this.miBizPacCancelInsuranceTypeOne.Text = "ยกเลิกถ่ายโอนข้อมูล ประกันภัยชั้นหนึ่ง";
            this.miBizPacCancelInsuranceTypeOne.Click += new System.EventHandler(this.miBizPacCancelInsuranceTypeOne_Click);
            // 
            // miBPMaintenance
            // 
            this.miBPMaintenance.Index = 2;
            this.miBPMaintenance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBPPreConnectVehicleRepairing,
            this.miBizPacConnectVehicleRepairing,
            this.miBPPreConnectVehicleExcess,
            this.miBizPacConnectVehicleExcess,
            this.menuItem25,
            this.miBizPacCancelVehicleRepairing,
            this.miBizPacCancelVehicleExcess});
            this.miBPMaintenance.Text = "ถ่ายโอนข้อมูล ค่าซ่อม และ ค่า Excess";
            // 
            // miBPPreConnectVehicleRepairing
            // 
            this.miBPPreConnectVehicleRepairing.Index = 0;
            this.miBPPreConnectVehicleRepairing.Text = "ทดสอบถ่ายโอนข้อมูล ค่าซ่อม";
            this.miBPPreConnectVehicleRepairing.Click += new System.EventHandler(this.miBPPreConnectVehicleRepairing_Click);
            // 
            // miBizPacConnectVehicleRepairing
            // 
            this.miBizPacConnectVehicleRepairing.Index = 1;
            this.miBizPacConnectVehicleRepairing.Text = "ถ่ายโอนข้อมูล ค่าซ่อม";
            this.miBizPacConnectVehicleRepairing.Visible = false;
            this.miBizPacConnectVehicleRepairing.Click += new System.EventHandler(this.miBizPacConnectVehicleRepairing_Click);
            // 
            // miBPPreConnectVehicleExcess
            // 
            this.miBPPreConnectVehicleExcess.Index = 2;
            this.miBPPreConnectVehicleExcess.Text = "ทดสอบถ่ายโอนข้อมูล ค่า Excess";
            this.miBPPreConnectVehicleExcess.Click += new System.EventHandler(this.miBPPreConnectVehicleExcess_Click);
            // 
            // miBizPacConnectVehicleExcess
            // 
            this.miBizPacConnectVehicleExcess.Index = 3;
            this.miBizPacConnectVehicleExcess.Text = "ถ่ายโอนข้อมูล ค่า Excess";
            this.miBizPacConnectVehicleExcess.Visible = false;
            this.miBizPacConnectVehicleExcess.Click += new System.EventHandler(this.miBizPacConnectVehicleExcess_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 4;
            this.menuItem25.Text = "-";
            // 
            // miBizPacCancelVehicleRepairing
            // 
            this.miBizPacCancelVehicleRepairing.Index = 5;
            this.miBizPacCancelVehicleRepairing.Text = "ยกเลิกถ่ายโอนข้อมูล ค่าซ่อม";
            this.miBizPacCancelVehicleRepairing.Click += new System.EventHandler(this.miBizPacCancelVehicleRepairing_Click);
            // 
            // miBizPacCancelVehicleExcess
            // 
            this.miBizPacCancelVehicleExcess.Index = 6;
            this.miBizPacCancelVehicleExcess.Text = "ยกเลิกถ่ายโอนข้อมูล ค่า Excess";
            this.miBizPacCancelVehicleExcess.Click += new System.EventHandler(this.miBizPacCancelVehicleExcess_Click);
            // 
            // miBPContract
            // 
            this.miBPContract.Index = 3;
            this.miBPContract.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBPPreConnectVehicleCharge,
            this.miBizPacConnectVehicleContractCharge,
            this.miBPPreConnectDriverCharge,
            this.miBizPacConnectDriverContractCharge,
            this.miBPPreConnectOfficeCharge,
            this.miBizPacConnectServiceStaffContractCharge,
            this.menuItem18,
            this.miBizPacConnectVehicleCancelCharge,
            this.miBizPacCancelDriverContractCharge,
            this.miBizPacCancelServiceStaffContractCharge,
            this.menuItem27,
            this.miBPRerunVehicleCharge,
            this.miBPRerunDriverCharge,
            this.miBPRerunOtherSSCharge});
            this.miBPContract.Text = "ถ่ายโอนข้อมูล รายได้ค่าเช่า";
            // 
            // miBPPreConnectVehicleCharge
            // 
            this.miBPPreConnectVehicleCharge.Index = 0;
            this.miBPPreConnectVehicleCharge.Text = "ทดสอบถ่ายโอนข้อมูล ค่าเช่ารถยนต์";
            this.miBPPreConnectVehicleCharge.Visible = false;
            this.miBPPreConnectVehicleCharge.Click += new System.EventHandler(this.miBPPreConnectVehicleCharge_Click);
            // 
            // miBizPacConnectVehicleContractCharge
            // 
            this.miBizPacConnectVehicleContractCharge.Index = 1;
            this.miBizPacConnectVehicleContractCharge.Text = "ถ่ายโอนข้อมูล ค่าเช่ารถยนต์";
            this.miBizPacConnectVehicleContractCharge.Visible = false;
            this.miBizPacConnectVehicleContractCharge.Click += new System.EventHandler(this.miBizPacConnectVehicleContractCharge_Click);
            // 
            // miBPPreConnectDriverCharge
            // 
            this.miBPPreConnectDriverCharge.Index = 2;
            this.miBPPreConnectDriverCharge.Text = "ทดสอบถ่ายโอนข้อมูล ค่าเช่าพนักงานขับรถ";
            this.miBPPreConnectDriverCharge.Visible = false;
            this.miBPPreConnectDriverCharge.Click += new System.EventHandler(this.miBPPreConnectDriverCharge_Click);
            // 
            // miBizPacConnectDriverContractCharge
            // 
            this.miBizPacConnectDriverContractCharge.Index = 3;
            this.miBizPacConnectDriverContractCharge.Text = "ถ่ายโอนข้อมูล ค่าเช่าพนักงานขับรถ";
            this.miBizPacConnectDriverContractCharge.Visible = false;
            this.miBizPacConnectDriverContractCharge.Click += new System.EventHandler(this.miBizPacConnectDriverContractCharge_Click);
            // 
            // miBPPreConnectOfficeCharge
            // 
            this.miBPPreConnectOfficeCharge.Enabled = false;
            this.miBPPreConnectOfficeCharge.Index = 4;
            this.miBPPreConnectOfficeCharge.ShowShortcut = false;
            this.miBPPreConnectOfficeCharge.Text = "ทดสอบถ่ายโอนข้อมูล ค่าเช่าพนักงานบริการอื่นๆ";
            this.miBPPreConnectOfficeCharge.Visible = false;
            this.miBPPreConnectOfficeCharge.Click += new System.EventHandler(this.miBPPreConnectOfficeCharge_Click);
            // 
            // miBizPacConnectServiceStaffContractCharge
            // 
            this.miBizPacConnectServiceStaffContractCharge.Enabled = false;
            this.miBizPacConnectServiceStaffContractCharge.Index = 5;
            this.miBizPacConnectServiceStaffContractCharge.ShowShortcut = false;
            this.miBizPacConnectServiceStaffContractCharge.Text = "ถ่ายโอนข้อมูล ค่าเช่าพนักงานบริการอื่นๆ";
            this.miBizPacConnectServiceStaffContractCharge.Visible = false;
            this.miBizPacConnectServiceStaffContractCharge.Click += new System.EventHandler(this.miBizPacConnectServiceStaffContractCharge_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 6;
            this.menuItem18.Text = "-";
            // 
            // miBizPacConnectVehicleCancelCharge
            // 
            this.miBizPacConnectVehicleCancelCharge.Index = 7;
            this.miBizPacConnectVehicleCancelCharge.Text = "ยกเลิกถ่ายโอนข้อมูล ค่าเช่ารถยนต์";
            this.miBizPacConnectVehicleCancelCharge.Click += new System.EventHandler(this.miBizPacConnectVehicleCancelCharge_Click);
            // 
            // miBizPacCancelDriverContractCharge
            // 
            this.miBizPacCancelDriverContractCharge.Index = 8;
            this.miBizPacCancelDriverContractCharge.Text = "ยกเลิกถ่ายโอนข้อมูล ค่าเช่าพนักงานขับรถ";
            this.miBizPacCancelDriverContractCharge.Click += new System.EventHandler(this.miBizPacCancelDriverContractCharge_Click);
            // 
            // miBizPacCancelServiceStaffContractCharge
            // 
            this.miBizPacCancelServiceStaffContractCharge.Enabled = false;
            this.miBizPacCancelServiceStaffContractCharge.Index = 9;
            this.miBizPacCancelServiceStaffContractCharge.ShowShortcut = false;
            this.miBizPacCancelServiceStaffContractCharge.Text = "ยกเลิกถ่ายโอนข้อมูล ค่าเช่าพนักงานบริการอื่นๆ";
            this.miBizPacCancelServiceStaffContractCharge.Visible = false;
            this.miBizPacCancelServiceStaffContractCharge.Click += new System.EventHandler(this.miBizPacCancelServiceStaffContractCharge_Click);
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 10;
            this.menuItem27.Text = "-";
            // 
            // miBPRerunVehicleCharge
            // 
            this.miBPRerunVehicleCharge.Index = 11;
            this.miBPRerunVehicleCharge.Text = "รายงานสรุปการถ่ายโอนข้อมูล ค่าเช่ารถยนต์";
            this.miBPRerunVehicleCharge.Visible = false;
            this.miBPRerunVehicleCharge.Click += new System.EventHandler(this.miBPRerunVehicleCharge_Click);
            // 
            // miBPRerunDriverCharge
            // 
            this.miBPRerunDriverCharge.Index = 12;
            this.miBPRerunDriverCharge.Text = "รายงานสรุปการถ่ายโอนข้อมูล ค่าเช่าพนักงานขับรถ";
            this.miBPRerunDriverCharge.Visible = false;
            this.miBPRerunDriverCharge.Click += new System.EventHandler(this.miBPRerunDriverCharge_Click);
            // 
            // miBPRerunOtherSSCharge
            // 
            this.miBPRerunOtherSSCharge.Enabled = false;
            this.miBPRerunOtherSSCharge.Index = 13;
            this.miBPRerunOtherSSCharge.ShowShortcut = false;
            this.miBPRerunOtherSSCharge.Text = "รายงานสรุปการถ่ายโอนข้อมูล ค่าเช่าพนักงานบริการอื่นๆ";
            this.miBPRerunOtherSSCharge.Visible = false;
            this.miBPRerunOtherSSCharge.Click += new System.EventHandler(this.miBPRerunOtherSSCharge_Click);
            // 
            // miBatchProcess
            // 
            this.miBatchProcess.Index = 7;
            this.miBatchProcess.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBatchProcessDaily,
            this.miBatchProcessMonthly,
            this.miBatchProcessYearly});
            this.miBatchProcess.Text = "การจัดการข้อมูลตามช่วงเวลา";
            // 
            // miBatchProcessDaily
            // 
            this.miBatchProcessDaily.Index = 0;
            this.miBatchProcessDaily.Text = "การจัดการข้อมูลรายวัน";
            this.miBatchProcessDaily.Visible = false;
            this.miBatchProcessDaily.Click += new System.EventHandler(this.miBatchProcessDaily_Click);
            // 
            // miBatchProcessMonthly
            // 
            this.miBatchProcessMonthly.Index = 1;
            this.miBatchProcessMonthly.Text = "การจัดการข้อมูลรายเดือน";
            this.miBatchProcessMonthly.Visible = false;
            this.miBatchProcessMonthly.Click += new System.EventHandler(this.miBatchProcessMonthly_Click);
            // 
            // miBatchProcessYearly
            // 
            this.miBatchProcessYearly.Index = 2;
            this.miBatchProcessYearly.Text = "การจัดการข้อมูลรายปี";
            this.miBatchProcessYearly.Visible = false;
            this.miBatchProcessYearly.Click += new System.EventHandler(this.miBatchProcessYearly_Click);
            // 
            // miConfig
            // 
            this.miConfig.Index = 8;
            this.miConfig.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mimiConfigPassword,
            this.miConfigAdmin,
            this.miConfigSystemTable});
            this.miConfig.Text = "เปลี่ยนแปลงข้อมูลในการใช้ระบบ";
            // 
            // mimiConfigPassword
            // 
            this.mimiConfigPassword.Index = 0;
            this.mimiConfigPassword.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miConfigChangePassword,
            this.miConfigLogIn});
            this.mimiConfigPassword.Text = "รหัสผ่าน";
            // 
            // miConfigChangePassword
            // 
            this.miConfigChangePassword.Index = 0;
            this.miConfigChangePassword.Text = "เปลี่ยนรหัสผ่าน";
            this.miConfigChangePassword.Click += new System.EventHandler(this.miConfigChangePassword_Click);
            // 
            // miConfigLogIn
            // 
            this.miConfigLogIn.Index = 1;
            this.miConfigLogIn.Text = "LogIn";
            this.miConfigLogIn.Visible = false;
            this.miConfigLogIn.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // miConfigAdmin
            // 
            this.miConfigAdmin.Index = 1;
            this.miConfigAdmin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miConfigUser,
            this.miConfigPermission,
            this.menuItem9,
            this.miConfigApplicationFunctionPermission});
            this.miConfigAdmin.Text = "การดูแลระบบ";
            this.miConfigAdmin.Visible = false;
            // 
            // miConfigUser
            // 
            this.miConfigUser.Index = 0;
            this.miConfigUser.Text = "ข้อมูลผู้ใช้ระบบ\r\n";
            this.miConfigUser.Click += new System.EventHandler(this.mimiConfigUser_Click);
            // 
            // miConfigPermission
            // 
            this.miConfigPermission.Index = 1;
            this.miConfigPermission.Text = "สิทธิในการใช้ระบบ\r\n";
            this.miConfigPermission.Click += new System.EventHandler(this.mimiConfigPermission_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // miConfigApplicationFunctionPermission
            // 
            this.miConfigApplicationFunctionPermission.Index = 3;
            this.miConfigApplicationFunctionPermission.Text = "รายงานสิทธิ์การใช้ระบบ";
            this.miConfigApplicationFunctionPermission.Click += new System.EventHandler(this.miConfigApplicationFunctionPermission_Click);
            // 
            // miConfigSystemTable
            // 
            this.miConfigSystemTable.Index = 2;
            this.miConfigSystemTable.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miConfigPI,
            this.miConfigVehicle,
            this.miConfigContract,
            this.miConfigAttendance});
            this.miConfigSystemTable.Text = "System Table";
            this.miConfigSystemTable.Visible = false;
            // 
            // miConfigPI
            // 
            this.miConfigPI.Index = 0;
            this.miConfigPI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miConfigKindOfStaff,
            this.miConfigMaritalStatus,
            this.miConfigMilitaryStatus,
            this.miConfigPositionGroup,
            this.miConfigPositionType,
            this.miConfigWorkingStatus});
            this.miConfigPI.Text = "PI\r\n";
            // 
            // miConfigKindOfStaff
            // 
            this.miConfigKindOfStaff.Index = 0;
            this.miConfigKindOfStaff.Text = "Kind Of Staff\r\n";
            this.miConfigKindOfStaff.Click += new System.EventHandler(this.miConfigKindOfStaff_Click);
            // 
            // miConfigMaritalStatus
            // 
            this.miConfigMaritalStatus.Index = 1;
            this.miConfigMaritalStatus.Text = "Marital Status\r\n";
            this.miConfigMaritalStatus.Click += new System.EventHandler(this.miConfigMaritalStatus_Click);
            // 
            // miConfigMilitaryStatus
            // 
            this.miConfigMilitaryStatus.Index = 2;
            this.miConfigMilitaryStatus.Text = "Military Status\r\n";
            this.miConfigMilitaryStatus.Click += new System.EventHandler(this.miConfigMilitaryStatus_Click);
            // 
            // miConfigPositionGroup
            // 
            this.miConfigPositionGroup.Index = 3;
            this.miConfigPositionGroup.Text = "Position Group\r\n";
            this.miConfigPositionGroup.Click += new System.EventHandler(this.miConfigPositionGroup_Click);
            // 
            // miConfigPositionType
            // 
            this.miConfigPositionType.Index = 4;
            this.miConfigPositionType.Text = "Position Type\r\n";
            this.miConfigPositionType.Click += new System.EventHandler(this.miConfigPositionType_Click);
            // 
            // miConfigWorkingStatus
            // 
            this.miConfigWorkingStatus.Index = 5;
            this.miConfigWorkingStatus.Text = "Working Status\r\n";
            this.miConfigWorkingStatus.Click += new System.EventHandler(this.miConfigWorkingStatus_Click);
            // 
            // miConfigVehicle
            // 
            this.miConfigVehicle.Index = 1;
            this.miConfigVehicle.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miConfigGasolineType,
            this.miConfigKindOfVehicle,
            this.miConfigModelType,
            this.miConfigVehicleStatus,
            this.miConfigVehicleTax,
            this.miConfigVehicleVAT});
            this.miConfigVehicle.Text = "Vehicle\r\n";
            // 
            // miConfigGasolineType
            // 
            this.miConfigGasolineType.Index = 0;
            this.miConfigGasolineType.Text = "Gasoline Type\r\n";
            this.miConfigGasolineType.Click += new System.EventHandler(this.miConfigGasolineType_Click);
            // 
            // miConfigKindOfVehicle
            // 
            this.miConfigKindOfVehicle.Index = 1;
            this.miConfigKindOfVehicle.Text = "Kind Of Vehicle\r\n";
            this.miConfigKindOfVehicle.Click += new System.EventHandler(this.miConfigKindOfVehicle_Click);
            // 
            // miConfigModelType
            // 
            this.miConfigModelType.Index = 2;
            this.miConfigModelType.Text = "Model Type\r\n";
            this.miConfigModelType.Click += new System.EventHandler(this.miConfigModelType_Click);
            // 
            // miConfigVehicleStatus
            // 
            this.miConfigVehicleStatus.Index = 3;
            this.miConfigVehicleStatus.Text = "Vehicle Status\r\n";
            this.miConfigVehicleStatus.Click += new System.EventHandler(this.miConfigVehicleStatus_Click);
            // 
            // miConfigVehicleTax
            // 
            this.miConfigVehicleTax.Index = 4;
            this.miConfigVehicleTax.Text = "Vehicle Tax Discount Ratio\r\n";
            this.miConfigVehicleTax.Click += new System.EventHandler(this.miConfigVehicleTax_Click);
            // 
            // miConfigVehicleVAT
            // 
            this.miConfigVehicleVAT.Index = 5;
            this.miConfigVehicleVAT.Text = "Vehicle VAT Status\r\n";
            this.miConfigVehicleVAT.Click += new System.EventHandler(this.miConfigVehicleVAT_Click);
            // 
            // miConfigContract
            // 
            this.miConfigContract.Index = 2;
            this.miConfigContract.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miConfigContractStatus,
            this.miConfigContractType,
            this.miConfigCustomerGroup,
            this.miConfigKindOfContract,
            this.miConfigPaymentType});
            this.miConfigContract.Text = "Contract\r\n";
            // 
            // miConfigContractStatus
            // 
            this.miConfigContractStatus.Index = 0;
            this.miConfigContractStatus.Text = "Contract Status\r\n";
            this.miConfigContractStatus.Click += new System.EventHandler(this.miConfigContractStatus_Click);
            // 
            // miConfigContractType
            // 
            this.miConfigContractType.Index = 1;
            this.miConfigContractType.Text = "Contract Type\r\n";
            this.miConfigContractType.Click += new System.EventHandler(this.miConfigContractType_Click);
            // 
            // miConfigCustomerGroup
            // 
            this.miConfigCustomerGroup.Index = 2;
            this.miConfigCustomerGroup.Text = "Customer Group\r\n";
            this.miConfigCustomerGroup.Click += new System.EventHandler(this.miConfigCustomerGroup_Click);
            // 
            // miConfigKindOfContract
            // 
            this.miConfigKindOfContract.Index = 3;
            this.miConfigKindOfContract.Text = "Kind Of Contract\r\n";
            // 
            // miConfigPaymentType
            // 
            this.miConfigPaymentType.Index = 4;
            this.miConfigPaymentType.Text = "Payment Type\r\n";
            this.miConfigPaymentType.Click += new System.EventHandler(this.miConfigPaymentType_Click);
            // 
            // miConfigAttendance
            // 
            this.miConfigAttendance.Index = 3;
            this.miConfigAttendance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTraditionalHolidayPattern});
            this.miConfigAttendance.Text = "Attendance\r\n";
            // 
            // miTraditionalHolidayPattern
            // 
            this.miTraditionalHolidayPattern.Index = 0;
            this.miTraditionalHolidayPattern.Text = "TraditionalHolidayPattern";
            this.miTraditionalHolidayPattern.Click += new System.EventHandler(this.miTraditionalHolidayPattern_Click);
            // 
            // imgListMainMenu
            // 
            this.imgListMainMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListMainMenu.ImageStream")));
            this.imgListMainMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListMainMenu.Images.SetKeyName(0, "");
            this.imgListMainMenu.Images.SetKeyName(1, "");
            this.imgListMainMenu.Images.SetKeyName(2, "");
            this.imgListMainMenu.Images.SetKeyName(3, "");
            this.imgListMainMenu.Images.SetKeyName(4, "");
            this.imgListMainMenu.Images.SetKeyName(5, "");
            // 
            // stbMain
            // 
            this.stbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.stbMain.Location = new System.Drawing.Point(0, -24);
            this.stbMain.Name = "stbMain";
            this.stbMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.stpFormID,
            this.stp,
            this.stpCount,
            this.stpUser,
            this.stpUserDomain});
            this.stbMain.ShowPanels = true;
            this.stbMain.Size = new System.Drawing.Size(720, 24);
            this.stbMain.TabIndex = 4;
            // 
            // stpFormID
            // 
            this.stpFormID.Name = "stpFormID";
            this.stpFormID.ToolTipText = "Form ID";
            this.stpFormID.Width = 170;
            // 
            // stp
            // 
            this.stp.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.stp.Name = "stp";
            this.stp.Width = 163;
            // 
            // stpCount
            // 
            this.stpCount.Name = "stpCount";
            // 
            // stpUser
            // 
            this.stpUser.Icon = ((System.Drawing.Icon)(resources.GetObject("stpUser.Icon")));
            this.stpUser.Name = "stpUser";
            this.stpUser.Text = "User Name : ";
            this.stpUser.Width = 170;
            // 
            // stpUserDomain
            // 
            this.stpUserDomain.Icon = ((System.Drawing.Icon)(resources.GetObject("stpUserDomain.Icon")));
            this.stpUserDomain.Name = "stpUserDomain";
            // 
            // toolBarMainMenu
            // 
            this.toolBarMainMenu.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBarMainMenu.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tlbSep1,
            this.tlbNew,
            this.tlbDelete,
            this.tlbSep2,
            this.tlbRefresh,
            this.tlbPrint,
            this.tlbSep3,
            this.tlbExit});
            this.toolBarMainMenu.ButtonSize = new System.Drawing.Size(32, 32);
            this.toolBarMainMenu.DropDownArrows = true;
            this.toolBarMainMenu.ImageList = this.imgListMainMenu;
            this.toolBarMainMenu.Location = new System.Drawing.Point(0, 0);
            this.toolBarMainMenu.Name = "toolBarMainMenu";
            this.toolBarMainMenu.ShowToolTips = true;
            this.toolBarMainMenu.Size = new System.Drawing.Size(720, 44);
            this.toolBarMainMenu.TabIndex = 2;
            this.toolBarMainMenu.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBarMainMenu.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarMainMenu_ButtonClick);
            // 
            // tlbSep1
            // 
            this.tlbSep1.Name = "tlbSep1";
            this.tlbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbNew
            // 
            this.tlbNew.ImageIndex = 0;
            this.tlbNew.Name = "tlbNew";
            this.tlbNew.Tag = "";
            this.tlbNew.Text = "สร้าง";
            // 
            // tlbDelete
            // 
            this.tlbDelete.ImageIndex = 3;
            this.tlbDelete.Name = "tlbDelete";
            this.tlbDelete.Text = "ลบ";
            // 
            // tlbSep2
            // 
            this.tlbSep2.Name = "tlbSep2";
            this.tlbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbRefresh
            // 
            this.tlbRefresh.ImageIndex = 2;
            this.tlbRefresh.Name = "tlbRefresh";
            this.tlbRefresh.Text = "ดึงข้อมูลใหม่";
            // 
            // tlbPrint
            // 
            this.tlbPrint.ImageIndex = 4;
            this.tlbPrint.Name = "tlbPrint";
            this.tlbPrint.Text = "พิมพ์";
            // 
            // tlbSep3
            // 
            this.tlbSep3.Name = "tlbSep3";
            this.tlbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbExit
            // 
            this.tlbExit.ImageIndex = 1;
            this.tlbExit.Name = "tlbExit";
            this.tlbExit.Text = "ออก";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(0, 0);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(120, 20);
            this.domainUpDown1.TabIndex = 1;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(720, 0);
            this.Controls.Add(this.stbMain);
            this.Controls.Add(this.toolBarMainMenu);
            this.Controls.Add(this.domainUpDown1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mmMenu;
            this.Name = "frmMain";
            this.Text = "Business Transaction Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.stpFormID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stpCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stpUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stpUserDomain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        [STAThread]
        static void Main()
        {
            Application.Run(new frmMain());
        }

        #endregion

        #region Public Variable
        public frmLogIn FormLogIn; 
        #endregion

        #region Constructor
        public frmMain()
            : base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Private Method
        private void visibleAll(bool visible)
        {
            visiblePI(visible);
            visibleVehicle(visible);
            visibleContract(visible);
            visibleAttendance(visible);
            visibleConfig(visible);
            visibleBatchProcess(visible);
            visibleBizPacConnect(visible);
            visibleWelfare(visible);

            miPI.Visible = visible;
            miVehicle.Visible = visible;
            miContract.Visible = visible;
            miAttendance.Visible = visible;
            miBatchProcess.Visible = visible;
            miConfig.Visible = visible;
            miSAPConnect.Visible = visible;
            miWelfare.Visible = visible;
        }

        private void visiblePI(bool visible)
        {
            miPIMasterPrefix.Visible = visible;
            miPIMasterRace.Visible = visible;
            miPIMasterNationality.Visible = visible;
            miPIMasterReligion.Visible = visible;
            miPIMasterOccupation.Visible = visible;
            miPIMasterRelationship.Visible = visible;
            miPIMasterBank.Visible = visible;
            miPIMasterBloodGroup.Visible = visible;
            miPIMasterPlaceProvince.Visible = visible;
            miPIMasterPlaceDistrict.Visible = visible;
            miPIMasterPlaceSubDistrict.Visible = visible;
            miPIMasterPlaceStreet.Visible = visible;
            miPIMasterEducationInstitute.Visible = visible;
            miPIMasterEducationLevel.Visible = visible;
            miPIMasterEducationFaculty.Visible = visible;
            miPIMasterEducationMajor.Visible = visible;
            miPIMapCompany.Visible = visible;
            miPIMapDepartment.Visible = visible;
            miPIMapSection.Visible = visible;
            miPIPositionPosition.Visible = visible;
            miPIPositionTitle.Visible = visible;
            miPIEmployeePI.Visible = visible;
            miPIEmployeeFormerPI.Visible = visible;
            miPIEmployeePrint.Visible = visible;
            miPIEmployeeReport.Visible = visible;
            miPINonEmployeeReport.Visible = visible;
            miPIRetireStaff.Visible = visible;
            miPIEmployeeMoveToFormerPI.Visible = visible;
            miPIEmployeePictureReport.Visible = visible;
            miPIPersonalData.Visible = visible;
            miPIExpiredDrivingLicense.Visible = visible;
            miPIProbationEmployee.Visible = visible;
            miPISalaryEmployee.Visible = visible;
            miPIHireDate.Visible = visible;
            miPIEmployeeSearch.Visible = visible;
            miPIExpiredIDCard.Visible = visible;
            miPIEmployeeRegist.Visible = visible;
            miSpecialAllowance.Visible = visible;
            miPIEmployeeProvidentFundResign.Visible = visible;
            miPIImportEmployeeSalary.Visible = visible;
            miPIPersonnalDataWelfare.Visible = visible;
            miPIEmployeeProvidentFund.Visible = visible;
        }

        private void visibleVehicle(bool visible)
        {
            miVehicleSettingAccidentPlace.Visible = visible;
            miVehicleSettingPoliceStation.Visible = visible;
            miVehicleVehicleVendor.Visible = visible;
            miVehicleVehicleBrand.Visible = visible;
            miVehicleVehicleModel.Visible = visible;
            miVehicleVehicleColor.Visible = visible;
            miVehicleVehicleVehicle.Visible = visible;
            miVehicleVehicleSpare.Visible = visible;
            miVehicleNoVehicleAssign.Visible = visible;
            miVehicleMainVehicle.Visible = visible;
            miVehicleVehicleRepairedVehicle.Visible = visible;
            miVehicleVehicleRepairedVehiclByFinishDate.Visible = visible;
            miVehicleVehicleRepairingHistoryBySpareParts.Visible = visible;
            miVehicleVehicleRepairingHistoryByModel.Visible = visible;
            miVehicleVehicleRepairingHistoryByCustomer.Visible = visible;
            miVehicleVehicleRepairingHistoryByPlateNo.Visible = visible;
            miVehicleAvgMaintenance.Visible = visible;
            miVehicleAvgMaintenanceCust.Visible = visible;
            miVehicleMaintenanceGarage.Visible = visible;
            miVehicleMaintenanceSpareParts.Visible = visible;
            miVehicleMaintenanceAccidentHistory.Visible = visible;
            miVehicleMaintenanceHistory.Visible = visible;
            miVehicleMaintenancebyGarage.Visible = visible;
            miVehicleMaintenanceTotalAmountMaintenance.Visible = visible;
            miVehicleMaintenanceRepairingHistorybyVehicle.Visible = visible;
            miVehicleDocumentInsurance.Visible = visible;
            miVehicleDocumentMaintainInsuranceTypeOne.Visible = visible;
            miVehicleDocumentCreateInsuranceTypeOne.Visible = visible;
            miVehicleDocumentCompulsoryPlate.Visible = visible;
            miVehicleDocumentCompulsoryMonth.Visible = visible;
            miVehicleDocumentCompulsoryInsurancenbyPlate.Visible = visible;
            miVehicleDocumentVehicleTaxPlateNo.Visible = visible;
            miVehicleDocumentVehicleTaxMonth.Visible = visible;
            miVehicleAccident.Visible = visible;
            miVehicleAccidentByEmpNo.Visible = visible;
            miVehicleAccidentByPlateNo.Visible = visible;
            miVehicleMaintenanceExcessInsurance.Visible = visible;
            miVehicleBidder.Visible = visible;
            miVehicleRepairingNoneTaxInvoice.Visible = visible;
            miVehicleLeasingCar.Visible = visible;
            miVehicleSellingPlanSellingPlan.Visible = visible;
            miVehicleSellingPlanVehicleSelling.Visible = visible;
            miVehicleLeasingCalculation.Visible = visible;
            miQuotation.Visible = visible;
            miPO.Visible = visible;
            miComparisonMaintenance.Visible = visible;
        }

        private void visibleContract(bool visible)
        {
            miContractSettingServiceStaffType.Visible = visible;
            miContractSettingContractCancelReason.Visible = visible;
            miContractCustomerData.Visible = visible;
            miContractCustomerDepartment.Visible = visible;
            miContractVehicle.Visible = visible;
            miContractDriver.Visible = visible;
            miContractOtherServiceStaft.Visible = visible;
            miContractDocumentApprove.Visible = visible;
            miContractDocumentCancel.Visible = visible;
            miContractDocumentServiceStaffMatchToContract.Visible = visible;
            miContractDocumentVDContractMatching.Visible = visible;
            miContractDocumentLeasingHistoryOfActiveVehicle.Visible = visible;
            miContractDocumentExpiredVehicleContract.Visible = visible;
            miContractDocumentInComplete.Visible = visible;
            miContractDocumentLongTermContract.Visible = visible;
            miContractDocumentSpareDriver.Visible = visible;
            miContractDocumentServiceStaffContract.Visible = visible;
            miContractDocumentExpiredDriver.Visible = visible;
            miContractDocumentCustomerSpecialCharge.Visible = visible;
            miContractDocumentExpiredVehicle.Visible = visible;
            miContractAssignmentHistoryServiceStaffAssignment.Visible = visible;
            miContractAssignmentHistoryVehicelAssignment.Visible = visible;
            miContractAssignmentHistoryVehicleSpareAssignment.Visible = visible;
            miContractAssignmentHistorybyDriver.Visible = visible;
            miContractVehicleAssignmentbyPlate.Visible = visible;
            miContractVehicleCharge.Visible = visible;
            miContractVehicleMatchWithDriverCheckList.Visible = visible;
            miContractVehicleMatchWithDriver.Visible = visible;
            miContractContractMatchWithDriver.Visible = visible;
            miContractDriverMatchWithVehicleCheckList.Visible = visible;
            miContractNoAccidentReward.Visible = visible;
            miContractSettingMinimumOTCharge.Visible = visible;
            miContractSettingServiceStaffCharge.Visible = visible;
            miContractSettingServiceStaffChargeContract.Visible = visible;
            miContractSettingCustomerChargeAdjustDriver.Visible = visible;
            miContractSettingCustomerChargeAdjustOtherSS.Visible = visible;
            miContractDocumentSpecialCharge.Visible = visible;
            miContractDocumentChargeDiff.Visible = visible;
            miContractDocumentPenaltyCharge.Visible = visible;
            miContractSettingCompensate.Visible = visible;
            miContractDocumentRenewalNotice.Visible = visible;
            miContractDocumentDriverAgreement.Visible = visible;
            miContractDocumentCarAgreement.Visible = visible;
            //D21018-BTS Modification
            miContractDocumentCompanyAgreement.Visible = visible;
        }

        private void visibleAttendance(bool visible)
        {
            miTraditionalHoliday.Visible = visible;
            miHolidayCondition.Visible = visible;
            miHolidayConditionSpecific.Visible = visible;
            miDisease.Visible = visible;
            miSpecialLeave.Visible = visible;
            miLeaveReason.Visible = visible;
            miWorkingTimeTable.Visible = visible;
            miWorkingTimeCondition.Visible = visible;
            miWorkingTimeConditionSpecific.Visible = visible;
            miOtherBenefitRate.Visible = visible;
            miOTPattern.Visible = visible;
            miOvertimeVariant.Visible = visible;
            miOTPatternGeneralCondition.Visible = visible;
            miOTPatternSpecificCondition.Visible = visible;
            miTelephoneCondition.Visible = visible;
            miTaxiCondition.Visible = visible;
            miEmployeeSickLeave.Visible = visible;
            miEmployeePrivateLeave.Visible = visible;
            miEmployeeSpecialLeave.Visible = visible;
            miGenEmployeeWorkSchedule.Visible = visible;
            miEmployeeWorkSchedule.Visible = visible;
            miEmployeeTelephoneBenefit.Visible = visible;
            miEmployeeFoodBenefit.Visible = visible;
            miEmployeeExtraBenefit.Visible = visible;
            miEmployeeMiscBenefit.Visible = visible;
            miEmployeeMiscDeducttion.Visible = visible;
            miAttendanceEmployeeBenefit.Visible = visible;
            miBenefitAdjustment.Visible = visible;
            miGenerateOtherBenefit.Visible = visible;
            miEmployeeExtraAGTBenefit.Visible = visible;
            miTimeRecordOfDriver.Visible = visible;
            miTimeCardForCharge.Visible = visible;
            miTimeCardForPayment.Visible = visible;
            miDriverExcess.Visible = visible;
            miDriverExcessDeductionByMonth.Visible = visible;
            miAttEmpAnnualLeave.Visible = visible;
            miAttendanceSaleAnnualLeave.Visible = visible;
            miAttendanceLeaveSickLeaveReport.Visible = visible;
            miAttendanceLeavePrivateLeaveReport.Visible = visible;
            miAttendanceLeaveAnnualLeaveReport.Visible = visible;
            miAttendanceLeaveEmployeeLeaveReport.Visible = visible;
            miGenAnnualLeaveDay.Visible = visible;
            miLeaveReport.Visible = visible;
            miPayrollBenefit.Visible = visible;
            miNonPayrollBenefit.Visible = visible;
            miAbsentRewardFamilyCarDriver.Visible = visible;
            miEmployeeReceiveGold.Visible = visible;
            miAttendanceLeaveSpecialLeaveReport.Visible = visible;
            miGenerateMealBenefit.Visible = visible;
        }

        private void visibleConfig(bool visible)
        {
            miConfigAdmin.Visible = visible;
            miConfigSystemTable.Visible = visible;
        }

        private void visibleBatchProcess(bool visible)
        {
            miBatchProcessDaily.Visible = visible;
            miBatchProcessMonthly.Visible = visible;
            miBatchProcessYearly.Visible = visible;
        }

        private void visibleBizPacConnect(bool visible)
        {
            //=================== Connect ====================
            miBizPacConnectVehicleRepairing.Visible = visible;
            miBPConnectCompulsoryInsurance.Visible = visible;
            miBizPacConnectInsuranceTypeOne.Visible = visible;
            miBizPacConnectVehicleExcess.Visible = visible;
            //obsolete [Napat C.] 18/02/2019
            miBizPacConnectServiceStaffContractCharge.Visible = false;
            miBizPacConnectVehicleContractCharge.Visible = visible;
            miBizPacConnectDriverContractCharge.Visible = visible;
            miBizPacConnectLoan.Visible = visible;
            miBizPacConnectMedicalAid.Visible = visible;
            miBizPacConnectContribution.Visible = visible;
            miBizPacConnectMedicalAidNoAtt.Visible = visible;
            miBPPreConnectCompulsory.Visible = visible;
            miBPPreConnectInsurance.Visible = visible;
            miBPPreConnectVehicleExcess.Visible = visible;
            miBPPreConnectVehicleRepairing.Visible = visible;
            miBPPreConnectVehicleCharge.Visible = visible;
            miBPPreConnectDriverCharge.Visible = visible;
            //obsolete [Napat C.] 18/02/2019
            miBPPreConnectOfficeCharge.Visible = false;
            miBPRerunVehicleCharge.Visible = visible;
            //obsolete [Napat C.] 18/02/2019
            miBPRerunOtherSSCharge.Visible = false;
            miBPRerunDriverCharge.Visible = visible;

            //=================== Cancel ====================
            miBizPacCancelCompulsoryInsurance.Visible = visible;
            miBizPacCancelInsuranceTypeOne.Visible = visible;
            miBizPacCancelLoan.Visible = visible;
            miBizPacCancelContribution.Visible = visible;
            miBizPacCancelMedicalAid.Visible = visible;
            miBizPacConnectVehicleCancelCharge.Visible = visible;
            miBizPacCancelDriverContractCharge.Visible = visible;
            //obsolete [Napat C.] 18/02/2019
            miBizPacCancelServiceStaffContractCharge.Visible = false;
            miBizPacCancelVehicleRepairing.Visible = visible;
            miBizPacCancelVehicleExcess.Visible = visible;
        }

        private void visibleWelfare(bool visible)
        {
            miWelfareContributionEmpList.Visible = visible;
            miWelfareLoanAppList.Visible = visible;
            miWelfareMedicalAidListByEmp.Visible = visible;
            miWelfareMedicalAidListByHospital.Visible = visible;
            miWelfareSettingContribution.Visible = visible;
            miWelfareSettingHospital.Visible = visible;
            miWelfareSettingLoanReasonList.Visible = visible;
            miWelfareLoanReport.Visible = visible;
            miWelfareLoanByEmpReport.Visible = visible;
            miWelfareLoanOffsetReport.Visible = visible;
            miSSHospital.Visible = visible;
            miWelfareMedicalAidListInsurancePaid.Visible = visible;
            miWelfareMedicalAidReport.Visible = visible;
            miWelfareMedicalAidAttReport.Visible = visible;
            miWelfareMedicalAidNoAttReport.Visible = visible;
            miWelfareMedicalAidListInsurancePaid.Visible = visible;
            miWelfareBenefit.Visible = visible;
        }

        private void setPermission(FunctionPermission value, MenuItem menuItem)
        {
            if (value.Permission == FUNCTION_PERMISSION.NO_ACCESS || (value.IsSystem && UserProfile.UserROLE != USER_ROLE.ADMIN))
            {
                menuItem.Visible = false;
            }
            else
            {
                menuItem.Visible = true;
            }
        }

        private void visibleModuleMenu(ModulePermission value)
        {
            switch (value.Name)
            {
                case "miPI":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miPI.Visible = true;
                            visiblePIMenu(value);
                        }
                        else
                        {
                            miPI.Visible = false;
                        }
                        break;
                    }
                case "miVehicle":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miVehicle.Visible = true;
                            visibleVehicleMenu(value);
                        }
                        else
                        {
                            miVehicle.Visible = false;
                        }
                        break;
                    }
                case "miContract":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miContract.Visible = true;
                            visibleContractMenu(value);
                        }
                        else
                        {
                            miContract.Visible = false;
                        }
                        break;
                    }

                case "miAttendance":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miAttendance.Visible = true;
                            visibleAttendantMenu(value);
                        }
                        else
                        {
                            miAttendance.Visible = false;
                        }
                        break;
                    }
                case "miBatchProcess":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miBatchProcess.Visible = true;
                            visibleBatchProcessMenu(value);
                        }
                        else
                        {
                            miBatchProcess.Visible = false;
                        }
                        break;
                    }
                case "miConfig":
                    {
                        miConfig.Visible = true;
                        visiblemiConfigMenu(value);
                        //						if(value.Permission == MODULE_PERMISSION.ACCESS)
                        //						{
                        //							miConfig.Visible = true;
                        //							visiblemiConfigMenu(value);
                        //						}
                        //						else
                        //						{
                        //							miConfig.Visible = false;
                        //						}
                        break;
                    }
                case "miBizPacConnect":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miSAPConnect.Visible = true;
                            visibleBizPacConnectMenu(value);
                        }
                        else
                        {
                            miSAPConnect.Visible = false;
                        }
                        break;
                    }
                case "miWelfare":
                    {
                        if (value.Permission == MODULE_PERMISSION.ACCESS)
                        {
                            miWelfare.Visible = true;
                            visibleWelfareMenu(value);
                        }
                        else
                        {
                            miWelfare.Visible = false;
                        }
                        break;
                    }
            }
        }

        private void visiblePIMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miPIMasterPrefix":
                        {
                            setPermission(value["miPIMasterPrefix"], miPIMasterPrefix);
                            break;
                        }
                    case "miPIMasterRace":
                        {
                            setPermission(value["miPIMasterRace"], miPIMasterRace);
                            break;
                        }
                    case "miPIMasterNationality":
                        {
                            setPermission(value["miPIMasterNationality"], miPIMasterNationality);
                            break;
                        }
                    case "miPIMasterReligion":
                        {
                            setPermission(value["miPIMasterReligion"], miPIMasterReligion);
                            break;
                        }
                    case "miPIMasterOccupation":
                        {
                            setPermission(value["miPIMasterOccupation"], miPIMasterOccupation);
                            break;
                        }
                    case "miPIMasterRelationship":
                        {
                            setPermission(value["miPIMasterRelationship"], miPIMasterRelationship);
                            break;
                        }
                    case "miPIMasterBank":
                        {
                            setPermission(value["miPIMasterBank"], miPIMasterBank);
                            break;
                        }
                    case "miPIMasterBloodGroup":
                        {
                            setPermission(value["miPIMasterBloodGroup"], miPIMasterBloodGroup);
                            break;
                        }
                    case "miPIMasterPlaceProvince":
                        {
                            setPermission(value["miPIMasterPlaceProvince"], miPIMasterPlaceProvince);
                            break;
                        }
                    case "miPIMasterPlaceDistrict":
                        {
                            setPermission(value["miPIMasterPlaceDistrict"], miPIMasterPlaceDistrict);
                            break;
                        }
                    case "miPIMasterPlaceSubDistrict":
                        {
                            setPermission(value["miPIMasterPlaceSubDistrict"], miPIMasterPlaceSubDistrict);
                            break;
                        }
                    case "miPIMasterPlaceStreet":
                        {
                            setPermission(value["miPIMasterPlaceStreet"], miPIMasterPlaceStreet);
                            break;
                        }
                    case "miPIMasterEducationInstitute":
                        {
                            setPermission(value["miPIMasterEducationInstitute"], miPIMasterEducationInstitute);
                            break;
                        }
                    case "miPIMasterEducationLevel":
                        {
                            setPermission(value["miPIMasterEducationLevel"], miPIMasterEducationLevel);
                            break;
                        }
                    case "miPIMasterEducationFaculty":
                        {
                            setPermission(value["miPIMasterEducationFaculty"], miPIMasterEducationFaculty);
                            break;
                        }
                    case "miPIMasterEducationMajor":
                        {
                            setPermission(value["miPIMasterEducationMajor"], miPIMasterEducationMajor);
                            break;
                        }

                    case "miPIMapCompany":
                        {
                            setPermission(value["miPIMapCompany"], miPIMapCompany);
                            break;
                        }
                    case "miPIMapDepartment":
                        {
                            setPermission(value["miPIMapDepartment"], miPIMapDepartment);
                            break;
                        }
                    case "miPIMapSection":
                        {
                            setPermission(value["miPIMapSection"], miPIMapSection);
                            break;
                        }
                    case "miPIPositionPosition":
                        {
                            setPermission(value["miPIPositionPosition"], miPIPositionPosition);
                            break;
                        }
                    case "miPIPositionTitle":
                        {
                            setPermission(value["miPIPositionTitle"], miPIPositionTitle);
                            break;
                        }

                    case "miPIEmployeePI":
                        {
                            setPermission(value["miPIEmployeePI"], miPIEmployeePI);
                            break;
                        }
                    case "miPIEmployeeFormerPI":
                        {
                            setPermission(value["miPIEmployeeFormerPI"], miPIEmployeeFormerPI);
                            break;
                        }
                    case "miPIEmployeeMoveToFormerPI":
                        {
                            setPermission(value["miPIEmployeeMoveToFormerPI"], miPIEmployeeMoveToFormerPI);
                            break;
                        }
                    case "miPIEmployeePrint":
                        {
                            setPermission(value["miPIEmployeePrint"], miPIEmployeePrint);
                            break;
                        }
                    case "miPIEmployeeReport":
                        {
                            setPermission(value["miPIEmployeeReport"], miPIEmployeeReport);
                            break;
                        }
                    case "miPINonEmployeeReport":
                        {
                            setPermission(value["miPINonEmployeeReport"], miPINonEmployeeReport);
                            break;
                        }
                    case "miPIRetireStaff":
                        {
                            setPermission(value["miPIRetireStaff"], miPIRetireStaff);
                            break;
                        }
                    case "miPIEmployeePictureReport":
                        {
                            setPermission(value["miPIEmployeePictureReport"], miPIEmployeePictureReport);
                            break;
                        }
                    case "miPIPersonalData":
                        {
                            setPermission(value["miPIPersonalData"], miPIPersonalData);
                            break;
                        }
                    case "miPIExpiredDrivingLicense":
                        {
                            setPermission(value["miPIExpiredDrivingLicense"], miPIExpiredDrivingLicense);
                            break;
                        }
                    case "miPIProbationEmployee":
                        {
                            setPermission(value["miPIProbationEmployee"], miPIProbationEmployee);
                            break;
                        }
                    case "miPISalaryEmployee":
                        {
                            setPermission(value["miPISalaryEmployee"], miPISalaryEmployee);
                            break;
                        }
                    case "miPIHireDate":
                        {
                            setPermission(value["miPIHireDate"], miPIHireDate);
                            break;
                        }
                    case "miPIEmployeeSearch":
                        {
                            setPermission(value["miPIEmployeeSearch"], miPIEmployeeSearch);
                            break;
                        }
                    case "miPIExpiredIDCard":
                        {
                            setPermission(value["miPIExpiredIDCard"], miPIExpiredIDCard);
                            break;
                        }
                    case "miPIEmployeeRegist":
                        {
                            setPermission(value["miPIEmployeeRegist"], miPIEmployeeRegist);
                            break;
                        }
                    case "miSpecialAllowance":
                        {
                            setPermission(value["miSpecialAllowance"], miSpecialAllowance);
                            break;
                        }
                    case "miPIEmployeeProvidentFundResign":
                        {
                            setPermission(value["miPIEmployeeProvidentFundResign"], miPIEmployeeProvidentFundResign);
                            break;
                        }
                    case "miPIImportEmployeeSalary":
                        {
                            setPermission(value["miPIImportEmployeeSalary"], miPIImportEmployeeSalary);
                            break;
                        }

                    case "miPIPersonnalDataWelfare":
                        {
                            setPermission(value["miPIPersonnalDataWelfare"], miPIPersonnalDataWelfare);
                            break;
                        }
                    case "miPIEmployeeProvidentFund":
                        {
                            setPermission(value["miPIEmployeeProvidentFund"], miPIEmployeeProvidentFund);
                            break;
                        }
                }
            }
        }

        private void visibleVehicleMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miVehicleSettingAccidentPlace":
                        {
                            setPermission(value["miVehicleSettingAccidentPlace"], miVehicleSettingAccidentPlace);
                            break;
                        }
                    case "miVehicleSettingPoliceStation":
                        {
                            setPermission(value["miVehicleSettingPoliceStation"], miVehicleSettingPoliceStation);
                            break;
                        }
                    case "miVehicleVehicleVendor":
                        {
                            setPermission(value["miVehicleVehicleVendor"], miVehicleVehicleVendor);
                            break;
                        }
                    case "miVehicleVehicleBrand":
                        {
                            setPermission(value["miVehicleVehicleBrand"], miVehicleVehicleBrand);
                            break;
                        }
                    case "miVehicleVehicleModel":
                        {
                            setPermission(value["miVehicleVehicleModel"], miVehicleVehicleModel);
                            break;
                        }
                    case "miVehicleVehicleColor":
                        {
                            setPermission(value["miVehicleVehicleColor"], miVehicleVehicleColor);
                            break;
                        }
                    case "miVehicleVehicleVehicle":
                        {
                            setPermission(value["miVehicleVehicleVehicle"], miVehicleVehicleVehicle);
                            break;
                        }
                    case "miVehicleVehicleSpare":
                        {
                            setPermission(value["miVehicleVehicleSpare"], miVehicleVehicleSpare);
                            break;
                        }
                    case "miVehicleNoVehicleAssign":
                        {
                            setPermission(value["miVehicleNoVehicleAssign"], miVehicleNoVehicleAssign);
                            break;
                        }

                    case "miVehicleMainVehicle":
                        {
                            setPermission(value["miVehicleMainVehicle"], miVehicleMainVehicle);
                            break;
                        }
                    case "miVehicleVehicleRepairedVehicle":
                        {
                            setPermission(value["miVehicleVehicleRepairedVehicle"], miVehicleVehicleRepairedVehicle);
                            break;
                        }
                    case "miVehicleVehicleRepairedVehiclByFinishDate":
                        {
                            setPermission(value["miVehicleVehicleRepairedVehiclByFinishDate"], miVehicleVehicleRepairedVehiclByFinishDate);
                            break;
                        }
                    case "miVehicleVehicleRepairingHistoryBySpareParts":
                        {
                            setPermission(value["miVehicleVehicleRepairingHistoryBySpareParts"], miVehicleVehicleRepairingHistoryBySpareParts);
                            break;
                        }
                    case "miVehicleVehicleRepairingHistoryByModel":
                        {
                            setPermission(value["miVehicleVehicleRepairingHistoryByModel"], miVehicleVehicleRepairingHistoryByModel);
                            break;
                        }
                    case "miVehicleVehicleRepairingHistoryByCustomer":
                        {
                            setPermission(value["miVehicleVehicleRepairingHistoryByCustomer"], miVehicleVehicleRepairingHistoryByCustomer);
                            break;
                        }
                    case "miVehicleVehicleRepairingHistoryByPlateNo":
                        {
                            setPermission(value["miVehicleVehicleRepairingHistoryByPlateNo"], miVehicleVehicleRepairingHistoryByPlateNo);
                            break;
                        }
                    case "miVehicleAvgMaintenance":
                        {
                            setPermission(value["miVehicleAvgMaintenance"], miVehicleAvgMaintenance);
                            break;
                        }
                    case "miVehicleAvgMaintenanceCust":
                        {
                            setPermission(value["miVehicleAvgMaintenanceCust"], miVehicleAvgMaintenanceCust);
                            break;
                        }

                    case "miVehicleMaintenanceGarage":
                        {
                            setPermission(value["miVehicleMaintenanceGarage"], miVehicleMaintenanceGarage);
                            break;
                        }
                    case "miVehicleMaintenanceSpareParts":
                        {
                            setPermission(value["miVehicleMaintenanceSpareParts"], miVehicleMaintenanceSpareParts);
                            break;
                        }
                    case "miVehicleMaintenanceAccidentHistory":
                        {
                            setPermission(value["miVehicleMaintenanceAccidentHistory"], miVehicleMaintenanceAccidentHistory);
                            break;
                        }
                    case "miVehicleMaintenanceHistory":
                        {
                            setPermission(value["miVehicleMaintenanceHistory"], miVehicleMaintenanceHistory);
                            break;
                        }
                    case "miVehicleMaintenancebyGarage":
                        {
                            setPermission(value["miVehicleMaintenancebyGarage"], miVehicleMaintenancebyGarage);
                            break;
                        }
                    case "miVehicleMaintenanceTotalAmountMaintenance":
                        {
                            setPermission(value["miVehicleMaintenanceTotalAmountMaintenance"], miVehicleMaintenanceTotalAmountMaintenance);
                            break;
                        }
                    case "miVehicleMaintenanceRepairingHistorybyVehicle":
                        {
                            setPermission(value["miVehicleMaintenanceRepairingHistorybyVehicle"], miVehicleMaintenanceRepairingHistorybyVehicle);
                            break;
                        }
                    case "miVehicleDocumentInsurance":
                        {
                            setPermission(value["miVehicleDocumentInsurance"], miVehicleDocumentInsurance);
                            break;
                        }
                    case "miVehicleDocumentMaintainInsuranceTypeOne":
                        {
                            setPermission(value["miVehicleDocumentMaintainInsuranceTypeOne"], miVehicleDocumentMaintainInsuranceTypeOne);
                            break;
                        }
                    case "miVehicleDocumentCreateInsuranceTypeOne":
                        {
                            setPermission(value["miVehicleDocumentCreateInsuranceTypeOne"], miVehicleDocumentCreateInsuranceTypeOne);
                            break;
                        }
                    case "miVehicleDocumentCompulsoryPlate":
                        {
                            setPermission(value["miVehicleDocumentCompulsoryPlate"], miVehicleDocumentCompulsoryPlate);
                            break;
                        }
                    case "miVehicleDocumentCompulsoryMonth":
                        {
                            setPermission(value["miVehicleDocumentCompulsoryMonth"], miVehicleDocumentCompulsoryMonth);
                            break;
                        }
                    case "miVehicleDocumentCompulsoryInsurancenbyPlate":
                        {
                            setPermission(value["miVehicleDocumentCompulsoryInsurancenbyPlate"], miVehicleDocumentCompulsoryInsurancenbyPlate);
                            break;
                        }
                    case "miVehicleDocumentVehicleTaxPlateNo":
                        {
                            setPermission(value["miVehicleDocumentVehicleTaxPlateNo"], miVehicleDocumentVehicleTaxPlateNo);
                            break;
                        }
                    case "miVehicleDocumentVehicleTaxMonth":
                        {
                            setPermission(value["miVehicleDocumentVehicleTaxMonth"], miVehicleDocumentVehicleTaxMonth);
                            break;
                        }
                    case "miVehicleAccident":
                        {
                            setPermission(value["miVehicleAccident"], miVehicleAccident);
                            break;
                        }
                    case "miVehicleAccidentByPlateNo":
                        {
                            setPermission(value["miVehicleAccidentByPlateNo"], miVehicleAccidentByPlateNo);
                            break;
                        }
                    case "miVehicleAccidentByEmpNo":
                        {
                            setPermission(value["miVehicleAccidentByEmpNo"], miVehicleAccidentByEmpNo);
                            break;
                        }
                    case "miVehicleMaintenanceExcessInsurance":
                        {
                            setPermission(value["miVehicleMaintenanceExcessInsurance"], miVehicleMaintenanceExcessInsurance);
                            break;
                        }
                    case "miVehicleBidder":
                        {
                            setPermission(value["miVehicleBidder"], miVehicleBidder);
                            break;
                        }
                    case "miVehicleRepairingNoneTaxInvoice":
                        {
                            setPermission(value["miVehicleRepairingNoneTaxInvoice"], miVehicleRepairingNoneTaxInvoice);
                            break;
                        }
                    case "miVehicleLeasingCar":
                        {
                            setPermission(value["miVehicleLeasingCar"], miVehicleLeasingCar);
                            break;
                        }
                    case "miVehicleSellingPlanSellingPlan":
                        {
                            setPermission(value["miVehicleSellingPlanSellingPlan"], miVehicleSellingPlanSellingPlan);
                            break;
                        }
                    case "miVehicleSellingPlanVehicleSelling":
                        {
                            setPermission(value["miVehicleSellingPlanVehicleSelling"], miVehicleSellingPlanVehicleSelling);
                            break;
                        }
                    case "miVehicleLeasingCalculation":
                        {
                            setPermission(value["miVehicleLeasingCalculation"], miVehicleLeasingCalculation);
                            break;
                        }
                    case "miQuotation":
                        {
                            setPermission(value["miQuotation"], miQuotation);
                            break;
                        }
                    case "miPO":
                        {
                            setPermission(value["miPO"], miPO);
                            break;
                        }
                    case "miComparisonMaintenance":
                        {
                            setPermission(value["miComparisonMaintenance"], miComparisonMaintenance);
                            break;
                        }
                }
            }
        }

        private void visibleContractMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miContractSettingServiceStaffType":
                        {
                            setPermission(value["miContractSettingServiceStaffType"], miContractSettingServiceStaffType);
                            break;
                        }
                    case "miContractSettingContractCancelReason":
                        {
                            setPermission(value["miContractSettingContractCancelReason"], miContractSettingContractCancelReason);
                            break;
                        }
                    case "miContractCustomerData":
                        {
                            setPermission(value["miContractCustomerData"], miContractCustomerData);
                            break;
                        }
                    case "miContractCustomerDepartment":
                        {
                            setPermission(value["miContractCustomerDepartment"], miContractCustomerDepartment);
                            break;
                        }
                    case "miContractVehicle":
                        {
                            setPermission(value["miContractVehicle"], miContractVehicle);
                            break;
                        }
                    case "miContractDriver":
                        {
                            setPermission(value["miContractDriver"], miContractDriver);
                            break;
                        }
                    case "miContractOtherServiceStaft":
                        {
                            setPermission(value["miContractOtherServiceStaft"], miContractOtherServiceStaft);
                            break;
                        }
                    case "miContractDocumentApprove":
                        {
                            setPermission(value["miContractDocumentApprove"], miContractDocumentApprove);
                            break;
                        }
                    case "miContractDocumentCancel":
                        {
                            setPermission(value["miContractDocumentCancel"], miContractDocumentCancel);
                            break;
                        }
                    case "miContractDocumentServiceStaffMatchToContract":
                        {
                            setPermission(value["miContractDocumentServiceStaffMatchToContract"], miContractDocumentServiceStaffMatchToContract);
                            break;
                        }
                    case "miContractDocumentVDContractMatching":
                        {
                            setPermission(value["miContractDocumentVDContractMatching"], miContractDocumentVDContractMatching);
                            break;
                        }
                    case "miContractDocumentLeasingHistoryOfActiveVehicle":
                        {
                            setPermission(value["miContractDocumentLeasingHistoryOfActiveVehicle"], miContractDocumentLeasingHistoryOfActiveVehicle);
                            break;
                        }
                    case "miContractDocumentExpiredVehicleContract":
                        {
                            setPermission(value["miContractDocumentExpiredVehicleContract"], miContractDocumentExpiredVehicleContract);
                            break;
                        }
                    case "miContractDocumentInComplete":
                        {
                            setPermission(value["miContractDocumentInComplete"], miContractDocumentInComplete);
                            break;
                        }
                    case "miContractDocumentLongTermContract":
                        {
                            setPermission(value["miContractDocumentLongTermContract"], miContractDocumentLongTermContract);
                            break;
                        }
                    case "miContractDocumentSpareDriver":
                        {
                            setPermission(value["miContractDocumentSpareDriver"], miContractDocumentSpareDriver);
                            break;
                        }
                    case "miContractDocumentServiceStaffContract":
                        {
                            setPermission(value["miContractDocumentServiceStaffContract"], miContractDocumentServiceStaffContract);
                            break;
                        }
                    case "miContractDocumentExpiredVehicle":
                        {
                            setPermission(value["miContractDocumentExpiredVehicle"], miContractDocumentExpiredVehicle);
                            break;
                        }
                    case "miContractDocumentExpiredDriver":
                        {
                            setPermission(value["miContractDocumentExpiredDriver"], miContractDocumentExpiredDriver);
                            break;
                        }
                    case "miContractDocumentCustomerSpecialCharge":
                        {
                            setPermission(value["miContractDocumentCustomerSpecialCharge"], miContractDocumentCustomerSpecialCharge);
                            break;
                        }
                    case "miContractAssignmentHistoryServiceStaffAssignment":
                        {
                            setPermission(value["miContractAssignmentHistoryServiceStaffAssignment"], miContractAssignmentHistoryServiceStaffAssignment);
                            break;
                        }
                    case "miContractAssignmentHistoryVehicleSpareAssignment":
                        {
                            setPermission(value["miContractAssignmentHistoryVehicleSpareAssignment"], miContractAssignmentHistoryVehicleSpareAssignment);
                            break;
                        }
                    case "miContractAssignmentHistoryVehicelAssignment":
                        {
                            setPermission(value["miContractAssignmentHistoryVehicelAssignment"], miContractAssignmentHistoryVehicelAssignment);
                            break;
                        }
                    case "miContractAssignmentHistorybyDriver":
                        {
                            setPermission(value["miContractAssignmentHistorybyDriver"], miContractAssignmentHistorybyDriver);
                            break;
                        }
                    case "miContractVehicleAssignmentbyPlate":
                        {
                            setPermission(value["miContractVehicleAssignmentbyPlate"], miContractVehicleAssignmentbyPlate);
                            break;
                        }
                    case "miContractVehicleCharge":
                        {
                            setPermission(value["miContractVehicleCharge"], miContractVehicleCharge);
                            break;
                        }
                    case "miContractVehicleMatchWithDriverCheckList":
                        {
                            setPermission(value["miContractVehicleMatchWithDriverCheckList"], miContractVehicleMatchWithDriverCheckList);
                            break;
                        }
                    case "miContractVehicleMatchWithDriver":
                        {
                            setPermission(value["miContractVehicleMatchWithDriver"], miContractVehicleMatchWithDriver);
                            break;
                        }
                    case "miContractContractMatchWithDriver":
                        {
                            setPermission(value["miContractContractMatchWithDriver"], miContractContractMatchWithDriver);
                            break;
                        }
                    case "miContractDriverMatchWithVehicleCheckList":
                        {
                            setPermission(value["miContractDriverMatchWithVehicleCheckList"], miContractDriverMatchWithVehicleCheckList);
                            break;
                        }
                    case "miContractNoAccidentReward":
                        {
                            setPermission(value["miContractNoAccidentReward"], miContractNoAccidentReward);
                            break;
                        }
                    case "miContractSettingMinimumOTCharge":
                        {
                            setPermission(value["miContractSettingMinimumOTCharge"], miContractSettingMinimumOTCharge);
                            break;
                        }
                    case "miContractSettingServiceStaffCharge":
                        {
                            setPermission(value["miContractSettingServiceStaffCharge"], miContractSettingServiceStaffCharge);
                            break;
                        }
                    case "miContractSettingServiceStaffChargeContract":
                        {
                            setPermission(value["miContractSettingServiceStaffChargeContract"], miContractSettingServiceStaffChargeContract);
                            break;
                        }
                    case "miContractSettingCustomerChargeAdjustDriver":
                        {
                            setPermission(value["miContractSettingCustomerChargeAdjustDriver"], miContractSettingCustomerChargeAdjustDriver);
                            break;
                        }
                    case "miContractSettingCustomerChargeAdjustOtherSS":
                        {
                            setPermission(value["miContractSettingCustomerChargeAdjustOtherSS"], miContractSettingCustomerChargeAdjustOtherSS);
                            break;
                        }
                    case "miContractDocumentSpecialCharge":
                        {
                            setPermission(value["miContractDocumentSpecialCharge"], miContractDocumentSpecialCharge);
                            break;
                        }
                    case "miContractDocumentChargeDiff":
                        {
                            setPermission(value["miContractDocumentChargeDiff"], miContractDocumentChargeDiff);
                            break;
                        }
                    case "miContractDocumentPenaltyCharge":
                        {
                            setPermission(value["miContractDocumentPenaltyCharge"], miContractDocumentPenaltyCharge);
                            break;
                        }
                    case "miContractSettingCompensate":
                        {
                            setPermission(value["miContractSettingCompensate"], miContractSettingCompensate);
                            break;
                        }
                    case "miContractDocumentRenewalNotice":
                        {
                            setPermission(value["miContractDocumentRenewalNotice"], miContractDocumentRenewalNotice);
                            break;
                        }
                    case "miContractDocumentDriverAgreement":
                        {
                            setPermission(value["miContractDocumentDriverAgreement"], miContractDocumentDriverAgreement);
                            break;
                        }
                    case "miContractDocumentCarAgreement":
                        {
                            setPermission(value["miContractDocumentCarAgreement"], miContractDocumentCarAgreement);
                            break;
                        }
                    //D21018-BTS Modification
                    case "miContractDocumentCompanyAgreement":
                        {
                            setPermission(value["miContractDocumentCompanyAgreement"], miContractDocumentCompanyAgreement);
                            break;
                        }
                }
            }
        }

        private void visibleAttendantMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miTraditionalHoliday":
                        {
                            setPermission(value["miTraditionalHoliday"], miTraditionalHoliday);
                            break;
                        }
                    case "miHolidayCondition":
                        {
                            setPermission(value["miHolidayCondition"], miHolidayCondition);
                            break;
                        }
                    case "miHolidayConditionSpecific":
                        {
                            setPermission(value["miHolidayConditionSpecific"], miHolidayConditionSpecific);
                            break;
                        }
                    case "miDisease":
                        {
                            setPermission(value["miDisease"], miDisease);
                            break;
                        }
                    case "miSpecialLeave":
                        {
                            setPermission(value["miSpecialLeave"], miSpecialLeave);
                            break;
                        }
                    case "miLeaveReason":
                        {
                            setPermission(value["miLeaveReason"], miLeaveReason);
                            break;
                        }
                    case "miWorkingTimeTable":
                        {
                            setPermission(value["miWorkingTimeTable"], miWorkingTimeTable);
                            break;
                        }
                    case "miWorkingTimeCondition":
                        {
                            setPermission(value["miWorkingTimeCondition"], miWorkingTimeCondition);
                            break;
                        }
                    case "miWorkingTimeConditionSpecific":
                        {
                            setPermission(value["miWorkingTimeConditionSpecific"], miWorkingTimeConditionSpecific);
                            break;
                        }
                    case "miOtherBenefitRate":
                        {
                            setPermission(value["miOtherBenefitRate"], miOtherBenefitRate);
                            break;
                        }
                    case "miOTPattern":
                        {
                            setPermission(value["miOTPattern"], miOTPattern);
                            break;
                        }
                    case "miOvertimeVariant":
                        {
                            setPermission(value["miOvertimeVariant"], miOvertimeVariant);
                            break;
                        }
                    case "miOTPatternGeneralCondition":
                        {
                            setPermission(value["miOTPatternGeneralCondition"], miOTPatternGeneralCondition);
                            break;
                        }
                    case "miOTPatternSpecificCondition":
                        {
                            setPermission(value["miOTPatternSpecificCondition"], miOTPatternSpecificCondition);
                            break;
                        }
                    case "miTelephoneCondition":
                        {
                            setPermission(value["miTelephoneCondition"], miTelephoneCondition);
                            break;
                        }
                    case "miTaxiCondition":
                        {
                            setPermission(value["miTaxiCondition"], miTaxiCondition);
                            break;
                        }
                    case "miEmployeeSickLeave":
                        {
                            setPermission(value["miEmployeeSickLeave"], miEmployeeSickLeave);
                            break;
                        }
                    case "miEmployeePrivateLeave":
                        {
                            setPermission(value["miEmployeePrivateLeave"], miEmployeePrivateLeave);
                            break;
                        }
                    case "miEmployeeSpecialLeave":
                        {
                            setPermission(value["miEmployeeSpecialLeave"], miEmployeeSpecialLeave);
                            break;
                        }
                    case "miGenEmployeeWorkSchedule":
                        {
                            setPermission(value["miGenEmployeeWorkSchedule"], miGenEmployeeWorkSchedule);
                            break;
                        }
                    case "miEmployeeWorkSchedule":
                        {
                            setPermission(value["miEmployeeWorkSchedule"], miEmployeeWorkSchedule);
                            break;
                        }
                    case "miEmployeeTelephoneBenefit":
                        {
                            setPermission(value["miEmployeeTelephoneBenefit"], miEmployeeTelephoneBenefit);
                            break;
                        }
                    case "miEmployeeFoodBenefit":
                        {
                            setPermission(value["miEmployeeFoodBenefit"], miEmployeeFoodBenefit);
                            break;
                        }
                    case "miEmployeeExtraBenefit":
                        {
                            setPermission(value["miEmployeeExtraBenefit"], miEmployeeExtraBenefit);
                            break;
                        }
                    case "miEmployeeMiscBenefit":
                        {
                            setPermission(value["miEmployeeMiscBenefit"], miEmployeeMiscBenefit);
                            break;
                        }
                    case "miEmployeeMiscDeducttion":
                        {
                            setPermission(value["miEmployeeMiscDeducttion"], miEmployeeMiscDeducttion);
                            break;
                        }
                    case "miAttendanceEmployeeBenefit":
                        {
                            setPermission(value["miAttendanceEmployeeBenefit"], miAttendanceEmployeeBenefit);
                            break;
                        }
                    case "miBenefitAdjustment":
                        {
                            setPermission(value["miBenefitAdjustment"], miBenefitAdjustment);
                            break;
                        }
                    case "miGenerateOtherBenefit":
                        {
                            setPermission(value["miGenerateOtherBenefit"], miGenerateOtherBenefit);
                            break;
                        }
                    case "miEmployeeExtraAGTBenefit":
                        {
                            setPermission(value["miEmployeeExtraAGTBenefit"], miEmployeeExtraAGTBenefit);
                            break;
                        }
                    case "miTimeRecordOfDriver":
                        {
                            setPermission(value["miTimeRecordOfDriver"], miTimeRecordOfDriver);
                            break;
                        }
                    case "miTimeCardForCharge":
                        {
                            setPermission(value["miTimeCardForCharge"], miTimeCardForCharge);
                            break;
                        }
                    case "miTimeCardForPayment":
                        {
                            setPermission(value["miTimeCardForPayment"], miTimeCardForPayment);
                            break;
                        }
                    case "miDriverExcess":
                        {
                            setPermission(value["miDriverExcess"], miDriverExcess);
                            break;
                        }
                    case "miDriverExcessDeductionByMonth":
                        {
                            setPermission(value["miDriverExcessDeductionByMonth"], miDriverExcessDeductionByMonth);
                            break;
                        }
                    case "miAttEmpAnnualLeave":
                        {
                            setPermission(value["miAttEmpAnnualLeave"], miAttEmpAnnualLeave);
                            break;
                        }
                    case "miAttendanceSaleAnnualLeave":
                        {
                            setPermission(value["miAttendanceSaleAnnualLeave"], miAttendanceSaleAnnualLeave);
                            break;
                        }
                    case "miAttendanceLeaveSickLeaveReport":
                        {
                            setPermission(value["miAttendanceLeaveSickLeaveReport"], miAttendanceLeaveSickLeaveReport);
                            break;
                        }
                    case "miAttendanceLeavePrivateLeaveReport":
                        {
                            setPermission(value["miAttendanceLeavePrivateLeaveReport"], miAttendanceLeavePrivateLeaveReport);
                            break;
                        }
                    case "miAttendanceLeaveAnnualLeaveReport":
                        {
                            setPermission(value["miAttendanceLeaveAnnualLeaveReport"], miAttendanceLeaveAnnualLeaveReport);
                            break;
                        }
                    case "miAttendanceLeaveEmployeeLeaveReport":
                        {
                            setPermission(value["miAttendanceLeaveEmployeeLeaveReport"], miAttendanceLeaveEmployeeLeaveReport);
                            break;
                        }
                    case "miGenAnnualLeaveDay":
                        {
                            setPermission(value["miGenAnnualLeaveDay"], miGenAnnualLeaveDay);
                            break;
                        }
                    case "miLeaveReport":
                        {
                            setPermission(value["miLeaveReport"], miLeaveReport);
                            break;
                        }
                    case "miPayrollBenefit":
                        {
                            setPermission(value["miPayrollBenefit"], miPayrollBenefit);
                            break;
                        }
                    case "miNonPayrollBenefit":
                        {
                            setPermission(value["miNonPayrollBenefit"], miNonPayrollBenefit);
                            break;
                        }
                    case "miAbsentRewardFamilyCarDriver":
                        {
                            setPermission(value["miAbsentRewardFamilyCarDriver"], miAbsentRewardFamilyCarDriver);
                            break;
                        }
                    case "miEmployeeReceiveGold":
                        {
                            setPermission(value["miEmployeeReceiveGold"], miEmployeeReceiveGold);
                            break;
                        }
                    case "miAttendanceLeaveSpecialLeaveReport":
                        {
                            setPermission(value["miAttendanceLeaveSpecialLeaveReport"], miAttendanceLeaveSpecialLeaveReport);
                            break;
                        }
                    case "miGenerateMealBenefit":
                        {
                            setPermission(value["miGenerateMealBenefit"], miGenerateMealBenefit);
                            break;
                        }
                }
            }
        }

        private void visibleBatchProcessMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miBatchProcessDaily":
                        {
                            setPermission(value["miBatchProcessDaily"], miBatchProcessDaily);
                            break;
                        }
                    case "miBatchProcessMonthly":
                        {
                            setPermission(value["miBatchProcessMonthly"], miBatchProcessMonthly);
                            break;
                        }
                    case "miBatchProcessYearly":
                        {
                            setPermission(value["miBatchProcessYearly"], miBatchProcessYearly);
                            break;
                        }
                }
            }
        }

        private void visiblemiConfigMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miConfigAdmin":
                        {
                            setPermission(value["miConfigAdmin"], miConfigAdmin);
                            break;
                        }
                    case "miConfigSystemTable":
                        {
                            setPermission(value["miConfigSystemTable"], miConfigSystemTable);
                            break;
                        }
                }
            }
        }

        private void visibleBizPacConnectMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miBizPacConnectVehicleRepairing":
                        {
                            setPermission(value["miBizPacConnectVehicleRepairing"], miBizPacConnectVehicleRepairing);
                            setPermission(value["miBizPacConnectVehicleRepairing"], miBPPreConnectVehicleRepairing);
                            break;
                        }
                    case "miBizPacConnectCompulsoryInsurance":
                        {
                            setPermission(value["miBizPacConnectCompulsoryInsurance"], miBPConnectCompulsoryInsurance);
                            setPermission(value["miBizPacConnectCompulsoryInsurance"], miBPPreConnectCompulsory);
                            break;
                        }
                    case "miBizPacConnectInsuranceTypeOne":
                        {
                            setPermission(value["miBizPacConnectInsuranceTypeOne"], miBizPacConnectInsuranceTypeOne);
                            setPermission(value["miBizPacConnectInsuranceTypeOne"], miBPPreConnectInsurance);
                            break;
                        }
                    case "miBizPacConnectVehicleExcess":
                        {
                            setPermission(value["miBizPacConnectVehicleExcess"], miBizPacConnectVehicleExcess);
                            setPermission(value["miBizPacConnectVehicleExcess"], miBPPreConnectVehicleExcess);
                            break;
                        }
                    case "miBizPacConnectServiceStaffContractCharge":
                        {
                            setPermission(value["miBizPacConnectServiceStaffContractCharge"], miBizPacConnectServiceStaffContractCharge);
                            setPermission(value["miBizPacConnectServiceStaffContractCharge"], miBPPreConnectOfficeCharge);
                            setPermission(value["miBizPacConnectServiceStaffContractCharge"], miBPRerunOtherSSCharge);
                            break;
                        }
                    case "miBizPacConnectVehicleContractCharge":
                        {
                            setPermission(value["miBizPacConnectVehicleContractCharge"], miBizPacConnectVehicleContractCharge);
                            setPermission(value["miBizPacConnectVehicleContractCharge"], miBPPreConnectVehicleCharge);
                            setPermission(value["miBizPacConnectVehicleContractCharge"], miBPRerunVehicleCharge);
                            break;
                        }
                    case "miBizPacConnectDriverContractCharge":
                        {
                            setPermission(value["miBizPacConnectDriverContractCharge"], miBizPacConnectDriverContractCharge);
                            setPermission(value["miBizPacConnectDriverContractCharge"], miBPRerunDriverCharge);
                            break;
                        }
                    case "miBPPreConnectDriverCharge":
                        {
                            setPermission(value["miBPPreConnectDriverCharge"], miBPPreConnectDriverCharge);
                            break;
                        }
                    case "miBizPacConnectLoan":
                        {
                            setPermission(value["miBizPacConnectLoan"], miBizPacConnectLoan);
                            break;
                        }
                    case "miBizPacConnectMedicalAid":
                        {
                            setPermission(value["miBizPacConnectMedicalAid"], miBizPacConnectMedicalAid);
                            break;
                        }
                    case "miBizPacConnectContribution":
                        {
                            setPermission(value["miBizPacConnectContribution"], miBizPacConnectContribution);
                            break;
                        }
                    case "miBizPacConnectMedicalAidNoAtt":
                        {
                            setPermission(value["miBizPacConnectMedicalAidNoAtt"], miBizPacConnectMedicalAidNoAtt);
                            break;
                        }
                    case "miBizPacCancelCompulsoryInsurance":
                        {
                            setPermission(value["miBizPacCancelCompulsoryInsurance"], miBizPacCancelCompulsoryInsurance);
                            break;
                        }
                    case "miBizPacCancelInsuranceTypeOne":
                        {
                            setPermission(value["miBizPacCancelInsuranceTypeOne"], miBizPacCancelInsuranceTypeOne);
                            break;
                        }
                    case "miBizPacCancelLoan":
                        {
                            setPermission(value["miBizPacCancelLoan"], miBizPacCancelLoan);
                            break;
                        }
                    case "miBizPacCancelContribution":
                        {
                            setPermission(value["miBizPacCancelContribution"], miBizPacCancelContribution);
                            break;
                        }
                    case "miBizPacCancelMedicalAid":
                        {
                            setPermission(value["miBizPacCancelMedicalAid"], miBizPacCancelMedicalAid);
                            break;
                        }
                    case "miBizPacConnectVehicleCancelCharge":
                        {
                            setPermission(value["miBizPacConnectVehicleCancelCharge"], miBizPacConnectVehicleCancelCharge);
                            break;
                        }
                    case "miBizPacCancelDriverContractCharge":
                        {
                            setPermission(value["miBizPacCancelDriverContractCharge"], miBizPacCancelDriverContractCharge);
                            break;
                        }
                    case "miBizPacCancelServiceStaffContractCharge":
                        {
                            setPermission(value["miBizPacCancelServiceStaffContractCharge"], miBizPacCancelServiceStaffContractCharge);
                            break;
                        }
                    case "miBizPacCancelVehicleRepairing":
                        {
                            setPermission(value["miBizPacCancelVehicleRepairing"], miBizPacCancelVehicleRepairing);
                            break;
                        }
                    case "miBizPacCancelVehicleExcess":
                        {
                            setPermission(value["miBizPacCancelVehicleExcess"], miBizPacCancelVehicleExcess);
                            break;
                        }
                }
            }
        }

        private void visibleWelfareMenu(ModulePermission value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (value[i].Name)
                {
                    case "miWelfareContributionEmpList":
                        {
                            setPermission(value["miWelfareContributionEmpList"], miWelfareContributionEmpList);
                            break;
                        }
                    case "miWelfareLoanAppList":
                        {
                            setPermission(value["miWelfareLoanAppList"], miWelfareLoanAppList);
                            break;
                        }
                    case "miWelfareMedicalAidListByEmp":
                        {
                            setPermission(value["miWelfareMedicalAidListByEmp"], miWelfareMedicalAidListByEmp);
                            break;
                        }
                    case "miWelfareMedicalAidListByHospital":
                        {
                            setPermission(value["miWelfareMedicalAidListByHospital"], miWelfareMedicalAidListByHospital);
                            break;
                        }
                    case "miWelfareSettingContribution":
                        {
                            setPermission(value["miWelfareSettingContribution"], miWelfareSettingContribution);
                            break;
                        }
                    case "miWelfareSettingHospital":
                        {
                            setPermission(value["miWelfareSettingHospital"], miWelfareSettingHospital);
                            break;
                        }
                    case "miWelfareSettingLoanReasonList":
                        {
                            setPermission(value["miWelfareSettingLoanReasonList"], miWelfareSettingLoanReasonList);
                            break;
                        }
                    case "miWelfareLoanReport":
                        {
                            setPermission(value["miWelfareLoanReport"], miWelfareLoanReport);
                            break;
                        }
                    case "miWelfareLoanByEmpReport":
                        {
                            setPermission(value["miWelfareLoanByEmpReport"], miWelfareLoanByEmpReport);
                            break;
                        }
                    case "miWelfareLoanOffsetReport":
                        {
                            setPermission(value["miWelfareLoanOffsetReport"], miWelfareLoanOffsetReport);
                            break;
                        }
                    case "miSSHospital":
                        {
                            setPermission(value["miSSHospital"], miSSHospital);
                            break;
                        }
                    case "miWelfareMedicalAidListInsurancePaid":
                        {
                            setPermission(value["miWelfareMedicalAidListInsurancePaid"], miWelfareMedicalAidListInsurancePaid);
                            break;
                        }
                    case "miWelfareMedicalAidReport":
                        {
                            setPermission(value["miWelfareMedicalAidReport"], miWelfareMedicalAidReport);
                            break;
                        }
                    case "miWelfareMedicalAidAttReport":
                        {
                            setPermission(value["miWelfareMedicalAidAttReport"], miWelfareMedicalAidAttReport);
                            break;
                        }
                    case "miWelfareMedicalAidNoAttReport":
                        {
                            setPermission(value["miWelfareMedicalAidNoAttReport"], miWelfareMedicalAidNoAttReport);
                            break;
                        }
                    case "miWelfareBenefit":
                        {
                            setPermission(value["miWelfareBenefit"], miWelfareBenefit);
                            break;
                        }
                }
            }
        }
        #endregion

        #region Public Method
        #region - Load LogIN -
        public void LoadMenu(ApplicationUserPermission value)
        {
            if (UserProfile.UserROLE == USER_ROLE.ADMIN)
            {
                visibleAll(true);
            }
            else
            {
                for (int i = 0; i < value.Count; i++)
                {
                    visibleModuleMenu(value[i]);
                }
            }
        }

        public void EnableNewCommand(bool value)
        {
            miFileNew.Enabled = value;
            toolBarMainMenu.Buttons[1].Enabled = value;
        }

        public void EnableDeleteCommand(bool value)
        {
            miFileDelete.Enabled = value;
            toolBarMainMenu.Buttons[2].Enabled = value;
        }

        public void EnableRefreshCommand(bool value)
        {
            miFileRefresh.Enabled = value;
            toolBarMainMenu.Buttons[4].Enabled = value;
        }

        public void EnablePrintCommand(bool value)
        {
            miFilePrint.Enabled = value;
            toolBarMainMenu.Buttons[5].Enabled = value;
        }

        public void EnableExitCommand(bool value)
        {
            miFileExit.Enabled = value;
            toolBarMainMenu.Buttons[7].Enabled = value;
        }
        #endregion

        #region - State Form -
        public void DisableCommand()
        {
            EnableNewCommand(false);
            EnableDeleteCommand(false);
            EnableRefreshCommand(false);
            EnablePrintCommand(false);
        }

        private void activeToolBarMainMenu()
        {
            if (this.ActiveMdiChild == null)
            {
                DisableCommand();
            }
            else
            {
                try
                {
                    FormBase activeChild = (FormBase)this.ActiveMdiChild;

                    EnableNewCommand(activeChild.MainMenuNewStatus);
                    EnableDeleteCommand(activeChild.MainMenuDeleteStatus);
                    EnableRefreshCommand(activeChild.MainMenuRefreshStatus);
                    EnablePrintCommand(activeChild.MainMenuPrintStatus);

                    activeChild = null;
                }
                catch
                {
                    DisableCommand();
                }
                finally
                { }
            }
        }

        private void showChildInfo()
        {
            if (this.ActiveMdiChild == null)
            {
                ClearMasterCount();
                stpFormID.Text = "";
            }
            else
            {
                try
                {
                    IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                    int rowCount = activeChild.MasterCount();
                    if (rowCount > 0)
                    {
                        stbMain.Panels[2].Text = rowCount.ToString() + " " + "ข้อมูล";
                    }
                    else
                    {
                        ClearMasterCount();
                    }

                    stpFormID.Text = "Form ID : " + activeChild.FormID();

                    activeChild = null;
                }
                catch
                {
                    ClearMasterCount();
                    stpFormID.Text = "";
                }
                finally
                { }
            }
        }
        #endregion

        #region - Base Event -
        public void InitForm()
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                    activeChild.InitForm();
                }
                catch
                { }
                finally
                { }
            }
        }

        public void DeleteForm()
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IDeleteMDIChildForm activeChild = (IDeleteMDIChildForm)this.ActiveMdiChild;
                    activeChild.DeleteForm();
                }
                catch
                { }
                finally
                { }
            }
        }

        public void RefreshForm()
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                    activeChild.RefreshForm();
                }
                catch
                { }
                finally
                { }
            }
        }

        public void PrintForm()
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                    activeChild.PrintForm();
                }
                finally
                { }
            }
        }

        public void ExitForm()
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    PresentationBase.CommonGUIBase.FormGUIBase formBase = (PresentationBase.CommonGUIBase.FormGUIBase)this.ActiveMdiChild;
                    if (formBase.IsMustQuestion)
                    {
                        switch (Message(MessageList.Question.Q0003))
                        {
                            case DialogResult.Yes:
                                {
                                    ISaveForm saveForm = (ISaveForm)this.ActiveMdiChild;
                                    if (saveForm.SaveForm())
                                    {
                                        IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                                        activeChild.ExitForm();
                                        activeChild = null;

                                        DisableCommand();
                                    }
                                    saveForm = null;
                                    break;
                                }
                            case DialogResult.No:
                                {
                                    IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                                    //PresentationBase.CommonGUIBase.IMDIChildForm activeChild = (PresentationBase.CommonGUIBase.IMDIChildForm)this.ActiveMdiChild;
                                    activeChild.ExitForm();
                                    activeChild = null;

                                    DisableCommand();
                                    break;
                                }
                            //								case DialogResult.Cancel :
                            //								{}
                        }
                    }
                    else
                    {
                        //IMDIChildForm activeChild = (IMDIChildForm)this.ActiveMdiChild;
                        PresentationBase.CommonGUIBase.IMDIChildFormGUI activeChild = (PresentationBase.CommonGUIBase.IMDIChildFormGUI)this.ActiveMdiChild;
                        activeChild.ExitForm();
                        activeChild = null;

                        DisableCommand();
                    }
                    formBase = null;
                }
                catch
                {
                    try
                    {
                        IMDIChildFormGUI activeChild = (IMDIChildFormGUI)this.ActiveMdiChild;
                        activeChild.ExitForm();
                    }
                    catch (Exception ex) { Debug.WriteLine(ex.ToString()); }
                }
                finally
                { }
            }
            else
            {
                Application.Exit();
            }

            activeToolBarMainMenu();
        }

        #endregion

        public void RefreshMasterCount()
        {
            showChildInfo();
        }

        public void ClearMasterCount()
        {
            stbMain.Panels[2].Text = "";
        } 
        #endregion

        #region Form event
        #region - form -
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            DisableCommand();
            stpUser.Text = string.Concat(stpUser.Text, UserProfile.UserID);
            if (ApplicationProfile.SERVER_NAME == "ICTDEV01" ||
                ApplicationProfile.SERVER_NAME == @"ICTDEVDB02\SECURED" ||
                ApplicationProfile.SERVER_NAME == @"PTBSVR01")
            {
                stpUserDomain.Text = ApplicationProfile.SERVER_NAME;
            }
            else
            {
                if (ApplicationProfile.DB_NAME.Equals("BTSDB"))
                {
                    stpUserDomain.Text = "PTB";
                }
                else
                {
                    stpUserDomain.Text = "PTB TEST";
                }
            }

            this.Text += " (BTS V" + ApplicationVersion.Version + ")";
        }
        #endregion

        #region - miFile -
        private void toolBarMainMenu_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (toolBarMainMenu.Buttons.IndexOf(e.Button))
            {
                case 1:
                    InitForm();
                    break;
                case 2:
                    DeleteForm();
                    break;
                case 4:
                    RefreshForm();
                    break;
                case 5:
                    PrintForm();
                    break;
                case 7:
                    ExitForm();
                    break;
            }
        }

        private void miFileNew_Click(object sender, System.EventArgs e)
        {
            InitForm();
        }

        private void miFileDelete_Click(object sender, System.EventArgs e)
        {
            DeleteForm();
        }

        private void miFileRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshForm();
        }

        private void miFilePrint_Click(object sender, System.EventArgs e)
        {
            PrintForm();
        }

        private void miFileExit_Click(object sender, System.EventArgs e)
        {
            ExitForm();
        }
        #endregion

        #region - miPI -
        private void miPIMasterPrefix_Click(object sender, System.EventArgs e)
        {
            frmPrefix objfrm = new frmPrefix();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterRace_Click(object sender, System.EventArgs e)
        {
            frmRace objfrm = new frmRace();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterNationality_Click(object sender, System.EventArgs e)
        {
            frmNationality objfrm = new frmNationality();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterReligion_Click(object sender, System.EventArgs e)
        {
            frmReligion objfrm = new frmReligion();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterOccupation_Click(object sender, System.EventArgs e)
        {
            frmOccupation objfrm = new frmOccupation();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterRelationship_Click(object sender, System.EventArgs e)
        {
            frmRelationship objfrm = new frmRelationship();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterBank_Click(object sender, System.EventArgs e)
        {
            frmBank objfrm = new frmBank();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterBloodGroup_Click(object sender, System.EventArgs e)
        {
            frmBloodGroup objfrm = new frmBloodGroup();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterPlaceProvince_Click(object sender, System.EventArgs e)
        {
            frmProvince objfrm = new frmProvince();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterPlaceDistrict_Click(object sender, System.EventArgs e)
        {
            frmDistrict objfrm = new frmDistrict();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterPlaceSubDistrict_Click(object sender, System.EventArgs e)
        {
            frmSubDistrict objfrm = new frmSubDistrict();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterPlaceStreet_Click(object sender, System.EventArgs e)
        {
            frmStreet objfrm = new frmStreet();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterEducationInstitute_Click(object sender, System.EventArgs e)
        {
            frmInstitute objfrm = new frmInstitute();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterEducationLevel_Click(object sender, System.EventArgs e)
        {
            frmEducationLevel objfrm = new frmEducationLevel();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIMasterEducationFaculty_Click(object sender, System.EventArgs e)
        {
            frmFaculty objfrm = new frmFaculty();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMasterEducationMajor_Click(object sender, System.EventArgs e)
        {
            frmMajor objfrm = new frmMajor();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMapCompany_Click(object sender, System.EventArgs e)
        {
            frmCompanyEntry objfrm = new frmCompanyEntry();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMapDepartment_Click(object sender, System.EventArgs e)
        {
            frmDepartment objfrm = new frmDepartment();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIMapSection_Click(object sender, System.EventArgs e)
        {
            frmSection objfrm = new frmSection();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIPositionPosition_Click(object sender, System.EventArgs e)
        {
            frmPosition objfrm = new frmPosition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIPositionTitle_Click(object sender, System.EventArgs e)
        {
            frmTitle objfrm = new frmTitle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPISpecialAllowance_Click(object sender, System.EventArgs e)
        {

        }

        private void miPIEmployeePI_Click(object sender, System.EventArgs e)
        {
            frmPI objfrm = new frmPI();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIEmployeeFormerPI_Click(object sender, System.EventArgs e)
        {
            frmFormerPI objfrm = new frmFormerPI();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIEmployeePrint_Click(object sender, System.EventArgs e)
        {
            frmListofPIAllData objfrm = new frmListofPIAllData();
            objfrm.Show();
        }

        private void miPIEmployeeMoveToFormerPI_Click(object sender, System.EventArgs e)
        {
            frmMovetoFormerPI objfrm = new frmMovetoFormerPI();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIEmployeeReport_Click(object sender, System.EventArgs e)
        {
            frmListofEmployee objfrm = new frmListofEmployee();
            objfrm.Show();
        }
        private void miPINonEmployeeReport_Click(object sender, System.EventArgs e)
        {
            frmListofNonEmployee objfrm = new frmListofNonEmployee();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIRetireStaff_Click(object sender, System.EventArgs e)
        {
            frmrptListOfRetireStaff objfrm = new frmrptListOfRetireStaff();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIEmployeePictureReport_Click(object sender, System.EventArgs e)
        {
            FrmListOfPictureEmployee objfrm = new FrmListOfPictureEmployee();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIPersonalData_Click(object sender, System.EventArgs e)
        {
            frmrptPersonnalData objfrm = new frmrptPersonnalData();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIExpiredDrivingLicense_Click(object sender, EventArgs e)
        {
            FrmReportExpiredDrivingLicense objfrm = new FrmReportExpiredDrivingLicense();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIProbationEmployee_Click(object sender, EventArgs e)
        {
            FrmReportProbationEmployee objfrm = new FrmReportProbationEmployee();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPISalaryEmployee_Click(object sender, EventArgs e)
        {
            FrmReportSalaryEmployee objfrm = new FrmReportSalaryEmployee();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIHireDate_Click(object sender, EventArgs e)
        {
            FrmReportHireDate objfrm = new FrmReportHireDate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miPIEmployeeSearch_Click(object sender, EventArgs e)
        {
            FrmReportEmployeeSearch objfrm = new FrmReportEmployeeSearch();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIExpiredIDCard_Click(object sender, EventArgs e)
        {
            FrmReportExpiredIDCard objfrm = new FrmReportExpiredIDCard();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPIEmployeeRegist_Click(object sender, EventArgs e)
        {
            FrmReportEmployeeRegist objfrm = new FrmReportEmployeeRegist();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miSpecialAllowance_Click(object sender, EventArgs e)
        {
            FrmSpecialAllowance objfrm = new FrmSpecialAllowance();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miSSHospital_Click(object sender, EventArgs e)
        {
            FrmSSHospital objfrm = new FrmSSHospital();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIEmployeeProvidentFundResign_Click(object sender, EventArgs e)
        {
            FrmReportResignProvidentFund objfrm = new FrmReportResignProvidentFund();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPIImportEmployeeSalary_Click(object sender, EventArgs e)
        {
            FrmImportEmployeeSalary objfrm = new FrmImportEmployeeSalary();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miPIPersonnalDataWelfare_Click(object sender, EventArgs e)
        {
            FrmReportPersonnalDataWelfare objFrm = new FrmReportPersonnalDataWelfare();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miPIEmployeeProvidentFund_Click(object sender, EventArgs e)
        {
            FrmReportProvidentFund objfrm = new FrmReportProvidentFund();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        #region 10/10/2019 BTS Improvement for new HR System add new function to export employee data
        private void miPIExportEmployeeData_Click(object sender, EventArgs e)
        {
            frmExportEmpData objfrm = new frmExportEmpData();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        #endregion

        #endregion

        #region - miVehicle -
        private void miVehicleSettingAccidentPlace_Click(object sender, System.EventArgs e)
        {
            frmPlace objfrm = new frmPlace();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleSettingPoliceStation_Click(object sender, System.EventArgs e)
        {
            frmPoliceStation objfrm = new frmPoliceStation();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleVendor_Click(object sender, System.EventArgs e)
        {
            frmVendor objfrm = new frmVendor();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleBrand_Click(object sender, System.EventArgs e)
        {
            frmBrand objfrm = new frmBrand();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleModel_Click(object sender, System.EventArgs e)
        {
            FrmModel objfrm = new FrmModel();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleColor_Click(object sender, System.EventArgs e)
        {
            frmColor objfrm = new frmColor();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleVehicle_Click(object sender, System.EventArgs e)
        {
            frmVehicle objfrm = new frmVehicle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleSpare_Click(object sender, System.EventArgs e)
        {
            frmListofSpareVehicleCurrently objfrm = new frmListofSpareVehicleCurrently();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleNoVehicleAssign_Click(object sender, EventArgs e)
        {
            frmrptNoVehicleAssign objfrm = new frmrptNoVehicleAssign();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleMainVehicle_Click(object sender, EventArgs e)
        {
            frmrptListofMainVehicle objfrm = new frmrptListofMainVehicle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleVehicleRepairedVehicle_Click(object sender, System.EventArgs e)
        {
            frmListofRepairedVehicle objfrm = new frmListofRepairedVehicle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleVehicleRepairedVehiclByFinishDate_Click(object sender, System.EventArgs e)
        {
            frmListofRepairedVehicleByFinishDate objfrm = new frmListofRepairedVehicleByFinishDate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleVehicleRepairingHistoryBySpareParts_Click(object sender, System.EventArgs e)
        {
            frmListofRepairingHistoryBySpareParts objfrm = new frmListofRepairingHistoryBySpareParts();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleVehicleRepairingHistoryByModel_Click(object sender, System.EventArgs e)
        {
            frmListofRepairingHistoryByModel objfrm = new frmListofRepairingHistoryByModel();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleVehicleRepairingHistoryByCustomer_Click(object sender, System.EventArgs e)
        {
            frmListofRepairingHistoryByCustomer objfrm = new frmListofRepairingHistoryByCustomer();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleVehicleRepairingHistoryByPlateNo_Click(object sender, System.EventArgs e)
        {
            frmListofRepairingHistoryByPlateNo objfrm = new frmListofRepairingHistoryByPlateNo();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miVehicleMaintenanceGarage_Click(object sender, System.EventArgs e)
        {
            frmGarage objfrm = new frmGarage();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleMaintenanceSpareParts_Click(object sender, System.EventArgs e)
        {
            frmSpareParts objfrm = new frmSpareParts();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleMaintenanceAccidentHistory_Click(object sender, System.EventArgs e)
        {
            frmVehicleAccident objfrm = new frmVehicleAccident();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleMaintenanceHistory_Click(object sender, System.EventArgs e)
        {
            frmVehicleMaintenance objfrm = new frmVehicleMaintenance();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miVehicleDocumentInsurance_Click(object sender, System.EventArgs e)
        {
            frmInsuranceCompany objfrm = new frmInsuranceCompany();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleDocumentMaintainInsuranceTypeOne_Click(object sender, System.EventArgs e)
        {
            Presentation.VehicleGUI.InsuranceTypeOneGUI.FrmCreateInsuranceTypeOne objfrm = new Presentation.VehicleGUI.InsuranceTypeOneGUI.FrmCreateInsuranceTypeOne();
            //frmMaintainInsuranceTypeOne objfrm = new frmMaintainInsuranceTypeOne();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleDocumentCreateInsuranceTypeOne_Click(object sender, System.EventArgs e)
        {
            Presentation.VehicleGUI.InsuranceTypeOneGUI.FrmVehicleInsuranceTypeOne objfrm = new Presentation.VehicleGUI.InsuranceTypeOneGUI.FrmVehicleInsuranceTypeOne();
            //frmCreateInsuranceTypeOne objfrm = new frmCreateInsuranceTypeOne();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleDocumentCompulsoryPlate_Click(object sender, System.EventArgs e)
        {
            frmCompulsoryInsuranceByPlate objfrm = new frmCompulsoryInsuranceByPlate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleDocumentCompulsoryMonth_Click(object sender, System.EventArgs e)
        {
            frmCompulsoryInsuranceByMonth objfrm = new frmCompulsoryInsuranceByMonth();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleDocumentCompulsoryInsurancenbyPlate_Click(object sender, System.EventArgs e)
        {
            frmListofCompulsoryInsurancebyPlate objfrm = new frmListofCompulsoryInsurancebyPlate();
            objfrm.Show();
        }


        private void miVehicleDocumentVehicleTaxPlateNo_Click(object sender, System.EventArgs e)
        {
            frmVehicleTaxByPlate objfrm = new frmVehicleTaxByPlate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleDocumentVehicleTaxMonth_Click(object sender, System.EventArgs e)
        {
            frmVehicleTaxByMonth objfrm = new frmVehicleTaxByMonth();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleMaintenancebyGarage_Click(object sender, System.EventArgs e)
        {
            frmListofVehicleMaintenanceByGarage objfrm = new frmListofVehicleMaintenanceByGarage();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleMaintenanceTotalAmountMaintenance_Click(object sender, System.EventArgs e)
        {
            frmrptTotalAmountMaintenance objfrm = new frmrptTotalAmountMaintenance();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleMaintenanceRepairingHistorybyVehicle_Click(object sender, System.EventArgs e)
        {
            frmListofRepairingHistorybyVehicle objfrm = new frmListofRepairingHistorybyVehicle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleAccident_Click(object sender, System.EventArgs e)
        {
            frmListofAccident objfrm = new frmListofAccident();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleAccidentByPlateNo_Click(object sender, System.EventArgs e)
        {
            frmListOfAccidentByPlateNo objfrm = new frmListOfAccidentByPlateNo();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleAccidentByEmpNo_Click(object sender, System.EventArgs e)
        {
            frmListOfAccidentByEmpNo objfrm = new frmListOfAccidentByEmpNo();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miVehicleAccidentExcessInsurance_Click(object sender, EventArgs e)
        {
            frmrptVehicleAccidentExcess objfrm = new frmrptVehicleAccidentExcess();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleMaintenanceExcessInsurance_Click(object sender, EventArgs e)
        {
            Presentation.VehicleGUI.ExcessInsurance.FrmExcessInsurance objfrm = new Presentation.VehicleGUI.ExcessInsurance.FrmExcessInsurance();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleAvgMaintenance_Click(object sender, EventArgs e)
        {
            FrmReportAvgMaintenance objfrm = new FrmReportAvgMaintenance();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miVehicleAvgMaintenanceCust_Click(object sender, EventArgs e)
        {
            FrmReportAvgMaintenanceCust objfrm = new FrmReportAvgMaintenanceCust();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miVehicleLeasing_Click(object sender, EventArgs e)
        {
            FrmLeasing objfrm = new FrmLeasing();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleBidder_Click(object sender, EventArgs e)
        {
            FrmBidder objfrm = new FrmBidder();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miVehicleInterestCost_Click(object sender, EventArgs e)
        {
            FrmInterestCost objfrm = new FrmInterestCost();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleProfitLost_Click(object sender, EventArgs e)
        {
            FrmProfitLost objfrm = new FrmProfitLost();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miProfitCalculation_Click(object sender, EventArgs e)
        {
            FrmProfitCalculation objfrm = new FrmProfitCalculation();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miVehicleSellingPlan_Click(object sender, EventArgs e)
        {
            FrmVehicleSellingPlan objfrm = new FrmVehicleSellingPlan();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miVehicleRepairingNoneTaxInvoice_Click(object sender, EventArgs e)
        {
            FrmRptVehicleRepairingNoneTaxInvoice objFrm = new FrmRptVehicleRepairingNoneTaxInvoice();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miVehicleLeasingCalculation_Click(object sender, EventArgs e)
        {
            FrmCalculationSearch objfrm = new FrmCalculationSearch();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miQuotation_Click(object sender, EventArgs e)
        {
            FrmVehicleQuotationList objfrm = new FrmVehicleQuotationList();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miPO_Click(object sender, EventArgs e)
        {
            FrmPurchaseOrderList objFrm = new FrmPurchaseOrderList();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miVehicleSellingPlanSellingPlan_Click(object sender, EventArgs e)
        {
            FrmSellingPlan objFrm = new FrmSellingPlan();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miVehicleSellingPlanVehicleSelling_Click(object sender, EventArgs e)
        {
            FrmReportVehicleSelling objFrm = new FrmReportVehicleSelling();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miVehicleLeasingCar_Click(object sender, EventArgs e)
        {
            FrmReportLeasingCar objFrm = new FrmReportLeasingCar();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        //Todsporn Modified 25/2/2020 PO. Discount
        private void miVehicleDiscountCar_Click(object sender, EventArgs e)
        {
            FrmReportDiscountCar objFrm = new FrmReportDiscountCar();
            objFrm.MdiParent = this;
            objFrm.Show();
        }





        private void miComparisonMaintenance_Click(object sender, EventArgs e)
        {
            FrmReportComparisonMaintenance objFrm = new FrmReportComparisonMaintenance();
            objFrm.MdiParent = this;
            objFrm.Show();
        }
        #endregion

        #region - miContract -

        private void miContractVehicle_Click(object sender, System.EventArgs e)
        {
            FrmVehicleContract objfrm = new FrmVehicleContract();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractOtherServiceStaft_Click(object sender, System.EventArgs e)
        {
            FrmOtherSSContract objfrm = new FrmOtherSSContract();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDriver_Click(object sender, System.EventArgs e)
        {
            FrmDriverContract objfrm = new FrmDriverContract();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingServiceStaffType_Click(object sender, System.EventArgs e)
        {
            frmServiceStaffType objfrm = new frmServiceStaffType();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingContractCancelReason_Click(object sender, System.EventArgs e)
        {
            frmContractCancelReason objfrm = new frmContractCancelReason();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractCustomerData_Click(object sender, System.EventArgs e)
        {
            frmCustomer objfrm = new frmCustomer();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractCustomerDepartment_Click(object sender, System.EventArgs e)
        {
            frmCustomerDept objfrm = new frmCustomerDept();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentApprove_Click(object sender, System.EventArgs e)
        {
            frmContractApprove objfrm = new frmContractApprove();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentCancel_Click(object sender, System.EventArgs e)
        {
            frmContractCancel objfrm = new frmContractCancel();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentServiceStaffMatchToContract_Click(object sender, System.EventArgs e)
        {
            frmServiceStaffMatchToContract objfrm = new frmServiceStaffMatchToContract();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentVDContractMatching_Click(object sender, System.EventArgs e)
        {
            frmVDContractMatch objfrm = new frmVDContractMatch();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentSpareDriver_Click(object sender, System.EventArgs e)
        {
            frmListOfSprerDriver objfrm = new frmListOfSprerDriver();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentServiceStaffContract_Click(object sender, System.EventArgs e)
        {
            frmListOfServiceStaffReport objfrm = new frmListOfServiceStaffReport();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentExpiredVehicle_Click(object sender, System.EventArgs e)
        {
            frmrptExpiredVehicleContractWithDriver objfrm = new frmrptExpiredVehicleContractWithDriver();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentExpiredDriver_Click(object sender, System.EventArgs e)
        {
            frmrptExpiredDriverContractWithVehicle objfrm = new frmrptExpiredDriverContractWithVehicle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentCustomerSpecialCharge_Click(object sender, EventArgs e)
        {
            FrmListofCustomerSpecialCharge objfrm = new FrmListofCustomerSpecialCharge();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miContractAssignmentHistoryServiceStaffAssignment_Click(object sender, System.EventArgs e)
        {
            FrmServiceStaffAssignment objfrm = new FrmServiceStaffAssignment();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractAssignmentHistoryVehicelAssignment_Click(object sender, System.EventArgs e)
        {
            FrmVehicleAssignment objfrm = new FrmVehicleAssignment();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractAssignmentHistorybyDriver_Click(object sender, System.EventArgs e)
        {
            frmrptAssignmentHistorybyDriver objfrm = new frmrptAssignmentHistorybyDriver();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractVehicleAssignmentbyPlate_Click(object sender, System.EventArgs e)
        {
            frmrptVehicleAssignmentbyPlate objfrm = new frmrptVehicleAssignmentbyPlate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentExpiredVehicleContract_Click(object sender, System.EventArgs e)
        {
            frmListofExpiredVehicleContract objfrm = new frmListofExpiredVehicleContract();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentLeasingHistoryOfActiveVehicle_Click(object sender, System.EventArgs e)
        {
            frmListofLeasingHistoryOfActiveVehicle objfrm = new frmListofLeasingHistoryOfActiveVehicle();
            objfrm.Show();
        }
        private void miContractDocumentInComplete_Click(object sender, System.EventArgs e)
        {
            frmListofInCompleteServiceStaffAssign objfrm = new frmListofInCompleteServiceStaffAssign();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentLongTermContract_Click(object sender, System.EventArgs e)
        {
            frmListOfDriverWithLongTermContractByDate objfrm = new frmListOfDriverWithLongTermContractByDate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentLongTermContractByDate_Click(object sender, System.EventArgs e)
        {
            //			frmListOfDriverWithLongTermContractByDate objfrm = new frmListOfDriverWithLongTermContractByDate();
            //			objfrm.MdiParent = this;
            //			objfrm.Show();
        }
        private void miContractVehicleCharge_Click(object sender, System.EventArgs e)
        {
            frmListofVehicleCharge objfrm = new frmListofVehicleCharge();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractVehicleMatchWithDriverCheckList_Click(object sender, System.EventArgs e)
        {
            frmListofVehicleMatchWithDriverCheckList objfrm = new frmListofVehicleMatchWithDriverCheckList();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractVehicleMatchWithDriver_Click(object sender, System.EventArgs e)
        {
            frmListofVehicleMatchWithDriver objfrm = new frmListofVehicleMatchWithDriver();
            objfrm.Show();
        }

        private void miContractContractMatchWithDriver_Click(object sender, System.EventArgs e)
        {
            frmrptListOfContractMatchWithDriver objfrm = new frmrptListOfContractMatchWithDriver();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDriverMatchWithVehicleCheckList_Click(object sender, System.EventArgs e)
        {
            frmListofDriverMatchWithVehicleCheckList objfrm = new frmListofDriverMatchWithVehicleCheckList();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractNoAccidentReward_Click(object sender, System.EventArgs e)
        {
            frmListForNoAccidentReward objfrm = new frmListForNoAccidentReward();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miContractSettingMinimumOTCharge_Click(object sender, EventArgs e)
        {
            FrmMinimumOTCharge objfrm = new FrmMinimumOTCharge();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingServiceStaffCharge_Click(object sender, EventArgs e)
        {
            FrmChargeRateByServiceStaffType objfrm = new FrmChargeRateByServiceStaffType();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingServiceStaffChargeContract_Click(object sender, EventArgs e)
        {
            FrmChargeRateByContract objfrm = new FrmChargeRateByContract();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingCustomerChargeAdjustDriver_Click(object sender, EventArgs e)
        {
            FrmCustomerChargeAdjust objfrm = new FrmCustomerChargeAdjust(true);
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingCustomerChargeAdjustOtherSS_Click(object sender, EventArgs e)
        {
            FrmCustomerChargeAdjust objfrm = new FrmCustomerChargeAdjust(false);
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentSpecialCharge_Click(object sender, EventArgs e)
        {
            FrmCustomerSpecialChargeCondition objfrm = new FrmCustomerSpecialChargeCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miContractDocumentChargeDiff_Click(object sender, EventArgs e)
        {
            FrmrptVehicleChargeDiff objfrm = new FrmrptVehicleChargeDiff();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentContractCarLeasing_Click(object sender, EventArgs e)
        {
            FrmReportContractCarLeasing objfrm = new FrmReportContractCarLeasing();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentContractDriverLeasing_Click(object sender, EventArgs e)
        {
            FrmReportContractDriverLeasing objfrm = new FrmReportContractDriverLeasing();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentContractServiceAgreement_Click(object sender, EventArgs e)
        {
            FrmContractServiceAgreement objfrm = new FrmContractServiceAgreement();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miContractDocumentPenaltyCharge_Click(object sender, EventArgs e)
        {
            FrmReportPenaltyCharge objfrm = new FrmReportPenaltyCharge();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractSettingCompensate_Click(object sender, EventArgs e)
        {
            FrmCompensateRate objfrm = new FrmCompensateRate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miContractDocumentRenewalNotice_Click(object sender, EventArgs e)
        {
            FrmRenewalNotice objFrm = new FrmRenewalNotice();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miContractDocumentDriverAgreement_Click(object sender, EventArgs e)
        {
            FrmReportDriverAgreement objFrm = new FrmReportDriverAgreement();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miContractDocumentCarAgreement_Click(object sender, EventArgs e)
        {
            FrmReportCarAgreement objFrm = new FrmReportCarAgreement();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miContractAssignmentHistoryVehicleSpareAssignment_Click(object sender, System.EventArgs e)
        {
            frmVehicleSpareAssignment objfrm = new frmVehicleSpareAssignment();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        //D21018-BTS Modification
        private void miContractDocumentCompanyAgreement_Click(object sender, EventArgs e)
        {
            FrmReportCarCompanyAgreement objFrm = new FrmReportCarCompanyAgreement();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        //D21018
        private void miContractListExpectedIncomeReport_Click(object sender, EventArgs e)
        {
            FrmrptContractListExpectedIncomeReport objFrm = new FrmrptContractListExpectedIncomeReport();
            objFrm.MdiParent = this;
            objFrm.Show();
        }
        #endregion

        #region - miAttendance -
        private void miTraditionalHolidayPattern_Click(object sender, System.EventArgs e)
        {
            frmTraditionalHolidayPattern objfrm = new frmTraditionalHolidayPattern();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miTraditionalHoliday_Click(object sender, System.EventArgs e)
        {
            frmTraditionalHoliday objfrm = new frmTraditionalHoliday();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWorkingTimeTable_Click(object sender, System.EventArgs e)
        {
            frmWorkingTimeTable objfrm = new frmWorkingTimeTable();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWorkingTimeCondition_Click(object sender, System.EventArgs e)
        {
            frmWorkingTimeCondition objfrm = new frmWorkingTimeCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miHolidayCondition_Click(object sender, System.EventArgs e)
        {
            frmHolidayCondition objfrm = new frmHolidayCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miGenEmployeeWorkSchedule_Click(object sender, System.EventArgs e)
        {
            FrmGenEmployeeWorkSchedule objfrm = new FrmGenEmployeeWorkSchedule();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miDriverExcess_Click(object sender, System.EventArgs e)
        {
            frmListofDriverExcess objfrm = new frmListofDriverExcess();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miDriverExcessDeductionByMonth_Click(object sender, System.EventArgs e)
        {
            frmListofDriverExcessDeductionByMonth objfrm = new frmListofDriverExcessDeductionByMonth();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miOTPattern_Click(object sender, System.EventArgs e)
        {
            frmOTPattern objfrm = new frmOTPattern();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miOTPatternGeneralCondition_Click(object sender, System.EventArgs e)
        {
            frmOTPatternGeneralCondition objfrm = new frmOTPatternGeneralCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miOTPatternSpecificCondition_Click(object sender, System.EventArgs e)
        {
            frmOTPatternSpecificCondition objfrm = new frmOTPatternSpecificCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeWorkSchedule_Click(object sender, System.EventArgs e)
        {
            frmEmployeeWorkAttendance objfrm = new frmEmployeeWorkAttendance();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miHolidayConditionSpecific_Click(object sender, System.EventArgs e)
        {
            frmHolidayConditionSpecific objfrm = new frmHolidayConditionSpecific();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        //		private void miAttendantGenTimeCard_Click(object sender, System.EventArgs e)
        //		{
        //			frmGenEmployeeTimeCard objfrm = new frmGenEmployeeTimeCard();
        //			objfrm.MdiParent = this;
        //			objfrm.Show();
        //		}
        //
        //		private void miAttendanceEmployeeTimeCard_Click(object sender, System.EventArgs e)
        //		{
        //			frmEmployeeTimeCard objfrm = new frmEmployeeTimeCard();
        //			objfrm.MdiParent = this;
        //			objfrm.Show();
        //		}


        private void miEmployeeTelephoneBenefit_Click(object sender, System.EventArgs e)
        {
            frmEmployeeTelephoneBenefit objfrm = new frmEmployeeTelephoneBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeMiscBenefit_Click(object sender, System.EventArgs e)
        {
            frmEmployeeMiscBenefit objfrm = new frmEmployeeMiscBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeMiscDeducttion_Click(object sender, System.EventArgs e)
        {
            frmEmployeeMiscDeduction objfrm = new frmEmployeeMiscDeduction();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miAttendanceEmployeeBenefit_Click(object sender, System.EventArgs e)
        {
            frmEmployeeBenefit objfrm = new frmEmployeeBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miOvertimeVariant_Click(object sender, System.EventArgs e)
        {
            frmOTVariant objfrm = new frmOTVariant();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miOtherBenefitRate_Click(object sender, System.EventArgs e)
        {
            frmOtherBenefitRate objfrm = new frmOtherBenefitRate();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miTelephoneCondition_Click(object sender, System.EventArgs e)
        {
            frmTelephoneCondition objfrm = new frmTelephoneCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miMealAllowance_Click(object sender, EventArgs e)
        {
            frmGenerateMealBenefit objfrm = new frmGenerateMealBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeExtraBenefit_Click(object sender, System.EventArgs e)
        {
            frmEmployeeExtraBenefit objfrm = new frmEmployeeExtraBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeExtraAGTBenefit_Click(object sender, System.EventArgs e)
        {
            frmEmployeeExtraAGTBenefit objfrm = new frmEmployeeExtraAGTBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miTimeRecordOfDriver_Click(object sender, System.EventArgs e)
        {
            frmListofTimeRecordOfDriver objfrm = new frmListofTimeRecordOfDriver();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miTimeCardForCharge_Click(object sender, System.EventArgs e)
        {
            frmTimeCardForCharge objfrm = new frmTimeCardForCharge();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miTimeCardForPayment_Click(object sender, System.EventArgs e)
        {
            frmTimeCardForPayment objfrm = new frmTimeCardForPayment();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miEmployeeOverNightTripBenefit_Click(object sender, EventArgs e)
        {
            FrmReportEmployeeOverNightTripBenefit objfrm = new FrmReportEmployeeOverNightTripBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();

        }

        private void miEmployeeFoodBenefit_Click(object sender, System.EventArgs e)
        {
            frmEmployeeFoodBenefit objfrm = new frmEmployeeFoodBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miTaxiCondition_Click(object sender, System.EventArgs e)
        {
            frmTaxiCondition objfrm = new frmTaxiCondition();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBenefitAdjustment_Click(object sender, System.EventArgs e)
        {
            frmEmployeeBenefitAdjustment objfrm = new frmEmployeeBenefitAdjustment();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miGenerateOtherBenefit_Click(object sender, System.EventArgs e)
        {
            frmGenerateOtherBenefit objfrm = new frmGenerateOtherBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWorkingTimeConditionSpecific_Click(object sender, System.EventArgs e)
        {
            frmWorkingTimeConditionSpecific objfrm = new frmWorkingTimeConditionSpecific();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miEmployeePrivateLeave_Click(object sender, System.EventArgs e)
        {
            frmEmployeePrivateLeave objfrm = new frmEmployeePrivateLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeSickLeave_Click(object sender, System.EventArgs e)
        {
            frmEmployeeSickLeave objfrm = new frmEmployeeSickLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miEmployeeSpecialLeave_Click(object sender, System.EventArgs e)
        {
            frmEmployeeSpecialLeave objfrm = new frmEmployeeSpecialLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miDisease_Click(object sender, System.EventArgs e)
        {
            frmDisease objfrm = new frmDisease();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miLeaveReason_Click(object sender, System.EventArgs e)
        {
            frmLeaveReason objfrm = new frmLeaveReason();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miSpecialLeave_Click(object sender, System.EventArgs e)
        {
            frmSpecialLeave objfrm = new frmSpecialLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miPayrollBenefit_Click(object sender, System.EventArgs e)
        {
            frmrptPayrollBenefit objfrm = new frmrptPayrollBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miNonPayrollBenefit_Click(object sender, System.EventArgs e)
        {
            frmrptNonPayrollBenefit objfrm = new frmrptNonPayrollBenefit();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miAttEmpAnnualLeave_Click(object sender, System.EventArgs e)
        {
            frmEmployeeAnnualLeave objfrm = new frmEmployeeAnnualLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miAttendanceSaleAnnualLeave_Click(object sender, System.EventArgs e)
        {
            frmSaleAnnualLeave objfrm = new frmSaleAnnualLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miAttendanceLeaveSickLeaveReport_Click(object sender, System.EventArgs e)
        {
            frmrptEmployeeSickLeave objfrm = new frmrptEmployeeSickLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miAttendanceLeavePrivateLeaveReport_Click(object sender, System.EventArgs e)
        {
            frmrptEmployeePrivateLeave objfrm = new frmrptEmployeePrivateLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miAttendanceLeaveSpecialLeaveReport_Click(object sender, EventArgs e)
        {
            FrmrptEmployeeSpecialLeave objfrm = new FrmrptEmployeeSpecialLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miAttendanceLeaveAnnualLeaveReport_Click(object sender, System.EventArgs e)
        {
            frmrptEmployeeAnnualLeave objfrm = new frmrptEmployeeAnnualLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miAttendanceLeaveEmployeeLeaveReport_Click(object sender, EventArgs e)
        {
            FrmrptEmployeeLeave objfrm = new FrmrptEmployeeLeave();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miGenAnnualLeaveDay_Click(object sender, System.EventArgs e)
        {
            frmGenerateAnnualLeaveDay objfrm = new frmGenerateAnnualLeaveDay();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miLeaveReport_Click(object sender, System.EventArgs e)
        {
            frmListOfMonthlyLeaveSummary objfrm = new frmListOfMonthlyLeaveSummary();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miAbsentRewardFamilyCarDriver_Click(object sender, System.EventArgs e)
        {
            frmListOfFamilyCarDriverReward objfrm = new frmListOfFamilyCarDriverReward();
            objfrm.MdiParent = this;
            objfrm.Show();
            //frmListOfFamilyCarDriverReward
        }

        private void miEmployeeReceiveGold_Click(object sender, EventArgs e)
        {
            frmrptEmployeeReceiveGold objfrm = new frmrptEmployeeReceiveGold();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        #endregion

        #region - miConfig -
        private void miConfigChangePassword_Click(object sender, System.EventArgs e)
        {
            frmLogIn objfrm = new frmLogIn();
            objfrm.ChangePasswordOnly = true;
            //			objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void mimiConfigUser_Click(object sender, System.EventArgs e)
        {
            frmApplicationUserProfile objfrm = new frmApplicationUserProfile();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void mimiConfigPermission_Click(object sender, System.EventArgs e)
        {
            frmPermission objfrm = new frmPermission();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        private void miConfigApplicationFunctionPermission_Click(object sender, System.EventArgs e)
        {
            frmListofApplicationFunctionPermission objfrm = new frmListofApplicationFunctionPermission();
            objfrm.Show();
        }
        private void miConfigKindOfStaff_Click(object sender, System.EventArgs e)
        {
            frmKindOfStaff objfrm = new frmKindOfStaff();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigMaritalStatus_Click(object sender, System.EventArgs e)
        {
            frmMaritalStatus objfrm = new frmMaritalStatus();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigMilitaryStatus_Click(object sender, System.EventArgs e)
        {
            frmMilitaryStatus objfrm = new frmMilitaryStatus();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigPositionGroup_Click(object sender, System.EventArgs e)
        {
            frmPositionGroup objfrm = new frmPositionGroup();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigPositionType_Click(object sender, System.EventArgs e)
        {
        }

        private void miConfigWorkingStatus_Click(object sender, System.EventArgs e)
        {
            frmWorkingStatus objfrm = new frmWorkingStatus();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigGasolineType_Click(object sender, System.EventArgs e)
        {
            frmGassolineType objfrm = new frmGassolineType();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigKindOfVehicle_Click(object sender, System.EventArgs e)
        {
            frmKindOfVehicle objfrm = new frmKindOfVehicle();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigModelType_Click(object sender, System.EventArgs e)
        {
            frmModelType objfrm = new frmModelType();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigVehicleStatus_Click(object sender, System.EventArgs e)
        {
            frmVehicleStatus objfrm = new frmVehicleStatus();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigVehicleTax_Click(object sender, System.EventArgs e)
        {
        }

        private void miConfigVehicleVAT_Click(object sender, System.EventArgs e)
        {
            frmVehicleVatStatus objfrm = new frmVehicleVatStatus();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigPaymentType_Click(object sender, System.EventArgs e)
        {
            frmPaymentType objfrm = new frmPaymentType();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigContractStatus_Click(object sender, System.EventArgs e)
        {
            frmContractStatus objfrm = new frmContractStatus();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigContractType_Click(object sender, System.EventArgs e)
        {
            frmContractType objfrm = new frmContractType();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miConfigCustomerGroup_Click(object sender, System.EventArgs e)
        {
            frmCustomerGroup objfrm = new frmCustomerGroup();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        #endregion

        #region - miBatchProcess -
        private void miBatchProcessDaily_Click(object sender, System.EventArgs e)
        {
            frmDailyProcess objfrm = new frmDailyProcess();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBatchProcessMonthly_Click(object sender, System.EventArgs e)
        {
        }

        private void miBatchProcessYearly_Click(object sender, System.EventArgs e)
        {
        }

        #endregion

        #region - miBizPacConnect -

        #region - Connect -
        private void miBizPacConnectVehicleRepairing_Click(object sender, EventArgs e)
        {
            FrmVehicleRepairingHistoryBP objfrm = new FrmVehicleRepairingHistoryBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectVehicleExcess_Click(object sender, EventArgs e)
        {
            FrmVehicleExcessBP objfrm = new FrmVehicleExcessBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectCompulsoryInsurance_Click(object sender, EventArgs e)
        {
            FrmCompulsoryInsuranceBP objfrm = new FrmCompulsoryInsuranceBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectInsuranceTypeOne_Click(object sender, EventArgs e)
        {
            FrmInsuranceTypeOneBP objfrm = new FrmInsuranceTypeOneBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectVehicleContractCharge_Click(object sender, EventArgs e)
        {
            FrmVehicleContractChargeBP objfrm = new FrmVehicleContractChargeBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectDriverContractCharge_Click(object sender, EventArgs e)
        {
            FrmDriverContractChargeBP objfrm = new FrmDriverContractChargeBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectServiceStaffContractCharge_Click(object sender, EventArgs e)
        {
            FrmOtherSSContractChargeBP objfrm = new FrmOtherSSContractChargeBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectLoan_Click(object sender, EventArgs e)
        {
            FrmLoanBizPac objfrm = new FrmLoanBizPac();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectMedicalAid_Click(object sender, EventArgs e)
        {
            FrmMedicalAidAttBizPac objfrm = new FrmMedicalAidAttBizPac();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        
        private void miBizPacConnectContribution_Click(object sender, EventArgs e)
        {
            FrmContributionBizPac objfrm = new FrmContributionBizPac();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

 

        private void miBizPacConnectContributionN_Click(object sender, EventArgs e)
        {
            FrmContributionBizPacNew objfrm = new FrmContributionBizPacNew();
            objfrm.MdiParent = this;
            objfrm.Show();

        }

        private void miBizPacConnectMedicalAidNoAtt_Click(object sender, EventArgs e)
        {
            FrmMedicalAidNoAttBizPac objfrm = new FrmMedicalAidNoAttBizPac();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miBPPreConnectCompulsory_Click(object sender, EventArgs e)
        {
            FrmCompulsoryInsuranceTR objfrm = new FrmCompulsoryInsuranceTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPPreConnectInsurance_Click(object sender, EventArgs e)
        {
            FrmInsuranceTypeOneTR objfrm = new FrmInsuranceTypeOneTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPPreConnectVehicleRepairing_Click(object sender, EventArgs e)
        {
            FrmVehicleRepairingHistoryTR objfrm = new FrmVehicleRepairingHistoryTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPPreConnectVehicleExcess_Click(object sender, EventArgs e)
        {
            FrmVehicleExcessTR objfrm = new FrmVehicleExcessTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miBPPreConnectVehicleCharge_Click(object sender, EventArgs e)
        {
            FrmVehicleContractChargeTR objfrm = new FrmVehicleContractChargeTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPPreConnectDriverCharge_Click(object sender, EventArgs e)
        {
            FrmDriverContractChargeTR objfrm = new FrmDriverContractChargeTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPPreConnectOfficeCharge_Click(object sender, EventArgs e)
        {
            FrmOtherSSContractChargeTR objfrm = new FrmOtherSSContractChargeTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miBPRerunVehicleCharge_Click(object sender, EventArgs e)
        {
            FrmVehicleSummaryIncome objfrm = new FrmVehicleSummaryIncome();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPRerunDriverCharge_Click(object sender, EventArgs e)
        {
            FrmDriverSummaryIncome objfrm = new FrmDriverSummaryIncome();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBPRerunOtherSSCharge_Click(object sender, EventArgs e)
        {
            FrmOtherSSSummaryIncome objfrm = new FrmOtherSSSummaryIncome();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        #endregion

        #region - Cancel -
        private void miBizPacCancelVehicleRepairing_Click(object sender, EventArgs e)
        {
            FrmVehicleRepairingHistoryCancelBP objfrm = new FrmVehicleRepairingHistoryCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacCancelVehicleExcess_Click(object sender, EventArgs e)
        {
            FrmVehicleExcessCancelBP objfrm = new FrmVehicleExcessCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacCancelCompulsoryInsurance_Click(object sender, EventArgs e)
        {
            FrmCompulsoryInsuranceCancelBP objfrm = new FrmCompulsoryInsuranceCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacCancelInsuranceTypeOne_Click(object sender, EventArgs e)
        {
            FrmInsuranceTypeOneCancelBP objfrm = new FrmInsuranceTypeOneCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacConnectVehicleCancelCharge_Click(object sender, EventArgs e)
        {
            FrmVehicleContractChargeCancelBP objfrm = new FrmVehicleContractChargeCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacCancelDriverContractCharge_Click(object sender, EventArgs e)
        {
            FrmDriverContractChargeCancelBP objfrm = new FrmDriverContractChargeCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacCancelServiceStaffContractCharge_Click(object sender, EventArgs e)
        {
            FrmServiceStaffContractChargeCancelBP objfrm = new FrmServiceStaffContractChargeCancelBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miBizPacCancelLoan_Click(object sender, EventArgs e)
        {
            Form frm = new FrmCancelBizLoan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void miBizPacCancelContribution_Click(object sender, EventArgs e)
        {
            Form frm = new FrmCancelBizContribution();
            frm.MdiParent = this;
            frm.Show();
        }

        private void miBizPacCancelMedicalAid_Click(object sender, EventArgs e)
        {
            Form frm = new FrmCancelBizMedicalAid();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion
        #endregion

        #region - miWelfare -
        private void miWelfareSettingHospital_Click(object sender, EventArgs e)
        {
            FrmHospital objfrm = new FrmHospital();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareSettingContribution_Click(object sender, EventArgs e)
        {
            FrmContribution objfrm = new FrmContribution();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareSettingLoanReasonList_Click(object sender, EventArgs e)
        {
            FrmLoanResonLst objfrm = new FrmLoanResonLst();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareMedicalAidListByEmp_Click(object sender, EventArgs e)
        {
            FrmMedicalAidLstByEmp objfrm = new FrmMedicalAidLstByEmp();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareMedicalAidListByHospital_Click(object sender, EventArgs e)
        {
            FrmMedicalAidLstByHospital objfrm = new FrmMedicalAidLstByHospital();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareContributionEmpList_Click(object sender, EventArgs e)
        {
            FrmContributionEmpLst objfrm = new FrmContributionEmpLst();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareLoanAppList_Click(object sender, EventArgs e)
        {
            FrmLoanApplicationLst objfrm = new FrmLoanApplicationLst();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miWelfareMedicalAidReport_Click(object sender, EventArgs e)
        {
            //report
            FrmReportMedicalAid objfrm = new FrmReportMedicalAid();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareMedicalAidAttReport_Click(object sender, EventArgs e)
        {
            //report
            FrmReportMedicalAidAtt objfrm = new FrmReportMedicalAidAtt();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareMedicalAidNoAttReport_Click(object sender, EventArgs e)
        {
            //report
            FrmReportMedicalAidNoAtt objfrm = new FrmReportMedicalAidNoAtt();
            objfrm.MdiParent = this;
            objfrm.Show();

        }

        private void miWelfareContributionReport_Click(object sender, EventArgs e)
        {
            //report
            FrmReportContributionApp objfrm = new FrmReportContributionApp();
            objfrm.MdiParent = this;
            objfrm.Show();

        }

        private void miWelfareLoanReport_Click(object sender, EventArgs e)
        {
            //report
            FrmReportLoanApp objfrm = new FrmReportLoanApp();
            objfrm.MdiParent = this;
            objfrm.Show();
        }


        private void miWelfareLoanByEmpReport_Click(object sender, EventArgs e)
        {
            FrmReportLoanNewApp objfrm = new FrmReportLoanNewApp();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareLoanOffsetReport_Click(object sender, EventArgs e)
        {
            FrmReportLoanOffset objfrm = new FrmReportLoanOffset();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miWelfareMedicalAidListInsurancePaid_Click(object sender, EventArgs e)
        {
            FrmReportMedicalAidInsurancePaid objFrm = new FrmReportMedicalAidInsurancePaid();
            objFrm.MdiParent = this;
            objFrm.Show();
        }

        private void miWelfareBenefit_Click(object sender, EventArgs e)
        {
            frmWelfareBenefit objFrm = new frmWelfareBenefit();
            objFrm.MdiParent = this;
            objFrm.Show();
        }
        #endregion

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            frmLogIn objfrm = new frmLogIn();
            objfrm.Show();
        }

        private void frmMain_Closed(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_MdiChildActivate(object sender, System.EventArgs e)
        {
            showChildInfo();
            activeToolBarMainMenu();
        }

        private void OnLeafMenuClicked(object sender, EventArgs e)
        {
            MenuContain obj = (MenuContain)((System.Windows.Forms.MenuItem)sender).Tag;
            if (obj.ChildFrm == null || obj.ChildFrm.IsDisposed)
            {
                System.Runtime.Remoting.ObjectHandle objh;
                objh = Activator.CreateInstance(obj.LoadAssemblyName, obj.LoadClassName);
                obj.Frm = objh.Unwrap();
                obj.ChildFrm.MdiParent = this;
                obj.ChildFrm.Show();
            }
            else
            {
                obj.ChildFrm.Focus();
                obj.ChildFrm.Activate();
            }
        }

        private void LoadMenuContain()
        {
            string assemblyName = "Report";
            MenuContain obj = new MenuContain();
            obj.LoadAssemblyName = assemblyName;
            obj.LoadClassName = "Report.Contract.FrmListNoAccidentReward";
            miContractNoAccidentReward.Tag = obj;
        }
        #endregion

        #region 6/2/2018 BTS Improvement change transfer data from BizPac to SAP
        private void miSAPPreConnectCompulsory_Click(object sender, EventArgs e)
        {
            FrmCompulsoryInsuranceTR objfrm = new FrmCompulsoryInsuranceTR();
            objfrm.MdiParent = this;
            objfrm.Show();
        }

        private void miSAPConnectCompulsoryInsurance_Click(object sender, EventArgs e)
        {
            FrmCompulsoryInsuranceBP objfrm = new FrmCompulsoryInsuranceBP();
            objfrm.MdiParent = this;
            objfrm.Show();
        }
        #endregion       

    }
}