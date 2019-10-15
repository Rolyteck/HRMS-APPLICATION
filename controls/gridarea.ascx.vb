
Partial Class webroot_web_controls_gridarea
    Inherits System.Web.UI.UserControl

    Protected _GroupName As String = "und_policy"
    Protected _hideFilterBox As Boolean = False
    Protected _allowPaging As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            mod_combo_fill.FillPayGroup(Me.cdbPaysheet)
            Me.cdbPaysheet.SelectedIndex = 0
        End If

        mod_ui_helpers.MakeDatePicker(Me.Page, Me.txtDate1, IIf(IsDate(Me.txtDate1.Text), Me.txtDate1.Text, Today.AddMonths(-12)))
        mod_ui_helpers.MakeDatePicker(Me.Page, Me.txtDate2, IIf(IsDate(Me.txtDate2.Text), Me.txtDate2.Text, Today))

        'If Not Page.IsPostBack Then
        SetupGridView()
        'End If

        mod_ui_helpers.MakeDropDownJs(Me.Page, Me.cbSearchOn)

        If _GroupName Like "admin*" Then
            '"admin_region_list", "admin_branch_list", "admin_class_list",      
            '"admin_subclass_list", "admin_mktstaff_list", "admin_mktunit_list", 
            '"admin_party_list", "admin_role_list", "admin_user_list"

            Me.txtDate1.Visible = False
            Me.txtDate2.Visible = False
            Me.lbBtwAnd.Visible = False
            Me.lbBetween.Visible = False
            Me.ExpandingImageButton1.Expanded = False
        ElseIf _GroupName = "hr_employees" Then
            Me.txtDate1.Visible = False
            Me.txtDate2.Visible = False
            Me.lbBtwAnd.Visible = False
            Me.lbBetween.Visible = False
        ElseIf _GroupName = "hr_employees_enquiries" Then
            Me.txtDate1.Visible = False
            Me.txtDate2.Visible = False
            Me.lbBtwAnd.Visible = False
            Me.lbBetween.Visible = False

        ElseIf _GroupName = "training_needs_list" Then
            Me.txtDate1.Visible = True
            Me.txtDate2.Visible = True
            Me.lbBtwAnd.Visible = True
            Me.lbBetween.Visible = True
            Me.ExpandingImageButton1.Expanded = True
        ElseIf _GroupName = "loans_list" Then
            Me.txtDate1.Visible = True
            Me.txtDate2.Visible = True
            Me.lbBtwAnd.Visible = True
            Me.lbBetween.Visible = True
            Me.ExpandingImageButton1.Expanded = True
        End If
        If _hideFilterBox = True Then
            Me.filterBoxDiv.Visible = False
        End If

    End Sub

    Protected Sub cmdFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFilter.Click

        If settings.COMPANY_ABREV = "Fin" Then
        Else
            Select Case _GroupName
                Case "monthly_pay_process", "hr_employees", "hr_pay_rolls", "monthly_variance_list", "view_variance_list"

                    If Val(Me.cdbPaysheet.SelectedValue) = 1 Then
                        Dim AD As Hrms3.User = (New cls_Users).SelectByUsername(mod_main.getLoggedOnUsername())
                        If AD.SecQuestion <> "SUPER" Then
                            CheckCurrUserPermission(PermissionEnum.PAYROLL_MGT_MODULE_ACCESS)
                        End If
                    End If

                Case Else

            End Select
        End If


        GridView1.DataBind()
    End Sub

    Protected Sub pagerDdl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GridView1.PageSize = sender.SelectedValue
        GridView1.DataBind()
    End Sub

