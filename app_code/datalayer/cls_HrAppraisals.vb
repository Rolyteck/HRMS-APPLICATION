
Public Class cls_HrAppraisals
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal AppraisalID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRAppraisal = (From DN In db.HRAppraisals Where DN.AppraisalID = AppraisalID).ToList()(0)
            db.HRAppraisals.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)


        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRAppraisal) As ResponseInfo
        Try
            db.HRAppraisals.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRAppraisal) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal AppraisalID As String) As Hrms3.HRAppraisal
        Try
            Return (From DN In db.HRAppraisals Where DN.AppraisalID = AppraisalID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRAppraisal
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRAppraisal)
        Try
            Return (From DN In db.HRAppraisals Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRAppraisal)
        End Try
    End Function
    Public Function SelectWhere(ByVal AppraisalID As String) As List(Of Hrms3.HRAppraisal)
        Try
            Return (From DN In db.HRAppraisals Where DN.AppraisalID = AppraisalID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRAppraisal)
        End Try
    End Function
End Class
