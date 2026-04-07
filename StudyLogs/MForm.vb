Imports System
Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming
Imports MyLib

Public Class MForm

#Region "イベント"

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageUtil.CtShowDialog("Hello, World.")
        LogUtil.WriteLog("opened : " & Me.Name)
    End Sub

    ''' <summary>
    ''' cmd1のクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmd1_click(sender As Object, e As EventArgs) Handles cmd1.Click
        MessageUtil.CtShowDialog("Button Clicked.")
    End Sub

    ''' <summary>
    ''' 表示ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDisp_Click(sender As Object, e As EventArgs) Handles btnDisp.Click
        MessageUtil.CtShowDialog(TextLabel1.TextBoxText)
    End Sub

    ''' <summary>
    ''' 出力ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOutput_click(sender As Object, e As EventArgs) Handles btnOutput.Click
        OutputUtil.outputText(TextLabel1.TextBoxText, My.Settings.OutputPath)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim settingsForm As New SettingsForm()
        settingsForm.ShowDialog()
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
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End Select
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageUtil.CtConfirm("終了してよろしいですか？") = DialogResult.Yes Then
            MessageUtil.CtShowDialog("Goodbye, World.")
            LogUtil.WriteLog("closed : " & Me.Name)
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub lblText1_Load(sender As Object, e As EventArgs) Handles TextLabel1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

    End Sub


#End Region

End Class
