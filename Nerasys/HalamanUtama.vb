Public Class HalamanUtama
    Public Property LoggedInUsername As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Form1 As New FormLogin
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        FormUser.ShowDialog()
    End Sub

    Private Sub HalamanUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Login sebagai: " & LoggedInUsername
    End Sub

    Private Sub RubrikToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubrikToolStripMenuItem.Click
        Rubrik.ShowDialog()
    End Sub

    Private Sub KodeKelompokToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KodeKelompokToolStripMenuItem.Click
        FormGroup.ShowDialog()
    End Sub

    Private Sub KodeRekeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KodeRekeningToolStripMenuItem.Click
        FormRekening.ShowDialog()
    End Sub

    Private Sub TransaksiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem1.Click

    End Sub

    Private Sub JudulDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JudulDetailToolStripMenuItem.Click
        JudulDetail.ShowDialog()
    End Sub

    Private Sub NeracaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeracaToolStripMenuItem.Click
        Neraca.ShowDialog()
    End Sub
End Class