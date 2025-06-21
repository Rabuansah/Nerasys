<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HalamanUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        MasterToolStripMenuItem = New ToolStripMenuItem()
        KodeRekeningToolStripMenuItem = New ToolStripMenuItem()
        UserToolStripMenuItem = New ToolStripMenuItem()
        TransaksiToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        TransaksiToolStripMenuItem1 = New ToolStripMenuItem()
        TutupBukuToolStripMenuItem = New ToolStripMenuItem()
        LaporanToolStripMenuItem = New ToolStripMenuItem()
        NeracaPercobaanToolStripMenuItem = New ToolStripMenuItem()
        KRBBToolStripMenuItem = New ToolStripMenuItem()
        KasBankToolStripMenuItem = New ToolStripMenuItem()
        PemeliharaanToolStripMenuItem = New ToolStripMenuItem()
        SaldoAwalToolStripMenuItem = New ToolStripMenuItem()
        TutupBukuToolStripMenuItem1 = New ToolStripMenuItem()
        Panel1 = New Panel()
        Label3 = New Label()
        Panel3 = New Panel()
        Button1 = New Button()
        DateTimePicker1 = New DateTimePicker()
        Label2 = New Label()
        Panel2 = New Panel()
        Label4 = New Label()
        Label1 = New Label()
        RubrikToolStripMenuItem = New ToolStripMenuItem()
        KodeKelompokToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {MasterToolStripMenuItem, TransaksiToolStripMenuItem, LaporanToolStripMenuItem, PemeliharaanToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1348, 28)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MasterToolStripMenuItem
        ' 
        MasterToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RubrikToolStripMenuItem, KodeKelompokToolStripMenuItem, KodeRekeningToolStripMenuItem, UserToolStripMenuItem})
        MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        MasterToolStripMenuItem.Size = New Size(68, 24)
        MasterToolStripMenuItem.Text = "Master"
        ' 
        ' KodeRekeningToolStripMenuItem
        ' 
        KodeRekeningToolStripMenuItem.Name = "KodeRekeningToolStripMenuItem"
        KodeRekeningToolStripMenuItem.Size = New Size(199, 26)
        KodeRekeningToolStripMenuItem.Text = "Kode Rekening"
        ' 
        ' UserToolStripMenuItem
        ' 
        UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        UserToolStripMenuItem.Size = New Size(199, 26)
        UserToolStripMenuItem.Text = "User"
        ' 
        ' TransaksiToolStripMenuItem
        ' 
        TransaksiToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripSeparator1, TransaksiToolStripMenuItem1, TutupBukuToolStripMenuItem})
        TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        TransaksiToolStripMenuItem.Size = New Size(82, 24)
        TransaksiToolStripMenuItem.Text = "Transaksi"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(163, 6)
        ' 
        ' TransaksiToolStripMenuItem1
        ' 
        TransaksiToolStripMenuItem1.Name = "TransaksiToolStripMenuItem1"
        TransaksiToolStripMenuItem1.Size = New Size(166, 26)
        TransaksiToolStripMenuItem1.Text = "Transaksi"
        ' 
        ' TutupBukuToolStripMenuItem
        ' 
        TutupBukuToolStripMenuItem.Name = "TutupBukuToolStripMenuItem"
        TutupBukuToolStripMenuItem.Size = New Size(166, 26)
        TutupBukuToolStripMenuItem.Text = "Tutup Buku"
        ' 
        ' LaporanToolStripMenuItem
        ' 
        LaporanToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NeracaPercobaanToolStripMenuItem, KRBBToolStripMenuItem, KasBankToolStripMenuItem})
        LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        LaporanToolStripMenuItem.Size = New Size(77, 24)
        LaporanToolStripMenuItem.Text = "Laporan"
        ' 
        ' NeracaPercobaanToolStripMenuItem
        ' 
        NeracaPercobaanToolStripMenuItem.Name = "NeracaPercobaanToolStripMenuItem"
        NeracaPercobaanToolStripMenuItem.Size = New Size(212, 26)
        NeracaPercobaanToolStripMenuItem.Text = "Neraca Percobaan"
        ' 
        ' KRBBToolStripMenuItem
        ' 
        KRBBToolStripMenuItem.Name = "KRBBToolStripMenuItem"
        KRBBToolStripMenuItem.Size = New Size(212, 26)
        KRBBToolStripMenuItem.Text = "KRBB"
        ' 
        ' KasBankToolStripMenuItem
        ' 
        KasBankToolStripMenuItem.Name = "KasBankToolStripMenuItem"
        KasBankToolStripMenuItem.Size = New Size(212, 26)
        KasBankToolStripMenuItem.Text = "Kas/Bank"
        ' 
        ' PemeliharaanToolStripMenuItem
        ' 
        PemeliharaanToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SaldoAwalToolStripMenuItem, TutupBukuToolStripMenuItem1})
        PemeliharaanToolStripMenuItem.Name = "PemeliharaanToolStripMenuItem"
        PemeliharaanToolStripMenuItem.Size = New Size(112, 24)
        PemeliharaanToolStripMenuItem.Text = "Pemeliharaan"
        ' 
        ' SaldoAwalToolStripMenuItem
        ' 
        SaldoAwalToolStripMenuItem.Name = "SaldoAwalToolStripMenuItem"
        SaldoAwalToolStripMenuItem.Size = New Size(167, 26)
        SaldoAwalToolStripMenuItem.Text = "Saldo Awal"
        ' 
        ' TutupBukuToolStripMenuItem1
        ' 
        TutupBukuToolStripMenuItem1.Name = "TutupBukuToolStripMenuItem1"
        TutupBukuToolStripMenuItem1.Size = New Size(167, 26)
        TutupBukuToolStripMenuItem1.Text = "Tutup Buku"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.SkyBlue
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(DateTimePicker1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Panel2)
        Panel1.Location = New Point(388, 180)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(505, 325)
        Panel1.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(197, 287)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 20)
        Label3.TabIndex = 6
        Label3.Text = "User : Admin"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Location = New Point(25, 261)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(459, 10)
        Panel3.TabIndex = 5
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.Location = New Point(339, 167)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 4
        Button1.Text = "Keluar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(168, 167)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(153, 27)
        DateTimePicker1.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(99, 170)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 20)
        Label2.TabIndex = 1
        Label2.Text = "Tanggal"
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.None
        Panel2.BackColor = Color.Aqua
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(25, 20)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(459, 93)
        Panel2.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(119, 59)
        Label4.Name = "Label4"
        Label4.Size = New Size(210, 17)
        Label4.TabIndex = 1
        Label4.Text = "Jln. Sultan Abdurrachman No. 11"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Bauhaus 93", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(74, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(309, 39)
        Label1.TabIndex = 0
        Label1.Text = "KOPKAR SEJAHTERA"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' RubrikToolStripMenuItem
        ' 
        RubrikToolStripMenuItem.Name = "RubrikToolStripMenuItem"
        RubrikToolStripMenuItem.Size = New Size(199, 26)
        RubrikToolStripMenuItem.Text = "Rubrik"
        ' 
        ' KodeKelompokToolStripMenuItem
        ' 
        KodeKelompokToolStripMenuItem.Name = "KodeKelompokToolStripMenuItem"
        KodeKelompokToolStripMenuItem.Size = New Size(199, 26)
        KodeKelompokToolStripMenuItem.Text = "Kode Kelompok"
        ' 
        ' HalamanUtama
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1348, 746)
        Controls.Add(Panel1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "HalamanUtama"
        StartPosition = FormStartPosition.CenterScreen
        Text = "HalamanUtama"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KodeRekeningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PemeliharaanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TutupBukuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NeracaPercobaanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KRBBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KasBankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaldoAwalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TutupBukuToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents RubrikToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KodeKelompokToolStripMenuItem As ToolStripMenuItem
End Class
