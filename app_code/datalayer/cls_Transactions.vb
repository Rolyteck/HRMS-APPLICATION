
Public Class cls_transactions
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal transactionID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Transaction = (From DN In db.Transactions Where DN.TransactionID = transactionID).ToList()(0)
            db.Transactions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HREmployee) As ResponseInfo
        Try
            db.HREmployees.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.Transaction) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal transactionID As String) As Hrms3.Transaction
        Try
            Return (From DN In db.Transactions Where DN.TransactionID = transactionID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Transaction
        End Try
    End Function


    Public Function SelectWhere(ByVal transactionID As String) As List(Of Hrms3.Transaction)
        Try
            Return (From DN In db.Transactions Where DN.TransactionID = transactionID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Transaction)
        End Try
    End Function

    Public Function SelectAllWhere(ByVal Date1 As Date, ByVal Date2 As Date, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.Transaction)
        Try
            Return (From DN In db.Transactions _
            Where DN.TDate >= Date1.AddSeconds(1) _
            AndAlso DN.TDate <= Date2.AddDays(1).AddSeconds(-1) _
            ).Where(SearchField & ".Contains(@0) ", SearchText).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Transaction)
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.Transaction)
        Try
            Return (From RG In db.Transactions).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Transaction)
        End Try
    End Function





End Class
