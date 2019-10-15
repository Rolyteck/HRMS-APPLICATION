
Public Class cls_HrProperties
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal PptyID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRProperty = (From B In db.HRProperties Where B.PptyID = PptyID).ToList()(0)
            db.HRProperties.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.HRProperty) As ResponseInfo
        Try
            db.HRProperties.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRProperty) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function


    Public Function SelectThis(ByVal PptyID As String) As Hrms3.HRProperty
        Try
            Return (From B In db.HRProperties Where B.PptyID = PptyID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRProperty
        End Try
    End Function


    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRProperty)
        Try
            Return (From DN In db.HRProperties Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRProperty)
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HRProperty)
        Try
            Return (From P In db.HRProperties Order By P.PptyID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRProperty)
        End Try
    End Function
End Class
