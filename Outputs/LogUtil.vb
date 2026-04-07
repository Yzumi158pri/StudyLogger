Public Class LogUtil
    Public Sub New()
    End Sub



    Public Shared Sub WriteLog(message As String)
        ' ここにログファイルへの書き込み処理を記述
        ' 例: DateTime.Now と一緒にテキストファイルへ追記
        Debug.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss} : {message}")
    End Sub

End Class
