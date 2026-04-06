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
        SuspendLayout()
        ' 
        ' cmd1
        ' 
        cmd1.Location = New Point(516, 254)
        cmd1.Name = "cmd1"
        cmd1.Size = New Size(94, 29)
        cmd1.TabIndex = 0
        cmd1.Text = "ボタンを押せ"
        cmd1.UseVisualStyleBackColor = True
        ' 
        ' main
        ' 
        ClientSize = New Size(1185, 635)
        Controls.Add(cmd1)
        Name = "main"
        ResumeLayout(False)

    End Sub

    Friend WithEvents cmd1 As Button

End Class
