
Public Class cls_families
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal familyID As String) As ResponseInfo
        Try
            Dim row As Hrms3.PurFamily = (From B In db.PurFamilies Where B.FamilyID = familyID).ToList()(0)
            db.PurFamilies.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.PurFamily) As ResponseInfo
        Try
            db.PurFamilies.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.PurFamily) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal familyID As String) As Hrms3.PurFamily
        Try
            Return (From B In db.PurFamilies Where B.FamilyID = familyID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PurFamily
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.PurFamily)
        Try
            Return (From P In db.PurFamilies Order By P.Description).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PurFamily)
        End Try
    End Function

   

End Class
