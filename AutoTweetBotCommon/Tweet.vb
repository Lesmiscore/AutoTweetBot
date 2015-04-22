﻿Imports System.IO
Imports System.Drawing.Imaging
Imports System.Text

Public Class Tweet
    Dim additionalDic As New SortedDictionary(Of String, String)

    Public Shared Function Open() As Tweet()
        Dim tmp = Path.Combine(My.Application.Info.DirectoryPath, "Tweets")
        MakeFolder(tmp)
        Dim tm As New List(Of Tweet)
        For Each i In Directory.GetFiles(tmp)
            Dim pd = Parse(i)
            If pd Is Nothing Then
                Continue For
            End If
            tm.Add(pd)
        Next
        Return tm.ToArray
    End Function
    Public Shared ReadOnly Property SandBox As Tweet
        Get
            Return New Tweet(Date.Now)
        End Get
    End Property
    Private Shared Function Parse(s As String) As Tweet
        'Try
        Dim xd = XDocument.Parse(File.ReadAllText(s))
        Dim time = Date.Parse(xd.<Tweet>.<TimeStamp>.Value)
        Dim tm As New Tweet(time)
        Dim multiLine As Boolean = False
        Try
            multiLine = Boolean.Parse(xd.<Tweet>.<Text>.@multiLine)
        Catch ex As Exception
            multiLine = False
        End Try
        If multiLine Then
            Dim sb As New StringBuilder
            For Each i In xd.<Tweet>.<Text>.<Line>
                sb.AppendLine(i.Value)
            Next
            tm.text = sb.ToString
        Else
            tm.text = xd.<Tweet>.<Text>.Value
        End If
        tm.detectInfo = Path.GetFileNameWithoutExtension(s)
        For Each i In xd.<Tweet>.<Pictures>
            tm.AddPicture(Convert.FromBase64String(i.Value))
        Next
        Return tm
    End Function
    Protected Friend Shared Function ParsePlugin(s As String, factory As Func(Of Date, Tweet)) As Tweet
        'Try
        Dim xd = XDocument.Parse(File.ReadAllText(s))
        Dim time = Date.Parse(xd.<Tweet>.<TimeStamp>.Value)
        Dim tm As Tweet = factory(time)
        Dim multiLine As Boolean = False
        Try
            multiLine = Boolean.Parse(xd.<Tweet>.<Text>.@multiLine)
        Catch ex As Exception
            multiLine = False
        End Try
        If multiLine Then
            Dim sb As New StringBuilder
            For Each i In xd.<Tweet>.<Text>.<Line>
                sb.AppendLine(i.Value)
            Next
            tm.text = sb.ToString
        Else
            tm.text = xd.<Tweet>.<Text>.Value
        End If
        tm.detectInfo = Path.GetFileNameWithoutExtension(s)
        For Each i In xd.<Tweet>.<Pictures>
            tm.AddPicture(Convert.FromBase64String(i.Value))
        Next
        For Each i In xd.<Tweet>.<Additional>
            tm.additionalDic(i.Name.LocalName) = i.Value
        Next
        tm.LoadedAdditionalInfo(tm.additionalDic)
        Return tm
    End Function
    Public Overridable Sub SaveAdditionalInfo(dic As IDictionary(Of String, String))

    End Sub
    Public Overridable Sub LoadedAdditionalInfo(dic As IDictionary(Of String, String))

    End Sub
    Private Shared Sub MakeFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
    Private text, detectInfo As String
    Private time As Date
    Private pictures As List(Of Bitmap)
    Public Sub New(tweetTime As Date)
        pictures = New List(Of Bitmap)
        time = tweetTime
        text = ""
    End Sub
    Public Overridable Function Save() As Tweet
        Dim tmp = Path.Combine(My.Application.Info.DirectoryPath, "Tweets", InstanceSearchInfo) & ".xml"
        Dim parent = <Tweet></Tweet>
        Dim text = <Text></Text>
        If Me.text.Contains(vbLf) Then
            text.@multiLine = True
            Dim strd As New StringReader(Me.text)
            While True
                Dim s As String = strd.ReadLine()
                If s = Nothing Then
                    Exit While
                End If
                Dim line = <Line></Line>
                line.Value = s
                text.Add(line)
            End While
            strd.Close()
            strd.Dispose()
        Else
            text.@multiLine = False
            text.Value = Me.text
        End If
        parent.Add(text)
        Dim datei = <TimeStamp></TimeStamp>
        datei.Value = Me.time.ToString
        parent.Add(datei)
        If AvaliablePicture Then
            For Each i In pictures
                If i Is Nothing Then
                    Continue For
                End If
                Dim pn = <Pictures></Pictures>
                Dim ms As New MemoryStream
                i.Save(ms, ImageFormat.Png)
                pn.Value = Convert.ToBase64String(ms.ToArray)
                parent.Add(pn)
            Next
        End If
        Dim additional = <Additional></Additional>
        SaveAdditionalInfo(additionalDic)
        For Each i In additionalDic
            additional.Add((Function() As XElement
                                Dim s = "<" + i.Key + ">" + i.Value + "</" + i.Key + ">"
                                Dim n = XDocument.Parse(s).FirstNode
                                n.Remove()
                                Return n
                            End Function)())
        Next
        parent.Add(additional)
        MakeFolder(Path.GetDirectoryName(tmp))
        Using fs As New FileStream(tmp, FileMode.Create, FileAccess.Write)
            Using sr As New StreamWriter(fs, New UTF8Encoding, 8)
                parent.Save(sr)
            End Using
        End Using
        Return Me
    End Function
    Public Overridable Function CheckTimeAndTweet() As Tweet
        If time = Date.MinValue Then
            '無視
        ElseIf time < Date.Now Then
            Try
                Dim token = AccountAuthManager.GetAccount(True)
                Dim status = token.Statuses
                If Not AvaliablePicture Then
                    status.Update(New With {.status = ToSafeString(text)})
                Else
                    Dim ids As Long() = New Long(pictures.Count - 1) {}
                    For i = 0 To pictures.Count - 1
                        Dim files = Path.GetTempFileName
                        pictures(i).Save(files, ImageFormat.Png)
                        ids(i) = token.Media.Upload(New With {.media = files}).MediaId
                    Next
                    status.Update(New With {.status = ToSafeString(text), .media_ids = ids})
                End If
            Catch ex As Exception
                Console.WriteLine(ex.GetType.ToString)
                Console.WriteLine(ex.Message)
                Console.WriteLine(ex.StackTrace)
            End Try
            Delete()
        End If
        Return Me
    End Function
    Public Sub Delete()
        Dim tmp = Path.Combine(My.Application.Info.DirectoryPath, "Tweets", detectInfo) & ".xml"
        File.Delete(tmp)
    End Sub
    Public Function ToSafeString(s As String) As String
        Return s.Replace(vbCr, "")
    End Function
    Public Property TweetText As String
        Get
            Return text
        End Get
        Set(value As String)
            If ToSafeString(value).Length > 140 Then
                Throw New ArgumentException("テキストは140文字以内までです。")
            End If
            text = value
        End Set
    End Property
    Public Property TweetTime As Date
        Get
            Return time
        End Get
        Set(value As Date)
            time = value
        End Set
    End Property
    Public ReadOnly Property InstanceSearchInfo As String
        Get
            If detectInfo = Nothing OrElse detectInfo = "" OrElse detectInfo.Length <> 30 Then
                detectInfo = CreateISI()
            End If
            Return detectInfo
        End Get
    End Property
    Private Shared ReadOnly passwordChars As String = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Private Function CreateISI() As String
        Dim length = 30
        Dim sb As New System.Text.StringBuilder(length)
        Dim random() As Byte = New Byte(length - 1) {}
        'RNGCryptoServiceProviderクラスのインスタンスを作成
        Dim rng As New System.Security.Cryptography.RNGCryptoServiceProvider()
        rng.GetNonZeroBytes(random)
        For Each i In random
            sb.Append(passwordChars(i Mod passwordChars.Length))
        Next
        Return sb.ToString()
    End Function
    Public ReadOnly Property AvaliablePicture As Boolean
        Get
            Return pictures.Count <> 0
        End Get
    End Property
    Public Function AddPicture(path As String) As Tweet
        Return AddPicture(New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    End Function
    Public Function AddPicture(bytes As Byte()) As Tweet
        Return AddPicture(New MemoryStream(bytes, False))
    End Function
    Public Function AddPicture(stream As Stream) As Tweet
        Return AddPicture(Bitmap.FromStream(stream))
    End Function
    Public Function AddPicture(bmp As Bitmap) As Tweet
        pictures.Add(bmp)
        Return Me
    End Function
    Public Class NullTweetManager
        Inherits Tweet
        Public Sub New()
            MyBase.New(Date.Now)
        End Sub
        Public Overrides Function Save() As Tweet
            Return Me
        End Function
        Public Overrides Function CheckTimeAndTweet() As Tweet
            Return Me
        End Function
    End Class
End Class
