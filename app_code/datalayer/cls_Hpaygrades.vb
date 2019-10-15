
Public Class cls_Hpaygrades
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal ID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HPayGrade = (From B In db.HPayGrades Where B.ID = ID).ToList()(0)
            db.HPayGrades.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HPayGrade) As ResponseInfo
        Try
            db.HPayGrades.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HPayGrade) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal ID As String) As Hrms3.HPayGrade
        Try
            Return (From B In db.HPayGrades Where B.ID = ID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayGrade
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.HPayGrade)
        Try
            Return (From P In db.HPayGrades Order By P.ID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HPayGrade)
        End Try
    End Function
End Class
