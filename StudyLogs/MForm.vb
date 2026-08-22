Imports System
Imports System.Text
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Vml
Imports MyControls
Imports MyLib
Imports MyLib.FileUtil
Imports MyModules
Imports StudyLogs.My

Public Class MForm

#Region "定数"
    ''' <summary>
    ''' 登録モード
    ''' </summary>
    Private Enum Mode
        ''' <summary>
        ''' 新規登録モード
        ''' </summary>
        insert = 0
        ''' <summary>
        ''' 編集モード
        ''' </summary>
        update = 1
    End Enum

    ''' <summary>
    ''' 必須入力の背景色
    ''' </summary>
    Private mustInputColor As System.Drawing.Color = System.Drawing.Color.LightPink

#End Region


#Region "変数"

    ''' <summary>
    ''' Excelファイルの存在フラグ
    ''' </summary>
    Private createExcelFlg As Boolean = False

    ''' <summary>
    ''' Excelシートの存在フラグ
    ''' </summary>
    Private createSheetFlg As Boolean = False

    ''' <summary>
    ''' Excelファイルのパスを保持する変数
    ''' </summary>
    Private excelFile As String = String.Empty

    ''' <summary>
    ''' シート名を保持する変数
    ''' </summary>
    Private sheetName As String = String.Empty

    ''' <summary>
    ''' 合計学習時間を保持する変数
    ''' </summary>
    Private tmpSumStudyTime As Integer = 0

    ''' <summary>
    ''' 学習時間を保持する変数
    ''' </summary>
    Private tmpNumStudyTime As Integer = 0
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
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)

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

        ' 実行ファイルがある場所の "Templates" フォルダ内のパスを取得
        Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Template", "【資格学習記録】_名前.xlsx")

        ' ファイルの存在確認
        If Not IO.File.Exists(templatePath) Then
            MessageUtil.CtShowDialog("テンプレートファイルが見つかりません。")
            Return
        Else
            MessageUtil.CtShowDialog("OK")
        End If
    End Sub

    ''' <summary>
    ''' 表示ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDisp_Click(sender As Object, e As EventArgs) Handles btnDisp.Click
        If chkHeadText() = False Then
            Return
        End If

        createExcelFlg = False
        createSheetFlg = False

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
        If chkHeadText() = False Then
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

    ''' <summary>
    ''' 設定ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

        If btnExit.Text = "中止" Then
            If MessageUtil.CtConfirm("中止してよろしいですか？") = DialogResult.Yes Then

                'ボディ部を非活性
                BodyPanel.Enabled = False
                numStudyTime.BackColor = SystemColors.Control

                resetBody()
                'ヘッダ部を活性
                HeaderPanel.Enabled = True
                btnExit.Text = "終了"
            End If
        Else
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 記録ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRecord_Click(sender As Object, e As EventArgs) Handles btnRecord.Click

        '入力チェック
        If chkBody() = False Then
            Return
        End If

        If MessageUtil.CtConfirm("Excelに記録しますか？") = DialogResult.No Then
            Return
        End If

        If StudyDate.GetDate() <> DateTime.Now.ToString("yyyyMMdd") Then
            Dim msg As String = "学習日：" & StudyDate.GetDate() & vbCrLf _
                            & "今日の日付：" & DateTime.Now.ToString("yyyy/MM/dd") & vbCrLf _
                            & "学習日が今日の日付と異なります。記録してもよろしいですか？"
            If MessageUtil.CtConfirm(msg) = DialogResult.No Then
                Return
            End If
        End If

        'Excelに記録する内容を保持するクラスのインスタンスを生成
        Dim item As ExcelItems = New ExcelItems()

        '記録内容をセット
        setExcelItem(item)

        'Excelに記録する処理を実装
        If Not FileUtil.outputExcel(item, excelFile, sheetName, My.Settings.UserName, createExcelFlg, createSheetFlg) Then
            MessageUtil.CtShowErrorDialog("Excelへの出力に失敗しました。")
        Else
            MessageUtil.CtShowDialog("Excelに記録しました。" _
                                     & vbCrLf & "ファイルパス：" & excelFile _
                                     & vbCrLf & "シート名：" & sheetName)
            createExcelFlg = False
            createSheetFlg = False
            Dim strSumStudy As String = SumStudyTime.Text.Replace("時間", ":").Replace("分", "")
            tmpSumStudyTime = strSumStudy.Split(":").Select(Function(x) CInt(x)).Aggregate(Function(a, b) a * 60 + b)
            tmpNumStudyTime = CInt(numStudyTime.Value)

            'ボディの表示を終了
            'ボディ部を非活性
            BodyPanel.Enabled = False
            numStudyTime.BackColor = SystemColors.Control

            resetBody()
            'ヘッダ部を活性
            HeaderPanel.Enabled = True
            btnExit.Text = "終了"
        End If

    End Sub

    ''' <summary>
    ''' キーダウンイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Enterキーが押された場合
        If keyData = Keys.Enter Then

            ' Shiftキーが同時に押されているかどうかを判定
            Dim isShiftPressed As Boolean = ((keyData And Keys.Modifiers) = Keys.Shift)

            'コントロールがテキストかつマルチラインの場合は、Shift+Enterで改行させる
            Dim isMultilineTextBox As Boolean = False
            If TypeOf Me.ActiveControl Is LabeledTextBox Then
                isMultilineTextBox = DirectCast(Me.ActiveControl, LabeledTextBox).TextMultiline
            End If
            If isShiftPressed Then
                If isMultilineTextBox Then
                    ' 通常の改行動作をさせたいので、横取りせずにWindows（Base）に処理を戻す
                    Return MyBase.ProcessCmdKey(msg, keyData)
                Else
                    ' Shift+Enterで前のコントロールへフォーカスを移動する
                    Me.SelectNextControl(Me.ActiveControl, False, True, True, True)
                    Return True
                End If
            End If

            ' 次のコントロールへフォーカスを移動する
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

            Return True
        End If

        ' Escapeキーが押された場合の処理
        If keyData = Keys.Escape Then
            btnExit_Click(Nothing, Nothing)
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

    ''' <summary>
    ''' 学習時間の入力時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub numStudyTime_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles numStudyTime.Validating
        Dim hours As Integer
        Dim minites As Integer

        If SumStudyTime.Text.Trim() = String.Empty Then
            hours = CInt(numStudyTime.Value) \ 60
            minites = CInt(numStudyTime.Value) Mod 60
            SumStudyTime.Text = hours.ToString() & "時間" & minites.ToString() & "分"

        Else
            Dim totalMin As Integer = tmpSumStudyTime + CInt(numStudyTime.Value) - tmpNumStudyTime
            hours = totalMin \ 60
            minites = totalMin Mod 60
            SumStudyTime.Text = hours.ToString() & "時間" & minites.ToString() & "分"
        End If


    End Sub

    ''' <summary>
    ''' モード選択のテキスト変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lbltxtSelectMode_TextChanged(sender As Object, e As EventArgs) Handles lbltxtSelectMode.TextChangedCustom

        '全角数字を半角数字に変換する
        lbltxtSelectMode.txtText = StrConv(lbltxtSelectMode.txtText, VbStrConv.Narrow)

        '1,0以外が入力されている
        If lbltxtSelectMode.txtText <> String.Empty AndAlso lbltxtSelectMode.txtText <> CStr(Mode.insert) AndAlso lbltxtSelectMode.txtText <> CStr(Mode.update) Then
            'デフォルトは登録モード
            lbltxtSelectMode.txtText = CStr(Mode.insert)
            lbltxtSelectMode.TextBox.SelectionStart = lbltxtSelectMode.TextBox.Text.Length
        End If

        'モードによって学習日の活性/非活性を切り替える
        If lbltxtSelectMode.txtText = CStr(Mode.insert) Then
            StudyDate.SetToday()
            StudyDate.Enabled = False
        ElseIf lbltxtSelectMode.txtText = CStr(Mode.update) Then
            StudyDate.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' モード選択のテキストボックスにフォーカスが入ったときに全選択する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lbltxtSelectMode_Enter(sender As Object, e As EventArgs) Handles lbltxtSelectMode.Enter
        lbltxtSelectMode.TextBox.BeginInvoke(New Action(Sub() lbltxtSelectMode.TextBox.SelectAll()))
    End Sub

