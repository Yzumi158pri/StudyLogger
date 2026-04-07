Imports System.IO
Imports System.Text

Public Class LogUtil
    Public Sub New()
    End Sub


    ' ログを保存するフォルダパス（例：実行ファイルと同じ場所のLogフォルダ）
    Private Shared ReadOnly LogDirPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log")

    Public Shared Sub WriteLog(message As String)
        Try
            ' 1. フォルダがなければ作成
            If Not Directory.Exists(LogDirPath) Then
                Directory.CreateDirectory(LogDirPath)
            End If

            ' 2. ファイル名を決定（1日ごとにファイル分ける：Log_20260407.log）
            Dim fileName As String = $"Log_{DateTime.Now:yyyyMMdd}.log"
            Dim filePath As String = Path.Combine(LogDirPath, fileName)

            ' 3. ログ内容の組み立て
            Dim logLine As String = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} : {message}{Environment.NewLine}"

            ' 4. ファイルへ追記（UTF-8, 共有モードを考慮した書き込み）
            ' AppendAllTextは自動でファイルを開閉してくれるので安全です
            File.AppendAllText(filePath, logLine, Encoding.UTF8)

            ' デバッグ出力にも表示
            Debug.Write(logLine)

        Catch ex As Exception
            ' ログ書き込み自体に失敗した場合はデバッグ出力のみ
            Debug.WriteLine($"ログ書き込み失敗: {ex.Message}")
        End Try
    End Sub

End Class
