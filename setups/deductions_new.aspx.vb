
Partial Class webroot_web_modules_admin_employees_deductions_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            mod_ui_helpers.DisableInput(Me.txtcode)
            Dim CodeID As String = Request.QueryString("edit-id")
            If CodeID <> "" Then
                Dim Gd As Hrms3.DeductionID = (New cls_DeductionsID).SelectThis(CodeID)


                Me.txtcode.Text = Gd.DedID
                Me.txtName.Text = Gd.DedName
                'Me.txtRemarks.Text = Gd.Description
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CodeID As String = Request.QueryString("edit-id")
        Dim U As New cls_DeductionsID

        If CodeID <> "" Then
            'fetch the old data first
            Dim D As Hrms3.DeductionID = U.SelectThis(CodeID)

            'update the necassary fields
            D.DedID = Me.txtcode.Text
            D.DedName = Me.txtName.Text
            Dim res As ResponseInfo = U.Update(D)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("deductions.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim D As New Hrms3.DeductionID
            'pass the new values here
            'D.DedID = Me.txtcode.Text
            D.DedName = Me.txtName.Text
    
            Dim res As ResponseInfo = U.Insert(D)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("deductions.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("deductions.aspx")
    End Sub
End Class
