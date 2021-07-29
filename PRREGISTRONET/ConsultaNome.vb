Public Class ConsultaNome
    Private Sub TxtConsultaNome_TextChanged(sender As Object, e As EventArgs) Handles TxtConsultaNome.TextChanged
        Dim nome = TxtConsultaNome.Text
        If nome = String.Empty Then
            ClearDataGridView()
            Return
        End If
        DGConsultaNome.DataSource = Consulta.ConsultarPor("nome", nome)
    End Sub

    Private Sub TxtConsultaNome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConsultaNome.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            LoadRegister(DGConsultaNome.CurrentRow.Index)
        End If
    End Sub

    Private Sub TxtConsultaNome_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtConsultaNome.PreviewKeyDown
        If e.KeyCode = Keys.Down Then
            DGConsultaNome.Select()
            DGConsultaNome.CurrentRow.Selected = False
            DGConsultaNome.Rows(DGConsultaNome.CurrentRow.Index + 1).Selected = True
            DGConsultaNome.CurrentCell = DGConsultaNome.Rows(DGConsultaNome.CurrentRow.Index + 1).Cells(0)
        End If
    End Sub

    Private Sub BtnLimparConsultaNome_Click(sender As Object, e As EventArgs) Handles BtnLimparConsultaNome.Click
        ClearSearchResult()
    End Sub

    Private Sub DGConsultaNome_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGConsultaNome.CellDoubleClick
        LoadRegister(DGConsultaNome.CurrentRow.Index)
    End Sub

    Private Sub DGConsultaNome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGConsultaNome.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            LoadRegister(DGConsultaNome.CurrentRow.Index - 1)
        End If
    End Sub

    Private Sub BtnConsultaNomeSair_Click(sender As Object, e As EventArgs) Handles BtnConsultaNomeSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub ClearDataGridView()
        DGConsultaNome.DataSource = New List(Of Registro)
    End Sub

    Private Sub ClearSearchResult()
        ClearDataGridView()
        TxtConsultaNome.Text = String.Empty
    End Sub

    Private Sub LoadRegister(index As Integer)
        FormREGISTRONET.SUBMOSTRADADOS(DGConsultaNome.Item(1, index).Value)
        ActiveForm.Close()
    End Sub
End Class

