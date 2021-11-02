Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaRegistro
    Private Property _registros As List(Of TBLRegistro)

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/registro"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLRegistro))(response)
    End Sub

    Private Sub AtualizarTabela()
        DgvRegistro.DataSource = _registros
    End Sub

    Private Sub DgvRegistro_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvRegistro.ColumnHeaderMouseClick
        Dim column = DgvRegistro.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nserie"
                _registros = _registros.OrderByDescending(Function(x) x.nserie).ToList()
            Case "tipo"
                _registros = _registros.OrderByDescending(Function(x) x.tipo).ToList()
            Case "versao"
                _registros = _registros.OrderByDescending(Function(x) x.versao).ToList()
            Case "cliente"
                _registros = _registros.OrderByDescending(Function(x) x.cliente).ToList()
            Case "uf"
                _registros = _registros.OrderByDescending(Function(x) x.uf).ToList()
            Case "cgc"
                _registros = _registros.OrderByDescending(Function(x) x.cgc).ToList()
            Case "email"
                _registros = _registros.OrderByDescending(Function(x) x.email).ToList()
            Case "serial"
                _registros = _registros.OrderByDescending(Function(x) x.serial).ToList()
            Case "verant"
                _registros = _registros.OrderByDescending(Function(x) x.verant).ToList()
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class