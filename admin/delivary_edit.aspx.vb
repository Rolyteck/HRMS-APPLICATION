

Partial Class webroot_web_modules_accounts_asset_purchases_edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim optionType As String = Request.QueryString("option")
      
            mod_ui_helpers.MakeDatePicker(Me, Me.txtbillingDate, Now)
            Me.txtUnitPrice.Text = 0
            Me.txtPaidAmount.Text = 0
            Me.txtQuantity.Text = 0

            mod_combo_fill.FillBranches(Me.cdbBranch)
            Me.toptabs1.GroupName = " "
            BindDt(Me.Datagrid1, "tableopt1")
            Me.txtQuantity.Attributes.Add("onkeyup", "calcPremium();")
            Dim InvoiceNo As String = Request.QueryString("edit-id")
            If InvoiceNo <> "" Then 'existing
                Dim G = (New cls_Asspurchases).GetAssetDetails(InvoiceNo)
                Me.cdbBranch.SelectedValue = G.LocationID
                'Me.txttotalAmount.Text = FormatNaira(G.Purchase_Amt & vbNullString, "", 2)
                'Me.party1.SelectedValue = G.CategoryID
                Me.txtReceiptNo.Text = G.Invoice_No
                Me.txtBillingDate.Text = g.Purchase_Date
                Me.txtNarration.Text = G.Description

                Call CreateGrid(G.Invoice_No)

                Me.ExpandingImageButton3.Expanded = False
            Else 'new data

            End If



            Select Case optionType
                Case "ADJ_INWARD"
                    Me.toptabs1.GroupName = "Delivaries_inward"
                    Me.lbHeader.Text = "Adjustment Inward " & Request.QueryString("edit-id") & " "

                Case "ADJ_OUTWARD"
                    Me.toptabs1.GroupName = "Delivaries_Outward"
                    Me.lbHeader.Text = "Adjustment Outward" & Request.QueryString("edit-id") & " "

                Case "INWARD"
                    Me.toptabs1.GroupName = "purchases_inward"
                    Me.lbHeader.Text = "Inward Delivary" & Request.QueryString("edit-id") & " "

                Case "OUTWARD"
                    Me.toptabs1.GroupName = "purchases_outward"
                    Me.lbHeader.Text = "Issue Out" & Request.QueryString("edit-id") & " "


            End Select
        End If
    End Sub

    Private Sub CreateGrid(ByVal TransDetailsID As String)
        Dim Recs As List(Of Hrms3.assPurchase) = (New cls_Asspurchases).SelectThisByInvoiceNos(TransDetailsID)
        Dim da As DataTable = getDt("tableopt1")
        ' i need a loop here to list all recordds
        For Each R In Recs
            Dim dr As DataRow = da.NewRow()
            dr(0) = da.Rows.Count + 1
            dr(1) = R.Asset_Code
            dr(2) = R.Asset
            dr(3) = CDbl(R.Quantity & vbNullString).ToString
            dr(4) = CDbl(R.UnitPrice & vbNullString).ToString
            dr(5) = CDbl(R.Purchase_Amt & vbNullString).ToString
            da.Rows.Add(dr)
        Next
        saveDt("tableopt1", da)
        BindDt(Datagrid1, "tableopt1")
    End Sub


    Private Sub saveDt(ByVal tableName As String, ByVal NewDt As DataTable)
        ViewState(tableName) = NewDt
    End Sub

    Private Sub BindDt(ByVal DtGrid As DataGrid, ByVal tableName As String)
        Dim dt As DataTable = getDt(tableName)
        Dim dv As New DataView(dt)
        ViewState(tableName) = dt
        DtGrid.DataSource = dv
        DtGrid.DataBind()
    End Sub
    Private Function getDt(ByVal tableName As String) As DataTable
        If TypeOf ViewState(tableName) Is DataTable Then
            Return CType(ViewState(tableName), DataTable)
        Else
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("SN", GetType(Int32)))
            dt.Columns.Add(New DataColumn("Ass Code", GetType(String)))
            dt.Columns.Add(New DataColumn("Asset Name", GetType(String)))
            dt.Columns.Add(New DataColumn("Unit price", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("Quantity", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("Amount", GetType(Decimal)))

            Return dt
        End If
    End Function

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Dim dt As DataTable = getDt("tableopt1")
        Dim dr As DataRow = dt.NewRow()
        dr(0) = dt.Rows.Count + 1
        dr(1) = Me.product1.SelectedValue
        dr(2) = Me.product1.SelectedText
        dr(3) = CDbl(Me.txtUnitPrice.Text)
        dr(4) = CDbl(Me.txtQuantity.Text)
        dr(5) = CDbl(Me.txtPaidAmount.Text)
        dt.Rows.Add(dr)
        BindDt(Datagrid1, "tableopt1")

        Dim r As DataRow, P As Decimal
        For Each r In dt.Rows
            P += r(5)
        Next
        Me.product1.SelectedValue = ""
        Me.txtUnitPrice.Text = 0
        Me.txtPaidAmount.Text = 0
        Me.txtQuantity.Text = 0
    End Sub
    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If DoInsert() = True Then
            Messagebox(Me, "Data saved successfully for  [" & Me.txtReceiptNo.Text & "]")
            Response.Redirect("purchases.aspx?" & mod_main.getQueryString())
        End If
    End Sub

    Private Function DoInsert() As Boolean
        Dim optionType As String = Request.QueryString("option")
        Dim Desc As String = ""

        Dim dt As DataTable = getDt("tableopt1")
        Dim r As DataRow, Q As Int16 = 1

        Dim Conn As New Data.SqlClient.SqlConnection(m_strConnString)
        Conn.Open()
        Dim Trans As Data.SqlClient.SqlTransaction = Conn.BeginTransaction

        '---------- AUTONUMBER BEGINS HERE --------------------------------------------------
        Dim strAutoNumber As String = (New cls_AutoNumber).getNextAutoNumber("AUTO", _
                                                        cls_AutoNumber.AutoNumEnum.PROPOSAL, _
                                                       Me.cdbBranch.SelectedItem.Value)
        If String.IsNullOrEmpty(strAutoNumber) Then
            Msgbox1.ShowError("AutoNumber settings is invalid. Data was NOT saved.")
            'Trans.Rollback()
        End If
        Me.txtReceiptNo.Text = strAutoNumber
        '---------- AUTONUMBER ENDS HERE ----------------------------------------------------
        Dim D As New cls_Asspurchases

        For Each r In dt.Rows
            r(0) = Q : Q += 1
            Dim assetcodeID As String = Request.QueryString("edit-id")
            If assetcodeID <> "" Then
                'Receipt notes  4 editting/modified
                Dim Rec As Hrms3.assPurchase = D.SelectThis(r(1))
                Rec.Asset_Code = r(1)
                Rec.Asset = r(2)
                Rec.LocationID = Me.cdbBranch.SelectedItem.Value
                Rec.Location = Me.cdbBranch.SelectedItem.Text
                'Rec.CategoryID = Me.party1.SelectedValue
                'Rec.Category = Me.party1.SelectedText
                Rec.Trans_Type = optionType
                Rec.Purchase_Date = CDate(Me.txtBillingDate.Text)
                Rec.Invoice_No = Me.txtReceiptNo.Text
                Rec.UnitPrice = r(3)
                Rec.Quantity = r(4)
                Rec.CumDep = r(5)
                Rec.Purchase_Amt = r(5)
                Rec.NBV = 0
                Rec.BankCode = ""
                Rec.ChequeDetail = "" ' Me.txtchequeNo.Text
                Rec.Optiontype = "" 'Me.cdbPaymentOption.SelectedItem.Value
                Rec.Description = Me.txtNarration.Text
                Rec.ModifiedBy = mod_main.getLoggedOnUsername()
                Rec.ModifiedOn = DateTime.Now
                'comit to database here
                Dim res As ResponseInfo = D.Update(Rec)
                If res.ErrorCode = 0 Then
                Else
                    Trans.Rollback()
                    Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                    'LogError(Request.UserHostAddress, "Update users", res.ErrorMessage, True)
                    Return False
                End If

            Else
                Me.txtTransGUID.Text = System.Guid.NewGuid.ToString

                Dim Rec As New Hrms3.assPurchase
                Rec.Asset_Code = r(1)
                Rec.Asset = r(2)
                Rec.LocationID = Me.cdbBranch.SelectedItem.Value
                Rec.Location = Me.cdbBranch.SelectedItem.Text
                'Rec.CategoryID = Me.party1.SelectedValue
                'Rec.Category = Me.party1.SelectedText
                Rec.Trans_Type = optionType
                Rec.Purchase_Date = CDate(Me.txtBillingDate.Text)
                Rec.Invoice_No = Me.txtReceiptNo.Text
                Rec.UnitPrice = r(3)
                Rec.Quantity = r(4)
                Rec.CumDep = r(5)
                Rec.Purchase_Amt = r(5)
                Rec.NBV = 0
                Rec.BankCode = ""
                Rec.ChequeDetail = "" ' Me.txtchequeNo.Text
                Rec.Optiontype = "" 'Me.cdbPaymentOption.SelectedItem.Value
                Rec.Description = Me.txtNarration.Text

                Rec.TransSTATUS = "PENDING"
                Rec.TransGUID = Me.txtTransGUID.Text
                Rec.Deleted = 0
                Rec.Active = 1
                Rec.SubmittedBy = mod_main.getLoggedOnUsername()
                Rec.SubmittedOn = DateTime.Now

                'comit to database here
                Dim res As ResponseInfo = (New cls_Asspurchases).Insert(Rec)

                If res.ErrorCode = 0 Then

                Else
                    Trans.Rollback()
                    Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
                    'LogError(Request.UserHostAddress, "Update users", res.ErrorMessage, True)
                    Return False
                End If
            End If
        Next

        Trans.Commit()
        'Trans.Close()
        Return True

    End Function

    Private Sub DataGrid1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid1.DeleteCommand
        Dim dt As DataTable = getDt("tableopt1")
        dt.Rows.RemoveAt(e.Item.ItemIndex)
        Dim r As DataRow, P As Decimal, Q As Int16 = 1
        For Each r In dt.Rows
            r(0) = Q : Q += 1
            P += r(5)
        Next
        BindDt(Datagrid1, "tableopt1")

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("purchases.aspx?" & mod_main.getQueryString(, "edit-id,msg"))
    End Sub


End Class
