
Public Class cls_StatesofOrigin
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal StateID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRState = (From B In db.HRStates Where B.StateID = StateID).ToList()(0)
            db.HRStates.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRState) As ResponseInfo
        Try
            db.HRStates.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRState) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal stateID As String) As Hrms3.HRState
        Try
            Return (From B In db.HRStates Where B.StateID = stateID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRState
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HRState)
        Try
            Return (From P In db.HRStates Order By P.StateName).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRState)
        End Try
    End Function




End Class
