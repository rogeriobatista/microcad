<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTabelas
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DGVTabelas = New System.Windows.Forms.DataGridView()
        Me.BtnSairConsultaEmail = New System.Windows.Forms.Button()
        Me.nserie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.DGVTabelas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVTabelas
        '
        Me.DGVTabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVTabelas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nserie})
        Me.DGVTabelas.Location = New System.Drawing.Point(12, 72)
        Me.DGVTabelas.Name = "DGVTabelas"
        Me.DGVTabelas.ReadOnly = True
        Me.DGVTabelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVTabelas.Size = New System.Drawing.Size(805, 406)
        Me.DGVTabelas.TabIndex = 6
        '
        'BtnSairConsultaEmail
        '
        Me.BtnSairConsultaEmail.Location = New System.Drawing.Point(713, 13)
        Me.BtnSairConsultaEmail.Name = "BtnSairConsultaEmail"
        Me.BtnSairConsultaEmail.Size = New System.Drawing.Size(75, 23)
        Me.BtnSairConsultaEmail.TabIndex = 7
        Me.BtnSairConsultaEmail.Text = "Sair"
        Me.BtnSairConsultaEmail.UseVisualStyleBackColor = True
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 33)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "TBLaaa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(111, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 33)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "TBLaaa"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(203, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 33)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "TBLaaa"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(296, 13)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 33)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "TBLaaa"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(386, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 33)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "TBLaaa"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(477, 13)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 33)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "TBLaaa"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(569, 13)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 33)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = "TBLaaa"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'FormTabelas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 504)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGVTabelas)
        Me.Controls.Add(Me.BtnSairConsultaEmail)
        Me.Name = "FormTabelas"
        Me.Text = "FormTabelas"
        CType(Me.DGVTabelas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGVTabelas As DataGridView
    Friend WithEvents BtnSairConsultaEmail As Button
    Friend WithEvents nserie As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
