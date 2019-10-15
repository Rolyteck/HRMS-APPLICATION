
Public Class cls_Roles
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal RoleID As String) As ResponseInfo
        Try
            Dim row As Hrms3.Role = (From R In db.Roles Where R.RoleID = RoleID).ToList()(0)
            db.Roles.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal O As Hrms3.Role) As ResponseInfo
        Try
            db.Roles.InsertOnSubmit(O)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal O As Hrms3.Role) As ResponseInfo
        'very funny proceedure. all it does is call SubmitChanges()
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal RoleID As String) As Hrms3.Role
        Try
            Return (From R In db.Roles Where R.RoleID = RoleID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.Role
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.Role)
        Try
            Return (From R In db.Roles).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Role)
        End Try
    End Function

    Public Function SelectAllWithCount() As Object
        Try
            Return (From R In db.Roles Select R.RoleID, R.RoleName, R.RoleDescription, UserCount = 100).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Role)
        End Try
    End Function

    Public Function SelectByUserID(ByVal UserID As String) As List(Of Hrms3.Role)
        Try
            Return (From uR In db.UserRoles, R In db.Roles _
                    Where uR.RoleID = R.RoleID _
                    AndAlso uR.UserID = UserID _
                    Select R).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Role)
        End Try
    End Function

    Public Function SelectUsers(ByVal RoleID As String) As List(Of Hrms3.User)
        Return (New cls_Users).SelectByRoleID(RoleID)
    End Function

    Public Function SelectPermissions(ByVal RoleID As String) As List(Of Hrms3.Permission)
        Try
            Return (From rP In db.RolePermissions, P In db.Permissions _
                    Where rP.PermissionID = P.PermissionID _
                    AndAlso rP.RoleID = RoleID _
                    Select P).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Permission)
        End Try
    End Function

    Public Function InsertPermission(ByVal RoleID As String, ByVal PermissionID As String) As ResponseInfo
        Try
            Dim O As New Hrms3.RolePermission With { _
                        .RoleID = RoleID, _
                        .PermissionID = PermissionID, _
                        .SubmittedBy = mod_main.getLoggedOnUsername(), _
                        .SubmittedOn = Date.UtcNow _
                        }
            db.RolePermissions.InsertOnSubmit(O)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function DeletePermission(ByVal RoleID As String, ByVal PermissionID As Long) As ResponseInfo
        Try
            Dim row As Hrms3.RolePermission = (From item In db.RolePermissions Where (item.RoleID = RoleID) And (item.PermissionID = PermissionID)).ToList()(0)
            db.RolePermissions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function AddUserToRole(ByVal RoleID As String, ByVal UserID As String) As ResponseInfo
        Try
            Dim O As New Hrms3.UserRole With { _
                        .UserID = UserID, _
                        .RoleID = RoleID, _
                        .SubmittedBy = mod_main.getLoggedOnUsername(), _
                        .SubmittedOn = Date.UtcNow _
                        }
            db.UserRoles.InsertOnSubmit(O)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function RemoveUserFromRole(ByVal RoleID As String, ByVal UserID As String) As ResponseInfo
        Try
            Dim row As Hrms3.UserRole = (From item In db.UserRoles Where (item.UserID = UserID) And (item.RoleID = RoleID)).ToList()(0)
            db.UserRoles.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function RemoveUserFromAllRoles(ByVal UserID As String) As ResponseInfo
        Try
            Dim rows As List(Of Hrms3.UserRole) = (From item In db.UserRoles Where (item.UserID = UserID)).ToList()
            db.UserRoles.DeleteAllOnSubmit(rows)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function RemoveAllUsersFromRole(ByVal RoleID As String) As ResponseInfo
        Try
            Dim rows As List(Of Hrms3.UserRole) = (From item In db.UserRoles Where (item.RoleID = RoleID)).ToList()
            db.UserRoles.DeleteAllOnSubmit(rows)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function RemoveAllPermissions(ByVal RoleID As String) As ResponseInfo
        Try
            Dim rows As List(Of Hrms3.RolePermission) = (From item In db.RolePermissions Where (item.RoleID = RoleID)).ToList()
            db.RolePermissions.DeleteAllOnSubmit(rows)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    'Public Function hasPermission(ByVal RoleID As String, ByVal PermissionID As Long) As Boolean
    '    Dim rows As List(Of Hrms3.Permission) = (From U In SelectPermissions(RoleID) Where U.PermissionID = PermissionID).ToList()
    '    Return (rows IsNot Nothing And rows.Count > 0)
    'End Function

End Class
