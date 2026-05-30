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
        Public Property studyTime As String
        ''' <summary>学習内容</summary>
        Public Property studyContent As String
        ''' <summary>進捗状況</summary>
        Public Property progress As String
        ''' <summary>備考</summary>
        Public Property remarks As String


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
    ''' <summary>Excel出力用のテンプレートファイルパス</summary>
    Private Const TEMPLATE_FILE_PATH As String = "C:\Users\yuki_\source\repos\StudyLogs\StudyLogs\Resources\"

    ''' <summary>読み込み用Excelファイル名パターン</summary>
    Private Const FILE_NAME_PATTERN As String = "【資格学習記録】_"

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
    Public Shared Sub outputExcel()

    End Sub


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
    ''' <returns></returns>
    Public Shared Function ReadSheet(workBook As XLWorkbook, sheetName As String) As ExcelItems

        Dim items As ExcelItems = New ExcelItems()

        Dim workSheet As IXLWorksheet = workBook.Worksheet(sheetName)

        Dim table As IXLTable = workSheet.Tables.FirstOrDefault()

        If table Is Nothing Then
            Return Nothing
        End If



        With items
            'ヘッダ情報の取得
            .targetDate = workSheet.Cell(CellAddress.targetDate).GetString()
            .sumStudyTime = workSheet.Cell(CellAddress.sumStudyTime).GetString()
            .jukenbi = workSheet.Cell(CellAddress.jukenbi).GetValue(Of String)
            .result = workSheet.Cell(CellAddress.result).GetString()


            'テーブルの値は最終行を取得
            .studyContent = table.DataRange.LastRow().Field(CellAddress.studyContent).GetString()
            .progress = table.DataRange.LastRow().Field(CellAddress.progress).GetString()
            .remarks = table.DataRange.LastRow().Field(CellAddress.remarks).GetString()

        End With


        Return items

    End Function









#End Region

End Class
