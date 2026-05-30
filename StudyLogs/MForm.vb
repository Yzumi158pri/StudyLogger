Imports System
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Vml
Imports MyControls
Imports MyLib
Imports MyLib.FileUtil
Imports MyModules
Imports StudyLogs.My

Public Class MForm

#Region "変数"

    ''' <summary>
    ''' Excelファイルの存在フラグ
    ''' </summary>
    Private createExcelFlg As Boolean = False

    ''' <summary>
    ''' Excelシートの存在フラグ
    ''' </summary>
    Private createSheetFlg As Boolean = False

#End Region


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
                    FileUtil.outputText(txtExamName.txtText, outPath)
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
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' 1. Enterキーが押された場合の処理
        If keyData = Keys.Enter Then

            ' Shiftキーが同時に押されているかどうかを判定
            Dim isShiftPressed As Boolean = ((keyData And Keys.Modifiers) = Keys.Shift)

            'コントロールがテキストかつマルチラインの場合は、Shift+Enterで改行させる
            Dim isMultilineTextBox As Boolean = False
            If TypeOf Me.ActiveControl Is LabeledTextBox Then
                isMultilineTextBox = DirectCast(Me.ActiveControl, LabeledTextBox).TextMultiline
            End If

            If isShiftPressed AndAlso isMultilineTextBox Then
                ' 通常の改行動作をさせたいので、横取りせずにWindows（Base）に処理を戻す
                Return MyBase.ProcessCmdKey(msg, keyData)

            Else
                ' Shift+Enterで前のコントロールへフォーカスを移動する（False:前方へ移動、True:タブストップのみ、True:ラップする）
                Me.SelectNextControl(Me.ActiveControl, False, True, True, True)
                Return True
            End If

            ' 次のコントロールへフォーカスを移動する（True:前方へ移動、True:タブストップのみ、True:ラップする）
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

            ' Trueを返すことで、「このキー入力は処理済みなので、これ以上何もするな（改行するな）」とOSに伝えます
            Return True
        End If

        ' 2. Escapeキーが押された場合の処理
        If keyData = Keys.Escape Then
            Me.Close()
            Return True
        End If

        ' Enter/Escape以外のキーは、通常の処理（デフォルトの動作）に任せる
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

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

        Dim existExcelResult As FileUtil.existExcel
        Dim existSheetResult As FileUtil.existSheet
        Dim dispFlg As Boolean = True

        Dim items As FileUtil.ExcelItems = New FileUtil.ExcelItems()

        Dim excelFile As String = String.Empty

        Try

            If My.Settings.AutoOutput = False Then
                '出力先を設定
                Using fbd As New FolderBrowserDialog()
                    fbd.Description = "読み取りたいExcelファイルを選択してください。"
                    '現在のパスを初期値に設定
                    fbd.SelectedPath = My.Settings.OutputPath
                    If fbd.ShowDialog() = DialogResult.OK Then
                        excelFile = fbd.SelectedPath
                    End If
                End Using
            Else
                '出力ファイルパスにExcelファイルが存在するかチェックする
                existExcelResult = FileUtil.isExistExcel(My.Settings.OutputPath, My.Settings.UserName, excelFile)
                '表示フラグ
                dispFlg = chkExcel(existExcelResult)
            End If

            If dispFlg = False Then
                Return
            ElseIf dispFlg = True AndAlso existExcelResult = FileUtil.existExcel.EXIST Then


                'Excelファイルが存在する場合はシートの存在もチェックする

                Using workbook As New XLWorkbook(excelFile)
                    existSheetResult = FileUtil.isExistSheet(workbook, txtExamName.txtText)

                    If existSheetResult = FileUtil.existSheet.EXIST Then
                        'シートが存在する場合は内容を読み取る
                        items = FileUtil.ReadSheet(workbook, txtExamName.txtText)


                        If items Is Nothing Then
                            Dim msg As String = "読み込んだファイルが正しくありません。" & vbCrLf _
                                                & "ファイルの内容を確認してください" & vbCrLf _
                                                & "ファイルパス：" & excelFile & vbCrLf _
                                                & "シート名：" & txtExamName.txtText
                            MessageUtil.CtShowChkErrDialog(msg)
                        End If


                    ElseIf existSheetResult = FileUtil.existSheet.NOT_EXIST Then
                        'シートが存在しない場合は新規作成するか確認する
                        Dim msg As String = "シートがありません。" & vbCrLf _
                                                & "新規作成しますか？"
                        If MessageUtil.CtConfirm(msg) = DialogResult.Yes Then
                            createSheetFlg = True
                        Else
                            dispFlg = False
                        End If
                    Else
                        dispFlg = False
                    End If
                End Using


            End If

            '表示処理
            If dispFlg Then
                SuspendLayout()

                'ボディ部の内容を設定する処理を実装
                setBody(items)


                'ボディ部を活性
                BodyPanel.Enabled = True

                '学習時間をフォーカス
                numStudyTime.Focus()

                ResumeLayout()

            Else
                Return
            End If



        Catch ex As Exception
            LogUtil.ShowExeption(ex)

            Dim msg As String = "表示処理が異常終了しました。"
            If existExcelResult = FileUtil.existExcel.AN_EERROR Then
                msg = msg & vbCrLf & "Excelファイルの存在確認中にエラーが発生しました。"
            ElseIf existSheetResult = FileUtil.existSheet.AN_EERROR Then
                msg = msg & vbCrLf & "Excelシートの存在確認中にエラーが発生しました。"
            End If

            MessageUtil.CtShowErrorDialog(msg)
            Return
        End Try

    End Sub


    ''' <summary>
    ''' ボディ部の内容を設定する処理
    ''' </summary>
    ''' <param name="items">Excelから読み取った内容</param>
    Private Sub setBody(items As ExcelItems)

        lbltxtTargetDate.txtText = items.targetDate
        SumStudyTime.Text = items.sumStudyTime
        Jukenbi.setYMD(items.jukenbi)
        cmbResult.Text = items.result

        txtStudyContent.txtText = items.studyContent
        txtRemarks.txtText = items.remarks



    End Sub

    ''' <summary>
    ''' テキストの入力チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function chkText() As Boolean

        If txtExamName.txtText.Trim() = String.Empty Then
            MessageUtil.CtShowChkErrDialog("資格名を入力してください")
            txtExamName.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Excelファイルの存在チェック
    ''' ボディを表示するかどうかを判断する
    ''' </summary>
    ''' <param name="existExcel"></param>
    ''' <returns>
    ''' True：Excelファイルが存在する、または新規作成することに同意した場合
    ''' False：Excelファイルのパスが存在しない、または新規作成することに同意しなかった場合
    ''' </returns>
    Private Function chkExcel(existExcel As FileUtil.existExcel) As Boolean
        Select Case existExcel
            ' Excelファイルが存在する場合の処理
            Case FileUtil.existExcel.EXIST
                Return True


            ' Excelファイルが存在しない場合の処理
            Case FileUtil.existExcel.NOT_EXIST
                Dim msg As String = "ファイルがありません。" & vbCrLf _
                                            & "新規作成しますか？"

                '新規作成するか確認
                If MessageUtil.CtConfirm(msg) = DialogResult.Yes Then
                    createExcelFlg = True
                    Return True
                Else
                    Return False
                End If

            ' パスが存在しない場合の処理
            Case FileUtil.existExcel.NOT_PATH
                MessageUtil.CtShowErrorDialog("Excelファイルのパスが存在しません。パス：" & My.Settings.OutputPath)
                Return False

            ' 予期せぬエラーの場合の処理
            Case FileUtil.existExcel.AN_EERROR
                MessageUtil.CtShowErrorDialog("Excelファイルの存在確認中にエラーが発生しました。")
                Return False

        End Select
        'どれにも引っかからない場合はFalseを返す
        Return False
    End Function



#End Region

End Class
