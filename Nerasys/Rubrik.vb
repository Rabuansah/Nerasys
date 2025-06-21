Imports MySql.Data.MySqlClient

Public Class Rubrik
    Dim modeEdit As Boolean = False
    Dim idEditRubrik As String = ""

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False

        Button1.Text = "Add New Rubrik"
        Button2.Text = "Close"
        Button1.Enabled = True
        Button2.Enabled = True
        modeEdit = False
        idEditRubrik = ""

        TampilkanData()
    End Sub

    Sub TampilkanData()
        Call Koneksi()
        Da = New MySqlDataAdapter("SELECT id_rubrik, kode_rubrik, uraian_rubrik FROM tbl_rubrik", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_rubrik")

        Dim dt As DataTable = Ds.Tables("tbl_rubrik")
        DataGridView1.DataSource = dt ' <-- PENTING! Set datasource dulu sebelum atur kolom

        ' Tambahkan tombol aksi (Edit & Delete)
        TambahTombolAksi()

        With DataGridView1
            ' Sembunyikan id_rubrik
            If .Columns.Contains("id_rubrik") Then .Columns("id_rubrik").Visible = False

            ' Atur urutan dan judul kolom
            If .Columns.Contains("kode_rubrik") Then
                .Columns("kode_rubrik").DisplayIndex = 0
                .Columns("kode_rubrik").HeaderText = "Kode Rubrik"
            End If
            If .Columns.Contains("uraian_rubrik") Then
                .Columns("uraian_rubrik").DisplayIndex = 1
                .Columns("uraian_rubrik").HeaderText = "Nama Rubrik"
            End If
            If .Columns.Contains("Edit") Then .Columns("Edit").DisplayIndex = 2
            If .Columns.Contains("Delete") Then .Columns("Delete").DisplayIndex = 3
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
    End Sub

    Private Sub FormRubrik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If Button1.Text = "Add New Rubrik" Then
            Button1.Text = "Save"
            Button2.Text = "Cancle"
            SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Silakan isi semua field.")
                Exit Sub
            End If

            Try
                Call Koneksi()

                ' Cek kode rubrik unik saat INSERT
                If Not modeEdit Then
                    Dim checkCmd = New MySqlCommand("SELECT COUNT(*) FROM tbl_rubrik WHERE kode_rubrik = @kode", Conn)
                    checkCmd.Parameters.AddWithValue("@kode", TextBox1.Text)
                    Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Kode Rubrik sudah ada.")
                        Exit Sub
                    End If
                End If

                Dim query As String
                If modeEdit Then
                    query = "UPDATE tbl_rubrik SET kode_rubrik=@kode, uraian_rubrik=@nama WHERE id_rubrik=@id"
                Else
                    query = "INSERT INTO tbl_rubrik (kode_rubrik, uraian_rubrik) VALUES (@kode, @nama)"
                End If

                Cmd = New MySqlCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@kode", TextBox1.Text)
                Cmd.Parameters.AddWithValue("@nama", TextBox2.Text)
                If modeEdit Then Cmd.Parameters.AddWithValue("@id", idEditRubrik)

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
            Dim idRubrik As String = DataGridView1.Rows(e.RowIndex).Cells("id_rubrik").Value.ToString()

            If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
                Try
                    Call Koneksi()
                    Cmd = New MySqlCommand("SELECT * FROM tbl_rubrik WHERE id_rubrik = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", idRubrik)
                    Rd = Cmd.ExecuteReader()
                    If Rd.Read() Then
                        TextBox1.Text = Rd("kode_rubrik").ToString()
                        TextBox2.Text = Rd("uraian_rubrik").ToString()

                        SiapIsi()
                        modeEdit = True
                        idEditRubrik = idRubrik
                        Button1.Text = "Save"
                        Button2.Text = "Cancle"
                    End If
                    Rd.Close()
                Catch ex As Exception
                    MsgBox("Gagal memuat data: " & ex.Message)
                End Try
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                If MsgBox("Yakin ingin menghapus rubrik ini?", vbYesNo + vbQuestion, "Konfirmasi") = vbYes Then
                    Try
                        Call Koneksi()
                        Cmd = New MySqlCommand("DELETE FROM tbl_rubrik WHERE id_rubrik = @id", Conn)
                        Cmd.Parameters.AddWithValue("@id", idRubrik)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Kosongkan saja jika tidak digunakan
    End Sub
End Class
