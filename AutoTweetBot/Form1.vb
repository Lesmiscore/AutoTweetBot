Imports System.Threading
Imports System.Windows

Public Class Form1
    Dim arr As TweetManager()
    Dim startUpMode As Boolean = False
    Dim hidden As Boolean = False
    Dim checked As Boolean = False
    Dim botName As ToolStripItem
    Dim wkState As ToolStripItem
    Dim hideOrShow As ToolStripItem
    Dim switchExperimental As ToolStripItem
    Dim experimental As Boolean = False
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        HideForm()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.CommandLine.Contains("Princessin") Then
            HideForm()
            startUpMode = True
        End If
        If Environment.CommandLine.Contains("Experimental") Then
            experimental = True
        End If
        AccountAuthManager.GetAccount(True)
        'TweetWorker.RunWorkerAsync()
        StartTimer()
        UpdateQueue()
        StatusNotifyIcon.Icon = My.Resources.ImgTimer
        StatusNotifyIcon.ContextMenuStrip = New ContextMenuStrip
        botName = StatusNotifyIcon.ContextMenuStrip.Items.Add("自動ツイートBOT")
        wkState = StatusNotifyIcon.ContextMenuStrip.Items.Add("")
        hideOrShow = StatusNotifyIcon.ContextMenuStrip.Items.Add("隠す", Nothing, Sub()
                                                                                    If hidden Then
                                                                                        ShowForm()
                                                                                        hideOrShow.Text = "隠す"
                                                                                    Else
                                                                                        HideForm()
                                                                                        hideOrShow.Text = "表示"
                                                                                    End If
                                                                                End Sub)
        If Not startUpMode Then
            StatusNotifyIcon.ContextMenuStrip.Items.Add("スタートアップに登録", Nothing, Sub()
                                                                                   SetCurrentVersionRun()
                                                                               End Sub)
        End If
        If experimental Then
            switchExperimental = StatusNotifyIcon.ContextMenuStrip.Items.Add("試験運用モード" & IIf(experimental, "OFF", "ON"), Nothing, Sub()
                                                                                                                                      experimental = Not experimental
                                                                                                                                      switchExperimental.Text = "試験運用モード" & IIf(experimental, "OFF", "ON")
                                                                                                                                  End Sub)
        End If
        StatusNotifyIcon.ContextMenuStrip.Items.Add("終了", Nothing, Sub()
                                                                       If MessageBox.Show("本当に閉じますか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                                                           Application.Exit()
                                                                           Me.Dispose()
                                                                       End If
                                                                   End Sub)

    End Sub
    Public Shared Sub SetCurrentVersionRun()
        Try
            'Runキーを開く
            Dim regkey As Microsoft.Win32.RegistryKey = _
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey( _
                "Software\Microsoft\Windows\CurrentVersion\Run", True)
            '値の名前に製品名、値のデータに実行ファイルのパスを指定し、書き込む
            regkey.SetValue(Application.ProductName, """" & Application.ExecutablePath & """ ""Princessin""" & IIf(Form1.experimental, " ""Experimental""", ""))
            '閉じる
            regkey.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub HideForm()
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
        Me.Visible = False
        hidden = True
    End Sub
    Public Sub ShowForm()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Visible = True
        hidden = False
    End Sub
    Private Sub UpdateQueue()
        arr = (From i In TweetManager.Open Where i IsNot Nothing).ToArray
        Invoke(Sub()
                   AutoTweetList.Items.Clear()
               End Sub)
        For Each i In arr
            If i Is Nothing Then
                Continue For
            End If
            Invoke(Sub()
                       AutoTweetList.Items.Add(New ListViewItem({i.TweetText, i.TweetTime.ToString, i.AvaliablePicture, i.InstanceSearchInfo}))
                   End Sub)
        Next
    End Sub
    Public Sub SetState(s As String)
        Invoke(Sub()
                   WorkerStatus.Text = s
                   StatusNotifyIcon.Text = "自動ツイートBOT - " & s
                   wkState.Text = s
               End Sub)
    End Sub
    Public Sub SetSeconds(s As Integer)
        Invoke(Sub()
                   ClockBar.Value = s
               End Sub)
    End Sub
    Private Sub TweetWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles TweetWorker.DoWork
        StartTimer()
    End Sub
    Private Sub StartTimer()
        Dim t As New Forms.Timer
        AddHandler t.Tick, Async Sub(sender_ As Object, e_ As EventArgs)
                               Await Task.Run(Sub()
                                                  If experimental Then
                                                      If checked Then
                                                          SetState("ツイートを処理しています。")
                                                          Try
                                                              For Each i In arr
                                                                  If i Is Nothing Then
                                                                      Continue For
                                                                  Else
                                                                      i.CheckTimeAndTweet()
                                                                  End If
                                                              Next
                                                          Catch
                                                          End Try
                                                      Else
                                                          SetState("次の0秒まで待機しています。")
                                                      End If
                                                      checked = Not checked
                                                  Else
                                                      If Date.Now.Second = 0 Then
                                                          If checked Then
                                                              SetState("ツイートを処理しています。")
                                                              Try
                                                                  For Each i In arr
                                                                      If i Is Nothing Then
                                                                          Continue For
                                                                      Else
                                                                          i.CheckTimeAndTweet()
                                                                      End If
                                                                  Next
                                                              Catch
                                                              End Try
                                                              checked = False
                                                          Else
                                                              SetState("次の0秒まで待機しています。")
                                                          End If
                                                      ElseIf Date.Now.Second = 59 Then
                                                          SetState("お待ち下さい。")
                                                          UpdateQueue()
                                                          checked = True
                                                      Else
                                                          SetState("次の0秒まで待機しています。")
                                                      End If
                                                  End If
                                                  SetSeconds(Date.Now.Second)
                                              End Sub)
                           End Sub
        t.Interval = 500
        t.Start()
    End Sub
    Private Sub TweetWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles TweetWorker.RunWorkerCompleted
        TweetWorker.RunWorkerAsync()
    End Sub
    Private Sub MakeReservation_Click(sender As Object, e As EventArgs) Handles MakeReservation.Click
        TweetManagerEditorGUI.StartEdit(TweetManager.SandBox).Save()
        UpdateQueue()
    End Sub
    Private Sub EditReservation_Click(sender As Object, e As EventArgs) Handles EditReservation.Click
        Dim item As ListViewItem
        Try
            item = AutoTweetList.SelectedItems(0)
        Catch
            MessageBox.Show("項目を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
        Dim isi = item.SubItems(3).Text
        Dim tm As TweetManager = Nothing
        For Each i In arr
            If i.InstanceSearchInfo = isi Then
                tm = i
            End If
        Next
        TweetManagerEditorGUI.StartEdit(tm).Save()
        UpdateQueue()
    End Sub
    Private Sub DeleteReservation_Click(sender As Object, e As EventArgs) Handles DeleteReservation.Click
        Dim item As ListViewItem
        Try
            item = AutoTweetList.SelectedItems(0)
        Catch
            MessageBox.Show("項目を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
        Dim isi = item.SubItems(3).Text
        Dim tm As TweetManager = Nothing
        For Each i In arr
            If i.InstanceSearchInfo = isi Then
                tm = i
            End If
        Next
        tm.Delete()
        UpdateQueue()
    End Sub
    Private Sub StatusNotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles StatusNotifyIcon.MouseDoubleClick
        ShowForm()
    End Sub
    Protected Friend ReadOnly Property ExperientalMode As Boolean
        Get
            Return experimental
        End Get
    End Property
End Class
