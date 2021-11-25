using System;
using System.Collections;

using Entity.CommonEntity;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

using Facade.CommonFacade;

using FarPoint.Win.Spread.CellType;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using Flow.PiFlow;

namespace Facade.PiFacade
{
	public class PIFacade : CommonPIFacadeBase
	{
		#region Private Variable
		protected PIFlow flowPI;
		private AgeFlow flowAge;
		#endregion

		#region - Property for Change -
		public bool EmployeeChange
		{
			set{flowPI.EmployeeChange = value;}
			get{return flowPI.EmployeeChange;}
		}
		public bool EmployeeParentChange
		{
			set{flowPI.EmployeeParentChange = value;}
			get{return flowPI.EmployeeParentChange;}
		}
		public bool ReferencePersonChange
		{
			set{flowPI.ReferencePersonChange = value;}
			get{return flowPI.ReferencePersonChange;}
		}
		public bool GuarantorChange
		{
			set{flowPI.GuarantorChange = value;}
			get{return flowPI.GuarantorChange;}
		}
		public bool EmployeeAddressChange
		{
			set{flowPI.EmployeeAddressChange = value;}
			get{return flowPI.EmployeeAddressChange;}
		}
		public bool EmployeeSpouseChange
		{
			set{flowPI.EmployeeSpouseChange = value;}
			get{return flowPI.EmployeeSpouseChange;}
		}
		public bool EmployeeWorkBackgroundChange
		{
			set{flowPI.EmployeeWorkBackgroundChange = value;}
			get{return flowPI.EmployeeWorkBackgroundChange;}
		}
		public bool EmployeeChildrenListChange
		{
			set{flowPI.EmployeeChildrenListChange = value;}
			get{return flowPI.EmployeeChildrenListChange;}
		}
		public bool EmployeeEducationChange
		{
			set{flowPI.EmployeeEducationChange = value;}
			get{return flowPI.EmployeeEducationChange;}
		}
		public bool SalaryChange
		{
			set{flowPI.SalaryChange = value;}
			get{return flowPI.SalaryChange;}
		}
		public bool EmployeeSpecialAllowanceChange
		{
			set{flowPI.EmployeeSpecialAllowanceChange = value;}
			get{return flowPI.EmployeeSpecialAllowanceChange;}
		}
		#endregion
		
		#region - Property -
			public EmployeeInfo EmployeeInfo
			{
				get{return flowPI.AEmployeeInfo;}
			}
			public Address CurrentAddress
			{
				get{return flowPI.AEmployeeAddress.ACurrentAddress;}
				set{flowPI.AEmployeeAddress.ACurrentAddress = value;}
			}
			public Address RegisterAddress
			{
				get{return flowPI.AEmployeeAddress.ARegisterAddress;}
				set{flowPI.AEmployeeAddress.ARegisterAddress = value;}
			}
			public EmployeeFather EmployeeFather
			{
				get{return flowPI.AEmployeeFather;}
			}
			public EmployeeMother EmployeeMother
			{
				get{return flowPI.AEmployeeMother;}
			}
			public ReferencePerson ReferencePerson
			{
				get{return flowPI.AReferencePerson;}
				set{flowPI.AReferencePerson = value;}
			}
			public ReferencePerson Guarantor
			{
				get{return flowPI.AGuarantor;}
				set{flowPI.AGuarantor = value;}
			}
			public EmployeeSpouse EmployeeSpouse
			{
				get{return flowPI.AEmployeeSpouse;}
			}
			public Salary Salary
			{
				get{return flowPI.ASalary;}
			}
			public EmployeeEducation EmployeeEducation
			{
				get{return flowPI.AEmployeeEducation;}
			}
			public EmployeeWorkBackground EmployeeWorkBackground
			{
				get{return flowPI.AEmployeeWorkBackground;}
			}
			public EmployeeChildrenList EmployeeChildrenList
			{
				get{return flowPI.AEmployeeChildrenList;}
			}
			public EmployeeSpecialAllowance EmployeeSpecialAllowance
			{
				get{return flowPI.AEmployeeSpecialAllowance;}
			}
		#endregion
		
