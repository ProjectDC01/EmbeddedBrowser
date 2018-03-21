Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            Form1.IEWebBrowser(ComboBox1.Text).Navigate(TextBox1.Text)
        Else
            Form1.ChWebBrowser(ComboBox1.Text).Load(TextBox1.Text)
        End If

    End Sub
End Class