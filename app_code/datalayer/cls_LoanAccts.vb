
Public Class cls_loanAccts
    Dim db As New Hrms3.hrms3dbDataContext

    Public Enum LoanStatusEnum
        PENDING
        APPROVED
        CONFIRMED
    End Enum

    Public Function Delete(ByVal LoanacctID As String, ByVal DedID As String) As ResponseInfo
        Try
            Dim row As List(Of Hrms3.LoanAcct) = (From A In db.LoanAccts Where A.EmployeeID = LoanacctID And A.DedID = DedID And A.TransSTATUS = "NEW").ToList()
            For Each V In row
                db.LoanAccts.DeleteOnSubmit(V)
            Next
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.LoanAcct) As ResponseInfo
        Try
            db.LoanAccts.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.LoanAcct) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal LoanAcctID As String) As Hrms3.LoanAcct
        Try
            Return (From DN In db.LoanAccts Where DN.LoanAcctID = LoanAcctID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LoanAcct
        End Try
    End Function

    Public Function SelectThisStaffDedID(ByVal StaffID As String, ByVal MonthID As Integer, ByVal DedID As Integer) As Hrms3.LoanAcct
        Try
            Return (From LD In db.LoanAccts Where LD.EmployeeID = StaffID And LD.A1 = MonthID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LoanAcct
        End Try
    End Function

    Public Function SelectThisStaffVDedID(ByVal StaffID As String, ByVal DedID As Integer) As Hrms3.LoanAcct
        Try
            Return (From LD In db.LoanAccts Where LD.EmployeeID = StaffID And LD.A1 > 0 And LD.DedID = DedID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LoanAcct
        End Try
    End Function
    Public Function SelectThisStaffVDedIDPayMonth(ByVal StaffID As String, ByVal DedID As Integer, ByVal zMonth As String) As Hrms3.LoanAcct
        Try
            Return (From LD In db.LoanAccts Where LD.EmployeeID = StaffID And LD.A1 > 0 And LD.DedID = DedID And LD.Period = zMonth).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LoanAcct
        End Try
    End Function


    Public Function SelectThisPolicyDedID(ByVal PolicyNo As String, ByVal MonthID As Integer) As Hrms3.LoanAcct
        Try
            Return (From LD In db.LoanAccts Where LD.EmployeeID = PolicyNo And LD.A1 = MonthID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LoanAcct
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.LoanAcct)
        Try
            Return (From DN In db.LoanAccts Where DN.EmployeeID = EmployeeID And DN.A1 > 0).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.LoanAcct)
        End Try
    End Function
    Public Function SelectWhereEmployeeLoanDetails(ByVal EmployeeID As String, ByVal DedID As Integer) As List(Of Hrms3.LoanAcct)
        Try
            Return (From DN In db.LoanAccts Where DN.EmployeeID = EmployeeID And DN.DedID = DedID And DN.A1 > 0).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.LoanAcct)
        End Try
    End Function
    Public Function SelectWhere(ByVal loanID As String) As List(Of Hrms3.LoanAcct)
        Try
            Return (From DN In db.LoanAccts Where DN.LoanAcctID = loanID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.LoanAcct)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.LoanAcct)
        Try
            Return (From RG In db.LoanAccts).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.LoanAcct)
        End Try
    End Function
End Class
