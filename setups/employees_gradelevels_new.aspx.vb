
Partial Class webroot_web_modules_admin_employees_gradelevels_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            mod_combo_fill.FillPayGroupType(Me.ddlPaygp)

            Dim CodeID As String = Request.QueryString("detail-id")

            If CodeID <> "" Then
                Dim Gd As Hrms3.HPayGrade = (New cls_Hpaygrades).SelectThis(CodeID)
                mod_ui_helpers.DisableInput(Me.txtcode)

                Me.txtcode.Text = Gd.ID
                Me.ddlPaygp.SelectedValue = Gd.StaffGrpID
                Me.txtName.Text = Gd.Name
                Me.txtRemarks.Text = Gd.Description


            End If
            'mod_ui_helpers.MakeDropDownJs(Me, Me.ddlRegions)
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim CodeID As String = Request.QueryString("detail-id")
        Dim G As New cls_Hpaygrades
        If CodeID <> "" Then
            'fetch the old data first
            Dim bra As Hrms3.HPayGrade = G.SelectThis(CodeID)

            'update the necassary fields
            bra.ID = Me.txtcode.Text
            bra.StaffGrpID = Me.ddlPaygp.SelectedItem.Value
            bra.Name = Me.txtName.Text
            bra.Description = Me.txtRemarks.Text
            bra.Tag = Me.ddlPaygp.SelectedItem.Text
            'commit to database here
            Dim res As ResponseInfo = G.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("employees_gradelevels.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.HPayGrade

            'pass the new values here
            bra.ID = Me.txtcode.Text
            bra.StaffGrpID = Me.ddlPaygp.SelectedItem.Value
            bra.Name = Me.txtName.Text
            bra.Tag = Me.ddlPaygp.SelectedItem.Text
            bra.Description = Me.txtRemarks.Text

            'comit to database here
            Dim res As ResponseInfo = G.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("employees_gradelevels.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("employees_gradelevels.aspx")
    End Sub
End Class
