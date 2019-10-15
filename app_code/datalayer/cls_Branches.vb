
Public Class cls_Branches
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal BranchID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Branch = (From B In db.Branches Where B.BranchID = BranchID).ToList()(0)
            db.Branches.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.Branch) As ResponseInfo
        Try
            db.Branches.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.Branch) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal BranchID As String) As Hrms3.Branch
        Try
            Return (From B In db.Branches Where B.BranchID = BranchID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Branch
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.Branch)
        Try
            Return (From P In db.Branches Order By P.Description).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Branch)
        End Try
    End Function

    Public Function SelectByUserID(ByVal UserID As String) As List(Of Hrms3.Branch)
        Try
            Return (From uB In db.UserBranches, B In db.Branches _
                    Where uB.BranchID = B.BranchID _
                    AndAlso uB.UserID = UserID _
                    Select B).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Branch)
        End Try
    End Function

    Public Function RemoveUserFromAllBranches(ByVal UserID As String) As ResponseInfo
        Try
            Dim rows As List(Of Hrms3.UserBranch) = (From uB In db.UserBranches Where uB.UserID = UserID).ToList()
            db.UserBranches.DeleteAllOnSubmit(rows)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function AddUserToBranch(ByVal BranchID As String, ByVal UserID As String) As ResponseInfo
        Try
            Dim O As New Hrms3.UserBranch With { _
                        .UserID = UserID, _
                        .BranchID = BranchID, _
                        .SubmittedBy = mod_main.getLoggedOnUsername(), _
                        .SubmittedOn = Date.UtcNow _
                        }
            db.UserBranches.InsertOnSubmit(O)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

End Class
