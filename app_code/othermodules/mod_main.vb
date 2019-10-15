Imports System.Net
Imports System.Text
Imports System.Web.Mail
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Module mod_main
    Public settings As GibsStettings

    'Public db As New Hrms3.hrms3dbDataContext
    Public m_strConnString As String = (New Hrms3.hrms3dbDataContext).Connection.ConnectionString
    Public strDenied As String = "/webroot/web/modules/welcome/denied.aspx"


#Region "GLOBAL_VARIABLES"
    Public m_isOnline As Boolean = True
    Public m_isDebug As Boolean = CBool(ConfigurationManager.AppSettings("CNFG-isDebug"))

    Public m_strDebugEmails As String = ConfigurationManager.AppSettings("USER-Debug")
    Public m_strAdminEmails As String = ConfigurationManager.AppSettings("USER-Admin")
    Public m_strSupportEmails As String = ConfigurationManager.AppSettings("USER-Support")

    Public m_pathToTempFiles As String = ConfigurationManager.AppSettings("PATH-TempFiles")
    Public m_pathToMemberData As String = ConfigurationManager.AppSettings("PATH-MemberData")

    Public m_strAnnouncement As String = ConfigurationManager.AppSettings("INFO-Text")
    Public m_strAnnounceLink As String = ConfigurationManager.AppSettings("INFO-Link")
    Public m_strAnnounceType As String = ConfigurationManager.AppSettings("INFO-Type")

    Public m_SMTPHostOrIP As String = ConfigurationManager.AppSettings("SMTP-HostOrIP")
    Public m_SMTPUsername As String = ConfigurationManager.AppSettings("SMTP-Username")
    Public m_SMTPPassword As String = ConfigurationManager.AppSettings("SMTP-Password")
