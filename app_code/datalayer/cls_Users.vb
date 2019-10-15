
Public Class cls_Users
    Dim db As New Hrms3.hrms3dbDataContext


    Public Function Delete(ByVal UserID As String) As ResponseInfo
        Try
            Dim row As Hrms3.User = (From U In db.Users Where U.UserID = UserID).ToList()(0)
            db.Users.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal O As Hrms3.User) As ResponseInfo
        Try
            db.Users.InsertOnSubmit(O)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal O As Hrms3.User) As ResponseInfo
        'very funny proceedure. all it does is call SubmitChanges()
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal UserID As String) As Hrms3.User
        Try
            Return (From U In db.Users Where U.UserID = UserID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.User
        End Try
    End Function

    Public Function SelectByUsername(ByVal Username As String) As Hrms3.User
        Try
            Return (From U In db.Users Where U.Username = Username).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.User
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.User)
        Try
            Return (From U In db.Users Order By U.Username).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.User)
        End Try
    End Function
    Public Function SelectAllUsers(ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.User)
        Try
            Return (From U In db.Users Order By U.Username).Where( _
                            SearchField & ".Contains(@0)", _
            SearchText).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.User)
        End Try
    End Function
    Public Function SelectByRoleID(ByVal RoleID As String) As List(Of Hrms3.User)
        Try
            Return (From uR In db.UserRoles, U In db.Users _
                    Where uR.UserID = U.UserID _
                    AndAlso uR.RoleID = RoleID _
                    Select U Order By U.Username).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.User)
        End Try
    End Function

    Public Function SelectRoles(ByVal UserID As String) As List(Of Hrms3.Role)
        Return (New cls_Roles).SelectByUserID(UserID)
    End Function

    Public Function SelectPermissionsCombined(ByVal UserID As String) As List(Of Hrms3.Permission)
        Try
            Return (From uP In db.UserPermissions, P In db.Permissions _
                    Where uP.PermissionID = P.PermissionID _
                    AndAlso uP.UserID = UserID _
                    Select P).Union( _
                    From uR In db.UserRoles, rP In db.RolePermissions, P In db.Permissions _
                    Where uR.RoleID = rP.RoleID AndAlso rP.PermissionID = P.PermissionID _
                    AndAlso uR.UserID = UserID _
                    Select P).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Permission)
        End Try
    End Function

    Public Function SelectPermissionsExplicit(ByVal UserID As String) As List(Of Hrms3.Permission)
        Try
            Return (From uP In db.UserPermissions, P In db.Permissions _
                    Where uP.PermissionID = P.PermissionID _
                    AndAlso uP.UserID = UserID _
                    Select P).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.Permission)
        End Try
    End Function

    Public Function InsertPermission(ByVal UserID As String, ByVal PermissionID As String) As ResponseInfo
        Try
            Dim O As New Hrms3.UserPermission With { _
                        .UserID = UserID, _
                        .PermissionID = PermissionID, _
                        .SubmittedBy = mod_main.getLoggedOnUsername(), _
                        .SubmittedOn = Date.UtcNow _
                        }
            db.UserPermissions.InsertOnSubmit(O)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function RemoveAllPermissions(ByVal UserID As String) As ResponseInfo
        Try
            Dim rows As List(Of Hrms3.UserPermission) = (From item In db.UserPermissions Where (item.UserID = UserID)).ToList()
            db.UserPermissions.DeleteAllOnSubmit(rows)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function DeletePermission(ByVal UserID As String, ByVal PermissionID As Long) As ResponseInfo
        Try
            Dim row As Hrms3.UserPermission = (From item In db.UserPermissions Where (item.UserID = UserID) And (item.PermissionID = PermissionID)).ToList()(0)
            db.UserPermissions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function AddUserToRole(ByVal RoleID As String, ByVal UserID As String) As ResponseInfo
        Return (New cls_Roles).AddUserToRole(RoleID, UserID)
    End Function

    Public Function RemoveUserFromRole(ByVal RoleID As String, ByVal UserID As String) As ResponseInfo
        Return (New cls_Roles).RemoveUserFromRole(RoleID, UserID)
    End Function

    Public Function hasPermission(ByVal UserID As String, ByVal PermissionID As PermissionEnum) As Boolean
        Dim rows As List(Of Hrms3.Permission) = (From U In SelectPermissionsCombined(UserID) Where U.PermissionID = PermissionID).ToList()
        Return (rows IsNot Nothing AndAlso rows.Count > 0)
    End Function

    Public Function Login(ByVal Username As String, ByVal Password As String) As ResponseInfo
        Try
            Dim user As List(Of Hrms3.User) = (From item In db.Users Where item.Username = Username AndAlso item.Password = mod_main.EncodeToHash(Password)).ToList()
            If user IsNot Nothing AndAlso user.Count > 0 Then
                If user(0).Active = 0 Then 'disabled
                    Return mod_main._GetResponseStruct(ErrCodeEnum.ACCOUNT_LOCKED, , , "Your account has been disabled by your Administrator.")
                ElseIf user(0).PwdExpiry < Today Then 'expired
                    Return mod_main._GetResponseStruct(ErrCodeEnum.ACCOUNT_EXPIRED, , , "Your password has expired. Please change your password now.")
                Else
                    Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0, , user(0).UserID)
                End If
            Else
                'Dim Attempt As List(Of Hrms3.LoginHistory) = (From item In db.LoginHistories Where item.UserName = Username And item.SubmittedOn = Today.Date).ToList()
                'If Attempt IsNot Nothing AndAlso Attempt.Count > settings.LOGIN_ATTEMPTS Then

                '    Return mod_main._GetResponseStruct(ErrCodeEnum.INVALID_PASSWORD, , , "Your Password attempts has been exhausted contact your Administrator.")
                'Else

                '    Dim O As New Hrms3.LoginHistory With { _
                '                       .UserName = Username, _
                '                       .password = Password, _
                '                       .Description = mod_main.EncodeToHash(Password), _
                '                       .SubmittedOn = Today.Date _
                '                            }
                '    db.LoginHistories.InsertOnSubmit(O)
                '    db.SubmitChanges()
                '    
                'End If
                Return mod_main._GetResponseStruct(ErrCodeEnum.INVALID_PASSWORD, , , "Invalid Username or Password.")
            End If
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function



    Public Function SelectMktUsersComplete(ByVal Username As String) As Object

        Try
            Return (From U In db.Users Where U.Username = Username _
                     Select U.UserID, FullName = U.FirstName & " " & U.LastName, U.FirstName, U.LastName, U.Phone).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.User)
        End Try

    End Function


    Public Function ChangePwd(ByVal Username As String, ByVal OldPassword As String, ByVal NewPassword As String) As ResponseInfo
        Try
            Dim user As List(Of Hrms3.User) = (From item In db.Users Where item.Username = Username AndAlso item.Password = mod_main.EncodeToHash(OldPassword)).ToList()
            If user IsNot Nothing AndAlso user.Count > 0 Then
                If user(0).Active = 0 Then 'disabled
                    Return mod_main._GetResponseStruct(ErrCodeEnum.ACCOUNT_LOCKED, , , "Your account has been disabled by your Administrator.")
                Else
                    user(0).Password = mod_main.EncodeToHash(NewPassword)
                    user(0).PwdExpiry = Today.Date.AddDays(settings.CHANGE_PWD_DAYS)

                    db.SubmitChanges()
                    Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
                End If
            Else
                Return mod_main._GetResponseStruct(ErrCodeEnum.INVALID_PASSWORD, , , "Invalid Username or Password.")
            End If
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Reset(ByVal Username As String, ByVal NewPassword As String) As ResponseInfo
        Try
            Dim user As List(Of Hrms3.User) = (From item In db.Users Where item.Username = Username).ToList()
            If user IsNot Nothing AndAlso user.Count > 0 Then
                If user(0).Active = 0 Then 'disabled
                    Return mod_main._GetResponseStruct(ErrCodeEnum.ACCOUNT_LOCKED, , , "Your account has been disabled by your Administrator.")
                Else
                    user(0).Password = mod_main.EncodeToHash(NewPassword)
                    user(0).PwdExpiry = Today.Date.AddDays(settings.INITIAL_PWD_DAYS)

                    db.SubmitChanges()
                    Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
                End If
            Else
                Return mod_main._GetResponseStruct(ErrCodeEnum.INVALID_PASSWORD, , , "Invalid Username. User does not exist in the database.")
            End If

        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

End Class