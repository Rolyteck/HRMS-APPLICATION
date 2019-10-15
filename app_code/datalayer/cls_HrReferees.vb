
Public Class cls_HrReferees
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal RefID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRReferee = (From B In db.HRReferees Where B.RefereeID = RefID).ToList()(0)
            db.HRReferees.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRReferee) As ResponseInfo
        Try
            db.HRReferees.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.HRReferee) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal RefID As String) As Hrms3.HRReferee
        Try
            Return (From B In db.HRReferees Where B.RefereeID = RefID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRReferee
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRReferee)
        Try
            Return (From DN In db.HRReferees Where DN.EmployeeNo = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRReferee)
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HRReferee)
        Try
            Return (From P In db.HRReferees Order By P.RefereeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRReferee)
        End Try
    End Function
End Class
