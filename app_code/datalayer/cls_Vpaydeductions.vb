
Public Class cls_VpayDeductions
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal DedID As String) As ResponseInfo
        Try
            Dim row As Hrms3.VPayDeduction = (From B In db.VPayDeductions Where B.DedID = DedID).ToList()(0)
            db.VPayDeductions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.VPayDeduction) As ResponseInfo
        Try
            db.VPayDeductions.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.VPayDeduction) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal DedID As String) As Hrms3.VPayDeduction
        Try
            Return (From B In db.VPayDeductions Where B.DedID = DedID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.VPayDeduction
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.VPayDeduction)
        Try
            Return (From P In db.VPayDeductions Order By P.DedID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.VPayDeduction)
        End Try
    End Function
End Class
