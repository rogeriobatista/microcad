Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaXemail
    Private Property _registros As List(Of TBLXemail)

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaXemail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/xemail"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLXemail))(response)
    End Sub

    Private Sub AtualizarTabela()
        LblTotal.Text = "Total de registros: " & _registros.Count()
        DgvXemail.DataSource = _registros
    End Sub

    Private Sub DgvXemail_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvXemail.ColumnHeaderMouseClick
        Dim column = DgvXemail.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nserie"
                _registros = _registros.OrderByDescending(Function(x) x.nserie).ToList()
            Case "email"
                _registros = _registros.OrderByDescending(Function(x) x.email).ToList()
            Case "data"
                _registros = _registros.OrderByDescending(Function(x) x.data).ToList()
            Case "origem"
                _registros = _registros.OrderByDescending(Function(x) x.origem).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class