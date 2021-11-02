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
        Me.DgvDadosinsA = New System.Windows.Forms.DataGridView()
        Me.DgvDadosinsB = New System.Windows.Forms.DataGridView()
        CType(Me.DgvDadosinsA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDadosinsB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(713, 415)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'DgvDadosinsA
        '
        Me.DgvDadosinsA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDadosinsA.Location = New System.Drawing.Point(12, 12)
        Me.DgvDadosinsA.Name = "DgvDadosinsA"
        Me.DgvDadosinsA.Size = New System.Drawing.Size(376, 397)
        Me.DgvDadosinsA.TabIndex = 1
        '
        'DgvDadosinsB
        '
        Me.DgvDadosinsB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDadosinsB.Location = New System.Drawing.Point(394, 12)
        Me.DgvDadosinsB.Name = "DgvDadosinsB"
        Me.DgvDadosinsB.Size = New System.Drawing.Size(394, 397)
        Me.DgvDadosinsB.TabIndex = 2
        '
        'FormTabelaDadosins
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(800, 445)
        Me.ControlBox = False
        Me.Controls.Add(Me.DgvDadosinsB)
        Me.Controls.Add(Me.DgvDadosinsA)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormTabelaDadosins"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabela Dadosins"
        CType(Me.DgvDadosinsA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDadosinsB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents DgvDadosinsA As DataGridView
    Friend WithEvents DgvDadosinsB As DataGridView
End Class
