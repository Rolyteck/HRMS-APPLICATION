
Partial Class webroot_web_modules_admin_employees_depts_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim CodeID As String = Request.QueryString("edit-id")
            If CodeID <> "" Then
                Dim Gd As Hrms3.HPayDept = (New cls_HpayDepts).SelectThis(CodeID)
                mod_ui_helpers.DisableInput(Me.txtcode)
                Me.txtcode.Text = Gd.Code
                Me.txtName.Text = Gd.Name
                Me.txtRemarks.Text = Gd.Remark
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim CodeID As String = Request.QueryString("edit-id")

        Dim D As New cls_HpayDepts
        If CodeID <> "" Then
            'fetch the old data first
            Dim bra As Hrms3.HPayDept = D.SelectThis(CodeID)
            'update the necassary fields
            bra.Code = Me.txtcode.Text
            bra.Name = Me.txtName.Text
            bra.Remark = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = D.Update(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("employees_depts.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.HPayDept
            'pass the new values here
            bra.Code = Me.txtcode.Text
            bra.Name = Me.txtName.Text
            bra.Remark = Me.txtRemarks.Text
            'comit to database here
            Dim res As ResponseInfo = D.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("employees_depts.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("employees_depts.aspx")
    End Sub
End Class
