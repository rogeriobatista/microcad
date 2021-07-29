<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaNome
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
        Me.TxtConsultaNome = New System.Windows.Forms.TextBox()
        Me.DGConsultaNome = New System.Windows.Forms.DataGridView()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nserie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnConsultaNomeSair = New System.Windows.Forms.Button()
        Me.BtnLimparConsultaNome = New System.Windows.Forms.Button()
        CType(Me.DGConsultaNome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtConsultaNome
        '
        Me.TxtConsultaNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsultaNome.Location = New System.Drawing.Point(12, 12)
        Me.TxtConsultaNome.Name = "TxtConsultaNome"
        Me.TxtConsultaNome.Size = New System.Drawing.Size(500, 20)
        Me.TxtConsultaNome.TabIndex = 0
        '
        'DGConsultaNome
        '
        Me.DGConsultaNome.AllowUserToAddRows = False
        Me.DGConsultaNome.AllowUserToDeleteRows = False
        Me.DGConsultaNome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGConsultaNome.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nome, Me.nserie, Me.email})
        Me.DGConsultaNome.Location = New System.Drawing.Point(12, 38)
        Me.DGConsultaNome.Name = "DGConsultaNome"
        Me.DGConsultaNome.ReadOnly = True
        Me.DGConsultaNome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGConsultaNome.Size = New System.Drawing.Size(606, 390)
        Me.DGConsultaNome.TabIndex = 2
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
        'BtnConsultaNomeSair
        '
        Me.BtnConsultaNomeSair.Location = New System.Drawing.Point(543, 434)
        Me.BtnConsultaNomeSair.Name = "BtnConsultaNomeSair"
        Me.BtnConsultaNomeSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnConsultaNomeSair.TabIndex = 3
        Me.BtnConsultaNomeSair.Text = "Sair"
        Me.BtnConsultaNomeSair.UseVisualStyleBackColor = True
        '
        'BtnLimparConsultaNome
        '
        Me.BtnLimparConsultaNome.Location = New System.Drawing.Point(518, 12)
        Me.BtnLimparConsultaNome.Name = "BtnLimparConsultaNome"
        Me.BtnLimparConsultaNome.Size = New System.Drawing.Size(100, 20)
        Me.BtnLimparConsultaNome.TabIndex = 4
        Me.BtnLimparConsultaNome.Text = "Limpar"
        Me.BtnLimparConsultaNome.UseVisualStyleBackColor = True
        '
        'ConsultaNome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(630, 469)
        Me.Controls.Add(Me.BtnLimparConsultaNome)
        Me.Controls.Add(Me.BtnConsultaNomeSair)
        Me.Controls.Add(Me.DGConsultaNome)
        Me.Controls.Add(Me.TxtConsultaNome)
        Me.MaximizeBox = False
        Me.Name = "ConsultaNome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta por Nome"
        CType(Me.DGConsultaNome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtConsultaNome As TextBox
    Friend WithEvents DGConsultaNome As DataGridView
    Friend WithEvents BtnConsultaNomeSair As Button
    Friend WithEvents BtnLimparConsultaNome As Button
    Friend WithEvents nome As DataGridViewTextBoxColumn
    Friend WithEvents nserie As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
End Class
