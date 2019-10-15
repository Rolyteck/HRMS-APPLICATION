
Public Class cls_payslips
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal ID As String) As ResponseInfo
        Try
            Dim row As Hrms3.PaySlip = (From B In db.PaySlips Where B.ID = ID).ToList()(0)
            db.PaySlips.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function


    Public Function DeleteByID(ByVal ID As String, ByVal Period As String) As ResponseInfo
        Try
            Dim row As Hrms3.PaySlip = (From B In db.PaySlips Where B.EmployeeID = ID AndAlso B.Period = Period).ToList()(0)
            db.PaySlips.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.PaySlip) As ResponseInfo
        Try
            db.PaySlips.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.PaySlip) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal ID As String) As Hrms3.PaySlip
        Try
            Return (From B In db.PaySlips Where B.ID = ID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PaySlip
        End Try
    End Function


    Public Function SelectThisEmployeeSummaryPayroll(ByVal PaidD As String) As Object
        Try
            Return (From p In db.PaySlips _
Where p.ID = PaidD _
Select _
  p.EmployeeID, _
  FinalGrossPay = (If(CType(p.Basic, Decimal?) Is Nothing, 0, p.Basic) + If(CType(p.Housing, Decimal?) Is Nothing, 0, p.Housing) + If(CType(p.Transport, Decimal?) Is Nothing, 0, p.Transport) + If(CType(p.A1, Decimal?) Is Nothing, 0, p.A1) + If(CType(p.A2, Decimal?) Is Nothing, 0, p.A2) + If(CType(p.A3, Decimal?) Is Nothing, 0, p.A3) + If(CType(p.A4, Decimal?) Is Nothing, 0, p.A4) + If(CType(p.A5, Decimal?) Is Nothing, 0, p.A5) + If(CType(p.A6, Decimal?) Is Nothing, 0, p.A6) + If(CType(p.A7, Decimal?) Is Nothing, 0, p.A7) + If(CType(p.A8, Decimal?) Is Nothing, 0, p.A8) + If(CType(p.A9, Decimal?) Is Nothing, 0, p.A9) + If(CType(p.A10, Decimal?) Is Nothing, 0, p.A10) + If(CType(p.A11, Decimal?) Is Nothing, 0, p.A11) + If(CType(p.A12, Decimal?) Is Nothing, 0, p.A12) + If(CType(p.A13, Decimal?) Is Nothing, 0, p.A13) + If(CType(p.A14, Decimal?) Is Nothing, 0, p.A14) + If(CType(p.A15, Decimal?) Is Nothing, 0, p.A15)), _
  FinalDeductions = (If(CType(p.D1, Decimal?) Is Nothing, 0, p.D1) + If(CType(p.D2, Decimal?) Is Nothing, 0, p.D2) + If(CType(p.D3, Decimal?) Is Nothing, 0, p.D3) + If(CType(p.D4, Decimal?) Is Nothing, 0, p.D4) + If(CType(p.D5, Decimal?) Is Nothing, 0, p.D5) + If(CType(p.D6, Decimal?) Is Nothing, 0, p.D6) + If(CType(p.D7, Decimal?) Is Nothing, 0, p.D7) + If(CType(p.D8, Decimal?) Is Nothing, 0, p.D8) + If(CType(p.D9, Decimal?) Is Nothing, 0, p.D9) + If(CType(p.D10, Decimal?) Is Nothing, 0, p.D10) + If(CType(p.D11, Decimal?) Is Nothing, 0, p.D11) + If(CType(p.D12, Decimal?) Is Nothing, 0, p.D12) + If(CType(p.D13, Decimal?) Is Nothing, 0, p.D13) + If(CType(p.D14, Decimal?) Is Nothing, 0, p.D14) + If(CType(p.D15, Decimal?) Is Nothing, 0, p.D15)), _
  FinalNetPay = ((If(CType(p.Basic, Decimal?) Is Nothing, 0, p.Basic) + If(CType(p.Housing, Decimal?) Is Nothing, 0, p.Housing) + If(CType(p.Transport, Decimal?) Is Nothing, 0, p.Transport) + If(CType(p.A1, Decimal?) Is Nothing, 0, p.A1) + If(CType(p.A2, Decimal?) Is Nothing, 0, p.A2) + If(CType(p.A3, Decimal?) Is Nothing, 0, p.A3) + If(CType(p.A4, Decimal?) Is Nothing, 0, p.A4) + If(CType(p.A5, Decimal?) Is Nothing, 0, p.A5) + If(CType(p.A6, Decimal?) Is Nothing, 0, p.A6) + If(CType(p.A7, Decimal?) Is Nothing, 0, p.A7) + If(CType(p.A8, Decimal?) Is Nothing, 0, p.A8) + If(CType(p.A9, Decimal?) Is Nothing, 0, p.A9) + If(CType(p.A10, Decimal?) Is Nothing, 0, p.A10) + If(CType(p.A11, Decimal?) Is Nothing, 0, p.A11) + If(CType(p.A12, Decimal?) Is Nothing, 0, p.A12) + If(CType(p.A13, Decimal?) Is Nothing, 0, p.A13) + If(CType(p.A14, Decimal?) Is Nothing, 0, p.A14) + If(CType(p.A15, Decimal?) Is Nothing, 0, p.A15)) - (If(CType(p.D1, Decimal?) Is Nothing, 0, p.D1) + If(CType(p.D2, Decimal?) Is Nothing, 0, p.D2) + If(CType(p.D3, Decimal?) Is Nothing, 0, p.D3) + If(CType(p.D4, Decimal?) Is Nothing, 0, p.D4) + If(CType(p.D5, Decimal?) Is Nothing, 0, p.D5) + If(CType(p.D6, Decimal?) Is Nothing, 0, p.D6) + If(CType(p.D7, Decimal?) Is Nothing, 0, p.D7) + If(CType(p.D8, Decimal?) Is Nothing, 0, p.D8) + If(CType(p.D9, Decimal?) Is Nothing, 0, p.D9) + If(CType(p.D10, Decimal?) Is Nothing, 0, p.D10) + If(CType(p.D11, Decimal?) Is Nothing, 0, p.D11) + If(CType(p.D12, Decimal?) Is Nothing, 0, p.D12) + If(CType(p.D13, Decimal?) Is Nothing, 0, p.D13) + If(CType(p.D14, Decimal?) Is Nothing, 0, p.D14) + If(CType(p.D15, Decimal?) Is Nothing, 0, p.D15)))).ToList()(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function SelectThisEmployeeMonthPayroll(ByVal PaidD As String) As Hrms3.PaySlip
        Try
            Return (From P In db.PaySlips Where P.ID = PaidD).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PaySlip
        End Try
    End Function

    Public Function ValidatePayrollPeriod(ByVal Period As String, ByVal SheetID As String) As Hrms3.PaySlip
        Try
            Return (From P In db.PaySlips Where P.Period = Period And P.SheetID = SheetID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PaySlip
        End Try
    End Function


    Public Function SelectThisEmployeePayMonth(ByVal Period As String, ByVal EmployeeID As String) As Hrms3.PaySlip
        Try
            Return (From P In db.PaySlips Where P.Period = Period And P.EmployeeID = EmployeeID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PaySlip
        End Try
    End Function
    Public Function SelectThisCategoryPayMonth(ByVal Period As String, ByVal SheetID As String) As Hrms3.PaySlip
        Try
            Return (From P In db.PaySlips Where P.Period = Period And P.SheetID = SheetID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.PaySlip
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.PaySlip)
        Try
            Return (From P In db.PaySlips Order By P.ID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PaySlip)
        End Try
    End Function

    Public Function SelectAllPayslips(ByVal PayPeriod As String, ByVal SheetID As Long) As List(Of Hrms3.PaySlip)
        Try
            Return (From P In db.PaySlips Where P.Period = PayPeriod And P.SheetID = SheetID Order By P.ID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PaySlip)
        End Try
    End Function

    Public Function SelectAllPaidEmployees(ByVal PayPeriod As String, ByVal SheetID As Long, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.PaySlip)
        'remove this line later
        Try
            Return (From P In db.PaySlips _
                    Where P.Period = PayPeriod And P.SheetID = SheetID Order By P.Surname).Where( _
                        SearchField & ".Contains(@0)", SearchText).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.PaySlip)
        End Try
    End Function



    Public Function SelectAllPaidEmployees2(ByVal SearchField As String, ByVal SearchText As String) As Object
        'remove this line later
        Try
            Return (From P In db.PaySlips, Q In db.HREmployees _
                    Where P.EmployeeID = Q.EmployeeID Select P.GrossPay, P.NetPay, P.SubmittedOn, P.ID, Q.Surname, Q.OtherNames, Q.EmployeeID).Where( _
                         SearchField & ".Contains(@0)", SearchText).ToList()

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function SelectWHere(ByVal SheetID As Long, ByVal SearchField As String, ByVal SearchText As String) As Object
        'remove this line later
        'Try
        Return (From Q In db.HREmployees _
                Where Q.SheetID2 = SheetID _
                Select Q).Where( _
                    SearchField & ".Contains(@0)", SearchText).ToList()

        'Catch ex As Exception
        '    Return Nothing
        'End Try
    End Function

    Public Function SelectThisINDPaySlips(ByVal PayslipsNos() As String) As List(Of Hrms3.PaySlip)
        Try
            Return (From P In db.PaySlips Where PayslipsNos.Contains(P.ID)).ToList()

        Catch ex As Exception
            Return New List(Of Hrms3.PaySlip)
        End Try
    End Function

End Class
