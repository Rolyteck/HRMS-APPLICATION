Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Scanner
    Inherits System.Web.UI.UserControl

    Protected PostedFile As HttpPostedFile

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Me.File1.Value = "***"

        If Page.IsPostBack And Request.Files.Count > 0 Then 'on upload
            Dim SavePath As String = "photos/" & Guid.NewGuid.ToString
            Request.Files(0).SaveAs(Server.MapPath(SavePath))
            Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & SavePath
        End If

        If Not Page.IsPostBack Then
            Me.File1.Attributes.Add("onpropertychange", "SlamPix('" & Me.Image1.ClientID & "', '" & Me.File1.UniqueID & "');")
        End If
    End Sub

    Public Sub ShowPhoto(ByVal Photo As System.Drawing.Image, ByVal PolicyNo As String)
        Try
            Dim TempFile As String = "photos/" & Replace(PolicyNo, "/", "") & ".bmp"
            Photo.Save(Server.MapPath(TempFile))
            Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & TempFile

        Catch
            Dim TempFile As String = "photos/error.bmp"
            Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & TempFile
            Me.Image1.Src = ""
        End Try
        Me.File1.Visible = False
    End Sub

    Public Sub ShowPhoto3(ByVal PolicyNo As String)
        'Try
        '    Dim TempFile As String = "photos/" & Replace(PolicyNo, "/", "") & ".bmp"
        '    Photo.Save(Server.MapPath(TempFile))
        '    Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & TempFile

        'Catch
        '    Dim TempFile As String = "photos/error.bmp"
        '    Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & TempFile
        Me.Image1.Src = ""

        'End Try
        'Me.File1.Visible = False
    End Sub

    Public Function GetPhotoAsByteArray() As Byte()
        Try
            If Request.Files.Count > 0 Then 'on upload
                Dim SavePath As String = Server.MapPath("photos/" & Guid.NewGuid.ToString)
                Request.Files(0).SaveAs(SavePath)

                Dim ms As New IO.MemoryStream
                Dim img As Drawing.Image = Drawing.Image.FromFile(SavePath)
                img.Save(ms, Imaging.ImageFormat.Jpeg)
                img.Dispose()
                IO.File.Delete(SavePath)
                Return ms.ToArray
            Else
                Dim B(-1) As Byte
                Return B
            End If
        Catch
            Dim B(-1) As Byte
            Return B
        End Try
    End Function


    Public Sub ShowPhoto2(ByVal Photo As System.Drawing.Image, ByVal PolicyNo As String)
        Try
            Dim TempFile As String = "photos/" & Replace(PolicyNo, "/", "") & ".bmp"
            Photo.Save(Server.MapPath(TempFile))
            Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & TempFile
        Catch
            Dim TempFile As String = "photos/error.bmp"
            Me.Image1.Src = Left(Request.Url.AbsolutePath, Request.Url.AbsolutePath.LastIndexOf("/") + 1) & TempFile
        End Try

        Me.File1.Visible = True
    End Sub
    'Public Function GetPhotoAsByteArrayUpdate() As Byte()
    '    Try
    '        If Request.Files.Count > 0 Then 'on upload
    '            Dim SavePath As String = Server.MapPath("photos/" & Guid.NewGuid.ToString)
    '            Request.Files(0).SaveAs(SavePath)

    '            Dim ms As New IO.MemoryStream
    '            Dim img As Drawing.Image = Drawing.Image.FromFile(SavePath)
    '            img.Save(ms, Imaging.ImageFormat.Jpeg)
    '            img.Dispose()
    '            IO.File.Delete(SavePath)
    '            Return ms.ToArray
    '        Else
    '            Dim B(-1) As Byte
    '            Return B
    '            'length is 0
    '        End If
    '    Catch
    '        Dim B(-1) As Byte
    '        Return B
    '    End Try
    'End Function

    Public Function GetPhotoAsByteArrayUpdate() As Byte()
        Try
            If Request.Files.Count > 0 Then 'on upload
                Dim SavePath As String = Server.MapPath("photos/" & Guid.NewGuid.ToString)
                Request.Files(0).SaveAs(SavePath)

                Dim ms As New IO.MemoryStream
                Dim img As Drawing.Image = Drawing.Image.FromFile(SavePath)
                img.Save(ms, Imaging.ImageFormat.Jpeg)
                img.Dispose()
                IO.File.Delete(SavePath)
                Return ms.ToArray
            Else
                Dim B(-1) As Byte
                Return B
                'length is 0
            End If
        Catch
            Dim B(-1) As Byte
            Return B
        End Try
    End Function

    Public Property Width() As Long
        Get
            Return Me.Image1.Width
        End Get
        Set(ByVal value As Long)
            Me.Image1.Width = value
        End Set
    End Property

    Public Property Height() As Long
        Get
            Return Me.Image1.Height
        End Get
        Set(ByVal value As Long)
            Me.Image1.Height = value
        End Set
    End Property
End Class
