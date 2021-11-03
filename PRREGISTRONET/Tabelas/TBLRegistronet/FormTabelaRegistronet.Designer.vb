<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelaRegistronet
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
        Me.DgvRegistronet = New System.Windows.Forms.DataGridView()
        Me.LblTotal = New System.Windows.Forms.Label()
        CType(Me.DgvRegistronet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(1007, 536)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'DgvRegistronet
        '
        Me.DgvRegistronet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRegistronet.Location = New System.Drawing.Point(12, 12)
        Me.DgvRegistronet.Name = "DgvRegistronet"
        Me.DgvRegistronet.Size = New System.Drawing.Size(1070, 453)
        Me.DgvRegistronet.TabIndex = 1
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(968, 489)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(91, 13)
        Me.LblTotal.TabIndex = 2
        Me.LblTotal.Text = "Total de registros:"
        '
        'FormTabelaRegistronet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1094, 571)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.DgvRegistronet)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormTabelaRegistronet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela Registronet"
        CType(Me.DgvRegistronet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents DgvRegistronet As DataGridView
    Friend WithEvents LblTotal As Label
End Class
