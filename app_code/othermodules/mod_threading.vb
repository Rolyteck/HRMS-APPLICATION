Imports Microsoft.Exchange.WebServices.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'
Public Class SendMailThread
    ' State information used in the task.

    Private rTo As String = Nothing
    Private rCC As String = Nothing
    Private rBCC As String = Nothing
    Private rSubject As String = "subject"
    Private rIsHtml As Boolean = False
    Private rBody As String = Nothing
    Private rParamString As String = Nothing
    Private rReportFullPath As String = Nothing

    ' The constructor obtains the state information.
    Public Sub New(ByVal mTo As String, _
                    ByVal mSubject As String, _
                    ByVal mBody As String, _
                    ByVal mIsHtml As Boolean, _
                    Optional ByVal mCC As String = Nothing, _
                    Optional ByVal mBCC As String = Nothing, _
                    Optional ByVal mReportFullPath As String = Nothing, _
                    Optional ByVal mParamString As String = Nothing)

        rTo = mTo
        rCC = mCC
        rBCC = mBCC
        rSubject = mSubject
        rIsHtml = mIsHtml
        rBody = mBody
        rReportFullPath = mReportFullPath
        rParamString = mParamString
    End Sub

    Private rSenderID As String = Nothing
    Private rDestination As String = Nothing
    Private rMessage As String = Nothing

    Public Sub New(ByVal SenderID As String, _
                   ByVal Destination As String, _
                   ByVal Message As String)

        rSenderID = SenderID
        rDestination = Destination
        rMessage = Message
    End Sub

    ' The thread procedure performs the task, such as formatting 
    ' and printing a document.
    Public Function SendMail() As String
        If rReportFullPath = "" Then
            Return SendUserEmail(rTo, rCC, rBCC, rSubject, rIsHtml, rBody)
        Else
            'Dim ctx As HttpContext = HttpContext.Current
            'Dim AttachmentFilePath As String = settings.PATH_TO_REPORTS_PHYSICAL & Now.ToString("dd_MM_yy_hh_mm_ss") & ".pdf"

            Dim crdoc As ReportDocument = LoadReportWithParams(rReportFullPath, rParamString, "ReportTitle")
            Dim AttachmentStream = crdoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Return SendUserEmail(rTo, rCC, rBCC, rSubject, rIsHtml, rBody, AttachmentStream)
        End If

    End Function

    Private Shared Function LoadReportWithParams(ByVal rptFile As String, ByVal ParamString As String, ByVal ReportTitle As String) As ReportDocument
        Dim oReport As New ReportDocument
        oReport.Load(rptFile, CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)

        Dim dbParams(-1) As DictionaryEntry
        Dim P() As String = Split(ParamString, "&")

        For i As Integer = 0 To P.Length - 1
            If InStr(P(i), "=") Then
                Dim B() As String = Split(P(i), "=")
                ReDim Preserve dbParams(dbParams.Length)
                dbParams(dbParams.Length - 1) = New DictionaryEntry(B(0), DBNull.Value)
                dbParams(dbParams.Length - 1).Value = B(1)
            End If
        Next

        mod_report.setReportParams(oReport, dbParams, ReportTitle)
        Return oReport
    End Function

   Public Shared Function SendUserEmail(Optional ByVal mTo As String = Nothing, _
      Optional ByVal mCC As String = Nothing, Optional ByVal mBCC As String = Nothing, Optional ByVal mSubject As String = "subject", _
      Optional ByVal mIsBodyHtml As Boolean = False, Optional ByVal mBody As String = Nothing, Optional ByVal AttachmentStream As Stream = Nothing) As String

        If mod_main.m_isOnline Then
            Try
                'use SMTP
                Dim mailMessage As New Net.Mail.MailMessage
                With mailMessage
                    '.From = New Net.Mail.MailAddress(settings.SMTP_EMAIL_OR_EXG_USERNAME, settings.SMTP_FRIENDLY_NAME_OR_EXG_BOX)
                    If IsValidEmail(mTo) Then .To.Add(mTo)
                    If IsValidEmail(mCC) Then .CC.Add(mCC)
                    If IsValidEmail(mBCC) Then .Bcc.Add(mBCC)
                    .Subject = mSubject
                    .IsBodyHtml = mIsBodyHtml
                    .Body = mBody
                    If AttachmentStream IsNot Nothing Then
                        Dim att As New Net.Mail.Attachment(AttachmentStream, Now.ToString("dd_MM_yy_hh_mm_ss") & ".pdf")
                        .Attachments.Add(att)
                    End If

                    Dim Client As New Net.Mail.SmtpClient()
                    'Client.Credentials = New Net.NetworkCredential(settings.SMTP_EMAIL_OR_EXG_USERNAME, settings.SMTP_PASWD_OR_EXG_PASSWORD)
                    Client.Send(mailMessage)
                    Return "OK"
                End With


            Catch ex As Exception
                Dim res As String = ""

                If IsNothing(ex.InnerException) Then
                    res = ex.Message()
                Else
                    res = ex.InnerException.ToString()
                End If

                If InStr(res, "COMException (0x80040213)") Then
                    Return "Err: SMTP Server [" & settings.SMTP_SERVER_OR_EXG_DOMAIN & _
                     "] NOT found!<br>Please specify a valid SMTP Server name or IP Address."

                ElseIf InStr(res, "COMException (0x80040211)") Then
                    Return "Err: SMTP Server OK. But Invalid [Email/Password] combination."

                ElseIf InStr(res, "COMException (0x8004020F)") Then
                    Return "Err: Server [" & settings.SMTP_SERVER_OR_EXG_DOMAIN & _
                     "] IS NOT a SMTP Server!<br>Please specify a valid SMTP Server name or IP Address."
                Else
                    Return "Err: " & res

                End If
            End Try
        Else
            Return "Err: You are not online. Change the 'Online' variable to 'True'"
        End If

    End Function

End Class
