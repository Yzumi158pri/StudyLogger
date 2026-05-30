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
        txtlblUserName = New MyControls.LabeledTextBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtlblOutputPath
        ' 
        txtlblOutputPath.LabelAlign = ContentAlignment.MiddleLeft
        txtlblOutputPath.LabelSize = New Size(70, 23)
        txtlblOutputPath.LabelWidth = 70
        txtlblOutputPath.lblText = "出力先"
        txtlblOutputPath.Location = New Point(18, 84)
        txtlblOutputPath.Margin = New Padding(36, 14, 36, 14)
        txtlblOutputPath.MustInput = False
        txtlblOutputPath.Name = "txtlblOutputPath"
        txtlblOutputPath.Size = New Size(496, 23)
        txtlblOutputPath.TabIndex = 0
        txtlblOutputPath.TextBoxAlign = HorizontalAlignment.Left
        txtlblOutputPath.TextBoxSize = New Size(426, 23)
        txtlblOutputPath.TextBoxWidth = 426
        txtlblOutputPath.TextEnable = True
        txtlblOutputPath.TextMultiline = False
        txtlblOutputPath.txtMaxLength = 32767
        txtlblOutputPath.txtText = ""
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(7, 6)
        btnReset.Margin = New Padding(2)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(75, 23)
        btnReset.TabIndex = 1
        btnReset.Text = "再読込"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(417, 6)
        btnExit.Margin = New Padding(2)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(75, 23)
        btnExit.TabIndex = 2
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnUpd
        ' 
        btnUpd.Location = New Point(338, 6)
        btnUpd.Margin = New Padding(2)
        btnUpd.Name = "btnUpd"
        btnUpd.Size = New Size(75, 23)
        btnUpd.TabIndex = 3
        btnUpd.Text = "更新"
        btnUpd.UseVisualStyleBackColor = True
        ' 
        ' btnRef
        ' 
        btnRef.Location = New Point(441, 118)
        btnRef.Margin = New Padding(2)
        btnRef.Name = "btnRef"
        btnRef.Size = New Size(75, 23)
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
        Panel1.Location = New Point(11, 198)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(505, 34)
        Panel1.TabIndex = 5
        ' 
        ' radAutoOutput
        ' 
        radAutoOutput.AutoSize = True
        radAutoOutput.Location = New Point(20, 122)
        radAutoOutput.Margin = New Padding(2)
        radAutoOutput.Name = "radAutoOutput"
        radAutoOutput.Size = New Size(73, 19)
        radAutoOutput.TabIndex = 6
        radAutoOutput.TabStop = True
        radAutoOutput.Text = "自動出力"
        radAutoOutput.UseVisualStyleBackColor = True
        ' 
        ' radManualOutput
        ' 
        radManualOutput.AutoSize = True
        radManualOutput.Location = New Point(97, 122)
        radManualOutput.Margin = New Padding(2)
        radManualOutput.Name = "radManualOutput"
        radManualOutput.Size = New Size(73, 19)
        radManualOutput.TabIndex = 7
        radManualOutput.TabStop = True
        radManualOutput.Text = "手動出力"
        radManualOutput.UseVisualStyleBackColor = True
        ' 
        ' txtlblUserName
        ' 
        txtlblUserName.LabelAlign = ContentAlignment.MiddleLeft
        txtlblUserName.LabelSize = New Size(70, 23)
        txtlblUserName.LabelWidth = 70
        txtlblUserName.lblText = "ユーザー名"
        txtlblUserName.Location = New Point(18, 47)
        txtlblUserName.Margin = New Padding(0)
        txtlblUserName.MustInput = False
        txtlblUserName.Name = "txtlblUserName"
        txtlblUserName.Size = New Size(321, 23)
        txtlblUserName.TabIndex = 8
        txtlblUserName.TextBoxAlign = HorizontalAlignment.Left
        txtlblUserName.TextBoxSize = New Size(251, 23)
        txtlblUserName.TextBoxWidth = 251
        txtlblUserName.TextEnable = True
        txtlblUserName.TextMultiline = False
        txtlblUserName.txtMaxLength = 20
        txtlblUserName.txtText = ""
        ' 
        ' SettingsForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(527, 238)
        Controls.Add(txtlblUserName)
        Controls.Add(radManualOutput)
        Controls.Add(radAutoOutput)
        Controls.Add(btnRef)
        Controls.Add(txtlblOutputPath)
        Controls.Add(Panel1)
        Margin = New Padding(2)
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
    Friend WithEvents txtlblUserName As MyControls.LabeledTextBox
End Class
