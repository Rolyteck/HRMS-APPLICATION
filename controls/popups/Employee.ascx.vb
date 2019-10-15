
Partial Class webroot_web_controls_party
    Inherits System.Web.UI.UserControl

    Public Event SelectedItemChanged(ByVal NewParty As Hrms3.HREmployee)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtCode.Attributes.Add("onclick", "pop_showModalPopup('" & Me.txtSearch.ClientID & "','" & Me.mpe.ClientID & "');")
        Me.txtSearch.Attributes.Add("onkeyup", "pop_onSearchKeyPress('" & Me.lbMsg.ClientID & "','" & Me.txtCode.ClientID & "','" & Me.txtSearch.ClientID & "','" & Me.uPnlModal.ClientID & "');")
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "uc-popups", "<script src='/webroot/web/controls/popups/popups.js' type='text/javascript'></script>")
    End Sub

    Protected Sub uPnlControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles uPnlControl.Load
        If Me.Request.Params("__EVENTARGUMENT") = "" Then Exit Sub
        Dim I As Hrms3.HREmployee = (New cls_employees).SelectThis(Me.txtCode.Text)

        Me.txtCode.Text = I.EmployeeID & "\" & I.Surname
        Me.txtHiddenCode.Value = I.EmployeeID
        Me.txtHiddenName.Value = I.Surname & " " & I.OtherNames


        RaiseEvent SelectedItemChanged(I)
    End Sub

    Protected Sub uPnlModal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles uPnlModal.Load
        Select Case Me.Request.Params("__EVENTARGUMENT")
            Case "gridview"
                Dim contextKey As String = Me.txtSearch.Text
                Dim strSQL As String = "SELECT TOP 500 EmployeeID, Surname, OtherNames FROM HREmployees WHERE Surname LIKE '%" & contextKey & "%'"

                Dim Conn As New Data.SqlClient.SqlConnection(m_strConnString)

                Me.GridView1.DataSource = New DataView(mod_main.getAdhocTable(strSQL, Conn))
                Me.GridView1.DataBind()
                Me.GridView1.EmptyDataText = "No Vendor found with this name."
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

    Public Property SelectedText() As String
        Get
            Return Me.txtHiddenName.Value
        End Get
        Set(ByVal value As String)
            Me.txtHiddenName.Value = value
        End Set

    End Property

    Public Property SelectedValue() As String
        Get
            Return Me.txtHiddenCode.Value
        End Get
        Set(ByVal value As String)
            Me.txtHiddenCode.Value = value
            Dim i As Hrms3.HREmployee = (New cls_employees).SelectThis(value)
            Me.txtCode.Text = i.EmployeeID & "\" & i.Surname & "" & i.OtherNames
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
