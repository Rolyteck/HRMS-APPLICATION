
Public Class cls_HrQualifications
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal QualificationID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRProfQ = (From B In db.HRProfQs Where B.ProfQualificationID = QualificationID).ToList()(0)
            db.HRProfQs.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRProfQ) As ResponseInfo
        Try
            db.HRProfQs.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.HRProfQ) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal QualificationID As String) As Hrms3.HRProfQ
        Try
            Return (From B In db.HRProfQs Where B.ProfQualificationID = QualificationID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRProfQ
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRProfQ)
        Try
            Return (From DN In db.HRProfQs Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRProfQ)
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HRProfQ)
        Try
            Return (From P In db.HRProfQs Order By P.ProfQualificationID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRProfQ)
        End Try
    End Function
End Class
