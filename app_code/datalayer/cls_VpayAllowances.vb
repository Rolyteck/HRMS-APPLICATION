
Public Class cls_VpayAllowances
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal AllowID As String) As ResponseInfo
        Try
            Dim row As Hrms3.VPayAllowance = (From B In db.VPayAllowances Where B.AllowID = AllowID).ToList()(0)
            db.VPayAllowances.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.VPayAllowance) As ResponseInfo
        Try
            db.VPayAllowances.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.VPayAllowance) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal AllowID As String) As Hrms3.VPayAllowance
        Try
            Return (From B In db.VPayAllowances Where B.AllowID = AllowID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.VPayAllowance
        End Try
    End Function



    Public Function SelectAll() As List(Of Hrms3.VPayAllowance)
        Try
            Return (From P In db.VPayAllowances Order By P.AllowID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.VPayAllowance)
        End Try
    End Function
End Class
