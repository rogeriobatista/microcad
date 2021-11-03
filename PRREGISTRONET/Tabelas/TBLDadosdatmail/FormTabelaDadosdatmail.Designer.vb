<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelaDadosdatmail
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
        Me.DgvDadosdatmail = New System.Windows.Forms.DataGridView()
        Me.BtnExportarEmail = New System.Windows.Forms.Button()
        Me.LblTotal = New System.Windows.Forms.Label()
        CType(Me.DgvDadosdatmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(713, 461)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'DgvDadosdatmail
        '
        Me.DgvDadosdatmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDadosdatmail.Location = New System.Drawing.Point(12, 12)
        Me.DgvDadosdatmail.Name = "DgvDadosdatmail"
        Me.DgvDadosdatmail.Size = New System.Drawing.Size(776, 397)
        Me.DgvDadosdatmail.TabIndex = 1
        '
        'BtnExportarEmail
        '
        Me.BtnExportarEmail.Location = New System.Drawing.Point(589, 461)
        Me.BtnExportarEmail.Name = "BtnExportarEmail"
        Me.BtnExportarEmail.Size = New System.Drawing.Size(118, 23)
        Me.BtnExportarEmail.TabIndex = 2
        Me.BtnExportarEmail.Text = "Exportar Emails"
        Me.BtnExportarEmail.UseVisualStyleBackColor = True
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(684, 427)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(91, 13)
        Me.LblTotal.TabIndex = 3
        Me.LblTotal.Text = "Total de registros:"
        '
        'FormTabelaDadosdatmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(800, 496)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.BtnExportarEmail)
        Me.Controls.Add(Me.DgvDadosdatmail)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormTabelaDadosdatmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela Dadosdatmail"
        CType(Me.DgvDadosdatmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents DgvDadosdatmail As DataGridView
    Friend WithEvents BtnExportarEmail As Button
    Friend WithEvents LblTotal As Label
End Class
