Partial Class sytem_numbers_aspx
    Inherits System.Web.UI.Page

    '$SR$ - Sub Risk Code
    '$RC$ - Risk Code
    '$YR$ - Current Year (2 digits)
    '$MO$ - Current Month (2 Digits)
    '$00000$ - Serial Number
    '$BR$ - Branch Code
    '$BR2$ - Branch Code 2

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.GridView1.DataSource = CreateDataSource()
            Me.GridView1.DataBind()
        End If
    End Sub

    Private Function CreateDataSource() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("AutoNum", GetType(String)))
        dt.Columns.Add(New DataColumn("BranchID", GetType(String)))
        dt.Columns.Add(New DataColumn("NextVal", GetType(String)))
        dt.Columns.Add(New DataColumn("Format", GetType(String)))
        dt.Columns.Add(New DataColumn("Sample", GetType(String)))

        Dim EnumNames As String() = [Enum].GetNames(GetType(cls_AutoNumber.AutoNumEnum))

        For Each EnumName In EnumNames
            Dim dr As DataRow = dt.NewRow()

            Dim Aa As Hrms3.AutoNumber = (New cls_AutoNumber).SelectThis(EnumName, "ALL")
            dr(0) = EnumName
            If Aa.NumType = "" Then 'empty
                dr(1) = "SEPARATE"
                dr(2) = ""
                dr(3) = ""
                dr(4) = ""
            Else
                dr(1) = "ALL"
                dr(2) = Aa.NextValue
                dr(3) = Aa.Format
                dr(4) = Aa.Sample
            End If
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function
End Class