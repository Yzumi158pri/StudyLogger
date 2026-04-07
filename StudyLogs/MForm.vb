Imports System
Imports System.Windows.Forms
Imports Outputs

Public Class MForm

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OutPutLog.ShowDialog("Hello, World.")
    End Sub

    Private Sub cmd1_click(sender As Object, e As EventArgs) Handles cmd1.Click
        OutPutLog.ShowDialog("Button Clicked.")
    End Sub

End Class
