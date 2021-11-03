<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelaRegistro
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
        Me.DgvRegistro = New System.Windows.Forms.DataGridView()
        Me.LblTotal = New System.Windows.Forms.Label()
        CType(Me.DgvRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(713, 482)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'DgvRegistro
        '
        Me.DgvRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRegistro.Location = New System.Drawing.Point(12, 12)
        Me.DgvRegistro.Name = "DgvRegistro"
        Me.DgvRegistro.Size = New System.Drawing.Size(776, 397)
        Me.DgvRegistro.TabIndex = 1
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(671, 430)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(91, 13)
        Me.LblTotal.TabIndex = 2
        Me.LblTotal.Text = "Total de registros:"
        '
        'FormTabelaRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(800, 517)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.DgvRegistro)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormTabelaRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela Registro"
        CType(Me.DgvRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents DgvRegistro As DataGridView
    Friend WithEvents LblTotal As Label
End Class
