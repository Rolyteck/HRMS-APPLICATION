
Public Class cls_Appraisals
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal AppraisalID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Appraisal = (From B In db.Appraisals Where B.AppraisalID = AppraisalID).ToList()(0)
            db.Appraisals.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.Appraisal) As ResponseInfo
        Try
            db.Appraisals.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.Appraisal) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal appraisalID As String) As Hrms3.Appraisal
        Try
            Return (From B In db.Appraisals Where B.AppraisalID = appraisalID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Appraisal
        End Try
    End Function
    Public Function SelectThisName(ByVal GradeID As String, ByVal AppraisalID As String) As Hrms3.Appraisal
        Try
            Return (From B In db.Appraisals Where B.GradeID = GradeID And B.AppraisalID = AppraisalID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Appraisal
        End Try
    End Function

    Public Function SelectThisGrade(ByVal GradeID As String) As List(Of Hrms3.Appraisal)
        Try
            Return (From B In db.Appraisals Where B.GradeID = GradeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Appraisal)
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRAppraisal)
        Try
            Return (From DN In db.HRAppraisals Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRAppraisal)
        End Try
    End Function


    Public Function SelectAll() As List(Of Hrms3.Appraisal)
        Try
            Return (From P In db.Appraisals Order By P.Grade).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Appraisal)
        End Try
    End Function
End Class
