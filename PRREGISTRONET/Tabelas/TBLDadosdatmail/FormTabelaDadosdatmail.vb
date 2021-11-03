Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class FormTabelaDadosdatmail
    Private Property _registros As List(Of TBLDadosdatmail)

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub FormTabelaDadosdatmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObterRegistros()
        AtualizarTabela()
    End Sub

    Private Sub ObterRegistros()
        Dim url As String = "https://microcad.azurewebsites.net/api/dadosdatmail"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        _registros = JsonConvert.DeserializeObject(Of List(Of TBLDadosdatmail))(response)
    End Sub

    Private Sub AtualizarTabela()
        LblTotal.Text = "Total de registros: " & _registros.Count()
        DgvDadosdatmail.DataSource = _registros
    End Sub

    Private Sub DgvDadosdatmail_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDadosdatmail.ColumnHeaderMouseClick
        Dim column = DgvDadosdatmail.Columns.Item(e.ColumnIndex).Name

        Select Case column
            Case "nmail"
                _registros = _registros.OrderByDescending(Function(x) x.nmail).ToList()
            Case "ndata"
                _registros = _registros.OrderByDescending(Function(x) x.ndata).ToList()
            Case "nhora"
                _registros = _registros.OrderByDescending(Function(x) x.nhora).ToList()
            Case "nvxx"
                _registros = _registros.OrderByDescending(Function(x) x.nvxx).ToList()
        End Select

        AtualizarTabela()
    End Sub

    Private Sub BtnExportarEmail_Click(sender As Object, e As EventArgs) Handles BtnExportarEmail.Click
        Const PATH As String = "C:\REGISTRONET-LISTAS\"

        If Not My.Computer.FileSystem.DirectoryExists(PATH) Then
            My.Computer.FileSystem.CreateDirectory(PATH)
        End If

        Dim csvFilePath As String = PATH & "Dadosdatmail.txt"

        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFilePath, False)

        For Each item As TBLDadosdatmail In _registros
            outFile.WriteLine(item.nmail)
        Next

        outFile.Close()

        MessageBox.Show("Arquivo gerado com sucesso!")
    End Sub
End Class