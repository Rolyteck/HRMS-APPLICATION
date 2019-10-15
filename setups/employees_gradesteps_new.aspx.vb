
Partial Class webroot_web_modules_admin_employees_gradesteps_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then


            Dim CodeID As String = Request.QueryString("edit-id")

            If CodeID <> "" Then
                Dim Gd As Hrms3.HRStep = (New cls_Hrsteps).SelectThis(CodeID)
                mod_ui_helpers.DisableInput(Me.txtcode)

                Me.txtcode.Text = Gd.ID
                Me.txtName.Text = Gd.Name
                Me.txtRemarks.Text = Gd.Remarks


            End If
            'mod_ui_helpers.MakeDropDownJs(Me, Me.ddlRegions)
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CodeID As String = Request.QueryString("edit-id")
        Dim H As New cls_Hrsteps

        If CodeID <> "" Then
            'fetch the old data first
            Dim bra As Hrms3.HRStep = H.SelectThis(CodeID)

            'update the necassary fields
            bra.ID = Me.txtcode.Text
            bra.Name = Me.txtName.Text
            bra.Remarks = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = H.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Code", Me.txtcode.Text)
                Response.Redirect("employees_gradesteps.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.HRStep

            'pass the new values here
            bra.ID = Me.txtcode.Text
            bra.Name = Me.txtName.Text
            bra.Remarks = Me.txtRemarks.Text

            'comit to database here
            Dim res As ResponseInfo = (New cls_Hrsteps).Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("code", Me.txtcode.Text)
                Response.Redirect("employees_gradesteps.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("employees_gradesteps.aspx")
    End Sub
End Class
