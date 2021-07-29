Public Class FormConsultaNumeroSerie
    Private Sub TxtConsultaNumeroSerie_TextChanged(sender As Object, e As EventArgs) Handles TxtConsultaNumeroSerie.TextChanged
        Dim nserie = TxtConsultaNumeroSerie.Text
        If nserie = String.Empty Then
            ClearDataGridView()
            Return
        End If
        DGVConsultaNumeroSerie.DataSource = Consulta.ConsultarPor("nserie", nserie)
    End Sub

    Private Sub TxtConsultaNumeroSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConsultaNumeroSerie.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            LoadRegister(DGVConsultaNumeroSerie.CurrentRow.Index)
        End If
    End Sub

    Private Sub TxtConsultaNumeroSerie_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtConsultaNumeroSerie.PreviewKeyDown
        If e.KeyCode = Keys.Down Then
            Dim currentIndex = DGVConsultaNumeroSerie.CurrentRow.Index
            DGVConsultaNumeroSerie.Select()
            DGVConsultaNumeroSerie.CurrentRow.Selected = False
            DGVConsultaNumeroSerie.Rows(currentIndex + 1).Selected = True
            DGVConsultaNumeroSerie.CurrentCell = DGVConsultaNumeroSerie.Rows(currentIndex + 1).Cells(0)
        End If
    End Sub

    Private Sub BtnLimparConsultaNumeroSerie_Click(sender As Object, e As EventArgs) Handles BtnLimparConsultaNumeroSerie.Click
        ClearSearchResult()
    End Sub

    Private Sub DGVConsultaNumeroSerie_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVConsultaNumeroSerie.CellDoubleClick
        LoadRegister(DGVConsultaNumeroSerie.CurrentRow.Index)
    End Sub

    Private Sub DGVConsultaNumeroSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGVConsultaNumeroSerie.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            LoadRegister(DGVConsultaNumeroSerie.CurrentRow.Index - 1)
        End If
    End Sub

    Private Sub BtnSairConsultaNumeroSerie_Click(sender As Object, e As EventArgs) Handles BtnSairConsultaNumeroSerie.Click
        ActiveForm.Close()
    End Sub

    Private Sub ClearDataGridView()
        DGVConsultaNumeroSerie.DataSource = New List(Of Registro)
    End Sub

    Private Sub ClearSearchResult()
        ClearDataGridView()
        TxtConsultaNumeroSerie.Text = String.Empty
    End Sub

    Private Sub LoadRegister(index As Integer)
        FormREGISTRONET.SUBMOSTRADADOS(DGVConsultaNumeroSerie.Item(1, index).Value)
        ActiveForm.Close()
    End Sub
End Class