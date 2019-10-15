Public Module mod_ui_helpers

#Region "USER INTERFACE HELPERS"

    Public Function FormatDate(ByVal Value As String) As String
        If IsDate(Value) Then
            Return Format(CDate(Value), "dd-MMM-yyyy")
        Else
            Return ""
        End If
    End Function
    Public Function FormatDate2(ByVal Value As String) As String
        If IsDate(Value) Then
            Return Format(CDate(Value), "MMMM yyyy")
        Else
            Return ""
        End If
    End Function



    Public Function FormatMonthYear(ByVal Value As String) As String
        If IsDate(Value) Then
            Return Format(CDate(Value), "MMMM-yyyy")
        Else
            Return ""
        End If
    End Function
    Public Function SetNextPageMessage(ByVal EntityName As String, ByVal EntityID As String, Optional ByVal isError As Boolean = False) As Boolean
        Dim str As String = "Data saved successfully for " & EntityName.ToLower & " [" & EntityID & "]"
        My.Response.Cookies.Add(New HttpCookie("NextPageMessage", str))
    End Function

    Public Function GetNextPageMessage(ByVal Msgbox As Object) As Boolean
        Dim C As HttpCookie = My.Request.Cookies.Get("NextPageMessage")
        If C IsNot Nothing AndAlso C.Value <> "" Then
            My.Response.Cookies.Item("NextPageMessage").Value = ""
            If C.Value.StartsWith("Error") Then
                Msgbox.showError(C.Value)
            Else
                Msgbox.showInfo(C.Value)
            End If
        End If
    End Function

    Public Function FormatClassHeader(ByVal listType As String) As String
        'Return "[" & getClassName() & "] " & listType
        Return getClassName(ClassNameEnum.FullClassName) & " " & listType
    End Function

    Public Sub MakeDatePicker(ByVal pg As Web.UI.Page, ByRef txt As UI.WebControls.TextBox, ByVal defaultDate As Date)
        Dim UID As String = txt.ClientID

        'txt.Attributes.Add("onclick", "return showCalendar('" & UID & "', '%b, %d %Y');")
        txt.Attributes.Add("onclick", "return showCalendar('" & UID & "', '%d-%b-%Y');")
        txt.Attributes.Add("onfocus", "this.select();")
        txt.Text = Format(defaultDate, "MMM, dd yyyy")
        'txt.CssClass = "textboxDate"

        pg.Header.Controls.Add(New UI.LiteralControl("<link type='text/css' rel='stylesheet' href='/webroot/web/scripts/calendar/calendar-blue.css'></link>"))
        pg.ClientScript.RegisterClientScriptBlock(pg.GetType, "cal", "<script src='/webroot/web/scripts/calendar/calendar.js' type='text/javascript'></script>")
        pg.ClientScript.RegisterClientScriptBlock(pg.GetType, "cal-en", "<script src='/webroot/web/scripts/calendar/calendar-en.js' type='text/javascript'></script>")
        pg.ClientScript.RegisterClientScriptBlock(pg.GetType, "cal-setup", "<script src='/webroot/web/scripts/calendar/calendar-setup.js' type='text/javascript'></script>")
        pg.ClientScript.RegisterClientScriptBlock(pg.GetType, "cal-helper", "<script src='/webroot/web/scripts/calendar/calendar-helper.js' type='text/javascript'></script>")
    End Sub

    Public Sub MakeDropDownJs(ByVal pg As Web.UI.Page, ByRef cmb As UI.WebControls.DropDownList)
        'Dim cmbID As String = Replace(cmb.UniqueID, ":", "_")
        'Dim txt As New UI.WebControls.TextBox()
        'txt.ID = cmb.ID & "Textbox"
        'txt.CssClass = cmb.CssClass
        'txt.ReadOnly = True
        'If txt.CssClass = "" Then txt.CssClass = "dropdown_text"
        'If Not cmb.Enabled Then txt.Attributes.Add("disabled", "disabled")
        'If Not cmb.Width.IsEmpty Then txt.Width = cmb.Width
        'If cmb.SelectedItem IsNot Nothing Then txt.Text = cmb.SelectedItem.Text
        'cmb.Style.Add("display", "none")

        'Dim tbl As New UI.WebControls.Panel
        'tbl.ID = cmb.ID & "Table"
        'tbl.CssClass = "dropdown_table"
        'tbl.Style.Add("display", "none")
        'For Each i As ListItem In cmb.Items
        '    tbl.Controls.Add(New LiteralControl("<a href=""javascript:dropdown_setDropValue('" & cmbID & "', '" & i.Text & "', '" & i.Value & "');"">" & i.Text & "</a><br>"))
        'Next

        'cmb.Parent.Controls.Add(txt) 'this only places the control properly if the parent is also a control (runat=server)
        'cmb.Parent.Controls.Add(tbl)

        'txt.Attributes.Add("onclick", "return dropdown_showPopup('" & cmbID & "');")
        'txt.Attributes.Add("onblur", "return dropdown_hidePopup('" & cmbID & "');")

        'pg.Header.Controls.Add(New UI.LiteralControl("<link type='text/css' rel='stylesheet' href='/webroot/web/scripts/dropdown/dropdown.css'></link>"))
        'pg.ClientScript.RegisterClientScriptBlock(pg.GetType, "dropdown", "<script src='/webroot/web/scripts/dropdown/dropdown.js' type='text/javascript'></script>")
    End Sub

    Public Sub AppendBoundField(ByVal gridView As UI.WebControls.GridView, ByVal HeaderText As String, ByVal DataField As String, Optional ByVal hAlignment As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Width As String = "", Optional ByVal Format As String = "")
        Dim Field As New WebControls.BoundField

        With Field
            .DataField = DataField
            .HeaderText = HeaderText
            .HeaderStyle.HorizontalAlign = hAlignment
            .ItemStyle.HorizontalAlign = hAlignment
            .HtmlEncode = False
            .HtmlEncodeFormatString = False
            If Width = "0" Then
                .HeaderStyle.CssClass = "hidden"
                .ItemStyle.CssClass = "hidden"
            ElseIf Width <> "" Then
                .HeaderStyle.Width = Unit.Parse(Width)
                .ItemStyle.Width = Unit.Parse(Width)
            End If

            If Format.StartsWith("{") Then
                .DataFormatString = Format
            Else
                .AccessibleHeaderText = Format
            End If

        End With
        gridView.Columns.Add(Field)
    End Sub

    Public Sub AppendHyLinkField(ByVal gridView As UI.WebControls.GridView, ByVal HeaderText As String, ByVal DataTextField As String, ByVal DataUrlField As String, Optional ByVal DataTextFormat As String = "", Optional ByVal DataUrlFormat As String = "", Optional ByVal hAlignment As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Width As String = "")
        AppendHyLinkField(gridView, _
                           HeaderText, DataTextField, _
                           New String() {DataUrlField}, _
                           DataTextFormat, DataUrlFormat, hAlignment, Width)
    End Sub

    Public Sub AppendHyLinkField(ByVal gridView As UI.WebControls.GridView, ByVal HeaderText As String, ByVal DataTextField As String, ByVal DataUrlFields() As String, Optional ByVal DataTextFormat As String = "", Optional ByVal DataUrlFormat As String = "", Optional ByVal hAlignment As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Width As String = "")
        Dim Field As New WebControls.HyperLinkField

        With Field
            .HeaderText = HeaderText
            .DataTextField = DataTextField
            .DataTextFormatString = DataTextFormat
            .DataNavigateUrlFields = DataUrlFields
            .DataNavigateUrlFormatString = DataUrlFormat

            .HeaderStyle.HorizontalAlign = hAlignment
            .ItemStyle.HorizontalAlign = hAlignment

            If Width <> "" Then
                .HeaderStyle.Width = Unit.Parse(Width)
                .ItemStyle.Width = Unit.Parse(Width)
            End If
        End With
        gridView.Columns.Add(Field)
    End Sub

    Public Sub AppendSelectField(ByVal gridView As UI.WebControls.GridView, ByVal HeaderText As String, ByVal DeleteIndexDataField As String, ByVal SelectionMode As ListSelectionMode, Optional ByVal hAlignment As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Width As String = "", Optional ByVal AllowSelectAll As Boolean = True)
        Dim Field As New SelectorField

        With Field
            .HeaderText = HeaderText
            .SelectionMode = SelectionMode
            .AllowSelectAll = AllowSelectAll
            .HeaderStyle.HorizontalAlign = hAlignment
            .ItemStyle.HorizontalAlign = hAlignment

            .HeaderStyle.CssClass = "GridSelectorCol"
            .ItemStyle.CssClass = "GridSelectorCol"

            If Width <> "" Then
                .HeaderStyle.Width = Unit.Parse(Width)
                .ItemStyle.Width = Unit.Parse(Width)
            Else
                '.HeaderStyle.Width = Unit.Parse("1px")
                '.ItemStyle.Width = Unit.Parse("1px")
            End If
        End With
        gridView.Columns.Add(Field)
        'put a hidden index field.
        AppendBoundField(gridView, "", DeleteIndexDataField, , 0)
    End Sub

    Public Function DisableInput(ByVal InputItem As UI.WebControls.WebControl) As Boolean
        InputItem.Attributes.Remove("readonly")
        InputItem.Style.Remove("background-color")
        InputItem.Attributes.Add("readonly", "readonly")
        InputItem.Style.Add("background-color", "whitesmoke")
        If TypeOf InputItem Is WebControls.DropDownList Then
            InputItem.Enabled = False
        End If
    End Function

    Public Function EnableInput(ByVal InputItem As UI.WebControls.WebControl) As Boolean
        InputItem.Enabled = True
        InputItem.Attributes.Remove("disabled")
        InputItem.Attributes.Remove("readonly")
        InputItem.Style.Remove("background-color")
    End Function

    Public Function FindRecursive(ByVal root As Control, ByVal id As String) As Control
        If root.ID = id Then
            Return root
        End If
        Dim c As Control
        For Each c In root.Controls
            Dim t As Control = FindRecursive(c, id)
            If Not t Is Nothing Then
                Return t
            End If
        Next
        Return Nothing
    End Function

#End Region

End Module


