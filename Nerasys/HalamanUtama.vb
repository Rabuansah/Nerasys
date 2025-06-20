Public Class HalamanUtama
    Public Property LoggedInUsername As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Form1 As New From1
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        FormUser.ShowDialog()
    End Sub

    Private Sub HalamanUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Login sebagai: " & LoggedInUsername
    End Sub
End Class