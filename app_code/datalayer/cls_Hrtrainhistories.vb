
Public Class cls_HrTraininghistories
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal TrainingID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRTrainHistory = (From DN In db.HRTrainHistories Where DN.TrainHisID = TrainingID).ToList()(0)
            db.HRTrainHistories.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRTrainHistory) As ResponseInfo
        Try
            db.HRTrainHistories.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRTrainHistory) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function UpdateStatus(ByVal ClaimNo As String) As ResponseInfo
        Try
            Dim c As Hrms3.HRTrainHistory = SelectThis(ClaimNo)
            c.Approval = 1
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function UpdateStatusSuspended(ByVal ClaimNo As String) As ResponseInfo
        Try
            Dim c As Hrms3.HRTrainHistory = SelectThis(ClaimNo)
            c.Approval = 0
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal TrainID As String) As Hrms3.HRTrainHistory
        Try
            Return (From DN In db.HRTrainHistories Where DN.TrainHisID = TrainID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRTrainHistory
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRTrainHistory)
        Try
            Return (From DN In db.HRTrainHistories Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRTrainHistory)
        End Try
    End Function
    Public Function SelectWhere(ByVal Status As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.HRTrainHistory)
        Try
            If SearchText = "" Then

                Select Case Status
                    Case "PENDING"
                        Return (From R In db.HRTrainHistories _
                                          Where R.Deleted = 0 _
                                           AndAlso R.Approval = 0 _
                                        AndAlso R.DueDate >= Date1 _
                              AndAlso R.DueDate <= Date2 _
                                                                 Order By R.DueDate Descending).Where( _
                                           SearchField & ".Contains(@0)", _
                                            SearchText).ToList()
                    Case "APPROVED"
                        Return (From R In db.HRTrainHistories _
                             Where R.Deleted = 0 _
                                         AndAlso R.Approval = 1 _
                              AndAlso R.DueDate >= Date1 _
                                 AndAlso R.DueDate <= Date2 _
                                         Order By R.DueDate Descending).Where( _
                                  SearchField & ".Contains(@0)", _
                                   SearchText).ToList()
                End Select

            Else
                Return (From R In db.HRTrainHistories Where R.Deleted = 0 Select R Order By R.DueDate Descending).Where( _
                        SearchField & ".Contains(@0)", _
                        SearchText).ToList()
            End If
        Catch ex As Exception
            Return New List(Of Hrms3.HRTrainHistory)
        End Try



    End Function

End Class
