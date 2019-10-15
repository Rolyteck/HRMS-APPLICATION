Partial Class sidenav
    Inherits System.Web.UI.UserControl

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'If Not Page.IsPostBack Then
        '    If Request.Path.Contains("/welcome/") Then
        '        Me.nav_wcm1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/marketing") Then
        '        Me.nav_mkt1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/underwriting") Then
        '        Me.nav_und1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/claims") Then
        '        Me.nav_clm1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/reinsurance") Then
        '        Me.nav_rein1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/reports") Then
        '        Me.nav_rpt1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/maintenance") Then
        '        Me.nav_main1.Visible = True

        '    ElseIf Request.Path.Contains("/modules/admin") Then
        '        Me.nav_adm1.Visible = True

        '    End If
        'End If
    End Sub
End Class