#End Region


#Region "処理"

    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    Private Sub initForm()

        'ボディ部は非活性
        BodyPanel.Enabled = False
        numStudyTime.BackColor = SystemColors.Control
        lbltxtSelectMode.txtText = CStr(Mode.insert)

    End Sub

    ''' <summary>
    ''' ボディ部の表示
    ''' </summary>
    Private Sub dispBody()

        Dim existExcelResult As FileUtil.existExcel
        Dim existSheetResult As FileUtil.existSheet
        Dim dispFlg As Boolean = True

        Dim items As FileUtil.ExcelItems = New FileUtil.ExcelItems()


        Try

            dispFlg = chkFile(existExcelResult)

            'チェックエラーであれば終了
            If dispFlg = False Then
                Return
            End If

            'ファイルが存在するならシートのチェックと取込を行う
            If dispFlg = True AndAlso existExcelResult = FileUtil.existExcel.EXIST Then

                If lbltxtSelectMode.txtText = CStr(Mode.insert) Then
                    dispFlg = chkSheet_insert(existSheetResult, items)
                ElseIf lbltxtSelectMode.txtText = CStr(Mode.update) Then
                    dispFlg = chkSheet_update(existSheetResult, items)
                End If



            End If

            '表示処理
            If dispFlg Then
                SuspendLayout()


                If Not createExcelFlg AndAlso Not createSheetFlg Then
                    'ボディ部の内容を設定する
                    setBody(items)

                Else
                    resetBody()
                End If

                'ボディ部を活性
                BodyPanel.Enabled = True
                numStudyTime.BackColor = mustInputColor

                'ヘッダ部を非活性
                HeaderPanel.Enabled = False
                btnExit.Text = "中止"

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
            'ボディを初期化
            resetBody()
            Return
        End Try

    End Sub

    ''' <summary>
    ''' Excelファイルの存在チェック
    ''' </summary>
    ''' <param name="result">Excelファイルの存在フラグ</param>
    ''' <returns>True：Excelファイルが存在する、または新規作成する場合
    '''          False：Excelファイルのパスが存在せず、新規作成しない場合
    ''' ></returns>
    Private Function chkFile(ByRef result As FileUtil.existExcel) As Boolean

        If My.Settings.AutoOutput = False Then
            '出力先を設定
            Using dlg As New OpenFileDialog()

                dlg.Title = "読み取りたいExcelファイルを選択してください。"
                dlg.Filter = "Excelファイル (*.xlsx)|*.xlsx|すべてのファイル (*.*)|*.*"
                '現在のパスを初期値に設定
                dlg.InitialDirectory = My.Settings.OutputPath
                If dlg.ShowDialog() = DialogResult.OK Then
                    excelFile = dlg.FileName
                Else
                    'キャンセルされた場合は処理を中止する
                    Return False
                End If
            End Using
            '手動出力モードの場合は、Excelファイルの存在チェックは行わず、選択されたファイルを使用する
            result = FileUtil.existExcel.EXIST
            Return True
        Else
            '出力ファイルパスにExcelファイルが存在するかチェックする
            result = FileUtil.isExistExcel(My.Settings.OutputPath, My.Settings.UserName, excelFile)
            '表示フラグ
            Return chkExcel(result)
        End If
    End Function

    ''' <summary>
    ''' シートチェックと取込（登録モード）
    ''' </summary>
    ''' <param name="result"></param>
    ''' <param name="items"></param>
    ''' <returns></returns>
    Private Function chkSheet_insert(ByRef result As FileUtil.existSheet, ByRef items As FileUtil.ExcelItems) As Boolean
        Using workbook As New XLWorkbook(excelFile)
            result = FileUtil.isExistSheet(workbook, txtExamName.txtText)

            If result = FileUtil.existSheet.EXIST Then
                'シートが存在する場合は内容を読み取る
                items = FileUtil.ReadSheet(workbook, txtExamName.txtText, True)

                'すでに今日の日付で登録されている
                If items.studyDate = StudyDate.GetDate(True) Then
                    Dim msg As String = "すでに今日の日付で登録されています。" & vbCrLf _
                                        & "訂正したい場合は、訂正モードで表示してください。" & vbCrLf _
                                        & "ファイルパス：" & excelFile & vbCrLf _
                                        & "シート名：" & txtExamName.txtText
                    MessageUtil.CtShowChkErrDialog(msg)
                    Return False
                End If


                If items Is Nothing Then
                    Dim msg As String = "読み込んだファイルが正しくありません。" & vbCrLf _
                                            & "ファイルの内容を確認してください" & vbCrLf _
                                            & "ファイルパス：" & excelFile & vbCrLf _
                                            & "シート名：" & txtExamName.txtText
                    MessageUtil.CtShowChkErrDialog(msg)
                    Return False
                End If
                Return True

            ElseIf result = FileUtil.existSheet.NOT_EXIST Then
                'シートが存在しない場合は新規作成するか確認する
                Dim msg As String = "シートがありません。" & vbCrLf _
                                            & "新規作成しますか？"
                If MessageUtil.CtConfirm(msg) = DialogResult.Yes Then
                    createSheetFlg = True
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Using
    End Function

    ''' <summary>
    ''' シートチェックと取込（登録モード）
    ''' </summary>
    ''' <param name="result"></param>
    ''' <param name="items"></param>
    ''' <returns></returns>
    Private Function chkSheet_update(ByRef result As FileUtil.existSheet, ByRef items As FileUtil.ExcelItems) As Boolean
        Using workbook As New XLWorkbook(excelFile)
            result = FileUtil.isExistSheet(workbook, txtExamName.txtText)

            If result = FileUtil.existSheet.EXIST Then
                'シートが存在する場合は内容を読み取る
                items = FileUtil.ReadSheet(workbook, txtExamName.txtText, False, StudyDate.GetDate(True))

                Select Case items.importResult
                    Case FileUtil.importResult.FAIL
                        Dim msg As String = "読み込んだファイルが正しくありません。" & vbCrLf _
                                            & "ファイルの内容を確認してください。" & vbCrLf _
                                            & "ファイルパス：" & excelFile & vbCrLf _
                                            & "シート名：" & txtExamName.txtText
                        MessageUtil.CtShowChkErrDialog(msg)
                        Return False
                    Case FileUtil.importResult.NONE_RECORD
                        Dim msg As String = "シートに存在しない日付が入力されています。" & vbCrLf _
                                            & $"学習日：{StudyDate.GetDate(True)}で新規登録を行います。"
                        MessageUtil.CtShowDialog(msg)
                        Return True
                    Case Else
                        Return True

                End Select
            Else
                Dim msg As String = "シートが存在しません。" & vbCrLf _
                                            & "ファイルの内容を確認してください。" & vbCrLf _
                                            & "ファイルパス：" & excelFile & vbCrLf _
                                            & "シート名：" & txtExamName.txtText
                MessageUtil.CtShowChkErrDialog(msg)
                Return False
            End If
        End Using
    End Function



    ''' <summary>
    ''' ボディ部の内容を設定する処理
    ''' </summary>
    ''' <param name="items">Excelから読み取った内容</param>
    Private Sub setBody(items As ExcelItems)

        lbltxtTargetDate.txtText = items.targetDate
        SumStudyTime.Text = items.sumStudyTime
        Jukenbi.setYMD(items.jukenbi)
        cmbResult.Text = items.result

        numStudyTime.Value = items.studyTime
        tmpNumStudyTime = items.studyTime
        txtStudyContent.txtText = items.studyContent.Replace(vbLf, vbCrLf).Replace(vbCr & vbCr, vbCr)
        numProgress.Value = items.progress * 100D
        txtRemarks.txtText = items.remarks.Replace(vbLf, vbCrLf).Replace(vbCr & vbCr, vbCr)

        Dim strSumStudy As String = items.sumStudyTime.Replace("時間", ":").Replace("分", "")
        tmpSumStudyTime = strSumStudy.Split(":").Select(Function(x) CInt(x)).Aggregate(Function(a, b) a * 60 + b)


    End Sub

    ''' <summary>
    ''' ボディ部の内容をリセットする処理
    ''' </summary>
    Private Sub resetBody()

        lbltxtTargetDate.txtText = String.Empty
        SumStudyTime.Text = String.Empty
        tmpSumStudyTime = 0
        numStudyTime.Value = 0
        tmpNumStudyTime = 0
        numProgress.Value = 0
        Jukenbi.initYMDDesign()
        cmbResult.SelectedIndex = -1
        txtStudyContent.txtText = String.Empty
        txtRemarks.txtText = String.Empty

    End Sub

    ''' <summary>
    ''' Excelに記録する内容を設定
    ''' </summary>
    Private Sub setExcelItem(ByRef item As ExcelItems)

        With item
            'ヘッダ部
            If createExcelFlg OrElse createSheetFlg Then
                .examName = txtExamName.txtText
            End If
            .targetDate = lbltxtTargetDate.txtText
            .jukenbi = Jukenbi.GetDate(True)
            .result = cmbResult.Text

            'テーブル部
            .studyDate = StudyDate.GetDate(True)
            .studyTime = CInt(numStudyTime.Value)
            .studyContent = txtStudyContent.txtText.Replace(vbCrLf, vbLf)
            .progress = CDec(numProgress.Value)
            .remarks = txtRemarks.txtText.Replace(vbCrLf, vbLf)

        End With
    End Sub


