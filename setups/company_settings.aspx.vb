
Partial Class webroot_web_modules_admin_admin_settings
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.txtAbbr.Text = settings.COMPANY_ABREV
            Me.txtWebSite.Text = settings.COMPANY_WEBSITE
            Me.txtName.Text = settings.COMPANY_NAME
            Me.txtAddress.Text = settings.COMPANY_ADDRESS
            Me.txtpwdLen.Text = settings.PASSWORD_MIN_LEN
            Me.txtResetPwd.Text = settings.DEFAULT_RESET_PWD
            Me.txtInitialPwdDays.Text = settings.INITIAL_PWD_DAYS
            Me.txtchangePwdDays.Text = settings.CHANGE_PWD_DAYS
            Me.txtLockDays.Text = settings.LOCK_USER_ACCES_DAYS
            'Me.txtLockAcctPeriod.Text = settings.CLOSE_ACCT_PERMT
            'Me.txtLockLedgerSuppress.Text = settings.LOCK_ACCT_SUPPRESS

            'Me.txtEmailSenderOrExgBox.Text = settings.SMTP_FRIENDLY_NAME_OR_EXG_BOX
            'Me.txtEmailUsername.Text = settings.SMTP_EMAIL_OR_EXG_USERNAME
            'Me.txtEmailPassword.Text = settings.SMTP_PASWD_OR_EXG_PASSWORD
            'Me.txtEmailServerOrDoamin.Text = settings.SMTP_SERVER_OR_EXG_DOMAIN
            'Me.txtsmsAcct.Text = settings.SMS_ACCOUNT
            'Me.txtSMSPassword.Text = settings.SMS_PASSWORD

            'If settings.USE_EXCHANGE_MAIL Then
            '    Me.rblMailType.SelectedIndex = 1
            'Else
            '    Me.rblMailType.SelectedIndex = 0
            'End If
            'Call rblMailType_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim S As New cls_Settings

        With settings
            S.SelectThis("COMPANY_ABREV", "").Value = Me.txtAbbr.Text
            S.SelectThis("COMPANY_ADDRESS", "").Value = Me.txtAddress.Text
            S.SelectThis("COMPANY_NAME", "").Value = Me.txtName.Text
            S.SelectThis("COMPANY_WEBSITE", "").Value = Me.txtWebSite.Text
            S.SelectThis("PASSWORD_MIN_LEN", 0).Value = Me.txtpwdLen.Text
            S.SelectThis("DEFAULT_RESET_PWD", "").Value = Me.txtResetPwd.Text
            S.SelectThis("INITIAL_PWD_DAYS", 0).Value = Me.txtInitialPwdDays.Text
            S.SelectThis("CHANGE_PWD_DAYS", 0).Value = Me.txtchangePwdDays.Text
            S.SelectThis("LOCK_USER_ACCES_DAYS", 0).Value = Me.txtLockDays.Text
            S.SelectThis("CLOSE_ACCT_PERMT", "").Value = Me.txtLockAcctPeriod.Text
            S.SelectThis("SMTP_SENDER_NAME", "").Value = Me.txtEmailSenderOrExgBox.Text

            S.SelectThis("SMTP_EMAIL", "").Value = Me.txtEmailUsername.Text
            S.SelectThis("SMTP_PASWD", "").Value = Me.txtEmailPassword.Text
            S.SelectThis("SMTP_SERVER", "").Value = Me.txtEmailServerOrDoamin.Text
            S.SelectThis("SMTP_SENDER_NAME", "").Value = Me.txtEmailSenderOrExgBox.Text
            S.SelectThis("USE_EXCHANGE_MAIL", "").Value = Me.rblMailType.SelectedIndex
            S.SelectThis("SMS_ACCOUNT", "").Value = Me.txtsmsAcct.Text
            S.SelectThis("SMS_PASSWORD", "").Value = Me.txtSMSPassword.Text
        End With

        S.Save()
        mod_main.LoadAllSettings()
    End Sub

    Protected Sub rblMailType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblMailType.SelectedIndexChanged
        If Me.rblMailType.SelectedIndex = 0 Then
            'smtp
            Me.lbEmailUsername.Text = "SMTP Email:"
            Me.lbPassword.Text = "SMTP Password:"
            Me.lbSender.Text = "Friendly Name:"
            Me.lbServer.Text = "SMTP Server:"
        Else
            'exchange
            Me.lbEmailUsername.Text = "Username:"
            Me.lbPassword.Text = "Password:"
            Me.lbSender.Text = "Email Box:"
            Me.lbServer.Text = "Domain:"
        End If
    End Sub
End Class
