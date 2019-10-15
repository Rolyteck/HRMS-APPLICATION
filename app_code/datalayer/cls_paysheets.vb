
Public Class cls_paysheets
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal sheetID As String) As ResponseInfo
        Try
            Dim row As Hrms3.PaySheet = (From B In db.PaySheets Where B.SheetID = sheetID).ToList()(0)
            db.PaySheets.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.PaySheet) As ResponseInfo
        Try
            db.PaySheets.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.PaySheet) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal sheetID As String) As Hrms3.PaySheet
        Try
            Return (From B In db.PaySheets Where B.SheetID = sheetID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PaySheet
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.PaySheet)
        Try
            Return (From P In db.PaySheets Order By P.SheetID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PaySheet)
        End Try
    End Function
End Class
