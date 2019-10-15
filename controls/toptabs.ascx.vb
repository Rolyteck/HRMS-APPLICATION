Partial Class toptabs
    Inherits System.Web.UI.UserControl

    Protected _GroupName As String
    Protected _DefaultTab As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Dim params As String 
            Select Case _GroupName
                Case "employees_training_needs", "purchases_details"
                    params = "?" & mod_main.getQueryString(, "detail-id,trans-id,type,option,edit-id")
                Case Else
                    params = "?" & mod_main.getQueryString(, "detail-id,trans-id,type,option")

            End Select

            Me.Literal1.Text = ""
            Select Case _GroupName
                Case "adm_company"
                    Call AddTab("Auto Numbers", "company_numbers.aspx", "", params)
                    Call AddTab("Branches", "company_branches.aspx", "", params)
                    Call AddTab("Regions", "company_regions.aspx", "", params)
                Case "adm_vendor"
                    Call AddTab("Vendors", "vendors.aspx", "", params)
      
                Case "inventory_family"
                    Call AddTab("Families", "families.aspx", "", params)
                    Call AddTab("Categories", "categories.aspx", "", params)
                    Call AddTab("Product Items", "products.aspx", "", params)

                Case "adm_security"
                    Call AddTab("Users", "security_users.aspx", "", params)
                    Call AddTab("Roles", "security_roles.aspx", "", params)

                Case "adm_employees_1"
                    Call AddTab("Staff Grade Level", "employees_gradelevels.aspx", "", params)
                    Call AddTab("Staff Grade Steps", "employees_gradesteps.aspx", "", params)
                    Call AddTab("Staff Departments", "employees_depts.aspx", "", params)
                    Call AddTab("Staff Section/Units", "employees_units.aspx", "", params)
                    Call AddTab("Training Cadres", "training_cadres.aspx", "", params)

                Case "adm_allowances"
                    Call AddTab("Staff Allowances", "allowances.aspx", "", params)
                    Call AddTab("Staff Deductions", "deductions.aspx", "", params)

                Case "adm_Loantypes"
                    Call AddTab("Loan Types", "loantypes.aspx", "", params)

                Case "proposal_photo"

                    Call AddTab("Upload Photographs", "add_photos.aspx", "", "")

                Case "adm_employees_2"
                    Call AddTab("Staff Pay Sheets", "pay_sheets.aspx", "", params)
                    Call AddTab("Staff  Allowances", "pay_sheet_allowances.aspx", "", params)
                    Call AddTab("Staff Deductions", "pay_sheet_deductions.aspx", "", params)

                Case "adm_appraisals"
                    Call AddTab("Staff Appraisal Updates", "employees_appraisals.aspx", "", params)
                Case "adm_employees_3"
                    Call AddTab("Staff Variance Allowance", "variance_allowances.aspx", "", params)
                    Call AddTab("Staff Variance Deductions", "variance_deductions.aspx", "", params)

                Case "mkt_smsemail"

                    Call AddTab("Sent Items", "smsemail.aspx", "")
                    Call AddTab("Send New Email", "smsemail_edit.aspx?type=0", "")
                    Call AddTab("Send New SMS", "smsemail_edit.aspx?type=1", "")

                Case "employees_sgl"

                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Grade & Salary", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Grade & Salary", "promotions.aspx", "", params)
                    End If

                Case "employees_hobby"

                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("My hobbies", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("My hobbies", "staff_hobby.aspx", "", params)
                    End If

                Case "employees_enquiries"
                    Call AddTab("Staff Enquiries", "selfservices_profile_edit.aspx", "", params)
                Case "employees_leave_request"
                    Call AddTab("Staff Leave Request", "staff_request_edit.aspx", "", params)

                Case "employees_self_appraisal"
                    Call AddTab("Staff Self Appraisal", "appraisee_edit.aspx", "", params)
                Case "employees_sgl_edit"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Grade & Salary", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Grade & Salary", "promotions.aspx", "", params)
                    End If
                Case "employees_qed"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Academic qualification", js, "", "")
                        Call AddTab("Work Experience", js, "", "")
                        Call AddTab("Professional Qualif.", js, "", "")
                        Call AddTab("Referees", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Academic qualification", "educations.aspx", "", params)
                        Call AddTab("Work Experience", "experiences.aspx", "", params)
                        Call AddTab("Professional Qualif.", "professional.aspx", "", params)
                        Call AddTab("Referees", "referees.aspx", "", params)
                    End If
                Case "employees_qed_edit"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Academic qualification", js, "", "")
                        Call AddTab("Work Experience", js, "", "")
                        Call AddTab("Professional Qualif.", js, "", "")
                        Call AddTab("Referees", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Academic qualification", "educations.aspx", "", params)
                        Call AddTab("Work Experience", "experiences.aspx", "", params)
                        Call AddTab("Professional Qualif.", "professional.aspx", "", params)
                        Call AddTab("Referees", "referees.aspx", "", params)
                    End If

                Case "employees_sth"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Training Histories", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Training Histories", "training_history.aspx", "", params)
                    End If

                Case "purchases_details"
                    Call AddTab("Pending Purchases", "purchases.aspx?option=PUR_REQ", "", params)
                    Call AddTab("Approved Purchases", "purchases.aspx?option=APPROVED", "", params)
                    Call AddTab("Purchases Delivaries", "purchases.aspx?option=PUR_DELIVER", "", params)

                Case "Delivaries_inward"
                    Call AddTab("Adjustment Inward ", "pur_delivary.aspx?option=ADJ_INWARD", "", params)

                Case "Delivaries_Outward"
                    Call AddTab("Adjustment Outward ", "pur_delivary.aspx?option=ADJ_OUTWARD", "", params)

                Case "purchases_inward"
                    Call AddTab("In ward Delivary", "pur_delivary.aspx?option=INWARD", "", params)

                Case "purchases_outward"
                    Call AddTab("Issueing out ", "pur_delivary.aspx?option=OUTWARD", "", params)

                Case "employees_servicing"
                    Call AddTab("Pending Loan Requests", "loans.aspx?option=PENDING", "", params)
                    Call AddTab("Approved Loans", "loans.aspx?option=APPROVED", "", params)
                    Call AddTab("Confirmed Loans", "loans.aspx?option=CONFIRM", "", params)

                Case "employees_training_needs"
                    Call AddTab("Pending Training needs", "training_needs.aspx?option=PENDING", "", params)
                    Call AddTab("Approved Training Request", "training_needs.aspx?option=APPROVED", "", params)
                Case "employees_medical_events"
                    Call AddTab("Pending Medical  Activities", "medicalevents.aspx?option=PENDING", "", params)
                    Call AddTab("Approved Medical  Activities", "medicalevents.aspx?option=APPROVED", "", params)

                Case "staff_leave_activities"
                    Call AddTab("Pending Leave  Request", "staff_leaves.aspx?option=PENDING", "", params)
                    Call AddTab("Approved Leave  Request", "staff_leaves.aspx?option=APPROVED", "", params)


                Case "employees_servicing_edit"
                    Call AddTab("Staff Loan & Advance", "loans.aspx?option=PENDING", "", params)
                Case "employees_sad"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Appraisals", js, "", "")
                        Call AddTab("Staff Disciplines", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Appraisals", "appraisals.aspx", "", params)
                        Call AddTab("Staff Disciplines", "disciplines.aspx", "", params)
                    End If
                Case "employees_msi"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Medical Details", js, "", "")
                        'Call AddTab("medical Events(Activities)", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Medical Details", "medicaldetails.aspx", "", params)
                        'Call AddTab("Medical Events(Activities)", "medicalevents.aspx", "", params)
                    End If
                Case "employees_sla"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Leave -Activities", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Leave -Activities", "leaves.aspx", "", params)
                    End If

                Case "employees_vop"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Vehicles In Custody", js, "", "")
                        Call AddTab("Other Properties", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Vehicles In Custody", "vehicles.aspx", "", params)
                        Call AddTab("Other Properties", "properties.aspx", "", params)
                    End If

                Case "employees_scom"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you save this employee');"
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Compensations", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "employees.aspx", "", params)
                        Call AddTab("Staff Compensations", "compensations.aspx", "", params)
                    End If

                Case "budget_control"
                    Call AddTab("Operating Expenses Budget", "budget_expenses.aspx", "", "")
                    Call AddTab("Branch Production Budget", "budget_productions.aspx", "", "")
                    Call AddTab("Branch Collection Budget", "budget_collections.aspx", "", "")

                Case "acct_period"
                    Call AddTab("Change Account Period", "accounts_period.aspx", "")

                Case "employees_pay"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"

                        Call AddTab("Employee Details", "pay_employees.aspx", "", params)
                        'Call AddTab("Pay Roll History", js, "", "")
                    Else 'edit
                        Call AddTab("Employee Details", "Pay_employees.aspx", "", params)
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        'Call AddTab("Pay Roll History", js, "", "")
                    End If

                Case "open_pay_rolls"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        Call AddTab("Open Employee pay roll Details ", "pay_rolls.aspx", "", params)
                        'Call AddTab("Pay Roll History", js, "", "")
                    Else 'edit
                        Call AddTab("Open Employee pay roll Details ", "pay_rolls.aspx", "", params)
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        'Call AddTab("Pay Roll History", js, "", "")
                    End If


                Case "mail_pay_rolls"
                 
                    Call AddTab("Mail Employee pay roll Details ", "mail_pay_rolls.aspx", "", params)

                Case "monthly_variance_pay"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        Call AddTab("Employee Monthly Variance Details ", "monthly_variances.aspx", "", params)
                    Else 'edit
                        Call AddTab("Employee Monthly Variance  Details ", "monthly_variances.aspx", "", params)
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                    End If


                Case "view_variance_pay"
                    If Request.QueryString("edit-id") = "" Then
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                        Call AddTab("Employee Monthly Variance View ", "view_variances.aspx", "", params)
                    Else 'edit
                        Call AddTab("Employee Monthly Variance  View ", "view_variances.aspx", "", params)
                        Dim js As String = "javascript:alert('Not available until you select an employee');"
                    End If
            End Select
        End If
    End Sub

    Private Function AddTab(ByVal Caption As String, ByVal LinkTo As String, ByVal ToolTip As String, Optional ByVal Params As String = "") As Boolean
        Dim id As String = ""

        If Request.RawUrl.ToLower Like "*/" & LinkTo.ToLower & "*" Then
            Me.Literal1.Text = Replace(Me.Literal1.Text, "id=""current""", "") : id = "current"
        ElseIf Request.Path.ToLower Like "*/" & Replace(LinkTo.ToLower, ".aspx", "") & "*" Then
            Me.Literal1.Text = Replace(Me.Literal1.Text, "id=""current""", "") : id = "current"
        End If

        Me.Literal1.Text += "<li title=""" & ToolTip & """>"
        Me.Literal1.Text += "<a hidefocus=true id=""" & id & """ href=""" & LinkTo & Params & """>" & Caption & "</a>"
        Me.Literal1.Text += "</li>"
    End Function

    Public WriteOnly Property GroupName() As String
        Set(ByVal Value As String)
            _GroupName = Value
        End Set
    End Property

    Public WriteOnly Property DefaultTab() As String
        Set(ByVal Value As String)
            _DefaultTab = Value
        End Set
    End Property

End Class