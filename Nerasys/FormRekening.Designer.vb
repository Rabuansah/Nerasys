<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRekening
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
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        DataGridView1 = New DataGridView()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        ComboBox3 = New ComboBox()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        TextBox2 = New TextBox()
        DateTimePicker1 = New DateTimePicker()
        TextBox3 = New TextBox()
        Label7 = New Label()
        Button3 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.Location = New Point(50, 50)
        Button1.Name = "Button1"
        Button1.Size = New Size(130, 35)
        Button1.TabIndex = 27
        Button1.Text = "Add Rekening"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.Location = New Point(200, 50)
        Button2.Name = "Button2"
        Button2.Size = New Size(90, 35)
        Button2.TabIndex = 29
        Button2.Text = "Close"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Location = New Point(50, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(61, 20)
        Label1.TabIndex = 21
        Label1.Text = "Tanggal"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(50, 140)
        Label2.Name = "Label2"
        Label2.Size = New Size(109, 20)
        Label2.TabIndex = 22
        Label2.Text = "Kode Rekening"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Location = New Point(50, 183)
        Label3.Name = "Label3"
        Label3.Size = New Size(114, 20)
        Label3.TabIndex = 23
        Label3.Text = "Nama Rekening"
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(200, 140)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(400, 27)
        TextBox1.TabIndex = 25
        ' 
        ' DataGridView1
        ' 
        DataGridView1.Anchor = AnchorStyles.None
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(50, 233)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1180, 329)
        DataGridView1.TabIndex = 28
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Location = New Point(680, 100)
        Label4.Name = "Label4"
        Label4.Size = New Size(77, 20)
        Label4.TabIndex = 30
        Label4.Text = "Kelompok"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Location = New Point(680, 140)
        Label5.Name = "Label5"
        Label5.Size = New Size(40, 20)
        Label5.TabIndex = 31
        Label5.Text = "Jenis"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Location = New Point(680, 183)
        Label6.Name = "Label6"
        Label6.Size = New Size(56, 20)
        Label6.TabIndex = 32
        Label6.Text = "Neraca"
        ' 
        ' ComboBox3
        ' 
        ComboBox3.Anchor = AnchorStyles.None
        ComboBox3.FormattingEnabled = True
        ComboBox3.Location = New Point(830, 183)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(400, 28)
        ComboBox3.TabIndex = 35
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Anchor = AnchorStyles.None
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(830, 137)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(400, 28)
        ComboBox2.TabIndex = 36
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.None
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(830, 97)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(400, 28)
        ComboBox1.TabIndex = 37
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(200, 180)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(400, 27)
        TextBox2.TabIndex = 38
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Anchor = AnchorStyles.None
        DateTimePicker1.Location = New Point(200, 97)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(400, 27)
        DateTimePicker1.TabIndex = 39
        ' 
        ' TextBox3
        ' 
        TextBox3.Anchor = AnchorStyles.None
        TextBox3.Location = New Point(200, 583)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(400, 27)
        TextBox3.TabIndex = 41
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Location = New Point(50, 586)
        Label7.Name = "Label7"
        Label7.Size = New Size(100, 20)
        Label7.TabIndex = 40
        Label7.Text = "Cari Rekening"
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.None
        Button3.Location = New Point(630, 579)
        Button3.Name = "Button3"
        Button3.Size = New Size(127, 35)
        Button3.TabIndex = 42
        Button3.Text = "Lihat Rekening"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' FormRekening
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoValidate = AutoValidate.Disable
        ClientSize = New Size(1282, 643)
        Controls.Add(Button1)
        Controls.Add(Button2)
        Controls.Add(Button3)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(Label5)
        Controls.Add(Label6)
        Controls.Add(Label7)
        Controls.Add(TextBox1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox3)
        Controls.Add(ComboBox1)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox3)
        Controls.Add(DateTimePicker1)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FormRekening"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Kode Rekening"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button3 As Button
End Class
