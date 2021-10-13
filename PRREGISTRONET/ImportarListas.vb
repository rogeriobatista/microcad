Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class ImportarListas
    Public Shared Function ImportarTXT(filePath As String) As List(Of Email)

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

    Public Shared Function ObterListaRegistronet() As List(Of Email)
        Dim url As String = "http://localhost:3333/api/listRegistronet"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of Email))(response)
    End Function

    Public Shared Function Salvar(emails As List(Of Email)) As List(Of Email)
        Dim url As String = "http://localhost:3333/api/emails/update"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            Dim data() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(emails, Formatting.Indented))
            response = Encoding.Default.GetString(webClient.UploadData(url, "post", data))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of Email))(response)
    End Function

    Public Shared Function CreateEmailFromRegistronet(email As Email) As Email

        Return New Email With
        {
            .email = email.email,
            .nserie = "TXXBBB",
            .data = FormatDate(email.data)
        }
    End Function

    Private Shared Function FormatDate(data As String) As String

        If String.IsNullOrWhiteSpace(data) Then
            Return "AAMMDD"
        End If

        Dim splitedDate = data.Split("/")

        Return splitedDate.Last().Substring(2) + splitedDate(1) + splitedDate(0)
    End Function

    Private Shared Function CreateEmail(line As String) As Email
        Return New Email With {
            .Email = line.Split(":").Last(),
            .Nserie = "TXXBBB",
            .Data = DateTime.Now.ToString("yyMMdd")
        }
    End Function
End Class
