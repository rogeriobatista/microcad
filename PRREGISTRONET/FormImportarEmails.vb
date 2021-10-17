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

        Dim emailsToValidate = New List(Of Email)

        For Each list As String In selectedLists
            RTBDetalhes.Text += "Processando " & list.Split("\").Last() & vbNewLine
            If (list.Split(".").Last() = "TXT") Then
                emailsToValidate.AddRange(ImportarListas.ImportarTXT(list))
            Else
                emailsToValidate.AddRange(ImportarListas.ImportarCSV(list))
            End If
            RTBDetalhes.Text += emailsToValidate.Count().ToString() & " emails processados" & vbNewLine
        Next

        Dim listaRegistronet = ImportarListas.ObterListaRegistronet()

        If listaRegistronet.Count > 0 Then
            emailsToValidate.AddRange(listaRegistronet)
        End If

        RTBDetalhes.Text += "================ Validando Emails ================" & vbNewLine

        Dim emailsToImport = New List(Of Email)
        Dim order As Integer = 0
        For Each email As Email In emailsToValidate
            If (Not ImportarListas.EmailInvalido(email)) Then
                email.id = order
                order += 1
                emailsToImport.Add(email)
            End If

        Next

        RTBDetalhes.Text += "================ Importando Emails ================" & vbNewLine

        Dim index As Integer = 0
        Dim lote As Integer = 5
        While index <= emailsToImport.Count
            Dim emails = emailsToImport.Where(Function(x) x.id > index).Take(lote).ToList()
            emailsToImport = ImportarListas.Salvar(emailsToImport)
            index += lote
        End While

        RTBDetalhes.Text += "==================== Concluído ====================" & vbNewLine

        If emailsToImport.Count() > 0 Then
            Dim successMessage = emailsToImport.Count().ToString() & " emails importados com sucesso!"
            RTBDetalhes.Text += successMessage & vbNewLine
            MessageBox.Show(successMessage)
        Else
            MessageBox.Show("Nenhum email foi importado!")
        End If
    End Sub
End Class