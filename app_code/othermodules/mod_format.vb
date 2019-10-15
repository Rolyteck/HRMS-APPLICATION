Public Class idevFormatProvider : Implements IFormatProvider, ICustomFormatter

    Public Function GetFormat(ByVal formatType As Type) As Object Implements IFormatProvider.GetFormat
        If formatType Is GetType(ICustomFormatter) Then
            Return Me
        Else
            Return Nothing
        End If
    End Function

    Public Function Format(ByVal param As String, ByVal arg As Object, ByVal formatProvider As IFormatProvider) As String Implements ICustomFormatter.Format

        Dim source As String = arg.ToString()

        Select Case param
            Case "TIME" '{0:TIME}
                Return source ' FormatTime(source)

            Case "MONEY" '{0:MONEY}
                Return source 'FormatMoney(Val(source))

            Case "NUMBER" '{0:NUMBER}
                Return FormatNumber(source)

            Case "EMAIL" '{0:EMAIL}
                Return Left(source, 18)

            Case Else
                Return "?" & source & "?"

        End Select
    End Function
End Class