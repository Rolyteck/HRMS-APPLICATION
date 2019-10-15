
Public Class cls_Categories
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal CategoryID As String) As ResponseInfo
        Try
            Dim row As Hrms3.PurCategory = (From B In db.PurCategories Where B.CategoryID = CategoryID).ToList()(0)
            db.PurCategories.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.PurCategory) As ResponseInfo
        Try
            db.PurCategories.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.PurCategory) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal categoryID As String) As Hrms3.PurCategory
        Try
            Return (From B In db.PurCategories Where B.CategoryID = categoryID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PurCategory
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.PurCategory)
        Try
            Return (From P In db.PurCategories Order By P.Description).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PurCategory)
        End Try
    End Function



End Class
