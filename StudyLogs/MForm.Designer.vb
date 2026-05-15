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
        txtExamName = New MyControls.LabeledTextBox()
        btnDisp = New Button()
        btnOutput = New Button()
        btnSettings = New Button()
        Panel1 = New Panel()
        TargetDate = New MyControls.DateYMD()
        lblTargetDate = New Label()
        HeaderLine = New Label()
        txtStudyContent = New MyControls.LabeledTextBox()
        Dateymd1 = New MyControls.DateYMD()
        Label1 = New Label()
        lblStudyDate = New Label()
        numStudyTime = New NumericUpDown()
        lblStudyTime = New Label()
        lblProgress = New Label()
        numProgress = New NumericUpDown()
        txtRemarks = New MyControls.LabeledTextBox()
        lblSumStudyTime = New Label()
        SumStudyTime = New Label()
        BodyPanel = New Panel()
        Panel1.SuspendLayout()
        CType(numStudyTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(numProgress, ComponentModel.ISupportInitialize).BeginInit()
        BodyPanel.SuspendLayout()
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
        ' txtExamName
        ' 
        txtExamName.LabelAlign = ContentAlignment.MiddleLeft
        txtExamName.LabelSize = New Size(72, 27)
        txtExamName.LabelWidth = 72
        txtExamName.lblText = "資格名"
        txtExamName.Location = New Point(45, 24)
        txtExamName.Margin = New Padding(45, 18, 45, 18)
        txtExamName.Name = "txtExamName"
        txtExamName.Size = New Size(372, 27)
        txtExamName.TabIndex = 1
        txtExamName.TextBoxAlign = HorizontalAlignment.Left
        txtExamName.TextBoxSize = New Size(300, 27)
        txtExamName.TextBoxWidth = 300
        txtExamName.TextEnable = True
        txtExamName.TextMultiline = False
        txtExamName.txtMaxLength = 32767
        txtExamName.txtText = ""
        ' 
        ' btnDisp
        ' 
        btnDisp.Location = New Point(1083, 56)
        btnDisp.Name = "btnDisp"
        btnDisp.Size = New Size(55, 29)
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
        ' TargetDate
        ' 
        TargetDate.Location = New Point(611, 28)
        TargetDate.Name = "TargetDate"
        TargetDate.Size = New Size(188, 27)
        TargetDate.TabIndex = 9
        ' 
        ' lblTargetDate
        ' 
        lblTargetDate.BorderStyle = BorderStyle.FixedSingle
        lblTargetDate.ImageAlign = ContentAlignment.MiddleLeft
        lblTargetDate.Location = New Point(509, 28)
        lblTargetDate.Name = "lblTargetDate"
        lblTargetDate.Size = New Size(101, 27)
        lblTargetDate.TabIndex = 4
        lblTargetDate.Text = "取得目標時期"
        lblTargetDate.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' HeaderLine
        ' 
        HeaderLine.BorderStyle = BorderStyle.Fixed3D
        HeaderLine.Location = New Point(0, 88)
        HeaderLine.Name = "HeaderLine"
        HeaderLine.Size = New Size(1183, 1)
        HeaderLine.TabIndex = 10
        ' 
        ' txtStudyContent
        ' 
        txtStudyContent.LabelAlign = ContentAlignment.MiddleLeft
        txtStudyContent.LabelSize = New Size(72, 115)
        txtStudyContent.LabelWidth = 72
        txtStudyContent.lblText = "学習内容"
        txtStudyContent.Location = New Point(45, 186)
        txtStudyContent.Margin = New Padding(45, 18, 45, 18)
        txtStudyContent.Name = "txtStudyContent"
        txtStudyContent.Size = New Size(572, 115)
        txtStudyContent.TabIndex = 12
        txtStudyContent.TextBoxAlign = HorizontalAlignment.Left
        txtStudyContent.TextBoxSize = New Size(500, 115)
        txtStudyContent.TextBoxWidth = 500
        txtStudyContent.TextEnable = True
        txtStudyContent.TextMultiline = True
        txtStudyContent.txtMaxLength = 32767
        txtStudyContent.txtText = ""
        ' 
        ' Dateymd1
        ' 
        Dateymd1.Location = New Point(119, 141)
        Dateymd1.Name = "Dateymd1"
        Dateymd1.Size = New Size(201, 35)
        Dateymd1.TabIndex = 13
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(44, 103)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 20)
        Label1.TabIndex = 14
        Label1.Text = "学習内容を入力"
        ' 
        ' lblStudyDate
        ' 
        lblStudyDate.BorderStyle = BorderStyle.FixedSingle
        lblStudyDate.Location = New Point(44, 141)
        lblStudyDate.Name = "lblStudyDate"
        lblStudyDate.Size = New Size(75, 27)
        lblStudyDate.TabIndex = 15
        lblStudyDate.Text = "学習日"
        ' 
        ' numStudyTime
        ' 
        numStudyTime.Location = New Point(116, 95)
        numStudyTime.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        numStudyTime.Name = "numStudyTime"
        numStudyTime.Size = New Size(108, 27)
        numStudyTime.TabIndex = 16
        ' 
        ' lblStudyTime
        ' 
        lblStudyTime.BorderStyle = BorderStyle.FixedSingle
        lblStudyTime.Location = New Point(44, 96)
        lblStudyTime.Name = "lblStudyTime"
        lblStudyTime.Size = New Size(72, 27)
        lblStudyTime.TabIndex = 17
        lblStudyTime.Text = "学習時間"
        ' 
        ' lblProgress
        ' 
        lblProgress.BorderStyle = BorderStyle.FixedSingle
        lblProgress.Location = New Point(44, 141)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(72, 27)
        lblProgress.TabIndex = 19
        lblProgress.Text = "進捗率"
        ' 
        ' numProgress
        ' 
        numProgress.Location = New Point(116, 141)
        numProgress.Name = "numProgress"
        numProgress.Size = New Size(108, 27)
        numProgress.TabIndex = 18
        ' 
        ' txtRemarks
        ' 
        txtRemarks.LabelAlign = ContentAlignment.MiddleLeft
        txtRemarks.LabelSize = New Size(72, 115)
        txtRemarks.LabelWidth = 72
        txtRemarks.lblText = "備考"
        txtRemarks.Location = New Point(45, 334)
        txtRemarks.Margin = New Padding(45, 18, 45, 18)
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(572, 115)
        txtRemarks.TabIndex = 20
        txtRemarks.TextBoxAlign = HorizontalAlignment.Left
        txtRemarks.TextBoxSize = New Size(500, 115)
        txtRemarks.TextBoxWidth = 500
        txtRemarks.TextEnable = True
        txtRemarks.TextMultiline = True
        txtRemarks.txtMaxLength = 32767
        txtRemarks.txtText = ""
        ' 
        ' lblSumStudyTime
        ' 
        lblSumStudyTime.BorderStyle = BorderStyle.FixedSingle
        lblSumStudyTime.Location = New Point(798, 27)
        lblSumStudyTime.Name = "lblSumStudyTime"
        lblSumStudyTime.Size = New Size(102, 27)
        lblSumStudyTime.TabIndex = 21
        lblSumStudyTime.Text = "合計学習時間"
        lblSumStudyTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SumStudyTime
        ' 
        SumStudyTime.BorderStyle = BorderStyle.FixedSingle
        SumStudyTime.Location = New Point(899, 27)
        SumStudyTime.Name = "SumStudyTime"
        SumStudyTime.Size = New Size(125, 27)
        SumStudyTime.TabIndex = 22
        SumStudyTime.Text = "99時間99分"
        SumStudyTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BodyPanel
        ' 
        BodyPanel.Controls.Add(txtStudyContent)
        BodyPanel.Controls.Add(lblProgress)
        BodyPanel.Controls.Add(txtRemarks)
        BodyPanel.Controls.Add(lblStudyTime)
        BodyPanel.Controls.Add(numProgress)
        BodyPanel.Controls.Add(numStudyTime)
        BodyPanel.Location = New Point(0, 92)
        BodyPanel.Name = "BodyPanel"
        BodyPanel.Size = New Size(1183, 467)
        BodyPanel.TabIndex = 23
        ' 
        ' MForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1185, 635)
        Controls.Add(SumStudyTime)
        Controls.Add(lblSumStudyTime)
        Controls.Add(lblStudyDate)
        Controls.Add(Label1)
        Controls.Add(Dateymd1)
        Controls.Add(btnDisp)
        Controls.Add(HeaderLine)
        Controls.Add(txtExamName)
        Controls.Add(TargetDate)
        Controls.Add(lblTargetDate)
        Controls.Add(Panel1)
        Controls.Add(BodyPanel)
        KeyPreview = True
        MinimumSize = New Size(1203, 682)
        Name = "MForm"
        Text = "資格学習記録"
        Panel1.ResumeLayout(False)
        CType(numStudyTime, ComponentModel.ISupportInitialize).EndInit()
        CType(numProgress, ComponentModel.ISupportInitialize).EndInit()
        BodyPanel.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents cmd1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents txtExamName As MyControls.LabeledTextBox
    Friend WithEvents btnDisp As Button
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TargetDate As MyControls.DateYMD
    Friend WithEvents lblTargetDate As Label
    Friend WithEvents HeaderLine As Label
    Friend WithEvents txtStudyContent As MyControls.LabeledTextBox
    Friend WithEvents Dateymd1 As MyControls.DateYMD
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStudyDate As Label
    Friend WithEvents numStudyTime As NumericUpDown
    Friend WithEvents lblStudyTime As Label
    Friend WithEvents lblProgress As Label
    Friend WithEvents numProgress As NumericUpDown
    Friend WithEvents txtRemarks As MyControls.LabeledTextBox
    Friend WithEvents lblSumStudyTime As Label
    Friend WithEvents SumStudyTime As Label
    Friend WithEvents BodyPanel As Panel

End Class
