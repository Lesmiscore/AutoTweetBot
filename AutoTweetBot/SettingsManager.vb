Imports System.IO
Imports System.Text

Public Class SettingsManager
    Shared temp As SettingsManager
    Dim avaliableSettingsInfo, startUp As Boolean
    Dim authKey, authSecret As String
    Shared spath As String = Path.Combine(My.Application.Info.DirectoryPath, "ATB_Settings.xml")
    Public Shared Function Open() As SettingsManager
        If temp IsNot Nothing Then
            Return temp
        End If
        Dim r As New SettingsManager
        If Not File.Exists(spath) Then
            r.avaliableSettingsInfo = False
            Dim parent = <AutoTweetBot></AutoTweetBot>
            parent.Add(<IsAuthencated>False</IsAuthencated>, <DidSetStartup>False</DidSetStartup>, <AuthencateKey></AuthencateKey>, <AuthencateKeySecret></AuthencateKeySecret>)
            Using fs As New FileStream(spath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)
                Using sr As New StreamWriter(fs, New UTF8Encoding)
                    parent.Save(sr)
                End Using
            End Using
        Else
            Dim xd As XDocument = XDocument.Load(New StreamReader(New MemoryStream(File.ReadAllBytes(spath), False)))
            'xd = RepairXml(xd)
            r.avaliableSettingsInfo = Boolean.Parse(xd.<AutoTweetBot>.<IsAuthencated>.Value)
            r.startUp = Boolean.Parse(xd.<AutoTweetBot>.<DidSetStartup>.Value)
            r.authKey = xd.<AutoTweetBot>.<AuthencateKey>.Value
            r.authSecret = xd.<AutoTweetBot>.<AuthencateKeySecret>.Value
        End If
        Return r
    End Function
    Private Sub New()

    End Sub
    Private Shared Function RepairXml(xd As XDocument) As XDocument
        Try
            Dim s = xd.<AutoTweetBot>.<DidSetStartup>.Count
            If s <= 0 Then
                xd.Add(<DidSetStartup>False</DidSetStartup>)
            End If
        Catch ex As Exception
            xd.Add(<DidSetStartup>False</DidSetStartup>)
        End Try
        Return xd
    End Function
    Public Sub Commit()
        Dim parent = <AutoTweetBot></AutoTweetBot>
        Dim isauth = <IsAuthencated></IsAuthencated>
        Dim didsetsu = <DidSetStartup></DidSetStartup>
        Dim authKey = <AuthencateKey></AuthencateKey>
        Dim authSecret = <AuthencateKeySecret></AuthencateKeySecret>
        isauth.Value = avaliableSettingsInfo
        didsetsu.Value = startUp
        authKey.Value = Me.authKey
        authSecret.Value = Me.authSecret
        parent.Add(isauth)
        parent.Add(didsetsu)
        parent.Add(authKey)
        parent.Add(authSecret)
        Using fs As New FileStream(spath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)
            Using sr As New StreamWriter(fs, New UTF8Encoding)
                parent.Save(sr)
            End Using
        End Using
    End Sub
    Public Shared Sub Commit(Optional o As SettingsManager = Nothing)
        o = IIf(o Is Nothing, Open, o)
        o.Commit()
    End Sub
    Public Property IsAuthencated As Boolean
        Get
            Return avaliableSettingsInfo
        End Get
        Set(value As Boolean)
            avaliableSettingsInfo = value
        End Set
    End Property
    Public Property DidSetStartup As Boolean
        Get
            Return startUp
        End Get
        Set(value As Boolean)
            startUp = value
        End Set
    End Property
    Public Property AuthencateKey As String
        Get
            Return authKey
        End Get
        Set(value As String)
            authKey = value
        End Set
    End Property
    Public Property AuthencateKeySecret As String
        Get
            Return authSecret
        End Get
        Set(value As String)
            authSecret = value
        End Set
    End Property
End Class
