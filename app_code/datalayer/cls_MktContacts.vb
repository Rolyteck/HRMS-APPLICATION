
Public Class cls_MktContacts
    Dim db As New Hrms3.hrms3dbDataContext

    Public  Function Delete(ByVal MktContactID As String) As ResponseInfo
        Try
            Dim row As Hrms3.MktContact = (From c In db.MktContacts Where c.MktContactID = MktContactID).ToList()(0)
            db.MktContacts.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.MktContact) As ResponseInfo
        Try
            db.MktContacts.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.MktContact) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function SelectThis(ByVal MktContactID As String) As Hrms3.MktContact
        Try
            Return (From C In db.MktContacts Where C.MktContactID = MktContactID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.MktContact
        End Try
    End Function

    Public Function SelectWhere(ByVal InsuredID As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.MktContact)
        Try
            If InsuredID = "" Then
                Return (From C In db.MktContacts Select C).Where( _
                     "(SubmittedOn >= @0) And (SubmittedOn <= @1)  And " & SearchField & ".Contains(@2)", _
                     Date1.AddSeconds(1), Date2.AddDays(1).AddSeconds(-1), SearchText).ToList()
            Else
                Return (From C In db.MktContacts _
                        Where C.InsuredID = InsuredID _
                        AndAlso C.SubmittedOn >= Date1.AddSeconds(1) _
                        AndAlso C.SubmittedOn <= Date2.AddDays(1).AddSeconds(-1) _
                        Select C).ToList() '.Where(SearchField & ".Contains(@0)", SearchText).ToList()
            End If

        Catch ex As Exception
            Return New List(Of Hrms3.MktContact)
        End Try
    End Function

End Class
