Imports MyLib

Public Class SettingsForm

    ''' <summary>
    ''' 変更前の出力先パスを保持する変数
    ''' </summary>
    Dim outPathBefor As String


    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        initForm()
        LogUtil.WriteLog("opened : " & Me.Name)

    End Sub

    Private Sub btnUpd_click(sender As Object, e As EventArgs) Handles btnUpd.Click

        Dim msg As String
        '入力チェック
        If chkBody(txtlblOutputPath.TextBoxText, msg) = False Then
            MessageUtil.CtShowChkErrDialog(msg)
            Return
        End If

        If MessageUtil.CtConfirm("保存しますか？") = DialogResult.No Then
            Return
        End If

        Try
            '更新処理
            updateOutputPath()
        Catch ex As Exception
            LogUtil.ShowExeption(ex)
        Finally
            MessageUtil.CtShowDialog("保存しました。")
            LogUtil.WriteLog("出力先を変更 → " & My.Settings.OutputPath)
            LogUtil.WriteLog("出力先変更前 → " & outPathBefor)
        End Try

    End Sub

    Private Function chkBody(ByVal strPath As String, ByRef msg As String) As Boolean
        If strPath = outPathBefor Then
            msg = "出力先が変更されていません。"
            Return False
        End If

        If IsValidPath(strPath) = False Then
            msg = "不正な出力先です。"
            Return False
        End If

        Return True
    End Function

    Private Function IsValidPath(path As String) As Boolean
        If String.IsNullOrWhiteSpace(path) Then Return False

        Try
            ' 2. パスとして不適切な文字（「*」「?」など）が含まれていないか
            ' ※不適切な文字が含まれていると、Path.GetFullPath は例外を投げます
            Dim fullPath As String = System.IO.Path.GetFullPath(path)

            ' 3. ルート（C:\など）が含まれているか、形式が正しいか
            ' (相対パスを禁止したい場合などに有効)
            If Not System.IO.Path.IsPathRooted(path) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnReset_click(sender As Object, e As EventArgs) Handles btnReset.Click

        Dim tmpPath As String = txtlblOutputPath.TextBoxText
        If MessageUtil.CtConfirm("リセットしますか？") = DialogResult.No Then
            Return
        Else
            initForm()
        End If

        MessageUtil.CtShowDialog("リセットしました。")

        'リセット前後で値が異なる場合のみログ出力
        If outPathBefor <> txtlblOutputPath.TextBoxText Then
            LogUtil.WriteLog("出力先をリセット → " & My.Settings.OutputPath)
            LogUtil.WriteLog("出力先リセット前 → " & tmpPath)
        End If
    End Sub

    Private Sub btnExit_click(sender As Object, e As EventArgs) Handles btnExit.Click

        If outPathBefor <> txtlblOutputPath.TextBoxText Then
            If MessageUtil.CtConfirm("保存せずに終了してよろしいですか？") = DialogResult.No Then
                Return
            End If
        End If

        Me.Close()
        LogUtil.WriteLog("closed : " & Me.Name)

    End Sub


#Region "共通処理"

    Private Sub updateOutputPath()

        My.Settings.OutputPath = txtlblOutputPath.TextBoxText
        My.Settings.Save()
        initForm()

    End Sub

    Private Sub initForm()
        txtlblOutputPath.TextBoxText = My.Settings.OutputPath
        outPathBefor = My.Settings.OutputPath
    End Sub

#End Region

End Class