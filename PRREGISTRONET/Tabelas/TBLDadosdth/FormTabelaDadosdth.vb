Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadosdth
    Private Property _registros As List(Of TBLDadosdth)
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadosdth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/dadosdth"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLDadosdth))(response)
    End Sub

    Private Sub AtualizarTabela()
        LblTotal.Text = "Total de registros: " & _registros.Count()
        DgvDadosdth.DataSource = _registros
    End Sub

    Private Sub DgvDadosdth_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosdth.ColumnHeaderMouseClick
        Dim column = DgvDadosdth.Columns.Item(e.ColumnIndex).Name

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
        End Select

        AtualizarTabela()
    End Sub
End Class