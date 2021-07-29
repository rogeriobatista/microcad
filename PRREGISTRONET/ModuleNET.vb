Imports System.ComponentModel
Module ModuleNET
    Public Function SomenteNumeros(Numero As String) As String
        Dim Tamanho As Integer, RESULTADO As String, A As Integer
        If Numero = "" Then
            SomenteNumeros = ""
            Exit Function
        End If
        Tamanho = Len(Trim(Numero))
        RESULTADO = ""
        For A = 1 To Tamanho
            If Asc(Mid(Numero, A, 1)) >= 48 And Asc(Mid(Numero, A, 1)) <= 57 Then
                RESULTADO = RESULTADO + Mid(Numero, A, 1)
            End If
        Next
        SomenteNumeros = RESULTADO
    End Function
    Public Function mascaraCNPJ_CPF(doc As String) As String
        Dim mascara As New MaskedTextProvider("00\.000\.000/0000-00")

        If SomenteNumeros(doc).Length = 11 Then
            mascara = New MaskedTextProvider("000\.000\.000-00")
        End If

        mascara.Set(doc)
        Return mascara.ToString()
    End Function
End Module
