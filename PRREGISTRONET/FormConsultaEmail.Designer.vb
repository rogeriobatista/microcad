<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsultaEmail
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
        Me.BtnSairConsultaEmail = New System.Windows.Forms.Button()
        Me.BtnLimparConsultaEmail = New System.Windows.Forms.Button()
        Me.TxtConsultaEmail = New System.Windows.Forms.TextBox()
        Me.DGVConsultaEmail = New System.Windows.Forms.DataGridView()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nserie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGVConsultaEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSairConsultaEmail
        '
        Me.BtnSairConsultaEmail.Location = New System.Drawing.Point(617, 460)
        Me.BtnSairConsultaEmail.Name = "BtnSairConsultaEmail"
        Me.BtnSairConsultaEmail.Size = New System.Drawing.Size(75, 23)
        Me.BtnSairConsultaEmail.TabIndex = 3
        Me.BtnSairConsultaEmail.Text = "Sair"
        Me.BtnSairConsultaEmail.UseVisualStyleBackColor = True
        '
        'BtnLimparConsultaEmail
        '
        Me.BtnLimparConsultaEmail.Location = New System.Drawing.Point(617, 12)
        Me.BtnLimparConsultaEmail.Name = "BtnLimparConsultaEmail"
        Me.BtnLimparConsultaEmail.Size = New System.Drawing.Size(75, 20)
        Me.BtnLimparConsultaEmail.TabIndex = 1
        Me.BtnLimparConsultaEmail.Text = "Limpar"
        Me.BtnLimparConsultaEmail.UseVisualStyleBackColor = True
        '
        'TxtConsultaEmail
        '
        Me.TxtConsultaEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsultaEmail.Location = New System.Drawing.Point(12, 12)
        Me.TxtConsultaEmail.Name = "TxtConsultaEmail"
        Me.TxtConsultaEmail.Size = New System.Drawing.Size(599, 20)
        Me.TxtConsultaEmail.TabIndex = 0
        '
        'DGVConsultaEmail
        '
        Me.DGVConsultaEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVConsultaEmail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nome, Me.nserie, Me.email})
        Me.DGVConsultaEmail.Location = New System.Drawing.Point(12, 38)
        Me.DGVConsultaEmail.Name = "DGVConsultaEmail"
        Me.DGVConsultaEmail.ReadOnly = True
        Me.DGVConsultaEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVConsultaEmail.Size = New System.Drawing.Size(680, 416)
        Me.DGVConsultaEmail.TabIndex = 2
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
        'FormConsultaEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(704, 488)
        Me.Controls.Add(Me.DGVConsultaEmail)
        Me.Controls.Add(Me.TxtConsultaEmail)
        Me.Controls.Add(Me.BtnLimparConsultaEmail)
        Me.Controls.Add(Me.BtnSairConsultaEmail)
        Me.MaximizeBox = False
        Me.Name = "FormConsultaEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta por Email"
        CType(Me.DGVConsultaEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSairConsultaEmail As Button
    Friend WithEvents BtnLimparConsultaEmail As Button
    Friend WithEvents TxtConsultaEmail As TextBox
    Friend WithEvents DGVConsultaEmail As DataGridView
    Friend WithEvents nome As DataGridViewTextBoxColumn
    Friend WithEvents nserie As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
End Class
