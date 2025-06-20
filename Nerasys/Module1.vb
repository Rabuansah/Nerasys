Imports MySql.Data.MySqlClient

Module Module1
    Public Conn As MySqlConnection
    Public Cmd As MySqlCommand
    Public Rd As MySqlDataReader
    Public Da As MySqlDataAdapter
    Public Ds As DataSet

    Public Sub Koneksi()
        Try
            Conn = New MySqlConnection("server=localhost;user id=root;password=;database=nerasys")
            If Conn.State = ConnectionState.Closed Then Conn.Open()
        Catch ex As Exception
            MsgBox("Gagal koneksi ke database: " & ex.Message)
        End Try
    End Sub
End Module
