Imports System.IO
Imports System.Reflection.Metadata
Imports System.Windows.Forms
Imports MyLib.LogUtil

Public Class OutputUtil


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
End Class
