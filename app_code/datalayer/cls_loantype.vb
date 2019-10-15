
Public Class cls_LoanType
    Dim db As New Hrms3.hrms3dbDataContext

    Public Function Delete(ByVal Typeid As String) As ResponseInfo
        Try
            Dim row As Hrms3.LoanType = (From B In db.LoanTypes Where B.TypeID = Typeid).ToList()(0)
            db.LoanTypes.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.LoanType) As ResponseInfo
        Try
            db.LoanTypes.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function
    Public Function Update(ByVal G As Hrms3.LoanType) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal TypeID As String) As Hrms3.LoanType
        Try
            Return (From B In db.LoanTypes Where B.TypeID = TypeID Order By TypeID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.LoanType
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.LoanType)
        Try
            Return (From P In db.LoanTypes Order By P.TypeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.LoanType)
        End Try
    End Function
End Class
