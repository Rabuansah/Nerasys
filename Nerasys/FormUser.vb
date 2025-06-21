Imports MySql.Data.MySqlClient

Public Class FormUser
    Dim modeEdit As Boolean = False
    Dim idEditUser As String = ""

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        ComboBox1.Enabled = False
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.AddRange(New String() {"Admin", "User"})

        Button1.Text = "Add New User"
        Button2.Text = "Tutup"
        Button1.Enabled = True
        Button2.Enabled = True
        modeEdit = False
        idEditUser = ""

        TampilkanData()
    End Sub

    Sub TampilkanData()
        Call Koneksi()
        Da = New MySqlDataAdapter("SELECT id_user, username, role FROM tbl_user", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_user")

        Dim dt As DataTable = Ds.Tables("tbl_user")
        dt.Columns.Add("No", GetType(Integer))

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("No") = i + 1
        Next

        DataGridView1.DataSource = dt

        ' Sembunyikan id_user
        If DataGridView1.Columns.Contains("id_user") Then
            DataGridView1.Columns("id_user").Visible = False
        End If

        TambahTombolAksi()

        With DataGridView1
            If .Columns.Contains("No") Then .Columns("No").DisplayIndex = 0
            If .Columns.Contains("username") Then .Columns("username").DisplayIndex = 1
            If .Columns.Contains("role") Then .Columns("role").DisplayIndex = 2
            If .Columns.Contains("Edit") Then .Columns("Edit").DisplayIndex = 3
            If .Columns.Contains("Delete") Then .Columns("Delete").DisplayIndex = 4
        End With
    End Sub

    Sub TambahTombolAksi()
        If Not DataGridView1.Columns.Contains("Edit") Then
            Dim btnEdit As New DataGridViewButtonColumn()
            btnEdit.Name = "Edit"
            btnEdit.HeaderText = "Edit"
            btnEdit.Text = "Edit"
            btnEdit.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(btnEdit)
        End If

        If Not DataGridView1.Columns.Contains("Delete") Then
            Dim btnDelete As New DataGridViewButtonColumn()
            btnDelete.Name = "Delete"
            btnDelete.HeaderText = "Hapus"
            btnDelete.Text = "Hapus"
            btnDelete.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(btnDelete)
        End If
    End Sub

    Sub SiapIsi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        ComboBox1.Enabled = True
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            .EnableHeadersVisualStyles = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Add New User" Then
            Button1.Text = "Simpan"
            Button2.Text = "Batal"
            SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silakan isi semua field.")
                Exit Sub
            End If

            Try
                Call Koneksi()

                If Not modeEdit Then
                    Dim checkCmd = New MySqlCommand("SELECT COUNT(*) FROM tbl_user WHERE username = @username", Conn)
                    checkCmd.Parameters.AddWithValue("@username", TextBox1.Text)
                    Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Username sudah digunakan.")
                        Exit Sub
                    End If
                End If

                Dim query As String
                If modeEdit Then
                    query = "UPDATE tbl_user SET username=@username, password=@password, role=@role WHERE id_user=@id"
                Else
                    query = "INSERT INTO tbl_user (username, password, role) VALUES (@username, @password, @role)"
                End If

                Cmd = New MySqlCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
                Cmd.Parameters.AddWithValue("@password", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@role", ComboBox1.Text)
                If modeEdit Then Cmd.Parameters.AddWithValue("@id", idEditUser)

                Cmd.ExecuteNonQuery()
                MsgBox("Data berhasil disimpan.")
                KondisiAwal()
            Catch ex As Exception
                MsgBox("Terjadi kesalahan: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Tutup" Then
            Me.Close()
        Else
            KondisiAwal()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim idUser As String = DataGridView1.Rows(e.RowIndex).Cells("id_user").Value.ToString()

            If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
                Try
                    Call Koneksi()
                    Cmd = New MySqlCommand("SELECT * FROM tbl_user WHERE id_user = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", idUser)
                    Rd = Cmd.ExecuteReader()
                    If Rd.Read() Then
                        TextBox1.Text = Rd("username").ToString()
                        TextBox2.Text = Rd("password").ToString()
                        ComboBox1.Text = Rd("role").ToString()

                        SiapIsi()
                        modeEdit = True
                        idEditUser = idUser
                        Button1.Text = "Simpan"
                        Button2.Text = "Batal"
                    End If
                    Rd.Close()
                Catch ex As Exception
                    MsgBox("Gagal memuat data: " & ex.Message)
                End Try
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                If MsgBox("Yakin ingin menghapus user ini?", vbYesNo + vbQuestion, "Konfirmasi") = vbYes Then
                    Try
                        Call Koneksi()
                        Cmd = New MySqlCommand("DELETE FROM tbl_user WHERE id_user = @id", Conn)
                        Cmd.Parameters.AddWithValue("@id", idUser)
                        Cmd.ExecuteNonQuery()
                        MsgBox("Data berhasil dihapus.")
                        KondisiAwal()
                    Catch ex As Exception
                        MsgBox("Gagal menghapus data: " & ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" AndAlso e.RowIndex >= 0 Then
            e.CellStyle.BackColor = Color.SkyBlue
            e.CellStyle.ForeColor = Color.White
            e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        End If

        If DataGridView1.Columns(e.ColumnIndex).Name = "Delete" AndAlso e.RowIndex >= 0 Then
            e.CellStyle.BackColor = Color.IndianRed
            e.CellStyle.ForeColor = Color.White
            e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        End If
    End Sub
End Class
