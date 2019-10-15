
Public Class cls_hrpromotions
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal promotoinID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRPromotion = (From DN In db.HRPromotions Where DN.PromotionID = promotoinID).ToList()(0)
            db.HRPromotions.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Insert(ByVal G As Hrms3.HRPromotion) As ResponseInfo
        Try
            db.HRPromotions.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRPromotion) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
            'Return mod_main._GetResponseStruct(ErrCodeEnum.FORBIDDEN, , , "You cannot modify a Debit Note!")
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal PromotionID As String) As Hrms3.HRPromotion
        Try
            Return (From DN In db.HRPromotions Where DN.PromotionID = PromotionID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRPromotion
        End Try
    End Function

    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRPromotion)
        Try
            Return (From DN In db.HRPromotions Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRPromotion)
        End Try
    End Function


    Public Function SelectWhere(ByVal PromotionID As String) As List(Of Hrms3.HRPromotion)
        Try
            Return (From DN In db.HRPromotions Where DN.PromotionID = PromotionID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRPromotion)
        End Try
    End Function


    'Public Function SelectWhereEmployeeNo(ByVal EmployeeID As String) As Object
    '    'remove this line later
    '    Try
    '        Return (From P In db.PromotionView1s, Q In db.PaySheets _
    '                Where P.SheetID = Q.SheetID Select P, Q.PaySheet).Where( _
    '                "(EmployeeID = @0)", _
    '                EmployeeID).SingleOrDefault
    '        'Return (From DN In db.HRPromotions Where DN.EmployeeID = EmployeeID).ToList()(0)
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function


    Public Function SelectWhereEmployeeNo(ByVal EmployeeID As String) As Hrms3.HRPromotion
        'remove this line later
        Try
            'Return (From P In db.PromotionView1s, Q In db.PaySheets _
            '        Where P.SheetID = Q.SheetID Select P, Q.PaySheet).Where( _
            '        "(EmployeeID = @0)", _
            '        EmployeeID).SingleOrDefault
            Return (From DN In db.HRPromotions Where DN.EmployeeID = EmployeeID).ToList()(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
