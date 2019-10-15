
Public Class cls_Asspurchases
    Dim db As Hrms3.hrms3dbDataContext


    Public Sub New(Optional ByVal Context As Hrms3.hrms3dbDataContext = Nothing)
        If Context Is Nothing Then
            db = New Hrms3.hrms3dbDataContext
        Else
            db = Context
        End If
    End Sub

    Public Function Delete(ByVal Asset_Code As String) As ResponseInfo
        Try
            Dim row As Hrms3.assPurchase = (From A In db.assPurchases Where A.Asset_Code = Asset_Code).ToList()(0)
            'row.Deleted = 1
            db.assPurchases.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.assPurchase) As ResponseInfo
        Try
            db.assPurchases.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal A As Hrms3.assPurchase) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try

    End Function

    Public Function UpdateAssetTransferStatus(ByVal AssetCode As String, ByVal LocationID As String, ByVal Location As String, ByVal transferDate As Date) As ResponseInfo
        Try
            Dim c As Hrms3.assPurchase = SelectThis(AssetCode)
            c.LocationID = LocationID
            c.Location = Location
            c.DisposedDate = transferDate
            db.SubmitChanges()

            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function


    Public Function UpdateAssetApprovalStatus(ByVal AssetCode As String) As ResponseInfo
        Try
            Dim c As Hrms3.assPurchase = SelectThis(AssetCode)
            c.TransSTATUS = "APPROVED2"
            c.ApprovedBy = mod_main.getLoggedOnUsername()
            c.ApprovedOn = DateTime.Now
            db.SubmitChanges()

            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function UpdateAssetDisposalApprovalStatus(ByVal AssetCode As String) As ResponseInfo
        Try
            Dim c As Hrms3.assPurchase = SelectThisDisposal(AssetCode)
            c.TransSTATUS = "APPROVED2"
            c.ApprovedBy = mod_main.getLoggedOnUsername()
            c.ApprovedOn = DateTime.Now
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function


    Public Function UpdateAssetNETBookValue(ByVal AssetCode As String, ByVal MonthDeprAmt As Decimal, ByVal LastDEPRMonth As String) As ResponseInfo
        Try
            Dim c As Hrms3.assPurchase = SelectThis(AssetCode)
            c.CumDep = c.CumDep + MonthDeprAmt
            c.NBV = c.Purchase_Amt - (c.CumDep + MonthDeprAmt)
            'c.LastDeprMonth = LastDEPRMonth
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function SelectThis(ByVal Asset_Code As String) As Hrms3.assPurchase
        Try
            Return (From A In db.assPurchases Where A.Asset_Code = Asset_Code And A.Trans_Type = "PUR").ToList()(0)
        Catch ex As Exception
            Return New Hrms3.assPurchase
        End Try
    End Function
    Public Function SelectThisDisposal(ByVal Asset_Code As String) As Hrms3.assPurchase
        Try
            Return (From A In db.assPurchases Where A.Asset_Code = Asset_Code And A.Trans_Type = "DISPOSED").ToList()(0)
        Catch ex As Exception
            Return New Hrms3.assPurchase
        End Try
    End Function
    Public Function SelectThisByInvoiceNos(ByVal InvoiceNo As String) As List(Of Hrms3.assPurchase)
        Try
            Return (From A In db.assPurchases Where A.Invoice_No = InvoiceNo And A.Trans_Type = "PUR_REQ").ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.assPurchase)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.assPurchase)
        Try
            Return (From A In db.assPurchases Where A.Deleted = 0 And A.Trans_Type = "PUR").ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.assPurchase)
        End Try
    End Function
    Public Function SelectAllAssets(ByVal AssetCodes() As String) As List(Of Hrms3.assPurchase)
        Try
            Return (From P In db.assPurchases Where AssetCodes.Contains(P.Asset_Code) And P.TransSTATUS = "PENDING" And P.Deleted = 0).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.assPurchase)
        End Try
    End Function
    Public Function SelectWhere(ByVal Date1 As Date, ByVal Date2 As Date, ByVal NoteType As String, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.assPurchase)
        Try
            If SearchText = "" Then
                Return (From AC In db.assPurchases _
                Where AC.Purchase_Date >= Date1 _
                AndAlso AC.Purchase_Date <= Date2 _
                AndAlso AC.Trans_Type = NoteType _
                AndAlso AC.Deleted = 0 _
                AndAlso AC.TransSTATUS = "PENDING").ToList()

            Else
                Return (From AC In db.assPurchases _
            Where AC.Trans_Type = NoteType _
             AndAlso AC.Deleted = 0 _
            AndAlso AC.TransSTATUS = "PENDING").Where(SearchField & ".Contains(@0)", _
                               SearchText).ToList()
            End If
        Catch ex As Exception
            Return New List(Of Hrms3.assPurchase)
        End Try
    End Function



    Public Function GetAssetDetails(ByVal VoucherNo As String) As Object
        Try
            Return (From asspurchases In db.assPurchases _
Where _
  asspurchases.Invoice_No = VoucherNo _
Group asspurchases By _
  asspurchases.Purchase_Date, _
  asspurchases.Invoice_No, _
  asspurchases.CategoryID, _
  asspurchases.BankCode, _
  asspurchases.ChequeDetail, _
  asspurchases.Optiontype, _
  asspurchases.Description, _
  asspurchases.Remarks _
 Into g = Group _
Select _
  LocationID = g.Max(Function(p) p.LocationID), _
  CategoryID, _
  Purchase_Date, _
  Invoice_No, _
  Purchase_Amt = CType(g.Sum(Function(p) p.Purchase_Amt), Decimal?), _
  BankCode, _
  ChequeDetail, _
  Optiontype, _
  Description, _
  Remarks).ToList()(0)


        Catch ex As Exception
            Return New Hrms3.assPurchase
        End Try
    End Function

    Public Function SelectWhereDisposed(ByVal Date1 As Date, ByVal Date2 As Date, ByVal NoteType As String, ByVal SearchField As String, ByVal SearchText As String) As List(Of Hrms3.assPurchase)
        Try
            Return (From AC In db.assPurchases _
            Where AC.DisposedDate >= Date1 _
            AndAlso AC.Purchase_Date <= Date2 _
            AndAlso AC.Trans_Type = NoteType _
              AndAlso AC.Deleted = 0 _
              AndAlso AC.TransSTATUS <> "APPROVED2").Where( _
                                        SearchField & ".Contains(@0)", _
                        SearchText).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.assPurchase)
        End Try
    End Function
    Public Function SelectAll4Depr() As List(Of Hrms3.assPurchase)
        Try
            Return (From AC In db.assPurchases _
            Where AC.Trans_Type = "PUR" _
             AndAlso AC.Deleted = 0 _
              AndAlso AC.NBV > 0 _
                 AndAlso AC.Active = 1 _
            ).ToList()

        Catch ex As Exception
            Return New List(Of Hrms3.assPurchase)
        End Try
    End Function

End Class
