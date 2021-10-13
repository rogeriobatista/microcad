Public Class FormImportarEmails
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormImportarEmails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CLBImportarEmails.Items.Add("C:\REGISTRONET-LISTAS\LISTA-DADOSDAT.TXT", True)
        CLBImportarEmails.Items.Add("C:\REGISTRONET-LISTAS\LISTA-DADOSLIS.CSV", True)
        CLBImportarEmails.Items.Add("C:\REGISTRONET-LISTAS\LISTA-DADOSOUT.CSV", True)
        CLBImportarEmails.Items.Add("C:\REGISTRONET-LISTAS\LISTA-DADOSWIX.CSV", True)
    End Sub

    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click

        Dim selectedLists = CLBImportarEmails.CheckedItems

        Dim emailsToImport = New List(Of Email)

        For Each list As String In selectedLists
            RTBDetalhes.Text += "Processando " & list.Split("\").Last() & vbNewLine
            If (list.Split(".").Last() = "TXT") Then
                emailsToImport.AddRange(ImportarListas.ImportarTXT(list))
            Else
                emailsToImport.AddRange(ImportarListas.ImportarCSV(list))
            End If
            RTBDetalhes.Text += emailsToImport.Count().ToString() & " emails processados" & vbNewLine
        Next

        Dim listaRegistronet = ImportarListas.ObterListaRegistronet()

        If listaRegistronet.Count > 0 Then
            emailsToImport.AddRange(listaRegistronet)
        End If

        RTBDetalhes.Text += "==================== Importando Emails ====================" & vbNewLine

        Dim importedEmails = ImportarListas.Salvar(emailsToImport)

        RTBDetalhes.Text += "==================== Concluído ====================" & vbNewLine

        If importedEmails.Count() > 0 Then
            Dim successMessage = importedEmails.Count().ToString() & " emails importados com sucesso!"
            RTBDetalhes.Text += successMessage & vbNewLine
            MessageBox.Show(successMessage)
        Else
            MessageBox.Show("Nenhum email foi importado!")
        End If
    End Sub
End Class