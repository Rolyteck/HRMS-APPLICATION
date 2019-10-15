
Public Class cls_loans
    Dim db As New Hrms3.hrms3dbDataContext

    Public Enum LoanStatusEnum
        PENDING
        APPROVED
        CONFIRMED
    End Enum

    Public Function Delete(ByVal LoanID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Loan = (From DN In db.Loans Where DN.LoanID = LoanID).ToList()(0)
            db.Loans.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.Loan) As ResponseInfo
        Try
            db.Loans.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.Loan) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function UpdateStatus(ByVal LoanID As String, ByVal newStatus As LoanStatusEnum) As ResponseInfo
        Try
            Dim c As Hrms3.Loan = SelectThis(LoanID)
            c.TransSTATUS = newStatus.ToString

            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal LoaniD As String) As Hrms3.Loan
        Try
            Return (From DN In db.Loans Where DN.LoanID = LoaniD).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Loan
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.Loan)
        Try
            Return (From DN In db.Loans Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Loan)
        End Try
    End Function
    Public Function SelectWhere(ByVal loanID As String) As List(Of Hrms3.Loan)
        Try
            Return (From DN In db.Loans Where DN.LoanID = loanID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Loan)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.Loan)
        Try
            Return (From RG In db.Loans).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Loan)
        End Try
    End Function
End Class
