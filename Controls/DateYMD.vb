Imports System.Drawing
Imports System.Windows.Forms

Public Class DateYMD
    ' フォーカス時の色管理用
    Private _focusColor As Color = Color.LightYellow
    Private _defaultColor As Color = SystemColors.Window

    ' カレンダーを保持する変数（最初は空）
    Private WithEvents _popupCalendar As MonthCalendar

    ' カスタムコントロール（DatePickerYMD.vb）内のコード
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' デザイナー（設計画面）での動作でないことを確認
        If Not Me.DesignMode Then
            SetToday()
        End If
    End Sub




    ' カレンダーを表示するメソッド
    Private Sub btnCalendar_Click(sender As Object, e As EventArgs) Handles btnCalendar.Click
        ' カレンダーがまだ無ければ生成
        If _popupCalendar Is Nothing Then
            _popupCalendar = New MonthCalendar()
            _popupCalendar.MaxSelectionCount = 1
            _popupCalendar.Visible = False
        End If


        ' 1. 親フォームを取得
        Dim parentForm = Me.FindForm()
        If parentForm Is Nothing Then Return

        ' 2. 表示位置を計算（コントロールの左下の位置をフォーム基準で取得）
        ' Me.PointToScreen(New Point(0, Me.Height)) でコントロールの左下端のスクリーン座標を取得
        ' それを parentForm.PointToClient でフォーム内の相対座標に変換
        Dim spawnPoint = parentForm.PointToClient(Me.PointToScreen(New Point(0, Me.Height)))
        _popupCalendar.Location = spawnPoint

        ' 3. フォームのControlsに追加（まだ追加されていなければ）
        If Not parentForm.Controls.Contains(_popupCalendar) Then
            parentForm.Controls.Add(_popupCalendar)
        End If

        ' 4. 最前面に表示
        _popupCalendar.Visible = Not _popupCalendar.Visible
        _popupCalendar.BringToFront()
        _popupCalendar.Focus()
    End Sub


    Private Sub _popupCalendar_LostFocus(sender As Object, e As EventArgs) Handles _popupCalendar.LostFocus

        ' 1. マウスの現在のスクリーン座標を取得
        Dim mousePos As Point = Cursor.Position

        ' 2. ボタン（btnCalendar）のスクリーン上の範囲を取得
        ' RectangleToScreenを使えば、ボタンの正確な位置がわかる
        Dim btnRect As Rectangle = btnCalendar.RectangleToScreen(btnCalendar.ClientRectangle)

        ' 3. もしマウスがボタンの範囲内にあれば、Leaveの処理（非表示）はしない！
        '    あとのことはボタンの Click イベントにすべて任せる。
        If btnRect.Contains(mousePos) Then
            Return
        End If

        ' 4. ボタン以外の場所をクリックしたなら、カレンダーを閉じる
        _popupCalendar.Visible = False

    End Sub

    ''' <summary>
    ''' カレンダーで選択された日付を各txtに分解してセットします
    ''' </summary>
    Private Sub _popupCalendar_DateSelected(sender As Object, e As DateRangeEventArgs) Handles _popupCalendar.DateSelected
        Dim selectedDate = e.Start
        txtYear.Text = selectedDate.Year.ToString
        txtMonth.Text = selectedDate.Month.ToString("00")
        txtDay.Text = selectedDate.Day.ToString("00")
        _popupCalendar.Visible = False
    End Sub

    Private Sub txtYMD_Validated(sender As Object, e As EventArgs) Handles txtYear.Validated, txtMonth.Validated, txtDay.Validated

        If CType(sender, TextBox).Text <> "" Then
            Select Case CType(sender, TextBox).MaxLength
                Case 2
                    CType(sender, TextBox).Text = String.Format("{0:00}", CInt(CType(sender, TextBox).Text))
                Case 4
                    CType(sender, TextBox).Text = String.Format("{0:0000}", CInt(CType(sender, TextBox).Text))
            End Select
        End If

    End Sub

    Private Sub txtYMD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYear.KeyPress, txtMonth.KeyPress, txtDay.KeyPress
        ' 数字とバックスペース以外の入力を拒否
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 今日の日付を各テキストボックスにセットする共通メソッド
    ''' </summary>
    Public Sub SetToday()
        Dim today = DateTime.Today
        txtYear.Text = today.Year.ToString()
        txtMonth.Text = today.Month.ToString("00")
        txtDay.Text = today.Day.ToString("00")
    End Sub

    Private Sub initYMDDesign()
        txtYear.Text = String.Empty
        txtMonth.Text = String.Empty
        txtDay.Text = String.Empty
    End Sub

End Class
