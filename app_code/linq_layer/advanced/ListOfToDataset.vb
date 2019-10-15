Imports System.Data
Imports System.Reflection

Public Module CollectionExtensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDataSet(Of T)(ByVal collection As IEnumerable(Of T), Optional ByVal dataTableName As String = "Table1") As DataSet
        If collection Is Nothing Then
            Throw New ArgumentNullException("collection")
        End If
        If String.IsNullOrEmpty(dataTableName) Then
            Throw New ArgumentNullException("dataTableName")
        End If
        Dim data As New DataSet("NewDataSet")
        data.Tables.Add(FillDataTable(dataTableName, collection))
        Return data
    End Function

    Private Function FillDataTable(Of T)(ByVal tableName As String, ByVal collection As IEnumerable(Of T)) As DataTable
        Dim dt As New DataTable(tableName)

        Dim properties As PropertyInfo() = GetType(T).GetProperties()
        For Each p As PropertyInfo In properties
            dt.Columns.Add(p.Name) ', p.PropertyType)
        Next

        For Each item As T In collection
            Dim row As DataRow = dt.NewRow()
            For Each p As PropertyInfo In properties
                row(p.Name) = p.GetValue(item, Nothing)
            Next
            dt.Rows.Add(row)
        Next

        Return dt
    End Function

    Private Function FillDataRow(Of T)(ByVal dataRow As DataRow, ByVal item As T, ByVal properties As PropertyInfo()) As DataRow
        For Each p As PropertyInfo In properties
            dataRow(p.Name) = p.GetValue(item, Nothing)
        Next

        Return dataRow
    End Function

    Private Function CreateDataTable(Of T)(ByVal tableName As String, ByVal collection As IEnumerable(Of T), ByVal properties As PropertyInfo()) As DataTable
        Dim dt As New DataTable(tableName)

        For Each p As PropertyInfo In properties
            dt.Columns.Add(p.Name, p.PropertyType)
        Next

        Return dt
    End Function
End Module