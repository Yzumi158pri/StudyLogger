Imports System.Drawing
Imports System.Windows.Forms


Public Module ControlHelper
    ''' <summary>
    ''' 指定したコンテナ内のTextBoxの場合にフォーカス時の色変更イベントを紐づけます
    ''' </summary>
    Public Sub SetFocusColorEvent(ByVal parent As Control)
        For Each c As Control In parent.Controls
            ' 対象のコントロールか判定
            If TypeOf c Is TextBox Then
                AddHandler c.Enter, AddressOf Control_Enter
                AddHandler c.Leave, AddressOf Control_Leave
            End If

            ' パネルやグループボックスの中も再帰的にチェック
            If c.HasChildren Then
                SetFocusColorEvent(c)
            End If
        Next
    End Sub

    ' --- 実際のイベントハンドラ ---

    Private Sub Control_Enter(sender As Object, e As EventArgs)
        Dim ctrl = DirectCast(sender, Control)
        ctrl.BackColor = Color.Yellow
    End Sub

    Private Sub Control_Leave(sender As Object, e As EventArgs)
        Dim ctrl = DirectCast(sender, Control)
        ctrl.BackColor = SystemColors.Window
    End Sub
End Module

