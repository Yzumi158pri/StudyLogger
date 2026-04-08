Imports System.Windows.Forms

Public Class MessageUtil

    ''' <summary>
    ''' アプリタイトル
    ''' </summary>
    Private Shared ReadOnly AppTitle As String = "資格学習記録"

    ''' <summary>
    ''' フォームタイトル
    ''' </summary>
    Private Shared ReadOnly CheckTitle As String = "確認"

    ''' <summary>
    ''' メッセージを表示
    ''' </summary>
    ''' <param name="message">
    ''' 表示するメッセージ
    ''' </param>
    Public Shared Sub CtShowDialog(ByVal message As String)
        System.Windows.Forms.MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    ''' <summary>
    ''' はい/いいえ の確認ダイアログ
    ''' </summary>
    ''' <param name="message">
    ''' 表示するメッセージ
    ''' </param>
    Public Shared Function CtConfirm(ByVal message As String) As DialogResult
        Return MessageBox.Show(message, CheckTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function

    ''' <summary>
    ''' エラーダイアログ
    ''' </summary>
    ''' <param name="message"></param>
    Public Shared Sub CtShowErrorDialog(ByVal message As String)
        System.Windows.Forms.MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' チェックエラー・警告ダイアログ
    ''' </summary>
    ''' <param name="message"></param>
    Public Shared Sub CtShowChkErrDialog(message As String)
        System.Windows.Forms.MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
End Class
