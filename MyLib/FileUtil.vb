Imports System.IO
Imports System.Reflection.Metadata
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Spreadsheet
Imports MyLib.LogUtil

Public Class FileUtil

#Region "定数"

    ''' <summary>
    ''' Excel存在チェック結果
    ''' </summary>
    Public Enum existExcel

        ''' <summary>Excelファイルが存在する</summary>
        EXIST
        ''' <summary>Excelファイルが存在しない</summary>
        NOT_EXIST
        ''' <summary>パスがそもそも存在しない</summary>
        NOT_PATH
        ''' <summary>予期せぬエラー</summary>
        AN_EERROR
    End Enum

    ''' <summary>
    ''' Excel存在チェック結果
    ''' </summary>
    Public Enum existSheet

        ''' <summary>Excelファイルが存在する</summary>
        EXIST
        ''' <summary>Excelファイルが存在しない</summary>
        NOT_EXIST
        ''' <summary>予期せぬエラー</summary>
        AN_EERROR
    End Enum


    Public Enum importResult
        ''' <summary>取込成功</summary>
        SUCCESS
        ''' <summary>データなし(訂正モードの場合)</summary>
        NONE_RECORD
        ''' <summary>取込失敗</summary>
        FAIL
    End Enum

    ''' <summary>
    ''' Excelデータのクラス
    ''' 読み書きに使用する
    ''' </summary>
    Public Class ExcelItems

        ''' <summary>資格名</summary>
        Public Property examName As String
        ''' <summary>取得目標時期</summary>
        Public Property targetDate As String
        ''' <summary>合計学習時間</summary>
        Public Property sumStudyTime As String
        ''' <summary>受験日</summary>
        Public Property jukenbi As String
        ''' <summary>受験結果</summary>
        Public Property result As String
        ''' <summary>学習日付</summary>
        Public Property studyDate As String
        ''' <summary>学習時間</summary>
        Public Property studyTime As Integer
        ''' <summary>学習内容</summary>
        Public Property studyContent As String
        ''' <summary>進捗状況</summary>
        Public Property progress As Decimal
        ''' <summary>備考</summary>
        Public Property remarks As String
        ''' <summary>取込結果</summary>
        Public Property importResult As importResult

    End Class


    ''' <summary>
    ''' Excelシートのセルアドレス
    ''' 
    ''' ヘッダ部分はセルアドレス
    ''' テーブルは列名で管理
    ''' 
    ''' </summary>
    Public Class CellAddress
        ''' <summary>資格名</summary>
        Public Const examName As String = "C2"
        ''' <summary>取得目標時期</summary>
        Public Const targetDate As String = "C3"
        ''' <summary>合計学習時間</summary>
        Public Const sumStudyTime As String = "C4"
        ''' <summary>受験日</summary>
        Public Const jukenbi As String = "C5"
        ''' <summary>受験結果</summary>
        Public Const result As String = "C6"

        ''' <summary>学習日</summary>
        Public Const studyDate As String = "日付"
        ''' <summary>学習時間</summary>
        Public Const studyTime As String = "学習時間(分)"
        ''' <summary>学習内容/summary>
        Public Const studyContent As String = "内容"
        ''' <summary>進捗率</summary>
        Public Const progress As String = "進捗率"
        ''' <summary>備考</summary>
        Public Const remarks As String = "備考"


    End Class

    ''' <summary>Excel出力用のテンプレートファイル名</summary>
    Private Const TEMPLATE_FILE_NAME As String = "【資格学習記録】_名前.xlsx"
    ''' <summary>Excel出力用のテンプレートファイルのシート名</summary>
    Private Const TEMPLATE_SHEET_NAME As String = "tmp"
    ''' <summary>読み込み用Excelファイル名パターン</summary>
    Public Const FILE_NAME_PATTERN As String = "【資格学習記録】_"

#End Region

#Region "出力系"


    ''' <summary>
    ''' テキストを指定したパスに保存する
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="outputPath"></param>
    Public Shared Sub outputText(ByVal text As String, ByVal outputPath As String)

        Dim filename As String = "output_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt"
        Dim filePath As String = Path.Combine(outputPath, filename)

        Dim directoryPath As String = Path.GetDirectoryName(filePath)
        Try
            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
            End If
            File.WriteAllText(filePath, text, System.Text.Encoding.UTF8)

        Catch ex As Exception
            ShowExeption(ex)
        Finally
            MessageBox.Show("保存しました")
            WriteLog("保存しました: " & filePath)
        End Try
    End Sub

    ''' <summary>
    ''' Excelに出力する
    ''' </summary>
    Public Shared Function outputExcel(item As ExcelItems, excelPath As String, sheetName As String, userName As String, createExcel As Boolean, createSheet As Boolean) As Boolean


        Try
            'テンプレートファイルのパスを取得
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Template", "【資格学習記録】_名前.xlsx")
            If createExcel Then
                'Excelファイル作成フラグが立っている場合はテンプレートから新規作成する
                File.Copy(templatePath, excelPath, True)
            End If

            Using workBook As New XLWorkbook(excelPath)

                'シートを新規作成する場合はテンプレートからコピーしてくる
                If createSheet Then
                    Using tempBook As New XLWorkbook(templatePath)
                        Dim tempSheet As IXLWorksheet = tempBook.Worksheet(TEMPLATE_SHEET_NAME)
                        tempSheet.CopyTo(workBook, sheetName)
                    End Using
                End If

                'ファイルを新規作成した場合はシート名を設定
                If createExcel Then
                    Dim newSheet As IXLWorksheet = workBook.Worksheet(TEMPLATE_SHEET_NAME)
                    newSheet.Name = sheetName
                End If

                'シートを取得
                Dim workSheet As IXLWorksheet = workBook.Worksheet(sheetName)

                'Excelに書き込む
                With item
                    workSheet.Cell(CellAddress.examName).Value = .examName
                    workSheet.Cell(CellAddress.targetDate).Value = .targetDate
                    If .jukenbi <> "//" Then
                        workSheet.Cell(CellAddress.jukenbi).Value = .jukenbi
                    Else
                        workSheet.Cell(CellAddress.jukenbi).Value = "未定"
                    End If
                    workSheet.Cell(CellAddress.result).Value = .result


                    Dim table As IXLTable = workSheet.Tables.FirstOrDefault()
                    If table IsNot Nothing Then

                        'シートが新しい場合は最終行に書き込む。既にデータがある場合は最終行の下に新しい行を追加して書き込む。
                        If createExcel OrElse createSheet Then
                            table.Name = table.Name & workBook.Worksheets.Count.ToString()
                            Dim lastRow As IXLTableRow = table.DataRange.LastRow()
                            lastRow.Field(CellAddress.studyDate).Value = .studyDate
                            lastRow.Field(CellAddress.studyTime).Value = .studyTime
                            lastRow.Field(CellAddress.studyContent).Value = .studyContent
                            lastRow.Field(CellAddress.progress).Value = .progress / 100D
                            lastRow.Field(CellAddress.remarks).Value = .remarks
                        Else
                            Dim newRow As IXLTableRow = table.DataRange.LastRow().InsertRowsBelow(1).First()
                            newRow.Field(CellAddress.studyDate).Value = .studyDate
                            newRow.Field(CellAddress.studyTime).Value = .studyTime
                            newRow.Field(CellAddress.studyContent).Value = .studyContent
                            newRow.Field(CellAddress.progress).Value = .progress / 100D
                            newRow.Field(CellAddress.remarks).Value = .remarks
                        End If
                    End If

                    '合計学習時間の計算式を設定する（分単位で合計して、時間と分に分けて表示）
                    Dim timeFormula As String = $"=INT(SUM({table.Name}[学習時間(分)])/60) & ""時間"" & MOD(SUM({table.Name}[学習時間(分)]), 60) & ""分"""
                    workSheet.Cell(CellAddress.sumStudyTime).FormulaA1 = timeFormula
                End With

                workBook.Save()
            End Using

            Return True
        Catch ex As Exception
            LogUtil.ShowExeption(ex)
            Return False
        End Try





    End Function


