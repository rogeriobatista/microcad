Imports System.ComponentModel
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaAtualiza
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaAtualiza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim registros = ObterRegistros()

        Dim items = New BindingList(Of TBLAtualiza)

        For Each item As TBLAtualiza In registros
            items.Add(item)
        Next

        Dim dataSource = New BindingSource() With {
            .DataSource = items
        }

        DgvTBLAtualiza.DataSource = dataSource

        For Each column As DataGridViewColumn In DgvTBLAtualiza.Columns
            column.SortMode = DataGridViewColumnSortMode.Programmatic
        Next

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click
        DgvTBLAtualiza.EditMode = False
        Salvar()
        DgvTBLAtualiza.EditMode = True
    End Sub

    Private Shared Function ObterRegistros() As List(Of TBLAtualiza)
        Dim url As String = "http://localhost:3333/api/atualiza"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of TBLAtualiza))(response)
    End Function

    Private Sub Salvar()
        Dim registros = New List(Of TBLAtualiza)

        For Each row As DataGridViewRow In DgvTBLAtualiza.Rows
            registros.Add(row.DataBoundItem)
        Next


    End Sub

    Public Sub Update(registros As List(Of TBLAtualiza))
        Dim url As String = "http://localhost:3333/api/atualiza/update"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            Dim data() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(New With {Key .registros = registros}, Formatting.Indented))
            response = Encoding.Default.GetString(webClient.UploadData(url, "post", data))
        End Using
    End Sub

    Private Sub DgvTBLAtualiza_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvTBLAtualiza.ColumnHeaderMouseClick
        DgvTBLAtualiza.Sort(DgvTBLAtualiza.Columns(e.ColumnIndex), ComponentModel.ListSortDirection.Ascending)
    End Sub
End Class