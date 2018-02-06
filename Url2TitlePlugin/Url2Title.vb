Imports OpenLiveWriter.Api
Imports System.Reflection
Imports System.Runtime.CompilerServices

<Assembly: CLSCompliant(False)>

<WriterPlugin("2d6b054f-27ae-48e1-ae18-78d76183e704", "Url2Title",
              Description:="Replaces a pasted URL with a title.",
              HasEditableOptions:=True, ImagePath:="Globe.ico", PublisherUrl:="https://github.com/olwplugins/url2title"),
 UrlContentSource(".+")>
Public Class Url2Title
    Inherits ContentSource


    Public Overrides Sub CreateContentFromUrl(ByVal url As String, ByRef title As String, ByRef newContent As String)

        If My.Computer.Keyboard.ShiftKeyDown Then
            title = url            
        End If

        If String.IsNullOrEmpty(title) Then
            If Not PluginHttpRequest.InternetConnectionAvailable Then
                title = url
            Else
                title = GetTitleFromUrl(url)
            End If
        End If

        Dim template = Options.GetString(Url2TitleOptions.Template.Name, Url2TitleOptions.Template.DefaultValue)
        newContent = template.Replace("{url}", url).Replace("{title}", title)

    End Sub

    Public Overrides Sub EditOptions(ByVal dialogOwner As System.Windows.Forms.IWin32Window)

        Dim frm = New OptionForm With { _
            .Template = Options.GetString(Url2TitleOptions.Template.Name, Url2TitleOptions.Template.DefaultValue), _
            .TimeOut = Options.GetInt(Url2TitleOptions.Timeout.Name, Url2TitleOptions.Timeout.DefaultValue), _
            .Extensions = Options.GetString(Url2TitleOptions.Extensions.Name, Url2TitleOptions.Extensions.DefaultValue)}

        If frm.ShowDialog(dialogOwner) = Windows.Forms.DialogResult.OK Then
            Options.SetString(Url2TitleOptions.Template.Name, frm.Template)
            Options.SetInt(Url2TitleOptions.Timeout.Name, frm.TimeOut)
            Options.SetString(Url2TitleOptions.Extensions.Name, frm.Extensions)
        End If
        frm.Dispose()

    End Sub

    Private Function GetTitleFromUrl(ByVal url As String) As String

        Dim request As PluginHttpRequest
        Dim reader As System.IO.BinaryReader = Nothing
        Dim title = url

        Dim exts = Options.GetString(Url2TitleOptions.Extensions.Name, Url2TitleOptions.Extensions.DefaultValue).Split(","c)
        For Each ext In exts
            If url.EndsWith("." & ext.Trim) Then
                Return url
            End If
        Next

        Try
            request = New PluginHttpRequest(url)
            request.AllowAutoRedirect = False

            Dim timeout = Options.GetInt(Url2TitleOptions.Timeout.Name, Url2TitleOptions.Timeout.DefaultValue) * 1000

            If timeout = 0 Then
                reader = New System.IO.BinaryReader(request.GetResponse)
            Else
                reader = New System.IO.BinaryReader(request.GetResponse(timeout))
            End If

            Dim buffer = reader.ReadBytes(50000)
            Dim html = GetCode(buffer).GetString(buffer)

            Const openTag As String = "<title"
            Const closeTag As String = "</title>"

            Dim pos1 = html.IndexOf(openTag, StringComparison.CurrentCultureIgnoreCase)
            If pos1 < 0 Then
                Return url
            End If
            Dim pos2 = html.IndexOf(closeTag, pos1 + openTag.Length, StringComparison.CurrentCultureIgnoreCase)
            If pos2 < 0 Then
                Return url
            End If

            html = html.Substring(pos1, pos2 - pos1 + closeTag.Length)

            Dim match = System.Text.RegularExpressions.Regex.Match(html.Replace(vbCr, "").Replace(vbLf, ""), "^<title.*>(.*?)</title>$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If match.Success Then
                title = match.Groups(1).Value.Trim
            End If

        Catch ex As Exception
            ' Ignore
#If DEBUG Then
            System.Windows.Forms.MessageBox.Show(ex.ToString)
#End If
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try

        Return title

    End Function

#Region "From http://dobon.net/vb/dotnet/string/detectcode.html"

    ''' <summary>
    ''' 文字コードを判別する
    ''' </summary>
    ''' <remarks>
    ''' Jcode.pmのgetcodeメソッドを移植したものです。
    ''' Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
    ''' Jcode.pmのCopyright : Copyright 1999 Dan Kogai.
    ''' </remarks>
    ''' <param name="byts">文字コードを調べるデータ</param>
    ''' <returns>適当と思われるEncodingオブジェクト。
    ''' 判断できなかった時はnull。</returns>
    Public Shared Function GetCode(ByVal byts() As Byte) As System.Text.Encoding
        Const bESC As Byte = &H1B
        Const bAT As Byte = &H40
        Const bDollar As Byte = &H24
        Const bAnd As Byte = &H26
        Const bOP As Byte = &H28 '(
        Const bB As Byte = &H42
        Const bD As Byte = &H44
        Const bJ As Byte = &H4A
        Const bI As Byte = &H49

        Dim len As Integer = byts.Length
        Dim [binary] As Integer = 0
        Dim ucs2 As Integer = 0
        Dim sjis As Integer = 0
        Dim euc As Integer = 0
        Dim utf8 As Integer = 0
        Dim b1, b2 As Byte

        Dim i As Integer
        For i = 0 To len - 1
            If byts(i) <= &H6 OrElse byts(i) = &H7F OrElse byts(i) = &HFF Then
                ''binary'
                [binary] += 1
                If len - 1 > i AndAlso byts(i) = &H0 AndAlso _
                i > 0 AndAlso byts(i - 1) <= &H7F Then
                    'smells like raw unicode
                    ucs2 += 1
                End If
            End If
        Next i

        If [binary] > 0 Then
            If ucs2 > 0 Then
                'JIS
                'ucs2(Unicode)
                Return System.Text.Encoding.Unicode
                'binary
            Else
                Return Nothing
            End If
        End If

        For i = 0 To len - 2
            b1 = byts(i)
            b2 = byts(i + 1)

            If b1 = bESC Then
                If b2 >= &H80 Then
                    'not Japanese
                    'ASCII
                    Return System.Text.Encoding.ASCII
                Else
                    If len - 2 > i AndAlso _
                    b2 = bDollar AndAlso byts(i + 2) = bAT Then
                        'JIS_0208 1978
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    ElseIf len - 2 > i AndAlso _
                    b2 = bDollar AndAlso byts(i + 2) = bB Then
                        'JIS_0208 1983
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    ElseIf len - 5 > i AndAlso _
                    b2 = bAnd AndAlso byts(i + 2) = bAT AndAlso _
                    byts(i + 3) = bESC AndAlso byts(i + 4) = bDollar AndAlso _
                    byts((i + 5)) = bB Then
                        'JIS_0208 1990
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    ElseIf len - 3 > i AndAlso _
                    b2 = bDollar AndAlso byts(i + 2) = bOP AndAlso _
                    byts(i + 3) = bD Then
                        'JIS_0212
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    ElseIf len - 2 > i AndAlso b2 = bOP AndAlso _
                    (byts(i + 2) = bB OrElse byts(i + 2) = bJ) Then
                        'JIS_ASC
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    ElseIf len - 2 > i AndAlso _
                    b2 = bOP AndAlso byts(i + 2) = bI Then
                        'JIS_KANA
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    End If
                End If
            End If
        Next i

        For i = 0 To len - 2
            b1 = byts(i)
            b2 = byts(i + 1)
            If ((b1 >= &H81 AndAlso b1 <= &H9F) OrElse _
            (b1 >= &HE0 AndAlso b1 <= &HFC)) AndAlso _
            ((b2 >= &H40 AndAlso b2 <= &H7E) OrElse _
            (b2 >= &H80 AndAlso b2 <= &HFC)) Then
                sjis += 2
                i += 1
            End If
        Next i

        For i = 0 To len - 2
            b1 = byts(i)
            b2 = byts(i + 1)
            If ((b1 >= &HA1 AndAlso b1 <= &HFE) AndAlso _
            (b2 >= &HA1 AndAlso b2 <= &HFE)) OrElse _
            (b1 = &H8E AndAlso (b2 >= &HA1 AndAlso b2 <= &HDF)) Then
                euc += 2
                i += 1
            ElseIf len - 2 > i AndAlso b1 = &H8F AndAlso _
            (b2 >= &HA1 AndAlso b2 <= &HFE) AndAlso _
            (byts(i + 2) >= &HA1 AndAlso byts(i + 2) <= &HFE) Then
                euc += 3
                i += 2
            End If
        Next i

        For i = 0 To len - 2
            b1 = byts(i)
            b2 = byts(i + 1)
            If (b1 >= &HC0 AndAlso b1 <= &HDF) AndAlso _
            (b2 >= &H80 AndAlso b2 <= &HBF) Then
                utf8 += 2
                i += 1
            ElseIf len - 2 > i AndAlso _
            (b1 >= &HE0 AndAlso b1 <= &HEF) AndAlso _
            (b2 >= &H80 AndAlso b2 <= &HBF) AndAlso _
            (byts(i + 2) >= &H80 AndAlso byts(i + 2) <= &HBF) Then
                utf8 += 3
                i += 2
            End If
        Next i

        If euc > sjis AndAlso euc > utf8 Then
            'EUC
            Return System.Text.Encoding.GetEncoding(51932)
        ElseIf sjis > euc AndAlso sjis > utf8 Then
            'SJIS
            Return System.Text.Encoding.GetEncoding(932)
        ElseIf utf8 > euc AndAlso utf8 > sjis Then
            'UTF8
            Return System.Text.Encoding.UTF8
        End If

        'Return Nothing
        Return System.Text.Encoding.UTF8

    End Function

#End Region

    Public NotInheritable Class Url2TitleOptions
        Public Shared ReadOnly Template As New Item(Of String)("<a href=""{url}"">{title}</a>")
        Public Shared ReadOnly Timeout As New Item(Of Integer)(15)
        Public Shared ReadOnly Extensions As New Item(Of String)("zip,lzh,rar,cab,pdf,mp3,wma,wmv,avi,mov,swf,png,jpeg,jpg,gif,bmp,ico")

        Public NotInheritable Class Item(Of T)
            Private _name As String
            Public ReadOnly Property Name() As String
                Get
                    Return _name
                End Get
            End Property

            Private _defaultValue As T
            Public ReadOnly Property DefaultValue() As T
                Get
                    Return _defaultValue
                End Get
            End Property

            Public Sub New(ByVal defaultValue As T)
                _defaultValue = defaultValue
            End Sub

            Public Overrides Function ToString() As String
                Return _name
            End Function
        End Class

        Shared Sub New()
            Dim fieldsInfo = GetType(Url2TitleOptions).GetFields( _
                BindingFlags.DeclaredOnly Or _
                BindingFlags.GetField Or _
                BindingFlags.Instance Or _
                BindingFlags.Public Or _
                BindingFlags.Static Or _
                BindingFlags.FlattenHierarchy)

            For Each info In fieldsInfo
                Dim item = info.GetValue(Nothing)
                item.GetType.InvokeMember( _
                    "_name", _
                    BindingFlags.SetField Or BindingFlags.NonPublic Or BindingFlags.Instance, _
                    Nothing, _
                    item, _
                    New Object() {info.Name}, _
                    Nothing, Nothing, Nothing)
            Next
        End Sub
    End Class

End Class
