Partial Class welcome_login_aspx
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Try
            If Not Page.IsPostBack Then
                Response.Cookies("user_name").Value = ""
                Me.CheckBox1.Checked = Val(Request.Cookies("remember_me").Value)
                If Me.CheckBox1.Checked Then Me.txtUsername.Text = getLastUser()
                If Request.Params("msg") = "err" Then
                    Me.Msgbox1.ShowError("Your login in information is not valid. Please try again.")
                ElseIf Request.Params("msg") = "logoff1" Then 'redirection needed
                    Response.Redirect("login.aspx?msg=logoff2")
                ElseIf Request.Params("msg") = "logoff2" Then
                    Me.Msgbox1.ShowInfo("You have logged off successfully. Please login here.")
                ElseIf Request.Params("msg") = "admin" Then
                    Me.Msgbox1.ShowInfo("You need to login as ADMIN to access the requested page. Please login here.")
                ElseIf Request.Params("goto") <> "" Then
                    Me.Msgbox1.ShowInfo("You need to login to access the requested page. Please login here.")
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim res As ResponseInfo = (New cls_Users).Login(Me.txtUsername.Text, Me.txtPassword.Text)
        If res.ErrorCode = 0 Then 'ok
            Response.Cookies("user_id").Value = EncodeToBase64String(res.ExtraMessage)
            Response.Cookies("user_id").Expires = Now.AddMinutes(30)
            Response.Cookies("user_name").Value = EncodeToBase64String(Me.txtUsername.Text)
            Response.Cookies("user_name").Expires = Now.AddMinutes(30)
            Response.Cookies("last_user").Value = EncodeToBase64String(Me.txtUsername.Text)
            Response.Cookies("last_user").Expires = Now.AddYears(1)
            Response.Cookies("remember_me").Value = Val(Me.CheckBox1.Checked)
            Response.Cookies("remember_me").Expires = Now.AddYears(1)
            If Request.Params("goto") <> "" Then

                Response.Redirect(Request.Params("goto"))
            Else
                Response.Redirect("/webroot/web/modules/employees/default.aspx")
            End If
        Else 'error
            Me.Msgbox1.ShowError(res.ErrorMessage & " " & res.ExtraMessage)
        End If
    End Sub

End Class


