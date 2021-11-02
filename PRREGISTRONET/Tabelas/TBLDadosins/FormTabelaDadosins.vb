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
        Dim lista = (From p In _registros
                     Group p By p.nserie0 Into Group
                     Select New With {.nserie0 = nserie0, .total = Group.Count()}).ToList

        DgvDadosinsA.DataSource = lista.Where(Function(x) x.nserie0.EndsWith("A") And x.total > 3).ToList()
        DgvDadosinsB.DataSource = lista.Where(Function(x) x.nserie0.EndsWith("B") And x.total > 1).ToList()
    End Sub
End Class