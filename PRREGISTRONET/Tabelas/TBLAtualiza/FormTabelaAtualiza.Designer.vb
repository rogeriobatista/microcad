<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelaAtualiza
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
        Me.BtnSalvar = New System.Windows.Forms.Button()
        Me.DgvTBLAtualiza = New System.Windows.Forms.DataGridView()
        Me.nvxx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nvxxyy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ndata = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vxx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblTotal = New System.Windows.Forms.Label()
        CType(Me.DgvTBLAtualiza, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'BtnSalvar
        '
        Me.BtnSalvar.Location = New System.Drawing.Point(632, 461)
        Me.BtnSalvar.Name = "BtnSalvar"
        Me.BtnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.BtnSalvar.TabIndex = 1
        Me.BtnSalvar.Text = "Salvar"
        Me.BtnSalvar.UseVisualStyleBackColor = True
        '
        'DgvTBLAtualiza
        '
        Me.DgvTBLAtualiza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTBLAtualiza.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nvxx, Me.nvxxyy, Me.ndata, Me.vxx})
        Me.DgvTBLAtualiza.Location = New System.Drawing.Point(12, 12)
        Me.DgvTBLAtualiza.Name = "DgvTBLAtualiza"
        Me.DgvTBLAtualiza.Size = New System.Drawing.Size(776, 397)
        Me.DgvTBLAtualiza.TabIndex = 2
        '
        'nvxx
        '
        Me.nvxx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.nvxx.DataPropertyName = "nvxx"
        Me.nvxx.HeaderText = "nvxx"
        Me.nvxx.MinimumWidth = 100
        Me.nvxx.Name = "nvxx"
        '
        'nvxxyy
        '
        Me.nvxxyy.DataPropertyName = "nvxxyy"
        Me.nvxxyy.HeaderText = "nvxxyy"
        Me.nvxxyy.Name = "nvxxyy"
        '
        'ndata
        '
        Me.ndata.DataPropertyName = "ndata"
        Me.ndata.HeaderText = "ndata"
        Me.ndata.Name = "ndata"
        '
        'vxx
        '
        Me.vxx.DataPropertyName = "vxx"
        Me.vxx.HeaderText = "vxx"
        Me.vxx.Name = "vxx"
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(671, 421)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(91, 13)
        Me.LblTotal.TabIndex = 3
        Me.LblTotal.Text = "Total de registros:"
        '
        'FormTabelaAtualiza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(800, 496)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.DgvTBLAtualiza)
        Me.Controls.Add(Me.BtnSalvar)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormTabelaAtualiza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela TBLAtualiza"
        CType(Me.DgvTBLAtualiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents BtnSalvar As Button
    Friend WithEvents DgvTBLAtualiza As DataGridView
    Friend WithEvents nvxx As DataGridViewTextBoxColumn
    Friend WithEvents nvxxyy As DataGridViewTextBoxColumn
    Friend WithEvents ndata As DataGridViewTextBoxColumn
    Friend WithEvents vxx As DataGridViewTextBoxColumn
    Friend WithEvents LblTotal As Label
End Class
