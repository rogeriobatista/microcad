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

    Private Shared Function CreateEmail(line As String) As Email
        Return New Email With {
            .Email = line.Split(":").Last(),
            .Nserie = "TXXBBB",
            .Data = DateTime.Now.ToString("yyMMdd")
        }
    End Function
End Class
