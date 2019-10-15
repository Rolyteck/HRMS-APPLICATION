
Partial Class webroot_web_modules_admin_categories_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            mod_combo_fill.FillFamilies(Me.ddlFamilies)
            Dim CategoryID As String = Request.QueryString("edit-id")

            If CategoryID <> "" Then
                Dim Bra As Hrms3.PurCategory = (New cls_Categories).SelectThis(CategoryID)
                mod_ui_helpers.DisableInput(Me.txtcategoryID)


                Me.txtcategoryID.Text = Bra.CategoryID
                Me.ddlFamilies.SelectedValue = Bra.FamilyID
                Me.txtCategoryName.Text = Bra.CategoryName
                Me.txtRemarks.Text = Bra.Remarks
            End If
            'mod_ui_helpers.MakeDropDownJs(Me, Me.ddlRegions)
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim CategoryID As String = Request.QueryString("edit-id")
        Dim B As New cls_Categories
        If CategoryID <> "" Then
            'fetch the old data first

            Dim bra As Hrms3.PurCategory = B.SelectThis(CategoryID)

            'update the necassary fields
            bra.CategoryID = Me.txtcategoryID.Text
            bra.FamilyID = Me.ddlFamilies.SelectedValue
            bra.CategoryName = Me.txtCategoryName.Text
            bra.Remarks = Me.txtRemarks.Text

            bra.ModifiedBy = mod_main.getLoggedOnUsername()
            bra.ModifiedOn = DateTime.Now

            'commit to database here
            Dim res As ResponseInfo = B.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Category", Me.txtcategoryID.Text)
                Response.Redirect("categories.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.PurCategory

            'pass the new values here
            bra.FamilyID = Me.ddlFamilies.SelectedValue
            bra.CategoryName = Me.txtCategoryName.Text
            bra.Remarks = Me.txtRemarks.Text
            bra.Remarks = Me.txtRemarks.Text

            bra.Submitby = mod_main.getLoggedOnUsername()
            bra.SubmitOn = DateTime.Now

            'comit to database here
            Dim res As ResponseInfo = B.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Category", Me.txtcategoryID.Text)
                Response.Redirect("categories.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("categories.aspx")
    End Sub
End Class
