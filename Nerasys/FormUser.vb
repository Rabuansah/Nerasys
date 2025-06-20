Imports MySql.Data.MySqlClient
Public Class FormUser
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button1.Text = "Input"
        Button2.Text = "Edit"
        Button3.Text = "Hapus"
        Button4.Text = "Tutup"
        Call Koneksi()
        Da = New MySqlDataAdapter("Select id_user,username,role from tbl_user", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_user")
        DataGridView1.DataSource = Ds.Tables("tbl_user")
        DataGridView1.ReadOnly = True

        If DataGridView1.Columns.Contains("id_user") Then
            DataGridView1.Columns("id_user").HeaderText = "ID"
            DataGridView1.Columns("username").HeaderText = "Username"
            DataGridView1.Columns("role").HeaderText = "Role"
        End If
    End Sub

    Sub SiapIsi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = False
        ComboBox1.Enabled = True
        ComboBox1.Items.Add("Admin")
        ComboBox1.Items.Add("User")
    End Sub

    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Kolom memenuhi lebar grid
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            .EnableHeadersVisualStyles = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect ' Klik 1 sel langsung pilih seluruh baris
            .ReadOnly = True ' Biar user nggak bisa edit langsung di grid
            .AllowUserToAddRows = False ' Hilangkan baris kosong di akhir
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
            Try
                Call Koneksi()
                Dim query As String = "SELECT IFNULL(MIN(t1.id_user + 1), 1) AS next_id
                               FROM tbl_user t1
                               WHERE NOT EXISTS (
                                   SELECT 1 FROM tbl_user t2 WHERE t2.id_user = t1.id_user + 1
                               )"
                Cmd = New MySqlCommand(query, Conn)
                Rd = Cmd.ExecuteReader()
                If Rd.Read() Then
                    TextBox3.Text = Rd("next_id").ToString()
                End If
                Rd.Close()
            Catch ex As Exception
                MsgBox("Gagal mengambil ID: " & ex.Message)
            End Try

            TextBox3.Enabled = False
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan Isi Semua Field")
            Else
                Try
                    Call Koneksi()

                    Dim query As String = "INSERT INTO tbl_user (id_user, username, password, role) VALUES (@id, @username, @password, @role)"
                    Cmd = New MySqlCommand(query, Conn)
                    Cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                    Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
                    Cmd.Parameters.AddWithValue("@password", TextBox2.Text)
                    Cmd.Parameters.AddWithValue("@role", ComboBox1.Text)

                    Cmd.ExecuteNonQuery()

                    MsgBox("Input Data Berhasil")
                    Call KondisiAwal()
                Catch ex As Exception
                    MsgBox("Gagal input data: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
            TextBox3.Enabled = True
            TextBox3.Focus()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan Isi Semua Field")
            Else
                Try
                    Call Koneksi()

                    Dim query As String = "UPDATE tbl_user SET username=@username, password=@password, role=@role WHERE id_user=@id"
                    Cmd = New MySqlCommand(query, Conn)
                    Cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                    Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
                    Cmd.Parameters.AddWithValue("@password", TextBox2.Text)
                    Cmd.Parameters.AddWithValue("@role", ComboBox1.Text)

                    Cmd.ExecuteNonQuery()

                    MsgBox("Input Data Berhasil")
                    Call KondisiAwal()
                Catch ex As Exception
                    MsgBox("Gagal input data: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox3.Text = "" Then
                MsgBox("Silahkan masukkan ID User terlebih dahulu.")
            Else
                Try
                    Call Koneksi()
                    Dim query As String = "SELECT * FROM tbl_user WHERE id_user = @id"
                    Cmd = New MySqlCommand(query, Conn)
                    Cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                    Rd = Cmd.ExecuteReader()

                    If Rd.Read() Then
                        TextBox1.Text = Rd("username").ToString()
                        TextBox2.Text = Rd("password").ToString()
                        ComboBox1.Text = Rd("role").ToString()
                        MsgBox("Data ditemukan. Silakan lakukan perubahan.")
                    Else
                        MsgBox("ID User tidak ditemukan.")
                        TextBox1.Clear()
                        TextBox2.Clear()
                        ComboBox1.SelectedIndex = -1
                    End If
                    Rd.Close()
                Catch ex As Exception
                    MsgBox("Terjadi kesalahan: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Tutup" Then
            Me.Close()
        Else
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Hapus" Then
            Button3.Text = "Delete"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
            TextBox3.Enabled = True
            TextBox3.Focus()
        Else
            If TextBox3.Text = "" Then
                MsgBox("Silahkan masukkan ID user yang akan dihapus.")
            Else
                Try
                    Call Koneksi()

                    ' Konfirmasi sebelum hapus
                    Dim result = MsgBox("Apakah Anda yakin ingin menghapus data ini?", vbYesNo + vbQuestion, "Konfirmasi")
                    If result = vbYes Then
                        Dim query As String = "DELETE FROM tbl_user WHERE id_user = @id"
                        Cmd = New MySqlCommand(query, Conn)
                        Cmd.Parameters.AddWithValue("@id", TextBox3.Text)

                        Cmd.ExecuteNonQuery()

                        MsgBox("Data berhasil dihapus.")
                        Call KondisiAwal()
                    End If
                Catch ex As Exception
                    MsgBox("Gagal menghapus data: " & ex.Message)
                End Try
            End If
        End If
    End Sub

End Class