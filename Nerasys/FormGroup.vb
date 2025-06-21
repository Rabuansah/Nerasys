Imports MySql.Data.MySqlClient

Public Class FormGroup
    Dim modeEdit As Boolean = False
    Dim idEditGroup As String = ""

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        ComboBox1.Enabled = False

        Button1.Text = "Add New Group"
        Button2.Text = "Close"
        Button1.Enabled = True
        Button2.Enabled = True
        modeEdit = False
        idEditGroup = ""

        TampilkanData()
    End Sub

    Sub TampilkanData()
        Call Koneksi()
        Da = New MySqlDataAdapter("SELECT id_group, kode_group, uraian_group, jenis_group FROM tbl_group", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_group")

        DataGridView1.DataSource = Ds.Tables("tbl_group")
        TambahTombolAksi()

        With DataGridView1
            If .Columns.Contains("kode_group") Then
                .Columns("kode_group").HeaderText = "Kode Kelompok"
                .Columns("kode_group").DisplayIndex = 0
            End If
            If .Columns.Contains("uraian_group") Then
                .Columns("uraian_group").HeaderText = "Nama Kelompok"
                .Columns("uraian_group").DisplayIndex = 1
            End If
            If .Columns.Contains("jenis_group") Then
                .Columns("jenis_group").HeaderText = "Jenis"
                .Columns("jenis_group").DisplayIndex = 2
            End If
            If .Columns.Contains("Edit") Then .Columns("Edit").DisplayIndex = 3
            If .Columns.Contains("Delete") Then .Columns("Delete").DisplayIndex = 4
            If .Columns.Contains("id_group") Then .Columns("id_group").Visible = False
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
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Aktiva")
        ComboBox1.Items.Add("Pasiva")
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub FormGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KondisiAwal()
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
        If Button1.Text = "Add New Group" Then
            Button1.Text = "Save"
            Button2.Text = "Cancel"
            SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silakan isi semua field.")
                Exit Sub
            End If

            Try
                Call Koneksi()

                ' Cek kode_group duplikat (saat insert)
                If Not modeEdit Then
                    Dim checkCmd = New MySqlCommand("SELECT COUNT(*) FROM tbl_group WHERE kode_group = @kode", Conn)
                    checkCmd.Parameters.AddWithValue("@kode", TextBox1.Text)
                    Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Kode Kelompok sudah ada.")
                        Exit Sub
                    End If
                End If

                Dim query As String
                If modeEdit Then
                    query = "UPDATE tbl_group SET kode_group=@kode, uraian_group=@uraian, jenis_group=@jenis WHERE id_group=@id"
                Else
                    query = "INSERT INTO tbl_group (kode_group, uraian_group, jenis_group) VALUES (@kode, @uraian, @jenis)"
                End If

                Cmd = New MySqlCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@kode", TextBox1.Text)
                Cmd.Parameters.AddWithValue("@uraian", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@jenis", ComboBox1.Text)
                If modeEdit Then Cmd.Parameters.AddWithValue("@id", idEditGroup)

                Cmd.ExecuteNonQuery()
                MsgBox("Data berhasil disimpan.")
                KondisiAwal()
            Catch ex As Exception
                MsgBox("Terjadi kesalahan: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Close" Then
            Me.Close()
        Else
            KondisiAwal()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim idGroup As String = DataGridView1.Rows(e.RowIndex).Cells("id_group").Value.ToString()

            If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
                Try
                    Call Koneksi()
                    Cmd = New MySqlCommand("SELECT * FROM tbl_group WHERE id_group = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", idGroup)
                    Rd = Cmd.ExecuteReader()
                    If Rd.Read() Then
                        TextBox1.Text = Rd("kode_group").ToString()
                        TextBox2.Text = Rd("uraian_group").ToString()
                        ComboBox1.Text = Rd("jenis_group").ToString()

                        SiapIsi()
                        modeEdit = True
                        idEditGroup = idGroup
                        Button1.Text = "Save"
                        Button2.Text = "Cancel"
                    End If
                    Rd.Close()
                Catch ex As Exception
                    MsgBox("Gagal memuat data: " & ex.Message)
                End Try
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                If MsgBox("Yakin ingin menghapus kelompok ini?", vbYesNo + vbQuestion, "Konfirmasi") = vbYes Then
                    Try
                        Call Koneksi()
                        Cmd = New MySqlCommand("DELETE FROM tbl_group WHERE id_group = @id", Conn)
                        Cmd.Parameters.AddWithValue("@id", idGroup)
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
End Class
