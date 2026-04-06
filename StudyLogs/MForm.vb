Imports System
Imports System.Windows.Forms

Public Class MForm

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim log As New OutPutLog()
        log.ShowDialog("Hello, World.")
    End Sub

    Private Sub cmd1_click(sender As Object, e As EventArgs) Handles cmd1.Click
        Dim log As New OutPutLog()
        log.ShowDialog("Button Clicked.")
    End Sub

End Class
