Partial Class welcome_resetpwd_aspx
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim U As Hrms3.User = (New cls_Users).SelectByUsername(Me.txtUsername.Text)

        If U.Username = "" Then
            Me.Msgbox1.ShowError("Invalid User. This username does not exist in the database!")
        Else
            Dim res As ResponseInfo = (New cls_Users).Reset(Me.txtUsername.Text, settings.DEFAULT_RESET_PWD)
            If res.ErrorCode = 0 Then
                Me.Msgbox1.ShowInfo("A reset password request has been sent to your Administrator. Please call the help desk if this request is very urgent.")
            Else 'email failed
                Me.Msgbox1.ShowError("Error sending your reset password request. " & res.ErrorMessage)
            End If
        End If
    End Sub
End Class


