Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class LimparListas
    Public Shared Function ImportarCSV(filePath As String) As List(Of Email)
        Dim importedEmails = New List(Of Email)

        If IO.File.Exists(filePath) = True Then

            Dim objReader As New IO.StreamReader(filePath)

            Do While objReader.Peek() <> -1

                Dim line = objReader.ReadLine()

                If line.Contains("@") Then
                    importedEmails.Add(CreateEmail(line))
                End If
            Loop
        Else
            MessageBox.Show(filePath.Split("\").Last() & " não encontrado")
        End If

        Return importedEmails
    End Function

    Public Shared Function Limpar(emails As List(Of Email)) As List(Of Email)
        Dim url As String = "http://localhost:3333/api/emails/update"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            Dim data() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(New With {Key .emails = emails}, Formatting.Indented))
            response = Encoding.Default.GetString(webClient.UploadData(url, "post", data))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of Email))(response)
    End Function

    Private Shared Function CreateEmail(line As String) As Email
        Return New Email With {
            .email = line.Split(";").Last(),
            .nserie = "XXXXXXX",
            .data = Now.ToString("yyMMdd")
        }
    End Function
End Class
