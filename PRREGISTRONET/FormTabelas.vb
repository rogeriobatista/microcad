Public Class FormTabelas
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub BtnAtualiza_Click(sender As Object, e As EventArgs) Handles BtnAtualiza.Click
        FormTabelaAtualiza.Show()
    End Sub
End Class