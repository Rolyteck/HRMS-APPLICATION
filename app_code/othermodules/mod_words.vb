Public Module NumberToWords

    Private Function getU(ByVal U As Byte) As String
        Select Case U
            Case 0 : getU = ""
            Case 1 : getU = "one"
            Case 2 : getU = "two"
            Case 3 : getU = "three"
            Case 4 : getU = "four"
            Case 5 : getU = "five"
            Case 6 : getU = "six"
            Case 7 : getU = "seven"
            Case 8 : getU = "eight"
            Case 9 : getU = "nine"
            Case Else : getU = "*error*"
        End Select
    End Function

    Private Function getTU(ByVal TU As Byte) As String
        Dim T As Byte, U As Byte

        T = Left(Format(TU, "0#"), 1)
        U = Right(TU, 1)

        Select Case T
            Case 0 : getTU = getU(U)
            Case 1
                Select Case U
                    Case 0 : getTU = "ten"
                    Case 1 : getTU = "eleven"
                    Case 2 : getTU = "twelve"
                    Case 3 : getTU = "thirteen"
                    Case 4 : getTU = "fourteen"
                    Case 5 : getTU = "fifteen"
                    Case 6 : getTU = "sixteen"
                    Case 7 : getTU = "seventeen"
                    Case 8 : getTU = "eighteen"
                    Case 9 : getTU = "nineteen"
                    Case Else : getTU = "*error*"
                End Select
            Case 2 : getTU = "twenty" & IIf(U > 0, "-" & getU(U), "")
            Case 3 : getTU = "thirty" & IIf(U > 0, "-" & getU(U), "")
            Case 4 : getTU = "forty" & IIf(U > 0, "-" & getU(U), "")
            Case 5 : getTU = "fifty" & IIf(U > 0, "-" & getU(U), "")
            Case 6 : getTU = "sixty" & IIf(U > 0, "-" & getU(U), "")
            Case 7 : getTU = "seventy" & IIf(U > 0, "-" & getU(U), "")
            Case 8 : getTU = "eighty" & IIf(U > 0, "-" & getU(U), "")
            Case 9 : getTU = "ninety" & IIf(U > 0, "-" & getU(U), "")
            Case Else : getTU = "*error2*"
        End Select
    End Function

    Private Function getHTU(ByVal HTUi As Integer) As String
        Dim HTU As String, temp As String = ""
        Dim H As Byte, TU As Byte

        HTU = Format(HTUi, "00#")
        H = Left(HTU, 1)
        TU = Mid(HTU, 2, 2)

        If H > 0 Then temp = getU(H) & " hundred"
        If TU > 0 Then
            If H > 0 Then
                temp &= " and " & getTU(TU)
            Else
                temp = getTU(TU)
            End If
        End If
        Return temp
    End Function

    Public Function ConvNumToWords(ByVal Num As String) As String
        Dim Temp As Integer, strTemp As String = ""
        Dim nLen As Byte = Num.Length
        Num = Num.Trim

        Num = Format(Val(Num), "00000000000000#") '15 digits max

        If nLen > 12 Then
            Temp = CInt(Mid(Num, 1, 3))
            If Temp > 0 Then strTemp = getHTU(Temp) & " trillion, "
        End If
        If nLen > 9 Then
            Temp = CInt(Mid(Num, 4, 3))
            If Temp > 0 Then strTemp &= getHTU(Temp) & " billion, "
        End If
        If nLen > 6 Then
            Temp = CInt(Mid(Num, 7, 3))
            If Temp > 0 Then strTemp &= getHTU(Temp) & " million, "
        End If
        If nLen > 3 Then
            Temp = CInt(Mid(Num, 10, 3))
            If Temp > 0 Then strTemp &= getHTU(Temp) & " thousand, "
        End If

        Temp = CInt(Mid(Num, 13, 3))
        strTemp = StrConv(Trim(strTemp & getHTU(Temp)), vbProperCase)

        If Right(strTemp, 1) = "," Then
            strTemp = Left(strTemp, strTemp.Length - 1)
        End If

        Dim P As Integer = InStrRev(strTemp, ",")
        If P > 0 And Temp < 99 Then
            strTemp = Left(strTemp, P - 1) & Replace(strTemp, ",", " and", P)
        End If

        Return strTemp
    End Function

    Public Function ConvToNairaKobo(ByVal Amount As Single, Optional ByVal AddOnly As Boolean = True, Optional ByVal CurrencyName As String = "Naira", Optional ByVal CurrencyNameEx As String = "Kobo") As String
        Dim Naira As Long = Fix(Amount)
        Dim Kobo As Long = Fix((Amount - Naira) * 100)
        ConvToNairaKobo = ConvNumToWords(Naira) & " " & CurrencyName
        If Kobo > 0 Then ConvToNairaKobo = ConvToNairaKobo _
        & " and " & ConvNumToWords(Kobo) & " " & CurrencyNameEx
        If AddOnly Then ConvToNairaKobo = ConvToNairaKobo & " Only"
    End Function

End Module
