﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rubrik
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
        DataGridView1 = New DataGridView()
        Button2 = New Button()
        Button1 = New Button()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.Anchor = AnchorStyles.None
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(50, 190)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(666, 400)
        DataGridView1.TabIndex = 23
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.Location = New Point(200, 50)
        Button2.Name = "Button2"
        Button2.Size = New Size(90, 35)
        Button2.TabIndex = 22
        Button2.Text = "Close"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.Location = New Point(50, 50)
        Button1.Name = "Button1"
        Button1.Size = New Size(130, 35)
        Button1.TabIndex = 19
        Button1.Text = "Add New Rubrik"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(150, 140)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(566, 27)
        TextBox2.TabIndex = 17
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(150, 100)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(150, 27)
        TextBox1.TabIndex = 16
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(50, 140)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 20)
        Label2.TabIndex = 14
        Label2.Text = "Nama Rubrik"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Location = New Point(50, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 20)
        Label1.TabIndex = 13
        Label1.Text = "Kode Rubrik"
        ' 
        ' Rubrik
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(782, 653)
        Controls.Add(Button1)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(TextBox1)
        Controls.Add(TextBox2)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Rubrik"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Rubrik"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