#End Region

    Public Enum BizOptionEnum
        [NEW]
        RENEWAL
        DELETED
        EXPIRED
        REVERSAL
    End Enum

    Public Enum ClassNameEnum
        FullClassName
        ShortClassName
        SafeClassName
    End Enum

    Public Enum ErrCodeEnum
        NO_ERROR = 0
        INVALID_GUID = 401
        INVALID_PASSWORD = 402
        FORBIDDEN = 407
        INVALID_RANGE = 408
        ACCOUNT_LOCKED = 410
        ACCOUNT_EXPIRED = 410
        GENERIC_ERROR = 100
    End Enum

    Public Class UserInfo_SMTP
        Public SMTPServer As String
        Public SMTPEmail As String
        Public SMTPPaswd As String
        Public SMTPFName As String
    End Class

    Public Class ResponseInfo
        Public ErrorCode As Integer
        Public ErrorMessage As String
        Public ExtraMessage As String
        Public TotalSuccess As Integer
        Public TotalFailure As Integer
        Public TotalCharged As Integer
        Public CurrentBalance As Integer
    End Class

    Public Structure GibsStettings

        Dim COMPANY_DOC_PATH As String
        Dim COMPANY_NAME As String
        Dim COMPANY_ADDRESS As String
        Dim COMPANY_ABREV As String
        Dim COMPANY_WEBSITE As String

        Dim SHOW_MARKETING_MODULE As Boolean
        Dim PASSWORD_MIN_LEN As Integer
        Dim INITIAL_PWD_DAYS As Integer
        Dim CHANGE_PWD_DAYS As Integer
        Dim LOCK_USER_ACCES_DAYS As Integer

        Dim DEFAULT_RESET_PWD As String
        Dim CURRENT_ACCT_PERIOD As String

        Dim PATH_TO_POLICY_DOCS_PHYSICAL As String
        Dim PATH_TO_POLICY_DOCS_VIRTUAL As String
        Dim PATH_TO_POLICY_TEMPLATES_PHYSICAL As String
        Dim PATH_TO_POLICY_TEMPLATES_VIRTUAL As String
        Dim PATH_TO_REPORTS_PHYSICAL As String
        Dim PATH_TO_REPORTS_VIRTUAL As String
        Dim PATH_TO_GIBS_HOME_PAGE As String

        Dim SMS_ACCOUNT As String
        Dim SMS_PASSWORD As String

        Dim PROXY_HOSTNAME As String
        Dim PROXY_PORT As Integer
        Dim PROXY_USERNAME As String
        Dim PROXY_PASSWORD As String

        Dim USE_EXCHANGE_MAIL As Boolean
        Dim SMTP_SERVER_OR_EXG_DOMAIN As String
        Dim SMTP_EMAIL_OR_EXG_USERNAME As String
        Dim SMTP_PASWD_OR_EXG_PASSWORD As String
        Dim SMTP_FRIENDLY_NAME_OR_EXG_BOX As String

        Dim CLOSE_ACCT_PERMT As String
        Dim LOCK_ACCT_SUPPRESS As String
        Dim AUTO_MAIL_DATE As String




    End Structure

    Public Sub LoadAllSettings()
        Dim S As New cls_Settings
        With settings
            .COMPANY_ABREV = S.SelectThis("COMPANY_ABREV", "default").Value
            .COMPANY_ADDRESS = S.SelectThis("COMPANY_ADDRESS", "Put your address here").Value
            .COMPANY_NAME = S.SelectThis("COMPANY_NAME", "Default Company").Value
            .COMPANY_WEBSITE = S.SelectThis("COMPANY_WEBSITE", "www.inttecktechnologies.com").Value
            .PASSWORD_MIN_LEN = S.SelectThis("PASSWORD_MIN_LEN", 6).Value
            .SHOW_MARKETING_MODULE = CBool(S.SelectThis("SHOW_MARKETING_MODULE", True).Value)
            .DEFAULT_RESET_PWD = S.SelectThis("DEFAULT_RESET_PWD", "gibs321.").Value
            .INITIAL_PWD_DAYS = S.SelectThis("INITIAL_PWD_DAYS", 6).Value
            .CHANGE_PWD_DAYS = S.SelectThis("CHANGE_PWD_DAYS", 24).Value
            .LOCK_USER_ACCES_DAYS = S.SelectThis("LOCK_USER_ACCES_DAYS", 50).Value
            .CURRENT_ACCT_PERIOD = S.SelectThis("CURRENT_ACCT_PERIOD", 25 / 3 / 2009).Value
            .PATH_TO_GIBS_HOME_PAGE = "/datafiles/" & .COMPANY_ABREV & "/welcome/default.aspx"

            .PATH_TO_POLICY_DOCS_PHYSICAL = HttpRuntime.AppDomainAppPath & "datafiles\" & .COMPANY_ABREV & "\docs\policies\"
            .PATH_TO_POLICY_DOCS_VIRTUAL = "/datafiles/" & .COMPANY_ABREV & "/docs/policies/"

            .PATH_TO_POLICY_TEMPLATES_PHYSICAL = HttpRuntime.AppDomainAppPath & "datafiles\" & .COMPANY_ABREV & "\docs\policies\templates\"
            .PATH_TO_POLICY_TEMPLATES_VIRTUAL = "/datafiles/" & .COMPANY_ABREV & "/docs/policies/templates/"

            .PATH_TO_REPORTS_PHYSICAL = HttpRuntime.AppDomainAppPath & "datafiles\" & .COMPANY_ABREV & "\reports\"
            .PATH_TO_REPORTS_VIRTUAL = "/datafiles/" & .COMPANY_ABREV & "/reports/"
            .USE_EXCHANGE_MAIL = CBool(S.SelectThis("USE_EXCHANGE_MAIL", True).Value)
            .SMS_ACCOUNT = S.SelectThis("SMS_ACCOUNT", "OCEANIC").Value
            .SMS_PASSWORD = S.SelectThis("SMS_PASSWORD", "oceanic123").Value
            .SMTP_SERVER_OR_EXG_DOMAIN = S.SelectThis("SMTP_SERVER", "smtp.gmail.com[secure]:587").Value
            .SMTP_EMAIL_OR_EXG_USERNAME = S.SelectThis("SMTP_EMAIL", "oseniwasiu@gmail.com").Value
            .SMTP_PASWD_OR_EXG_PASSWORD = S.SelectThis("SMTP_PASWD", "olayinka321").Value
            .SMTP_FRIENDLY_NAME_OR_EXG_BOX = S.SelectThis("SMTP_SENDER_NAME", "").Value
            .CLOSE_ACCT_PERMT = S.SelectThis("CLOSE_ACCT_PERMT", "NO").Value
            .LOCK_ACCT_SUPPRESS = S.SelectThis("LOCK_ACCT_SUPPRESS", "NO").Value
            .AUTO_MAIL_DATE = S.SelectThis("AUTO_MAIL_DATE", "1 jan 2009").Value

        End With
    End Sub
