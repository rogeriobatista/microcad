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

        Dim importedItems = New List(Of Email)

        For Each list As String In selectedLists
            RTBDetalhes.Text += "Importando " & list.Split("\").Last() & vbNewLine
            If (list.Split(".").Last() = "TXT") Then
                importedItems.AddRange(ImportarListas.ImportarTXT(list))
            Else
                importedItems.AddRange(ImportarListas.ImportarCSV(list))
            End If
            RTBDetalhes.Text += importedItems.Count().ToString() & " items importados" & vbNewLine
        Next

        MessageBox.Show("Importação concluída com sucesso!")
    End Sub
End Class