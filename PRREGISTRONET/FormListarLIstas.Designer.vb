<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListarListas
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
        Me.BtnListar = New System.Windows.Forms.Button()
        Me.PBListarListas = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'BtnSair
        '
        Me.BtnSair.Location = New System.Drawing.Point(395, 12)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(75, 23)
        Me.BtnSair.TabIndex = 0
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'BtnListar
        '
        Me.BtnListar.Location = New System.Drawing.Point(314, 12)
        Me.BtnListar.Name = "BtnListar"
        Me.BtnListar.Size = New System.Drawing.Size(75, 23)
        Me.BtnListar.TabIndex = 1
        Me.BtnListar.Text = "Listar"
        Me.BtnListar.UseVisualStyleBackColor = True
        '
        'PBListarListas
        '
        Me.PBListarListas.Location = New System.Drawing.Point(12, 12)
        Me.PBListarListas.Name = "PBListarListas"
        Me.PBListarListas.Size = New System.Drawing.Size(296, 23)
        Me.PBListarListas.TabIndex = 2
        '
        'FormListarListas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(482, 48)
        Me.ControlBox = False
        Me.Controls.Add(Me.PBListarListas)
        Me.Controls.Add(Me.BtnListar)
        Me.Controls.Add(Me.BtnSair)
        Me.Name = "FormListarListas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listar Listas"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSair As Button
    Friend WithEvents BtnListar As Button
    Friend WithEvents PBListarListas As ProgressBar
End Class
