
Public Class cls_AutoNumber
    Dim db As New Hrms3.hrms3dbDataContext
    Public Enum AutoNumEnum
     
        PROPOSAL
        EMPLOYEEID
   
        'OTHERS
      
        'JOURNAL
    
    End Enum

    Public Function getNextAutoNumber(ByVal CustomNo As String, ByVal NumType As AutoNumEnum, ByVal BranchID As String, Optional ByVal SubRiskID As String = "") As String
        '$SR$ - Sub Risk Code
        '$RC$ - Risk Code
        '$YR$ - Current Year (2 digits)
        '$MO$ - Current Month (2 Digits)
        '$00000$ - Serial Number
        '$BR$ - Branch Code
        '$BR2$ - Branch Code 2

        Try

            If SubRiskID = "" Then
                If CustomNo.ToUpper.Contains("AUTO") Then
                    Dim strAutoNum As String = getSerialNoFormat(NumType.ToString, BranchID).ToString

                    If strAutoNum.IndexOf("$0") >= 0 Then
                        Dim nextNum As Long = getNextSerialNo(NumType.ToString, BranchID)
                        If nextNum > 0 Then
                            Dim len As Integer = strAutoNum.IndexOf("0$") - strAutoNum.IndexOf("$0")
                            If len < 3 Then len = 3

                            Dim zeros As String = New String("0", len)
                            strAutoNum = Replace(strAutoNum, "$" & zeros & "$", Format(nextNum, zeros))
                        Else
                            Throw New Exception("Invalid format in $0000$")
                        End If
                    Else
                        Throw New Exception("Missing format $0000$")
                    End If


                    strAutoNum = Replace(strAutoNum, "$SR$", SubRiskID)
                    strAutoNum = Replace(strAutoNum, "$YR$", Right(Now.Year.ToString, 2))
                    strAutoNum = Replace(strAutoNum, "$MO$", Right("0" & Now.Month.ToString, 2))
                    strAutoNum = Replace(strAutoNum, "$BR$", BranchID)
                  
                    If strAutoNum.Contains("$BR2$") Then
                        strAutoNum = Replace(strAutoNum, "$BR2$", (New cls_Branches).SelectThis(BranchID).BranchID2)
                    End If

                    Return strAutoNum
                Else
                    Return CustomNo.ToUpper
                End If
            Else
                If CustomNo.ToUpper.Contains("AUTO") Then
                    Dim strAutoNum As String = getSerialNoFormat(NumType.ToString, BranchID, SubRiskID).ToString

                    If strAutoNum.IndexOf("$0") >= 0 Then
                        Dim nextNum As Long = getNextSerialNo(NumType.ToString, BranchID, SubRiskID)
                        If nextNum > 0 Then
                            Dim len As Integer = strAutoNum.IndexOf("0$") - strAutoNum.IndexOf("$0")
                            If len < 3 Then len = 3

                            Dim zeros As String = New String("0", len)
                            strAutoNum = Replace(strAutoNum, "$" & zeros & "$", Format(nextNum, zeros))
                        Else
                            Throw New Exception("Invalid format in $0000$")
                        End If
                    Else
                        Throw New Exception("Missing format $0000$")
                    End If

                    strAutoNum = Replace(strAutoNum, "$SR$", SubRiskID)
                    strAutoNum = Replace(strAutoNum, "$YR$", Right(Now.Year.ToString, 2))
                    strAutoNum = Replace(strAutoNum, "$MO$", Right("0" & Now.Month.ToString, 2))
                    strAutoNum = Replace(strAutoNum, "$BR$", BranchID)
                
                    If strAutoNum.Contains("$BR2$") Then
                        strAutoNum = Replace(strAutoNum, "$BR2$", (New cls_Branches).SelectThis(BranchID).BranchID2)
                    End If

                    Return strAutoNum
                Else
                    Return CustomNo.ToUpper
                End If


            End If

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function getNextSerialNo(ByVal NumType As String, ByVal BranchID As String, Optional ByVal RiskID As String = "") As Long

        If settings.COMPANY_ABREV = "staco" Then
            RiskID = BranchID
        End If


        Try
            Dim T As List(Of Hrms3.AutoNumber) = (From A In db.AutoNumbers _
            Where A.NumType = NumType And A.BranchID = "ALL").ToList()

            If T.Count > 0 Then
                Try
                    getNextSerialNo = T(0).NextValue
                Catch ex As Exception
                    T(0).NextValue = 1
                    getNextSerialNo = 1
                End Try
                'then increment and update
                T(0).NextValue += 1
                db.SubmitChanges()
            Else 'try specific

                If RiskID = "" Then
                    T = (From A In db.AutoNumbers _
                        Where A.NumType = NumType And A.BranchID = BranchID).ToList()

                    If T.Count > 0 Then
                        getNextSerialNo = T(0).NextValue
                        'then increment and update
                        T(0).NextValue += 1
                        db.SubmitChanges()
                    Else 'no number setup
                        Return -1
                    End If
                Else
                    T = (From A In db.AutoNumbers _
                Where A.NumType = NumType And A.BranchID = BranchID).ToList()

                    If T.Count > 0 Then
                        getNextSerialNo = T(0).NextValue
                        'then increment and update
                        T(0).NextValue += 1
                        db.SubmitChanges()
                    Else 'no number setup
                        Return -1
                    End If

                End If

            End If

        Catch ex As Exception
            Return -2
        End Try
    End Function

    Private Function getSerialNoFormat(ByVal NumType As String, ByVal BranchID As String, Optional ByVal RiskID As String = "") As String

        If settings.COMPANY_ABREV = "staco" Then
            RiskID = BranchID
        End If

        Try
            Dim T As List(Of Hrms3.AutoNumber) = (From A In db.AutoNumbers _
            Where A.NumType = NumType And A.BranchID = "ALL").ToList()

            If T.Count > 0 Then
                Return T(0).Format
            Else 'try specific

                If RiskID = "" Then
                    T = (From A In db.AutoNumbers _
                        Where A.NumType = NumType And A.BranchID = BranchID).ToList()

                    If T.Count > 0 Then
                        Return T(0).Format
                    Else 'no number setup
                        Return String.Empty
                    End If
                Else
                    T = (From A In db.AutoNumbers _
                                         Where A.NumType = NumType And A.BranchID = BranchID).ToList()

                    If T.Count > 0 Then
                        Return T(0).Format
                    Else 'no number setup
                        Return String.Empty
                    End If


                End If
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function


    Public Function Insert(ByVal G As Hrms3.AutoNumber) As ResponseInfo
        Try
            db.AutoNumbers.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.AutoNumber) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function Delete(ByVal G As Hrms3.AutoNumber) As ResponseInfo
        Try
            db.AutoNumbers.DeleteOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal NumType As String, ByVal BranchID As String) As Hrms3.AutoNumber
        Try
            Return (From A In db.AutoNumbers _
                    Where A.NumType = NumType And A.BranchID = BranchID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.AutoNumber
        End Try
    End Function

    Public Function SelectAll() As List(Of Hrms3.AutoNumber)
        Try
            Return (From A In db.AutoNumbers).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.AutoNumber)
        End Try
    End Function
End Class
