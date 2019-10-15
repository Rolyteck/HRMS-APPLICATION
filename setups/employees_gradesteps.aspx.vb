Partial Class employees_gradesteps_Index_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            GetNextPageMessage(Me.Msgbox1)
        End If
    End Sub

    Protected Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim gridView As GridView = Me.gridarea1.GridView
        Dim PryKey As String, Count As Integer = 0, Err As String = ""

        For Each r As GridViewRow In gridView.Rows
            If CType(r.Cells(0).Controls(0), SelectorField.SelectorFieldCheckBox).Checked Then
                PryKey = r.Cells(1).Text
                'do work here...
                Dim res As ResponseInfo = (New cls_Hrsteps).Delete(PryKey)
                If res.ErrorCode = 0 Then
                    Count += res.TotalSuccess
                Else
                    Err &= "<br>" & res.ErrorMessage
                End If
            End If
        Next

        Me.Msgbox1.ShowInfo(Count & " items(s) deleted! " & Err)
        gridView.DataBind()
        Response.Redirect(Me.Request.Path & "?" & mod_main.getQueryString)

    End Sub

    Protected Sub cmdNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Response.Redirect("employees_gradesteps_new.aspx?" & Request.QueryString.ToString)
    End Sub
End Class