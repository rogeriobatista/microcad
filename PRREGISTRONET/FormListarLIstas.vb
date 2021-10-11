Public Class FormListarListas
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub BtnListar_Click(sender As Object, e As EventArgs) Handles BtnListar.Click
        PBListarListas.Value = 100

        Dim list = ListarListas.Listar()

        MessageBox.Show("Listagem concluída com sucesso!")
    End Sub
End Class