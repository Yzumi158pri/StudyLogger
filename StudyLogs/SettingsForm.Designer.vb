<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        txtlblOutputPath = New MyControls.LabeledTextBox()
        btnReset = New Button()
        btnExit = New Button()
        btnUpd = New Button()
        SuspendLayout()
        ' 
        ' txtlblOutputPath
        ' 
        txtlblOutputPath.LabelSize = New Size(70, 27)
        txtlblOutputPath.LabelText = "出力先"
        txtlblOutputPath.LabelWidth = 70
        txtlblOutputPath.Location = New Point(50, 114)
        txtlblOutputPath.Name = "txtlblOutputPath"
        txtlblOutputPath.Size = New Size(678, 34)
        txtlblOutputPath.TabIndex = 0
        txtlblOutputPath.TextBoxSize = New Size(600, 27)
        txtlblOutputPath.TextBoxText = ""
        txtlblOutputPath.TextBoxWidth = 600
        ' 
        ' btnReset
        ' 
        btnReset.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnReset.Location = New Point(585, 227)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(94, 37)
        btnReset.TabIndex = 1
        btnReset.Text = "再読込"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnExit.Location = New Point(694, 227)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(94, 37)
        btnExit.TabIndex = 2
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnUpd
        ' 
        btnUpd.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnUpd.Location = New Point(25, 227)
        btnUpd.Name = "btnUpd"
        btnUpd.Size = New Size(94, 37)
        btnUpd.TabIndex = 3
        btnUpd.Text = "更新"
        btnUpd.UseVisualStyleBackColor = True
        ' 
        ' SettingsForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 290)
        Controls.Add(btnUpd)
        Controls.Add(btnExit)
        Controls.Add(btnReset)
        Controls.Add(txtlblOutputPath)
        Name = "SettingsForm"
        Text = "設定"
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtlblOutputPath As MyControls.LabeledTextBox
    Friend WithEvents btnReset As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnUpd As Button
End Class
