
Public Class cls_Hrleaves
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal leaveID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRLeave = (From DN In db.HRLeaves Where DN.LeaveID = leaveID).ToList()(0)
            db.HRLeaves.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)


        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRLeave) As ResponseInfo
        Try
            db.HRLeaves.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRLeave) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal LeaveID As String) As Hrms3.HRLeave
        Try
            Return (From DN In db.HRLeaves Where DN.LeaveID = LeaveID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRLeave
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRLeave)
        Try
            Return (From DN In db.HRLeaves Where DN.EmployeeNo = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRLeave)
        End Try
    End Function
    Public Function SelectWhere(ByVal LeaveID As String) As List(Of Hrms3.HRLeave)
        Try
            Return (From DN In db.HRLeaves Where DN.LeaveID = LeaveID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRLeave)
        End Try
    End Function


    Public Function SelectWhereDetails(ByVal Status As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.HRLeave)
        Try
            If SearchText = "" Then
                Select Case Status
                    Case "PENDING"
                        Return (From R In db.HRLeaves _
                                          Where R.Deleted = 0 _
                                           AndAlso R.Approval = 0 _
                                        AndAlso R.LDate >= Date1 _
                              AndAlso R.LDate <= Date2 _
                                                                 Order By R.LDate Descending).Where( _
                                           SearchField & ".Contains(@0)", _
                                            SearchText).ToList()
                    Case "APPROVED"
                        Return (From R In db.HRLeaves _
                             Where R.Deleted = 0 _
                                         AndAlso R.Approval = 1 _
                              AndAlso R.LDate >= Date1 _
                                 AndAlso R.LDate <= Date2 _
                                         Order By R.LDate Descending).Where( _
                                  SearchField & ".Contains(@0)", _
                                   SearchText).ToList()
                End Select

            Else
                Return (From R In db.HRLeaves _
                                Where R.Deleted = 0 _
                            AndAlso R.LDate >= Date1 _
                              AndAlso R.LDate <= Date2 _
Order By R.LDate Descending).Where( _
                        SearchField & ".Contains(@0)", _
                        SearchText).ToList()
            End If
        Catch ex As Exception
            Return New List(Of Hrms3.HRLeave)
        End Try
    End Function
End Class
