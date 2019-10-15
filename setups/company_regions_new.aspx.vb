
Partial Class webroot_web_modules_admin_Region_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim RegionID As String = Request.QueryString("edit-id")

            If RegionID <> "" Then
                Dim Reg As Hrms3.Region = (New cls_Regions).SelectThis(RegionID)
                mod_ui_helpers.DisableInput(Me.txtRegionID)

                Me.txtRegionID.Text = Reg.RegionID
                Me.txtRegName.Text = Reg.Region
                Me.txtManager.Text = Reg.Manager
                Me.txtAddress.Text = Reg.Address
                Me.txtFaxNo.Text = Reg.Fax
                Me.txtEmail.Text = Reg.Email
                Me.txtPhone1.Text = Reg.MobilePhone
                Me.txtPhone2.Text = Reg.LandPhone
                Me.txtRemarks.Text = Reg.Remarks
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim RegionID As String = Request.QueryString("edit-id")

        Dim R As New cls_Regions
        If RegionID <> "" Then
            'fetch the old data first
            Dim Reg As Hrms3.Region = R.SelectThis(RegionID)

            'update the necassary fields
            Reg.Region = Me.txtRegName.Text
            Reg.Manager = Me.txtManager.Text
            Reg.Address = Me.txtAddress.Text
            Reg.Fax = Me.txtFaxNo.Text
            Reg.Email = Me.txtEmail.Text
            Reg.MobilePhone = Me.txtPhone1.Text
            Reg.LandPhone = Me.txtPhone2.Text
            Reg.Remarks = Me.txtRemarks.Text

            Reg.Modifiedby = mod_main.getLoggedOnUsername()
            Reg.ModifiedOn = DateTime.Now

            'commit to database here
            Dim res As ResponseInfo = R.Update(Reg)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Region", Me.txtRegionID.Text)
                Response.Redirect("company_regions.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim reg As New Hrms3.Region

            'pass the new values here
            reg.RegionID = Me.txtRegionID.Text
            reg.Region = Me.txtRegName.Text
            reg.Manager = Me.txtManager.Text
            reg.Address = Me.txtAddress.Text
            reg.Fax = Me.txtFaxNo.Text
            reg.Email = Me.txtEmail.Text
            reg.MobilePhone = Me.txtPhone1.Text
            reg.LandPhone = Me.txtPhone2.Text
            reg.Remarks = Me.txtRemarks.Text

            reg.SubmittedBy = mod_main.getLoggedOnUsername()
            reg.SubmittedOn = DateTime.Now

            'comit to database here
            Dim res As ResponseInfo = R.Insert(reg)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Region", Me.txtRegionID.Text)
                Response.Redirect("company_regions.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("company_regions.aspx")
    End Sub
End Class
