Imports MySql.Data.MySqlClient

Public Class FormRekening
    Dim modeEdit As Boolean = False
    Dim idEdit As String = ""

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        DateTimePicker1.Value = Date.Now

        Button1.Text = "Add Rekening"
        Button2.Text = "Close"
        modeEdit = False
        idEdit = ""

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        DateTimePicker1.Enabled = False

        LoadComboData()
        TampilkanData()
    End Sub

    Sub SiapIsi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        DateTimePicker1.Enabled = True
    End Sub

    Sub LoadComboData()
        Call Koneksi()

        ' Group
        Cmd = New MySqlCommand("SELECT id_group, uraian_group FROM tbl_group", Conn)
        Rd = Cmd.ExecuteReader()
        While Rd.Read()
            ComboBox1.Items.Add(New With {.Text = Rd("uraian_group").ToString(), .Value = Rd("id_group")})
        End While
        Rd.Close()

        ' Judul Detail
        Cmd = New MySqlCommand("SELECT id_judul_detail, judul_detail FROM tbl_judul_detail", Conn)
        Rd = Cmd.ExecuteReader()
        While Rd.Read()
            ComboBox2.Items.Add(New With {.Text = Rd("judul_detail").ToString(), .Value = Rd("id_judul_detail")})
        End While
        Rd.Close()

        ' Neraca
        Cmd = New MySqlCommand("SELECT id_neraca, neraca FROM tbl_neraca", Conn)
        Rd = Cmd.ExecuteReader()
        While Rd.Read()
            ComboBox3.Items.Add(New With {.Text = Rd("neraca").ToString(), .Value = Rd("id_neraca")})
        End While
        Rd.Close()

        ComboBox1.DisplayMember = "Text"
        ComboBox2.DisplayMember = "Text"
        ComboBox3.DisplayMember = "Text"
    End Sub

    Sub TampilkanData()
        Call Koneksi()
        Dim query As String = "SELECT r.id_rekening, r.kode_regk, r.nama_regk, g.uraian_group, j.judul_detail, n.neraca " &
                          "FROM tbl_rekening r " &
                          "JOIN tbl_group g ON r.id_group = g.id_group " &
                          "JOIN tbl_judul_detail j ON r.id_judul_detail = j.id_judul_detail " &
                          "JOIN tbl_neraca n ON r.id_neraca = n.id_neraca"
        Da = New MySqlDataAdapter(query, Conn)
        Ds = New DataSet
        Da.Fill(Ds, "rekening")

        Dim dt As DataTable = Ds.Tables("rekening")
        dt.Columns.Add("No", GetType(Integer))

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("No") = i + 1
        Next

        DataGridView1.DataSource = dt

        With DataGridView1
            ' Urutkan dan ganti header kolom
            If .Columns.Contains("No") Then .Columns("No").DisplayIndex = 0
            If .Columns.Contains("kode_regk") Then
                .Columns("kode_regk").HeaderText = "Kode Rekening"
                .Columns("kode_regk").DisplayIndex = 1
            End If
            If .Columns.Contains("nama_regk") Then
                .Columns("nama_regk").HeaderText = "Nama Rekening"
                .Columns("nama_regk").DisplayIndex = 2
            End If
            If .Columns.Contains("uraian_group") Then
                .Columns("uraian_group").HeaderText = "Kelompok"
                .Columns("uraian_group").DisplayIndex = 3
            End If
            If .Columns.Contains("judul_detail") Then
                .Columns("judul_detail").HeaderText = "Jenis"
                .Columns("judul_detail").DisplayIndex = 4
            End If
            If .Columns.Contains("neraca") Then
                .Columns("neraca").HeaderText = "Neraca"
                .Columns("neraca").DisplayIndex = 5
            End If

            ' Sembunyikan kolom ID
            If .Columns.Contains("id_rekening") Then
                .Columns("id_rekening").Visible = False
            End If

            ' Tambahkan tombol Edit dan Delete kalau belum ada
            If Not .Columns.Contains("Edit") Then
                Dim editBtn As New DataGridViewButtonColumn()
                editBtn.Name = "Edit"
                editBtn.Text = "Edit"
                editBtn.UseColumnTextForButtonValue = True
                .Columns.Add(editBtn)
            End If
            If Not .Columns.Contains("Delete") Then
                Dim delBtn As New DataGridViewButtonColumn()
                delBtn.Name = "Delete"
                delBtn.Text = "Hapus"
                delBtn.UseColumnTextForButtonValue = True
                .Columns.Add(delBtn)
            End If

            ' Atur ukuran kolom
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Kolom selain Nama Rekening diatur otomatis ke isinya
            For Each col As DataGridViewColumn In .Columns
                If col.Name = "nama_regk" Then
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                ElseIf col.Name <> "Edit" And col.Name <> "Delete" Then
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next
        End With
    End Sub

    Private Sub FormRekening_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KondisiAwal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Add Rekening" Then
            Button1.Text = "Save"
            Button2.Text = "Cancel"
            SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.SelectedItem Is Nothing Or ComboBox2.SelectedItem Is Nothing Or ComboBox3.SelectedItem Is Nothing Then
                MsgBox("Silakan lengkapi semua field.")
                Exit Sub
            End If

            Try
                Call Koneksi()
                Dim query As String
                If modeEdit Then
                    query = "UPDATE tbl_rekening SET id_group=@group, kode_regk=@kode, nama_regk=@nama, id_judul_detail=@judul, id_neraca=@neraca, tgl_update=@tgl WHERE id_rekening=@id"
                Else
                    query = "INSERT INTO tbl_rekening (id_group, kode_regk, nama_regk, id_judul_detail, id_neraca, tgl_update) " &
                            "VALUES (@group, @kode, @nama, @judul, @neraca, @tgl)"
                End If

                Cmd = New MySqlCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@group", DirectCast(ComboBox1.SelectedItem, Object).Value)
                Cmd.Parameters.AddWithValue("@kode", TextBox1.Text)
                Cmd.Parameters.AddWithValue("@nama", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@judul", DirectCast(ComboBox2.SelectedItem, Object).Value)
                Cmd.Parameters.AddWithValue("@neraca", DirectCast(ComboBox3.SelectedItem, Object).Value)
                Cmd.Parameters.AddWithValue("@tgl", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
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
            Dim idRekening As String = DataGridView1.Rows(e.RowIndex).Cells("id_rekening").Value.ToString()

            If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
                Call Koneksi()
                Cmd = New MySqlCommand("SELECT * FROM tbl_rekening WHERE id_rekening = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", idRekening)
                Rd = Cmd.ExecuteReader()
                If Rd.Read() Then
                    TextBox1.Text = Rd("kode_regk").ToString()
                    TextBox2.Text = Rd("nama_regk").ToString()
                    idEdit = Rd("id_rekening").ToString()

                    ' Pilih item dari ComboBox berdasarkan ID
                    For Each item In ComboBox1.Items
                        If item.Value.ToString() = Rd("id_group").ToString() Then
                            ComboBox1.SelectedItem = item
                            Exit For
                        End If
                    Next

                    For Each item In ComboBox2.Items
                        If item.Value.ToString() = Rd("id_judul_detail").ToString() Then
                            ComboBox2.SelectedItem = item
                            Exit For
                        End If
                    Next

                    For Each item In ComboBox3.Items
                        If item.Value.ToString() = Rd("id_neraca").ToString() Then
                            ComboBox3.SelectedItem = item
                            Exit For
                        End If
                    Next

                    DateTimePicker1.Value = Date.Parse(Rd("tgl_update").ToString())
                    modeEdit = True
                    Button1.Text = "Save"
                    Button2.Text = "Cancel"
                    SiapIsi()
                End If
                Rd.Close()

            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                If MsgBox("Yakin ingin menghapus data ini?", vbYesNo + vbQuestion, "Konfirmasi") = vbYes Then
                    Call Koneksi()
                    Cmd = New MySqlCommand("DELETE FROM tbl_rekening WHERE id_rekening = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", idRekening)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Data berhasil dihapus.")
                    KondisiAwal()
                End If
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox3.Text = "" Then
            MsgBox("Masukkan kode rekening yang ingin dicari.")
            Exit Sub
        End If

        Call Koneksi()
        Dim query As String = "SELECT r.kode_regk, r.nama_regk, g.uraian_group, j.judul_detail, n.neraca, r.tgl_update " &
                              "FROM tbl_rekening r " &
                              "JOIN tbl_group g ON r.id_group = g.id_group " &
                              "JOIN tbl_judul_detail j ON r.id_judul_detail = j.id_judul_detail " &
                              "JOIN tbl_neraca n ON r.id_neraca = n.id_neraca " &
                              "WHERE r.kode_regk = @kode"
        Cmd = New MySqlCommand(query, Conn)
        Cmd.Parameters.AddWithValue("@kode", TextBox3.Text)
        Rd = Cmd.ExecuteReader()

        If Rd.Read() Then
            ' Kirim data ke FormDetailRekening
            'FormDetailRekening.LabelKode.Text = Rd("kode_regk").ToString()
            'FormDetailRekening.LabelNama.Text = Rd("nama_regk").ToString()
            'FormDetailRekening.LabelGroup.Text = Rd("uraian_group").ToString()
            'FormDetailRekening.LabelJenis.Text = Rd("judul_detail").ToString()
            'FormDetailRekening.LabelNeraca.Text = Rd("neraca").ToString()
            'FormDetailRekening.LabelTanggal.Text = Convert.ToDateTime(Rd("tgl_update")).ToString("dd-MM-yyyy")

            'FormDetailRekening.Show()
            MsgBox("Kode rekening ditemukan.")
        Else
            MsgBox("Kode rekening tidak ditemukan.")
        End If
        Rd.Close()
    End Sub
End Class
