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
            TextBox1.Size = New Size(Me.Width - value.Width - TextBox1.Location.X, TextBox1.Height)
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
        End Set
    End Property

#End Region

#Region "イベント"

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

    ' 必要に応じて、テキスト変更イベントなどを外に流すこともできます
    Public Event TextChangedCustom As EventHandler

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        RaiseEvent TextChangedCustom(Me, e)
    End Sub

#End Region

End Class