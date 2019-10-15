
Partial Class webroot_web_modules_admin_employees_units_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim CodeID As String = Request.QueryString("edit-id")
            If CodeID <> "" Then
                Dim Gd As Hrms3.HPaySection = (New cls_HpayUnits).SelectThis(CodeID)
                mod_ui_helpers.DisableInput(Me.txtcode)

                Me.txtcode.Text = Gd.Code
                Me.txtName.Text = Gd.Section
                Me.txtRemarks.Text = Gd.Description
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CodeID As String = Request.QueryString("edit-id")
        Dim U As New cls_HpayUnits
        If CodeID <> "" Then
            'fetch the old data first
            Dim bra As Hrms3.HPaySection = U.SelectThis(CodeID)

            'update the necassary fields
            bra.Code = Me.txtcode.Text
            bra.Section = Me.txtName.Text
            bra.Description = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = U.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("employees_units.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.HPaySection
            'pass the new values here
            bra.Code = Me.txtcode.Text
            bra.Section = Me.txtName.Text
            bra.Description = Me.txtRemarks.Text
            'comit to database here
            Dim res As ResponseInfo = U.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("employees_units.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("employees_units.aspx")
    End Sub
End Class
