
Public Class cls_AllowancesID
    Dim db As New Hrms3.hrms3dbDataContext
 
    Public Function Delete(ByVal AllowID As String) As ResponseInfo
        Try
            Dim row As Hrms3.AllowanceID = (From B In db.AllowanceIDs Where B.AllowID = AllowID).ToList()(0)
            db.AllowanceIDs.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.AllowanceID) As ResponseInfo
        Try
            db.AllowanceIDs.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function
    Public Function Update(ByVal G As Hrms3.AllowanceID) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal AllowID As String) As Hrms3.AllowanceID
        Try
            Return (From B In db.AllowanceIDs Where B.AllowID = AllowID Order By AllowID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.AllowanceID
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.AllowanceID)
        Try
            Return (From P In db.AllowanceIDs Order By P.AllowID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.AllowanceID)
        End Try
    End Function
End Class
