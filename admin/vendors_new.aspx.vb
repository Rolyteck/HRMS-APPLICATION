
Partial Class webroot_web_modules_admin_branch_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim CompanyID As String = Request.QueryString("edit-id")
            If CompanyID <> "" Then
                Dim Bra As Hrms3.Company = (New cls_Companies).SelectThis(CompanyID)
                mod_ui_helpers.DisableInput(Me.txtbranchID)
                Me.txtbranchID.Text = Bra.CompanyID
                Me.txtbranchName.Text = Bra.Company
                Me.txtAddress.Text = Bra.Address
                Me.txtPhone1.Text = Bra.MobilePhone
                Me.txtPhone2.Text = Bra.LandPhone
                Me.txtEmail.Text = Bra.Email
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CompanyID As String = Request.QueryString("edit-id")
        Dim C As New cls_Companies

        If CompanyID <> "" Then
            'fetch the old data first
            Dim bra As Hrms3.Company = C.SelectThis(CompanyID)
            bra.CompanyID = Me.txtbranchID.Text
            bra.Company = Me.txtbranchName.Text
            bra.CompanyType = "VENDOR"
            bra.Address = Me.txtAddress.Text
            bra.MobilePhone = Me.txtPhone1.Text
            bra.LandPhone = Me.txtPhone2.Text
            bra.Email = Me.txtEmail.Text
            bra.Modifiedby = mod_main.getLoggedOnUsername()
            bra.ModifiedOn = DateTime.Now
            'commit to database here
            Dim res As ResponseInfo = C.Update(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("company", Me.txtbranchID.Text)
                Response.Redirect("vendors.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.Company
            bra.CompanyID = Me.txtbranchID.Text
            bra.Company = Me.txtbranchName.Text
            bra.CompanyType = "VENDOR"
            bra.Address = Me.txtAddress.Text
            bra.MobilePhone = Me.txtPhone1.Text
            bra.LandPhone = Me.txtPhone2.Text
            bra.Email = Me.txtEmail.Text
            bra.SubmittedBy = mod_main.getLoggedOnUsername()
            bra.SubmittedOn = DateTime.Now
            'comit to database here
            Dim res As ResponseInfo = C.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Company", Me.txtbranchID.Text)
                Response.Redirect("vendors.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("vendors.aspx")
    End Sub
End Class
