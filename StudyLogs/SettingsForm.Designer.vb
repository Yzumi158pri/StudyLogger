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
        btnRef = New Button()
        Panel1 = New Panel()
        radAutoOutput = New RadioButton()
        radManualOutput = New RadioButton()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtlblOutputPath
        ' 
        txtlblOutputPath.LabelSize = New Size(70, 27)
        txtlblOutputPath.LabelWidth = 70
        txtlblOutputPath.lblText = "出力先"
        txtlblOutputPath.Location = New Point(25, 105)
        txtlblOutputPath.Margin = New Padding(45, 18, 45, 18)
        txtlblOutputPath.Name = "txtlblOutputPath"
        txtlblOutputPath.Size = New Size(620, 27)
        txtlblOutputPath.TabIndex = 0
        txtlblOutputPath.TextBoxSize = New Size(550, 27)
        txtlblOutputPath.TextBoxWidth = 550
        txtlblOutputPath.txtMaxLength = 32767
        txtlblOutputPath.txtText = ""
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(585, 8)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(94, 29)
        btnReset.TabIndex = 1
        btnReset.Text = "再読込"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(694, 8)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(94, 29)
        btnExit.TabIndex = 2
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnUpd
        ' 
        btnUpd.Location = New Point(12, 8)
        btnUpd.Name = "btnUpd"
        btnUpd.Size = New Size(94, 29)
        btnUpd.TabIndex = 3
        btnUpd.Text = "更新"
        btnUpd.UseVisualStyleBackColor = True
        ' 
        ' btnRef
        ' 
        btnRef.Location = New Point(645, 105)
        btnRef.Name = "btnRef"
        btnRef.Size = New Size(51, 29)
        btnRef.TabIndex = 4
        btnRef.Text = "参照"
        btnRef.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Panel1.Controls.Add(btnUpd)
        Panel1.Controls.Add(btnExit)
        Panel1.Controls.Add(btnReset)
        Panel1.Location = New Point(3, 247)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 43)
        Panel1.TabIndex = 5
        ' 
        ' radAutoOutput
        ' 
        radAutoOutput.AutoSize = True
        radAutoOutput.Location = New Point(25, 153)
        radAutoOutput.Name = "radAutoOutput"
        radAutoOutput.Size = New Size(90, 24)
        radAutoOutput.TabIndex = 6
        radAutoOutput.TabStop = True
        radAutoOutput.Text = "自動出力"
        radAutoOutput.UseVisualStyleBackColor = True
        ' 
        ' radManualOutput
        ' 
        radManualOutput.AutoSize = True
        radManualOutput.Location = New Point(121, 153)
        radManualOutput.Name = "radManualOutput"
        radManualOutput.Size = New Size(90, 24)
        radManualOutput.TabIndex = 7
        radManualOutput.TabStop = True
        radManualOutput.Text = "手動出力"
        radManualOutput.UseVisualStyleBackColor = True
        ' 
        ' SettingsForm
        ' 
        AutoScaleMode = AutoScaleMode.Inherit
        ClientSize = New Size(800, 290)
        Controls.Add(radManualOutput)
        Controls.Add(radAutoOutput)
        Controls.Add(btnRef)
        Controls.Add(txtlblOutputPath)
        Controls.Add(Panel1)
        MinimumSize = New Size(818, 337)
        Name = "SettingsForm"
        Text = "設定"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtlblOutputPath As MyControls.LabeledTextBox
    Friend WithEvents btnReset As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnUpd As Button
    Friend WithEvents btnRef As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents radAutoOutput As RadioButton
    Friend WithEvents radManualOutput As RadioButton
End Class
