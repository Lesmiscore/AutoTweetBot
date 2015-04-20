<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TweetManagerEditorGUI
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TweetTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TweetDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.SubmitTweet = New System.Windows.Forms.Button()
        Me.DestroyTweet = New System.Windows.Forms.Button()
        Me.TextLength = New System.Windows.Forms.Label()
        Me.TweetTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "テキスト"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TweetTextBox, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TweetDatePicker, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.SubmitTweet, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.DestroyTweet, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextLength, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TweetTimePicker, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(422, 376)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TweetTextBox
        '
        Me.TweetTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TweetTextBox.Location = New System.Drawing.Point(3, 23)
        Me.TweetTextBox.Multiline = True
        Me.TweetTextBox.Name = "TweetTextBox"
        Me.TableLayoutPanel1.SetRowSpan(Me.TweetTextBox, 2)
        Me.TweetTextBox.Size = New System.Drawing.Size(205, 300)
        Me.TweetTextBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "時間指定"
        '
        'TweetDatePicker
        '
        Me.TweetDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TweetDatePicker.Location = New System.Drawing.Point(214, 23)
        Me.TweetDatePicker.Name = "TweetDatePicker"
        Me.TweetDatePicker.Size = New System.Drawing.Size(205, 19)
        Me.TweetDatePicker.TabIndex = 3
        '
        'SubmitTweet
        '
        Me.SubmitTweet.Location = New System.Drawing.Point(3, 349)
        Me.SubmitTweet.Name = "SubmitTweet"
        Me.SubmitTweet.Size = New System.Drawing.Size(75, 23)
        Me.SubmitTweet.TabIndex = 4
        Me.SubmitTweet.Text = "適用/保存"
        Me.SubmitTweet.UseVisualStyleBackColor = True
        '
        'DestroyTweet
        '
        Me.DestroyTweet.Location = New System.Drawing.Point(214, 349)
        Me.DestroyTweet.Name = "DestroyTweet"
        Me.DestroyTweet.Size = New System.Drawing.Size(100, 23)
        Me.DestroyTweet.TabIndex = 5
        Me.DestroyTweet.Text = "破棄/キャンセル"
        Me.DestroyTweet.UseVisualStyleBackColor = True
        '
        'TextLength
        '
        Me.TextLength.AutoSize = True
        Me.TextLength.Location = New System.Drawing.Point(3, 326)
        Me.TextLength.Name = "TextLength"
        Me.TextLength.Size = New System.Drawing.Size(0, 12)
        Me.TextLength.TabIndex = 6
        '
        'TweetTimePicker
        '
        Me.TweetTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TweetTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TweetTimePicker.Location = New System.Drawing.Point(214, 63)
        Me.TweetTimePicker.Name = "TweetTimePicker"
        Me.TweetTimePicker.Size = New System.Drawing.Size(205, 19)
        Me.TweetTimePicker.TabIndex = 7
        '
        'TweetManagerEditorGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 376)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TweetManagerEditorGUI"
        Me.ShowIcon = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TweetDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents SubmitTweet As System.Windows.Forms.Button
    Friend WithEvents DestroyTweet As System.Windows.Forms.Button
    Friend WithEvents TextLength As System.Windows.Forms.Label
    Friend WithEvents TweetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TweetTimePicker As System.Windows.Forms.DateTimePicker
End Class
