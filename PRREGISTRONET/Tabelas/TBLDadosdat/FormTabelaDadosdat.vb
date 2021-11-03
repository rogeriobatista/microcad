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
        DgvDadosdat.DataSource = (From p In _registros
                                  Group p By p.ndata Into Group
                                  Select New With {.ndata = ndata, .total = Group.Sum(Function(x) x.ntot)}).ToList

        LblTotal.Text = "Total de registros: " & DgvDadosdat.Rows.Count()
    End Sub

    Private Sub DgvDadosdat_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosdat.ColumnHeaderMouseClick
        Dim column = DgvDadosdat.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
            Case "total"
                _registros = _registros.OrderByDescending(Function(x) x.ntot).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class