#Region "チェック"


    ''' <summary>
    ''' テキストの入力チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function chkHeadText() As Boolean

        If txtExamName.txtText.Trim() = String.Empty Then
            MessageUtil.CtShowChkErrDialog("資格名を入力してください")
            txtExamName.Focus()
            Return False
        End If

        If Convert.ToDateTime(StudyDate.GetDate(True)) > DateTime.Today Then
            MessageUtil.CtShowChkErrDialog("未来の日付は指定できません。")
            StudyDate.Focus()
            Return False
        End If

        sheetName = txtExamName.txtText
        Return True

    End Function


    ''' <summary>
    ''' ボディの入力チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function chkBody() As Boolean

        '学習時間の入力チェック
        If numStudyTime.Value <= 0 Then
            MessageUtil.CtShowChkErrDialog("学習時間は0より大きい値を入力してください")
            numStudyTime.Focus()
            Return False
        End If

        '取得目標時期の入力チェック
        If lbltxtTargetDate.txtText.Trim() = String.Empty Then
            MessageUtil.CtShowChkErrDialog("取得目標時期を入力してください")
            lbltxtTargetDate.Focus()
            Return False
        End If

        If StudyDate.GetDate() = String.Empty Then
            MessageUtil.CtShowChkErrDialog("学習日を入力してください")
            StudyDate.Focus()
            Return False
        End If


        If txtStudyContent.txtText.Trim() = String.Empty Then
            MessageUtil.CtShowChkErrDialog("学習内容を入力してください")
            txtStudyContent.Focus()
            Return False
        End If

        Return True
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
                    excelFile = IO.Path.Combine(My.Settings.OutputPath, FileUtil.FILE_NAME_PATTERN & My.Settings.UserName & ".xlsx")
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

#End Region

End Class
