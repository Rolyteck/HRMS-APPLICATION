Partial Class welcome_default_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        'dont edit this page, edit the welcome page shown below
        If File.Exists(Server.MapPath(settings.PATH_TO_GIBS_HOME_PAGE)) Then
            Server.Transfer(settings.PATH_TO_GIBS_HOME_PAGE, True)
        Else
            'show this one
        End If
    End Sub
End Class


