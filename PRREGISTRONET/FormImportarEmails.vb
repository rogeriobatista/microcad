Public Class FormImportarEmails
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormImportarEmails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click

        RTBDetalhes.Text += "================ Importando Emails ================" & vbNewLine

        Const listsPath As String = "C:\REGISTRONET-LISTAS"

        Dim selectedLists = New List(Of String) From {
            listsPath + "\LISTA-DADOSDAT.TXT",
            listsPath + "\LISTA-DADOSLIS.CSV",
            listsPath + "\LISTA-DADOSOUT.CSV",
            listsPath + "\LISTA-DADOSWIX.CSV"
        }

        For Each list As String In selectedLists

            Dim emailsToImport

            If (list.Split(".").Last() = "TXT") Then
                emailsToImport = ImportarListas.ImportarTXT(list)
            Else
                emailsToImport = ImportarListas.ImportarCSV(list)
            End If

            ImportarLista(emailsToImport, list.Split("\").Last())

        Next

        'ImportarLista(ImportarListas.ObterListaRegistronet(), "Registronet")
    End Sub

    Private Sub ImportarLista(emailsToImport As List(Of Email), listName As String)

        Dim startMessage = "Processando " & listName & vbNewLine

        RTBDetalhes.Text += startMessage

        MessageBox.Show(startMessage)

        Dim importedEmails = ImportarListas.Salvar(emailsToImport)

        RTBDetalhes.Text += "==================== Concluído ====================" & vbNewLine

        If importedEmails.Count() > 0 Then

            Dim successMessage = importedEmails.Count().ToString() & " emails importados com sucesso!"

            RTBDetalhes.Text += successMessage & vbNewLine

            MessageBox.Show(successMessage)
        Else
            MessageBox.Show("Nenhum email foi importado!")
        End If

        PGBImportarListas.Value += 20

    End Sub
End Class