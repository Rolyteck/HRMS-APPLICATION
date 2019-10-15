
Public Class cls_HrDisciplines
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal DisciplineID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRDiscipline = (From DN In db.HRDisciplines Where DN.DisciplineID = DisciplineID).ToList()(0)
            db.HRDisciplines.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)


        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRDiscipline) As ResponseInfo
        Try
            db.HRDisciplines.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRDiscipline) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal DisciplineID As String) As Hrms3.HRDiscipline
        Try
            Return (From DN In db.HRDisciplines Where DN.DisciplineID = DisciplineID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRDiscipline
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRDiscipline)
        Try
            Return (From DN In db.HRDisciplines Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRDiscipline)
        End Try
    End Function
    Public Function SelectWhere(ByVal DisciplineID As String) As List(Of Hrms3.HRDiscipline)
        Try
            Return (From DN In db.HRDisciplines Where DN.DisciplineID = DisciplineID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRDiscipline)
        End Try
    End Function
End Class
