<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLimparListas
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
        Me.BtnLimpar = New System.Windows.Forms.Button()
        Me.PBLimparListas = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(392, 12)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'BtnLimpar
        '
        Me.BtnLimpar.Location = New System.Drawing.Point(311, 12)
        Me.BtnLimpar.Name = "BtnLimpar"
        Me.BtnLimpar.Size = New System.Drawing.Size(75, 23)
        Me.BtnLimpar.TabIndex = 1
        Me.BtnLimpar.Text = "Limpar"
        Me.BtnLimpar.UseVisualStyleBackColor = True
        '
        'PBLimparListas
        '
        Me.PBLimparListas.Location = New System.Drawing.Point(12, 12)
        Me.PBLimparListas.Name = "PBLimparListas"
        Me.PBLimparListas.Size = New System.Drawing.Size(293, 23)
        Me.PBLimparListas.TabIndex = 2
        '
        'FormLimparListas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(479, 47)
        Me.ControlBox = False
        Me.Controls.Add(Me.PBLimparListas)
        Me.Controls.Add(Me.BtnLimpar)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormLimparListas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Limpar Listas"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents BtnLimpar As Button
    Friend WithEvents PBLimparListas As ProgressBar
End Class
