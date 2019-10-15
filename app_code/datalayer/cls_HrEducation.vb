
Public Class cls_HrEducation
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal EducationID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HREducation = (From B In db.HREducations Where B.EducationID = EducationID).ToList()(0)
            db.HREducations.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HREducation) As ResponseInfo
        Try
            db.HREducations.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.HREducation) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal EducationID As String) As Hrms3.HREducation
        Try
            Return (From B In db.HREducations Where B.EducationID = EducationID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HREducation
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HREducation)
        Try
            Return (From DN In db.HREducations Where DN.EmployeeNo = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HREducation)
        End Try
    End Function


    Public Function SelectAll() As List(Of Hrms3.HREducation)
        Try
            Return (From P In db.HREducations Order By P.EducationID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HREducation)
        End Try
    End Function
End Class