#End Region

#Region "読み取り系"

    ''' <summary>
    ''' Excelファイルの存在確認する（自動出力モード）
    ''' </summary>
    ''' <param name="excelPath">Excelファイルのパス</param>
    ''' <param name="userName">ユーザ名</param>
    ''' <param name="foundFile">見つかったファイルのパス（見つかった場合）</param>
    ''' <returns></returns>
    Public Shared Function isExistExcel(excelPath As String, userName As String, ByRef foundFile As String) As existExcel


        Try
            '念のためパスの存在チェックをする
            If Not Directory.Exists(excelPath) Then
                LogUtil.WriteLog("Excelファイルのパスが存在しません。パス：" & excelPath)
                Return existExcel.NOT_PATH
            End If

            'ファイル名がパターンに合うファイルを検索
            '【資格学習記録】_ユーザ名*.xlsx
            Dim files As String() = Directory.GetFiles(excelPath, FILE_NAME_PATTERN & userName & "*.xlsx")

            'ファイルが見つからない場合は存在しないとする
            If files.Count = 0 Then
                Return existExcel.NOT_EXIST
            End If

            foundFile = files(0) '最初に見つかったファイルを返す（複数見つかる可能性があるため）

            Return existExcel.EXIST
        Catch ex As Exception
            Return existExcel.AN_EERROR
            Throw
        End Try

    End Function

    ''' <summary>
    ''' シート存在チェック
    ''' </summary>
    ''' <param name="workBook">開いているExcelワークブック</param>
    ''' <param name="sheetName">チェックするシート名</param>
    ''' <returns></returns>
    Public Shared Function isExistSheet(workBook As XLWorkbook, sheetName As String) As existSheet

        Try
            Dim workSheet As IXLWorksheet = Nothing
            If workBook.TryGetWorksheet(sheetName, workSheet) Then
                Return existSheet.EXIST

            Else
                Return existSheet.NOT_EXIST
            End If

        Catch ex As Exception
            Return existSheet.AN_EERROR
            Throw
        End Try

    End Function

    ''' <summary>
    ''' Excelシートからデータを読み取る
    ''' </summary>
    ''' <param name="workBook">開いているExcelワークブック</param>
    ''' <param name="sheetName">読み取るシート名</param>
    ''' <param name="insFlg">新規登録フラグ</param>
    ''' <returns></returns>
    Public Shared Function ReadSheet(workBook As XLWorkbook, sheetName As String, insFlg As Boolean, Optional ByVal studyDate As String = "") As ExcelItems

        Dim items As ExcelItems = New ExcelItems()

        Dim workSheet As IXLWorksheet = workBook.Worksheet(sheetName)

        Dim table As IXLTable = workSheet.Tables.FirstOrDefault()

        If table Is Nothing Then
            items.importResult = importResult.FAIL
            Return items
        End If



        With items
            'ヘッダ情報の取得
            .targetDate = workSheet.Cell(CellAddress.targetDate).GetString()
            .sumStudyTime = workSheet.Cell(CellAddress.sumStudyTime).GetString()
            .jukenbi = workSheet.Cell(CellAddress.jukenbi).GetValue(Of String)
            .result = workSheet.Cell(CellAddress.result).GetString()


            'テーブルの情報を取得
            If insFlg Then
                '新規登録の場合は最終行を取得
                .studyDate = table.DataRange.LastRow().Field(CellAddress.studyDate).GetString()
                .studyContent = table.DataRange.LastRow().Field(CellAddress.studyContent).GetString()
                If Not table.DataRange.LastRow().Field(CellAddress.progress).TryGetValue(Of Decimal)(.progress) Then
                    .progress = 0
                End If
                .remarks = table.DataRange.LastRow().Field(CellAddress.remarks).GetString()
                .importResult = importResult.SUCCESS
            Else
                '更新の場合は同じ日付の行を取得する
                Dim targetRow As IXLTableRow = table.DataRange.Rows().FirstOrDefault(Function(r) r.Field(CellAddress.studyDate).GetString() = studyDate)

                If targetRow IsNot Nothing Then
                    .studyTime = targetRow.Field(CellAddress.studyTime).GetValue(Of Integer)()
                    .studyContent = targetRow.Field(CellAddress.studyContent).GetString()
                    If Not targetRow.Field(CellAddress.progress).TryGetValue(Of Decimal)(.progress) Then
                        .progress = 0
                    End If
                    .remarks = targetRow.Field(CellAddress.remarks).GetString()
                    .importResult = importResult.SUCCESS

                Else
                    '更新モードで同じ日付の行が見つからなかった場合は、NONE_RECORDを返す
                    .importResult = importResult.NONE_RECORD
                End If

            End If

        End With


        Return items

    End Function









#End Region

End Class
