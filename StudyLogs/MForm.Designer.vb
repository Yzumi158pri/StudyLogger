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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MForm))
        cmd1 = New Button()
        btnExit = New Button()
        txtExamName = New MyControls.LabeledTextBox()
        btnDisp = New Button()
        btnOutput = New Button()
        btnSettings = New Button()
        Panel1 = New Panel()
        btnRecord = New Button()
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
        lbltxtTargetDate = New MyControls.LabeledTextBox()
        cmbResult = New ComboBox()
        lblResult = New Label()
        lblJukenbi = New Label()
        Jukenbi = New MyControls.DateYMD()
        lbltxtSelectMode = New MyControls.LabeledTextBox()
        Label2 = New Label()
        HeaderPanel = New Panel()
        Panel1.SuspendLayout()
        CType(numStudyTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(numProgress, ComponentModel.ISupportInitialize).BeginInit()
        BodyPanel.SuspendLayout()
        HeaderPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmd1
        ' 
        cmd1.Location = New Point(347, 14)
        cmd1.Margin = New Padding(2)
        cmd1.Name = "cmd1"
        cmd1.Size = New Size(97, 23)
        cmd1.TabIndex = 4
        cmd1.Text = "ファイルチェック"
        cmd1.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(448, 14)
        btnExit.Margin = New Padding(2)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(75, 23)
        btnExit.TabIndex = 5
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' txtExamName
        ' 
        txtExamName.LabelAlign = ContentAlignment.MiddleLeft
        txtExamName.LabelSize = New Size(72, 23)
        txtExamName.LabelWidth = 72
        txtExamName.lblText = "資格名"
        txtExamName.Location = New Point(20, 9)
        txtExamName.Margin = New Padding(36, 14, 36, 14)
        txtExamName.MustInput = True
        txtExamName.Name = "txtExamName"
        txtExamName.Size = New Size(449, 23)
        txtExamName.TabIndex = 1
        txtExamName.Tag = "資格名"
        txtExamName.TextBoxAlign = HorizontalAlignment.Left
        txtExamName.TextBoxSize = New Size(377, 23)
        txtExamName.TextBoxWidth = 377
        txtExamName.TextEnable = True
        txtExamName.TextMultiline = False
        txtExamName.txtMaxLength = 32767
        txtExamName.txtText = ""
        ' 
        ' btnDisp
        ' 
        btnDisp.Location = New Point(490, 44)
        btnDisp.Margin = New Padding(2)
        btnDisp.Name = "btnDisp"
        btnDisp.Size = New Size(44, 23)
        btnDisp.TabIndex = 2
        btnDisp.Text = "表示"
        btnDisp.UseVisualStyleBackColor = True
        ' 
        ' btnOutput
        ' 
        btnOutput.Location = New Point(187, 14)
        btnOutput.Margin = New Padding(2)
        btnOutput.Name = "btnOutput"
        btnOutput.Size = New Size(75, 23)
        btnOutput.TabIndex = 2
        btnOutput.Text = "出力"
        btnOutput.UseVisualStyleBackColor = True
        btnOutput.Visible = False
        ' 
        ' btnSettings
        ' 
        btnSettings.Location = New Point(22, 14)
        btnSettings.Margin = New Padding(2)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(75, 23)
        btnSettings.TabIndex = 1
        btnSettings.Text = "設定"
        btnSettings.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Panel1.Controls.Add(btnRecord)
        Panel1.Controls.Add(btnOutput)
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(cmd1)
        Panel1.Controls.Add(btnExit)
        Panel1.Location = New Point(2, 484)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(547, 54)
        Panel1.TabIndex = 17
        ' 
        ' btnRecord
        ' 
        btnRecord.Location = New Point(267, 14)
        btnRecord.Name = "btnRecord"
        btnRecord.Size = New Size(75, 23)
        btnRecord.TabIndex = 3
        btnRecord.Text = "記録する"
        btnRecord.UseVisualStyleBackColor = True
        ' 
        ' HeaderLine
        ' 
        HeaderLine.BorderStyle = BorderStyle.Fixed3D
        HeaderLine.Location = New Point(-13, 90)
        HeaderLine.Margin = New Padding(2, 0, 2, 0)
        HeaderLine.Name = "HeaderLine"
        HeaderLine.Size = New Size(946, 1)
        HeaderLine.TabIndex = 10
        ' 
        ' lblSumStudyTime
        ' 
        lblSumStudyTime.BorderStyle = BorderStyle.FixedSingle
        lblSumStudyTime.Location = New Point(291, 18)
        lblSumStudyTime.Margin = New Padding(2, 0, 2, 0)
        lblSumStudyTime.Name = "lblSumStudyTime"
        lblSumStudyTime.Size = New Size(82, 23)
        lblSumStudyTime.TabIndex = 2
        lblSumStudyTime.Text = "合計学習時間"
        lblSumStudyTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SumStudyTime
        ' 
        SumStudyTime.BorderStyle = BorderStyle.FixedSingle
        SumStudyTime.Location = New Point(372, 18)
        SumStudyTime.Margin = New Padding(2, 0, 2, 0)
        SumStudyTime.Name = "SumStudyTime"
        SumStudyTime.Size = New Size(121, 23)
        SumStudyTime.TabIndex = 3
        SumStudyTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' numStudyTime
        ' 
        numStudyTime.BackColor = Color.LightPink
        numStudyTime.ImeMode = ImeMode.Disable
        numStudyTime.Location = New Point(99, 89)
        numStudyTime.Margin = New Padding(2)
        numStudyTime.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        numStudyTime.Name = "numStudyTime"
        numStudyTime.Size = New Size(86, 23)
        numStudyTime.TabIndex = 8
        numStudyTime.Tag = "学習時間"
        ' 
        ' numProgress
        ' 
        numProgress.DecimalPlaces = 2
        numProgress.ImeMode = ImeMode.Disable
        numProgress.Location = New Point(99, 127)
        numProgress.Margin = New Padding(2)
        numProgress.Name = "numProgress"
        numProgress.Size = New Size(86, 23)
        numProgress.TabIndex = 12
        ' 
        ' StudyDate
        ' 
        StudyDate.BackColor = SystemColors.Control
        StudyDate.Location = New Point(92, 46)
        StudyDate.Margin = New Padding(2)
        StudyDate.MustInput = True
        StudyDate.Name = "StudyDate"
        StudyDate.Size = New Size(139, 28)
        StudyDate.TabIndex = 5
        StudyDate.Tag = "学習日"
        ' 
        ' lblStudyTime
        ' 
        lblStudyTime.BackColor = SystemColors.Control
        lblStudyTime.BorderStyle = BorderStyle.FixedSingle
        lblStudyTime.ForeColor = SystemColors.ControlText
        lblStudyTime.Location = New Point(34, 89)
        lblStudyTime.Margin = New Padding(2, 0, 2, 0)
        lblStudyTime.Name = "lblStudyTime"
        lblStudyTime.Size = New Size(65, 23)
        lblStudyTime.TabIndex = 7
        lblStudyTime.Text = "学習時間"
        ' 
        ' txtRemarks
        ' 
        txtRemarks.LabelAlign = ContentAlignment.MiddleLeft
        txtRemarks.LabelSize = New Size(72, 92)
        txtRemarks.LabelWidth = 72
        txtRemarks.lblText = "備考"
        txtRemarks.Location = New Point(34, 276)
        txtRemarks.Margin = New Padding(0)
        txtRemarks.MustInput = False
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(491, 92)
        txtRemarks.TabIndex = 16
        txtRemarks.TextBoxAlign = HorizontalAlignment.Left
        txtRemarks.TextBoxSize = New Size(419, 92)
        txtRemarks.TextBoxWidth = 419
        txtRemarks.TextEnable = True
        txtRemarks.TextMultiline = True
        txtRemarks.txtMaxLength = 32767
        txtRemarks.txtText = ""
        ' 
        ' lblStudyDate
        ' 
        lblStudyDate.BorderStyle = BorderStyle.FixedSingle
        lblStudyDate.Location = New Point(18, 46)
        lblStudyDate.Margin = New Padding(2, 0, 2, 0)
        lblStudyDate.Name = "lblStudyDate"
        lblStudyDate.Size = New Size(72, 23)
        lblStudyDate.TabIndex = 4
        lblStudyDate.Text = "学習日"
        lblStudyDate.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(36, 22)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(155, 30)
        Label1.TabIndex = 1
        Label1.Text = "学習内容を入力"
        ' 
        ' lblProgress
        ' 
        lblProgress.BorderStyle = BorderStyle.FixedSingle
        lblProgress.Location = New Point(34, 127)
        lblProgress.Margin = New Padding(2, 0, 2, 0)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(65, 23)
        lblProgress.TabIndex = 11
        lblProgress.Text = "進捗率(%)"
        ' 
        ' txtStudyContent
        ' 
        txtStudyContent.LabelAlign = ContentAlignment.MiddleLeft
        txtStudyContent.LabelSize = New Size(72, 92)
        txtStudyContent.LabelWidth = 72
        txtStudyContent.lblText = "学習内容"
        txtStudyContent.Location = New Point(34, 168)
        txtStudyContent.Margin = New Padding(0)
        txtStudyContent.MustInput = True
        txtStudyContent.Name = "txtStudyContent"
        txtStudyContent.Size = New Size(491, 92)
        txtStudyContent.TabIndex = 15
        txtStudyContent.Tag = "学習内容"
        txtStudyContent.TextBoxAlign = HorizontalAlignment.Left
        txtStudyContent.TextBoxSize = New Size(419, 92)
        txtStudyContent.TextBoxWidth = 419
        txtStudyContent.TextEnable = True
        txtStudyContent.TextMultiline = True
        txtStudyContent.txtMaxLength = 32767
        txtStudyContent.txtText = ""
        ' 
        ' BodyPanel
        ' 
        BodyPanel.Controls.Add(lbltxtTargetDate)
        BodyPanel.Controls.Add(cmbResult)
        BodyPanel.Controls.Add(lblResult)
        BodyPanel.Controls.Add(lblJukenbi)
        BodyPanel.Controls.Add(Jukenbi)
        BodyPanel.Controls.Add(SumStudyTime)
        BodyPanel.Controls.Add(txtStudyContent)
        BodyPanel.Controls.Add(lblSumStudyTime)
        BodyPanel.Controls.Add(lblProgress)
        BodyPanel.Controls.Add(Label1)
        BodyPanel.Controls.Add(txtRemarks)
        BodyPanel.Controls.Add(lblStudyTime)
        BodyPanel.Controls.Add(numProgress)
        BodyPanel.Controls.Add(numStudyTime)
        BodyPanel.Location = New Point(0, 93)
        BodyPanel.Margin = New Padding(2)
        BodyPanel.Name = "BodyPanel"
        BodyPanel.Size = New Size(549, 386)
        BodyPanel.TabIndex = 3
        ' 
        ' lbltxtTargetDate
        ' 
        lbltxtTargetDate.LabelAlign = ContentAlignment.MiddleLeft
        lbltxtTargetDate.LabelSize = New Size(82, 23)
        lbltxtTargetDate.LabelWidth = 82
        lbltxtTargetDate.lblText = "取得目標時期"
        lbltxtTargetDate.Location = New Point(291, 56)
        lbltxtTargetDate.Margin = New Padding(0)
        lbltxtTargetDate.MustInput = True
        lbltxtTargetDate.Name = "lbltxtTargetDate"
        lbltxtTargetDate.Size = New Size(202, 23)
        lbltxtTargetDate.TabIndex = 6
        lbltxtTargetDate.Tag = "取得目標時期"
        lbltxtTargetDate.TextBoxAlign = HorizontalAlignment.Left
        lbltxtTargetDate.TextBoxSize = New Size(120, 23)
        lbltxtTargetDate.TextBoxWidth = 120
        lbltxtTargetDate.TextEnable = True
        lbltxtTargetDate.TextMultiline = False
        lbltxtTargetDate.txtMaxLength = 32767
        lbltxtTargetDate.txtText = ""
        ' 
        ' cmbResult
        ' 
        cmbResult.FormattingEnabled = True
        cmbResult.Items.AddRange(New Object() {"学習中", "合格", "不合格", "合否待ち"})
        cmbResult.Location = New Point(373, 132)
        cmbResult.Name = "cmbResult"
        cmbResult.Size = New Size(120, 23)
        cmbResult.TabIndex = 14
        ' 
        ' lblResult
        ' 
        lblResult.BorderStyle = BorderStyle.FixedSingle
        lblResult.Location = New Point(291, 132)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(82, 23)
        lblResult.TabIndex = 13
        lblResult.Text = "受験結果"
        lblResult.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblJukenbi
        ' 
        lblJukenbi.BorderStyle = BorderStyle.FixedSingle
        lblJukenbi.Location = New Point(291, 94)
        lblJukenbi.Name = "lblJukenbi"
        lblJukenbi.Size = New Size(82, 23)
        lblJukenbi.TabIndex = 9
        lblJukenbi.Text = "受験日"
        lblJukenbi.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Jukenbi
        ' 
        Jukenbi.Location = New Point(373, 94)
        Jukenbi.Margin = New Padding(3, 2, 3, 2)
        Jukenbi.MustInput = False
        Jukenbi.Name = "Jukenbi"
        Jukenbi.Size = New Size(139, 23)
        Jukenbi.TabIndex = 10
        ' 
        ' lbltxtSelectMode
        ' 
        lbltxtSelectMode.LabelAlign = ContentAlignment.MiddleLeft
        lbltxtSelectMode.LabelSize = New Size(72, 23)
        lbltxtSelectMode.LabelWidth = 72
        lbltxtSelectMode.lblText = "登録モード"
        lbltxtSelectMode.Location = New Point(240, 45)
        lbltxtSelectMode.Margin = New Padding(0)
        lbltxtSelectMode.MustInput = False
        lbltxtSelectMode.Name = "lbltxtSelectMode"
        lbltxtSelectMode.Size = New Size(120, 23)
        lbltxtSelectMode.TabIndex = 18
        lbltxtSelectMode.TextBoxAlign = HorizontalAlignment.Left
        lbltxtSelectMode.TextBoxSize = New Size(48, 23)
        lbltxtSelectMode.TextBoxWidth = 48
        lbltxtSelectMode.TextEnable = True
        lbltxtSelectMode.TextMultiline = False
        lbltxtSelectMode.txtMaxLength = 1
        lbltxtSelectMode.txtText = ""
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Location = New Point(361, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(106, 22)
        Label2.TabIndex = 19
        Label2.Text = "0:登録　1:訂正"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' HeaderPanel
        ' 
        HeaderPanel.Controls.Add(btnDisp)
        HeaderPanel.Controls.Add(lbltxtSelectMode)
        HeaderPanel.Controls.Add(Label2)
        HeaderPanel.Controls.Add(txtExamName)
        HeaderPanel.Controls.Add(lblStudyDate)
        HeaderPanel.Controls.Add(StudyDate)
        HeaderPanel.Location = New Point(2, 12)
        HeaderPanel.Name = "HeaderPanel"
        HeaderPanel.Size = New Size(547, 75)
        HeaderPanel.TabIndex = 20
        ' 
        ' MForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(556, 539)
        Controls.Add(HeaderLine)
        Controls.Add(Panel1)
        Controls.Add(BodyPanel)
        Controls.Add(HeaderPanel)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Margin = New Padding(2)
        Name = "MForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "資格学習記録"
        Panel1.ResumeLayout(False)
        CType(numStudyTime, ComponentModel.ISupportInitialize).EndInit()
        CType(numProgress, ComponentModel.ISupportInitialize).EndInit()
        BodyPanel.ResumeLayout(False)
        BodyPanel.PerformLayout()
        HeaderPanel.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents cmd1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents txtExamName As MyControls.LabeledTextBox
    Friend WithEvents btnDisp As Button
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents Jukenbi As MyControls.DateYMD
    Friend WithEvents lblJukenbi As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents cmbResult As ComboBox
    Friend WithEvents lbltxtTargetDate As MyControls.LabeledTextBox
    Friend WithEvents btnRecord As Button
    Friend WithEvents lbltxtSelectMode As MyControls.LabeledTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents HeaderPanel As Panel

End Class
