
Partial Class webroot_web_modules_admin_pay_sheets_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            mod_combo_fill.Fillfrquency(cdbgfrequency)
            Dim CodeID As String = Request.QueryString("edit-id")
            If CodeID <> "" Then
                Dim Gd As Hrms3.PaySheet = (New cls_paysheets).SelectThis(CodeID)
                Me.txtName.Text = Gd.PaySheet
                Me.cdbgfrequency.SelectedValue = Gd.Frequency
                Me.txtRemarks.Text = Gd.Remarks
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CodeID As String = Request.QueryString("edit-id")

        Dim C As New cls_paysheets


        If CodeID <> "" Then
            'fetch the old data first
            Dim bra As Hrms3.PaySheet = C.SelectThis(CodeID)
            'update the necassary fields
            bra.SheetID = Request.QueryString("edit-id")
            bra.PaySheet = Me.txtName.Text
            bra.Frequency = Me.cdbgfrequency.SelectedItem.Value
            bra.Remarks = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = C.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtName.Text)
                Response.Redirect("pay_sheets.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.PaySheet
            'pass the new values here
            bra.PaySheet = Me.txtName.Text
            bra.Frequency = Me.cdbgfrequency.SelectedItem.Value
            bra.Remarks = Me.txtRemarks.Text
            'comit to database here
            Dim res As ResponseInfo = C.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtName.Text)
                Response.Redirect("pay_sheets.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("pay_sheets.aspx")
    End Sub
End Class
