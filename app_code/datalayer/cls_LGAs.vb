
Public Class cls_LGAs
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal StateID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRLGA = (From B In db.HRLGAs Where B.LGAID = StateID).ToList()(0)
            db.HRLGAs.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRLGA) As ResponseInfo
        Try
            db.HRLGAs.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRLGA) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal stateID As String) As Hrms3.HRLGA
        Try
            Return (From B In db.HRLGAs Where B.LGAID = stateID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRLGA
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HRLGA)
        Try
            Return (From P In db.HRLGAs Order By P.LGAName).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRLGA)
        End Try
    End Function




End Class
