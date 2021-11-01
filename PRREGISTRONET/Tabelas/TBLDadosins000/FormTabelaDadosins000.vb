Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadosins000
    Private Property _registros As List(Of TBLDadosins000)
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadosins000_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "http://localhost:3333/api/dadosins000"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLDadosins000))(response)
    End Sub

    Private Sub AtualizarTabela()
        DgvDadosins000.DataSource = _registros
    End Sub

    Private Sub DgvDadosins000_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosins000.ColumnHeaderMouseClick
        Dim column = DgvDadosins000.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nvxx"
                _registros = _registros.OrderByDescending(Function(x) x.nvxx).ToList()
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
            Case "totd"
                _registros = _registros.OrderByDescending(Function(x) x.totd).ToList()
            Case "exe"
                _registros = _registros.OrderByDescending(Function(x) x.exe).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class