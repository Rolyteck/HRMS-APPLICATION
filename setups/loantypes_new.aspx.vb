
Partial Class webroot_web_modules_admin_employees_allowances_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtcode.Visible = False
        If Not Page.IsPostBack Then

            mod_ui_helpers.DisableInput(Me.txtcode)

            Dim CodeID As String = Request.QueryString("edit-id")
            If CodeID <> "" Then
                Dim Gd As Hrms3.VPayDeduction = (New cls_VpayDeductions).SelectThis(CodeID)

                Me.txtcode.Text = Gd.DedID
                Me.txtName.Text = Gd.DedName
                Me.txtLoanRate.Text = Gd.Value2 & vbNullString
                Me.txtRemarks.Text = Gd.Description

                'Me.txtRemarks.Text = Gd.Description
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CodeID As String = Request.QueryString("edit-id")
        Dim U As New cls_VpayDeductions
        If CodeID <> "" Then
            'fetch the old data first
            Dim A As Hrms3.VPayDeduction = U.SelectThis(CodeID)

            'update the necassary fields
            A.DedID = Me.txtcode.Text
            A.DedName = Me.txtName.Text
            A.Value2 = Me.txtLoanRate.Text
            A.Description = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = U.Update(A)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("loantypes.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim A As New Hrms3.VPayDeduction
            'pass the new values here
            A.DedName = Me.txtName.Text
            A.Value2 = Me.txtLoanRate.Text
            A.Description = Me.txtRemarks.Text
            'comit to database here
            Dim res As ResponseInfo = U.Insert(A)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("loantypes.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("loantypes.aspx")
    End Sub

    Protected Sub cmdSaveAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSaveAdd.Click

        Dim CodeID As String = Request.QueryString("edit-id")
        Dim U As New cls_VpayDeductions
        If CodeID <> "" Then
            'fetch the old data first
            'fetch the old data first
            Dim A As Hrms3.VPayDeduction = U.SelectThis(CodeID)

            'update the necassary fields
            A.DedID = Me.txtcode.Text
            A.DedName = Me.txtName.Text
            A.Value2 = Me.txtLoanRate.Text
            A.Description = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = U.Update(A)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)

            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim A As New Hrms3.VPayDeduction
            'pass the new values here
            A.DedName = Me.txtName.Text
            A.Value2 = Me.txtLoanRate.Text
            A.Description = Me.txtRemarks.Text
            'comit to database here

            Dim res As ResponseInfo = U.Insert(A)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)

            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If


        Me.txtName.Text = ""
        Me.txtLoanRate.Text = 0
        Me.txtRemarks.Text = ""

    End Sub
End Class