		#region - DataSource -
		public ArrayList DataSourcePrefix
		{
			get
			{
				PrefixFlow flowPrefix = new PrefixFlow();
				PrefixList prefixList = new PrefixList();
				flowPrefix.FillMTBList(prefixList);
				return prefixList.GetArrayList();
			}
		}
		public ArrayList DataSourceDepartment
		{
			get
			{
				DepartmentFlow flowDepartment = new DepartmentFlow();
				DepartmentList departmentList = new DepartmentList(GetCompany());
				flowDepartment.FillDepartment(ref departmentList);
				flowDepartment = null;
				return departmentList.GetArrayList();
			}
		}
		public ArrayList DataSourceSection(Department value)
		{
			SectionFlow flowSection = new SectionFlow();
			SectionList sectionList = new SectionList(GetCompany());
			Section section = new Section();
			section.ADepartment = value;
			flowSection.FillSectionList(ref sectionList, section);
			flowSection = null;
			return sectionList.GetArrayList();
		}
		public ArrayList DataSourcePosition
		{
			get
			{
				PositionFlow flowPosition = new PositionFlow();
				PositionList positionList = new PositionList(GetCompany());
				flowPosition.FillPosition(ref positionList);
				flowPosition = null;
				return positionList.GetArrayList();
			}
		}
		public ArrayList DataSourceTitle
		{
			get
			{
				TitleFlow flowTitle = new TitleFlow();
				TitleList titleList = new TitleList(GetCompany());
				flowTitle.FillTitle(ref titleList);
				flowTitle = null;
				return titleList.GetArrayList();
			}
		}
		public ArrayList DataSourceKinddOfStaff
		{
			get
			{
				KindOfStaffFlow flowKindOfStaff = new KindOfStaffFlow();
				KindOfStaffList kindOfStaffList = new KindOfStaffList(GetCompany());
				flowKindOfStaff.FillMTBList(kindOfStaffList);
				flowKindOfStaff = null;
				return kindOfStaffList.GetArrayList();
			}
		}
		public string[] DataSourceShiftType
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.ShiftTypeArray;
			}
		}
		public string[] DataSourceKindOfOT
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.KindOfOTTypeArray;
			}
		}
		public ArrayList DataSourceWorkingStatus
		{
			get
			{
				WorkingStatusFlow flowWorkingStatus = new WorkingStatusFlow();
				WorkingStatusList workingStatusList = new WorkingStatusList(GetCompany());
				flowWorkingStatus.FillMTBList(workingStatusList);
				flowWorkingStatus = null;
				return workingStatusList.GetArrayList();
			}
		}
		
		public string[] DataSourceGender
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.GenderTypeArray;
			}
		}
		public ArrayList DataSourceBloodGroup
		{
			get
			{
				BloodGroupFlow flowBloodGroup = new BloodGroupFlow();
				BloodGroupList bloodGroupList = new BloodGroupList();
				flowBloodGroup.FillMTBList(bloodGroupList);
				flowBloodGroup = null;
				return bloodGroupList.GetArrayList();
			}
		}
		public ArrayList DataSourceRace
		{
			get
			{
				RaceFlow flowRace = new RaceFlow();
				RaceList raceList = new RaceList();
				flowRace.FillMTBList(raceList);
				flowRace = null;
				return raceList.GetArrayList();
			}
		}
		public ArrayList DataSourceNationality
		{
			get
			{
				NationalityFlow flowNationality = new NationalityFlow();
				NationalityList nationalityList = new NationalityList();
				flowNationality.FillMTBList(nationalityList);
				flowNationality = null;
				return nationalityList.GetArrayList();
			}
		}
		public ArrayList DataSourceReligion
		{
			get
			{
				ReligionFlow flowReligion = new ReligionFlow();
				ReligionList religionList = new ReligionList();
				flowReligion.FillMTBList(religionList);
				flowReligion = null;
				return religionList.GetArrayList();
			}
		}
		public ArrayList DataSourceMaritalStatus
		{
			get
			{
				MaritalStatusFlow flowMaritalStatus = new MaritalStatusFlow();
				MaritalStatusList maritalStatusList = new MaritalStatusList();
				flowMaritalStatus.FillMTBList(maritalStatusList);
				flowMaritalStatus = null;
				return maritalStatusList.GetArrayList();
			}
		}
		public ArrayList DataSourceMilitaryStatus
		{
			get
			{
				MilitaryStatusFlow flowMilitaryStatus = new MilitaryStatusFlow();
				MilitaryStatusList militaryStatusList = new MilitaryStatusList();
				flowMilitaryStatus.FillMTBList(militaryStatusList);
				flowMilitaryStatus = null;
				return militaryStatusList.GetArrayList();
			}
		}
		public string[] DataSourceDriverLicenseType
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.DriverLicenseTypeArray;
			}
		}
		public ArrayList DataSourceStreet
		{
			get
			{
				StreetFlow flowStreet = new StreetFlow();
				StreetList streetList = new StreetList();
				flowStreet.FillMTBList(streetList);
				flowStreet= null;
				return streetList.GetArrayList();
			}
		}
		public ArrayList DataSourceSubDistrict
		{
			get
			{
				SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
				SubDistrictList subDistrictList = new SubDistrictList();
				flowSubDistrict.FillMTBList(subDistrictList);
				flowSubDistrict= null;
				return subDistrictList.GetArrayList();
			}
		}
		public ArrayList DataSourceDistrict
		{
			get
			{
				DistrictFlow flowDistrict = new DistrictFlow();
				DistrictList districtList = new DistrictList();
				flowDistrict.FillMTBList(districtList);
				flowDistrict= null;
				return districtList.GetArrayList();
			}
		}
		public ArrayList DataSourceProvince
		{
			get
			{
				ProvinceFlow flowProvince = new ProvinceFlow();
				ProvinceList provinceList = new ProvinceList();
				flowProvince.FillMTBList(provinceList);
				flowProvince= null;
				return provinceList.GetArrayList();
			}
		}
		public ArrayList DataSourceOccupation
		{
			get
			{
				OccupationFlow flowOccupation = new OccupationFlow();
				OccupationList occupationList = new OccupationList();
				flowOccupation.FillMTBList(occupationList);
				flowOccupation = null;
				return occupationList.GetArrayList();
			}
		}
		public ArrayList DataSourceRelationShip
		{
			get
			{
				RelationshipFlow flowRelationShip = new RelationshipFlow();
				RelationshipList relationShipList = new RelationshipList();
				flowRelationShip.FillMTBList(relationShipList);
				flowRelationShip = null;
				return relationShipList.GetArrayList();
			}
		}
		public ArrayList DataSourceBank
		{
			get
			{
				BankFlow flowBank = new BankFlow();
				BankList bankList = new BankList();
				flowBank.FillMTBList(bankList);
				flowBank = null;
				return bankList.GetArrayList();
			}
		}

        public ArrayList DataSourceSSHospital
        {
            get
            {
                SSHospitalFlow flow = new SSHospitalFlow();
                SSHospitalList list = new SSHospitalList();
                flow.FillMTBList(list);
                flow = null;
                return list.GetArrayList();
            }
        }
		#endregion

		# region -Datasource Farpoint-
		//Education
		public ComboBoxCellType DataSourceInstitute
		{
			get
			{
				InstituteFlow flowMTB = new InstituteFlow();
				InstituteList mtbList = new InstituteList();

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				Institute institute;

				for(int i=0; i<mtbList.Count; i++)
				{					
					items[i] = ((DualFieldBase)mtbList.BaseGet(i)).AName.Thai;
					itemData[i] = ((DualFieldBase)mtbList.BaseGet(i)).Code;

					institute = (Institute)mtbList.BaseGet(i);
					InstituteList.Add(institute.AName.Thai, institute);
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		public ComboBoxCellType DataSourceEducationlevel
		{
			get
			{
				EducationLevelFlow flowMTB = new EducationLevelFlow();
				EducationLevelList mtbList = new EducationLevelList();

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];
				
				EducationLevel educationLevel;

				for(int i=0; i<mtbList.Count; i++)
				{
					items[i] = ((DualFieldBase)mtbList.BaseGet(i)).AName.Thai;
					itemData[i] = ((DualFieldBase)mtbList.BaseGet(i)).Code;

					educationLevel = (EducationLevel)mtbList.BaseGet(i);
					EducationLevelList.Add(educationLevel.AName.Thai, educationLevel);
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;


				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		public ComboBoxCellType DataSourceFaculty
		{
			get
			{
				FacultyFlow flowMTB = new FacultyFlow();
				FacultyList mtbList = new FacultyList();

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				Faculty faculty;

				for(int i=0; i<mtbList.Count; i++)
				{
					items[i] = ((DualFieldBase)mtbList.BaseGet(i)).AName.Thai;
					itemData[i] = ((DualFieldBase)mtbList.BaseGet(i)).Code;

					faculty = (Faculty)mtbList.BaseGet(i);
					FacultyList.Add(faculty.AName.Thai, faculty);

				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;


				items = null;
				itemData = null;

				return comboBox;			
			}
		}

		public ComboBoxCellType DataSourceMajor
		{
			get
			{
				MajorFlow flowMTB = new MajorFlow();
				MajorList mtbList = new MajorList();

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				Major major;

				for(int i=0; i<mtbList.Count; i++)
				{
					items[i] = ((DualFieldBase)mtbList.BaseGet(i)).AName.Thai;
					itemData[i] = ((DualFieldBase)mtbList.BaseGet(i)).Code;

					major = (Major)mtbList.BaseGet(i);
					MajorList.Add(major.AName.Thai, major);
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;


				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		public ComboBoxCellType DataSourceEducationStatus
		{
			get
			{
				CTFunction ctFunction = new CTFunction();

				string[] items;
				string[] itemData;

				items = ctFunction.EducationStatusType;
				itemData = ctFunction.EducationStatusType;

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				EducationStausCode = itemData;

				items = null;
				itemData = null;

				return comboBox;
			}
		}
		//Spouse
		public ComboBoxCellType DataSourcePrefixSpouse
		{
			get
			{
				PrefixFlow flowMTB = new PrefixFlow();
				PrefixList mtbList = new PrefixList();

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				for(int i=0; i<mtbList.Count; i++)
				{
					items[i] = ((SingleFieldBase)mtbList.BaseGet(i)).Name;
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				PrefixSpouseCode = itemData;

				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		public ComboBoxCellType DataSourceGenderSpouse
		{
			get
			{
				CTFunction ctFunction = new CTFunction();

				string[] items;
				string[] itemData;

				items = ctFunction.GenderTypeArray;
				itemData = ctFunction.GenderTypeArray;

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				GenderSpouseCode = itemData;

				items = null;
				itemData = null;

				return comboBox;
			}
		}
		public ComboBoxCellType DataSourceOccupationSpouse
		{
			get
			{
				OccupationFlow flowMTB = new OccupationFlow();
				OccupationList mtbList = new OccupationList();

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				for(int i=0; i<mtbList.Count; i++)
				{
					items[i] = ((SingleFieldBase)mtbList.BaseGet(i)).Name;
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				OccupationSpouseCode = itemData;

				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		public ComboBoxCellType DataSourceSpecialAllowance
		{
			get
			{
				SpecialAllowanceFlow flowMTB = new SpecialAllowanceFlow();
				SpecialAllowanceList mtbList = new SpecialAllowanceList(GetCompany());

				flowMTB.FillSpecialAllowance(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				SpecialAllowance specialAllowance;

				for(int i=0; i<mtbList.Count; i++)
				{
					items[i] = ((SpecialAllowance)mtbList.BaseGet(i)).AName.Thai;
					itemData[i] = ((SpecialAllowance)mtbList.BaseGet(i)).Code;

					specialAllowance = (SpecialAllowance)mtbList.BaseGet(i);
					SpecialAllowanceList.Add(specialAllowance.AName.Thai, specialAllowance);
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;


				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		#endregion -Datasource Farpoint-

		# region -Get Data Farpoint-
		public InstituteList InstituteList;
		public EducationLevelList EducationLevelList;
		public FacultyList FacultyList;
		public MajorList MajorList;
		public string[] EducationStausCode;
		public string[] PrefixSpouseCode;
		public string[] GenderSpouseCode;
		public string[] OccupationSpouseCode;
		public SpecialAllowanceList SpecialAllowanceList;
		#endregion -Get Data Farpoint-

        #region Constructor
        public PIFacade()
        {
            BaseNew();

            flowAge = new AgeFlow();
            InstituteList = new InstituteList();
            EducationLevelList = new EducationLevelList();
            FacultyList = new FacultyList();
            MajorList = new MajorList();
            SpecialAllowanceList = new SpecialAllowanceList(GetCompany());
        }
        #endregion

        #region Protected Method
        protected virtual void BaseNew()
        {
            flowPI = new PIFlow(GetCompany());
        } 
        #endregion

        #region Public Method
        public void ReNew()
        {
            flowPI.ReNew(GetCompany());
        }

        public bool CheckAnnualLeaveControl(DateTime hireDate)
        {
            return flowPI.CheckAnnualLeaveControl(hireDate, GetCompany());
        }

        public bool CheckAnnualLeaveDay(Employee value)
        {
            return flowPI.CheckAnnualLeaveDay(value);
        }

        public bool CheckServiceStaffAssignment(Employee value)
        {
            return flowPI.CheckServiceStaffAssignment(value);
        }

        public YearMonth CalculateAge(DateTime birthDate)
        {
            return flowAge.CalculateAge(birthDate);
        }

        public Age CalculateAge(DateTime fromDate, DateTime toDate)
        {
            return flowAge.CalculateFineAge(fromDate, toDate);
        }

        public string CalculateAgeYY(DateTime birthDate)
        {
            YearMonth YearMonth = CalculateAge(birthDate);
            string result = YearMonth.Year.ToString();
            return result;
        }
        public string CalculateAgeMM(DateTime birthDate)
        {
            YearMonth YearMonth = CalculateAge(birthDate);
            string result = string.Format("{0:D2}", YearMonth.Month);
            return result;
        }
        public string CalculateAgeDecimal(DateTime birthDate)
        {
            YearMonth YearMonth = CalculateAge(birthDate);
            string result = YearMonth.Year.ToString();
            result += ".";
            result += string.Format("{0:D2}", YearMonth.Month);
            return result;
        }
        public void changeAll(bool change)
        {
            flowPI.changeAll(change);
        }

        public bool Display()
        {
            return flowPI.Display();
        }

        public void ClearAllList()
        {
            flowPI.ClearAllList();
        }

        public bool Insert()
        {
            return flowPI.Insert();
        }

        public bool Update()
        {
            return flowPI.Update();
        }

        public bool Delete()
        {
            return flowPI.Delete();
        } 

        #endregion
	}
}
