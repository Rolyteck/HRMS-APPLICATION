
Public Class cls_Compensation
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal CaseID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRCompensation = (From B In db.HRCompensations Where B.CaseID = CaseID).ToList()(0)
            db.HRCompensations.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.HRCompensation) As ResponseInfo
        Try
            db.HRCompensations.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRCompensation) As ResponseInfo

        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal CaseID As String) As Hrms3.HRCompensation
        Try
            Return (From B In db.HRCompensations Where B.CaseID = CaseID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRCompensation
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRCompensation)
        Try
            Return (From DN In db.HRCompensations Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRCompensation)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.HRCompensation)
        Try
            Return (From P In db.HRCompensations Order By P.CaseID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRCompensation)
        End Try
    End Function
End Class
