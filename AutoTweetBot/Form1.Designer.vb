<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AutoTweetList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MakeReservation = New System.Windows.Forms.Button()
        Me.EditReservation = New System.Windows.Forms.Button()
        Me.TweetWorker = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.WorkerStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ClockBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.DeleteReservation = New System.Windows.Forms.Button()
        Me.StatusNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AutoTweetList
        '
        Me.AutoTweetList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AutoTweetList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.AutoTweetList.Location = New System.Drawing.Point(13, 42)
        Me.AutoTweetList.MultiSelect = False
        Me.AutoTweetList.Name = "AutoTweetList"
        Me.AutoTweetList.Size = New System.Drawing.Size(417, 282)
        Me.AutoTweetList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.AutoTweetList.TabIndex = 0
        Me.AutoTweetList.UseCompatibleStateImageBehavior = False
        Me.AutoTweetList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "テキスト"
        Me.ColumnHeader1.Width = 160
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ツイート時間"
        Me.ColumnHeader2.Width = 77
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "画像の有無"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "内部識別ID"
        Me.ColumnHeader4.Width = 0
        '
        'MakeReservation
        '
        Me.MakeReservation.Location = New System.Drawing.Point(12, 13)
        Me.MakeReservation.Name = "MakeReservation"
        Me.MakeReservation.Size = New System.Drawing.Size(75, 23)
        Me.MakeReservation.TabIndex = 1
        Me.MakeReservation.Text = "新規"
        Me.MakeReservation.UseVisualStyleBackColor = True
        '
        'EditReservation
        '
        Me.EditReservation.Location = New System.Drawing.Point(93, 13)
        Me.EditReservation.Name = "EditReservation"
        Me.EditReservation.Size = New System.Drawing.Size(75, 23)
        Me.EditReservation.TabIndex = 2
        Me.EditReservation.Text = "編集"
        Me.EditReservation.UseVisualStyleBackColor = True
        '
        'TweetWorker
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WorkerStatus, Me.ClockBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 327)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(442, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'WorkerStatus
        '
        Me.WorkerStatus.Name = "WorkerStatus"
        Me.WorkerStatus.Size = New System.Drawing.Size(75, 17)
        Me.WorkerStatus.Text = "認証中です..."
        '
        'ClockBar
        '
        Me.ClockBar.Maximum = 59
        Me.ClockBar.Name = "ClockBar"
        Me.ClockBar.Size = New System.Drawing.Size(100, 16)
        Me.ClockBar.Step = 0
        '
        'DeleteReservation
        '
        Me.DeleteReservation.Location = New System.Drawing.Point(174, 12)
        Me.DeleteReservation.Name = "DeleteReservation"
        Me.DeleteReservation.Size = New System.Drawing.Size(75, 23)
        Me.DeleteReservation.TabIndex = 4
        Me.DeleteReservation.Text = "削除"
        Me.DeleteReservation.UseVisualStyleBackColor = True
        '
        'StatusNotifyIcon
        '
        Me.StatusNotifyIcon.Visible = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 349)
        Me.Controls.Add(Me.DeleteReservation)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.EditReservation)
        Me.Controls.Add(Me.MakeReservation)
        Me.Controls.Add(Me.AutoTweetList)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "自動ツイートBOT"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AutoTweetList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MakeReservation As System.Windows.Forms.Button
    Friend WithEvents EditReservation As System.Windows.Forms.Button
    Friend WithEvents TweetWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents WorkerStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ClockBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DeleteReservation As System.Windows.Forms.Button
    Friend WithEvents StatusNotifyIcon As System.Windows.Forms.NotifyIcon

End Class
