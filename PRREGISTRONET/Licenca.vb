Imports Newtonsoft.Json

Public Class Licenca
    Public Property valid As Boolean
    Public Shared Function Validar(nserie As String, uname As String, cname As String) As Boolean
        Dim url = "https://microcad.azurewebsites.net/apimicrocad?nserie=" + nserie + "&uname=" + uname + "&cname=" + cname

        Using webClient As New Net.WebClient
            webClient.Encoding = Text.Encoding.UTF8
            Dim result As String = webClient.DownloadString(url)
            Dim licenca = JsonConvert.DeserializeObject(Of Licenca)(result)
            Return licenca.valid
        End Using
    End Function
End Class
