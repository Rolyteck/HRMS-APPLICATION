
Partial Class webroot_web_modules_admin_branch_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            mod_combo_fill.FillRegions(Me.ddlRegions)
            mod_combo_fill.Fillstate(Me.ddlState)
            Dim branchID As String = Request.QueryString("edit-id")

            If branchID <> "" Then
                Dim Bra As Hrms3.Branch = (New cls_Branches).SelectThis(branchID)
                mod_ui_helpers.DisableInput(Me.txtbranchID)

                Me.txtbranchID2.Text = Bra.BranchID2
                Me.txtbranchID.Text = Bra.BranchID
                Me.ddlRegions.SelectedValue = Bra.RegionID
                Me.ddlState.SelectedValue = Bra.StateID
                Me.txtbranchName.Text = Bra.Description
                Me.txtManager.Text = Bra.Manager
                Me.txtAddress.Text = Bra.Address
                Me.txtPhone1.Text = Bra.MobilePhone
                Me.txtPhone2.Text = Bra.LandPhone
                Me.txtEmail.Text = Bra.Email
                Me.txtFaxNo.Text = Bra.Fax
                Me.txtRemarks.Text = Bra.Remarks
            End If
            'mod_ui_helpers.MakeDropDownJs(Me, Me.ddlRegions)
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim branchID As String = Request.QueryString("edit-id")
        Dim B As New cls_Branches
        If branchID <> "" Then
            'fetch the old data first

            Dim bra As Hrms3.Branch = B.SelectThis(branchID)

            'update the necassary fields
            bra.BranchID2 = Me.txtbranchID2.Text
            bra.RegionID = Me.ddlRegions.SelectedItem.Value
            bra.StateID = Me.ddlState.SelectedItem.Value

            bra.Description = Me.txtbranchName.Text
            bra.Manager = Me.txtManager.Text
            bra.Address = Me.txtAddress.Text
            bra.MobilePhone = Me.txtPhone1.Text
            bra.LandPhone = Me.txtPhone2.Text
            bra.Email = Me.txtEmail.Text
            bra.Fax = Me.txtFaxNo.Text
            bra.Remarks = Me.txtRemarks.Text

            bra.ModifiedBy = mod_main.getLoggedOnUsername()
            bra.ModifiedOn = DateTime.Now

            'commit to database here
            Dim res As ResponseInfo = B.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Branch", Me.txtbranchID.Text)
                Response.Redirect("company_branches.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.Branch

            'pass the new values here
            bra.BranchID2 = Me.txtbranchID2.Text
            bra.BranchID = Me.txtbranchID.Text
            bra.RegionID = Me.ddlRegions.SelectedItem.Value
            bra.StateID = Me.ddlState.SelectedItem.Value
            bra.Description = Me.txtbranchName.Text
            bra.Manager = Me.txtManager.Text
            bra.Address = Me.txtAddress.Text
            bra.MobilePhone = Me.txtPhone1.Text
            bra.LandPhone = Me.txtPhone2.Text
            bra.Email = Me.txtEmail.Text
            bra.Fax = Me.txtFaxNo.Text
            bra.Remarks = Me.txtRemarks.Text

            bra.SubmittedBy = mod_main.getLoggedOnUsername()
            bra.SubmittedOn = DateTime.Now

            'comit to database here
            Dim res As ResponseInfo = B.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Branch", Me.txtbranchID.Text)
                Response.Redirect("company_branches.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("company_branches.aspx")
    End Sub
End Class
