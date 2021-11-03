Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadostxt
    Private Property _registros As List(Of TBLDadostxt)
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadostxt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/dadostxt"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLDadostxt))(response)
    End Sub

    Private Sub AtualizarTabela()
        LblTotal.Text = "Total de registros: " & _registros.Count()
        DgvDadostxt.DataSource = _registros
    End Sub

    Private Sub DgvDadostxt_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadostxt.ColumnHeaderMouseClick
        Dim column = DgvDadostxt.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "ncmd"
                _registros = _registros.OrderByDescending(Function(x) x.ncmd).ToList()
            Case "ntot"
                _registros = _registros.OrderByDescending(Function(x) x.ntot).ToList()
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class