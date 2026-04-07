Imports System
Imports System.Windows.Forms
Imports MyLib.MessageUtil


Public Class MForm

#Region "イベント"

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CtShowDialog("Hello, World.")
    End Sub

    ''' <summary>
    ''' cmd1のクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmd1_click(sender As Object, e As EventArgs) Handles cmd1.Click
        CtShowDialog("Button Clicked.")
    End Sub

    ''' <summary>
    ''' 終了ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' キーダウンイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Escキーが押されたか判定
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If CtConfirm("終了してよろしいですか？") = DialogResult.Yes Then
            CtShowDialog("Goodbye, World.")
        Else
            e.Cancel = True
        End If
    End Sub

#End Region

End Class
