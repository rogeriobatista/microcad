Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadosinsSegregado
    Private Property _registros As List(Of TBLDadosins)

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadosinsSegregado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabelas()
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

    Private Sub AtualizarTabelaA()
        Dim lista = (From p In _registros
                     Group p By p.nserie0 Into Group
                     Select New With {.nserie0 = nserie0, .total = Group.Count()}).ToList

        DgvDadosinsA.DataSource = lista.Where(Function(x) x.nserie0.EndsWith("A") And x.total > 3).ToList()

        LblTotalA.Text = "Total de registros: " & DgvDadosinsA.Rows.Count()
    End Sub

    Private Sub AtualizarTabelaB()
        Dim lista = (From p In _registros
                     Group p By p.nserie0 Into Group
                     Select New With {.nserie0 = nserie0, .total = Group.Count()}).ToList

        DgvDadosinsB.DataSource = lista.Where(Function(x) x.nserie0.EndsWith("B") And x.total > 1).ToList()

        LblTotalB.Text = "Total de registros: " & DgvDadosinsB.Rows.Count()
    End Sub

    Private Sub AtualizarTabelas()
        AtualizarTabelaA()
        AtualizarTabelaB()
    End Sub

    Private Sub DgvDadosinsA_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosinsA.ColumnHeaderMouseClick
        Dim column = DgvDadosinsA.Columns.Item(e.ColumnIndex).Name

        Dim lista = (From p In _registros
                     Group p By p.nserie0 Into Group
                     Select New With {.nserie0 = nserie0, .total = Group.Count()}).ToList

        lista = lista.Where(Function(x) x.nserie0.EndsWith("A") And x.total > 3).ToList()

        Select Case column
            Case "nserie0"
                DgvDadosinsA.DataSource = lista.OrderByDescending(Function(x) x.nserie0).ToList()
            Case "total"
                DgvDadosinsA.DataSource = lista.OrderByDescending(Function(x) x.total).ToList()
        End Select
    End Sub

    Private Sub DgvDadosinsB_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosinsB.ColumnHeaderMouseClick
        Dim column = DgvDadosinsB.Columns.Item(e.ColumnIndex).Name

        Dim lista = (From p In _registros
                     Group p By p.nserie0 Into Group
                     Select New With {.nserie0 = nserie0, .total = Group.Count()}).ToList

        lista = lista.Where(Function(x) x.nserie0.EndsWith("B") And x.total > 1).ToList()

        Select Case column
            Case "nserie0"
                DgvDadosinsB.DataSource = lista.OrderByDescending(Function(x) x.nserie0).ToList()
            Case "total"
                DgvDadosinsB.DataSource = lista.OrderByDescending(Function(x) x.total).ToList()
        End Select
    End Sub
End Class