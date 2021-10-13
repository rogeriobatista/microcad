Public Class FormLimparListas
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub BtnLimpar_Click(sender As Object, e As EventArgs) Handles BtnLimpar.Click
        PBLimparListas.Value = 100

        Dim emails = LimparListas.ImportarCSV("D:\Projects\Felix\microcad\REGISTRONET-LISTAS\LISTA-XXXXXXXX.CSV")

        Dim emailsLimpos = LimparListas.Limpar(emails)

        MessageBox.Show(emailsLimpos.Count.ToString() + " emails foram limpos com sucesso!")
    End Sub
End Class