Imports System.Globalization
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class ImportarListas
    Public Shared Function ImportarTXT(filePath As String, origin As String) As List(Of Email)

        Dim importedEmails = New List(Of Email)

        If IO.File.Exists(filePath) = True Then

            Dim objReader As New IO.StreamReader(filePath)

            Do While objReader.Peek() <> -1

                Dim line = objReader.ReadLine()

                If line.Contains("@") Then
                    importedEmails.Add(CreateEmailFromTXT(line, origin))
                End If
            Loop
        Else
            MessageBox.Show(filePath.Split("\").Last() & " não encontrado")
        End If

        Return importedEmails
    End Function

    Public Shared Function ImportarCSV(filePath As String, origin As String) As List(Of Email)
        Dim importedEmails = New List(Of Email)

        If IO.File.Exists(filePath) = True Then

            Dim objReader As New IO.StreamReader(filePath)

            Do While objReader.Peek() <> -1

                Dim line = objReader.ReadLine()

                If line.Contains("@") Then
                    importedEmails.Add(CreateEmailFromCSV(line, origin))
                End If
            Loop
        Else
            MessageBox.Show(filePath.Split("\").Last() & " não encontrado")
        End If

        Return importedEmails
    End Function

    Public Shared Function ObterListaRegistronet() As List(Of Email)
        Dim url As String = "https://microcad.azurewebsites.net/api/registronet"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            response = Encoding.Default.GetString(webClient.DownloadData(url))
        End Using

        Dim list = JsonConvert.DeserializeObject(Of List(Of Email))(response)

        Return list.Where(Function(x) Not x.nserie.Equals("XXXXXXX") And Not String.IsNullOrEmpty(x.email) And x.email.Contains("@") And (x.nserie.StartsWith("T") Or x.nserie.StartsWith("M"))).Select(Function(x) CreateEmailFromRegistronet(x)).ToList()
    End Function

    Public Shared Function Salvar(emails As List(Of Email)) As List(Of Email)
        Dim url As String = "https://microcad.azurewebsites.net/api/emails/import"
        Dim response As String

        Using webClient As New WebClient
            webClient.Encoding = Encoding.UTF8
            webClient.Headers("content-type") = "application/json"

            Dim data() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(New With {Key .emails = emails}, Formatting.Indented))
            response = Encoding.Default.GetString(webClient.UploadData(url, "post", data))
        End Using

        Return JsonConvert.DeserializeObject(Of List(Of Email))(response)
    End Function

    Private Shared Function CreateEmailFromRegistronet(email As Email) As Email

        Return New Email With
        {
            .email = email.email,
            .nserie = email.nserie,
            .data = FormatDate(Now.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)),
            .origem = "Registronet"
        }
    End Function

    Private Shared Function FormatDate(data As String) As String

        If String.IsNullOrWhiteSpace(data) Then
            Return "AAMMDD"
        End If

        Dim splitedDate = data.Split("/")

        Return splitedDate.Last().Substring(2) + splitedDate(1) + splitedDate(0)
    End Function

    Private Shared Function CreateEmailFromTXT(line As String, origin As String) As Email
        Return New Email With {
            .email = line.Split(":").FirstOrDefault(Function(x) x.Contains("@")),
            .nserie = "TXXBBB",
            .data = DateTime.Now.ToString("yyMMdd"),
            .origem = origin
        }
    End Function

    Private Shared Function CreateEmailFromCSV(line As String, origin As String) As Email
        Return New Email With {
            .email = line.Split(",").FirstOrDefault(Function(x) x.Contains("@")).Replace("""", ""),
            .nserie = "TXXBBB",
            .data = DateTime.Now.ToString("yyMMdd"),
            .origem = origin
        }
    End Function
End Class
