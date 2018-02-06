<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionForm
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TemplateTextBox = New System.Windows.Forms.TextBox()
        Me.TimeOutNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.ExtensionsTextBox = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TimeOutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Label1.Location = New System.Drawing.Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(254, 22)
        Label1.TabIndex = 0
        Label1.Text = "HTML Template:"
        Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Label2.Location = New System.Drawing.Point(3, 131)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(254, 22)
        Label2.TabIndex = 1
        Label2.Text = "Exclude extensions:"
        Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Label3.Location = New System.Drawing.Point(3, 177)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(254, 22)
        Label3.TabIndex = 4
        Label3.Text = "Timeout(sec):"
        Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ButtonOk
        '
        Me.ButtonOk.Location = New System.Drawing.Point(116, 247)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(75, 25)
        Me.ButtonOk.TabIndex = 0
        Me.ButtonOk.Text = "OK"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(197, 247)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 25)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TemplateTextBox, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Label3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TimeOutNumericUpDown, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ExtensionsTextBox, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(260, 228)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TemplateTextBox
        '
        Me.TemplateTextBox.AcceptsReturn = True
        Me.TemplateTextBox.Location = New System.Drawing.Point(3, 25)
        Me.TemplateTextBox.Multiline = True
        Me.TemplateTextBox.Name = "TemplateTextBox"
        Me.TemplateTextBox.Size = New System.Drawing.Size(254, 103)
        Me.TemplateTextBox.TabIndex = 0
        '
        'TimeOutNumericUpDown
        '
        Me.TimeOutNumericUpDown.Location = New System.Drawing.Point(3, 202)
        Me.TimeOutNumericUpDown.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.TimeOutNumericUpDown.Name = "TimeOutNumericUpDown"
        Me.TimeOutNumericUpDown.Size = New System.Drawing.Size(85, 20)
        Me.TimeOutNumericUpDown.TabIndex = 2
        '
        'ExtensionsTextBox
        '
        Me.ExtensionsTextBox.Location = New System.Drawing.Point(3, 156)
        Me.ExtensionsTextBox.Name = "ExtensionsTextBox"
        Me.ExtensionsTextBox.Size = New System.Drawing.Size(254, 20)
        Me.ExtensionsTextBox.TabIndex = 1
        '
        'OptionForm
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 285)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Url2Title"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TimeOutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents ButtonOk As System.Windows.Forms.Button
    Private WithEvents ButtonCancel As System.Windows.Forms.Button
    Private WithEvents TimeOutNumericUpDown As System.Windows.Forms.NumericUpDown
    Private WithEvents ExtensionsTextBox As System.Windows.Forms.TextBox
    Private WithEvents TemplateTextBox As System.Windows.Forms.TextBox
End Class
