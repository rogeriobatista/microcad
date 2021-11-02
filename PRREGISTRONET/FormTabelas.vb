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

    Private Sub BtnDadostxt_Click(sender As Object, e As EventArgs) Handles BtnDadostxt.Click
        FormTabelaDadostxt.Show()
    End Sub

    Private Sub BtnNaoreg_Click(sender As Object, e As EventArgs) Handles BtnNaoreg.Click
        FormTabelaNaoreg.Show()
    End Sub

    Private Sub BtnRegistro_Click(sender As Object, e As EventArgs) Handles BtnRegistro.Click
        FormTabelaRegistro.Show()
    End Sub

    Private Sub BtnRegistronet_Click(sender As Object, e As EventArgs) Handles BtnRegistronet.Click
        FormTabelaRegistronet.Show()
    End Sub

    Private Sub BtnXemail_Click(sender As Object, e As EventArgs) Handles BtnXemail.Click
        FormTabelaXemail.Show()
    End Sub

    Private Sub BtnDadosdatmail_Click(sender As Object, e As EventArgs) Handles BtnDadosdatmail.Click
        FormTabelaDadosdatmail.Show()
    End Sub

    Private Sub BtnDadosdat_Click(sender As Object, e As EventArgs) Handles BtnDadosdat.Click
        FormTabelaDadosdat.Show()
    End Sub
End Class