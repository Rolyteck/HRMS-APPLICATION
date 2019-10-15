
Public Class cls_Hrexperience
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal ExperienceID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRExperience = (From B In db.HRExperiences Where B.ExperienceID = ExperienceID).ToList()(0)
            db.HRExperiences.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRExperience) As ResponseInfo
        Try
            db.HRExperiences.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.HRExperience) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal ExperienceID As String) As Hrms3.HRExperience
        Try
            Return (From B In db.HRExperiences Where B.ExperienceID = ExperienceID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRExperience
        End Try
    End Function


    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRExperience)
        Try
            Return (From DN In db.HRExperiences Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRExperience)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.HRExperience)
        Try
            Return (From P In db.HRExperiences Order By P.ExperienceID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRExperience)
        End Try
    End Function
End Class
