<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLicencaInvalida
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
        Me.LblLicencaInvalida = New System.Windows.Forms.Label()
        Me.LblMensagem = New System.Windows.Forms.Label()
        Me.BtnSair = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblLicencaInvalida
        '
        Me.LblLicencaInvalida.AutoSize = True
        Me.LblLicencaInvalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLicencaInvalida.Location = New System.Drawing.Point(121, 45)
        Me.LblLicencaInvalida.Name = "LblLicencaInvalida"
        Me.LblLicencaInvalida.Size = New System.Drawing.Size(174, 26)
        Me.LblLicencaInvalida.TabIndex = 0
        Me.LblLicencaInvalida.Text = "Licença Inválida!"
        '
        'LblMensagem
        '
        Me.LblMensagem.AutoSize = True
        Me.LblMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensagem.Location = New System.Drawing.Point(50, 86)
        Me.LblMensagem.Name = "LblMensagem"
        Me.LblMensagem.Size = New System.Drawing.Size(328, 20)
        Me.LblMensagem.TabIndex = 1
        Me.LblMensagem.Text = "Por favor, procure o adminsitrador do sistema"
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(126, 151)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(161, 43)
        Me.BtnSair.TabIndex = 3
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'FormLicencaInvalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(429, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnSair)
        Me.Controls.Add(Me.LblMensagem)
        Me.Controls.Add(Me.LblLicencaInvalida)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLicencaInvalida"
        Me.Text = "Licenca Inválida"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblLicencaInvalida As Label
    Friend WithEvents LblMensagem As Label
    Friend WithEvents BtnSair As Button
End Class
