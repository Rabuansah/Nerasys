Imports MySql.Data.MySqlClient

Public Class FormLogin
    Private Sub TxtUser_GotFocus(sender As Object, e As EventArgs) Handles txtUser.GotFocus
        If txtUser.Text = "Username" Then
            txtUser.Text = ""
            txtUser.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtUser_LostFocus(sender As Object, e As EventArgs) Handles txtUser.LostFocus
        If txtUser.Text = "" Then
            txtUser.Text = "Username"
            txtUser.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TxtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
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

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUser.Text = "Username"
        txtUser.ForeColor = Color.Gray

        txtPassword.Text = "Password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.UseSystemPasswordChar = False

        picTogglePassword.Image = My.Resources.eye_closed1
    End Sub

    Dim isPasswordVisible As Boolean = False
    Private Sub PicTogglePassword_Click(sender As Object, e As EventArgs) Handles picTogglePassword.Click
        If isPasswordVisible Then
            ' Hide password
            txtPassword.UseSystemPasswordChar = True
            picTogglePassword.Image = My.Resources.eye_closed1 ' Ganti sesuai nama resource
            isPasswordVisible = False
        Else
            ' Show password
            txtPassword.UseSystemPasswordChar = False
            picTogglePassword.Image = My.Resources.eye_open1
            isPasswordVisible = True
        End If
    End Sub
End Class
