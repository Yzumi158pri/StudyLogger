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
        lblSumStudyTime = New Label()
        SumStudyTime = New Label()
        numStudyTime = New NumericUpDown()
        numProgress = New NumericUpDown()
        StudyDate = New MyControls.DateYMD()
        lblStudyTime = New Label()
        txtRemarks = New MyControls.LabeledTextBox()
        lblStudyDate = New Label()
        Label1 = New Label()
        lblProgress = New Label()
        txtStudyContent = New MyControls.LabeledTextBox()
        BodyPanel = New Panel()
        Panel1.SuspendLayout()
        CType(numStudyTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(numProgress, ComponentModel.ISupportInitialize).BeginInit()
        BodyPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmd1
        ' 
        cmd1.Location = New Point(356, 14)
        cmd1.Margin = New Padding(2)
        cmd1.Name = "cmd1"
        cmd1.Size = New Size(75, 23)
        cmd1.TabIndex = 3
        cmd1.Text = "ボタンを押せ"
        cmd1.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(435, 14)
        btnExit.Margin = New Padding(2)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(75, 23)
        btnExit.TabIndex = 4
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' txtExamName
        ' 
        txtExamName.LabelAlign = ContentAlignment.MiddleLeft
        txtExamName.LabelSize = New Size(72, 23)
        txtExamName.LabelWidth = 72
        txtExamName.lblText = "資格名"
        txtExamName.Location = New Point(36, 23)
        txtExamName.Margin = New Padding(36, 14, 36, 14)
        txtExamName.MustInput = True
        txtExamName.Name = "txtExamName"
        txtExamName.Size = New Size(345, 23)
        txtExamName.TabIndex = 1
        txtExamName.TextBoxAlign = HorizontalAlignment.Left
        txtExamName.TextBoxSize = New Size(273, 23)
        txtExamName.TextBoxWidth = 273
        txtExamName.TextEnable = True
        txtExamName.TextMultiline = False
        txtExamName.txtMaxLength = 32767
        txtExamName.txtText = ""
        ' 
        ' btnDisp
        ' 
        btnDisp.Location = New Point(435, 36)
        btnDisp.Margin = New Padding(2)
        btnDisp.Name = "btnDisp"
        btnDisp.Size = New Size(44, 23)
        btnDisp.TabIndex = 5
        btnDisp.Text = "表示"
        btnDisp.UseVisualStyleBackColor = True
        ' 
        ' btnOutput
        ' 
        btnOutput.Location = New Point(277, 14)
        btnOutput.Margin = New Padding(2)
        btnOutput.Name = "btnOutput"
        btnOutput.Size = New Size(75, 23)
        btnOutput.TabIndex = 6
        btnOutput.Text = "出力"
        btnOutput.UseVisualStyleBackColor = True
        ' 
        ' btnSettings
        ' 
        btnSettings.Location = New Point(22, 14)
        btnSettings.Margin = New Padding(2)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(75, 23)
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
        Panel1.Location = New Point(0, 452)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(538, 54)
        Panel1.TabIndex = 8
        ' 
        ' TargetDate
        ' 
        TargetDate.Location = New Point(340, 40)
        TargetDate.Margin = New Padding(2)
        TargetDate.MustInput = True
        TargetDate.Name = "TargetDate"
        TargetDate.Size = New Size(150, 22)
        TargetDate.TabIndex = 9
        ' 
        ' lblTargetDate
        ' 
        lblTargetDate.BorderStyle = BorderStyle.FixedSingle
        lblTargetDate.ImageAlign = ContentAlignment.MiddleLeft
        lblTargetDate.Location = New Point(258, 39)
        lblTargetDate.Margin = New Padding(2, 0, 2, 0)
        lblTargetDate.Name = "lblTargetDate"
        lblTargetDate.Size = New Size(82, 23)
        lblTargetDate.TabIndex = 4
        lblTargetDate.Text = "取得目標時期"
        lblTargetDate.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' HeaderLine
        ' 
        HeaderLine.BorderStyle = BorderStyle.Fixed3D
        HeaderLine.Location = New Point(0, 70)
        HeaderLine.Margin = New Padding(2, 0, 2, 0)
        HeaderLine.Name = "HeaderLine"
        HeaderLine.Size = New Size(946, 1)
        HeaderLine.TabIndex = 10
        ' 
        ' lblSumStudyTime
        ' 
        lblSumStudyTime.BorderStyle = BorderStyle.FixedSingle
        lblSumStudyTime.Location = New Point(258, 78)
        lblSumStudyTime.Margin = New Padding(2, 0, 2, 0)
        lblSumStudyTime.Name = "lblSumStudyTime"
        lblSumStudyTime.Size = New Size(82, 23)
        lblSumStudyTime.TabIndex = 21
        lblSumStudyTime.Text = "合計学習時間"
        lblSumStudyTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SumStudyTime
        ' 
        SumStudyTime.BorderStyle = BorderStyle.FixedSingle
        SumStudyTime.Location = New Point(339, 78)
        SumStudyTime.Margin = New Padding(2, 0, 2, 0)
        SumStudyTime.Name = "SumStudyTime"
        SumStudyTime.Size = New Size(100, 23)
        SumStudyTime.TabIndex = 22
        SumStudyTime.Text = "99時間99分"
        SumStudyTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' numStudyTime
        ' 
        numStudyTime.BackColor = Color.LightPink
        numStudyTime.Location = New Point(94, 77)
        numStudyTime.Margin = New Padding(2)
        numStudyTime.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        numStudyTime.Name = "numStudyTime"
        numStudyTime.Size = New Size(86, 23)
        numStudyTime.TabIndex = 16
        ' 
        ' numProgress
        ' 
        numProgress.Location = New Point(94, 115)
        numProgress.Margin = New Padding(2)
        numProgress.Name = "numProgress"
        numProgress.Size = New Size(86, 23)
        numProgress.TabIndex = 18
        ' 
        ' StudyDate
        ' 
        StudyDate.BackColor = SystemColors.Control
        StudyDate.Location = New Point(94, 39)
        StudyDate.Margin = New Padding(2)
        StudyDate.MustInput = True
        StudyDate.Name = "StudyDate"
        StudyDate.Size = New Size(139, 28)
        StudyDate.TabIndex = 13
        ' 
        ' lblStudyTime
        ' 
        lblStudyTime.BackColor = SystemColors.ControlLight
        lblStudyTime.BorderStyle = BorderStyle.FixedSingle
        lblStudyTime.ForeColor = SystemColors.ControlText
        lblStudyTime.Location = New Point(36, 77)
        lblStudyTime.Margin = New Padding(2, 0, 2, 0)
        lblStudyTime.Name = "lblStudyTime"
        lblStudyTime.Size = New Size(58, 23)
        lblStudyTime.TabIndex = 17
        lblStudyTime.Text = "学習時間"
        ' 
        ' txtRemarks
        ' 
        txtRemarks.LabelAlign = ContentAlignment.MiddleLeft
        txtRemarks.LabelSize = New Size(72, 92)
        txtRemarks.LabelWidth = 72
        txtRemarks.lblText = "備考"
        txtRemarks.Location = New Point(36, 262)
        txtRemarks.Margin = New Padding(0)
        txtRemarks.MustInput = False
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(458, 92)
        txtRemarks.TabIndex = 20
        txtRemarks.TextBoxAlign = HorizontalAlignment.Left
        txtRemarks.TextBoxSize = New Size(386, 92)
        txtRemarks.TextBoxWidth = 386
        txtRemarks.TextEnable = True
        txtRemarks.TextMultiline = True
        txtRemarks.txtMaxLength = 32767
        txtRemarks.txtText = ""
        ' 
        ' lblStudyDate
        ' 
        lblStudyDate.BorderStyle = BorderStyle.FixedSingle
        lblStudyDate.Location = New Point(36, 39)
        lblStudyDate.Margin = New Padding(2, 0, 2, 0)
        lblStudyDate.Name = "lblStudyDate"
        lblStudyDate.Size = New Size(58, 23)
        lblStudyDate.TabIndex = 15
        lblStudyDate.Text = "学習日"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(36, 8)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 15)
        Label1.TabIndex = 14
        Label1.Text = "学習内容を入力"
        ' 
        ' lblProgress
        ' 
        lblProgress.BorderStyle = BorderStyle.FixedSingle
        lblProgress.Location = New Point(36, 115)
        lblProgress.Margin = New Padding(2, 0, 2, 0)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(58, 23)
        lblProgress.TabIndex = 19
        lblProgress.Text = "進捗率"
        ' 
        ' txtStudyContent
        ' 
        txtStudyContent.LabelAlign = ContentAlignment.MiddleLeft
        txtStudyContent.LabelSize = New Size(72, 92)
        txtStudyContent.LabelWidth = 72
        txtStudyContent.lblText = "学習内容"
        txtStudyContent.Location = New Point(36, 154)
        txtStudyContent.Margin = New Padding(0)
        txtStudyContent.MustInput = True
        txtStudyContent.Name = "txtStudyContent"
        txtStudyContent.Size = New Size(458, 92)
        txtStudyContent.TabIndex = 12
        txtStudyContent.TextBoxAlign = HorizontalAlignment.Left
        txtStudyContent.TextBoxSize = New Size(386, 92)
        txtStudyContent.TextBoxWidth = 386
        txtStudyContent.TextEnable = True
        txtStudyContent.TextMultiline = True
        txtStudyContent.txtMaxLength = 32767
        txtStudyContent.txtText = ""
        ' 
        ' BodyPanel
        ' 
        BodyPanel.Controls.Add(SumStudyTime)
        BodyPanel.Controls.Add(txtStudyContent)
        BodyPanel.Controls.Add(lblSumStudyTime)
        BodyPanel.Controls.Add(TargetDate)
        BodyPanel.Controls.Add(lblProgress)
        BodyPanel.Controls.Add(lblTargetDate)
        BodyPanel.Controls.Add(Label1)
        BodyPanel.Controls.Add(lblStudyDate)
        BodyPanel.Controls.Add(txtRemarks)
        BodyPanel.Controls.Add(lblStudyTime)
        BodyPanel.Controls.Add(StudyDate)
        BodyPanel.Controls.Add(numProgress)
        BodyPanel.Controls.Add(numStudyTime)
        BodyPanel.Location = New Point(0, 74)
        BodyPanel.Margin = New Padding(2)
        BodyPanel.Name = "BodyPanel"
        BodyPanel.Size = New Size(538, 374)
        BodyPanel.TabIndex = 23
        ' 
        ' MForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(540, 514)
        Controls.Add(btnDisp)
        Controls.Add(HeaderLine)
        Controls.Add(txtExamName)
        Controls.Add(Panel1)
        Controls.Add(BodyPanel)
        KeyPreview = True
        Margin = New Padding(2)
        Name = "MForm"
        Text = "資格学習記録"
        Panel1.ResumeLayout(False)
        CType(numStudyTime, ComponentModel.ISupportInitialize).EndInit()
        CType(numProgress, ComponentModel.ISupportInitialize).EndInit()
        BodyPanel.ResumeLayout(False)
        BodyPanel.PerformLayout()
        ResumeLayout(False)

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
    Friend WithEvents lblSumStudyTime As Label
    Friend WithEvents SumStudyTime As Label
    Friend WithEvents numStudyTime As NumericUpDown
    Friend WithEvents numProgress As NumericUpDown
    Friend WithEvents StudyDate As MyControls.DateYMD
    Friend WithEvents lblStudyTime As Label
    Friend WithEvents txtRemarks As MyControls.LabeledTextBox
    Friend WithEvents lblStudyDate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblProgress As Label
    Friend WithEvents txtStudyContent As MyControls.LabeledTextBox
    Friend WithEvents BodyPanel As Panel

End Class
