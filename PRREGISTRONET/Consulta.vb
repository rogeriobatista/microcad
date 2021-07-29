Imports Newtonsoft.Json
Public Class Consulta
    Public Shared Function ConsultarPor(campo As String, consulta As String) As List(Of Registro)
        Using webClient As New Net.WebClient
            webClient.Encoding = Text.Encoding.UTF8
            Dim result As String = webClient.DownloadString("https://microcad.azurewebsites.net/apilisregistronet/" + campo + "/" + consulta)
            Return JsonConvert.DeserializeObject(Of List(Of Registro))(result)
        End Using
    End Function
End Class
