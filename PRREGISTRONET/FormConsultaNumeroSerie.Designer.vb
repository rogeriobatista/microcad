<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsultaNumeroSerie
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
        Me.DGVConsultaNumeroSerie = New System.Windows.Forms.DataGridView()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nserie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSairConsultaNumeroSerie = New System.Windows.Forms.Button()
        Me.BtnLimparConsultaNumeroSerie = New System.Windows.Forms.Button()
        Me.TxtConsultaNumeroSerie = New System.Windows.Forms.TextBox()
        CType(Me.DGVConsultaNumeroSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVConsultaNumeroSerie
        '
        Me.DGVConsultaNumeroSerie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVConsultaNumeroSerie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nome, Me.nserie, Me.email})
        Me.DGVConsultaNumeroSerie.Location = New System.Drawing.Point(12, 47)
        Me.DGVConsultaNumeroSerie.Name = "DGVConsultaNumeroSerie"
        Me.DGVConsultaNumeroSerie.ReadOnly = True
        Me.DGVConsultaNumeroSerie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVConsultaNumeroSerie.Size = New System.Drawing.Size(671, 394)
        Me.DGVConsultaNumeroSerie.TabIndex = 2
        '
        'nome
        '
        Me.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nome.DataPropertyName = "nome"
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        '
        'nserie
        '
        Me.nserie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.nserie.DataPropertyName = "nserie"
        Me.nserie.HeaderText = "Número de Série"
        Me.nserie.Name = "nserie"
        Me.nserie.ReadOnly = True
        Me.nserie.Width = 80
        '
        'email
        '
        Me.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.email.DataPropertyName = "email"
        Me.email.HeaderText = "Email"
        Me.email.Name = "email"
        Me.email.ReadOnly = True
        '
        'BtnSairConsultaNumeroSerie
        '
        Me.BtnSairConsultaNumeroSerie.Location = New System.Drawing.Point(608, 447)
        Me.BtnSairConsultaNumeroSerie.Name = "BtnSairConsultaNumeroSerie"
        Me.BtnSairConsultaNumeroSerie.Size = New System.Drawing.Size(75, 23)
        Me.BtnSairConsultaNumeroSerie.TabIndex = 3
        Me.BtnSairConsultaNumeroSerie.Text = "Sair"
        Me.BtnSairConsultaNumeroSerie.UseVisualStyleBackColor = True
        '
        'BtnLimparConsultaNumeroSerie
        '
        Me.BtnLimparConsultaNumeroSerie.Location = New System.Drawing.Point(608, 21)
        Me.BtnLimparConsultaNumeroSerie.Name = "BtnLimparConsultaNumeroSerie"
        Me.BtnLimparConsultaNumeroSerie.Size = New System.Drawing.Size(75, 21)
        Me.BtnLimparConsultaNumeroSerie.TabIndex = 1
        Me.BtnLimparConsultaNumeroSerie.Text = "Limpar"
        Me.BtnLimparConsultaNumeroSerie.UseVisualStyleBackColor = True
        '
        'TxtConsultaNumeroSerie
        '
        Me.TxtConsultaNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsultaNumeroSerie.Location = New System.Drawing.Point(12, 21)
        Me.TxtConsultaNumeroSerie.Name = "TxtConsultaNumeroSerie"
        Me.TxtConsultaNumeroSerie.Size = New System.Drawing.Size(590, 20)
        Me.TxtConsultaNumeroSerie.TabIndex = 0
        '
        'FormConsultaNumeroSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(695, 473)
        Me.Controls.Add(Me.TxtConsultaNumeroSerie)
        Me.Controls.Add(Me.BtnLimparConsultaNumeroSerie)
        Me.Controls.Add(Me.BtnSairConsultaNumeroSerie)
        Me.Controls.Add(Me.DGVConsultaNumeroSerie)
        Me.MaximizeBox = False
        Me.Name = "FormConsultaNumeroSerie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta por Número de Série"
        CType(Me.DGVConsultaNumeroSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGVConsultaNumeroSerie As DataGridView
    Friend WithEvents BtnSairConsultaNumeroSerie As Button
    Friend WithEvents BtnLimparConsultaNumeroSerie As Button
    Friend WithEvents TxtConsultaNumeroSerie As TextBox
    Friend WithEvents nome As DataGridViewTextBoxColumn
    Friend WithEvents nserie As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
End Class
