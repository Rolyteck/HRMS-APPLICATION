Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Reflection

<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://webservices.idevworks.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AjaxPopulate
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function DebitNotes(ByVal prefixText As String) As String()

    '    Return cls_Parties.SearchName(prefixText).ToArray

    'End Function

    '<WebMethod()> _
    'Public Function InsuredList(ByVal contextKey As String) As String

    '    Dim strSQL As String = "SELECT TOP 200 InsuredID, Surname, FirstName FROM Insured WHERE Surname LIKE '%" & contextKey & "%' OR  InsuredID = '" & contextKey & "'"
    '    Return gv_Populate(strSQL)

    'End Function

    '<WebMethod()> _
    'Public Function PartyList(ByVal contextKey As String) As String

    '    Dim strSQL As String = "SELECT TOP 500 PartyID, Party FROM Parties WHERE Party LIKE '%" & contextKey & "%'"
    '    Return gv_Populate(strSQL)

    'End Function

    'Private Function gv_Populate(ByVal strSQL As String, Optional ByVal result As String = "Nothing was found!") As String
    '    Dim tw As New System.IO.StringWriter
    '    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
    '    Dim gv As New System.Web.UI.WebControls.GridView

    '    gv.CssClass = "GridStyle"
    '    gv.RowStyle.CssClass = "GridRowStyle"
    '    gv.AlternatingRowStyle.CssClass = "GridAltRowStyle"
    '    gv.HeaderStyle.CssClass = "GridHeaderStyle"
    '    gv.AutoGenerateColumns = True
    '    gv.ShowHeader = False

    '    AddHandler gv.RowDataBound, AddressOf gv_RowDataBound

    '    Dim objDataTable As Data.DataTable
    '    Try
    '        objDataTable = mod_main.getAdhocTable(strSQL, db.Connection)
    '    Catch ex As Exception
    '        result = ex.Message & Now.ToString
    '    End Try
    '    If objDataTable IsNot Nothing Then
    '        If objDataTable.Rows.Count > 0 Then
    '            gv.DataSource = New DataView(objDataTable)
    '            gv.DataBind()
    '            gv.RenderControl(hw)
    '            Return tw.ToString
    '        Else
    '            Return result
    '        End If
    '    Else
    '        Return result
    '    End If
    'End Function

    'Private Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    '    With e.Row
    '        Select Case .RowType
    '            Case DataControlRowType.DataRow
    '                .Attributes.Add("onmouseover", "javascript:datagrid_rowHover(this, 1);")
    '                .Attributes.Add("onmouseout", "javascript:datagrid_rowHover(this, 0);")
    '                .Attributes.Add("onclick", "javascript:datagrid_selectOneRow(this);itemSelected(this, '" & .Cells(0).Text & "');")

    '            Case DataControlRowType.Header

    '            Case Else

    '        End Select
    '    End With

    'End Sub

    'Private Function RenderView(ByVal controlPath As String) As String
    '    Try
    '        Dim pg As New Page()
    '        Dim hf As New HtmlForm()

    '        pg.Controls.Add(hf)
    '        hf.Controls.Add(pg.LoadControl(controlPath))

    '        Dim sw As New System.IO.StringWriter
    '        'Dim hw As New System.Web.UI.HtmlTextWriter(sw)

    '        HttpContext.Current.Server.Execute(pg, sw, False)

    '        Return sw.ToString()
    '    Catch ex As Exception
    '        Return ex.Message & "-->" & ex.InnerException.ToString
    '    End Try

    'End Function
End Class
