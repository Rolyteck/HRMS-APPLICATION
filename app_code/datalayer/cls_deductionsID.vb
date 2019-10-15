
Public Class cls_DeductionsID
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal DedID As String) As ResponseInfo
        Try
            Dim row As Hrms3.DeductionID = (From B In db.DeductionIDs Where B.DedID = DedID).ToList()(0)
            db.DeductionIDs.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.DeductionID) As ResponseInfo
        Try
            db.DeductionIDs.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.DeductionID) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal DedID As String) As Hrms3.DeductionID
        Try
            Return (From B In db.DeductionIDs Where B.DedID = DedID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.DeductionID
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.DeductionID)
        Try
            Return (From P In db.DeductionIDs Order By P.DedID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.DeductionID)
        End Try
    End Function
End Class
