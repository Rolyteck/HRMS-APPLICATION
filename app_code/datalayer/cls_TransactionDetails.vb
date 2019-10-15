
Public Class cls_transactionDetails
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal DetailsID As String) As ResponseInfo
        Try
            Dim row As Hrms3.TransactionDetail = (From DN In db.TransactionDetails Where DN.DetailsID = DetailsID).ToList()(0)
            db.TransactionDetails.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.TransactionDetail) As ResponseInfo
        Try
            db.TransactionDetails.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.TransactionDetail) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal DetailsID As String) As Hrms3.TransactionDetail
        Try
            Return (From DN In db.TransactionDetails Where DN.DetailsID = DetailsID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.TransactionDetail
        End Try
    End Function


    Public Function SelectWhere(ByVal InvoiceiD As String) As List(Of Hrms3.TransactionDetail)
        Try
            Return (From DN In db.TransactionDetails Where DN.InvoiceID = InvoiceiD).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.TransactionDetail)
        End Try
    End Function

    

    Public Function SelectAll() As List(Of Hrms3.TransactionDetail)
        Try
            Return (From RG In db.TransactionDetails).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.TransactionDetail)
        End Try
    End Function





End Class
