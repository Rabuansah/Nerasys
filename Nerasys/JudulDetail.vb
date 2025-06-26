Imports MySql.Data.MySqlClient

Public Class JudulDetail
    Dim modeEdit As Boolean = False
    Dim idEdit As String = ""

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox1.Enabled = False

        Button1.Text = "Add Judul Detail"
        Button2.Text = "Close"
        Button1.Enabled = True
        Button2.Enabled = True
        modeEdit = False
        idEdit = ""

        TampilkanData()
    End Sub

    Sub TampilkanData()
        Call Koneksi()
        Da = New MySqlDataAdapter("SELECT id_judul_detail, judul_detail FROM tbl_judul_detail", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_judul_detail")

        Dim dt As DataTable = Ds.Tables("tbl_judul_detail")
        DataGridView1.DataSource = dt ' <-- PENTING! Set datasource dulu sebelum atur kolom

        ' Tambahkan tombol aksi (Edit & Delete)
        TambahTombolAksi()

        With DataGridView1
            ' Sembunyikan id_judul_detail
            If .Columns.Contains("id_judul_detail") Then .Columns("id_judul_detail").Visible = False

            ' Atur urutan dan judul kolom
            If .Columns.Contains("judul_detail") Then
                .Columns("judul_detail").DisplayIndex = 0
                .Columns("judul_detail").HeaderText = "Judul Detail"
            End If
            If .Columns.Contains("Edit") Then .Columns("Edit").DisplayIndex = 1
            If .Columns.Contains("Delete") Then .Columns("Delete").DisplayIndex = 2
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
    End Sub

    Private Sub FormJudulDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If Button1.Text = "Add Judul Detail" Then
            Button1.Text = "Save"
            Button2.Text = "Cancle"
            SiapIsi()
        Else
            If TextBox1.Text = "" Then
                MsgBox("Silakan isi semua field.")
                Exit Sub
            End If

            Try
                Call Koneksi()

                Dim query As String
                If modeEdit Then
                    query = "UPDATE tbl_judul_detail SET judul_detail=@judul WHERE id_judul_detail=@id"
                Else
                    query = "INSERT INTO tbl_judul_detail (judul_detail) VALUES (@judul)"
                End If

                Cmd = New MySqlCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@judul", TextBox1.Text)
                If modeEdit Then Cmd.Parameters.AddWithValue("@id", idEdit)

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
            Dim idJudulDetail As String = DataGridView1.Rows(e.RowIndex).Cells("id_judul_detail").Value.ToString()

            If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
                Try
                    Call Koneksi()
                    Cmd = New MySqlCommand("SELECT * FROM tbl_judul_detail WHERE id_judul_detail = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", idJudulDetail)
                    Rd = Cmd.ExecuteReader()
                    If Rd.Read() Then
                        TextBox1.Text = Rd("judul_detail").ToString()

                        SiapIsi()
                        modeEdit = True
                        idEdit = idJudulDetail
                        Button1.Text = "Save"
                        Button2.Text = "Cancle"
                    End If
                    Rd.Close()
                Catch ex As Exception
                    MsgBox("Gagal memuat data: " & ex.Message)
                End Try
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                If MsgBox("Yakin ingin menghapus judul detail ini?", vbYesNo + vbQuestion, "Konfirmasi") = vbYes Then
                    Try
                        Call Koneksi()
                        Cmd = New MySqlCommand("DELETE FROM tbl_judul_detail WHERE id_judul_detail = @id", Conn)
                        Cmd.Parameters.AddWithValue("@id", idJudulDetail)
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
