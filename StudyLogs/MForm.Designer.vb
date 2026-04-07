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
        DateTimePicker1 = New DateTimePicker()
        lblDate = New Label()
        btnDisp = New Button()
        btnOutput = New Button()
        SuspendLayout()
        ' 
        ' cmd1
        ' 
        cmd1.Location = New Point(962, 594)
        cmd1.Name = "cmd1"
        cmd1.Size = New Size(94, 29)
        cmd1.TabIndex = 3
        cmd1.Text = "ボタンを押せ"
        cmd1.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(1079, 594)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(94, 29)
        btnExit.TabIndex = 4
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' TextLabel1
        ' 
        TextLabel1.LabelSize = New Size(53, 27)
        TextLabel1.LabelText = "入力"
        TextLabel1.LabelWidth = 53
        TextLabel1.Location = New Point(50, 105)
        TextLabel1.Name = "TextLabel1"
        TextLabel1.Size = New Size(345, 29)
        TextLabel1.TabIndex = 1
        TextLabel1.TextBoxSize = New Size(160, 27)
        TextLabel1.TextBoxText = ""
        TextLabel1.TextBoxWidth = 160
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(102, 57)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(159, 27)
        DateTimePicker1.TabIndex = 0
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
        btnDisp.Location = New Point(271, 105)
        btnDisp.Name = "btnDisp"
        btnDisp.Size = New Size(50, 29)
        btnDisp.TabIndex = 5
        btnDisp.Text = "表示"
        btnDisp.UseVisualStyleBackColor = True
        ' 
        ' btnOutput
        ' 
        btnOutput.Location = New Point(841, 594)
        btnOutput.Name = "btnOutput"
        btnOutput.Size = New Size(94, 29)
        btnOutput.TabIndex = 6
        btnOutput.Text = "出力"
        btnOutput.UseVisualStyleBackColor = True
        ' 
        ' MForm
        ' 
        ClientSize = New Size(1185, 635)
        Controls.Add(btnOutput)
        Controls.Add(btnDisp)
        Controls.Add(lblDate)
        Controls.Add(DateTimePicker1)
        Controls.Add(TextLabel1)
        Controls.Add(btnExit)
        Controls.Add(cmd1)
        KeyPreview = True
        Name = "MForm"
        Text = "資格学習記録"
        ResumeLayout(False)

    End Sub

    Friend WithEvents cmd1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents TextLabel1 As MyControls.LabeledTextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents btnDisp As Button
    Friend WithEvents btnOutput As Button

End Class
