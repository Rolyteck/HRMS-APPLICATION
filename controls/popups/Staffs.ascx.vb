
Partial Class webroot_web_controls_StaffDetails
    Inherits System.Web.UI.UserControl

    Public Event SelectedItemChanged(ByVal NewNote As Hrms3.HREmployee)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtCode.Attributes.Add("onclick", "pop_showModalPopup('" & Me.txtSearch.ClientID & "','" & Me.mpe.ClientID & "');")
        Me.txtSearch.Attributes.Add("onkeyup", "pop_onSearchKeyPress('" & Me.lbMsg.ClientID & "','" & Me.txtCode.ClientID & "','" & Me.txtSearch.ClientID & "','" & Me.uPnlModal.ClientID & "');")
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "uc-popups", "<script src='/webroot/web/controls/popups/popups.js' type='text/javascript'></script>")

        mod_ui_helpers.DisableInput(Me.txtBranch)
        mod_ui_helpers.DisableInput(Me.txtGradelevel)
        mod_ui_helpers.DisableInput(Me.txtSurname)
        mod_ui_helpers.DisableInput(Me.txtOtherNames)
        mod_ui_helpers.DisableInput(Me.txtconfirmstatus)

  
    End Sub

    Protected Sub uPnlControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles uPnlControl.Load
        Select Case Me.Request.Params("__EVENTARGUMENT")
            Case "update"
                Dim I As Hrms3.HREmployee = (New cls_employees).SelectThis(Me.txtCode.Text)
                Me.txtBranch.Text = I.Branch
                Me.txtSurname.Text = I.Surname
                Me.txtOtherNames.Text = I.OtherNames
                Me.txtGradelevel.Text = I.Grade
                Me.txtconfirmstatus.Text = I.ConfirmStatus
                RaiseEvent SelectedItemChanged(I)
            Case Else

        End Select

    End Sub

    Protected Sub uPnlModal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles uPnlModal.Load
        Select Case Me.Request.Params("__EVENTARGUMENT")
            Case "gridview"
                Me.GridView1.Visible = True
                Me.premcalc1.Visible = False

                Dim contextKey As String = Me.txtSearch.Text
                Dim strSQL As String = "SELECT TOP 50 EmployeeID, Surname, OtherNames, Grade FROM HREmployees WHERE (Surname LIKE '%" & contextKey & "%' OR OtherNames LIKE'%" & contextKey & "%') "

                Dim Conn As New Data.SqlClient.SqlConnection(m_strConnString)
                Me.GridView1.DataSource = New DataView(mod_main.getAdhocTable(strSQL, Conn))
                Me.GridView1.DataBind()
            Case Else

        End Select
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        With e.Row
            Select Case .RowType
                Case DataControlRowType.DataRow
                    .Attributes.Add("onmouseover", "javascript:datagrid_rowHover(this, 1);")
                    .Attributes.Add("onmouseout", "javascript:datagrid_rowHover(this, 0);")
                    .Attributes.Add("onclick", "javascript:datagrid_selectOneRow(this);pop_itemSelected('" & Me.txtCode.ClientID & "','" & Me.mpe.ClientID & "','" & Me.uPnlControl.ClientID & "','" & .Cells(0).Text & "');")
                Case DataControlRowType.Header
                Case Else

            End Select
        End With
    End Sub

    Public Property NoteType() As String
        Get
            Return Me.txtCode.AccessKey
        End Get
        Set(ByVal value As String)
            Me.txtCode.AccessKey = value.Substring(0, 1)
        End Set
    End Property

    Public Property SelectedText() As String
        Get
            Return Me.txtCode.Text
        End Get
        Set(ByVal value As String)
            Me.txtCode.Text = value
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            Return Me.txtCode.Text
        End Get
        Set(ByVal value As String)
            Me.txtCode.Text = value
            Dim I As Hrms3.HREmployee = (New cls_employees).SelectThis(Me.txtCode.Text)
            Me.txtBranch.Text = I.Branch
            Me.txtSurname.Text = I.Surname
            Me.txtOtherNames.Text = I.OtherNames
            Me.txtGradelevel.Text = I.Grade
            Me.txtconfirmstatus.Text = I.ConfirmStatus
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Me.txtCode.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.txtCode.Enabled = value
            If value Then
                mod_ui_helpers.EnableInput(Me.txtCode)
            Else
                mod_ui_helpers.DisableInput(Me.txtCode)
            End If
        End Set
    End Property
End Class
