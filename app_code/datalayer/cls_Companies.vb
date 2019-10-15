
Public Class cls_Companies
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal CompanyID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Company = (From P In db.Companies Where P.CompanyID = CompanyID).ToList()(0)
            db.Companies.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.Company) As ResponseInfo
        Try
            db.Companies.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.Company) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal CompanyID As String) As Hrms3.Company
        Try
            Return (From P In db.Companies Where P.CompanyID = CompanyID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Company
        End Try
    End Function

    Public Function SelectThisByType(ByVal CompanyTypeID As String) As Hrms3.Company
        Try
            Return (From P In db.Companies Where P.CompanyType = CompanyTypeID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Company
        End Try
    End Function



    Public Function SelectAll() As List(Of Hrms3.Company)
        Try
            Return (From P In db.Companies).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Company)
        End Try
    End Function

End Class
