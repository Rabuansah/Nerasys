Imports MySql.Data.MySqlClient

Public Class From1
    Private Sub txtUser_MouseEnter(sender As Object, e As EventArgs) Handles txtUser.MouseEnter
        Dim colorText As Color
        colorText = Color.FromArgb(255, 0, 0, 0)
        If txtUser.Text = "Username" Then
            txtUser.Text = ""
            txtUser.ForeColor = colorText
        End If
    End Sub

    Private Sub txtUser_MouseLeave(sender As Object, e As EventArgs) Handles txtUser.MouseLeave
        Dim colorHint As Color
        colorHint = Color.FromArgb(200, 200, 200)
        If txtUser.Text = "" Then
            txtUser.Text = "Username"
            txtUser.ForeColor = colorHint
        End If
    End Sub

    Private Sub txtPassword_MouseEnter(sender As Object, e As EventArgs) Handles txtPassword.MouseEnter
        Dim colorText As Color
        colorText = Color.FromArgb(255, 0, 0, 0)
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = colorText
            txtPassword.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub txtPassword_MouseLeave(sender As Object, e As EventArgs) Handles txtPassword.MouseLeave
        Dim colorHint As Color
        colorHint = Color.FromArgb(200, 200, 200)
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = colorHint
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtUser.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Username dan Password Tidak Boleh Kosong")
        Else
            Try
                Call Koneksi()
                If Conn.State = ConnectionState.Closed Then Conn.Open()

                Cmd = New MySqlCommand("SELECT * FROM tbl_user WHERE username=@user AND password=@pass", Conn)
                Cmd.Parameters.AddWithValue("@user", txtUser.Text)
                Cmd.Parameters.AddWithValue("@pass", txtPassword.Text)

                Rd = Cmd.ExecuteReader()

                If Rd.HasRows Then
                    Rd.Read()
                    MsgBox("Login Berhasil, Selamat Datang " & Rd("username"))

                    Dim Form2 As New HalamanUtama
                    Form2.LoggedInUsername = txtUser.Text
                    Me.Hide()
                    Form2.Show()
                Else
                    MsgBox("Login Gagal. Username atau Password salah.")
                End If

                Rd.Close()
            Catch ex As Exception
                MsgBox("Terjadi kesalahan: " & ex.Message)
            End Try
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class
