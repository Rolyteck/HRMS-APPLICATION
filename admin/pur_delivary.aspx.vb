
Partial Class webroot_web_modules_accounts_ledger_cashbooks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim optionType As String = Request.QueryString("option")


            Select Case optionType
                Case "ADJ_INWARD"
                    Me.toptabs1.GroupName = "Delivaries_inward"
                    Me.lbHeader.Text = "Adjustment Inward " & Request.QueryString("edit-id") & " "
                    Me.cmdNew.Text = "New Adjustment"
                Case "ADJ_OUTWARD"
                    Me.toptabs1.GroupName = "Delivaries_Outward"
                    Me.lbHeader.Text = "Adjustment Outward" & Request.QueryString("edit-id") & " "
                    Me.cmdNew.Text = "New Adjustment"
                Case "INWARD"
                    Me.toptabs1.GroupName = "purchases_inward"
                    Me.lbHeader.Text = "Inward Delivary" & Request.QueryString("edit-id") & " "
                    Me.cmdNew.Text = "New Delivary"
                Case "OUTWARD"
                    Me.toptabs1.GroupName = "purchases_outward"
                    Me.lbHeader.Text = "Issue Out" & Request.QueryString("edit-id") & " "
                    Me.cmdNew.Text = "New Issue Out"

            End Select
        End If
    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Response.Redirect("pur_delivary.aspx?" & mod_main.getQueryString())
    End Sub

    Protected Sub cmdNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Response.Redirect("delivary_edit.aspx?" & mod_main.getQueryString(, "detail-id"))
    End Sub

End Class
