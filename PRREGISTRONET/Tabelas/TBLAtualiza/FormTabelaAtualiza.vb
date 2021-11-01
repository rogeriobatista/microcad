Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaAtualiza
    Private Property _registros As List(Of TBLAtualiza)
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaAtualiza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizaTabela()
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click
        Salvar()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "http://localhost:3333/api/atualiza"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLAtualiza))(response)
    End Sub

    Private Sub Salvar()

        Dim registros = New List(Of TBLAtualiza)

        For Each row As DataGridViewRow In DgvTBLAtualiza.Rows
            registros.Add(row.DataBoundItem)
        Next

        Update(registros)
        ObterRegistros()
        AtualizaTabela()
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
        Dim column = DgvTBLAtualiza.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nvxx"
                _registros = _registros.OrderByDescending(Function(x) x.nvxx).ToList()
            Case "nvxxyy"
                _registros = _registros.OrderByDescending(Function(x) x.nvxxyy).ToList()
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
            Case "vxx"
                _registros = _registros.OrderByDescending(Function(x) x.vxx).ToList()
        End Select

        AtualizaTabela()
    End Sub

    Private Sub AtualizaTabela()
        DgvTBLAtualiza.DataSource = _registros
    End Sub
End Class