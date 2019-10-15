
Public Class cls_hrtrainneeds
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal TrainID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRTrainingNeed = (From DN In db.HRTrainingNeeds Where DN.TrainNeedID = TrainID).ToList()(0)
            db.HRTrainingNeeds.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRTrainingNeed) As ResponseInfo
        Try
            db.HRTrainingNeeds.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRTrainingNeed) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal TrainID As String) As Hrms3.HRTrainingNeed
        Try
            Return (From DN In db.HRTrainingNeeds Where DN.TrainNeedID = TrainID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRTrainingNeed
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRTrainingNeed)
        Try
            Return (From DN In db.HRTrainingNeeds Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRTrainingNeed)
        End Try
    End Function


    Public Function SelectWhere(ByVal TrainID As String) As List(Of Hrms3.HRTrainingNeed)
        Try
            Return (From DN In db.HRTrainingNeeds Where DN.TrainNeedID = TrainID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRTrainingNeed)
        End Try
    End Function



End Class
