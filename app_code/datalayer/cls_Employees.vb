
Public Class cls_employees
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal EmployeeID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HREmployee = (From DN In db.HREmployees Where DN.EmployeeID = EmployeeID).ToList()(0)
            db.HREmployees.DeleteOnSubmit(row)
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

    Public Function Update(ByVal G As Hrms3.HREmployee) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal EmployeeID As String) As Hrms3.HREmployee
        Try
            Return (From DN In db.HREmployees Where DN.EmployeeID = EmployeeID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HREmployee
        End Try
    End Function


    Public Function SelectWhere(ByVal EmployeeID As String) As List(Of Hrms3.HREmployee)
        Try
            Return (From DN In db.HREmployees Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HREmployee)
        End Try
    End Function

    Public Function SelectWhereoption(ByVal EmployeeID As String) As List(Of Hrms3.HREmployee)
        Try
            Return (From DN In db.HREmployees Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HREmployee)
        End Try
    End Function
    Public Function SelectWhere(ByVal Date1 As Date, ByVal Date2 As Date) As List(Of Hrms3.HREmployee)
        Try
            Return (From DN In db.HREmployees _
            Where DN.HireDate >= Date1.AddSeconds(1) _
            AndAlso DN.HireDate <= Date2.AddDays(1).AddSeconds(-1) _
            ).ToList()

        Catch ex As Exception
            Return New List(Of Hrms3.HREmployee)
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HREmployee)
        Try
            Return (From RG In db.HREmployees).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HREmployee)
        End Try
    End Function
    Public Function SelectWHereActive(ByVal SheetID As Long, ByVal SearchField As String, ByVal SearchText As String) As Object
        Return (From Q In db.HREmployees _
                Where Q.SheetID2 = SheetID _
                AndAlso Q.Tag = "ACTIVE" _
                Select Q).Where( _
                    SearchField & ".Contains(@0)", SearchText).ToList()
    End Function
    Public Function SelectAllEmployees(ByVal SheetID As Long, ByVal SearchField As String, ByVal SearchText As String) As Object

        If SheetID = 0 Then
            Return (From Q In db.HREmployees Select Q).Where( _
                        SearchField & ".Contains(@0)", SearchText).ToList()
        Else
            Return (From Q In db.HREmployees Where Q.SheetID2 = SheetID Select Q).Where( _
                       SearchField & ".Contains(@0)", SearchText).ToList()
        End If
    End Function

    

    'Public Function SelectAllEmployeesActive(ByVal SheetID As Long, ByVal SearchField As String, ByVal SearchText As String) As Object
    '    Return (From Q In db.HREmployees _
    '            Where Q.SheetID2 = SheetID _
    '            AndAlso Q.Tag = "ACTIVE" _
    '            Select Q).Where( _
    '                SearchField & ".Contains(@0)", SearchText).ToList()
    'End Function
End Class
