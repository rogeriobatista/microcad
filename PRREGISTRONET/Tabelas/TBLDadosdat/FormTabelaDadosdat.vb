Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadosdat
    Private Property _registros As List(Of TBLDadosdat)

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadosdat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/dadosdat"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLDadosdat))(response)
    End Sub

    Private Sub AtualizarTabela()
        LblTotal.Text = "Total de registros: " & _registros.Count()
        DgvDadosdat.DataSource = _registros
    End Sub

    Private Sub DgvDadosdat_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosdat.ColumnHeaderMouseClick
        Dim column = DgvDadosdat.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nvxx"
                _registros = _registros.OrderByDescending(Function(x) x.nvxx).ToList()
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
            Case "ntot"
                _registros = _registros.OrderByDescending(Function(x) x.ntot).ToList()
        End Select

        AtualizarTabela()
    End Sub

    Private Sub BtnTotal_Click(sender As Object, e As EventArgs) Handles BtnTotal.Click
        FormTabelaDadosdatTotal.Show()
    End Sub
End Class