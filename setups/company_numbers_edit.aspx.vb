
Partial Class webroot_web_modules_marketing_smsemail_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim AutoNum As String = Request.QueryString("edit-id")

            If AutoNum <> "" Then
                mod_ui_helpers.DisableInput(Me.txtAutoNum)
                Dim a As Hrms3.AutoNumber = (New cls_AutoNumber).SelectThis(AutoNum, "ALL")

                Me.txtAutoNum.Text = AutoNum
                If a.NumType <> "" Then 'all branches
                    Try
                        Me.RadioButtonList1.SelectedIndex = 0
                        Me.txtNextValue.Text = a.NextValue
                        Me.txtFormat.Text = a.Format
                        Me.lnkFormat.Visible = False
                        Me.lnkNextVal.Visible = False
                    Catch
                    End Try

                Else
                    Me.RadioButtonList1.SelectedIndex = 1
                    'mod_ui_helpers.DisableInput(Me.txtFormat)
                    'mod_ui_helpers.DisableInput(Me.txtNextValue)
                    Me.lnkFormat.Visible = True
                    Me.lnkNextVal.Visible = True

                    Me.GridView1.DataSource = CreateDataSource()
                    Me.GridView1.DataBind()
                End If
            End If
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedIndex = 0 Then 'all branches
            mod_ui_helpers.EnableInput(Me.txtFormat)
            mod_ui_helpers.EnableInput(Me.txtNextValue)
            Me.lnkFormat.Visible = False
            Me.lnkNextVal.Visible = False

            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        Else
            'mod_ui_helpers.DisableInput(Me.txtFormat)
            'mod_ui_helpers.DisableInput(Me.txtNextValue)
            Me.lnkFormat.Visible = True
            Me.lnkNextVal.Visible = True

            Me.GridView1.DataSource = CreateDataSource()
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim Aut As New cls_AutoNumber
        Dim Aa As Hrms3.AutoNumber = Aut.SelectThis(Me.txtAutoNum.Text, "ALL")


        If Me.RadioButtonList1.SelectedIndex = 0 Then 'all branches
            Aa.NextValue = Me.txtNextValue.Text
            Aa.Format = Me.txtFormat.Text
            'Aa.Sample =  Me.txtAutoNum.Text

            If Aa.NumType <> "" Then
                Aa.LastUpdated = Now
                Aut.Update(Aa)
            Else
                Aa = New Hrms3.AutoNumber
                Aa.NumType = Me.txtAutoNum.Text
                Aa.BranchID = "ALL"
                Aa.LastUpdated = Now
                Aut.Insert(Aa)
            End If
        Else
            Aut.Delete(Aa)
            'save all the branches here

        End If

        Response.Redirect("company_numbers.aspx")
    End Sub

    Private Function CreateDataSource() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("BranchID", GetType(String)))
        dt.Columns.Add(New DataColumn("Branch", GetType(String)))
        dt.Columns.Add(New DataColumn("NextVal", GetType(String)))
        dt.Columns.Add(New DataColumn("Format", GetType(String)))
        dt.Columns.Add(New DataColumn("Sample", GetType(String)))

        Dim Branches As List(Of Hrms3.Branch) = (New cls_Branches).SelectAll

        For Each Br In Branches
            Dim dr As DataRow = dt.NewRow()
            Dim Aa As Hrms3.AutoNumber = (New cls_AutoNumber).SelectThis(Me.txtAutoNum.Text, Br.BranchID)
            dr(0) = Br.BranchID
            dr(1) = Br.Description
            dr(2) = Aa.NextValue
            dr(3) = Aa.Format
            dr(4) = Aa.Sample
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        Me.GridView1.EditIndex = -1
        Me.GridView1.DataSource = CreateDataSource()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Me.GridView1.EditIndex = e.NewEditIndex
        Me.GridView1.DataSource = CreateDataSource()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim BranchID As String = Me.GridView1.Rows(e.RowIndex).Cells(1).Text
        Dim Aut As New cls_AutoNumber
        Dim Aa As Hrms3.AutoNumber = Aut.SelectThis(Me.txtAutoNum.Text, BranchID)

        If Aa.NumType <> "" Then
            Aa.NextValue = CType(Me.GridView1.Rows(e.RowIndex).Cells(3).Controls(0), TextBox).Text
            Aa.Format = CType(Me.GridView1.Rows(e.RowIndex).Cells(4).Controls(0), TextBox).Text
            'Aa.Sample = CType(Me.GridView1.Rows(e.RowIndex).Cells(0).Controls(0), TextBox).Text
            Aa.LastUpdated = Now
            Aut.Update(Aa)
        Else
            Aa = New Hrms3.AutoNumber
            Aa.NumType = Me.txtAutoNum.Text
            Aa.BranchID = BranchID
            Aa.NextValue = CType(Me.GridView1.Rows(e.RowIndex).Cells(3).Controls(0), TextBox).Text
            Aa.Format = CType(Me.GridView1.Rows(e.RowIndex).Cells(4).Controls(0), TextBox).Text
            'Aa.Sample = CType(Me.GridView1.Rows(e.RowIndex).Cells(0).Controls(0), TextBox).Text
            Aa.LastUpdated = Now
            Aut.Insert(Aa)
        End If
        GridView1.EditIndex = -1
        Me.GridView1.DataSource = CreateDataSource()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub lnkFormat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFormat.Click
        Dim Branches As List(Of Hrms3.Branch) = (New cls_Branches).SelectAll
        Dim Aut As New cls_AutoNumber

        For Each Br In Branches
            Dim Aa As Hrms3.AutoNumber = Aut.SelectThis(Me.txtAutoNum.Text, Br.BranchID)
            If Aa.NumType <> "" Then
                Aa.Format = Me.txtFormat.Text
                Aut.Update(Aa)
            Else
                Aa = New Hrms3.AutoNumber
                Aa.NumType = Me.txtAutoNum.Text
                Aa.BranchID = Br.BranchID
                Aa.Format = Me.txtFormat.Text
                Aa.LastUpdated = Now
                Aut.Insert(Aa)
            End If
        Next
        Me.GridView1.DataSource = CreateDataSource()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub lnkNextVal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNextVal.Click
        Dim Branches As List(Of Hrms3.Branch) = (New cls_Branches).SelectAll
        Dim Aut As New cls_AutoNumber

        For Each Br In Branches
            Dim Aa As Hrms3.AutoNumber = Aut.SelectThis(Me.txtAutoNum.Text, Br.BranchID)
            If Aa.NumType <> "" Then
                Aa.NextValue = Me.txtNextValue.Text
                Aut.Update(Aa)
            Else
                Aa = New Hrms3.AutoNumber
                Aa.NumType = Me.txtAutoNum.Text
                Aa.BranchID = Br.BranchID
                Aa.NextValue = Me.txtNextValue.Text
                Aa.LastUpdated = Now
                Aut.Insert(Aa)
            End If
        Next
        Me.GridView1.DataSource = CreateDataSource()
        Me.GridView1.DataBind()
    End Sub
End Class
