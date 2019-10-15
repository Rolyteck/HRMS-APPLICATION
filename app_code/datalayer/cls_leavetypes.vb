
Public Class cls_leavetypes
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal TypeID As String) As ResponseInfo
        Try
            Dim row As Hrms3.LeaveType = (From B In db.LeaveTypes Where B.TypeID = TypeID).ToList()(0)
            db.LeaveTypes.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.LeaveType) As ResponseInfo
        Try
            db.LeaveTypes.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Update(ByVal G As Hrms3.LeaveType) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function
    Public Function SelectThis(ByVal typeID As String) As Hrms3.LeaveType
        Try
            Return (From B In db.LeaveTypes Where B.TypeID = typeID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LeaveType
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.LeaveType)
        Try
            Return (From P In db.LeaveTypes Order By P.TypeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.LeaveType)
        End Try
    End Function
End Class
