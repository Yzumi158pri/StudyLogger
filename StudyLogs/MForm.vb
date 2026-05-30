Imports System
Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming
Imports DocumentFormat.OpenXml.Vml
Imports MyLib
Imports StudyLogs.My
Imports MyModules

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

        'フォーム全体にフォーカスイベントを設定
        SetFocusColorEvent(Me)

        'フォームの初期化
        initForm()

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
        If chkText() = False Then
            Return
        End If

        'ボディ部を表示
        dispBody()

        'MessageUtil.CtShowDialog(txtExamName.txtText)
    End Sub

    ''' <summary>
    ''' 出力ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOutput_click(sender As Object, e As EventArgs) Handles btnOutput.Click

        '入力チェック
        If chkText() = False Then
            Return
        End If

        '出力先
        Dim outPath As String = My.Settings.OutputPath

        '手動出力モードの場合
        If My.Settings.AutoOutput = False Then

            '出力先を設定
            Using fbd As New FolderBrowserDialog()
                fbd.Description = "出力先のフォルダを選択してください。"
                '現在のパスを初期値に設定
                fbd.SelectedPath = outPath
                If fbd.ShowDialog() = DialogResult.OK Then
                    outPath = fbd.SelectedPath
                    '出力処理
                    OutputUtil.outputText(txtExamName.txtText, outPath)
                End If
            End Using
        End If

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
                ' Enterキーが押されたら、Tabキーを送信して次のコントロールにフォーカスを移す
                SendKeys.SendWait("{TAB}")

                ' 元のEnterキーの動作を無効化（これをしないとEnterも入力されてしまう）
                e.SuppressKeyPress = True
        End Select
    End Sub

    ''' <summary>
    ''' フォームクローズイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageUtil.CtConfirm("終了してよろしいですか？") = DialogResult.Yes Then
            MessageUtil.CtShowDialog("Goodbye, World.")
            LogUtil.WriteLog("closed : " & Me.Name)
        Else
            e.Cancel = True
        End If
    End Sub


#End Region


#Region "処理"

    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    Private Sub initForm()

        'ボディ部は非活性
        BodyPanel.Enabled = False

    End Sub

    ''' <summary>
    ''' ボディ部の表示
    ''' </summary>
    Private Sub dispBody()

        SuspendLayout()

        'TODO - ボディ部の内容を設定する処理を実装

        'ボディ部を活性
        BodyPanel.Enabled = True

        ResumeLayout()

    End Sub

    ''' <summary>
    ''' テキストの入力チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function chkText() As Boolean

        If txtExamName.txtText.Trim() = String.Empty Then
            MessageUtil.CtShowChkErrDialog("値を入力してください")
            txtExamName.Focus()
            Return False
        Else
            Return True
        End If
    End Function




#End Region

End Class
