Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaRegistronet
    Private Property _registros As List(Of TBLRegistronet)

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaRegistronet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "http://localhost:3333/api/registronet"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLRegistronet))(response)
    End Sub

    Private Sub AtualizarTabela()
        DgvRegistronet.DataSource = _registros
    End Sub

    Private Sub DgvRegistronet_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvRegistronet.ColumnHeaderMouseClick
        Dim column = DgvRegistronet.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nserie"
                _registros = _registros.OrderByDescending(Function(x) x.nserie).ToList()
            Case "nome"
                _registros = _registros.OrderByDescending(Function(x) x.nome).ToList()
            Case "nomereg"
                _registros = _registros.OrderByDescending(Function(x) x.nomereg).ToList()
            Case "programa"
                _registros = _registros.OrderByDescending(Function(x) x.programa).ToList()
            Case "tipo"
                _registros = _registros.OrderByDescending(Function(x) x.tipo).ToList()
            Case "versao"
                _registros = _registros.OrderByDescending(Function(x) x.versao).ToList()
            Case "nserieant"
                _registros = _registros.OrderByDescending(Function(x) x.nserieant).ToList()
            Case "versaoant"
                _registros = _registros.OrderByDescending(Function(x) x.versaoant).ToList()
            Case "serial"
                _registros = _registros.OrderByDescending(Function(x) x.serial).ToList()
            Case "dataenv"
                _registros = _registros.OrderByDescending(Function(x) x.dataenv).ToList()
            Case "data"
                _registros = _registros.OrderByDescending(Function(x) x.data).ToList()
            Case "valor"
                _registros = _registros.OrderByDescending(Function(x) x.valor).ToList()
            Case "desconto"
                _registros = _registros.OrderByDescending(Function(x) x.desconto).ToList()
            Case "frete"
                _registros = _registros.OrderByDescending(Function(x) x.frete).ToList()
            Case "pago"
                _registros = _registros.OrderByDescending(Function(x) x.pago).ToList()
            Case "codrastre"
                _registros = _registros.OrderByDescending(Function(x) x.codrastre).ToList()
            Case "rua"
                _registros = _registros.OrderByDescending(Function(x) x.rua).ToList()
            Case "bairro"
                _registros = _registros.OrderByDescending(Function(x) x.bairro).ToList()
            Case "cidade"
                _registros = _registros.OrderByDescending(Function(x) x.cidade).ToList()
            Case "uf"
                _registros = _registros.OrderByDescending(Function(x) x.uf).ToList()
            Case "cep"
                _registros = _registros.OrderByDescending(Function(x) x.cep).ToList()
            Case "cgc"
                _registros = _registros.OrderByDescending(Function(x) x.cgc).ToList()
            Case "telefone"
                _registros = _registros.OrderByDescending(Function(x) x.telefone).ToList()
            Case "email"
                _registros = _registros.OrderByDescending(Function(x) x.email).ToList()
            Case "emailcc"
                _registros = _registros.OrderByDescending(Function(x) x.emailcc).ToList()
            Case "obs"
                _registros = _registros.OrderByDescending(Function(x) x.obs).ToList()
        End Select

        AtualizarTabela()
    End Sub
End Class