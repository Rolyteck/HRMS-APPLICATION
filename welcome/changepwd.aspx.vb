Partial Class welcome_changepwd_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim Username As String = getLoggedOnUsername()
            If Username <> "" Then 'loged on
                mod_ui_helpers.DisableInput(Me.txtUsername)
                Me.txtUsername.Text = Username
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim U As Hrms3.User = (New cls_Users).SelectByUsername(Me.txtUsername.Text)

        If U.Username = "" Then
            Me.Msgbox1.ShowError("Invalid User. This username does not exist in the database!")
        ElseIf Me.txtNewPassword1.Text.Length < settings.PASSWORD_MIN_LEN Then
            Me.Msgbox1.ShowError("Password length can not be less than " & settings.PASSWORD_MIN_LEN)

        ElseIf isFirstCaps(Trim(Me.txtNewPassword1.Text)) = False Then
            Me.Msgbox1.ShowError("Pls Ensure that the First Letter is Capital.")
            Exit Sub
            'ElseIf Not InStr(Trim(Me.txtNewPassword1.Text), "@") Or Not InStr(Trim(Me.txtNewPassword1.Text), ".") Then
            '    Me.Msgbox1.ShowError("pls Ensure that your password contains @ or full stop.")
            '    Exit Sub
        Else
            Dim res As ResponseInfo = (New cls_Users).ChangePwd(Me.txtUsername.Text, Me.txtPassword.Text, Me.txtNewPassword1.Text)
            If res.ErrorCode = 0 Then
                Me.Msgbox1.ShowInfo("Your password has been changed!")
            Else 'email failed
                Me.Msgbox1.ShowError("Error changing your password. " & res.ErrorMessage)
            End If
        End If
    End Sub
End Class


