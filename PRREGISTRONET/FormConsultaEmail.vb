Public Class FormConsultaEmail
    Private Sub TxtConsultaEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtConsultaEmail.TextChanged
        Dim email = TxtConsultaEmail.Text
        If email = String.Empty Then
            ClearDataGridView()
            Return
        End If
        DGVConsultaEmail.DataSource = Consulta.ConsultarPor("email", email)
    End Sub

    Private Sub TxtConsultaEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConsultaEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            LoadRegister(DGVConsultaEmail.CurrentRow.Index)
        End If
    End Sub

    Private Sub TxtConsultaEmail_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtConsultaEmail.PreviewKeyDown
        If e.KeyCode = Keys.Down Then
            DGVConsultaEmail.Select()
            DGVConsultaEmail.CurrentRow.Selected = False
            DGVConsultaEmail.Rows(DGVConsultaEmail.CurrentRow.Index + 1).Selected = True
            DGVConsultaEmail.CurrentCell = DGVConsultaEmail.Rows(DGVConsultaEmail.CurrentRow.Index + 1).Cells(0)
        End If
    End Sub

    Private Sub BtnLimparConsultaEmail_Click(sender As Object, e As EventArgs) Handles BtnLimparConsultaEmail.Click
        ClearSearchResult()
    End Sub

    Private Sub DGVConsultaEmail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVConsultaEmail.CellDoubleClick
        LoadRegister(DGVConsultaEmail.CurrentRow.Index)
    End Sub

    Private Sub DGVConsultaEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGVConsultaEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            LoadRegister(DGVConsultaEmail.CurrentRow.Index - 1)
        End If
    End Sub

    Private Sub BtnSairConsultaEmail_Click(sender As Object, e As EventArgs) Handles BtnSairConsultaEmail.Click
        ActiveForm.Close()
    End Sub

    Private Sub ClearDataGridView()
        DGVConsultaEmail.DataSource = New List(Of Registro)
    End Sub

    Private Sub ClearSearchResult()
        ClearDataGridView()
        DGVConsultaEmail.Text = String.Empty
    End Sub

    Private Sub LoadRegister(index As Integer)
        FormREGISTRONET.SUBMOSTRADADOS(DGVConsultaEmail.Item(1, index).Value)
        ActiveForm.Close()
    End Sub
End Class