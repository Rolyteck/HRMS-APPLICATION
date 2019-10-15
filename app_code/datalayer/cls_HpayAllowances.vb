
Public Class cls_HpayAllowances
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal AllowID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HPayAllowance = (From B In db.HPayAllowances Where B.HID = AllowID).ToList()(0)
            db.HPayAllowances.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HPayAllowance) As ResponseInfo
        Try
            db.HPayAllowances.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Update(ByVal G As Hrms3.HPayAllowance) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal HID As Integer) As Hrms3.HPayAllowance
        Try
            Return (From B In db.HPayAllowances Where B.HID = HID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayAllowance
        End Try
    End Function
    Public Function SelectThisName(ByVal GradeID As String, ByVal AllowName As String) As Hrms3.HPayAllowance
        Try
            Return (From B In db.HPayAllowances Where B.Grade = GradeID And B.AllowName = AllowName).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayAllowance
        End Try
    End Function
    Public Function SelectThisNameStep(ByVal GradeID As String, ByVal AllowName As String, ByVal Steps As String) As Hrms3.HPayAllowance
        Try
            Return (From B In db.HPayAllowances Where B.Grade = GradeID And B.AllowName = AllowName And B.Steps = Steps).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HPayAllowance
        End Try
    End Function
    Public Function SelectThisGrade(ByVal GradeID As Integer) As List(Of Hrms3.HPayAllowance)
        Try
            Return (From B In db.HPayAllowances Where B.GradeID = GradeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HPayAllowance)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.HPayAllowance)
        Try
            Return (From P In db.HPayAllowances Order By P.Grade).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HPayAllowance)
        End Try
    End Function

    'Public Function SelectThisGradeAllowances(ByVal GradeID As String) As List(Of Object)
    '    'remove this line later
    '    Try
    '        Return (From P In db.HPayAllowances, Q In db.AllowanceIDs _
    '                Where P.AllowID = Q.AllowID Select Q, P.Value1).Where( _
    '                "(Grade = @0)", _
    '                GradeID).SingleOrDefault
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

End Class
