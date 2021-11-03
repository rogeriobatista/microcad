<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelaDadosinsSegregado
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
        Me.DgvDadosinsB = New System.Windows.Forms.DataGridView()
        Me.DgvDadosinsA = New System.Windows.Forms.DataGridView()
        Me.BtnSair = New System.Windows.Forms.Button()
        Me.LblTotalB = New System.Windows.Forms.Label()
        Me.LblTotalA = New System.Windows.Forms.Label()
        CType(Me.DgvDadosinsB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDadosinsA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvDadosinsB
        '
        Me.DgvDadosinsB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDadosinsB.Location = New System.Drawing.Point(394, 12)
        Me.DgvDadosinsB.Name = "DgvDadosinsB"
        Me.DgvDadosinsB.Size = New System.Drawing.Size(394, 397)
        Me.DgvDadosinsB.TabIndex = 4
        '
        'DgvDadosinsA
        '
        Me.DgvDadosinsA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDadosinsA.Location = New System.Drawing.Point(12, 12)
        Me.DgvDadosinsA.Name = "DgvDadosinsA"
        Me.DgvDadosinsA.Size = New System.Drawing.Size(376, 397)
        Me.DgvDadosinsA.TabIndex = 3
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(713, 475)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 5
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'LblTotalB
        '
        Me.LblTotalB.AutoSize = True
        Me.LblTotalB.Location = New System.Drawing.Point(676, 428)
        Me.LblTotalB.Name = "LblTotalB"
        Me.LblTotalB.Size = New System.Drawing.Size(91, 13)
        Me.LblTotalB.TabIndex = 6
        Me.LblTotalB.Text = "Total de registros:"
        '
        'LblTotalA
        '
        Me.LblTotalA.AutoSize = True
        Me.LblTotalA.Location = New System.Drawing.Point(270, 428)
        Me.LblTotalA.Name = "LblTotalA"
        Me.LblTotalA.Size = New System.Drawing.Size(91, 13)
        Me.LblTotalA.TabIndex = 7
        Me.LblTotalA.Text = "Total de registros:"
        '
        'FormTabelaDadosinsSegregado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(799, 510)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTotalA)
        Me.Controls.Add(Me.LblTotalB)
        Me.Controls.Add(Me.BtnSair)
        Me.Controls.Add(Me.DgvDadosinsB)
        Me.Controls.Add(Me.DgvDadosinsA)
        Me.Name = "FormTabelaDadosinsSegregado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela Dadosins A+3 e B+1"
        CType(Me.DgvDadosinsB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDadosinsA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgvDadosinsB As DataGridView
    Friend WithEvents DgvDadosinsA As DataGridView
    Friend WithEvents BtnSair As Button
    Friend WithEvents LblTotalB As Label
    Friend WithEvents LblTotalA As Label
End Class
