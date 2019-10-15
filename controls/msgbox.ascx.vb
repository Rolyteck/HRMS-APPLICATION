Partial Class msgbox
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim PanelID As String = Me.PanelError.ClientID
        'Me.HyperLink1.Attributes.Add("onclick", "$get('" & PanelID & "').style.display='none';")
    End Sub

    Public WriteOnly Property HelpText() As String
        Set(ByVal value As String)
            Me.Literal2.Text = value
            Me.PanelHelp.Visible = True
        End Set
    End Property

    Public Sub ShowHelp(ByVal Message As String)
        Me.PanelHelp.Visible = True
        Me.PanelError.Visible = False
        Me.Literal2.Text = Message
    End Sub

    Public Sub ShowError(ByVal Message As String)
        Me.PanelHelp.Visible = False
        Me.PanelError.Visible = True
        Me.Literal1.Text = Message
        Me.PanelError.CssClass = "msgboxError"
    End Sub

    Public Sub ShowInfo(ByVal Message As String)
        Me.PanelHelp.Visible = False
        Me.PanelError.Visible = True
        Me.Literal1.Text = Message
        Me.PanelError.CssClass = "msgboxInfo"
    End Sub

    Public Sub Hide()
        Me.PanelHelp.Visible = False
        Me.PanelError.Visible = False
    End Sub
End Class