#Region "Private Functions"

    Private Sub InitGridView(ByVal EntityName As String, Optional ByVal Buttons As List(Of Control) = Nothing, Optional ByVal PageSize As Integer = 15, Optional ByVal ShowHeader As Boolean = True, _
        Optional ByVal ShowFooter As Boolean = True, Optional ByVal AllowPaging As Boolean = True)
        With Me.GridView1
            If Not .Page.IsPostBack Then
                .PageSize = PageSize
                .ShowHeader = ShowHeader
                .ShowFooter = False 'ShowFooter
                .AllowPaging = _allowPaging ' AllowPaging
                .AutoGenerateColumns = False
                .RowStyle.CssClass = "GridRowStyle"
                .AlternatingRowStyle.CssClass = "GridAltRowStyle"
                .SelectedRowStyle.CssClass = "GriectedRowStyle"
                .HeaderStyle.CssClass = "GridHeaderStyle"
                .FooterStyle.CssClass = "GridFooterStyle"
                .PagerStyle.CssClass = "GridPagerStyle"
                .EditRowStyle.CssClass = "GridEditRowStyle"
                .EmptyDataRowStyle.CssClass = "GridEmptyDataRowStyle"
                .GridLines = GridLines.Horizontal
                .CssClass = "GridStyle"
                .CellPadding = 1
                .CellSpacing = 0
                .Attributes.Add("Entity-Name", EntityName)
                .Style.Add("border-collapse", "separate")
                '.Height = Unit.Parse("100px")
                '.Width = Unit.Parse("100px")
                'With .PagerSettings
                '    .FirstPageText = "&lt; First"
                '    .LastPageText = "Last &gt;"
                '    .Mode = PagerButtons.NextPreviousFirstLast
                '    .NextPageText = "Next &gt;"
                '    .Position = PagerPosition.Bottom
                '    .PreviousPageText = "&lt; Prev"
                '    .Visible = True
                'End With
            End If

            MakePagerAndFooter()
        End With
    End Sub

    Public Sub SetupGridView()
        With Me.GridView1
            .Columns.Clear()
            Dim editPath As String = Request.RawUrl.Remove(Request.RawUrl.LastIndexOf("/") + 1) '"/webroot/web/modules/"
            Select Case _GroupName
              
                Case "admin_region_list"
                    editPath += AppendQueryString("company_regions_new.aspx")
                    Me.InitGridView("Regions", Nothing, 25)
                    AppendSelectField(GridView, "", "RegionID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Code", "RegionID", "RegionID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Region", "Region", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Manager", "Manager", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Address", "Address", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Region Name", "Region"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "RegionID"))
                    End If
                    .DataSource = (New cls_Regions).SelectAll()

                Case "admin_families_list"
                    editPath += AppendQueryString("families_new.aspx")
                    Me.InitGridView("Regions", Nothing, 25)
                    AppendSelectField(GridView, "", "familyID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Code", "familyID", "familyID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Family Name", "familyName", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem(" Name", "familyname"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "familyID"))
                    End If
                    .DataSource = (New cls_families).SelectAll()

                Case "admin_categories_list"
                    editPath += AppendQueryString("categories_new.aspx")
                    Me.InitGridView("Regions", Nothing, 25)
                    AppendSelectField(GridView, "", "categoryID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Code", "categoryID", "categoryID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Category Name", "CategoryName", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem(" Name", "CategoryName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "categoryID"))
                    End If
                    .DataSource = (New cls_Categories).SelectAll()
                Case "admin_products_list"
                    editPath += AppendQueryString("products_new.aspx")
                    Me.InitGridView("product", Nothing, 25)
                    AppendSelectField(GridView, "", "productID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Code", "ProductNo", "productID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "product Name", "productName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Unit Price", "unitprice", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem(" Name", "productName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "productID"))
                    End If
                    .DataSource = (New cls_products).SelectAll()

                Case "admin_branch_list"
                    editPath += AppendQueryString("company_branches_new.aspx")
                    Me.InitGridView("Branches", Nothing, 25)

                    AppendSelectField(GridView, "", "BranchID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "BranchID", "BranchID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "ID", "BranchID2", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Branch", "Description", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Manager", "Manager", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Address", "Address", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Branch Name", "Description"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "BranchID"))
                    End If
                    .DataSource = (New cls_Branches).SelectAll()

                Case "admin_companies_list"
                    editPath += AppendQueryString("vendors_new.aspx")
                    Me.InitGridView("Companies", Nothing, 25)

                    AppendSelectField(GridView, "", "companyID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "companyID", "companyID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "vendor", "company", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Address", "Address", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Branch Name", "company"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "companyID"))
                    End If
                    .DataSource = (New cls_Companies).SelectAll()

                Case "admin_appraisals_list"
                    editPath += AppendQueryString("employees_appraisals_edit.aspx")
                    Me.InitGridView("Appraisals", Nothing, 25)

                    AppendSelectField(GridView, "", "AppraisalID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "AppraisalID", "AppraisalID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Appraisal", "Appraisals", HorizontalAlign.Left)
                   
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Appraisals Name", "Appraisals"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "AppraisalID"))
                    End If

                    .DataSource = (New cls_Appraisals).SelectAll()

            
                Case "admin_promotion_list"

                    editPath = "/webroot/web/modules/employees/promotions_edit.aspx"
                    editPath += AppendQueryString("", "detail-id")
               
                    Me.InitGridView("Promotions", Nothing, 25)
                    AppendSelectField(GridView, "", "promotionID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "promotionID", "promotionID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade Level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Date", "proDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Basic", "BS", HorizontalAlign.Right, , "{0:n0}")
                    AppendBoundField(GridView, "Housing", "HA", HorizontalAlign.Right, , "{0:n0}")
                    AppendBoundField(GridView, "Transport", "TA", HorizontalAlign.Right, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Housing", "HA"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "promotionID"))
                    End If

                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_hrpromotions).SelectWhereEmployee(EmployeeID)


                Case "admin_education_list"
                    editPath += AppendQueryString("educations_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("educations", Nothing, 25)

                    AppendSelectField(GridView, "", "EducationID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "EducationID", "EducationID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "School Attended", "schoolAttend", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "From", "DFrom", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "TO", "DTo", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Certificate", "Certobtained", HorizontalAlign.Left, , "{0:n0}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("School Attended", "schoolAttend"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "EducationID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrEducation).SelectWhereEmployee(EmployeeID)

                Case "admin_experience_list"
                    editPath += AppendQueryString("experiences_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id,msg,option")
                    Me.InitGridView("experience", Nothing, 25)

                    AppendSelectField(GridView, "", "experienceID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "experienceID", "experienceID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Organisation", "OrgName", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "From", "EDFrom", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "TO", "EDTo", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Post Head", "PostHeld", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Organisation", "OrgName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "experienceID"))
                    End If

                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_Hrexperience).SelectWhereEmployee(EmployeeID)


                Case "admin_professional_list"
                    editPath += AppendQueryString("professional_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("professional", Nothing, 25)

                    AppendSelectField(GridView, "", "ProfQualificationID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "ProfQualificationID", "ProfQualificationID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Date", "QualDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Qualification", "QualObtained", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Prof. Bodies", "ProfBodies", HorizontalAlign.Left, , "{0:n0}")


                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Qualification", "QualObtained"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "ProfQualificationID"))
                    End If

                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrQualifications).SelectWhereEmployee(EmployeeID)
                Case "admin_referees_list"
                    editPath += AppendQueryString("referees_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("Referees", Nothing, 25)
                    AppendSelectField(GridView, "", "RefereeID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "RefereeID", "RefereeID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Referee", "RefName", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Address", "Address", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Telephone", "Telephone", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Referee", "RefName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "RefereeID"))
                    End If

                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrReferees).SelectWhereEmployee(EmployeeID)


                Case "admin_training_history_list"
                    editPath += AppendQueryString("training_history_edit.aspx", "detail-id")

                    'editPath += AppendQueryString("", "detail-id")

                    Me.InitGridView("training_history", Nothing, 25)
                    AppendSelectField(GridView, "", "trainhisID", ListSelectionMode.Multiple, , "1px")

                    AppendHyLinkField(GridView, "Code", "trainhisID", "trainhisID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Course Title", "trainDesc", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Date", "DueDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Duration", "Duration", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Trainig Cadre", "trainCadre", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Venue", "trainvenue", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Cost", "CourseCost", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Description", "trainDesc"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "trainhisID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrTraininghistories).SelectWhereEmployee(EmployeeID)

                Case "loans_list"
                    editPath += AppendQueryString("loan_edit.aspx", "detail-id")
                    Me.InitGridView("Loans", Nothing, 25)

                    AppendSelectField(GridView, "", "loanID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Employee No", "EmployeeID", "loanID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Surname", "Surname", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Other names", "Othernames", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Loans ", "LoanName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Start Date", "StartDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Duration", "Duration", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Amount", "Amount", HorizontalAlign.Left, , "{0:n0}")
                    'AppendBoundField(GridView, "Monthly Deduction", "MonthlyDed", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Surname", "Surname"))
                        Me.cbSearchOn.Items.Add(New ListItem("Loan", "LoanName"))
                    End If

                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_loans).SelectAll

                Case "training_needs_list"
                    editPath += AppendQueryString("training_needs_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")

                    Me.InitGridView("training_needs", Nothing, 25)
                    AppendSelectField(GridView, "", "trainhisID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "trainhisID", "trainhisID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Course Title", "trainDesc", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Date", "DueDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Duration", "Duration", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Trainig Cadre", "trainCadre", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Venue", "trainvenue", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Cost", "CourseCost", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Approval", "Approval", HorizontalAlign.Left, , "APPROVAL_FORMAT")


                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Train Course", "trainDesc"))
                        Me.cbSearchOn.Items.Add(New ListItem("Employee No", "EmployeeID"))
                    End If

                    Dim Status As String = Page.Request.QueryString("option")

                    Status = Replace(Status, "?", "")
                    .DataSource = (New cls_HrTraininghistories).SelectWhere(Status, Me.txtDate1.Text, Me.txtDate2.Text, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case "admin_appraisals_employee"
                    editPath += AppendQueryString("appraisals_edit.aspx", "detail-id")

                    Me.InitGridView("appraisals", Nothing, 25)

                    AppendSelectField(GridView, "", "appraisalID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "appraisalID", "appraisalID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Description", "BaseDesc", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Appraisal Date", "AppDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Objective", "Objective", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Score", "Score", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Description", "BaseDesc"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "appraisalID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrAppraisals).SelectWhereEmployee(EmployeeID)


                Case "admin_disciplines_list"
                    editPath += AppendQueryString("disciplines_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("disciplines", Nothing, 25)

                    AppendSelectField(GridView, "", "disciplineID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "disciplineID", "disciplineID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Officer", "DisciplineOfficer", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Discipline Date", "DisDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Type", "DisplineType", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Remarks", "Remarks", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("officer", "DisciplineOfficer"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "disciplineID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrDisciplines).SelectWhereEmployee(EmployeeID)


                Case "admin_hobby_list"
                    editPath += AppendQueryString("staff_hobby_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("hobbies", Nothing, 25)

                    AppendSelectField(GridView, "", "ID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "ID", "ID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Hobby Type", "Name", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Remarks", "Remarks", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("officer", "Name"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "ID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_hobbies).SelectWhereEmployee(EmployeeID)


                Case "proposal_photos"
                    Dim type As String = Page.Request.QueryString("type")

                    editPath += AppendQueryString("add_photos_update.aspx")
                    Me.InitGridView("Employee Details", Nothing, 25)

                    AppendSelectField(GridView, "", "EmployeeID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Employee No", "EmployeeID", "EmployeeID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Surname", "Surname", HorizontalAlign.Left)
                    AppendBoundField(GridView, "OtherNames", "Othernames", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade Level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Branch", "Branch", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Hired Date", "HireDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Employee No", "EmployeeID"))
                        Me.cbSearchOn.Items.Add(New ListItem("Surname", "Surname"))
                    End If
                    Dim sheetid As Long = 0
                    If Me.cdbPaysheet.SelectedValue Is Nothing Then
                        sheetid = 0
                    Else
                        sheetid = Val(Me.cdbPaysheet.SelectedValue)
                    End If
                    .DataSource = (New cls_employees).SelectAllEmployees(sheetid, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case "admin_medicaldetails_list"
                    editPath += AppendQueryString("medicaldetails_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")

                    Me.InitGridView("medicaldetails", Nothing, 25)
                    AppendSelectField(GridView, "", "MedDetailsID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "medDetailsID", "medDetailsID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Conditions", "Conditions", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "blood Group", "bloodgrp", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Type", "Type", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Conditions", "Conditions"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "medDetailsID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_medicaldetails).SelectWhereEmployee(EmployeeID)



                Case "admin_medicalevents_list"
                    editPath += AppendQueryString("medicalevents_edit.aspx", "detail-id")

                    'editPath += AppendQueryString("", "detail-id")

                    Me.InitGridView("medicalevents", Nothing, 25)
                    AppendSelectField(GridView, "", "MedID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "MedID", "MedID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Description", "TreatDesc", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Hospital", "MedHospital", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Activity Date", "MedDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Remarks", "Remarks", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Medical Cost", "Medicalcost", HorizontalAlign.Right, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Decription", "TreatDesc"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "MedID"))
                    End If

                    Dim Status As String = Page.Request.QueryString("option")
                    Status = Replace(Status, "?", "")

                    .DataSource = (New cls_medicalevents).SelectWhere(Status, Me.txtDate1.Text, Me.txtDate2.Text, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case "staff_leaves_list"
                    editPath += AppendQueryString("staff_leaves_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("Leaves", Nothing, 25)

                    AppendSelectField(GridView, "", "LeaveID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "LeaveID", "LeaveID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Leave Date", "LDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Leave types", "LeaveType", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Duration", "Duration", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Leave Allowance", "LeaveAllow", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Leave types", "LeaveType"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "LeaveID"))
                    End If


                    Dim Status As String = Page.Request.QueryString("option")
                    Status = Replace(Status, "?", "")


                    .DataSource = (New cls_Hrleaves).SelectWhereDetails(Status, Me.txtDate1.Text, Me.txtDate2.Text, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case "admin_leaves_list"
                    editPath += AppendQueryString("leaves_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("Leaves", Nothing, 25)

                    AppendSelectField(GridView, "", "LeaveID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "LeaveID", "LeaveID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Leave Date", "LDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Leave types", "LeaveType", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Duration", "Duration", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Leave Allowance", "LeaveAllow", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Leave types", "LeaveType"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "LeaveID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_Hrleaves).SelectWhereEmployee(EmployeeID)




                Case "admin_vehicles_list"
                    editPath += AppendQueryString("vehicles_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("vehicles", Nothing, 25)

                    AppendSelectField(GridView, "", "vehicleID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "vehicleID", "vehicleID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Make", "make", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Assign Date", "AssignDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Vehicle", "compvehicle", HorizontalAlign.Left, , "{0:n0}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Vehicle Make", "make"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "vehicleID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_compVehicles).SelectWhereEmployee(EmployeeID)

                Case "admin_compensations_list"
                    editPath += AppendQueryString("compensations_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("compensations", Nothing, 25)

                    AppendSelectField(GridView, "", "caseID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "caseID", "caseID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Description", "CaseDesc", HorizontalAlign.Left, , "{0:n0}")

                    AppendBoundField(GridView, "Assign Date", "incidentDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Location", "LocDetails", HorizontalAlign.Left, , "{0:n0}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Description", "CaseDesc"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "caseID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_Compensation).SelectWhereEmployee(EmployeeID)

                Case "admin_properties_list"
                    editPath += AppendQueryString("properties_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("properties", Nothing, 25)

                    AppendSelectField(GridView, "", "PptyID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "PptyID", "PptyID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Name", "PtyName", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Issued Date", "IssuedDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    AppendBoundField(GridView, "Description", "PtyDesc", HorizontalAlign.Left, , "{0:n0}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Description", "PtyName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "PptyID"))
                    End If
                    Dim EmployeeID As String = Page.Request.QueryString("edit-id")
                    .DataSource = (New cls_HrProperties).SelectWhereEmployee(EmployeeID)

                Case "admin_leavetypes_list"
                    editPath += AppendQueryString("leavetypes_edit.aspx", "detail-id")
                    'editPath += AppendQueryString("", "detail-id")
                    Me.InitGridView("Leavetypes", Nothing, 25)

                    AppendSelectField(GridView, "", "TypeID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "TypeID", "TypeID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Leave types", "LeaveType", HorizontalAlign.Left, , "{0:n0}")
                    AppendBoundField(GridView, "Remarks", "Remarks", HorizontalAlign.Left, , "{0:n0}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Leave types", "LeaveType"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "TypeID"))
                    End If
                    .DataSource = (New cls_leavetypes).SelectAll()

                Case "admin_gradelevel_list"
                    editPath += AppendQueryString("employees_gradelevels_new.aspx", "detail-id")
                    Me.InitGridView("Grades", Nothing, 25)

                    AppendSelectField(GridView, "", "ID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "ID", "ID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade", "Name", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Staff Group", "tag", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Grade Level", "Name"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "ID"))
                    End If
                    .DataSource = (New cls_Hpaygrades).SelectAll()

                Case "admin_gradesteps_list"
                    editPath += AppendQueryString("employees_gradesteps_new.aspx", "detail-id")
                    Me.InitGridView("Steps", Nothing, 25)

                    AppendSelectField(GridView, "", "ID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "ID", "ID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "Name", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Remarks", "Remarks", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Grade Level", "Name"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "ID"))
                    End If
                    .DataSource = (New cls_Hrsteps).SelectAll()


                Case "admin_paysheets_list"
                    editPath += AppendQueryString("pay_sheets_new.aspx")
                    Me.InitGridView("pay_sheets", Nothing, 25)
                    AppendSelectField(GridView, "", "SheetID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "SheetID", "SheetID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "PaySheet", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Frequency", "frequency", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "PaySheet"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "SheetID"))
                    End If
                    .DataSource = (New cls_paysheets).SelectAll()
                Case "admin_vpayallowances_list"
                    editPath += AppendQueryString("variance_allowances_new.aspx")
                    Me.InitGridView("pay_sheets_vallowances", Nothing, 25)
                    AppendSelectField(GridView, "", "AllowID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "AllowID", "AllowID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "AllowName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Amount", "Value1", HorizontalAlign.Right, , "{0:n0}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "AllowName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "AllowID"))
                    End If
                    .DataSource = (New cls_VpayAllowances).SelectAll()

                Case "admin_paydeductions_list"
                    editPath += AppendQueryString("pay_sheet_deductions_new.aspx")
                    Me.InitGridView("pay_sheets_deductions", Nothing, 25)
                    AppendSelectField(GridView, "", "DedID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "DedID", "DedID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "DedName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Amount", "Value1", HorizontalAlign.Right, , "{0:n0}")
                    AppendBoundField(GridView, "Grade level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Steps", "Steps", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "DedName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "DedID"))
                    End If
                    .DataSource = (New cls_HpayDeductions).SelectAll()

                Case "admin_vpaydeductions_list"
                    editPath += AppendQueryString("variance_deductions_new.aspx")
                    Me.InitGridView("variance_deductions", Nothing, 25)
                    AppendSelectField(GridView, "", "DedID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "DedID", "DedID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "DedName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Amount", "Value1", HorizontalAlign.Right, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "DedName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "DedID"))
                    End If
                    .DataSource = (New cls_VpayDeductions).SelectAll()

                Case "admin_depts_list"
                    editPath += AppendQueryString("employees_depts_new.aspx")
                    Me.InitGridView("Steps", Nothing, 25)
                    AppendSelectField(GridView, "", "Code", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "Code", "Code", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "Name", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Remarks", "Remark", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Departments", "Name"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "Code"))
                    End If
                    .DataSource = (New cls_HpayDepts).SelectAll()

                Case "admin_trainings_list"
                    editPath += AppendQueryString("training_cadres_new.aspx")
                    Me.InitGridView("Steps", Nothing, 25)

                    AppendSelectField(GridView, "", "Code", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "Code", "Code", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "Name", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Remarks", "Remark", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Training Cadres", "Name"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "Code"))
                    End If
                    .DataSource = (New cls_TrainingCadres).SelectAll()

                Case "admin_units_list"
                    editPath += AppendQueryString("employees_units_new.aspx")
                    Me.InitGridView("units", Nothing, 25)

                    AppendSelectField(GridView, "", "Code", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "Code", "Code", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "Section", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Remarks", "Description", HorizontalAlign.Left)
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Grade Level", "Section"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "Code"))
                    End If
                    .DataSource = (New cls_HpayUnits).SelectAll()

                Case "admin_allowance_list"
                    editPath += AppendQueryString("allowances_new.aspx")
                    Me.InitGridView("Allowances", Nothing, 25)

                    AppendSelectField(GridView, "", "AllowID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "AllowID", "AllowID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Allowances", "allowname", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Allowances", "allowname"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "AllowID"))
                    End If
                    .DataSource = (New cls_AllowancesID).SelectAll()


                Case "admin_loantypes_list"
                    editPath += AppendQueryString("loantypes_new.aspx")

                    Me.InitGridView("variance_deductions", Nothing, 25)
                    AppendSelectField(GridView, "", "DedID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "DedID", "DedID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "DedName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Rate", "Value2", HorizontalAlign.Left, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "DedName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "DedID"))
                    End If
                    .DataSource = (New cls_VpayDeductions).SelectAll()

                Case "admin_deduction_list"
                    editPath += AppendQueryString("deductions_new.aspx")
                    Me.InitGridView("Deductions", Nothing, 25)

                    AppendSelectField(GridView, "", "dedID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "dedID", "dedID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Deductions", "dedname", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Deductions", "Dedname"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "DedID"))
                    End If
                    .DataSource = (New cls_DeductionsID).SelectAll()
                Case "admin_user_list"
                    editPath += AppendQueryString("security_users_new.aspx")
                    Me.InitGridView("Users", Nothing, 25)

                    AppendSelectField(GridView, "", "UserID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Username", "UserName", "UserID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "First Name", "FirstName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Last Name", "LastName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Phone", "Phone", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Active?", "Active", HorizontalAlign.Left, , "{0:Yes;;-}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "UserName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "UserID"))
                    End If
                    .DataSource = (New cls_Users).SelectAll()
                Case "admin_role_list"
                    editPath += AppendQueryString("security_roles_new.aspx")
                    Me.InitGridView("Roles", Nothing, 25)
                    AppendSelectField(GridView, "", "RoleID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "RoleID", "RoleID", "RoleID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Role Name", "RoleName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "User Count", "UserCount", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Description", "RoleDescription", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "RoleName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "RoleID"))
                    End If
                Case "hr_employees"
                    editPath += AppendQueryString("employees_edit.aspx")
                    Me.InitGridView("Employee Details", Nothing, 25)

                    AppendSelectField(GridView, "", "EmployeeID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Employee No", "EmployeeID", "EmployeeID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Surname", "Surname", HorizontalAlign.Left)
                    AppendBoundField(GridView, "OtherNames", "Othernames", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade Level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Branch", "Branch", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Hired Date", "HireDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Employee No", "EmployeeID"))
                        Me.cbSearchOn.Items.Add(New ListItem("Surname", "Surname"))
                    End If
                    Dim InvoiceType As String = Page.Request.QueryString("option")
                    Dim sheetid As Long = 0
                    If Me.cdbPaysheet.SelectedValue Is Nothing Then
                        sheetid = 0
                    Else
                        sheetid = Val(Me.cdbPaysheet.SelectedValue)
                    End If
                    .DataSource = (New cls_employees).SelectAllEmployees(sheetid, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                    'Case "purchase_invoices"
                    '    editPath += AppendQueryString("purchases_edit.aspx")
                    '    Me.InitGridView("Asset Purchase", Nothing, 25)
                    '    AppendSelectField(GridView, "", "Invoice_No", ListSelectionMode.Multiple)
                    '    AppendHyLinkField(GridView, "Invoice No", "Invoice_No", "Invoice_No", "{0:g}", editPath, HorizontalAlign.Left)
                    '    AppendBoundField(GridView, "Asset Name", "Asset", HorizontalAlign.Left)
                    '    AppendBoundField(GridView, "Purchase Date", "purchase_Date", HorizontalAlign.Left, , "{0:dd-MMM-yyyy}")
                    '    AppendBoundField(GridView, "Purchase Amount", "Purchase_Amt", HorizontalAlign.Right, , "{0:n0}")
                    '    AppendBoundField(GridView, "Status", "TransSTATUS", HorizontalAlign.Right, , "{0:n0}")
                    '    AppendBoundField(GridView, "SubmittedOn", "SubmittedOn", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")

                    '    If Not Me.Page.IsPostBack Then
                    '        Me.cbSearchOn.Items.Add(New ListItem("Asset Code", "Invoice_No"))
                    '        Me.cbSearchOn.Items.Add(New ListItem("Asset Name", "Asset"))
                    '    End If

                    '    Dim InvoiceType As String = Page.Request.QueryString("option")
                    '    .DataSource = (New cls_Asspurchases).SelectWhere(CDate(Me.txtDate1.Text), CDate(Me.txtDate2.Text), InvoiceType, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case "hr_employees_enquiries"

                    editPath += AppendQueryString("selfservices_profile.aspx")
                    Me.InitGridView("Employee Details", Nothing, 25)
                    AppendSelectField(GridView, "", "EmployeeID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Employee No", "EmployeeID", "EmployeeID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Surname", "Surname", HorizontalAlign.Left)
                    AppendBoundField(GridView, "OtherNames", "Othernames", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade Level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Branch", "Branch", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Hired Date", "HireDate", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")
                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Employee No", "EmployeeID"))
                        Me.cbSearchOn.Items.Add(New ListItem("Surname", "Surname"))
                    End If
                    'Dim InvoiceType As String = Page.Request.QueryString("option")

                    Dim sheetid As Long = 0
                    If Me.cdbPaysheet.SelectedValue Is Nothing Then
                        sheetid = 0
                    Else
                        sheetid = Val(Me.cdbPaysheet.SelectedValue)
                    End If
                    .DataSource = (New cls_employees).SelectAllEmployees(sheetid, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)
                Case "mkt_contacts"
                    editPath += "smsemail_edit.aspx" 'special case here, multiple params
                    Me.InitGridView("Contacts", Nothing, 25)
                    AppendSelectField(GridView, "", "MktContactID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "SentTo", "SentTo", _
                                      New String() {"MsgType", "MktContactID"}, "{0:g}", editPath & "?type={0}&edit-id={1}", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Subject", "Subject", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Type", "MsgType", HorizontalAlign.Left, , "{0:SMS;-;Email}")
                    AppendBoundField(GridView, "SubmittedOn", "SubmittedOn", HorizontalAlign.Right, , "{0:dd-MMM-yyyy}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Message", "Message"))
                        Me.cbSearchOn.Items.Add(New ListItem("Sent To", "SentTo"))
                        Me.cbSearchOn.Items.Add(New ListItem("Subject", "Subject"))
                    End If

                    .DataSource = (New cls_MktContacts).SelectWhere("", Me.txtDate1.Text, Me.txtDate2.Text, Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case Else
                    Exit Sub

            End Select

            If .DataSource.Count = 0 Then 'just to make sure d grids is shown'
                Dim t As Type = .DataSource.GetType().GetGenericArguments()(0)
                Dim i = Activator.CreateInstance(t, True)

                For Each info As Reflection.PropertyInfo In t.GetProperties()
                    If info.CanWrite AndAlso info.PropertyType Is GetType(String) Then
                        info.SetValue(i, "--em@#$%^?ty--", Nothing)
                    End If
                Next
                .DataSource.Add(i)
            End If

            If Not Page.IsPostBack Then
                .DataBind()
            End If
        End With
    End Sub

    Private Function AppendQueryString(ByVal str As String, Optional ByVal edit_id_str As String = "edit-id") As String
        If My.Request.Url.Query = "" Then
            Return str & "?" & edit_id_str & "={0}"
        Else
            Dim q As New Specialized.NameValueCollection
            q.Add(My.Request.QueryString) : q.Remove(edit_id_str)

            q.Add(edit_id_str, "{0}")
            Dim query As String = mod_main.getQueryString(q)
            Return str & "?" & query
        End If
    End Function

    Private Sub MakePagerAndFooter()
        Dim pagerRow As GridViewRow = GridView1.BottomPagerRow
        If pagerRow IsNot Nothing Then
            Dim myDropDn As DropDownList = pagerRow.Cells(0).FindControl("DropDownList1")

            Try
                Dim minPageSize As Integer = Val(myDropDn.Items(0).Value) '25
                If GridView1.DataSource.Count > minPageSize Then
                    myDropDn.Enabled = True
                End If
            Catch ex As Exception
                myDropDn.Enabled = True
            End Try
            MakeDropDownJs(Me.Page, myDropDn)

            Dim pagerTable As PlaceHolder = pagerRow.Cells(0).FindControl("PlaceHolder1")
            If pagerTable IsNot Nothing Then
                If GridView1.PageCount <= 1 Then
                    pagerTable.Controls.Add(New LiteralControl("&nbsp;"))
                    Exit Sub
                End If

                Dim intCurr As Integer = GridView1.PageIndex + 1
                Dim intEnd As Integer = intCurr + 6
                Dim intBegin As Integer = intCurr - 6

                If intBegin < 1 Then
                    intEnd += (1 - intBegin)
                    intBegin = 1
                End If

                If intEnd > GridView1.PageCount Then
                    intBegin -= (intEnd - GridView1.PageCount)
                    intEnd = GridView1.PageCount
                End If

                If intBegin < 1 Then intBegin = 1

                MakePageLink(pagerTable, 1) 'first page link
                If intBegin > 1 Then
                    pagerTable.Controls.Add(New LiteralControl("<span class='elipses'>...</span>"))
                End If
                For i As Integer = intBegin + 1 To intEnd - 1
                    MakePageLink(pagerTable, i)
                Next
                If intEnd < GridView1.PageCount Then
                    pagerTable.Controls.Add(New LiteralControl("<span class='elipses'>...</span>"))
                End If
                MakePageLink(pagerTable, GridView1.PageCount) 'last page link
            End If
        End If
    End Sub

    Private Sub MakePageLink(ByVal pHolder As PlaceHolder, ByVal index As Integer)
        If index = GridView1.PageIndex + 1 Then
            pHolder.Controls.Add(New LiteralControl("<span class='current'>" & index & "</span>"))
        Else
            Dim lnkPage As New LinkButton()
            lnkPage.Text = index
            lnkPage.CommandName = "Page"
            lnkPage.CommandArgument = index.ToString()
            lnkPage.ID = "Page" + index.ToString()
            pHolder.Controls.Add(lnkPage)
        End If
    End Sub

#End Region

#Region "GridView Events"

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        MakePagerAndFooter()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            If e.Row.Cells(0).Controls.Count > 0 Then
                Dim C As HtmlInputControl = CType(e.Row.Cells(0).Controls(0), HtmlInputControl)
                C.Attributes.Add("onclick", "datagrid_selectRow(this);")
                C.Attributes.Add("hidefocus", "true")
            End If

        ElseIf e.Row.RowType = DataControlRowType.Header Then
            If e.Row.Cells(0).Controls.Count > 0 Then
                Dim C As HtmlInputControl = CType(e.Row.Cells(0).Controls(0), HtmlInputControl)
                C.Attributes.Add("onclick", "datagrid_selectAllRows(this);")
                C.Attributes.Add("hidefocus", "true")
            End If

        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            Dim TotalRecords As Long = 0 'GridView1.DataSource.Count
            If GridView1.DataSource IsNot Nothing Then TotalRecords = GridView1.DataSource.Count
            Dim FirstRecords As Long = (GridView1.PageIndex * GridView1.PageSize) + 1
            Dim LastRecords As Long = (GridView1.PageIndex + 1) * GridView1.PageSize
            Dim EntityName As String = GridView1.Attributes.Item("Entity-Name")

            Dim myLabel As Label = CType(e.Row.Cells(0).FindControl("Label1"), Label)
            If TotalRecords > 0 Then
                If LastRecords > TotalRecords Then LastRecords = TotalRecords
                myLabel.Text = FormatNum(FirstRecords) & " to " & FormatNum(LastRecords) & " of " & FormatNum(TotalRecords)
            End If

        ElseIf e.Row.RowType = DataControlRowType.Footer Then

        End If
    End Sub

    Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender
        Dim pagerRow As GridViewRow = GridView1.BottomPagerRow
        If pagerRow IsNot Nothing Then
            pagerRow.Visible = True
            Dim pagerSize As DropDownList = pagerRow.Cells(0).FindControl("DropDownList1")
            If pagerSize IsNot Nothing AndAlso pagerSize.SelectedValue <> GridView1.PageSize Then
                pagerSize.SelectedValue = GridView1.PageSize
                'Dim txt As TextBox = pagerRow.Cells(0).FindControl("DropDownList1" & "Textbox")
                'txt.Text = pagerSize.SelectedItem.Text
            End If
        End If

        If GridView1.Rows.Count > 0 Then
            For Each c As TableCell In GridView1.Rows(0).Cells
                If c.Text = "--em@#$%^?ty--" Then
                    GridView1.Rows(0).Style.Add("display", "none") 'hide the empty row
                    Dim myLabel As Label = CType(pagerRow.Cells(0).FindControl("Label1"), Label)
                    myLabel.Text = "No records found. Please expand the search filter."
                    Exit For
                End If
            Next
        End If
    End Sub

#End Region

#Region "GridView Properties"

    Public Property AllowPaging() As Boolean
        Get
            Return _allowPaging
        End Get
        Set(ByVal value As Boolean)
            _allowPaging = value
        End Set
    End Property

    Public Property HideFilterBox() As Boolean
        Get
            Return _hideFilterBox
        End Get
        Set(ByVal value As Boolean)
            _hideFilterBox = value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return _GroupName
        End Get
        Set(ByVal value As String)
            _GroupName = value
        End Set
    End Property

    Public ReadOnly Property GridView() As GridView
        Get
            Return Me.GridView1
        End Get
    End Property

#End Region

    Public Enum ApprovalFormatEnum
        PENDING = 0
        APPROVED_1 = 1
        APPROVED_2 = 2
    End Enum

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            For P = 0 To e.Row.Cells.Count - 1
                If TypeOf Me.GridView1.Columns(P) Is WebControls.BoundField Then
                    Dim Field As WebControls.BoundField = Me.GridView1.Columns(P)
                    Select Case Field.AccessibleHeaderText
                        Case "APPROVAL_FORMAT"
                            'e.Row.Cells(P).Text = [Enum].GetName(GetType(ApprovalFormatEnum), CInt(e.Row.Cells(P).Text))
                            Select Case e.Row.Cells(P).Text
                                Case 0
                                    e.Row.Cells(P).Text = "PENDING"
                                Case 1
                                    e.Row.Cells(P).Text = "APPROVED"

                            End Select

                        Case Else

                    End Select
                End If
            Next
        End If
    End Sub
End Class
