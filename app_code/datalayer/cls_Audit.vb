
Public Class cls_Audit
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal AuditLogID As String) As ResponseInfo
        Try
            Dim row As Hrms3.AuditLog = (From A In db.AuditLogs Where A.AuditLogID = AuditLogID).ToList()(0)
            db.AuditLogs.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.AuditLog) As ResponseInfo
        Try
            db.AuditLogs.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.AuditLog) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal AuditLogID As String) As Hrms3.AuditLog
        Try
            Return (From A In db.AuditLogs Where A.AuditLogID = AuditLogID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.AuditLog
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.AuditLog)
        Try
            Return (From P In db.AuditLogs).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.AuditLog)
        End Try
    End Function

End Class
