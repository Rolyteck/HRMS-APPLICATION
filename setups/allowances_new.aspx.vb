
Partial Class webroot_web_modules_admin_employees_allowances_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            mod_ui_helpers.DisableInput(Me.txtcode)

            Dim CodeID As String = Request.QueryString("edit-id")
            If CodeID <> "" Then
                Dim Gd As Hrms3.AllowanceID = (New cls_AllowancesID).SelectThis(CodeID)

                Me.txtcode.Text = Gd.AllowID
                Me.txtName.Text = Gd.AllowName
                'Me.txtRemarks.Text = Gd.Description
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CodeID As String = Request.QueryString("edit-id")
        Dim U As New cls_AllowancesID
        If CodeID <> "" Then
            'fetch the old data first
            Dim A As Hrms3.AllowanceID = U.SelectThis(CodeID)

            'update the necassary fields
            A.AllowID = Me.txtcode.Text
            A.AllowName = Me.txtName.Text

            'commit to database here
            Dim res As ResponseInfo = U.Update(A)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("allowances.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim A As New Hrms3.AllowanceID
            'pass the new values here
            A.AllowName = Me.txtName.Text
            'comit to database here
            Dim res As ResponseInfo = U.Insert(A)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("allowances.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("allowances.aspx")
    End Sub
End Class
