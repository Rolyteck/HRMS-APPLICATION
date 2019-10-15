
Public Class cls_hobbies
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal ID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRHobby = (From B In db.HRHobbies Where B.ID = ID).ToList()(0)
            db.HRHobbies.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRHobby) As ResponseInfo
        Try
            db.HRHobbies.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRHobby) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal ID As String) As Hrms3.HRHobby
        Try
            Return (From B In db.HRHobbies Where B.ID = ID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRHobby
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HRHobby)
        Try
            Return (From P In db.HRHobbies Order By P.ID Descending).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRHobby)
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRHobby)
        Try
            Return (From DN In db.HRHobbies Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRHobby)
        End Try
    End Function
    Public Function SelectWhere(ByVal ID As String) As List(Of Hrms3.HRHobby)
        Try
            Return (From DN In db.HRHobbies Where DN.ID = ID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRHobby)
        End Try
    End Function


End Class
