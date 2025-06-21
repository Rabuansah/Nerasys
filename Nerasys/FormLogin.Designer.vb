<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        picTogglePassword = New PictureBox()
        Label3 = New Label()
        Button2 = New Button()
        Button1 = New Button()
        txtPassword = New TextBox()
        Label2 = New Label()
        txtUser = New TextBox()
        Label1 = New Label()
        Panel1.SuspendLayout()
        CType(picTogglePassword, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.LightCyan
        Panel1.Controls.Add(picTogglePassword)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtUser)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(377, 183)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(591, 380)
        Panel1.TabIndex = 0
        ' 
        ' picTogglePassword
        ' 
        picTogglePassword.Anchor = AnchorStyles.None
        picTogglePassword.Image = My.Resources.Resources.eye_open
        picTogglePassword.Location = New Point(481, 202)
        picTogglePassword.Name = "picTogglePassword"
        picTogglePassword.Size = New Size(34, 27)
        picTogglePassword.TabIndex = 7
        picTogglePassword.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(193, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(224, 64)
        Label3.TabIndex = 6
        Label3.Text = "Neraca System" & vbCrLf & "Login"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.Location = New Point(410, 266)
        Button2.Name = "Button2"
        Button2.Size = New Size(105, 40)
        Button2.TabIndex = 5
        Button2.Text = "Login"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.Location = New Point(76, 266)
        Button1.Name = "Button1"
        Button1.Size = New Size(104, 40)
        Button1.TabIndex = 4
        Button1.Text = "Cancel"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Anchor = AnchorStyles.None
        txtPassword.Location = New Point(76, 202)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(399, 27)
        txtPassword.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(76, 179)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 20)
        Label2.TabIndex = 2
        Label2.Text = "Password"
        ' 
        ' txtUser
        ' 
        txtUser.Anchor = AnchorStyles.None
        txtUser.Location = New Point(76, 130)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(439, 27)
        txtUser.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Location = New Point(76, 107)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 20)
        Label1.TabIndex = 0
        Label1.Text = "Username"
        ' 
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CausesValidation = False
        ClientSize = New Size(1348, 746)
        Controls.Add(Panel1)
        Name = "FormLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "NeraSys"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(picTogglePassword, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents picTogglePassword As PictureBox

End Class
