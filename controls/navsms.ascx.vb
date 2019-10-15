
Partial Class webroot_web_controls_navsms
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Path.Contains("/datafiles/welcome/default.aspx") Then
            Me.Visible = True
        End If

    End Sub
End Class
