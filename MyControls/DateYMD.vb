Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class DateYMD


#Region "変数"
    ''' <summary>
    ''' 必須入力かどうかを管理する変数
    ''' </summary>
    Private _mustInput As Boolean = False

    ' フォーカス時の色管理用
    Private _focusColor As Color = Color.LightYellow
    Private _defaultColor As Color = SystemColors.Window

    ' カレンダーを保持する変数（最初は空）
    Private WithEvents _popupCalendar As MonthCalendar

#End Region



#Region "プロパティ"
    ''' <summary>
    ''' 必須入力かどうかを個別に設定・取得したい場合
    ''' </summary>
    <Category("カスタム")>
    <Description("必須入力かどうかを指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property MustInput As Boolean
        Get
            Return _mustInput
        End Get
        Set(value As Boolean)
            _mustInput = value
            If _mustInput Then
                txtYear.BackColor = Color.LightPink
                txtMonth.BackColor = Color.LightPink
                txtDay.BackColor = Color.LightPink
            Else
                txtYear.BackColor = SystemColors.Window
                txtMonth.BackColor = SystemColors.Window
                txtDay.BackColor = SystemColors.Window
            End If
            Me.PerformLayout()
            Me.Invalidate()
        End Set
    End Property

#End Region

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

        If CType(sender, System.Windows.Forms.TextBox).Text <> "" Then
            Select Case CType(sender, System.Windows.Forms.TextBox).MaxLength
                Case 2
                    CType(sender, System.Windows.Forms.TextBox).Text = String.Format("{0:00}", CInt(CType(sender, System.Windows.Forms.TextBox).Text))
                Case 4
                    CType(sender, System.Windows.Forms.TextBox).Text = String.Format("{0:0000}", CInt(CType(sender, System.Windows.Forms.TextBox).Text))
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
        txtYear.Text = today.Year.ToString("0000")
        txtMonth.Text = today.Month.ToString("00")
        txtDay.Text = today.Day.ToString("00")
    End Sub

    ''' <summary>
    ''' 年・月・日をまとめてセットする共通メソッド
    ''' </summary>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <param name="day"></param>
    Public Sub setYMD(year As Integer, month As Integer, day As Integer)
        SetYear(year)
        SetMonth(month)
        SetDay(day)
    End Sub


    ''' <summary>
    ''' 年・月・日をまとめてセットする共通メソッド
    ''' </summary>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <param name="day"></param>
    Public Sub setYMD(YMDtext As String)
        Dim YMD As DateTime

        If DateTime.TryParseExact(YMDtext, "yyyy/MM/dd", Nothing, Globalization.DateTimeStyles.None, YMD) Then
            ' 変換成功
            txtYear.Text = YMD.Year.ToString("0000")
            txtMonth.Text = YMD.Month.ToString("00")
            txtDay.Text = YMD.Day.ToString("00")

        Else
            initYMDDesign()
        End If
    End Sub

    ''' <summary>
    ''' 年をセットする共通メソッド
    ''' </summary>
    Public Sub SetYear(year As Integer)
        txtYear.Text = year.ToString("0000")
    End Sub

    ''' <summary>
    ''' 月をセットする共通メソッド
    ''' </summary>
    Public Sub SetMonth(month As Integer)
        txtMonth.Text = month.ToString("00")
    End Sub

    ''' <summary>
    ''' 日をセットする共通メソッド
    ''' </summary>
    Public Sub SetDay(day As Integer)
        txtDay.Text = day.ToString("00")
    End Sub

    ''' <summary>
    ''' テキストボックスを空にする共通メソッド
    ''' </summary>
    Public Sub initYMDDesign()
        txtYear.Text = String.Empty
        txtMonth.Text = String.Empty
        txtDay.Text = String.Empty
    End Sub

    ''' <summary>
    ''' テキストボックスの内容を「yyyy/MM/dd」の形式で返す共通メソッド
    ''' </summary>
    ''' <param name="splitFlg">
    ''' True:「yyyy/MM/dd」の形式で返す
    ''' False:「yyyyMMdd」の形式で返す
    ''' </param>
    ''' <returns></returns>
    Public Function GetDate(Optional splitFlg As Boolean = False) As String
        Dim datesStr As String
        If splitFlg Then
            datesStr = txtYear.Text + "/" + txtMonth.Text + "/" + txtDay.Text
        Else
            datesStr = txtYear.Text + txtMonth.Text + txtDay.Text
        End If
        Return datesStr
    End Function

    Public Function GetDateTime() As DateTime
        Dim dateStr As String = txtYear.Text + "/" + txtMonth.Text + "/" + txtDay.Text
        Dim result As DateTime
        If DateTime.TryParse(dateStr, result) Then
            Return result
        Else
            Return Nothing
        End If
    End Function

End Class
