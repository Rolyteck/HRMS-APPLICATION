
Partial Class webroot_web_controls_navlogin
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Path.Contains("/datafiles/welcome/default.aspx") Then
            Me.Visible = True
        End If

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.Click

        Dim res As ResponseInfo = (New cls_Users).Login(Me.txtUsername.Text, Me.txtPassword.Text)

        If res.ErrorCode = 0 Then 'ok
            Response.Cookies("user_id").Value = EncodeToBase64String(res.ExtraMessage)
            Response.Cookies("user_id").Expires = Now.AddMinutes(30)

            Response.Cookies("user_name").Value = EncodeToBase64String(Me.txtUsername.Text)
            Response.Cookies("user_name").Expires = Now.AddMinutes(30)

            Response.Cookies("last_user").Value = EncodeToBase64String(Me.txtUsername.Text)
            Response.Cookies("last_user").Expires = Now.AddYears(1)

            If Request.Params("goto") <> "" Then
                Response.Redirect(Request.Params("goto"))

            Else
                Response.Redirect("/webroot/web/modules/employees/default.aspx")
            End If
        Else 'error
            Response.Redirect("/webroot/web/modules/welcome/login.aspx?msg=err")
        End If

    End Sub
End Class
