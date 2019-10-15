
Partial Class webroot_web_modules_admin_branch_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            mod_combo_fill.fillCategories(Me.ddlcategory)
            Dim productsID As String = Request.QueryString("edit-id")

            If productsID <> "" Then
                Dim Bra As Hrms3.PurProduct = (New cls_products).SelectThis(productsID)
                mod_ui_helpers.DisableInput(Me.txtproductCode)
                Me.txtproductCode.Text = Bra.ProductNo
                Me.ddlcategory.SelectedValue = Bra.CategoryID
                Me.txtProductName.Text = Bra.ProductName
                Me.txtRemarks.Text = Bra.Remarks
                Me.txtUnitPrice.Text = Bra.UnitPrice
                Me.txtQty.Text = Bra.Quantity
                Me.txtReorderQty.Text = Bra.ReorderQty
                Me.txtreorderlevel.Text = Bra.ReorderLevel
                Me.txtRemarks.Text = Bra.Remarks
            End If
            'mod_ui_helpers.MakeDropDownJs(Me, Me.ddlRegions)
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim productID As String = Request.QueryString("edit-id")
        Dim B As New cls_products
        If productID <> "" Then
            'fetch the old data first

            Dim bra As Hrms3.PurProduct = B.SelectThis(productID)

            'update the necassary fields
            bra.ProductID = productID
            bra.CategoryID = Me.ddlcategory.SelectedValue
            bra.ProductNo = Me.txtproductCode.Text
            bra.ProductName = Me.txtProductName.Text
            bra.Quantity = Me.txtQty.Text
            bra.UnitPrice = Me.txtUnitPrice.Text
            bra.ReorderQty = Me.txtReorderQty.Text
            bra.ReorderLevel = Me.txtreorderlevel.Text
            bra.Remarks = Me.txtRemarks.Text
            'commit to database here
            Dim res As ResponseInfo = B.Update(bra)

            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Products", Me.txtproductCode.Text)
                Response.Redirect("Products.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update Region", res.ErrorMessage, True)
            End If
        Else
            'create a new instance
            Dim bra As New Hrms3.PurProduct
            bra.CategoryID = Me.ddlcategory.SelectedValue
            bra.ProductNo = Me.txtproductCode.Text
            bra.ProductName = Me.txtProductName.Text
            bra.Quantity = Me.txtQty.Text.ToString
            bra.UnitPrice = Me.txtUnitPrice.Text.ToString
            bra.ReorderQty = Me.txtReorderQty.Text.ToString
            bra.ReorderLevel = Me.txtreorderlevel.Text.ToString
            bra.Remarks = Me.txtRemarks.Text
            'comit to database here
            Dim res As ResponseInfo = B.Insert(bra)
            If res.ErrorCode = 0 Then
                mod_ui_helpers.SetNextPageMessage("Products", Me.txtproductCode.Text)
                Response.Redirect("Products.aspx")
            Else
                Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                'LogError(Request.UserHostAddress, "Update branches", res.ErrorMessage, True)
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Products.aspx")
    End Sub
End Class
