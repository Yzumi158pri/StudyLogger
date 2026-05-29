<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LabeledTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TextBox1 = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        TextBox1.Location = New System.Drawing.Point(40, 0)
        TextBox1.Margin = New System.Windows.Forms.Padding(0)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New System.Drawing.Size(80, 23)
        TextBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Label1.Location = New System.Drawing.Point(0, 0)
        Label1.Margin = New System.Windows.Forms.Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(40, 23)
        Label1.TabIndex = 2
        Label1.Text = "Label1"
        Label1.TextAlign = Drawing.ContentAlignment.MiddleLeft
        ' 
        ' LabeledTextBox
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Controls.Add(Label1)
        Controls.Add(TextBox1)
        Margin = New System.Windows.Forms.Padding(0)
        Name = "LabeledTextBox"
        Size = New System.Drawing.Size(120, 23)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
