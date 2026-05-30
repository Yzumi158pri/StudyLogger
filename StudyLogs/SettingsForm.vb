Imports System.IO
Imports MyLib
Imports MyModules

Public Class SettingsForm

    ''' <summary>
    ''' 変更前の出力先パスを保持する変数
    ''' </summary>
    Dim outPathBefor As String

    ''' <summary>
    ''' 編集フラグ
    ''' </summary>
    Dim modFlg As Boolean = False

#Region "イベント"

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '初期化
        initForm()
        LogUtil.WriteLog("opened : " & Me.Name)

        'フォーム全体にフォーカスイベントを設定
        SetFocusColorEvent(Me)

    End Sub

    ''' <summary>
    ''' 更新ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpd_click(sender As Object, e As EventArgs) Handles btnUpd.Click

        Dim msg As String = ""
        Dim control As Control = Nothing
        '入力チェック
        If chkBody(msg, control) = False Then
            MessageUtil.CtShowChkErrDialog(msg)
            If control IsNot Nothing Then
                control.Focus()
            End If
            Return
        End If

        If MessageUtil.CtConfirm("保存しますか？") = DialogResult.No Then
            Return
        End If

        Try
            '更新処理
            updateSettings()
        Catch ex As Exception
            LogUtil.ShowExeption(ex)
        Finally
            MessageUtil.CtShowDialog("保存しました。")
            LogUtil.WriteLog("出力先を変更 → " & My.Settings.OutputPath)
            LogUtil.WriteLog("出力先変更前 → " & outPathBefor)
        End Try

    End Sub

    ''' <summary>
    ''' 再読み込みボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReset_click(sender As Object, e As EventArgs) Handles btnReset.Click

        Dim tmpPath As String = txtlblOutputPath.txtText
        If MessageUtil.CtConfirm("リセットしますか？") = DialogResult.No Then
            Return
        Else
            initForm()
        End If

        MessageUtil.CtShowDialog("リセットしました。")

        'リセット前後で値が異なる場合のみログ出力
        If outPathBefor <> txtlblOutputPath.txtText Then
            LogUtil.WriteLog("出力先をリセット → " & My.Settings.OutputPath)
            LogUtil.WriteLog("出力先リセット前 → " & tmpPath)
        End If
    End Sub

    ''' <summary>
    ''' フォルダ参照ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRef_click(sender As Object, e As EventArgs) Handles btnRef.Click
        Try
            Using fbd As New FolderBrowserDialog()
                fbd.Description = "出力先のフォルダを選択してください。"
                ' 現在のパスを初期値に設定
                fbd.SelectedPath = txtlblOutputPath.txtText
                If fbd.ShowDialog() = DialogResult.OK Then
                    txtlblOutputPath.txtText = fbd.SelectedPath
                    '編集フラグON
                    modFlg = True
                End If
            End Using
        Catch ex As Exception
            LogUtil.ShowExeption(ex)
            MessageUtil.CtShowDialog("フォルダの参照に失敗しました。")
        End Try
    End Sub

    ''' <summary>
    ''' 終了ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExit_click(sender As Object, e As EventArgs) Handles btnExit.Click

        '値が変更されているなら確認
        If modFlg Then

            Dim msg As String = "値が変更された可能性があります。" &
                                vbCrLf & "保存せずに終了してよろしいですか？"

            If MessageUtil.CtConfirm(msg) = DialogResult.No Then
                Return
            End If
        End If

        Me.Close()
        LogUtil.WriteLog("closed : " & Me.Name)

    End Sub

    ''' <summary>
    ''' ラジオボタン選択イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub radOutput_CheckedChanged(sender As Object, e As EventArgs) Handles radAutoOutput.CheckedChanged, radManualOutput.CheckedChanged

        '編集フラグON
        modFlg = True

        'どちらか一方が選択されたらもう一方の選択を解除する
        If radAutoOutput.Checked Then
            radManualOutput.Checked = False

        ElseIf radManualOutput.Checked Then
            radAutoOutput.Checked = False
        End If
    End Sub

    ''' <summary>
    ''' テキスト変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtlbl_TextChanged(sender As Object, e As EventArgs) Handles txtlblOutputPath.TextChanged, txtlblUserName.TextChanged
        '編集フラグON
        modFlg = True
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
#End Region


#Region "共通処理"

    ''' <summary>
    ''' 出力先パスの更新処理
    ''' </summary>
    Private Sub updateSettings()

        '更新
        My.Settings.OutputPath = txtlblOutputPath.txtText
        My.Settings.AutoOutput = radAutoOutput.Checked
        My.Settings.UserName = txtlblUserName.txtText
        My.Settings.Save()

        '再読み込み
        initForm()

    End Sub

    ''' <summary>
    ''' フォームの初期化処理
    ''' </summary>
    Private Sub initForm()

        '出力先
        txtlblOutputPath.txtText = My.Settings.OutputPath
        outPathBefor = My.Settings.OutputPath

        '出力モード
        If My.Settings.AutoOutput Then
            radAutoOutput.Checked = True
            radManualOutput.Checked = False
        Else
            radAutoOutput.Checked = False
            radManualOutput.Checked = True
        End If

        '編集フラグOFF
        modFlg = False

    End Sub

    ''' <summary>
    ''' 更新前の入力チェック処理
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <param name="msg"></param>
    ''' <returns></returns>
    Private Function chkBody(ByRef msg As String, ByRef control As Control) As Boolean
        '入力値の変更チェック
        If modFlg = False Then
            msg = "編集されていません。"
            Return False
        End If

        '必須チェック
        If txtlblOutputPath.txtText.Trim() = String.Empty Then
            msg = "出力先は必須入力です。"
            control = txtlblOutputPath
            Return False
        End If


        'ファイルパスチェック
        If IsValidPath(txtlblOutputPath.txtText) = False Then
            msg = "不正な出力先です。"
            control = txtlblOutputPath
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' ファイルパスチェック処理
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Private Function IsValidPath(path As String) As Boolean
        If String.IsNullOrWhiteSpace(path) Then Return False

        Try
            '基本的な書式チェック（ここで例外が出るものは即NG）
            Dim fullPath As String = System.IO.Path.GetFullPath(path)

            '絶対パスであることを確認
            If Not System.IO.Path.IsPathRooted(path) Then Return False

            'ドライブの実在確認
            Dim driveRoot As String = System.IO.Path.GetPathRoot(fullPath)

            'システム上の有効なドライブ一覧を取得して照合
            Dim driveExists As Boolean = DriveInfo.GetDrives().Any(
                Function(d) String.Equals(d.Name, driveRoot, StringComparison.OrdinalIgnoreCase)
            )

            If Not driveExists Then
                'ドライブ自体が存在しない
                Return False
            End If

            'パス全体にワイルドカードが含まれていないかチェック
            If path.Contains("*") OrElse path.Contains("?") Then Return False

            'ファイル名として解釈される部分に禁止文字がないか
            Dim fileName As String = System.IO.Path.GetFileName(path)
            If Not String.IsNullOrEmpty(fileName) Then
                If fileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0 Then Return False

                '拡張子があるか
                If System.IO.Path.HasExtension(fileName) Then Return False
            End If

            'パス全体の禁止文字チェック
            If path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0 Then Return False

            Return True
        Catch ex As Exception
            LogUtil.ShowExeption(ex)
            Return False
        End Try
    End Function

#End Region

End Class