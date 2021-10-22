<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportarEmails
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
        Me.BtnSair = New System.Windows.Forms.Button()
        Me.BtnImportar = New System.Windows.Forms.Button()
        Me.RTBDetalhes = New System.Windows.Forms.RichTextBox()
        Me.LblDetalhes = New System.Windows.Forms.Label()
        Me.PGBImportarListas = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(255, 219)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'BtnImportar
        '
        Me.BtnImportar.Location = New System.Drawing.Point(174, 219)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Size = New System.Drawing.Size(75, 23)
        Me.BtnImportar.TabIndex = 1
        Me.BtnImportar.Text = "Importar"
        Me.BtnImportar.UseVisualStyleBackColor = True
        '
        'RTBDetalhes
        '
        Me.RTBDetalhes.Location = New System.Drawing.Point(12, 25)
        Me.RTBDetalhes.Name = "RTBDetalhes"
        Me.RTBDetalhes.ReadOnly = True
        Me.RTBDetalhes.Size = New System.Drawing.Size(318, 159)
        Me.RTBDetalhes.TabIndex = 3
        Me.RTBDetalhes.Text = ""
        '
        'LblDetalhes
        '
        Me.LblDetalhes.AutoSize = True
        Me.LblDetalhes.Location = New System.Drawing.Point(12, 9)
        Me.LblDetalhes.Name = "LblDetalhes"
        Me.LblDetalhes.Size = New System.Drawing.Size(49, 13)
        Me.LblDetalhes.TabIndex = 4
        Me.LblDetalhes.Text = "Detalhes"
        '
        'PGBImportarListas
        '
        Me.PGBImportarListas.Location = New System.Drawing.Point(12, 190)
        Me.PGBImportarListas.Name = "PGBImportarListas"
        Me.PGBImportarListas.Size = New System.Drawing.Size(318, 23)
        Me.PGBImportarListas.TabIndex = 5
        '
        'FormImportarEmails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(342, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.PGBImportarListas)
        Me.Controls.Add(Me.LblDetalhes)
        Me.Controls.Add(Me.RTBDetalhes)
        Me.Controls.Add(Me.BtnImportar)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormImportarEmails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Emails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents BtnImportar As Button
    Friend WithEvents RTBDetalhes As RichTextBox
    Friend WithEvents LblDetalhes As Label
    Friend WithEvents PGBImportarListas As ProgressBar
End Class
