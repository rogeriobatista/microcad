Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class ListarListas
    Public Shared Function Listar() As List(Of Email)
        Dim url As String = "https://microcad.azurewebsites.net/api/emails"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of Email))(response)
    End Function

    Public Shared Sub Salvar(lista As List(Of Email), nomeDoArquivo As String)

        Const PATH As String = "C:\REGISTRONET-LISTAS-TESTE\"

        If Not My.Computer.FileSystem.DirectoryExists(PATH) Then
            My.Computer.FileSystem.CreateDirectory(PATH)
        End If

        Dim csvFilePath As String = PATH & nomeDoArquivo & ".csv"

        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFilePath, False)

        outFile.WriteLine("Email")

        For Each item As Email In lista
            outFile.WriteLine(item.email)
        Next

        outFile.Close()

        Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFilePath))
    End Sub
End Class
