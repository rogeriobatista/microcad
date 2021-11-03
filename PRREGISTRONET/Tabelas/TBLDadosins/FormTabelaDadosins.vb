Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadosins
    Private Property _registros As List(Of TBLDadosins)
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadosins_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/dadosins"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLDadosins))(response)
    End Sub

    Private Sub AtualizarTabela()
        LblTotal.Text = "Total de registros: " & _registros.Count()
        DgvDadosins.DataSource = _registros
    End Sub

    Private Sub BtnDadosSegregados_Click(sender As Object, e As EventArgs) Handles BtnDadosSegregados.Click
        FormTabelaDadosinsSegregado.Show()
    End Sub

    Private Sub DgvDadosins_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosins.ColumnHeaderMouseClick
        Dim column = DgvDadosins.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nserie0"
                _registros = _registros.OrderByDescending(Function(x) x.nserie0).ToList()
            Case "uname"
                _registros = _registros.OrderByDescending(Function(x) x.uname).ToList()
            Case "cname"
                _registros = _registros.OrderByDescending(Function(x) x.cname).ToList()
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
            Case "nhora"
                _registros = _registros.OrderByDescending(Function(x) x.nhora).ToList()
            Case "udata"
                _registros = _registros.OrderByDescending(Function(x) x.udata).ToList()
            Case "uhora"
                _registros = _registros.OrderByDescending(Function(x) x.uhora).ToList()
            Case "chave"
                _registros = _registros.OrderByDescending(Function(x) x.chave).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class