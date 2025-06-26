Imports MySql.Data.MySqlClient

Public Class Neraca
    Dim modeEdit As Boolean = False
    Dim idEdit As String = ""

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox1.Enabled = False

        Button1.Text = "Add Neraca"
        Button2.Text = "Close"
        Button1.Enabled = True
        Button2.Enabled = True
        modeEdit = False
        idEdit = ""

        TampilkanData()
    End Sub

    Sub TampilkanData()
        Call Koneksi()
        Da = New MySqlDataAdapter("SELECT id_neraca, neraca FROM tbl_neraca", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_neraca")

        Dim dt As DataTable = Ds.Tables("tbl_neraca")
        DataGridView1.DataSource = dt ' <-- PENTING! Set datasource dulu sebelum atur kolom

        ' Tambahkan tombol aksi (Edit & Delete)
        TambahTombolAksi()

        With DataGridView1
            ' Sembunyikan id_neraca
            If .Columns.Contains("id_neraca") Then .Columns("id_neraca").Visible = False

            ' Atur urutan dan judul kolom
            If .Columns.Contains("neraca") Then
                .Columns("neraca").DisplayIndex = 0
                .Columns("neraca").HeaderText = "Neraca"
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

    Private Sub FormNeraca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If Button1.Text = "Add Neraca" Then
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
                    query = "UPDATE tbl_neraca SET neraca=@neraca WHERE id_neraca=@id"
                Else
                    query = "INSERT INTO tbl_neraca (neraca) VALUES (@neraca)"
                End If

                Cmd = New MySqlCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@neraca", TextBox1.Text)
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
            Dim idNeraca As String = DataGridView1.Rows(e.RowIndex).Cells("id_neraca").Value.ToString()

            If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
                Try
                    Call Koneksi()
                    Cmd = New MySqlCommand("SELECT * FROM tbl_neraca WHERE id_neraca = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", idNeraca)
                    Rd = Cmd.ExecuteReader()
                    If Rd.Read() Then
                        TextBox1.Text = Rd("neraca").ToString()

                        SiapIsi()
                        modeEdit = True
                        idEdit = idNeraca
                        Button1.Text = "Save"
                        Button2.Text = "Cancle"
                    End If
                    Rd.Close()
                Catch ex As Exception
                    MsgBox("Gagal memuat data: " & ex.Message)
                End Try
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                If MsgBox("Yakin ingin menghapus neraca ini?", vbYesNo + vbQuestion, "Konfirmasi") = vbYes Then
                    Try
                        Call Koneksi()
                        Cmd = New MySqlCommand("DELETE FROM tbl_neraca WHERE id_neraca = @id", Conn)
                        Cmd.Parameters.AddWithValue("@id", idNeraca)
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