#Region "USEFUL GET FUNCTIONS"

    Public Function getQueryString(Optional ByVal q As NameValueCollection = Nothing, Optional ByVal SkipParam As String = "") As String
        If q Is Nothing Then q = My.Request.QueryString
        Dim query As String = "", skips() As String = Split(SkipParam, ",")
        For p As Integer = 0 To q.Count - 1
            If Not skips.Contains(q.GetKey(p)) Then
                query &= "&" & q.GetKey(p) & "=" & String.Join("", q.GetValues(p))
            End If
        Next
        If query.StartsWith("&") Then query = query.Remove(0, 1)
        Return query
    End Function

    Public Function getAdhocTable(ByVal strSQL As String, ByVal con As Data.Common.DbConnection) As Data.DataTable
        Dim cmd As New SqlCommand(strSQL, con)
        With cmd
            .CommandType = CommandType.Text

            Dim rdr As New SqlDataAdapter(cmd)
            Dim tbl As New DataTable("Table1")
            rdr.Fill(tbl) : Return tbl
        End With
    End Function

    Public Function getClassName(ByVal NameType As ClassNameEnum) As String
        Select Case NameType
            Case ClassNameEnum.FullClassName
                Select Case My.Request.QueryString("class")
                    Case "V"
                        Return "Motor"
                    Case "F"
                        Return "Fire"
                    Case "E"
                        Return "Engineering"
                    Case "G"
                        Return "Gen Accident"
                    Case "M"
                        Return "Marine"
                    Case "H"
                        Return "Aviation"
                    Case "O"
                        Return "Oil & Gas"
                    Case "MH"
                        Return "Marine Hull"
                    Case "S"
                        Return "Special Risk"
                    Case "B"
                        Return "Bond"
                    Case Else
                        Return "All"
                End Select
            Case ClassNameEnum.ShortClassName
                Select Case My.Request.QueryString("class")
                    Case "V"
                        Return "Motor"
                    Case "F"
                        Return "Fire"
                    Case "E"
                        Return "Engineering"
                    Case "G"
                        Return "Gen Accident"
                    Case "M"
                        Return "Marine"
                    Case "H"
                        Return "Aviation"
                    Case "O"
                        Return "Oil & Gas"
                    Case "MH"
                        Return "Marine Hull"
                    Case "S"
                        Return "Special Risk"
                    Case "B"
                        Return "Bond"
                    Case Else
                        Return "All"
                End Select
            Case Else 'ClassNameEnum.SafeClassName
                Select Case My.Request.QueryString("class")
                    Case "V"
                        Return "motor"
                    Case "F"
                        Return "fire"
                    Case "E"
                        Return "ega"
                    Case "G"
                        Return "ega"
                    Case "M"
                        Return "marine"
                    Case "H"
                        Return "hull"
                    Case "O"
                        Return "oilg"
                    Case "MH"
                        Return "mhull"
                    Case "S"
                        Return "special"
                    Case "B"
                        Return "bond"
                    Case Else
                        Return "All"
                End Select
        End Select
    End Function

    Public Sub SendEmailInThreadWithPdf(ByVal rptFile As String, ByVal ParamString As String, Optional ByVal mTo As String = Nothing, _
      Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
      Optional ByVal mIsHtml As Boolean = False, Optional ByVal mBody As String = Nothing)

        Dim tws As New SendMailThread(mTo, mSubject, mBody, mIsHtml, mCC, mBCC, rptFile, ParamString)
        Dim t As New Threading.Thread(AddressOf tws.SendMail)
        t.Start()
    End Sub

    Public Function SendEmailWithPdf(ByVal rptFile As String, ByVal ParamString As String, Optional ByVal mTo As String = Nothing, _
       Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
       Optional ByVal mIsHtml As Boolean = False, Optional ByVal mBody As String = Nothing) As String

        Dim tws As New SendMailThread(mTo, mSubject, mBody, mIsHtml, mCC, mBCC, rptFile, ParamString)
        Return tws.SendMail()
    End Function

    Public Function SendEmail(Optional ByVal mTo As String = Nothing, _
       Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
       Optional ByVal mIsHtml As Boolean = False, Optional ByVal mBody As String = Nothing) As String

        Dim tws As New SendMailThread(mTo, mSubject, mBody, mIsHtml, mCC, mBCC)
        Return tws.SendMail()
    End Function

    Public Sub SendEmailInThread(Optional ByVal mTo As String = Nothing, _
       Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
       Optional ByVal mIsHtml As Boolean = False, Optional ByVal mBody As String = Nothing)

        Dim tws As New SendMailThread(mTo, mSubject, mBody, mIsHtml, mCC, mBCC)
        Dim t As New Threading.Thread(AddressOf tws.SendMail)
        t.Start()
    End Sub

    Public Function getTempPath() As String
        'move this function to Global.asax-AppOnStart latter
        Dim Temp As String = m_pathToTempFiles
        Temp = Path.GetFullPath(HttpRuntime.AppDomainAppPath & Temp)
        If Not Directory.Exists(Temp) Then Directory.CreateDirectory(Temp)
        Return Temp
    End Function

    Public Function getLoggedOnUserObj() As Hrms3.User
        Try
            Return (New cls_Users).SelectThis(getLoggedOnUserID)
        Catch ex As Exception
            Return New Hrms3.User
        End Try
    End Function

    Public Function getLoggedOnUserID() As String
        Try
            Return DecodeFromBase64String(My.Request.Cookies("user_id").Value).ToLower
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Sub CheckCurrUserPermission(ByVal PermissionID As PermissionEnum)
        Try
            If (New cls_Users).hasPermission(getLoggedOnUserObj.UserID, PermissionID) = False Then
                My.Response.Redirect(strDenied)
            End If
        Catch ex As Exception
            My.Response.Redirect(strDenied)
        End Try
    End Sub

    Public Function getLoggedOnUsername(Optional ByVal DefaultAns As String = "") As String
        Try
            Return DecodeFromBase64String(My.Request.Cookies("user_name").Value).ToLower
        Catch ex As Exception
            Return DefaultAns
        End Try
    End Function

    Public Function getLastUser(Optional ByVal DefaultAns As String = "") As String
        Try
            Return DecodeFromBase64String(My.Request.Cookies("last_user").Value).ToLower
        Catch ex As Exception
            Return DefaultAns
        End Try
    End Function

    Public Function getNewTransRef() As String
        '(Today.Year * 10000000000) +
        Return 10000000000 + (Now.Month * 100000000) + (Now.Day * 1000000) + (Now.Hour * 10000) + (Now.Minute * 100) + (Now.Second)
    End Function

    'Public Function getLastMainTab() As String
    '    Try
    '        Select Case My.Request.Url.Query
    '            Case "?cmd=_home", "?cmd=_send-sms", "?cmd=_send-sms", "?cmd=_sms-hosting", "?cmd=_contact-us"
    '                Return My.Request.Url.Query

    '            Case Else
    '                Return DecodeFromBase64String(My.Request.Cookies("last_main_tab").Value)

    '        End Select

    '    Catch ex As Exception
    '        Return "?cmd="
    '    End Try
    'End Function

    Public Function getDbDate(ByVal dbDate As Object, Optional ByVal DefDate As Object = Nothing) As Object
        If IsDate(dbDate) Then
            Return dbDate
        Else
            Return DefDate
        End If
    End Function
    Public Function isFirstCaps(ByVal myString As String) As Boolean
        'get first char of string
        Dim firstChar As String = Left(myString, 1)

        'check if firstChar in string is in A - Z
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ", firstChar, CompareMethod.Binary) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FormatNaira(ByVal Num As String, Optional ByVal Sign As String = "&#8358;&nbsp;", Optional ByVal DecimalPlaces As Integer = 0) As String
        Dim N As String = Sign & " "
        Return (N & FormatNumber(Val(Num), DecimalPlaces, True, False, TriState.True)).Trim
    End Function

    Public Function FormatNum(ByVal Num As Object, Optional ByVal DecimalPlaces As Integer = 0) As String
        Return FormatNumber(Num, DecimalPlaces, True, False, TriState.True)
    End Function

