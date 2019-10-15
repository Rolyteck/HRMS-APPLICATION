
Partial Class webroot_web_modules_accounts_ledger_cashbooks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim optionType As String = Request.QueryString("option")
            Select Case optionType
                Case "PUR_REQ"
                    Me.toptabs1.GroupName = "purchases_details"
                    Me.lbHeader.Text = "Purchase Requisition " & Request.QueryString("edit-id") & " "
                    Me.cmdNew.Text = "New Requisition"

                Case "PUR_DELIVER"
                    Me.toptabs1.GroupName = "purchases_details"
                    Me.lbHeader.Text = "Purchase Deliveries " & Request.QueryString("edit-id") & " "
                    Me.cmdNew.Text = "New Deliveries"
            End Select
        End If
    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Response.Redirect("purchases.aspx?" & mod_main.getQueryString())
    End Sub

    Protected Sub cmdNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Response.Redirect("purchases_edit.aspx?" & mod_main.getQueryString(, "detail-id"))
    End Sub

    'Protected Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

    '    Dim gridView1 As GridView = Me.gridarea1.GridView
    '    Dim SelectedIDs As New ArrayList

    '    For Each r As GridViewRow In gridView1.Rows
    '        Dim AD As New cls_PolicyDetails
    '        If CType(r.Cells(0).Controls(0), SelectorField.SelectorFieldCheckBox).Checked Then
    '            SelectedIDs.Add(r.Cells(1).Text)
    '        End If
    '    Next
    '    If SelectedIDs.Count = 0 Then
    '        'nothing was selected
    '        Me.Msgbox1.ShowError("Please select an item to Print")
    '    Else
    '        Dim optionType As String = Request.QueryString("option")
    '        Select Case optionType
    '            Case "CASH_RCP"
    '                Dim rptFile As String = settings.PATH_TO_REPORTS_VIRTUAL & "documents/Premiumreceipt.rpt"

    '                Try
    '                    Response.Redirect("/webroot/web/modules/reports/viewer.aspx?rpt=" & rptFile & "&@DNCNNo_1=" & SelectedIDs.Item(0).ToString)
    '                Catch

    '                End Try
    '            Case "CASH_PAY"
    '                Dim rptFile As String = settings.PATH_TO_REPORTS_VIRTUAL & "documents/PaymentVoucher.rpt"

    '                Try
    '                    Response.Redirect("/webroot/web/modules/reports/viewer.aspx?rpt=" & rptFile & "&@DNCNNo_1=" & SelectedIDs.Item(0).ToString)
    '                Catch

    '                End Try

    '        End Select

    '    End If
    'End Sub
End Class
