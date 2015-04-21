Public Class TweetManagerEditorGUI
    Dim tm As TweetManager
    Private Sub TweetManagerEditorGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tm Is Nothing Then
            Return
        End If
        TweetTextBox.Text = tm.TweetText
        TweetDatePicker.Value = tm.TweetTime
        TweetTimePicker.Value = tm.TweetTime
    End Sub
    Public Function StartEdit(Optional ByRef tm As TweetManager = Nothing) As TweetManager
        Me.tm = tm
        Me.ShowDialog()
        tm = Me.tm
        Return Me.tm
    End Function
    Private Sub TweetTextBox_TextChanged(sender As Object, e As EventArgs) Handles TweetTextBox.TextChanged
        TextLength.Text = IIf(TTl.Length = 0, "空白にはできません。", IIf(TTl.Length < 140, "あと" & (140 - TTl.Length) & "文字入力できます", IIf(TTl.Length = 140, "もう入力できません", "あと" & (TTl.Length - 140) & "文字消してください")))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SubmitTweet.Click
        If TTl.Length >= 140 Then
            MessageBox.Show("あと" & (TTl.Length - 140) & "文字消してください" & vbCrLf & "これではツイートできません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If TTl.Length = 0 Then
            MessageBox.Show("テキストを空白にはできません。" & vbCrLf & "これではツイートできません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim date_ As Date = TweetDatePicker.Value
        Dim time_ As Date = TweetTimePicker.Value
        Dim tt As Date = New Date(date_.Year, date_.Month, date_.Day, time_.Hour, time_.Minute, 0)
        If tm Is Nothing Then
            tm = New TweetManager(tt)
        Else
            tm.TweetTime = tt
        End If
        tm.TweetText = TweetTextBox.Text
        Me.Close()
    End Sub
    Public Function ToSafeString(s As String) As String
        Return s.Replace(vbCr, "")
    End Function
    Public Function TTl() As String
        Return ToSafeString(TweetTextBox.Text)
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles DestroyTweet.Click
        tm = New TweetManager.NullTweetManager.NullTweetManager()
        Me.Close()
    End Sub
End Class