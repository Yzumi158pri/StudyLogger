<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        cmd1 = New Button()
        btnExit = New Button()
        TextLabel1 = New MyControls.LabeledTextBox()
        lblDate = New Label()
        btnDisp = New Button()
        btnOutput = New Button()
        btnSettings = New Button()
        Panel1 = New Panel()
        Dateymd1 = New MyControls.DateYMD()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmd1
        ' 
        cmd1.Location = New Point(967, 17)
        cmd1.Name = "cmd1"
        cmd1.Size = New Size(94, 29)
        cmd1.TabIndex = 3
        cmd1.Text = "ボタンを押せ"
        cmd1.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(1067, 17)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(94, 29)
        btnExit.TabIndex = 4
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' TextLabel1
        ' 
        TextLabel1.LabelSize = New Size(53, 27)
        TextLabel1.LabelWidth = 53
        TextLabel1.lblText = "入力"
        TextLabel1.Location = New Point(50, 105)
        TextLabel1.Margin = New Padding(45, 18, 45, 18)
        TextLabel1.Name = "TextLabel1"
        TextLabel1.Size = New Size(213, 27)
        TextLabel1.TabIndex = 1
        TextLabel1.TextBoxSize = New Size(160, 27)
        TextLabel1.TextBoxWidth = 160
        TextLabel1.txtMaxLength = 32767
        TextLabel1.txtText = ""
        ' 
        ' lblDate
        ' 
        lblDate.BorderStyle = BorderStyle.FixedSingle
        lblDate.Location = New Point(50, 57)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(53, 27)
        lblDate.TabIndex = 4
        lblDate.Text = "日付"
        ' 
        ' btnDisp
        ' 
        btnDisp.Location = New Point(263, 104)
        btnDisp.Name = "btnDisp"
        btnDisp.Size = New Size(50, 29)
        btnDisp.TabIndex = 5
        btnDisp.Text = "表示"
        btnDisp.UseVisualStyleBackColor = True
        ' 
        ' btnOutput
        ' 
        btnOutput.Location = New Point(867, 17)
        btnOutput.Name = "btnOutput"
        btnOutput.Size = New Size(94, 29)
        btnOutput.TabIndex = 6
        btnOutput.Text = "出力"
        btnOutput.UseVisualStyleBackColor = True
        ' 
        ' btnSettings
        ' 
        btnSettings.Location = New Point(12, 17)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(94, 29)
        btnSettings.TabIndex = 7
        btnSettings.Text = "設定"
        btnSettings.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Panel1.Controls.Add(btnOutput)
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(cmd1)
        Panel1.Controls.Add(btnExit)
        Panel1.Location = New Point(0, 565)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1183, 67)
        Panel1.TabIndex = 8
        ' 
        ' Dateymd1
        ' 
        Dateymd1.Location = New Point(103, 57)
        Dateymd1.Name = "Dateymd1"
        Dateymd1.Size = New Size(188, 27)
        Dateymd1.TabIndex = 9
        ' 
        ' MForm
        ' 
        AutoScaleMode = AutoScaleMode.Inherit
        ClientSize = New Size(1185, 635)
        Controls.Add(Dateymd1)
        Controls.Add(btnDisp)
        Controls.Add(lblDate)
        Controls.Add(TextLabel1)
        Controls.Add(Panel1)
        KeyPreview = True
        MinimumSize = New Size(1203, 682)
        Name = "MForm"
        Text = "資格学習記録"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents cmd1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents TextLabel1 As MyControls.LabeledTextBox
    Friend WithEvents lblDate As Label
    Friend WithEvents btnDisp As Button
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Dateymd1 As MyControls.DateYMD

End Class
