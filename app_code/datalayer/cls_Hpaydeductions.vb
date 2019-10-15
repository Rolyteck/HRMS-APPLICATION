
Public Class cls_HpayDeductions
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal DedID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HPayDeduction = (From B In db.HPayDeductions Where B.HID = DedID).ToList()(0)
            db.HPayDeductions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HPayDeduction) As ResponseInfo
        Try
            db.HPayDeductions.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThisGrade(ByVal GradeID As Integer) As List(Of Hrms3.HPayDeduction)
        Try
            Return (From B In db.HPayDeductions Where B.GradeID = GradeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HPayDeduction)
        End Try
    End Function



    Public Function Update(ByVal G As Hrms3.HPayDeduction) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal HID As String) As Hrms3.HPayDeduction
        Try
            Return (From B In db.HPayDeductions Where B.HID = HID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayDeduction
        End Try
    End Function

    Public Function SelectThisNameSteps(ByVal GradeID As String, ByVal DedName As String, ByVal Steps As String) As Hrms3.HPayDeduction
        Try
            Return (From B In db.HPayDeductions Where B.Grade = GradeID And B.DedName = DedName And B.Steps = Steps).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayDeduction
        End Try
    End Function

    Public Function SelectThisName(ByVal GradeID As String, ByVal DedName As String) As Hrms3.HPayDeduction
        Try
            Return (From B In db.HPayDeductions Where B.Grade = GradeID And B.DedName = DedName).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayDeduction
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.HPayDeduction)
        Try
            Return (From P In db.HPayDeductions Order By P.Grade).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HPayDeduction)
        End Try
    End Function
End Class
