
Public Class cls_Regions
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal RegionID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Region = (From RG In db.Regions Where RG.RegionID = RegionID).ToList()(0)
            db.Regions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.Region) As ResponseInfo
        Try
            db.Regions.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.Region) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal RegionID As String) As Hrms3.Region
        Try
            Return (From RG In db.Regions Where RG.RegionID = RegionID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Region
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.Region)
        Try
            Return (From RG In db.Regions).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Region)
        End Try
    End Function

End Class
