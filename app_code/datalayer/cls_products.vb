
Public Class cls_products
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal ProductID As String) As ResponseInfo
        Try
            Dim row As Hrms3.PurProduct = (From B In db.PurProducts Where B.ProductID = ProductID).ToList()(0)
            db.PurProducts.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.PurProduct) As ResponseInfo
        Try
            db.PurProducts.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.PurProduct) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal productID As String) As Hrms3.PurProduct
        Try
            Return (From B In db.PurProducts Where B.ProductID = productID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PurProduct
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.PurProduct)
        Try
            Return (From P In db.PurProducts Order By P.ProductNo).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PurProduct)
        End Try
    End Function



End Class
