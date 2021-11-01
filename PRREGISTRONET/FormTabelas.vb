Public Class FormTabelas
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub BtnAtualiza_Click(sender As Object, e As EventArgs) Handles BtnAtualiza.Click
        FormTabelaAtualiza.Show()
    End Sub

    Private Sub BtnDadosdth_Click(sender As Object, e As EventArgs) Handles BtnDadosdth.Click
        FormTabelaDadosdth.Show()
    End Sub

    Private Sub BtnDadosins000_Click(sender As Object, e As EventArgs) Handles BtnDadosins000.Click
        FormTabelaDadosins000.Show()
    End Sub
End Class