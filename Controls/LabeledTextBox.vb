Imports System.ComponentModel
Imports System.Drawing

Public Class LabeledTextBox

#Region "プロパティ"

    ''' <summary>
    ''' ラベル部分のサイズを設定・取得します
    ''' </summary>
    <Category("デザイン")>
    <Description("ラベルの幅と高さを指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property LabelSize As Size
        Get
            Return Label1.Size
        End Get
        Set(value As Size)
            Label1.Size = value
            TextBox1.Location = New Point(Label1.Width, TextBox1.Location.Y)
            ResizeCnt()
            Me.PerformLayout()
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' ラベルの幅のみを個別に設定・取得したい場合
    ''' </summary>
    <Category("デザイン")>
    <Description("ラベルの幅を指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property LabelWidth As Integer
        Get
            Return Label1.Width
        End Get
        Set(value As Integer)
            Label1.Width = value
            TextBox1.Location = New Point(value, TextBox1.Location.Y)
            ResizeCnt()
            Me.PerformLayout()
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' テキストボックス部分のサイズを設定・取得します
    ''' </summary>
    <Category("デザイン")>
    <Description("テキストボックスの幅と高さを指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property TextBoxSize As Size
        Get
            Return TextBox1.Size
        End Get
        Set(value As Size)
            TextBox1.Size = value
            ResizeCnt()
            Me.PerformLayout()
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' テキストボックスの幅のみを個別に設定・取得したい場合
    ''' </summary>
    <Category("デザイン")>
    <Description("テキストボックスの幅を指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property TextBoxWidth As Integer
        Get
            Return TextBox1.Width
        End Get
        Set(value As Integer)
            TextBox1.Width = value
            ResizeCnt()
            Me.PerformLayout()
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' テキストボックスの水平方向の配置のみを個別に設定・取得したい場合
    ''' </summary>
    <Category("デザイン")>
    <Description("テキストボックスの文字の水平方向の配置を指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property TextBoxAlign As System.Windows.Forms.HorizontalAlignment
        Get
            Return TextBox1.TextAlign
        End Get
        Set(value As System.Windows.Forms.HorizontalAlignment)
            TextBox1.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' ラベルの水平方向の配置のみを個別に設定・取得したい場合
    ''' </summary>
    <Category("デザイン")>
    <Description("ラベルの文字の水平方向の配置を指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property LabelAlign As ContentAlignment
        Get
            Return Label1.TextAlign
        End Get
        Set(value As ContentAlignment)
            Label1.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' テキストボックスの改行の可否を個別に設定・取得したい場合
    ''' </summary>
    <Category("カスタム")>
    <Description("テキストボックスの改行の可否を指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property TextMultiline As Boolean
        Get
            Return TextBox1.Multiline
        End Get
        Set(value As Boolean)
            TextBox1.Multiline = value
        End Set
    End Property

    ''' <summary>
    ''' テキストボックスの活性状態を個別に設定・取得したい場合
    ''' </summary>
    <Category("カスタム")>
    <Description("テキストボックスの活性状態を指定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property TextEnable As Boolean
        Get
            Return TextBox1.Enabled
        End Get
        Set(value As Boolean)
            TextBox1.Enabled = value
        End Set
    End Property

    ''' <summary>
    ''' ラベルに表示する文字列を設定・取得します
    ''' </summary>
    <Category("表示")>
    <Description("ラベルに表示する文字列を設定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property lblText As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property

    ''' <summary>
    ''' テキストボックスの内容を設定・取得します
    ''' </summary>
    <Category("表示")>
    <Description("テキストボックスの内容を設定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property txtText As String
        Get
            Return TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
        End Set
    End Property

    ''' <summary>
    ''' テキストボックスの内容を設定・取得します
    ''' </summary>
    <Category("動作")>
    <Description("テキストボックスの最大文字列を設定します")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property txtMaxLength As Integer
        Get
            Return TextBox1.MaxLength
        End Get
        Set(value As Integer)
            TextBox1.MaxLength = value
        End Set
    End Property

#End Region

#Region "イベント"



    ' 必要に応じて、テキスト変更イベントなどを外に流すこともできます
    Public Event TextChangedCustom As EventHandler

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        RaiseEvent TextChangedCustom(Me, e)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        ResizeCnt()

    End Sub
#End Region

    Private Sub ResizeCnt()
        ' テキストボックスの高さと垂直位置を調整
        If TextBox1.Multiline Then
            ' 複数行ならコントロール高さに合わせる
            TextBox1.Height = Me.Height
            TextBox1.Top = 0
        Else
            ' 単一行の場合はフォントに基づく推奨高さを使って中央寄せする
            Dim preferred = TextBox1.PreferredHeight
            TextBox1.Height = Math.Min(preferred, Me.Height)
            TextBox1.Top = (Me.Height - TextBox1.Height) \ 2
            ' コントロール全体の高さをテキストボックスに合わせる
            Me.Height = TextBox1.Height + TextBox1.Top * 2
        End If

        ' ラベルの高さをコントロール全体に合わせる
        Label1.Height = Me.Height
        ' コントロール全体の幅をラベルとテキストボックスに合わせる
        Me.Width = Label1.Width + TextBox1.Width
    End Sub


End Class