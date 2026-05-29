<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DateYMD
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnCalendar = New System.Windows.Forms.Button()
        txtYear = New System.Windows.Forms.TextBox()
        txtMonth = New System.Windows.Forms.TextBox()
        txtDay = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        SuspendLayout()
        ' 
        ' btnCalendar
        ' 
        btnCalendar.ForeColor = Drawing.SystemColors.ActiveBorder
        btnCalendar.Location = New System.Drawing.Point(121, 0)
        btnCalendar.Name = "btnCalendar"
        btnCalendar.Size = New System.Drawing.Size(29, 29)
        btnCalendar.TabIndex = 4
        btnCalendar.Text = "▼"
        btnCalendar.UseVisualStyleBackColor = True
        ' 
        ' txtYear
        ' 
        txtYear.ImeMode = System.Windows.Forms.ImeMode.Disable
        txtYear.Location = New System.Drawing.Point(0, 0)
        txtYear.MaxLength = 4
        txtYear.Name = "txtYear"
        txtYear.Size = New System.Drawing.Size(40, 27)
        txtYear.TabIndex = 1
        txtYear.Text = "YYYY"
        ' 
        ' txtMonth
        ' 
        txtMonth.ImeMode = System.Windows.Forms.ImeMode.Disable
        txtMonth.Location = New System.Drawing.Point(54, 0)
        txtMonth.MaxLength = 2
        txtMonth.Name = "txtMonth"
        txtMonth.Size = New System.Drawing.Size(25, 27)
        txtMonth.TabIndex = 2
        txtMonth.Text = "MM"
        ' 
        ' txtDay
        ' 
        txtDay.ImeMode = System.Windows.Forms.ImeMode.Disable
        txtDay.Location = New System.Drawing.Point(96, 0)
        txtDay.MaxLength = 2
        txtDay.Name = "txtDay"
        txtDay.Size = New System.Drawing.Size(25, 27)
        txtDay.TabIndex = 3
        txtDay.Text = "DD"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(40, 3)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(15, 20)
        Label1.TabIndex = 4
        Label1.Text = "/"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(81, 2)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(15, 20)
        Label2.TabIndex = 5
        Label2.Text = "/"
        ' 
        ' DateYMD
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(8.0F, 20.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtDay)
        Controls.Add(txtMonth)
        Controls.Add(txtYear)
        Controls.Add(btnCalendar)
        Name = "DateYMD"
        Size = New System.Drawing.Size(161, 28)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCalendar As System.Windows.Forms.Button
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
