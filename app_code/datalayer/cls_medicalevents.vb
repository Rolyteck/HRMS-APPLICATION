
Public Class cls_medicalevents
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal detailsID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRMedical = (From DN In db.HRMedicals Where DN.MedID = detailsID).ToList()(0)
            db.HRMedicals.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRMedical) As ResponseInfo
        Try

            db.HRMedicals.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRMedical) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal DetailsID As String) As Hrms3.HRMedical
        Try
            Return (From DN In db.HRMedicals Where DN.MedID = DetailsID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRMedical
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRMedical)
        Try
            Return (From DN In db.HRMedicals Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRMedical)
        End Try
    End Function
    Public Function SelectWhere(ByVal Status As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.HRMedical)
        Try
            If SearchText = "" Then
                Select Case Status
                    Case "PENDING"
                        Return (From R In db.HRMedicals _
                                          Where R.Deleted = 0 _
                                           AndAlso R.Approval = 0 _
                                        AndAlso R.MedDate >= Date1 _
                              AndAlso R.MedDate <= Date2 _
                                                                 Order By R.MedDate Descending).Where( _
                                           SearchField & ".Contains(@0)", _
                                            SearchText).ToList()
                    Case "APPROVED"
                        Return (From R In db.HRMedicals _
                             Where R.Deleted = 0 _
                                         AndAlso R.Approval = 1 _
                              AndAlso R.MedDate >= Date1 _
                                 AndAlso R.MedDate <= Date2 _
                                         Order By R.MedDate Descending).Where( _
                                  SearchField & ".Contains(@0)", _
                                   SearchText).ToList()
                End Select

            Else
                Return (From R In db.HRMedicals Where R.Deleted = 0 Select R Order By R.MedDate Descending).Where( _
                        SearchField & ".Contains(@0)", _
                        SearchText).ToList()
            End If
        Catch ex As Exception
            Return New List(Of Hrms3.HRMedical)
        End Try



    End Function
End Class
