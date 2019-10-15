
Public Class cls_medicaldetails
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal detailsID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRMedDetail = (From DN In db.HRMedDetails Where DN.MedDetailsID = detailsID).ToList()(0)
            db.HRMedDetails.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRMedDetail) As ResponseInfo
        Try
            db.HRMedDetails.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRMedDetail) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal DetailsID As String) As Hrms3.HRMedDetail
        Try
            Return (From DN In db.HRMedDetails Where DN.MedDetailsID = DetailsID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRMedDetail
        End Try
    End Function
    Public Function SelectThisByEmployyeeID(ByVal EmployeeID As String) As Hrms3.HRMedDetail
        Try
            Return (From DN In db.HRMedDetails Where DN.EmployeeNo = EmployeeID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRMedDetail
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRMedDetail)
        Try
            Return (From DN In db.HRMedDetails Where DN.EmployeeNo = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRMedDetail)
        End Try
    End Function
    Public Function SelectWhere(ByVal DetailsID As String) As List(Of Hrms3.HRMedDetail)
        Try
            Return (From DN In db.HRMedDetails Where DN.MedDetailsID = DetailsID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRMedDetail)
        End Try

    End Function
End Class
