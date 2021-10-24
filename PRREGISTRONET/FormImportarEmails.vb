Public Class FormImportarEmails
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormImportarEmails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click

        RTBDetalhes.Text += "================ Importando Emails ================" & vbNewLine

        Const PATH_LISTS As String = "C:\REGISTRONET-LISTAS"

        Dim selectedLists = New List(Of String) From {
            PATH_LISTS + "\LISTA-DADOSDAT.TXT",
            PATH_LISTS + "\LISTA-DADOSLIS.CSV",
            PATH_LISTS + "\LISTA-DADOSOUT.CSV",
            PATH_LISTS + "\LISTA-DADOSWIX.CSV"
        }

        For Each list As String In selectedLists

            Dim emailsToImport

            If (list.Split(".").Last() = "TXT") Then
                emailsToImport = ImportarListas.ImportarTXT(list)
            Else
                emailsToImport = ImportarListas.ImportarCSV(list)
            End If

            ImportarLista(OrdenarLista(emailsToImport), list.Split("\").Last())

        Next

        ImportarLista(OrdenarLista(ImportarListas.ObterListaRegistronet()), "Registronet")
    End Sub

    Private Sub ImportarLista(emailsToImport As List(Of Email), listName As String)

        Dim startMessage = "Processando " & listName & vbNewLine

        RTBDetalhes.Text += startMessage

        MessageBox.Show(startMessage)

        Dim index = 0
        Dim lote = 500
        Dim importedEmails = New List(Of Email)
        While (index <= emailsToImport.Count)
            Dim emails = emailsToImport.Where(Function(x) x.ordem > index).Take(lote).ToList()

            importedEmails.AddRange(ImportarListas.Salvar(emails))

            index += lote
        End While

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

    Private Shared Function OrdenarLista(lista As List(Of Email)) As List(Of Email)

        Dim ordem = 1
        For Each item As Email In lista
            item.ordem = ordem
            ordem += 1
        Next


        Return lista
    End Function
End Class