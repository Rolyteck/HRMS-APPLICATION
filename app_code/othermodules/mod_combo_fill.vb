Imports Microsoft.VisualBasic

Public Module mod_combo_fill

    Public Sub FillDeprMethod(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Straight Line", "Straight Line"))
        cb.Items.Add(New ListItem("Reducing Balance", "Reducing Balance"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillAppraisalObj(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Exceeded", "Exceeded"))
        cb.Items.Add(New ListItem("Reached", "Reached"))
        cb.Items.Add(New ListItem("Below", "Below"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub Fillfrquency(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("MONTHLY", "MONTHLY"))
        cb.Items.Add(New ListItem("FORTHNIGHTLY", "FORTHNIGHTLY"))
        cb.Items.Add(New ListItem("WEEKLY", "WEEKLY"))
        cb.Items.Add(New ListItem("ANNUALLY", "ANNUALLY"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillLeaveType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Annual Leave", "Annual Leave"))
        cb.Items.Add(New ListItem("Casual Leave", "Casual Leave"))
        cb.Items.Add(New ListItem("Medical Leave", "Medical Leave"))
        cb.Items.Add(New ListItem("Exam leave", "Exam leave"))
        cb.Items.Add(New ListItem("Maternity Leave", "Maternity Leave"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillLeavePurpose(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Illness/injury/incapacitation of requesting employee", "1"))
        cb.Items.Add(New ListItem("Medical/dental/optical examination of requesting employee", "2"))
        cb.Items.Add(New ListItem("Care of family member, including medical/dental/optical examination of family member, or bereavement", "3"))
        cb.Items.Add(New ListItem("Care of family member with a serious health condition", "4"))
        cb.Items.Add(New ListItem("Other", "5"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillAppraisalOption(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("APPRAISEE", "1"))
        cb.Items.Add(New ListItem("APPRAISER", "2"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub


    Public Sub FillLeaveDuration(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Day", "Day"))
        cb.Items.Add(New ListItem("Days", "Days"))
        cb.Items.Add(New ListItem("Months", "Months"))
        cb.Items.Add(New ListItem("Year", "Year"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillExcelOption(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("MS Word", "WordForWindows"))
        cb.Items.Add(New ListItem("MS Excel 97-2000", "Excel"))
        cb.Items.Add(New ListItem("MS Excel 97-2000 (Data Only)", "ExcelRecord"))
        cb.Items.Add(New ListItem("Rich Text Format", "RichText"))

        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillAppraisalGrade(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Excellent", "Excellent"))
        cb.Items.Add(New ListItem("Very Good", "Very Good"))
        cb.Items.Add(New ListItem("Good", "Good"))
        cb.Items.Add(New ListItem("Average", "Average"))
        cb.Items.Add(New ListItem("Below Average", "Below Average"))
        cb.Items.Add(New ListItem("Poor", "Poor"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillDisciplineType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Oral Warning", "Oral Warning"))
        cb.Items.Add(New ListItem("Caution", "Caution"))
        cb.Items.Add(New ListItem("1st Written Warning", "1st Written Warning"))
        cb.Items.Add(New ListItem("2nd Written Warning", "2nd Written Warning"))
        cb.Items.Add(New ListItem("3rd Written Warning", "3rd Written Warning"))
        cb.Items.Add(New ListItem("Termination", "Termination"))
        cb.Items.Add(New ListItem("Working Suspension", "Working Suspension"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub


    	
    Public Sub FillSex(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Male", "Male"))
        cb.Items.Add(New ListItem("Female", "Female"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub



    Public Sub FillPayMonthYr(ByVal cb As DropDownList)

        Dim P As Long
        cb.Items.Clear()
        For P = -52 To 12
            cb.Items.Add(FormatDate2(DateAdd(DateInterval.Month, P, Today.Date)))
        Next P
        cb.Items.Insert(0, New ListItem(FormatDate2(Today.Date), FormatDate2(Today.Date)))
    End Sub

    Public Sub Fillstate(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Abuja (FCT)", "Abuja (FCT)"))
        cb.Items.Add(New ListItem("Abia", "Abia"))
        cb.Items.Add(New ListItem("Adamawa", "Adamawa"))
        cb.Items.Add(New ListItem("Akwa Ibom", "Akwa Ibom"))
        cb.Items.Add(New ListItem("Anambra", "Anambra"))
        cb.Items.Add(New ListItem("Bauchi", "Bauchi"))
        cb.Items.Add(New ListItem("Bayelsa", "Bayelsa"))
        cb.Items.Add(New ListItem("Benue", "Benue"))
        cb.Items.Add(New ListItem("Borno", "Borno"))
        cb.Items.Add(New ListItem("Cross River", "Cross River"))
        cb.Items.Add(New ListItem("Ebonyi", "Ebonyi"))
        cb.Items.Add(New ListItem("Edo", "Edo"))
        cb.Items.Add(New ListItem("Ekiti", "Ekiti"))
        cb.Items.Add(New ListItem("Enugu", "Enugu"))
        cb.Items.Add(New ListItem("Gombe", "Gombe"))
        cb.Items.Add(New ListItem("Imo", "Imo"))
        cb.Items.Add(New ListItem("Jigawa", "Jigawa"))
        cb.Items.Add(New ListItem("Kaduna", "Kaduna"))
        cb.Items.Add(New ListItem("Kano", "Kano"))
        cb.Items.Add(New ListItem("Katsina", "Katsina"))
        cb.Items.Add(New ListItem("Kebbi Birni", "Kebbi Birni"))
        cb.Items.Add(New ListItem("Kogi", "Kogi"))
        cb.Items.Add(New ListItem("Kwara", "Kwara"))
        cb.Items.Add(New ListItem("Lagos", "Lagos"))
        cb.Items.Add(New ListItem("Nassarawa", "Nassarawa"))
        cb.Items.Add(New ListItem("Niger", "Niger"))
        cb.Items.Add(New ListItem("Ogun", "Ogun"))
        cb.Items.Add(New ListItem("Ondo", "Ondo"))
        cb.Items.Add(New ListItem("Osun", "Osun"))
        cb.Items.Add(New ListItem("Oyo", "Oyo"))
        cb.Items.Add(New ListItem("Plateau", "Plateau"))
        cb.Items.Add(New ListItem("Rivers", "Rivers"))
        cb.Items.Add(New ListItem("Delta", "Delta"))
        cb.Items.Add(New ListItem("Sokoto", "Sokoto"))
        cb.Items.Add(New ListItem("Taraba", "Taraba"))
        cb.Items.Add(New ListItem("Yobe", "Yobe"))
        cb.Items.Add(New ListItem("Zamfara", "Zamfara"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillMonthDay(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("January", "1"))
        cb.Items.Add(New ListItem("February", "2"))
        cb.Items.Add(New ListItem("Match", "3"))
        cb.Items.Add(New ListItem("April", "4"))
        cb.Items.Add(New ListItem("May", "5"))
        cb.Items.Add(New ListItem("June", "6"))
        cb.Items.Add(New ListItem("July", "7"))
        cb.Items.Add(New ListItem("August", "8"))
        cb.Items.Add(New ListItem("September", "9"))
        cb.Items.Add(New ListItem("October", "10"))
        cb.Items.Add(New ListItem("November", "11"))
        cb.Items.Add(New ListItem("December", "12"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillMaritalStatus(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("SINGLE", "SINGLE"))
        cb.Items.Add(New ListItem("MARRIED", "MARRIED"))
        cb.Items.Add(New ListItem("WIDOW", "WIDOW"))
        cb.Items.Add(New ListItem("DIVORCED", "DIVORCED"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillPFA(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("AIICO Pension Managers Limited", "001"))
        cb.Items.Add(New ListItem("Amana Capital Pension Limited", "002"))
        cb.Items.Add(New ListItem("APT Pension Fund Managers Limited", "003"))
        cb.Items.Add(New ListItem("ARM Pension Managers Limited", "004"))
        cb.Items.Add(New ListItem("Citi Trust Pension Managers Limited", "005"))
        cb.Items.Add(New ListItem("CRIB Pension Fund Managers Limited", "006"))
        cb.Items.Add(New ListItem("CrusaderSterling Pensions Limited", "007"))
        cb.Items.Add(New ListItem("Evergreen Pensions Limited", "008"))
        cb.Items.Add(New ListItem("Fidelity Pension Managers", "009"))
        cb.Items.Add(New ListItem("First Guarantee Pension Limited", "010"))
        cb.Items.Add(New ListItem("Future Unity Glanvils Pensions Limited", "011"))
        cb.Items.Add(New ListItem("IEI-Anchor Pension Managers Limited", "012"))
        cb.Items.Add(New ListItem("IGI Pension Fund Managers Limited", "013"))
        cb.Items.Add(New ListItem("Leadway Pensure PFA Limited", "014"))
        cb.Items.Add(New ListItem("Legacy Pension Managers Limited", "015"))
        cb.Items.Add(New ListItem("NLPC Pension Fund Administrators Limited", "016"))
        cb.Items.Add(New ListItem("OAK Pensions Limited", "017"))
        cb.Items.Add(New ListItem("Penman Pensions Limited", "018"))
        cb.Items.Add(New ListItem("Pensions Alliance Limited", "019"))
        cb.Items.Add(New ListItem("Premium Pension Limited", "020"))
        cb.Items.Add(New ListItem("Royal Trust Pension Fund Administrator Limited", "021"))
        cb.Items.Add(New ListItem("Sigma Pensions Limited", "022"))
        cb.Items.Add(New ListItem("Stanbic IBTC Pension Managers Limited", "023"))
        cb.Items.Add(New ListItem("Trustfund Pensions Plc", "024"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillHMO(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Mediplan Health Organisation", "001"))
        cb.Items.Add(New ListItem("Songhai Health Organisation", "002"))
        cb.Items.Add(New ListItem("Royal Exchange", "003"))
        cb.Items.Add(New ListItem("Anchor International Company Limited", "004"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillDurationFreq(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("DAYS", "DAYS"))
        cb.Items.Add(New ListItem("HOURS", "HOURS"))
        cb.Items.Add(New ListItem("WEEKS", "WEEKS"))
        cb.Items.Add(New ListItem("MONTHS", "MONTHS"))
        cb.Items.Add(New ListItem("YEARS", "YEARS"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillTitle(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Miss", "Miss"))
        cb.Items.Add(New ListItem("Master", "Master"))
        cb.Items.Add(New ListItem("Mr.", "Mr."))
        cb.Items.Add(New ListItem("Mrs.", "Mrs."))
        cb.Items.Add(New ListItem("Chief", "Chief"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub


    Public Sub FillOptionType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("DIRECT", "0"))
        cb.Items.Add(New ListItem("AGENT/BROKERS", "1"))
        cb.Items.Add(New ListItem("OTHERS", "2"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillLoanType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("LOAN", "LOAN"))
        cb.Items.Add(New ListItem("ADVANCE", "ADVANCE"))
        cb.Items.Add(New ListItem("UPFRONT", "UPFRONT"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillPayGroupType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("MNAGEMENT", "1"))
        cb.Items.Add(New ListItem("SENIOR", "2"))
        cb.Items.Add(New ListItem("JUNIOR", "3"))
        cb.Items.Add(New ListItem("CASUAL", "4"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillTypesPay(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("MAIN", "MAIN"))
        cb.Items.Add(New ListItem("SUPPLEMENTARY", "SUPPLEMENTARY"))
    End Sub
    Public Sub FillPayGroup(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.PaySheet) = (New cls_paysheets).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "paysheet"
        cb.DataValueField = "SheetID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillFamilies(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.PurFamily) = (New cls_families).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "FamilyName"
        cb.DataValueField = "FamilyID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillTrainCadre(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.TrainingCadre) = (New cls_TrainingCadres).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Name"
        cb.DataValueField = "code"
        cb.DataBind()
    End Sub
    Public Sub FillPaymentType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Cash", "Cash"))
        cb.Items.Add(New ListItem("Cheque", "Cheque"))
        cb.Items.Add(New ListItem("PD Cheque", "PD Cheque"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillTransType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("GROSS", "GROSS"))
        cb.Items.Add(New ListItem("PART GROSS", "PART GROSS"))
        cb.Items.Add(New ListItem("NET", "NET"))
        cb.Items.Add(New ListItem("PART NET", "PART NET"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillCurrency(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("₦ NAIRA", "NAIRA"))
        cb.Items.Add(New ListItem("$ DOLLAR", "DOLLAR"))
        cb.Items.Add(New ListItem("£ POUND", "POUND"))
        cb.Items.Add(New ListItem("€ EURO", "EURO"))
        cb.Items.Add(New ListItem("₣ FRANC", "FRANC"))
        cb.Items.Add(New ListItem("¥ YEN", "YEN"))
    End Sub


    Public Sub FillBankNames(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("ACCESS BANK PLC", "ACCESS BANK PLC"))
        cb.Items.Add(New ListItem("DIAMOND BANK PLC", "DIAMOND BANK PLC"))
        cb.Items.Add(New ListItem("ECOBANK NIGERIA PLC", "ECOBANK NIGERIA PLC"))
        cb.Items.Add(New ListItem("ENTERPRISE BANK", "ENTERPRISE BANK"))
        cb.Items.Add(New ListItem("EQUITORIAL TRUST BANK LIMITED", "EQUITORIAL TRUST BANK LIMITED"))
        cb.Items.Add(New ListItem("FIDELITY BANK PLC", "FIDELITY BANK PLC"))
        cb.Items.Add(New ListItem("FINBANK PLC", "FINBANK PLC"))
        cb.Items.Add(New ListItem("FIRST BANK OF NIGERIA PLC", "FIRST BANK OF NIGERIA PLC"))
        cb.Items.Add(New ListItem("FIRST CITY MONUMENT BANK PLC", "FIRST CITY MONUMENT BANK PLC"))
        cb.Items.Add(New ListItem("INTERCONTINENTAL BANK PLC", "INTERCONTINENTAL BANK PLC"))
        cb.Items.Add(New ListItem("KEYSTONE BANK", "KEYSTONE BANK"))
        cb.Items.Add(New ListItem("MAINSTREET BANK", "MAINSTREET BANK"))
        cb.Items.Add(New ListItem("NIGERIA INTERNATIONAL BANK (CITIGROUP)", "NIGERIA INTERNATIONAL BANK (CITIGROUP)"))
        cb.Items.Add(New ListItem("OCEANIC BANK INTERNATIONAL PLC", "OCEANIC BANK INTERNATIONAL PLC"))
        cb.Items.Add(New ListItem("SKYE BANK PLC", "SKYE BANK PLC"))
        cb.Items.Add(New ListItem("STANBIC-IBTC BANK PLC", "STANBIC-IBTC BANK PLC"))
        cb.Items.Add(New ListItem("STANDARD CHARTERED BANK NIGERIA LTD", "STANDARD CHARTERED BANK NIGERIA LTD"))
        cb.Items.Add(New ListItem("STERLING BANK PLC", "STERLING BANK PLC"))
        cb.Items.Add(New ListItem("UNION BANK OF NIGERIA PLC", "UNION BANK OF NIGERIA PLC"))
        cb.Items.Add(New ListItem("UNITED BANK FOR AFRICA PLC", "UNITED BANK FOR AFRICA PLC"))
        cb.Items.Add(New ListItem("UNITY BANK PLC", "UNITY BANK PLC"))
        cb.Items.Add(New ListItem("WEMA BANK PLC", "WEMA BANK PLC"))
        cb.Items.Add(New ListItem("ZENITH BANK PLC", "ZENITH BANK PLC"))
        cb.Items.Add(New ListItem("GTBANK  PLC", "GTBANK PLC"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillBankPayGrp(ByVal cb As DropDownList)
        cb.Items.Clear()
        Select Case settings.COMPANY_ABREV
            Case "SAP"
                cb.Items.Add(New ListItem("ACCESS BANK PLC", "01"))
                cb.Items.Add(New ListItem("STANBIC IBTC BANK", "02"))
                cb.Items.Add(New ListItem("GTBANK PLC - EXECUTIVE", "03"))
                cb.Items.Add(New ListItem("GTBANK PLC - MANAGEMENT", "04"))
                cb.Items.Add(New ListItem("GTBANK PLC - OTHERS", "05"))
                cb.Items.Add(New ListItem("GTBANK PLC - ABUJA", "06"))
                cb.Items.Add(New ListItem("FIRST BANK PLC - MD", "07"))
                cb.Items.Add(New ListItem("FIRST BANK PLC - HQ STAFFS", "08"))

            Case "GIP"
                cb.Items.Add(New ListItem("ACCESS BANK PLC", "09"))
                cb.Items.Add(New ListItem("STANBIC IBTC BANK", "10"))
                cb.Items.Add(New ListItem("GTBANK PLC - EXECUTIVE", "03"))
                cb.Items.Add(New ListItem("GTBANK PLC - MANAGEMENT", "04"))
                cb.Items.Add(New ListItem("GTBANK PLC - OTHERS", "05"))
                cb.Items.Add(New ListItem("GTBANK PLC - ABUJA", "06"))
                cb.Items.Add(New ListItem("FIRST BANK PLC - MD", "07"))
                cb.Items.Add(New ListItem("FIRST BANK PLC - HQ STAFFS", "08"))

            Case "Fin"
                cb.Items.Add(New ListItem("FCMB BANK PLC", "09"))
                cb.Items.Add(New ListItem("JAIZ BANK PLC", "10"))

            Case Else
                cb.Items.Add(New ListItem("ACCESS BANK PLC", "01"))
                cb.Items.Add(New ListItem("STANBIC IBTC BANK", "02"))
                cb.Items.Add(New ListItem("GTBANK PLC - EXECUTIVE", "03"))
                cb.Items.Add(New ListItem("GTBANK PLC - MANAGEMENT", "04"))
                cb.Items.Add(New ListItem("GTBANK PLC - OTHERS", "05"))
                cb.Items.Add(New ListItem("GTBANK PLC - ABUJA", "06"))
                cb.Items.Add(New ListItem("FIRST BANK PLC - MD", "07"))
                cb.Items.Add(New ListItem("FIRST BANK PLC - HQ STAFFS", "08"))

        End Select

    End Sub
    Public Sub FillAppClassification(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("CUSTOMER PERSPECTIVE", "01"))
        cb.Items.Add(New ListItem("BUSINESS PERSPECTIVE", "02"))
        cb.Items.Add(New ListItem("FINANCIAL PERSPECTIVE", "03"))
        cb.Items.Add(New ListItem("SELF DEVELOPMENT", "04"))
    End Sub
    Public Sub FillCoverType(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Comprehensive", "COMPREHENSIVE"))
        cb.Items.Add(New ListItem("Third Party Fire", "THIRD PARTY, FIRE"))
        cb.Items.Add(New ListItem("Third Party Only", "THIRD PARTY ONLY"))
        cb.Items.Add(New ListItem("Act", "ACT"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillVehUsage(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Pleasure & Business", "Pleasure"))
        cb.Items.Add(New ListItem("Private", "Private"))
        cb.Items.Add(New ListItem("Commercial", "Commercial"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillBizSource(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("Direct Business", "Direct"))
        cb.Items.Add(New ListItem("Accepted Business", "Accepted"))
        cb.Items.Add(New ListItem("Bank Business", "Bank"))
        cb.Items.Add(New ListItem("Bank Subsidiary", "BankSub"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillDepts(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.HPayDept) = (New cls_HpayDepts).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Name"
        cb.DataValueField = "Code"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillUnits(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.HPaySection) = (New cls_HpayUnits).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Section"
        cb.DataValueField = "Code"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillGradelevel(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.HPayGrade) = (New cls_Hpaygrades).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Name"
        cb.DataValueField = "Name"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillVPayDeductions(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.VPayDeduction) = (New cls_VpayDeductions).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "DedName"
        cb.DataValueField = "DedID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillAllowances(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.AllowanceID) = (New cls_AllowancesID).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "AllowName"
        cb.DataValueField = "AllowID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillDeductions(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.DeductionID) = (New cls_DeductionsID).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "DedName"
        cb.DataValueField = "DedID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillGradelevel2(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.HPayGrade) = (New cls_Hpaygrades).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Name"
        cb.DataValueField = "ID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillSteps(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.HRStep) = (New cls_Hrsteps).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Name"
        cb.DataValueField = "Name"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub FillRegions(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.Region) = (New cls_Regions).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Region"
        cb.DataValueField = "RegionID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub
    Public Sub fillCategories(ByVal cb As DropDownList)
        Dim obj As List(Of Hrms3.PurCategory) = (New cls_Categories).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "CategoryName"
        cb.DataValueField = "CategoryID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillBranches(ByVal cb As DropDownList, Optional ByVal ShowLimited As Boolean = False)
        Dim obj As New List(Of Hrms3.Branch)

        Dim B As New cls_Branches

        If ShowLimited Then
            obj = B.SelectByUserID(getLoggedOnUserID)
        Else
            obj = B.SelectAll()
        End If
        cb.DataSource = obj
        cb.DataTextField = "Description"
        cb.DataValueField = "BranchID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("ALL", "ALL"))
    End Sub

    Public Sub FillStates(ByVal cb As DropDownList)
        FillBranches(cb)
        'Dim obj As List(Of Hrms3.Branch) = cls_Branches.SelectAll
        'cb.DataSource = obj
        'cb.DataTextField = "State"
        'cb.DataValueField = "StateID"
        'cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillRelationship(ByVal cb As DropDownList)
        cb.Items.Clear()
        cb.Items.Add(New ListItem("FATHER", "FATHER"))
        cb.Items.Add(New ListItem("MOTHER", "MOTHER"))
        cb.Items.Add(New ListItem("SON", "SON"))
        cb.Items.Add(New ListItem("DAUGHTER", "DAUGHTER"))
        cb.Items.Add(New ListItem("BLOOD BROTHER", "BLOOD BROTHER"))
        cb.Items.Add(New ListItem("BLOOD SISTER", "BLOOD SISTER"))
        cb.Items.Add(New ListItem("COUSIN", "COUSIN"))
        cb.Items.Add(New ListItem("UNCLE", "UNCLE"))
        cb.Items.Add(New ListItem("NEPHEW", "NEPHEW"))
        cb.Items.Add(New ListItem("RELATION", "RELATION"))
        cb.Items.Add(New ListItem("WIFE", "WIFE"))
        cb.Items.Add(New ListItem("HUSBAND", "HUSBAND"))
        cb.Items.Add(New ListItem("FATHER-IN-LAW", "FATHER-IN-LAW"))
        cb.Items.Add(New ListItem("MOTHER-IN-LAW", "MOTHER-IN-LAW"))
        cb.Items.Add(New ListItem("FRIENDS", "FRIENDS"))
        cb.Items.Add(New ListItem("CREDIT INTEREST", "CREDIT INTEREST"))
        cb.Items.Add(New ListItem("NIECE", "NIECE"))
        cb.Items.Add(New ListItem("FIANCE", "FIANCE"))
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

    Public Sub FillCompanies(ByVal cb As DropDownList, ByVal CompanyType As String)
        'Dim obj As List(Of Hrms3.Company) = cls_Companies.SelectThisByType(CompanyType)
        Dim obj As List(Of Hrms3.Company) = (New cls_Companies).SelectAll
        cb.DataSource = obj
        cb.DataTextField = "Company"
        cb.DataValueField = "CompanyID"
        cb.DataBind()
        cb.Items.Insert(0, New ListItem("- select -", "NULL"))
    End Sub

End Module
