Partial Class gibs_main_master
    Inherits System.Web.UI.MasterPage

    Protected IdHumanResources As String = "IdHumanResources"
    Protected IdPayroll As String = "IdPayroll"
    Protected Idselfservice As String = "Idselfservice"
    Protected IdAdminInventory As String = "IdAdminInventory"
    Protected IdCorporateAffairs As String = "IdCorporateAffairs"
    Protected IdReports As String = "IdReports"
    Protected IdWelcome As String = "IdWelcome"
    Protected IdSetups As String = "IdSetups"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            BuildTabs()
        End If
    End Sub
    Private Sub Msgbox(ByVal Message As String)
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(Message)
        sb.Append("')};")
        sb.Append("</script>")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Page.Response.Cookies.Item("msgbox").Value = ""
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender

        Dim UserID As String = mod_main.getLoggedOnUserID
        Dim Username As String = mod_main.getLoggedOnUsername
        Dim strLogin As String = "/webroot/web/modules/welcome/login.aspx"
      
        If Username = "" Then 'not logged in
            Me.lblLogoffLinks.Text = "<a href='' class='white'>Login Here...<a/>"
            If Not Me.Request.Url.AbsolutePath.Contains("/webroot/web/modules/welcome/") Then
                Response.Redirect(strLogin & "?goto=" & Server.UrlEncode(Me.Request.Url.OriginalString))
            End If
        Else
            Me.lblLogoffLinks.Text = "Welcome <b>" & StrConv(Username, VbStrConv.ProperCase) & "</b>, <a href='/webroot/web/modules/welcome/login.aspx?msg=logoff1' class='white'>click here to logoff<a/>"
        End If
        If m_strAnnouncement <> "" Then
            If m_strAnnounceType = "ERROR" Then
                Me.msgbox1.ShowError(m_strAnnouncement)
            Else
                Me.msgbox1.ShowInfo(m_strAnnouncement)
            End If
        End If
        If Request.Path.Contains("/modules/welcome") Then
            IdWelcome = "current"
        ElseIf Request.Path.Contains("/modules/employees") Then
            'CheckCurrUserPermission(PermissionEnum.HRM_MODULE_ACCESS)
            IdHumanResources = "current"

        ElseIf Request.Path.Contains("/modules/payroll") Then
            'CheckCurrUserPermission(PermissionEnum.PAYROLL_MODULE_ACCESS)
            IdPayroll = "current"
        ElseIf Request.Path.Contains("/modules/selfservice") Then
            CheckCurrUserPermission(PermissionEnum.SERVICE_MODULE_ACCESS)
            Idselfservice = "current"
        ElseIf Request.Path.Contains("/modules/admin") Then
            CheckCurrUserPermission(PermissionEnum.ADMIN_MODULE_ACCESS)
            IdAdminInventory = "current"
        ElseIf Request.Path.Contains("/modules/corporate") Then
            CheckCurrUserPermission(PermissionEnum.CORPORATE_MODULE_ACCESS)
            IdCorporateAffairs = "current"
        ElseIf Request.Path.Contains("/modules/reports/viewer") Then
            IdReports = "current"
            Me.masterLeft.Visible = False
        ElseIf Request.Path.Contains("/modules/reports") Then
            IdReports = "current"
        ElseIf Request.Path.Contains("/modules/setups") Then
            'CheckCurrUserPermission(PermissionEnum.SETUP_MODULE_ACCESS)
            IdSetups = "current"
        Else
            IdWelcome = "current"
        End If


        Dim c As HttpCookie = Me.Request.Cookies("msgbox")
        Dim d As HttpCookie = Me.Response.Cookies("msgbox")
        If c IsNot Nothing AndAlso c.Value <> "" Then
            msgbox(c.Value)
        ElseIf d IsNot Nothing AndAlso d.Value <> "" Then
            msgbox(d.Value)
        End If

    End Sub

    Private Sub BuildTabs()
        Dim Username As String = mod_main.getLoggedOnUsername
        If Request.Path.Contains("/welcome/") Then
            AddTab("Start Page", "default.aspx", "Welcome page")
            If Username = "" Then 'not logged on
                AddTab("Login Here ", "login.aspx", "Login to Gibs")
                AddTab("Change Password", "changepwd.aspx", "Change your login password")
                AddTab("Reset Password", "resetpwd.aspx", "Reset your password")
            Else
                AddTab("Change Password", "changepwd.aspx", "Change your login password")
                AddTab("Reset Password", "#", "Reset your password")
            End If
        ElseIf Request.Path.Contains("/modules/employees") Then
            AddTab("Overview", "default.aspx", "Marketing Overview")
            AddTab("Employees", "employees.aspx", "Employees Details", 10)
            AddTab("Staff Activities", "employees.aspx", "Employees Activities", 11)
            AddTab("Other Activities", "employees.aspx", "Employees vehicles", 12)
            AddTab("Servicing", "employees.aspx", "Staff Maintenance", 59)
            'AddTab("Staff Enquiries", "employees.aspx", "Employees Enquiries", 60)
            'AddTab("Send SMS/Email", "smsemail.aspx", "Follow up via email or SMS")
            'AddTab("Reports", "reports.aspx", "Marketing Reports")

        ElseIf Request.Path.Contains("/modules/payroll") Then
            AddTab("Overview", "default.aspx", "Employees overview")
            AddTab("New Staff Payroll", "pay_employees.aspx", "new staff payroll etc")
            Select Case settings.COMPANY_ABREV
                Case "CHI"
                    AddTab("Next Month Payroll", "process_pay_rolls.aspx", "View/process pay roll for next month")
                Case Else
                    AddTab("Next Month Payroll", "pay_nextmonth.aspx", "View/process pay roll for next month")
            End Select
            'AddTab("Next Month Payroll", "pay_nextmonth.aspx", "View/process pay roll for next month")
            AddTab("Staff Monthly Variance", "monthly_variances.aspx", "View All transactions")
            AddTab("Payroll Preview", "pay_rolls.aspx", "Manage Insured/Wax codes etc", 23)
            'AddTab("Reports", "reports.aspx", "Employees Reports")

        ElseIf Request.Path.Contains("/modules/selfservice") Then
            AddTab("Overview", "default.aspx", "Employees overview")
            AddTab("Employee(Self - Service)", "postings.aspx", "new staff payroll etc", 40)
            AddTab("Manager (Self-Service)", "endorsement.aspx", "View/setup Endorsements", 41)
            AddTab("Send SMS/Email", "smsemail.aspx", "Follow up via email or SMS")
            ''AddTab("Reports", "reports.aspx", "Marketing Reports")

        ElseIf Request.Path.Contains("/modules/admin") Then
            AddTab("Overview", "default.aspx", "Accounts Overview")
            AddTab("Purchases", "purchases.aspx", "Accounts Overview", 24)
            AddTab("Stock Inventory", "stocks.aspx", "Accounts Overview", 25)
            'AddTab("Maintenance", "maintenances.aspx", "Accounts Overview", 27)
            AddTab("set up", "families.aspx", "Accounts Overview", 29)
            'AddTab("Reports", "reports.aspx", "ReInsurance Reports")

        ElseIf Request.Path.Contains("/modules/corporate") Then
            AddTab("Overview", "default.aspx", "Accounts Overview")
            AddTab("Reports", "reports.aspx", "ReInsurance Reports")

        ElseIf Request.Path.Contains("/modules/reports") Then
            AddTab("Overview", "default.aspx", "Reports Overview")
            AddTab("Employees", "reports.aspx?grp=employees", "Employees Reports")
            AddTab("Payrolls", "reports.aspx?grp=payrolls", "Payroll Reports")
            AddTab("Self Services", "reports.aspx?grp=selfservices", "Self Service Reports")
            AddTab("Admin", "reports.aspx?grp=Inventory", "Admin/Inventory Reports")
            AddTab("Set Up", "reports.aspx?grp=setups", "General Set-up Reports")
            'AddTab("Other Reports", "reports.aspx?grp=", "Other Uncategorised Reports")

        ElseIf Request.Path.Contains("/modules/setups") Then
            AddTab("Overview", "default.aspx", "Admin Overview")
            AddTab("Employees", "employees.aspx", "Employee Details Setup", 30)
            AddTab("Payroll", "payroll.aspx", "Payroll Related Setup", 32)
            'AddTab("Inventory", "admin.aspx", "Stock and Inventory Related Setup", 33)
            AddTab("Security", "setups.aspx", "Users/Roles Access Permissions", 20)
            AddTab("Company", "company.aspx", "System Settings", 26)
        Else
            'Stop b
        End If

    End Sub

    Private Function AddTab(ByVal Caption As String, ByVal LinkTo As String, ByVal ToolTip As String, Optional ByVal DropDownID As String = "") As Boolean
        Dim id As String = ""
        Dim je As String = Replace(LinkTo.ToLower, ".aspx", "")

        If je.IndexOf("_") > 0 Then
            je = je.Remove(je.IndexOf("_"))
        End If

        If Request.Path.ToLower Like getRequestPathWithoutFileName() & "/" & je & "*" Then
            Me.Literal1.Text = Replace(Me.Literal1.Text, "id=""current""", "") : id = "current"
        End If

        If DropDownID <> "" Then
            Me.Literal2.Text += "<ul id='ul_" & DropDownID & "'>"

            Select Case DropDownID
              
                Case 10
                    Call AddDropItem("Set Up Employees", "employees.aspx?option=SGL")
                    Call AddDropItem("Staff Grade Level", "employees.aspx?option=SGL")
                    Call AddDropItem("Academics Qualification", "employees.aspx?option=QED")
                    Call AddDropItem("Work Experiences", "employees.aspx?option=QED")
                    Call AddDropItem("Interest/Hobbies", "employees.aspx?option=HOB")
                Case 11
                    Call AddDropItem("Staff Training Admin", "employees.aspx?option=STH")
                    Call AddDropItem("Appraisals/Disciplines", "employees.aspx?option=SAD")
                    Call AddDropItem("Staff Medical Information", "employees.aspx?option=MSI")
                    Call AddDropItem("Leave Activities", "employees.aspx?option=SLA")


                Case 12

                    Call AddDropItem("Other Properties", "employees.aspx?option=VOP")
                    Call AddDropItem("Staff Compensations", "employees.aspx?option=SCOM")
                    Call AddDropItem("Update Employee Photographs", "add_photos.aspx")
                    Call AddDropItem("Scan Staff Documents", "not_active.aspx")
                    Call AddDropItem("Update Self Appraisal", "employees_appraisals.aspx")
                Case 21
                    Call AddDropItem("Setup Users' Access", "security_users.aspx")
                    Call AddDropItem("Setup Roles & Permissions", "security_roles.aspx")
                Case 59
                    Call AddDropItem("Staff Training Attended", "training_needs.aspx?option=PENDING")
                    Call AddDropItem("Staff Medical Events", "medicalevents.aspx?option=PENDING")
                    Call AddDropItem("Staff Leave activities", "staff_leaves.aspx?option=PENDING")


                Case 60
                    Call AddDropItem("Staff Enquires", "employees_enquiries.aspx?option=SEMP")

                Case 23
                    Call AddDropItem("Open Payroll Details ", "pay_rolls.aspx")
                    Call AddDropItem("View Monthly Variances ", "view_variances.aspx")
                    Call AddDropItem("Staff Loan & Advances", "loans.aspx?option=PENDING")
                    Call AddDropItem("View Employee Pay History", "not_active.aspx")
                    Call AddDropItem("Mail Employee Pay slips", "mail_pay_rolls.aspx")
                    Call AddDropItem("Payroll Archive", "not_active.aspx")
                Case 24
                    Call AddDropItem("Purchases(Requisition)", "purchases.aspx?option=PUR_REQ")
                    Call AddDropItem("Purchases Approval", "purchases.aspx?option=APPROVED")
                    Call AddDropItem("Purchases Delivaries ", "purchases.aspx?option=PUR_DELIVER")
                Case 25
                    Call AddDropItem("Stock Adjustment Inward", "pur_delivary.aspx?option=ADJ_INWARD")
                    Call AddDropItem("Stock Adjustment Outward", "pur_delivary.aspx?option=ADJ_OUTWARD")
                    Call AddDropItem("Stock Issued Out ", "pur_delivary.aspx?option=OUTWARD")
                    Call AddDropItem("Stock opening Balance ", "pur_delivary.aspx?option=OPENING")
                Case 27
                    Call AddDropItem("Vehicle fleets Maintenance", "admin.aspx")
                    Call AddDropItem("Mail Dispatch Register", "admin.aspx")
                Case 30
                    Call AddDropItem("Departments", "employees_depts.aspx")
                    Call AddDropItem("Section/Units", "employees_units.aspx")
                    Call AddDropItem("Grade Level", "employees_gradelevels.aspx")
                    Call AddDropItem("Grade Steps", "employees_gradesteps.aspx")
                    Call AddDropItem("Training Cadres", "training_cadres.aspx")
                Case 32
                    Call AddDropItem("Staff Pay Sheets", "pay_sheets.aspx")
                    Call AddDropItem("Grade Level Allowances", "pay_sheet_allowances.aspx")
                    Call AddDropItem("Grade Level Deductions", "pay_sheet_deductions.aspx")
                    Call AddDropItem("Monthly Variance Allowances", "variance_allowances.aspx")
                    Call AddDropItem("Monthly Variance Deductions", "variance_deductions.aspx")
                    Call AddDropItem("Staff Allowances", "allowances.aspx")
                    Call AddDropItem("Staff Deductions", "deductions.aspx")
                    Call AddDropItem("Loan Types", "loantypes.aspx")
                Case 40
                    Call AddDropItem("View personal profile", "selfservices_profile_edit.aspx")
                    Call AddDropItem("Submit leave, loan & other requests", "staff_request_edit.aspx")
                    Call AddDropItem("Perform self appraisal", "appraisee_edit.aspx")
                    Call AddDropItem("View and print personal payslips", "not_active.aspx")
                    Call AddDropItem("Give training feedback", "not_active.aspx")
                Case 41
                    Call AddDropItem("Appraise subordinates", "not_active.aspx")
                    Call AddDropItem("Approve leave, loan & other requests", "not_active.aspx")
                    Call AddDropItem("Perform self appraisal", "appraisee_edit.aspx")

                    Call AddDropItem("Nominate subordinates for training", "not_active.aspx")
                Case 26 'system
                    Call AddDropItem("Setup AutoNumbers", "company_numbers.aspx")
                    Call AddDropItem("Setup Branches", "company_branches.aspx")
                    Call AddDropItem("Setup Regions", "company_regions.aspx")
                    Call AddDropItem("Settings", "company_settings.aspx")
                Case 29 'system
                    Call AddDropItem("Setup Families", "families.aspx")
                    Call AddDropItem("Setup Categories ", "categories.aspx")
                    Call AddDropItem("Setup Products ", "products.aspx")
                    Call AddDropItem("Setup Vendors", "vendors.aspx")

                Case 20
                    Call AddDropItem("Setup Users' Access", "security_users.aspx")
                    Call AddDropItem("Setup Roles & Permissions", "security_roles.aspx")


            End Select

            Me.Literal2.Text += "</ul>"
            Me.Literal1.Text += "<li title=""" & ToolTip & """>"
            Me.Literal1.Text += "<span class='classes_span' onmouseover='dropdown_showPopupClasses(this,""ul_" & DropDownID & """);'>"
            Me.Literal1.Text += "<a hidefocus=true id=""" & id & """ href='#'>" & Caption & "</a>"
            Me.Literal1.Text += "</span>"
            Me.Literal1.Text += "</li>"
        Else
            Me.Literal1.Text += "<li title=""" & ToolTip & """>"
            Me.Literal1.Text += "<span>"
            Me.Literal1.Text += "<a hidefocus=true id=""" & id & """ href=""" & LinkTo & """>" & Caption & "</a>"
            Me.Literal1.Text += "</span>"
            Me.Literal1.Text += "</li>"
        End If
    End Function

    Private Sub AddDropItem(ByVal Caption As String, ByVal LinkTo As String)
        Me.Literal2.Text += "<li><a hidefocus=true href=""" & LinkTo & """>" & Caption & "</a></li>"
    End Sub

    Private Sub AddDropRuler()
        Me.Literal2.Text += "<li class='rule'>&nbsp;</li>"
    End Sub

    Private Function getRequestPathWithoutFileName() As String
        Dim idx As Integer = Request.Path.LastIndexOf("/")
        If idx > 0 Then
            Return Request.Path.Remove(idx)
        Else
            Return Request.Path
        End If
    End Function

End Class