#End Region

#Region "VALIDATION FUNCTIONS"

    Public Function IsValidGUID(ByVal strIn As String) As Boolean
        Try
            Return Regex.IsMatch(strIn, "^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsValidEmail(ByVal strIn As String) As Boolean
        Try
            Return Regex.IsMatch(strIn, "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsValidDomain(ByVal strIn As String) As Boolean
        Try
            Return Regex.IsMatch(strIn, "([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsValidUrl(ByVal strIn As String) As Boolean
        Try
            Return Regex.IsMatch(strIn, "http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsValidIP(ByVal strIn As String) As Boolean
        Try
            Return Regex.IsMatch(strIn, "^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsValidNigerianNo(ByVal MobileNo As String) As Boolean
        Return (MobileNo Like "23480########") Or (MobileNo Like "23470########")
    End Function

    Public Function RegexReplace(ByVal strIn As String, ByVal Pattern As String, ByVal Replacement As String) As String
        Try
            Return Regex.Replace(strIn, Pattern, Replacement)
        Catch ex As Exception
            Return strIn
        End Try
    End Function

#End Region

#Region "CORE SYSTEM FUNCTIONS"

    Public Function _GetResponseStruct(ByVal ErrCode As ErrCodeEnum, Optional ByVal TotalSuccess As Integer = 0, _
     Optional ByVal TotalFailure As Integer = 0, Optional ByVal ErrorMsg As String = "", Optional ByVal ExtraMsg As String = "", Optional ByVal currentBalance As Integer = 0) As ResponseInfo
        Dim res As New ResponseInfo
        With res
            .ErrorCode = ErrCode
            .ErrorMessage = ErrorMsg
            .ExtraMessage = ExtraMsg
            .TotalSuccess = TotalSuccess
            .TotalFailure = TotalFailure
            .CurrentBalance = currentBalance
        End With
        Return res
    End Function

    Public Function SendSystemEmail(Optional ByVal mFrom As String = "SMSLive247 Service", Optional ByVal mTo As String = Nothing, _
     Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
     Optional ByVal mIsBodyHtml As Boolean = False, Optional ByVal mBody As String = Nothing, Optional ByVal SendAsync As Boolean = True) As Boolean

        Dim objSystemSMTP As New UserInfo_SMTP
        With objSystemSMTP
            .SMTPServer = m_SMTPHostOrIP
            .SMTPFName = mFrom
            .SMTPEmail = m_SMTPUsername
            .SMTPPaswd = m_SMTPPassword
        End With

        Dim res As String = SendUserEmail(objSystemSMTP, mTo, mCC, mBCC, mSubject, mIsBodyHtml, mBody, SendAsync)
        Return (Not res.StartsWith("Err:"))

    End Function
    Public Sub Messagebox(ByVal Page As UI.Page, ByVal message As String)
        Page.Response.Cookies.Add(New HttpCookie("msgbox", message))
    End Sub

    Public Function SendUserEmail(ByVal objUserSMTP As UserInfo_SMTP, Optional ByVal mTo As String = Nothing, _
     Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
     Optional ByVal mIsBodyHtml As Boolean = False, Optional ByVal mBody As String = Nothing, Optional ByVal SendAsync As Boolean = True) As String

        If mod_main.m_isOnline Then
            Try
                If objUserSMTP.SMTPEmail <> "" Then 'USE SPECIFIED SMTP SERVER

                    Dim mSMTPServer As String = objUserSMTP.SMTPServer.Split(":")(0).Trim
                    Dim mSMTPPort As Integer = 25, mSecure As Boolean = False

                    If objUserSMTP.SMTPServer.IndexOf(":") > 0 Then
                        mSMTPPort = Val(objUserSMTP.SMTPServer.Split(":")(1).Trim)
                        If mSMTPPort <= 0 Then mSMTPPort = 25
                    End If
                    If objUserSMTP.SMTPServer.Contains("[secure]") Then
                        mSMTPServer = Replace(objUserSMTP.SMTPServer, "[secure]", "")
                        mSecure = True
                    End If

                    Dim mailMessage As New Net.Mail.MailMessage
                    With mailMessage
                        .From = New Net.Mail.MailAddress(objUserSMTP.SMTPEmail, objUserSMTP.SMTPFName)
                        If IsValidEmail(mTo) Then .To.Add(mTo)
                        If IsValidEmail(mCC) Then .CC.Add(mCC)
                        If IsValidEmail(mBCC) Then .Bcc.Add(mBCC)
                        .Subject = mSubject
                        .IsBodyHtml = mIsBodyHtml
                        .Body = mBody
                        Try
                            Dim Client As New Net.Mail.SmtpClient(mSMTPServer, mSMTPPort)
                            Client.Credentials = New Net.NetworkCredential(objUserSMTP.SMTPEmail, objUserSMTP.SMTPPaswd)
                            Client.Timeout = 300000
                            Client.EnableSsl = mSecure
                            Client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                            'If SendAsync Then
                            '    Client.SendAsync(mailMessage, Nothing)
                            'Else
                            Client.Send(mailMessage)
                            'End If
                            Return "OK"

                        Catch ex As Exception
                            Dim res As String = ""

                            If IsNothing(ex.InnerException) Then
                                res = ex.Message()
                            Else
                                res = ex.InnerException.ToString()
                            End If

                            If InStr(res, "COMException (0x80040213)") Then
                                Return "Err: SMTP Server [" & objUserSMTP.SMTPServer & _
                                 "] NOT found!<br>Please specify a valid SMTP Server name or IP Address."

                            ElseIf InStr(res, "COMException (0x80040211)") Then
                                Return "Err: SMTP Server OK. But Invalid [Email/Password] combination."

                            ElseIf InStr(res, "COMException (0x8004020F)") Then
                                Return "Err: Server [" & objUserSMTP.SMTPServer & _
                                 "] IS NOT a SMTP Server!<br>Please specify a valid SMTP Server name or IP Address."

                            Else
                                Return "Err: " & res

                            End If
                        End Try
                    End With
                Else
                    Return "Err: You have to specify a valid SMTP Server hostname or IP Address."
                End If

            Catch ex As Exception
                Return "Err: " & ex.Message
            End Try
        Else
            Return "Err: You are not online. Change the 'Online' variable to 'True'"
        End If

    End Function

    'Public Sub DisplayXLSFile(ByVal objDataSrc As Object, Optional ByVal Formatted As Boolean = True, Optional ByVal FileName As String = "", Optional ByVal strContentType As String = "application/vnd.ms-excel")
    '    Try
    '        Dim tw As New System.IO.StringWriter
    '        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
    '        Dim dg As New System.Web.UI.WebControls.DataGrid

    '        If Formatted Then
    '            dg.AlternatingItemStyle.BackColor = Color.MistyRose
    '            dg.HeaderStyle.BackColor = Color.Navy
    '            dg.HeaderStyle.ForeColor = Color.White
    '        End If

    '        If FileName = "" Then
    '            FileName = "idev_" & Format(Today, "dd_MM_yyyy") & ".xls"
    '        End If

    '        dg.DataSource = objDataSrc
    '        dg.DataBind()
    '        dg.RenderControl(hw)

    '        With My.Response
    '            .Clear()
    '            .AddHeader("Content-Disposition", "attachment;filename=" & FileName)
    '            .AddHeader("Content-Length", tw.ToString.Length)
    '            .ContentType = strContentType
    '            .Charset = ""
    '            .Write(tw.ToString)
    '            .Flush()
    '            .Close()
    '        End With
    '    Catch ex As Exception
    '        '
    '    End Try

    'End Sub

    'Public Sub DisplayXLSFile(ByVal strSELECT As String, Optional ByVal Formatted As Boolean = True, Optional ByVal FileName As String = "", Optional ByVal strContentType As String = "application/vnd.ms-excel")
    '    Dim dbConn As New OleDbConnection(mod_main.m_strConnString)
    '    Dim dbComm As New OleDbCommand(strSELECT, dbConn)
    '    dbComm.CommandType = CommandType.Text

    '    Try
    '        Dim mAdapter As New OleDbDataAdapter
    '        mAdapter.TableMappings.Add("Table", "TempTable")
    '        dbConn.Open()
    '        mAdapter.SelectCommand = dbComm
    '        Dim mDataSet As New DataSet("TempTable")
    '        mAdapter.Fill(mDataSet)

    '        DisplayXLSFile(mDataSet, Formatted, FileName, strContentType)

    '    Catch ex As Exception
    '        '
    '    Finally
    '        dbComm.Dispose()
    '        dbConn.Close()
    '    End Try

    'End Sub

    Public Function GetHTTPResponse(ByVal strHost As String, Optional ByVal Method As String = "POST", Optional ByVal strPost As String = "") As String
        Dim objRequest As Net.WebRequest
        Dim bytPost As Byte() = System.Text.Encoding.UTF8.GetBytes(strPost)

        Try
            If Method = "POST" Then
                objRequest = Net.WebRequest.Create(strHost)
                objRequest.ContentLength = bytPost.Length
                objRequest.Method = Method
                objRequest.ContentType = "application/x-www-form-urlencoded"
                Dim streamRequest As Stream = objRequest.GetRequestStream
                streamRequest.Write(bytPost, 0, bytPost.Length)
            Else
                objRequest = Net.WebRequest.Create(strHost & IIf(strPost = "", "", "?" & strPost))
                objRequest.Method = Method
                objRequest.ContentType = "application/x-www-form-urlencoded"
            End If

            Dim objResponse As Net.WebResponse = objRequest.GetResponse()
            Dim streamResponse As Stream = objResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)

            Dim strResponse As String = streamRead.ReadToEnd()
            streamResponse.Close()
            streamRead.Close()

            Return strResponse

        Catch ex As Exception
            Return "ERR:" & ex.Message
        End Try
    End Function

    Public Function EncodeToBase64String(ByVal inputStr As String) As String
        Try
            Dim binaryData() As Byte = (New System.Text.UnicodeEncoding).GetBytes(inputStr)
            ' Convert the binary input into Base64 UUEncoded output.
            Return System.Convert.ToBase64String(binaryData, 0, binaryData.Length)
        Catch exp As System.ArgumentNullException
            Return "#error#"
        Catch ex As Exception
            Return "#error#"
        End Try
    End Function

    Public Function DecodeFromBase64String(ByVal inputStr As String) As String
        Try
            If Len(inputStr) > 0 And (Len(inputStr) Mod 4) > 0 Then
                inputStr = inputStr & Left("====", (4 - (Len(inputStr) Mod 4)))
            End If
            ' Convert the binary input into Base64 UUEncoded output.
            Dim binaryData() As Byte = System.Convert.FromBase64String(inputStr)
            Return (New System.Text.UnicodeEncoding).GetString(binaryData)
        Catch exp As System.ArgumentNullException
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function EncodeToHash(ByVal inputStr As String, Optional ByVal HashFormat As String = "MD5") As String
        If HashFormat <> "SHA1" Then HashFormat = "MD5"
        Return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(inputStr, HashFormat)
    End Function

    Public Sub CompressFile(ByVal SrcFile As String, ByVal DestFile As String)
        Dim sourceFile As FileStream = File.OpenRead(SrcFile)
        Dim destinationFile As FileStream = File.Create(DestFile)
        Dim buffer(sourceFile.Length) As Byte
        sourceFile.Read(buffer, 0, buffer.Length)
        Using output As New Compression.GZipStream(destinationFile, _
            Compression.CompressionMode.Compress)

            output.Write(buffer, 0, buffer.Length)
        End Using

        ' Close the files.
        sourceFile.Close()
        destinationFile.Close()
    End Sub

#End Region

End Module


