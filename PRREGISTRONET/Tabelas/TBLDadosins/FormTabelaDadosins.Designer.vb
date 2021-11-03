<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelaDadosins
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
        Me.DgvDadosins = New System.Windows.Forms.DataGridView()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.BtnDadosSegregados = New System.Windows.Forms.Button()
        CType(Me.DgvDadosins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(517, 468)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'DgvDadosins
        '
        Me.DgvDadosins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDadosins.Location = New System.Drawing.Point(12, 12)
        Me.DgvDadosins.Name = "DgvDadosins"
        Me.DgvDadosins.Size = New System.Drawing.Size(579, 397)
        Me.DgvDadosins.TabIndex = 1
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(485, 421)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(91, 13)
        Me.LblTotal.TabIndex = 3
        Me.LblTotal.Text = "Total de registros:"
        '
        'BtnDadosSegregados
        '
        Me.BtnDadosSegregados.Location = New System.Drawing.Point(413, 468)
        Me.BtnDadosSegregados.Name = "BtnDadosSegregados"
        Me.BtnDadosSegregados.Size = New System.Drawing.Size(98, 23)
        Me.BtnDadosSegregados.TabIndex = 4
        Me.BtnDadosSegregados.Text = "Listar A+3 B+1"
        Me.BtnDadosSegregados.UseVisualStyleBackColor = True
        '
        'FormTabelaDadosins
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(604, 503)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnDadosSegregados)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.DgvDadosins)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormTabelaDadosins"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela Dadosins"
        CType(Me.DgvDadosins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents DgvDadosins As DataGridView
    Friend WithEvents LblTotal As Label
    Friend WithEvents BtnDadosSegregados As Button
End Class
