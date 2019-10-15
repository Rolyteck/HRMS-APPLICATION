
Public Class cls_Settings
    Dim db As New Hrms3.hrms3dbDataContext

    Public Function Insert(ByVal G As Hrms3.Setting) As ResponseInfo
        Try
            db.Settings.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Sub Save()
        db.SubmitChanges()
    End Sub

    Public Function SelectThis(ByVal SettingID As String, ByVal Value As String) As Hrms3.Setting
        Try
            Dim s As List(Of Hrms3.Setting) = (From B In db.Settings Where B.Setting = SettingID).ToList

            If s.Count > 0 Then
                Return s(0)
            Else
                Dim r As New Hrms3.Setting
                r.Setting = SettingID
                r.Value = Value
                Me.Insert(r)
                Return (From B In db.Settings Where B.Setting = SettingID).ToList()(0)
            End If
        Catch ex As Exception
            Dim r As New Hrms3.Setting
            r.ID = 1
            r.Setting = SettingID
            r.Value = Value
            Return r
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.Setting)
        Try
            Return (From P In db.Settings Order By P.Setting).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Setting)
        End Try
    End Function

End Class