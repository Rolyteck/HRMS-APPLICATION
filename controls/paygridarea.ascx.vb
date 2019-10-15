
Partial Class webroot_web_controls_Pay_gridarea
    Inherits System.Web.UI.UserControl

    Protected _GroupName As String = "und_policy"
    Protected _hideFilterBox As Boolean = False
    Protected _allowPaging As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mod_ui_helpers.MakeDropDownJs(Me.Page, Me.cbSearchOn)
        If Not Page.IsPostBack Then
            mod_combo_fill.FillPayGroup(Me.cdbPaysheet)
            mod_combo_fill.FillTypesPay(Me.cdbPayoption)
            mod_combo_fill.FillGradelevel2(Me.cdbGradelevel)
            'Dim P As Long
            'For P = -36 To 6
            '    Me.cdbPayPeriod.Items.Add(FormatDate2(DateAdd(DateInterval.Month, P, Today.Date)))
            'Next P
            'Me.cdbPayPeriod.Items.Insert(0, New ListItem(FormatDate2(Today.Date), FormatDate2(Today.Date)))
            Dim P As Long
            For P = -24 To 6
                Me.cdbPayPeriod.Items.Add(Format(DateAdd(DateInterval.Month, P, Today.Date), "MMMM yyyy"))
            Next P
            cdbPayPeriod.Items.Insert(0, New ListItem("- select -", "NULL"))

            Dim Q As Long
            For Q = -24 To 6
                Me.cdbPayNextmonth.Items.Add(Format(DateAdd(DateInterval.Month, Q, Today.Date), "MMMM yyyy"))
            Next Q
            cdbPayNextmonth.Items.Insert(0, New ListItem("- select -", "NULL"))




            Me.cdbPaysheet.SelectedIndex = 0
        End If
        SetupGridView()
        Me.cdbPayPeriod.Visible = False
        Me.lblperiod.Visible = False
        Me.cdbGradelevel.Visible = False
        Me.lblgradeLevel.Visible = False

        If _GroupName = "hr_pay_rolls" Then
            Me.cdbPaysheet.Visible = True
            Me.lblsheet.Visible = True
            Me.cdbPayPeriod.Visible = True
            Me.lblperiod.Visible = True
            'Me.ExpandingImageButton1.Expanded = False
        ElseIf _GroupName = "monthly_pay_process" Then

            Me.cdbPaysheet.Visible = True
            Me.lblsheet.Visible = True
            Me.cdbPayPeriod.Visible = True
            Me.lblperiod.Visible = True
            Me.cdbPayNextmonth.Visible = True
            Me.NextMonth.Visible = True
            Me.lblperiod.Text = "Previous Month:"
            Me.NextMonth.Text = "Next Month:"

        ElseIf _GroupName = "monthly_variance_list" Then

            Me.cdbPaysheet.Visible = True
            Me.lblsheet.Visible = True
            Me.cdbPayPeriod.Visible = True
            Me.lblperiod.Visible = True

        ElseIf _GroupName = "view_variance_list" Then

            Me.cdbPaysheet.Visible = True
            Me.lblsheet.Visible = True
            Me.cdbPayPeriod.Visible = True
            Me.lblperiod.Visible = True

        ElseIf _GroupName = "admin_payallowances_list" Then
            Me.cdbPaysheet.Visible = False
            Me.lblsheet.Visible = False
            Me.cdbPayPeriod.Visible = False
            Me.lblperiod.Visible = False
            Me.cdbGradelevel.Visible = True
            Me.lblgradeLevel.Visible = True
            Me.txtSearchStr.Visible = False
            Me.cbSearchOn.Visible = False
            Me.lblwhere.Visible = False
            Me.lblContains.Visible = False

        ElseIf _GroupName = "admin_paydeductions_list" Then
            Me.cdbPaysheet.Visible = False
            Me.lblsheet.Visible = False
            Me.cdbPayPeriod.Visible = False
            Me.lblperiod.Visible = False
            Me.cdbGradelevel.Visible = True
            Me.lblgradeLevel.Visible = True
            Me.txtSearchStr.Visible = False
            Me.cbSearchOn.Visible = False
            Me.lblwhere.Visible = False
            Me.lblContains.Visible = False

        End If
        If _hideFilterBox = True Then
            Me.filterBoxDiv.Visible = False
        End If

    End Sub

    Protected Sub cmdFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFilter.Click

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

                Case "admin_payallowances_list"
                    editPath += AppendQueryString("pay_sheet_allowances_new.aspx")
                    Me.InitGridView("pay_sheets_allowances", Nothing, 25)
                    AppendSelectField(GridView, "", "HID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "AllowID", "HID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "AllowName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Amount", "Value1", HorizontalAlign.Right, , "{0:n0}")
                    AppendBoundField(GridView, "Grade level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Steps", "Steps", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "AllowName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "AllowID"))
                    End If
                    .DataSource = (New cls_HpayAllowances).SelectThisGrade(Val(Me.cdbGradelevel.SelectedValue))
                Case "admin_paydeductions_list"
                    editPath += AppendQueryString("pay_sheet_deductions_new.aspx")
                    Me.InitGridView("pay_sheets_allowances", Nothing, 25)
                    AppendSelectField(GridView, "", "HID", ListSelectionMode.Multiple, , "1px")
                    AppendHyLinkField(GridView, "Code", "dedID", "HID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Names", "DedName", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Amount", "Value1", HorizontalAlign.Right, , "{0:n0}")
                    AppendBoundField(GridView, "Grade level", "Grade", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Steps", "Steps", HorizontalAlign.Left)

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Name", "DedName"))
                        Me.cbSearchOn.Items.Add(New ListItem("Code", "dedID"))
                    End If
                    .DataSource = (New cls_HpayDeductions).SelectThisGrade(Val(Me.cdbGradelevel.SelectedValue))

                Case "hr_employees"
                    editPath += AppendQueryString("pay_employees_edit.aspx")
                    Me.InitGridView("pay_employees", Nothing, 25)

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
                    .DataSource = (New cls_employees).SelectWHereActive(Val(Me.cdbPaysheet.SelectedValue), Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)

                Case "hr_pay_rolls", "monthly_variance_list", "view_variance_list", "monthly_pay_process"
                    Select Case _GroupName
                        Case "hr_pay_rolls", "monthly_pay_process"
                            editPath += AppendQueryString("pay_rolls_edit.aspx")
                        Case "monthly_variance_list"
                            editPath += AppendQueryString("monthly_variances_edit.aspx")
                        Case "view_variance_list"
                            editPath += AppendQueryString("view_variances_edit.aspx")
                    End Select

                    Me.InitGridView("Pay_Rolls", Nothing, 25)
                    AppendSelectField(GridView, "", "ID", ListSelectionMode.Multiple)
                    AppendHyLinkField(GridView, "Employee No", "EmployeeID", "ID", "{0:g}", editPath, HorizontalAlign.Left)
                    AppendBoundField(GridView, "Surname", "Surname", HorizontalAlign.Left)
                    AppendBoundField(GridView, "OtherNames", "Othernames", HorizontalAlign.Left)
                    AppendBoundField(GridView, "Grade Level", "Grade", HorizontalAlign.Left)
                    'AppendBoundField(GridView, "Gross Amount", "GrossPay", HorizontalAlign.Right, , "{0:n0}")
                    'AppendBoundField(GridView, "Net Amount", "NetPay", HorizontalAlign.Right, , "{0:n0}")

                    If Not Me.Page.IsPostBack Then
                        Me.cbSearchOn.Items.Add(New ListItem("Employee No", "EmployeeID"))
                        Me.cbSearchOn.Items.Add(New ListItem("Surname", "Surname"))
                    End If

                    Dim P As New cls_payslips
                    Select Case _GroupName
                        Case "hr_pay_rolls", "monthly_pay_process"
                            .DataSource = P.SelectAllPaidEmployees(Me.cdbPayPeriod.SelectedValue, Val(Me.cdbPaysheet.SelectedValue), Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)
                        Case "monthly_variance_list", "view_variance_list"
                            .DataSource = P.SelectAllPaidEmployees(Me.cdbPayPeriod.SelectedItem.Value, Val(Me.cdbPaysheet.SelectedValue), Me.cbSearchOn.SelectedValue, Me.txtSearchStr.Text)
                    End Select
                Case Else
                    Exit Sub
            End Select
            Try
                If .DataSource.Count = 0 Then 'just to make sure d grids is shown
                    Dim t As Type = .DataSource.GetType().GetGenericArguments()(0)
                    Dim i = Activator.CreateInstance(t, True)
                    For Each info As Reflection.PropertyInfo In t.GetProperties()
                        If info.CanWrite AndAlso info.PropertyType Is GetType(String) Then
                            info.SetValue(i, "--em@#$%^?ty--", Nothing)
                        End If
                    Next
                    .DataSource.Add(i)
                End If
            Catch ex As Exception
            End Try
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

    Public Property DateFrom() As String
        Get
            Return cdbPayPeriod.SelectedItem.Text
        End Get
        Set(ByVal value As String)
            cdbPayPeriod.SelectedValue = value
        End Set
    End Property

    Public Property DateTo() As String
        Get
            Return cdbPayNextmonth.SelectedItem.Text
        End Get
        Set(ByVal value As String)
            cdbPayNextmonth.SelectedValue = value
        End Set
    End Property
#End Region

End Class
