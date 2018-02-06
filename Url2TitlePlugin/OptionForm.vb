Public Class OptionForm

    Public Property Template() As String
        Get
            Return Me.TemplateTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.TemplateTextBox.Text = value
        End Set
    End Property

    Public Property TimeOut() As Integer
        Get
            Return CInt(Me.TimeOutNumericUpDown.Value)
        End Get
        Set(ByVal value As Integer)
            Me.TimeOutNumericUpDown.Value = value
        End Set
    End Property

    Public Property Extensions() As String
        Get
            Return Me.ExtensionsTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.ExtensionsTextBox.Text = value
        End Set
    End Property



    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class