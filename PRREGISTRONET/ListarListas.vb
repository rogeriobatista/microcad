Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class ListarListas
    Public Shared Function Listar() As List(Of Email)
        Dim url As String = "http://localhost:3333/api/emails"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of Email))(response)
    End Function
End Class
