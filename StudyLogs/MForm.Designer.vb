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
        lblText1 = New MyControls.LabeledTextBox()
        SuspendLayout()
        ' 
        ' cmd1
        ' 
        cmd1.Location = New Point(521, 321)
        cmd1.Name = "cmd1"
        cmd1.Size = New Size(94, 29)
        cmd1.TabIndex = 0
        cmd1.Text = "ボタンを押せ"
        cmd1.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(1079, 594)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(94, 29)
        btnExit.TabIndex = 1
        btnExit.Text = "終了"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' lblText1
        ' 
        lblText1.Location = New Point(380, 195)
        lblText1.Name = "lblText1"
        lblText1.Size = New Size(207, 29)
        lblText1.TabIndex = 2
        ' 
        ' MForm
        ' 
        ClientSize = New Size(1185, 635)
        Controls.Add(lblText1)
        Controls.Add(btnExit)
        Controls.Add(cmd1)
        KeyPreview = True
        Name = "MForm"
        Text = "資格学習記録"
        ResumeLayout(False)

    End Sub

    Friend WithEvents cmd1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblText1 As MyControls.LabeledTextBox

End Class
