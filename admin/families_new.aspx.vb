
Partial Class webroot_web_modules_admin_Region_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim familyID As String = Request.QueryString("edit-id")

            If familyID <> "" Then
                Dim Reg As Hrms3.PurFamily = (New cls_families).SelectThis(familyID)
                mod_ui_helpers.DisableInput(Me.txtfamilyID)

                Me.txtfamilyID.Text = Reg.FamilyID
                Me.txtName.Text = Reg.FamilyName
                Me.txtRemarks.Text = Reg.Description


            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim familyID As String = Request.QueryString("edit-id")

        Dim R As New cls_families
        If familyID <> "" Then
            'fetch the old data first
            Dim Reg As Hrms3.PurFamily = R.SelectThis(familyID)

            'update the necassary fields
            Reg.FamilyName = Me.txtName.Text
            Reg.Description = Me.txtRemarks.Text

            Reg.Modifiedby = mod_main.getLoggedOnUsername()
            Reg.ModifiedOn = DateTime.Now

            'commit to database here
            Dim res As ResponseInfo = R.Update(Reg)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("family", Me.txtfamilyID.Text)
                Response.Redirect("families.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim reg As New Hrms3.PurFamily

            'pass the new values here
            reg.FamilyID = Me.txtfamilyID.Text
            reg.FamilyName = Me.txtName.Text
            reg.Description = Me.txtRemarks.Text
         

            reg.Submitby = mod_main.getLoggedOnUsername()
            reg.SubmitOn = DateTime.Now

            'comit to database here
            Dim res As ResponseInfo = R.Insert(reg)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Family", Me.txtfamilyID.Text)
                Response.Redirect("families.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("families.aspx")
    End Sub
End Class
