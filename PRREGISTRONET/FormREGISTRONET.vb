Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports System.Net.Mail
Imports Microsoft.Office.Interop

Public Class FormREGISTRONET
    Public XCLIENTE, XNSERIE, XTIPO, XVERSAO, XVANT, XVALOR, XCODRAS, XEMAIL, XEMACC, XSERIAL, XUF, XCGC As String
    Public XFROM1, XFROM2, XSMTP, XPORTA, XCRED1, XCRED2, XIMAGE, XTITU, XLINK, AAA, XXX As String
    Public XDIA, XMES, XANO, XMICRO, XNOME, XPROGRA, LINHA As String
    Public JSON, VNSERIE, VNSERIE1, JSURL, XNSE, UNAME, CNAME, STRDATA, ARQPDF, TXT As String
    Public FLAGMAIS, FLAGMENOS, FLAGSALVAR, XSSL As Boolean
    Public RETCOD As Integer
    '
    Private Sub FormREGISTRONET_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '...VERIFICA USUARIO NA API
        XNSE = "REGV01"
        UNAME = UCase(Environ$("USERNAME"))
        CNAME = UCase(Environ$("COMPUTERNAME"))
        '
        Dim DATAEHORA As DateTime = DateTime.Now
        STRDATA = DATAEHORA.ToString("dd/MM/yy")
        '
        If Not Licenca.Validar(XNSE, UNAME, CNAME) Then
            FormLicencaInvalida.ShowDialog()
        End If
        '...
        If CNAME = "5-FELIX" Or CNAME = "FELIX-PC1" Or CNAME = "FELIX-PC2" Then
            CHKD1.Checked = True
            CHKD2.Checked = False
            CHKP0.Checked = True
            CHKP1.Checked = True
            CHKP2.Checked = False
        Else
            CHKD1.Checked = False
            CHKD2.Checked = True
            CHKP0.Checked = True
            CHKP1.Checked = True
            CHKP2.Checked = True
        End If

        Me.KeyPreview = True
        CMDSALVAR.Enabled = False
        SUBMOSTRADADOS("")
        Me.Text = "REGISTRONET - " & XNSE & ".0 * " & UNAME & " - " & CNAME
        '
    End Sub
    'Private Sub FormREGISTRONET_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    'If e.KeyCode = Keys.Enter Then
    'Me.SelectNextControl(Me.ActiveControl, True, True, False, True)
    'End If
    'End Sub

    Private Sub CMDATUALIZA_Click(sender As Object, e As EventArgs) Handles CMDATUALIZA.Click
        Dim LINHA As String
        LINHA = "ATUALIZADO DE " & TXTNSERIE.Text & " " & TXTVERSAO.Text & " DE " & TXTDATA.Text & " R$" & TXTVALOR.Text
        TXTDATA.Text = STRDATA
        TXTVALOR.Text = ""
        If TXTVERSAO.Text = "V15" Then TXTVALOR.Text = "400,00"
        If TXTVERSAO.Text = "V14" Then TXTVALOR.Text = "450,00"
        If TXTVERSAO.Text = "V13" Then TXTVALOR.Text = "500,00"
        If TXTVERSAO.Text = "V12" Then TXTVALOR.Text = "550,00"
        If TXTVERSAO.Text = "V11" Then TXTVALOR.Text = "600,00"
        If TXTVERSAO.Text = "V10" Then TXTVALOR.Text = "650,00"

        TXTVANT.Text = TXTVERSAO.Text
        TXTVERSAO.Text = "V16"
        TXTNSERIEA.Text = TXTNSERIE.Text

        SUBULTIMO()
        TXTNSERIE.Enabled = False
        TXTNSERIE.Text = VNSERIE1
        TXTNOME.Focus()

        If TXTDESCO.Text <> "" Then LINHA = LINHA & " D:R$" & TXTDESCO.Text
        If TXTFRETE.Text <> "" Then LINHA = LINHA & TXTFRETE.Text
        '
        LINHA = LINHA & " " & TXTPAGO.Text & " " & TXTCODRAS.Text
        TXTOBSREG.Text = LINHA & vbCrLf & TXTOBSREG.Text
        TXTDESCO.Text = "??"
        TXTPAGO.Text = "??"
        '
        'TXTDATA.Text = "01/05/21" '<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        'TXTVALOR.Text = "PROMO"   '<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        'TXTPAGO.Text = ""         '<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        '
        TXTFRETE.Text = ""
        TXTCODRAS.Text = ""

    End Sub


    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDIMPRIMIRDECLARA_Click(sender As Object, e As EventArgs) Handles CMDIMPRIMIRDECLARA.Click
        Dim PROGRA, ARQDOC As String
        Dim VTOTAL As Double
        Dim VVTOTAL As String
        'Dim VVTOTAL, VVDESCO, VFRETE, STRD As String
        Dim I As Integer
        '''''''''
        PROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "TOPOCAD" Then PROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "MEMORIAL" Then PROGRA = "MEMORIALCAD"
        If TXTPROGRAMA.Text = "PERFIS" Then PROGRA = "PERFIS2000"
        If TXTPROGRAMA.Text = "QFCAD" Then PROGRA = "QFCAD2000"

        ARQDOC = Application.StartupPath & "\PAG-DECLARA.DOC"

        Dim wordAPP As Word._Application = New Word.Application
        wordAPP.Visible = True
        wordAPP.Documents.Open(ARQDOC, ReadOnly:=False)
        Dim wordDoc As Word._Document = wordAPP.ActiveDocument 'word_app.Documents.Add() (novo)
        Dim PAWD As Word.Paragraph = wordDoc.Paragraphs.Add()
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Name = "Courier New"
        PAWD.Range.Font.Size = 5
        For I = 1 To 18
            PAWD.Range.Text = vbCrLf
            PAWD.Range.InsertParagraphAfter()
        Next I
        VTOTAL = CDbl(TXTVALOR.Text)

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = "       MICROCAD COMPUTAÇÃO GRAFICA LTDA-ME                    " & TXTNOME.Text
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "2"
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = "          RUA DA CONCEIÇÃO - 101 / LOJA 19                        " & TXTRUANO.Text
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "4"
        PAWD.Range.Text = " "
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Size = "8"

        PAWD.Range.Text = "          CENTRO                                                  " & TXTBAIRRO.Text
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "4"
        PAWD.Range.Text = " "
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = "          NITEROI                             RJ                " & TXTCIDADE.Text.PadRight(30, " ") & "         " & TXTUF.Text
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "2"
        PAWD.Range.Text = " "
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = "          24007-900              01.662.825/0001-34           " & TXTCEP.Text & "                 " & TXTCGC.Text
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "2"
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Text = vbCrLf & vbCrLf
        PAWD.Range.InsertParagraphAfter()

        If TXTDESCO.Text <> "" And TXTDESCO.Text <> "0" Then
            VTOTAL = VTOTAL - CDbl(TXTDESCO.Text)
        End If
        VVTOTAL = Format(VTOTAL, "##0.00")
        PAWD.Range.Text = "  1       PENDRIVE + DVD (PROGRAMA: " & PROGRA & "     " & TXTVERSAO.Text & "     N.S.: " & TXTNSERIE.Text & ")          1             R$" & VVTOTAL & vbCrLf & vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Text = "                                                                                      R$" & VVTOTAL
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "4"
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = "8"
        PAWD.Range.Text = "                                                                                         0,300" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Text = "     NITEROI, " & XDIA & " / " & XMES & " / " & XANO
        PAWD.Range.InsertParagraphAfter()
        '
        MsgBox("DECLARAÇÃO DE CONTEUDO CRIADO COM SUCESSO!")
    End Sub
    '
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDIMPRIMIRETQ_Click(sender As Object, e As EventArgs) Handles CMDIMPRIMIRETQ.Click

        Dim wordAPP As Word._Application = New Word.Application
        wordAPP.Visible = True
        Dim wordDoc As Word._Document = wordAPP.Documents.Add()
        Dim PAWD As Word.Paragraph = wordDoc.Paragraphs.Add()
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Name = "Courier New"
        PAWD.Range.Font.Size = 10
        PAWD.Range.Font.Bold = False
        PAWD.Range.Text = New String("_", 50)
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = "DESTINATARIO:"
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Size = 14
        PAWD.Range.Font.Bold = True
        PAWD.Range.Text = TXTNOME.Text
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = TXTRUANO.Text
        PAWD.Range.InsertParagraphAfter()
        If Len(TXTBAIRRO.Text) <> 1 Then
            PAWD.Range.Text = TXTBAIRRO.Text & " - " & TXTCIDADE.Text & " - " & TXTUF.Text
        Else
            PAWD.Range.Text = TXTCIDADE.Text & " - " & TXTUF.Text
        End If
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = TXTCEP.Text
        PAWD.Range.InsertParagraphAfter()

        PAWD.Range.Font.Size = 10
        PAWD.Range.Font.Bold = False
        PAWD.Range.Text = New String("_", 50)
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()
        '
        PAWD.Range.Font.Size = 10
        PAWD.Range.Font.Bold = False
        PAWD.Range.Text = New String("_", 50)
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Size = 10
        PAWD.Range.Text = "REMETENTE:"
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Size = 13
        PAWD.Range.Font.Bold = True
        PAWD.Range.Text = "MICROCAD COMPUTAÇÃO GRAFICA"
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = "RUA DA CONCEIÇÃO - 101 / LOJA 19"
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = "CENTRO - NITERÓI - RJ"
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = "24007-900"
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Size = 10
        PAWD.Range.Font.Bold = False
        PAWD.Range.Text = New String("_", 50)
        PAWD.Range.InsertParagraphAfter()
        '
        MsgBox("ETIQUETA CORREIOS ENVIADA PARA IMPRESSORA COM SUCESSO!")
    End Sub
    '
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDIMPRIMIRREC_Click(sender As Object, e As EventArgs) Handles CMDIMPRIMIRREC.Click
        Dim ARQDOCX, STRD, PROGRA, ARQDOC As String
        Dim VTOTAL As Double
        Dim VVTOTAL, VVDESCO, VFRETE As String
        Dim I As Integer
        '''''''''
        PROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "TOPOCAD" Then PROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "MEMORIAL" Then PROGRA = "MEMORIALCAD"
        If TXTPROGRAMA.Text = "PERFIS" Then PROGRA = "PERFIS2000"
        If TXTPROGRAMA.Text = "QFCAD" Then PROGRA = "QFCAD2000"

        ARQDOC = My.Application.Info.DirectoryPath & "\PAG-RECIBO.DOC"

        Dim wordAPP As Word._Application = New Word.Application
        wordAPP.Visible = True
        wordAPP.Documents.Open(ARQDOC, ReadOnly:=False)
        Dim wordDoc As Word._Document = wordAPP.ActiveDocument 'word_app.Documents.Add() (novo)
        Dim PAWD As Word.Paragraph = wordDoc.Paragraphs.Add()
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Font.Name = "Courier New"
        PAWD.Range.Font.Size = 11
        For I = 1 To 6
            PAWD.Range.Text = vbCrLf
            PAWD.Range.InsertParagraphAfter()
        Next I
        PAWD.Range.Font.Name = "Courier New"
        PAWD.Range.Font.Size = 12
        PAWD.Range.Font.Bold = True
        PAWD.Range.Text = "    NOME: " & TXTNOME.Text
        PAWD.Range.InsertParagraphAfter()


        If TXTRUANO.Text = "" Or TXTRUANO.Text = " " Then
        Else
            PAWD.Range.Text = "    ENDEREÇO: " & TXTRUANO.Text
            PAWD.Range.InsertParagraphAfter()
        End If

        If TXTBAIRRO.Text = "" Or TXTBAIRRO.Text = " " Then
            PAWD.Range.Text = "    CIDADE: " & TXTCIDADE.Text & " - " & TXTUF.Text
            PAWD.Range.InsertParagraphAfter()
        Else
            PAWD.Range.Text = "    BAIRRO: " & TXTBAIRRO.Text & " - CIDADE: " & TXTCIDADE.Text & " - " & TXTUF.Text
            PAWD.Range.InsertParagraphAfter()
        End If

        If TXTCEP.Text = "" Or TXTCEP.Text = " " Then
        Else
            PAWD.Range.Text = "    CEP: " & TXTCEP.Text
            PAWD.Range.InsertParagraphAfter()
        End If

        PAWD.Range.Text = "    CPF/CNPJ: " & TXTCGC.Text
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = "    DATA: " & STRDATA
        PAWD.Range.InsertParagraphAfter()
        PAWD.Range.Text = vbCrLf
        PAWD.Range.InsertParagraphAfter()

        If TXTRUANO.Text = "" Or TXTRUANO.Text = " " Then
            PAWD.Range.Text = vbCrLf
            PAWD.Range.InsertParagraphAfter()
        End If
        If TXTCEP.Text = "" Or TXTCEP.Text = " " Then
            PAWD.Range.Text = vbCrLf
            PAWD.Range.InsertParagraphAfter()
        End If

        PAWD.Range.Font.Name = "Courier New"
        PAWD.Range.Font.Size = 10
        PAWD.Range.Text = vbCrLf + vbCrLf + vbCrLf
        VTOTAL = CDbl(TXTVALOR.Text)
        PAWD.Range.Text = "     LICENÇA DE USO DO PROGRAMA " & PROGRA & " " & TXTVERSAO.Text & " N.S.: " & TXTNSERIE.Text & ".........R$" & TXTVALOR.Text & vbCrLf & vbCrLf

        If TXTDESCO.Text <> "" And TXTDESCO.Text <> "0" Then
            VVDESCO = Format(CDbl(Val(TXTDESCO.Text)), "##0.00")
            PAWD.Range.Text = "     DESCONTO .......................................................-R$ " & VVDESCO & vbCrLf & vbCrLf
            VTOTAL = VTOTAL - CDbl(TXTDESCO.Text)
        End If

        If TXTFRETE.Text <> "" Then
            VFRETE = TXTFRETE.Text
            If Mid(VFRETE, 1, 2) = "P:" Or Mid(VFRETE, 1, 2) = "S:" Then VFRETE = Mid(VFRETE, 3)
            VFRETE = Format(CDbl(VFRETE), "##0.00")
            PAWD.Range.Text = "     FRETE ...........................................................R$ " & VFRETE & vbCrLf & vbCrLf
            VTOTAL = VTOTAL + CDbl(VFRETE)
        End If

        VVTOTAL = Format(VTOTAL, "##0.00")
        PAWD.Range.Text = "     TOTAL ...........................................................R$" & VVTOTAL & vbCrLf & vbCrLf

        STRD = My.Application.Info.DirectoryPath & "\RECPDF"
        If Dir(STRD, FileAttribute.Directory) = "" Then
            MkDir(STRD)
            MsgBox(STRD & " CRIADO COM SUCESSO")
        End If

        If TXTNSERIE.Text <> "" Then
            ARQDOCX = STRD & "\" & PROGRA & "_REC_" & TXTVERSAO.Text & "-" & TXTNSERIE.Text & ".pdf"
            wordAPP.ActiveDocument.ExportAsFixedFormat(ARQDOCX, 17, False)
            MsgBox("RECIBO CRIADO COM SUCESSO!")
        End If

        'wordDoc.SaveAs(FileName:=ARQDOC)
        'Dim save_changes As Object = False
        'wordDoc.Close(save_changes)
        'wordAPP.Quit(save_changes)
        '
    End Sub

    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDENVIAREMAILCORREIOS_Click(sender As Object, e As EventArgs) Handles CMDENVIAREMAILCORREIOS.Click
        XPROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "MEMORIAL" Then XPROGRA = "MEMORIALCAD"

        If TXTNSERIE.Text = "" Or TXTCODRAS.Text = "" Or TXTEMAIL.Text = "" Then
            If TXTNSERIE.Text = "" Then MsgBox("NUMERO DE SERIE EM BRANCO!")
            If TXTCODRAS.Text = "" Then MsgBox("CODIGO DE RASTREAMENTO EM BRANCO!")
            If TXTEMAIL.Text = "" Then MsgBox("EMAIL EM BRANCO!")
            MsgBox("EMAIL NÃO PODE SER ENVIADO!")
            End
        Else
            If CHKD1.Checked = True Then
                XFROM1 = "microcad@terra.com.br"
                XCRED2 = "Acad2005"
                XFROM2 = "MICROCAD-Computação Grafica e Sistemas"
                XSMTP = "smtp.nri.terra.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            Else
                XFROM1 = "comercial@topocad2000.com.br"
                XCRED2 = "@Acadr14"
                XFROM2 = "MICROCAD-TOPOCAD2000 (Comercial)"
                XSMTP = "smtp.topocad2000.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            End If
            '
            XCLIENTE = TXTNOME.Text
            XNSERIE = TXTNSERIE.Text
            XTIPO = TXTTIPO.Text
            XVERSAO = TXTVERSAO.Text
            XVANT = TXTVANT.Text
            XSERIAL = TXTSERIAL.Text
            XCODRAS = TXTCODRAS.Text
            XEMAIL = TXTEMAIL.Text
            XEMACC = TXTEMAILCC.Text
            XUF = TXTUF.Text
            '
            If MessageBox.Show("ENVIAR EMAIL CORREIOS?" & vbCrLf & XCLIENTE & vbCrLf & XNSERIE & vbCrLf & XCODRAS & vbCrLf & XEMAIL, "ENVIAR EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ENVIA_CORREIOS()
            End If
        End If
    End Sub
    Private Sub ENVIA_CORREIOS()
        XIMAGE = Application.StartupPath & "\" & "TOPOCAD2000-COR.jpg"

        XLINK = "http://www.amicrocad.com.br/#!loja-topocad2000/c1knd"
        XTITU = XPROGRA & "-" & XVERSAO & "-" & XNSERIE & " CORREIOS"

        AAA = ""
        AAA = AAA & "<p class=MsoNormal style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & " " & XVERSAO & " - " & XNSERIE & " >>> " & XCLIENTE & " >>> enviado pelo Correios: <span style='color:#1F497D'>" & XCODRAS & "<br></span>"

        AAA = AAA & "<p><span style='font-family:""Arial"",""sans-serif""'>Acompanhe <a href=""http://websro.correios.com.br/sro_bin/txect01$.QueryList?P_LINGUA=001&amp;P_TIPO=001&amp;P_COD_UNI=" & XCODRAS & """>clicando aqui</a>"
        AAA = AAA & " ou pelo código através do site dos Correios pelo link: <a href=""http://www.correios.com.br/servicos/rastreamento/rastreamento.cfm"">http://www.correios.com.br/servicos/rastreamento/rastreamento.cfm</a>.<o:p></o:p></span></p>"

        AAA = AAA & "<br><span style='color:#1F497D'>*SUPORTE AO USUÁRIO das 10:00hs às 17:00hs de 2ª. A 6ª. Feira):<o:p></o:p></b></span></p>"

        If Mid(XNSERIE, 1, 1) = "T" Then AAA = AAA & "<p class=MsoNormal><span style='font-family:""Arial"",""sans-serif"" '>-Por email&nbsp;(<a href=""mailto:contato@topocad2000.com.br"">contato@topocad2000.com.br</a>): ilimitado.<o:p></o:p></span></p>"
        If Mid(XNSERIE, 1, 1) = "M" Then AAA = AAA & "<p class=MsoNormal><span style='font-family:""Arial"",""sans-serif"" '>-Por email&nbsp;(<a href=""mailto:contato@memorialcad.com.br"">contato@memorialcad.com.br</a>): ilimitado.<o:p></o:p></span></p>"

        AAA = AAA & "<p class=MsoNormal><span style='font-family:""Arial"",""sans-serif""'>-Por telefone (21-2722-3000): 1 mês.<o:p></o:p></span></p>"

        AAA = AAA & "<p class=MsoNormal><span style='font-family:""Arial"",""sans-serif""'>-Acesso remoto pelo Teamviewer para resolução de problemas: um ano<o:p></o:p></span></p>"

        AAA = AAA & "<p class=MsoNormal><span style='font-family:""Arial"",""sans-serif""'>Garantia da chave pendrivelock: um ano.<o:p></o:p></span></p>"

        AAA = AAA & "<p class=MsoNormal><span style='font-family:""Arial"",""sans-serif""'>Atualizações semanais grátis: versão atual.<o:p></o:p></span></p>"

        AAA = AAA & "<p class=MsoNormal style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif"";color:#1F497D'>"
        AAA = AAA & "<br><b>*LINK PARA ACESSO REMOTO:&nbsp;&nbsp; </b></span><b><span style='font-family:""Arial"",""sans-serif"";color:#464646;background:yellow'><ahref=""http://get.teamviewer.com/yjyrpcs"" target=""_blank"">http://get.teamviewer.com/yjyrpcs</a><br><br></span></b><span style='font-family:""Arial"",""sans-serif"";color:#1F497D'>1- Será então mostrado uma tela com as informações de SUA ID e SENHA.<br>2- Informe-os por email que então faremos o acesso em sua máquina.<br>3- A ID é fixa para um computador mas a senha é sempre gerada uma nova toda vez que o programa é executado.<br>4- Envie se possível um telefone de contato, &nbsp;pode ser celular.<br>5- Envie o motivo da solicitação<br>6- O Teamviewer deve permanecer ativo.&nbsp;<o:p></o:p></span></p>"

        XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><a href=""http://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href=""http://www.topocad2000.com.br/"" target=""_blank"">www.topocad2000.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"

        If CHKP0.Checked = True Then ENVIA_EMAIL_CORREIOS(XEMAIL, 1)
        If CHKP1.Checked = True Then ENVIA_EMAIL_CORREIOS("microcad@terra.com.br", 2)
        If CHKP2.Checked = True Then ENVIA_EMAIL_CORREIOS("comercial@topocad2000.com.br", 3)
    End Sub
    Public Sub ENVIA_EMAIL_CORREIOS(ByVal MM As String, ByVal II As Integer)
        Dim mail As New MailMessage()
        mail.From = New MailAddress(XFROM1, XFROM2)
        mail.IsBodyHtml = True

        Dim SMTP As New SmtpClient(XSMTP, XPORTA)
        SMTP.EnableSsl = XSSL
        SMTP.Credentials = New System.Net.NetworkCredential(XCRED1, XCRED2)
        '
        mail.Subject = XTITU

        Dim bodyHTML As String = "<html><body>" & AAA & "<a href=" & XLINK & "><img src='cid:LOGO_IMAGE' alt='Logo' /></a>" & XXX & "</body></html>"

        Dim alternateView As AlternateView = AlternateView.CreateAlternateViewFromString(bodyHTML, Nothing, "text/html")
        Dim logo As New LinkedResource(XIMAGE, "image/jpeg")
        logo.ContentId = "LOGO_IMAGE"
        logo.TransferEncoding = Net.Mime.TransferEncoding.Base64
        alternateView.LinkedResources.Add(logo)
        mail.AlternateViews.Add(alternateView)
        mail.Body = Nothing
        '
        Dim fileTXT As String
        Dim dataTXT As Net.Mail.Attachment
        fileTXT = Application.StartupPath & "\RECPDF\" & XPROGRA & "_REC_" & XVERSAO & "-" & XNSERIE & ".pdf"
        If File.Exists(fileTXT) Then
            dataTXT = New Net.Mail.Attachment(fileTXT)
            dataTXT.Name = XPROGRA & "_REC_" & XVERSAO & "-" & XNSERIE & ".pdf"
            mail.Attachments.Add(dataTXT)
        End If

        Try
            mail.To.Add(MM)

            If II = 1 And XEMACC.Contains("@") Then mail.CC.Add(XEMACC)
        Catch
            MsgBox(MM & ">>INVALIDO")
        End Try
        '
        Try
            SMTP.Send(mail)
            MsgBox(CStr(II) & ": EMAIL: " & MM & vbCrLf & " ENVIADO COM SUCESSO!", MsgBoxStyle.Information)
        Catch
            MsgBox(CStr(II) & " *** EMAIL: " & MM & vbCrLf & "  NÃO FOI ENVIADO. ***", MsgBoxStyle.Critical)
        End Try
    End Sub
    '
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDENVIAREMAILDIGITAL_Click(sender As Object, e As EventArgs) Handles CMDENVIAREMAILDIGITAL.Click
        Dim XNN As Integer
        Dim ARQN, ARQDRV, ARQNSE As String
        Dim XVV As String = ""

        XPROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "MEMORIAL" Then XPROGRA = "MEMORIALCAD"
        '
        If TXTNSERIE.Text = "" Or TXTSERIAL.Text = "" Or TXTEMAIL.Text = "" Then
            If TXTNSERIE.Text = "" Then MsgBox("NUMERO DE SERIE EM BRANCO!")
            If TXTSERIAL.Text = "" Then MsgBox("SERIAL DO PENDRIVE EM BRANCO!")
            If TXTEMAIL.Text = "" Then MsgBox("EMAIL EM BRANCO!")
            MsgBox("EMAIL NÃO PODE SER ENVIADO!")
        Else
            If Mid(TXTNSERIE.Text, 1, 1) = "T" Then
                XNN = CShort(Mid(TXTNSERIE.Text, 2, 2)) - 10
                XVV = "V" & CStr(XNN)
            End If
            If Mid(TXTNSERIE.Text, 1, 1) = "M" Then
                XNN = CShort(Mid(TXTNSERIE.Text, 2, 2)) - 18
                XVV = "V" & CStr(XNN)
            End If
            ARQN = Application.StartupPath & "\" & TXTNSERIE.Text & "_" & TXTSERIAL.Text & "\" & XPROGRA
            ARQDRV = ARQN & "_DRV_" & XVV & ".FAS"
            ARQNSE = ARQN & "_NSE_" & XVV & ".FAS"

            If (Not (File.Exists(ARQDRV))) Or (Not (File.Exists(ARQNSE))) Then
                If Not (File.Exists(ARQDRV)) Then MsgBox(ARQDRV & " NÃO ENCONTRADO")
                If Not (File.Exists(ARQNSE)) Then MsgBox(ARQNSE & " NÃO ENCONTRADO")
                Exit Sub
            End If

            ARQPDF = Application.StartupPath & "\RECPDF\" & XPROGRA & "_REC_" & TXTVERSAO.Text & "-" & TXTNSERIE.Text & ".pdf"
            If (Not (File.Exists(ARQPDF))) Then
                LINHA = MsgBox(ARQPDF & " NÃO ENCONTRADO" & vbCrLf & "" & vbCrLf & "ENVIAR MESMO ASSIM?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Caixa de Mensagem")
                If LINHA = MsgBoxResult.No Then Exit Sub
            End If
            '
            If CHKD1.Checked = True Then
                XFROM1 = "microcad@terra.com.br"
                XCRED2 = "Acad2005"
                XFROM2 = "MICROCAD-Computação Grafica e Sistemas"
                XSMTP = "smtp.nri.terra.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            Else
                XFROM1 = "comercial@topocad2000.com.br"
                XCRED2 = "@Acadr14"
                XFROM2 = "MICROCAD-TOPOCAD2000 (Comercial)"
                XSMTP = "smtp.topocad2000.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            End If
            '
            XCLIENTE = TXTNOME.Text
            XNSERIE = TXTNSERIE.Text
            XTIPO = TXTTIPO.Text
            XVERSAO = TXTVERSAO.Text
            XVANT = TXTVANT.Text
            XSERIAL = TXTSERIAL.Text
            XEMAIL = TXTEMAIL.Text
            XEMACC = TXTEMAILCC.Text
            XUF = TXTUF.Text
            '
            If MessageBox.Show("ENVIAR DIGITAL?" & vbCrLf & XCLIENTE & "-" & XUF & vbCrLf & XNSERIE & " - " & XSERIAL & vbCrLf & XEMAIL, "ENVIAR EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ENVIAR_CHAVEDIGITAL()
            End If
            '
            TXTDATAS.Text = STRDATA
        End If
    End Sub
    Private Sub ENVIAR_CHAVEDIGITAL()

        XIMAGE = Application.StartupPath & "\TOPOCAD2000-DIG.jpg"

        XLINK = "https://www.amicrocad.com.br/#!loja-topocad2000/c1knd"

        AAA = ""
        If XVANT = "" Then
            XTITU = XPROGRA & "-" & XVERSAO & "-" & XNSERIE & "->" & XSERIAL & " DIGITAL"
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & "-" & XVERSAO & "-" & XNSERIE & ">>>CODIGO=" & XSERIAL & ">>>" & XCLIENTE & "-" & XUF & "<br><br></span>"
        Else
            XTITU = XPROGRA & "-" & XVERSAO & "<" & XVANT & "-" & XNSERIE & "->" & XSERIAL & " DIGITAL"
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & "-" & XVERSAO & "<" & XVANT & "-" & XNSERIE & ">>>CODIGO=" & XSERIAL & ">>>" & XCLIENTE & "-" & XUF & "<br><br></span>"
        End If

        AAA = AAA & "1-Clique no link a seguir para baixar / instalar / atualizar Topocad2000 " & XVERSAO & " (caso ainda não tenha feito).<br>"
        AAA = AAA & "https://www.topocad2000.com.br/downloads/TOPOCAD2000" & XVERSAO & ".exe " & "<br>"
        AAA = AAA & "2-Salve este instalador no pendrive (caso ainda não tenha feito).<br>"
        AAA = AAA & "3-Salve os arquivos em anexo no mesmo pendrive do código e do instalador do Topocad2000. Salve na raiz, não crie uma pasta.<br>"
        AAA = AAA & "4-Abra o AutoCAD, acesse um menu do " & XPROGRA & " e clique em MICROCAD<br>"
        AAA = AAA & "5-Clique em HABILITAR PARA CHAVE PENDRIVELOCK.<br><br>"

        AAA = AAA & "Para baixar o DVD do Topocad2000:<br>"
        AAA = AAA & "acesse www.topocad2000.com.br -> DOWNLOADS -> DVD TOPOCAD2000.<br><br></p>"

        AAA = AAA & "<p class=MsoNormal><span style='color:#1F497D'>*SUPORTE AO USUÁRIO das 10:00hs às 17:00hs de 2ª. A 6ª. Feira):</b></span><br>"
        If Mid(XNSERIE, 1, 1) = "T" Then AAA = AAA & "-Por email&nbsp;(<a href="" mailto:contato@topocad2000.com.br"">contato@topocad2000.com.br</a>): ilimitado.<br>"
        If Mid(XNSERIE, 1, 1) = "M" Then AAA = AAA & "-Por email&nbsp;(<a href="" mailto:contato@memorialcad.com.br"">contato@memorialcad.com.br</a>): ilimitado.<br>"
        AAA = AAA & "-Por telefone (21-2722-3000): 1 mês.<br>"
        AAA = AAA & "-Acesso remoto pelo Teamviewer para resolução de problemas: um ano<br>"
        AAA = AAA & "-Garantia da chave pendrivelock: um ano.<br>"
        AAA = AAA & "-Atualizações grátis: versão atual.<br><br></p>"

        If XPROGRA = "TOPOCAD2000" Then XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b><br><a href="" https://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href="" https://www.topocad2000.com.br/"" target=""_blank"">www.topocad2000.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"
        If XPROGRA = "MEMORIALCAD" Then XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b><br><a href="" https://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href="" http://www.memorialcad.com.br/"" target=""_blank"">www.memorialcad.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"

        If CHKP0.Checked = True Then ENVIA_EMAIL_CHAVEDIGITAL(XEMAIL, 1)
        If CHKP1.Checked = True Then ENVIA_EMAIL_CHAVEDIGITAL("microcad@terra.com.br", 2)
        If CHKP2.Checked = True Then ENVIA_EMAIL_CHAVEDIGITAL("comercial@topocad2000.com.br", 3)

    End Sub
    Public Sub ENVIA_EMAIL_CHAVEDIGITAL(ByVal MM As String, ByVal II As Integer)

        Dim mail As New MailMessage()
        mail.From = New MailAddress(XFROM1, XFROM2)
        mail.IsBodyHtml = True

        Dim SMTP As New SmtpClient(XSMTP, XPORTA)
        SMTP.EnableSsl = XSSL
        SMTP.Credentials = New System.Net.NetworkCredential(XCRED1, XCRED2)
        '
        mail.Subject = XTITU

        Dim bodyHTML As String = "<html><body>" & AAA & "<a href=" & XLINK & "><img src='cid:LOGO_IMAGE' alt='Logo'/></a>" & XXX & "</body></html>"

        Dim alternateView As AlternateView = AlternateView.CreateAlternateViewFromString(bodyHTML, Nothing, "text/html")
        Dim logo As New LinkedResource(XIMAGE, "image/jpeg")
        logo.ContentId = "LOGO_IMAGE"
        logo.TransferEncoding = Net.Mime.TransferEncoding.Base64
        alternateView.LinkedResources.Add(logo)
        mail.AlternateViews.Add(alternateView)
        mail.Body = Nothing
        '
        Dim fileTXT As String
        Dim dataTXT As Net.Mail.Attachment
        Dim XNN As Integer
        Dim XVV As String = ""

        If Mid(XNSERIE, 1, 1) = "T" Then
            'T25 > V15
            XNN = CInt(Mid(XNSERIE, 2, 2)) - 10
            XVV = "V" & CStr(XNN)
        End If
        If Mid(XNSERIE, 1, 1) = "M" Then
            'M24 > V6
            XNN = CInt(Mid(XNSERIE, 2, 2)) - 18
            XVV = "V" & CStr(XNN)
        End If

        fileTXT = Application.StartupPath & "\" & XNSERIE & "_" & XSERIAL & "\" & XPROGRA & "_DRV_" & XVV & ".fas"
        dataTXT = New Net.Mail.Attachment(fileTXT)
        dataTXT.Name = XPROGRA & "_DRV_" & XVV & ".fas"
        mail.Attachments.Add(dataTXT)

        fileTXT = Application.StartupPath & "\" & XNSERIE & "_" & XSERIAL & "\" & XPROGRA & "_NSE_" & XVV & ".fas"
        dataTXT = New Net.Mail.Attachment(fileTXT)
        dataTXT.Name = XPROGRA & "_NSE_" & XVV & ".fas"
        mail.Attachments.Add(dataTXT)

        fileTXT = Application.StartupPath & "\RECPDF\" & XPROGRA & "_REC_" & XVERSAO & "-" & XNSERIE & ".pdf"
        If File.Exists(fileTXT) Then
            dataTXT = New Net.Mail.Attachment(fileTXT)
            dataTXT.Name = XPROGRA & "_REC_" & XVERSAO & "-" & XNSERIE & ".pdf"
            mail.Attachments.Add(dataTXT)
        End If

        fileTXT = Application.StartupPath & "\" & XNSERIE & "_" & XSERIAL & "\" & XPROGRA & "_DRV_" & XVV & ".zelx"
        If File.Exists(fileTXT) Then
            dataTXT = New Net.Mail.Attachment(fileTXT)
            dataTXT.Name = XPROGRA & "_DRV_" & XVV & ".zelx"
            mail.Attachments.Add(dataTXT)
        End If
        fileTXT = Application.StartupPath & "\" & XNSERIE & "_" & XSERIAL & "\" & XPROGRA & "_NSE_" & XVV & ".zelx"
        If File.Exists(fileTXT) Then
            dataTXT = New Net.Mail.Attachment(fileTXT)
            dataTXT.Name = XPROGRA & "_NSE_" & XVV & ".zelx"
            mail.Attachments.Add(dataTXT)
        End If

        Try
            mail.To.Add(MM)
            'MsgBox("EMAIL " & MM & " ENVIADO COM SUCESSO!")

            If II = 1 And XEMACC.Contains("@") Then
                mail.CC.Add(XEMACC)
                'MsgBox("EMAIL " & XEMACC & " ENVIADO COM SUCESSO!")
            End If
            '
            SMTP.Send(mail)
            MsgBox(CStr(II) & ": EMAIL: " & MM & vbCrLf & " ENVIADO COM SUCESSO!", MsgBoxStyle.Information)
        Catch
            MsgBox(CStr(II) & " *** EMAIL: " & MM & vbCrLf & "  NÃO FOI ENVIADO. ***", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tabelas As New FormTabelas()
        FormTabelas.Show()
    End Sub
    '
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDENVIAREMAILCHAVEVIRTUAL_Click(sender As Object, e As EventArgs) Handles CMDENVIAREMAILCHAVEVIRTUAL.Click
        If TXTPROGRAMA.Text = "TOPOCAD" Then XPROGRA = "TOPOCAD2000"
        If TXTPROGRAMA.Text = "MEMORIAL" Then XPROGRA = "MEMORIALCAD"
        If TXTPROGRAMA.Text = "PERFIS" Then XPROGRA = "PERFIS2000"
        If TXTPROGRAMA.Text = "QFCAD" Then XPROGRA = "QFCAD2000"

        If TXTNSERIE.Text = "" Or TXTEMAIL.Text = "" Then
            If TXTNSERIE.Text = "" Then MsgBox("NUMERO DE SERIE EM BRANCO!")
            If TXTEMAIL.Text = "" Then MsgBox("EMAIL EM BRANCO!")
            MsgBox("EMAIL NÃO PODE SER ENVIADO!")
            End
        Else
            ARQPDF = My.Application.Info.DirectoryPath & "\RECPDF\" & XPROGRA & "_REC_" & TXTVERSAO.Text & "-" & TXTNSERIE.Text & ".pdf"
            If Not (File.Exists(ARQPDF)) Then
                LINHA = MsgBox(ARQPDF & " NÃO ENCONTRADO" & vbCrLf & "" & vbCrLf & "ENVIAR MESMO ASSIM?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Caixa de Mensagem")
                If LINHA = MsgBoxResult.No Then Exit Sub
            End If
            '
            If CHKD1.Checked = True Then
                XFROM1 = "microcad@terra.com.br"
                XCRED2 = "Acad2005"
                XFROM2 = "MICROCAD-Computação Grafica e Sistemas"
                XSMTP = "smtp.nri.terra.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            Else
                XFROM1 = "comercial@topocad2000.com.br"
                XCRED2 = "@Acadr14"
                XFROM2 = "MICROCAD-TOPOCAD2000 (Comercial)"
                XSMTP = "smtp.topocad2000.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            End If
            '
            XCLIENTE = TXTNOME.Text
            XNSERIE = TXTNSERIE.Text
            XTIPO = TXTTIPO.Text
            XVERSAO = TXTVERSAO.Text
            XVANT = TXTVANT.Text
            XSERIAL = TXTSERIAL.Text
            XEMAIL = TXTEMAIL.Text
            XEMACC = TXTEMAILCC.Text
            XUF = TXTUF.Text
            XVALOR = TXTVALOR.Text
            XCGC = TXTCGC.Text
            '
            If MessageBox.Show("ENVIAR >>>" & XNSERIE & XTIPO & vbCrLf & XCLIENTE & vbCrLf & XEMAIL, "ENVIAR EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ENVIA_CHAVEVIRTUAL()
            End If
        End If
    End Sub
    Private Sub ENVIA_CHAVEVIRTUAL()

        XIMAGE = Application.StartupPath & "\" & XPROGRA & "-VIR.jpg"

        If XPROGRA = "TOPOCAD2000" Then XLINK = "https://www.topocad2000.com.br"
        If XPROGRA = "MEMORIALCAD" Then XLINK = "https://www.memorialcad.com.br"
        If XPROGRA = "PERFIS2000" Then XLINK = "https://www.amicrocad.com.br/perfis2000-c22md"
        If XPROGRA = "QFCAD2000" Then XLINK = "https://www.amicrocad.com.br/qfcad2000-cier"

        XTITU = XPROGRA & " " & XVERSAO & " - " & XNSERIE & XTIPO & " * CHAVE VIRTUAL"

        AAA = ""
        If XVALOR.Trim = "PROMO" Then AAA &= "<p class=MsoNormal><span style='margin-bottom:10.0pt'><span style='font-family:""Arial"",""sans-serif""'>*** ESTE EMAIL FOI ENVIADO POR ESTAR INCLUIDO NA PROMOÇÃO.<br><br></span>"

        AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & " " & XVERSAO & " - " & XNSERIE & XTIPO & " >>> " & XCLIENTE & "-" & XUF & "<br><br></span>"

        AAA = AAA & "1-Clique no link a seguir para baixar / instalar / atualizar " & XPROGRA & " " & XVERSAO & " (caso ainda não tenha feito).<br>"

        If XPROGRA = "TOPOCAD2000" Then AAA = AAA & "https://www.topocad2000.com.br/downloads/TOPOCAD2000" & XVERSAO & ".exe " & "<br>"
        If XPROGRA = "MEMORIALCAD" Then AAA = AAA & "https://www.topocad2000.com.br/downloads/MEMORIALCAD" & XVERSAO & ".exe " & "<br>"
        If XPROGRA = "PERFIS2000" Then AAA = AAA & "https://www.topocad2000.com.br/downloads/PERFIS2000" & XVERSAO & ".exe " & "<br>"
        If XPROGRA = "QFCAD2000" Then AAA = AAA & "https://www.topocad2000.com.br/downloads/QFCAD2000" & XVERSAO & ".exe " & "<br>"

        AAA = AAA & "2-Abra o AutoCAD / BricsCAD / GstarCAD / ZwCAD, acesse um menu do " & XPROGRA & " e clique em MICROCAD<br>"
        AAA = AAA & "3-Clique em HABILITAR PARA CHAVE VIRTUAL.<br>"

        XXX = "CPF"
        If XTIPO = "B" Then XXX = "CNPJ"
        AAA = AAA & "4-Informe o NUMERO DE SERIE / EMAIL / " & XXX & ".<br>"

        AAA = AAA & "<p Class=MsoNormal><span style ='font-size:18.0pt;font-family:""Arial"",sans-serif'>Número de Série: >>> " & XNSERIE & XTIPO & " <<< </span></p>"

        AAA = AAA & "<p Class=MsoNormal><span style ='font-size:18.0pt;font-family:""Arial"",sans-serif'>Email: >>> " & XEMAIL & " <<< </span></p>"

        If XCGC = "X" Then
            AAA = AAA & "<p Class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:12.0pt'><span style='font-size:12.0pt;font-family:""Arial"",sans-serif'>*** CPF / CNPJ não cadastrado *** Informe respondendo a este email para atualizarmos o nosso cadastro e poder habilitar para chave Virtual.</span></p>"
        End If

        If XPROGRA = "TOPOCAD2000" Or XPROGRA = "MEMORIALCAD" Then AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>* Caso deseje habilitar tambem por PENDRIVE acesse para instruções >>> &nbsp;<a href=""https://www.amicrocad.com.br/topocad-pendrive"">HABILITAR CHAVE PENDRIVELOCK</a>.<br></p>"

        If XPROGRA = "TOPOCAD2000" Then
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>* Para baixar o DVD Do Topocad2000 acesse www.topocad2000.com.br -> DOWNLOADS -> DVD TOPOCAD2000.<br></p>"
        End If

        AAA = AAA & "<p Class=MsoNormal><span style='color:#1F497D'>*SUPORTE AO USUÁRIO das 10:00hs às 17:00hs de 2ª. A 6ª. Feira):</b></span><br>"

        If XPROGRA = "TOPOCAD2000" Then AAA = AAA & "-Por email&nbsp;(<a href="" mailto:contato@topocad2000.com.br"">contato@topocad2000.com.br</a>): ilimitado.<br>"
        If XPROGRA = "MEMORIALCAD" Then AAA = AAA & "-Por email&nbsp;(<a href="" mailto:contato@memorialcad.com.br"">contato@memorialcad.com.br</a>): ilimitado.<br>"
        If XPROGRA = "PERFIS2000" Then AAA = AAA & "-Por email&nbsp;(<a href="" mailto:microcad@terra.com.br"">microcad@terra.com.br</a>): ilimitado.<br>"
        If XPROGRA = "QFCAD2000" Then AAA = AAA & "-Por email&nbsp;(<a href="" mailto:microcad@terra.com.br"">microcad@terra.com.br</a>): ilimitado.<br>"

        If XPROGRA = "TOPOCAD2000" Or XPROGRA = "MEMORIALCAD" Then
            AAA = AAA & "-Por telefone (21-2722-3000): 1 mês.<br>"
            AAA = AAA & "-Acesso remoto pelo Teamviewer para resolução de problemas: um ano<br>"
            AAA = AAA & "-Atualizações grátis: versão atual.<br>"
        End If
        AAA = AAA & "<br></p>"

        If XPROGRA = "TOPOCAD2000" Then XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b><br><a href="" https://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href="" https://www.topocad2000.com.br/"" target=""_blank"">www.topocad2000.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"
        If XPROGRA = "MEMORIALCAD" Then XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b><br><a href="" https://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href="" http://www.memorialcad.com.br/"" target=""_blank"">www.memorialcad.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"
        If XPROGRA = "PERFIS2000" Then XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b><br><a href="" https://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"
        If XPROGRA = "QFCAD2000" Then XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b><br><a href="" https://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"

        If CHKP0.Checked = True Then ENVIA_EMAIL_CHAVEVIRTUAL(XEMAIL, 1)
        If CHKP1.Checked = True Then ENVIA_EMAIL_CHAVEVIRTUAL("microcad@terra.com.br", 2)
        If CHKP2.Checked = True Then ENVIA_EMAIL_CHAVEVIRTUAL("comercial@topocad2000.com.br", 3)

    End Sub
    Public Sub ENVIA_EMAIL_CHAVEVIRTUAL(ByVal MM As String, ByVal II As Integer)
        '
        Dim mail As New MailMessage()
        mail.From = New MailAddress(XFROM1, XFROM2)
        mail.IsBodyHtml = True

        Dim SMTP As New SmtpClient(XSMTP, XPORTA)
        SMTP.EnableSsl = XSSL
        SMTP.Credentials = New System.Net.NetworkCredential(XCRED1, XCRED2)
        '
        mail.Subject = XTITU

        Dim bodyHTML As String = "<html><body>" & AAA & "<a href=" & XLINK & "><img src='cid:LOGO_IMAGE' alt='Logo' /></a>" & XXX & "</body></html>"

        Dim alternateView As AlternateView = AlternateView.CreateAlternateViewFromString(bodyHTML, Nothing, "text/html")
        Dim logo As New LinkedResource(XIMAGE, "image/jpeg")
        logo.ContentId = "LOGO_IMAGE"
        logo.TransferEncoding = Net.Mime.TransferEncoding.Base64
        alternateView.LinkedResources.Add(logo)
        mail.AlternateViews.Add(alternateView)
        mail.Body = Nothing
        '
        '
        Dim fileTXT As String
        Dim dataTXT As Net.Mail.Attachment
        Dim XNN As Integer
        Dim XVV As String

        If Mid(XNSERIE, 1, 1) = "T" Then
            'T25 > V15
            XNN = CInt(Mid(XNSERIE, 2, 2)) - 10
            XVV = "V" & CStr(XNN)
        End If
        If Mid(XNSERIE, 1, 1) = "M" Then
            'M24 > V6
            XNN = CInt(Mid(XNSERIE, 2, 2)) - 18
            XVV = "V" & CStr(XNN)
        End If

        fileTXT = Application.StartupPath & "\RECPDF\" & XPROGRA & "_REC_" & XVERSAO & "-" & XNSERIE & ".pdf"
        If File.Exists(fileTXT) Then
            dataTXT = New Net.Mail.Attachment(fileTXT)
            dataTXT.Name = XPROGRA & "_REC_" & XVERSAO & "-" & XNSERIE & ".pdf"
            mail.Attachments.Add(dataTXT)
        End If

        Try
            mail.To.Add(MM)
            If II = 1 Then
                If Len(XEMACC) > 5 Then
                    If XEMACC.Contains("@") Then
                        mail.CC.Add(XEMACC)
                    End If
                End If
            End If
        Catch
            MsgBox(MM & ">>INVALIDO")
        End Try
        '
        Try
            SMTP.Send(mail)
            MsgBox(CStr(II) & ": EMAIL: " & MM & vbCrLf & " ENVIADO COM SUCESSO!", MsgBoxStyle.Information)
        Catch
            MsgBox(CStr(II) & " *** EMAIL: " & MM & vbCrLf & "  NÃO FOI ENVIADO. ***", MsgBoxStyle.Critical)
        End Try
        '
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX    '
    Private Sub CMDALTERAR_Click(sender As Object, e As EventArgs) Handles CMDALTERAR.Click
        For Each element In Me.Controls
            element.enabled = False
        Next
        For Each CTR As Control In Me.Controls
            If TypeOf CTR Is TextBox Then
                CType(CTR, TextBox).Enabled = True
            End If
            For Each ctrl As Control In CTR.Controls
                If TypeOf ctrl Is Button Then
                    CType(ctrl, Button).Enabled = False
                End If
            Next
        Next
        Frame2.Enabled = True
        Frame3.Enabled = False
        Frame5.Enabled = False
        CMDATUALIZA.Enabled = True
        CMDSALVAR.Enabled = True
        CMDSAIR.Enabled = True
        TXTNSERIE.Enabled = True

    End Sub
    Private Sub CMDSALVAR_Click(sender As Object, e As EventArgs) Handles CMDSALVAR.Click
        For Each element In Me.Controls
            element.enabled = True
        Next
        For Each CTR As Control In Me.Controls
            If TypeOf CTR Is TextBox Then
                CType(CTR, TextBox).Enabled = False
            End If
            For Each ctrl As Control In CTR.Controls
                If TypeOf ctrl Is Button Then
                    CType(ctrl, Button).Enabled = True
                End If
            Next
        Next
        Frame2.Enabled = True
        Frame3.Enabled = True
        Frame5.Enabled = True
        CMDATUALIZA.Enabled = False
        CMDSALVAR.Enabled = False
        CMDSAIR.Enabled = True
        '
        If TXTNOMEREG.Text = "" Then TXTNOMEREG.Text = TXTNOME.Text

        If TXTTIPO.Text = "" Then TXTTIPO.Text = "A"
        If TXTTIPO.Text = " " Then TXTTIPO.Text = "A"
        If SomenteNumeros(TXTCGC.Text).Length > 11 Then
            TXTTIPO.Text = "B"
        End If

        TXTSERIAL.Text = TXTSERIAL.Text.ToUpper

        If TXTPAGO.Text = "??" Then
            MsgBox("INFORME O PAGAMENTO!")
            TXTPAGO.Focus()
            Exit Sub
        End If
        TXTPAGO.Text = TXTPAGO.Text.ToUpper

        If TXTDESCO.Text = "??" Then
            MsgBox("INFORME O DESCONTO")
            TXTDESCO.Focus()
            Exit Sub
        End If

        If TXTUF.Text = "" Then TXTUF.Text = "XX"
        If TXTUF.Text = " " Then TXTUF.Text = "XX"
        TXTUF.Text = TXTUF.Text.ToUpper

        TXTCODRAS.Text = TXTCODRAS.Text.ToUpper

        TXTCGC.Text = mascaraCNPJ_CPF(TXTCGC.Text)
        TXTEMAIL.Text = TXTEMAIL.Text.ToLower
        TXTEMAILCC.Text = TXTEMAILCC.Text.ToLower
        '
        Dim TXT As String = TXTOBSREG.Text.Replace(vbCrLf, "$$")
        Dim jsonstring As String
        jsonstring = "{""nserie"": """ & TXTNSERIE.Text &
                   """,""nome"": """ & TXTNOME.Text &
                   """,""nomereg"": """ & TXTNOMEREG.Text &
                   """,""programa"": """ & TXTPROGRAMA.Text &
                   """,""tipo"": """ & TXTTIPO.Text &
                   """,""versao"": """ & TXTVERSAO.Text &
                   """,""nserieant"": """ & TXTNSERIEA.Text &
                   """,""versaoant"": """ & TXTVANT.Text &
                   """,""serial"": """ & TXTSERIAL.Text &
                   """,""dataenv"": """ & TXTDATAS.Text &
                   """,""data"": """ & TXTDATA.Text &
                   """,""valor"": """ & TXTVALOR.Text &
                   """,""desconto"": """ & TXTDESCO.Text &
                   """,""frete"": """ & TXTFRETE.Text &
                   """,""pago"": """ & TXTPAGO.Text &
                   """,""codrastre"": """ & TXTCODRAS.Text &
                   """,""rua"": """ & TXTRUANO.Text &
                   """,""bairro"": """ & TXTBAIRRO.Text &
                   """,""cidade"": """ & TXTCIDADE.Text &
                   """,""uf"": """ & TXTUF.Text &
                   """,""cep"": """ & TXTCEP.Text &
                   """,""cgc"": """ & TXTCGC.Text &
                   """,""telefone"": """ & TXTTELEFONE.Text &
                   """,""email"": """ & TXTEMAIL.Text &
                   """,""emailcc"": """ & TXTEMAILCC.Text &
                   """,""obs"": """ & TXT & """}"

        Try
            Dim urls As String = "https://microcad.azurewebsites.net/apiupdregistronet"
            Dim data = Encoding.UTF8.GetBytes(jsonstring)
            Dim webClient As New WebClient()
            webClient.Headers("content-type") = "application/json"
            Dim reqString() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(jsonstring, Formatting.Indented))
            Dim resString As String = Encoding.Default.GetString(webClient.UploadData(urls, "post", data))
            webClient.Dispose()
            MsgBox(TXTNSERIE.Text & " " & TXTTIPO.Text & " " & TXTVERSAO.Text & " " & " >>> SALVO COM SUCESSO!")
        Catch
            MsgBox("*** NÃO SALVO. ***")
        End Try
        '
        'DELETA NSERIE ANT SE EXISTIR
        If TXTNSERIEA.Text = "" Then
            'MsgBox("BRANCO")
        Else
            Try
                Dim JSURL As String = "https://microcad.azurewebsites.net/apidelregistronet/" & TXTNSERIEA.Text
                Dim request As HttpWebRequest = TryCast(WebRequest.Create(JSURL), HttpWebRequest)
                request.Timeout = 5 * 1000
                Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim resp As String = reader.ReadToEnd()
                response.Close()
                'If resp = 0 Then MsgBox(TXTNSERIEA.Text & " * NÃO ENCONTRADO E NÃO DELETADO *")
                If resp = 1 Then MsgBox(TXTNSERIEA.Text & " * ENCONTRADO E DELETADO.")
            Catch
                MsgBox("NÃO DELETADO")
            End Try
        End If
        '
        SALVAR_REGISTRO()
        '
        CMDSALVAR.Enabled = False

    End Sub
    Private Sub SALVAR_REGISTRO()
        '
        Dim jsonstring As String

        jsonstring = "{""nserie"": """ & TXTNSERIE.Text &
                   """,""tipo"": """ & TXTTIPO.Text &
                   """,""versao"": """ & TXTVERSAO.Text &
                   """,""cliente"": """ & TXTNOMEREG.Text &
                   """,""uf"": """ & TXTUF.Text &
                   """,""cgc"": """ & TXTCGC.Text &
                   """,""email"": """ & TXTEMAIL.Text &
                   """,""serial"": """ & TXTSERIAL.Text &
                   """,""versaoant"": """ & TXTVANT.Text & """}"

        Dim data = Encoding.UTF8.GetBytes(jsonstring)
        Dim urls As String = "https://microcad.azurewebsites.net/apiupdregistro"
        Try
            Dim webClient As New WebClient()
            webClient.Headers("content-type") = "application/json"
            Dim reqString() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(jsonstring, Formatting.Indented))
            Dim resByte As Byte() = webClient.UploadData(urls, "post", data)
            Dim resString As String = Encoding.Default.GetString(resByte)
            webClient.Dispose()
            'MsgBox(XNSERIE & " " & XTIPO & " " & XVERSAO & " " & XCLIENTE & " >>>ok")
        Catch ex As Exception
            MsgBox("não ok")
        End Try
        '
        'DELETA NSERIE ANT SE EXISTIR
        If TXTNSERIEA.Text = "" Then
            'MsgBox("BRANCO")
        Else
            'Try
            'MsgBox(XNSEANT)
            Dim JSURL As String = "https://microcad.azurewebsites.net/apidelregistro/" & TXTNSERIEA.Text
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(JSURL), HttpWebRequest)
            request.Timeout = 5 * 1000
            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim resp As String = reader.ReadToEnd()
            'MsgBox(resp)
            response.Close()
            'If resp = 0 Then MsgBox(TXTNSERIEA.Text & " * NÃO ENCONTRADO E NÃO DELETADO *")
            If resp = 1 Then MsgBox(TXTNSERIEA.Text & " * ENCONTRADO E DELETADO.")
            'Catch
            'MsgBox("NÃO DELETADO")
            'End Try
        End If
    End Sub




    Private Sub CMDINCLUIR_Click(sender As Object, e As EventArgs) Handles CMDINCLUIR.Click
        For Each element In Me.Controls
            element.enabled = False
        Next
        For Each CTR As Control In Me.Controls
            If TypeOf CTR Is TextBox Then
                CType(CTR, TextBox).Enabled = True
                CType(CTR, TextBox).Text = ""
            End If
            For Each ctrl As Control In CTR.Controls
                If TypeOf ctrl Is Button Then
                    CType(ctrl, Button).Enabled = False
                End If
            Next
        Next
        Frame2.Enabled = True
        Frame3.Enabled = False
        Frame5.Enabled = False
        CMDATUALIZA.Enabled = False
        CMDSALVAR.Enabled = True
        CMDSAIR.Enabled = True
        '
        TXTPROGRAMA.Text = "TOPOCAD"
        SUBULTIMO()
        TXTNSERIE.Enabled = True
        TXTNSERIE.Text = VNSERIE1
        TXTNOME.Focus()
    End Sub
    Private Sub CMDEXCLUIR_Click(sender As Object, e As EventArgs) Handles CMDEXCLUIR.Click

        If MessageBox.Show("EXCLUIR >>> " & TXTNSERIE.Text & " <<<", "REGISTRONET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'Try
            'MsgBox(XNSEANT)
            Dim JSURL As String = "https://microcad.azurewebsites.net/apidelregistronet/" & TXTNSERIE.Text
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(JSURL), HttpWebRequest)
            request.Timeout = 5 * 1000
            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim resp As String = reader.ReadToEnd()
            'MsgBox(resp)
            response.Close()
            If resp = 0 Then MsgBox(TXTNSERIE.Text & " * NÃO ENCONTRADO E NÃO EXCLUIDO *")
            If resp = 1 Then
                XNSERIE = TXTNSERIE.Text
                Dim A As String = VNSERIE.Substring(0, 1)
                Dim B As String = VNSERIE.Substring(1)
                Dim C As String = (CInt(B) - 1).ToString
                Dim D As String = A & C
                SUBMOSTRADADOS(D)
                MsgBox(XNSERIE & " * ENCONTRADO E EXCLUIDO COM SUCESSO!.")
            End If
            'Catch
            'MsgBox("NÃO DELETADO")
            'End Try
        End If
    End Sub
    Private Sub CMDMAIS_Click(sender As Object, e As EventArgs) Handles CMDMAIS.Click
        VNSERIE = TXTNSERIE.Text
        XNSERIE = VNSERIE
        Dim A As String = VNSERIE.Substring(0, 1)
        Dim B As String = VNSERIE.Substring(1)
        Dim C As String = (CInt(B) + 1).ToString
        Dim D As String = A & C
        FLAGMAIS = True
        FLAGMENOS = False
        SUBMOSTRADADOS(D)
    End Sub
    Private Sub CMDMENOS_Click(sender As Object, e As EventArgs) Handles CMDMENOS.Click
        VNSERIE = TXTNSERIE.Text
        XNSERIE = VNSERIE
        Dim A As String = VNSERIE.Substring(0, 1)
        Dim B As String = VNSERIE.Substring(1)
        Dim C As String = (CInt(B) - 1).ToString
        Dim D As String = A & C
        FLAGMAIS = False
        FLAGMENOS = True
        SUBMOSTRADADOS(D)
    End Sub
    Private Sub CMDPROCURARNOME_Click(sender As Object, e As EventArgs) Handles CMDPROCURARNOME.Click
        Dim consultaNome As New ConsultaNome()
        consultaNome.Show()
    End Sub

    Private Sub CMDPROCURARNSERIE_Click(sender As Object, e As EventArgs) Handles CMDPROCURARNSERIE.Click
        FormConsultaNumeroSerie.Show()
    End Sub
    Private Sub CMDPROCURAREMAIL_Click(sender As Object, e As EventArgs) Handles CMDPROCURAREMAIL.Click
        FormConsultaEmail.Show()
    End Sub
    Private Sub CMDSAIR_Click(sender As Object, e As EventArgs) Handles CMDSAIR.Click
        Close()
    End Sub
    Private Sub CMDDADOSPENDRIVE_Click(sender As Object, e As EventArgs) Handles CMDDADOSPENDRIVE.Click
        Dim ARQ As String
        ARQ = Application.StartupPath & "\PDLOCK.SCR"
        If TXTNSERIE.Text <> "" And TXTSERIAL.Text <> "" Then
            Dim STRD As String = Application.StartupPath & "\" & TXTNSERIE.Text & "_" & TXTSERIAL.Text
            If Dir(STRD, vbDirectory) = "" Then
                MkDir(STRD)
                MsgBox(STRD & " CRIADO COM SUCESSO")
            End If
            ARQ = STRD & "\PDLOCK.SCR"
        End If

        Dim XNN As Integer
        Dim XVV As String = ""
        If Mid(TXTNSERIE.Text, 1, 1) = "T" Then
            'T25 > V15
            XNN = CInt(Mid(TXTNSERIE.Text, 2, 2)) - 10
            XVV = "V" & CStr(XNN)
        End If
        If Mid(TXTNSERIE.Text, 1, 1) = "M" Then
            'M24 > V6
            XNN = CInt(Mid(TXTNSERIE.Text, 2, 2)) - 18
            XVV = "V" & CStr(XNN)
        End If

        FileOpen(1, ARQ, OpenMode.Output)
        PrintLine(1, "PDLOCK")
        PrintLine(1, XVV)
        PrintLine(1, TXTSERIAL.Text)
        PrintLine(1, Mid(TXTNSERIE.Text, 4))
        PrintLine(1, TXTNOMEREG.Text)
        PrintLine(1, TXTUF.Text)
        FileClose(1)

        MsgBox("ARQUIVO:" & vbCrLf & ">>> " & ARQ & " <<<" & vbCrLf & "GRAVADO COM SUCESSO!")

    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Private Sub CMDEMAILCODIGO_Click(sender As Object, e As EventArgs) Handles CMDEMAILCODIGO.Click
        If TXTSERIAL.Text <> "XXXX-XXXX" Or TXTEMAIL.Text = "" Then
            If TXTSERIAL.Text <> "XXXX-XXXX" Then MsgBox("SERIAL DO PENDRIVE DEVE SER XXXX-XXXX")
            If TXTEMAIL.Text = "" Then MsgBox("EMAIL EM BRANCO!")
            MsgBox("EMAIL NÃO PODE SER ENVIADO!")
        Else
            XCLIENTE = TXTNOME.Text
            XNSERIE = TXTNSERIE.Text
            XVERSAO = TXTVERSAO.Text
            XVANT = TXTVANT.Text
            XSERIAL = TXTSERIAL.Text
            XEMAIL = TXTEMAIL.Text
            XEMACC = TXTEMAILCC.Text
            XUF = TXTUF.Text

            If CHKD1.Checked = True Then
                XFROM1 = "microcad@terra.com.br"
                XCRED2 = "Acad2005"
                XFROM2 = "MICROCAD-Computação Grafica e Sistemas"
                XSMTP = "smtp.nri.terra.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            Else
                XFROM1 = "comercial@topocad2000.com.br"
                XCRED2 = "@Acadr14"
                XFROM2 = "MICROCAD-TOPOCAD2000 (Comercial)"
                XSMTP = "smtp.topocad2000.com.br"
                XPORTA = 587
                XSSL = False
                XCRED1 = XFROM1
            End If
            '
            LINHA = "ENVIAR SOLICITAÇÃO DE CÓDIGO ?" & vbCrLf & " >>> " & XCLIENTE & vbCrLf & " De: " & XFROM1 & vbCrLf & " Para: " & XEMAIL
            If XEMACC.Contains("@") Then LINHA = LINHA & vbCrLf & "Cc: " & XEMACC

            If MessageBox.Show(LINHA, "ENVIAR EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Mid(XNSERIE, 1, 1) = "M" Then
                    XPROGRA = "MEMORIALCAD"
                    MEMORIALCADVXX_EMAIL()
                End If
                If Mid(XNSERIE, 1, 1) = "T" Then
                    XPROGRA = "TOPOCAD2000"
                    TOPOCAD2000VXX_EMAIL()
                End If
            End If
        End If
    End Sub
    Private Sub TOPOCAD2000VXX_EMAIL()
        Dim XLINHA As String
        XIMAGE = Application.StartupPath & "\" & "TOPOCAD2000-COD.jpg"
        XLINK = "https://www.topocad2000.com.br"
        XTITU = XPROGRA & "-" & XVERSAO & "-" & XNSERIE & " DIGITAL"
        AAA = ""

        If XVANT = "" Then
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & " " & XVERSAO & " - " & XNSERIE & " >>> " & XCLIENTE & "-" & XUF & "<br><br></span>"
        Else
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & " " & XVERSAO & " < " & XVANT & " - " & XNSERIE & " >>> " & XCLIENTE & "-" & XUF & "<br><br></span>"
        End If
        XLINHA = "Siga os passos a seguir para receber os arquivos de habilitação:<br>"
        AAA = AAA & "<p class=MsoNormal style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XLINHA & "<br></span>"
        AAA = AAA & "1-Clique no link a seguir para baixar / instalar / atualizar Topocad2000 " & XVERSAO & ":<br>"
        AAA = AAA & "https://www.topocad2000.com.br/downloads/TOPOCAD2000" & XVERSAO & ".exe" & " <br>"
        AAA = AAA & "2-Salve este instalador em um pendrive próprio. Pode ser de uso, de qualquer marca e de qualquer capacidade<br>"
        AAA = AAA & "3-Abra o AutoCAD, acesse um menu do Topocad2000 e clique em MICROCAD<br>"
        AAA = AAA & "4-Clique em INFORMAR CODIGO PENDRIVELOCK e retorne por email o código informado que a seguir enviaremos os arquivos de habilitação que deverão ser salvos neste mesmo pendrive.<br><br>"

        XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b> <br><a href=""http://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href=""http://www.topocad2000.com.br/"" target=""_blank"">www.topocad2000.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"

        If CHKP0.Checked = True Then ENVIA_EMAIL_COD(XEMAIL, 1)
        If CHKP1.Checked = True Then ENVIA_EMAIL_COD("microcad@terra.com.br", 2)
        If CHKP2.Checked = True Then ENVIA_EMAIL_COD("comercial@topocad2000.com.br", 3)
    End Sub
    Private Sub MEMORIALCADVXX_EMAIL()
        Dim XLINHA As String
        XIMAGE = Application.StartupPath & "\" & "MEMORIALCAD-COD.jpg"
        XLINK = "https://www.memorialcad.com.br"
        XTITU = XPROGRA & XVERSAO & "-" & XNSERIE
        AAA = ""
        If XVANT = "" Then
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & " " & XVERSAO & " - " & XNSERIE & " >>> " & XCLIENTE & "-" & XUF & "<br><br></span>"
        Else
            AAA = AAA & "<p class=MsoNormal><span style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XPROGRA & " " & XVERSAO & " < " & XVANT & " - " & XNSERIE & " >>> " & XCLIENTE & "-" & XUF & "<br><br></span>"
        End If
        XLINHA = "Siga os passos a seguir para receber os arquivos de habilitação:<br>"
        AAA = AAA & "<p class=MsoNormal style='margin-bottom:12.0pt'><span style='font-family:""Arial"",""sans-serif""'>*" & XLINHA & "<br></span>"
        AAA = AAA & "1-Clique no link a seguir para baixar / instalar / atualizar MEMORIALCAD V6:<br>"
        AAA = AAA & "https://www.topocad2000.com.br/downloads/MEMORIALCADV6.exe <br>"
        AAA = AAA & "2-Salve este instalador em um pendrive próprio. Pode ser de uso, de qualquer marca e de qualquer capacidade<br>"
        AAA = AAA & "3-Abra o AutoCAD, acesse um menu do MEMORIALCAD e clique em MICROCAD<br>"
        AAA = AAA & "4-Clique em INFORMAR CODIGO PENDRIVELOCK e retorne por email o código informado que a seguir enviaremos os arquivos de habilitação que deverão ser salvos neste mesmo pendrive.<br><br>"
        XXX = "<p class=MsoNormal style='background:white'><span style='font-family:""Arial"",""sans-serif"";color:  black() '>Grato, <br><br><b>Microcad Computação Grafica</b> <br><a href=""http://www.amicrocad.com.br/"" target=""_blank"">www.amicrocad.com.br</a><br><a href=""http://www.memorialcad.com.br/"" target=""_blank"">www.memorialcad.com.br</a></span><span style='font-family:""Arial"",""sans-serif""'><o:p></o:p></span></p>"

        If CHKP0.Checked = True Then ENVIA_EMAIL_COD(XEMAIL, 1)
        If CHKP1.Checked = True Then ENVIA_EMAIL_COD("microcad@terra.com.br", 2)
        If CHKP2.Checked = True Then ENVIA_EMAIL_COD("comercial@topocad2000.com.br", 3)
    End Sub
    Public Sub ENVIA_EMAIL_COD(ByVal MM As String, ByVal II As Integer)
        Dim mail As New Mail.MailMessage()
        mail.From = New MailAddress(XFROM1, XFROM2)
        mail.IsBodyHtml = True

        Dim SMTP As New SmtpClient(XSMTP, XPORTA)
        SMTP.EnableSsl = XSSL
        SMTP.Credentials = New System.Net.NetworkCredential(XCRED1, XCRED2)
        '
        mail.Subject = XTITU

        Dim bodyHTML As String = "<html><body>" & AAA & "<a href=" & XLINK & "><img src='cid:LOGO_IMAGE' alt='Logo' /></a>" & XXX & "</body></html>"
        Dim alternateView As AlternateView = AlternateView.CreateAlternateViewFromString(bodyHTML, Nothing, "text/html")
        Dim logo As New LinkedResource(XIMAGE, "image/jpeg")
        logo.ContentId = "LOGO_IMAGE"
        logo.TransferEncoding = Net.Mime.TransferEncoding.Base64
        alternateView.LinkedResources.Add(logo)
        mail.AlternateViews.Add(alternateView)
        mail.Body = Nothing
        '
        Try
            mail.To.Add(MM)
            If II = 1 And XEMACC.Contains("@") Then mail.CC.Add(XEMACC)
        Catch
            MsgBox(MM & ">>INVALIDO")
        End Try
        '
        Try
            SMTP.Send(mail)
            MsgBox(CStr(II) & ": EMAIL: " & MM & vbCrLf & " ENVIADO COM SUCESSO!", MsgBoxStyle.Information)
        Catch
            MsgBox(CStr(II) & " *** EMAIL: " & MM & vbCrLf & "  NÃO FOI ENVIADO. ***", MsgBoxStyle.Critical)
        End Try
    End Sub
    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    Public Function SUBMOSTRADADOS(nserie As String) As Integer
        Try
            VNSERIE = nserie
            JSURL = "https://microcad.azurewebsites.net/apiconregistronet/" & VNSERIE
            If VNSERIE = "" Then
                JSURL = "https://microcad.azurewebsites.net/apiconregistronetultimo/"
            End If
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(JSURL), HttpWebRequest)
            request.Timeout = 10 * 1000
            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            JSON = responseFromServer
            reader.Close()
            response.Close()
            If (Len(JSON) > 0) Then
                Dim read = Linq.JObject.Parse(JSON)
                If read.Count > 0 Then
                    TXTNSERIE.Text = read.Item("nserie").ToString
                    VNSERIE = TXTNSERIE.Text
                    TXTNOME.Text = read.Item("nome").ToString
                    TXTNOMEREG.Text = read.Item("nomereg").ToString
                    TXTPROGRAMA.Text = read.Item("programa").ToString
                    TXTTIPO.Text = read.Item("tipo").ToString
                    TXTVERSAO.Text = read.Item("versao").ToString
                    TXTNSERIEA.Text = read.Item("nserieant").ToString
                    TXTVANT.Text = read.Item("versaoant").ToString
                    TXTSERIAL.Text = read.Item("serial").ToString
                    TXTDATAS.Text = read.Item("dataenv").ToString
                    TXTDATA.Text = read.Item("data").ToString
                    TXTVALOR.Text = read.Item("valor").ToString
                    TXTDESCO.Text = read.Item("desconto").ToString
                    TXTFRETE.Text = read.Item("frete").ToString
                    TXTPAGO.Text = read.Item("pago").ToString
                    TXTCODRAS.Text = read.Item("codrastre").ToString
                    TXTRUANO.Text = read.Item("rua").ToString
                    TXTBAIRRO.Text = read.Item("bairro").ToString
                    TXTCIDADE.Text = read.Item("cidade").ToString
                    TXTUF.Text = read.Item("uf").ToString
                    TXTCEP.Text = read.Item("cep").ToString
                    TXTCGC.Text = mascaraCNPJ_CPF(read.Item("cgc").ToString)
                    TXTTELEFONE.Text = read.Item("telefone").ToString
                    TXTEMAIL.Text = read.Item("email").ToString
                    TXTEMAILCC.Text = read.Item("emailcc").ToString
                    Dim TXT As String = read.Item("obs").ToString
                    TXTOBSREG.Text = TXT.Replace("$$", vbCrLf)


                    RETCOD = 1
                    'MsgBox("ENCONTRADO")
                Else
                    RETCOD = 2
                    'MsgBox("NÃO ENCONTRADO-2")
                    VNSERIE = XNSERIE
                    If FLAGMAIS Then MsgBox("*** ULTIMO REGISTRO! ***")
                    If FLAGMENOS Then MsgBox("*** PRIMEIRO REGISTRO! ***")
                End If
            Else
                RETCOD = 3
                MsgBox("NÃO ENCONTRADO-3")
            End If
        Catch
            RETCOD = 0
            MsgBox("SEM INTERNET-0")
        End Try
        Return RETCOD
    End Function
    Private Sub SUBULTIMO()
        Try
            JSURL = "https://microcad.azurewebsites.net/apiconregistronetultimo/"
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(JSURL), HttpWebRequest)
            request.Timeout = 10 * 1000
            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            JSON = responseFromServer
            reader.Close()
            response.Close()
            If (Len(JSON) > 0) Then
                Dim read = Linq.JObject.Parse(JSON)
                If read.Count > 0 Then
                    VNSERIE = read.Item("nserie").ToString
                    Dim A As String = VNSERIE.Substring(0, 1)
                    Dim B As String = VNSERIE.Substring(1)
                    Dim C As String = (CInt(B) + 1).ToString
                    Dim D As String = A & C
                    VNSERIE1 = D
                Else
                    'MsgBox("NÃO ENCONTRADO-2")
                End If
            Else
                RETCOD = 3
                MsgBox("NÃO ENCONTRADO-3")
            End If
        Catch
            RETCOD = 0
            MsgBox("SEM INTERNET-0")
        End Try
    End Sub
    Private Sub Control_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If ((e.KeyCode = Keys.Enter) _
                    OrElse (e.KeyCode = Keys.Return)) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub TXTNOME_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNOME.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXTNOME.Text = "" Then
                MsgBox("INFORME O NOME DO CLIENTE!")
                TXTNOME.Focus()
                Exit Sub
            End If

            TXTNOMEREG.Focus()
        End If
    End Sub
    Private Sub TXTNOMEREG_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNOMEREG.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXTNOMEREG.Text = "" Then
                TXTNOMEREG.Text = TXTNOME.Text
            End If
            TXTPROGRAMA.Focus()
        End If
    End Sub
    Private Sub TXTPROGRAMA_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPROGRAMA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXTPROGRAMA.Text = "" Then
                TXTPROGRAMA.Text = "TOPOCAD"
            End If
            If TXTPROGRAMA.Text = "TOPOCAD" Then
                If TXTTIPO.Text = "" Then TXTTIPO.Text = "A"
                If TXTVERSAO.Text = "" Then TXTVERSAO.Text = "V16"
                If TXTDATA.Text = "" Then TXTDATA.Text = STRDATA
                If TXTVALOR.Text = "" Then TXTVALOR.Text = "800,00"
                If TXTDESCO.Text = "" Then TXTDESCO.Text = "??"
                If TXTPAGO.Text = "" Then TXTPAGO.Text = "??"
                TXTDESCO.Focus()
            End If

            TXT = TXTPROGRAMA.Text
            If TXT <> "TOPOCAD" And TXT <> "MEMORIAL" And TXT <> "PERFIS" And TXT <> "QFCAD" Then
                MsgBox("NOME DE PROGRAMA DEVE SER: TOPOCAD / MEMORIAL / PERFIS / QFCAD")
                TXTPROGRAMA.Focus()
            End If
        End If
    End Sub
    Private Sub TXTDATA_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTDATA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXTDATA.Text = "" Then
                TXTDATA.Text = STRDATA
            End If
            TXTVALOR.Focus()
        End If
    End Sub
    Private Sub TXTVALOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTVALOR.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTDESCO.Focus()
        End If
    End Sub
    Private Sub TXTDSECO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTDESCO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTFRETE.Focus()
        End If
    End Sub
    Private Sub TXTFRETE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTFRETE.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTPAGO.Focus()
        End If
    End Sub
    Private Sub TXTPAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPAGO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTRUANO.Focus()
        End If
    End Sub
    Private Sub TXTRUANO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTRUANO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTBAIRRO.Focus()
        End If
    End Sub
    Private Sub TXTBAIRRO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTBAIRRO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTCIDADE.Focus()
        End If
    End Sub
    Private Sub TXTCIDADE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCIDADE.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTUF.Focus()
        End If
    End Sub
    Private Sub TXTUF_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTUF.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTCEP.Focus()
        End If
    End Sub
    Private Sub TXTCEP_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCEP.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTCGC.Focus()
        End If
    End Sub
    Private Sub TXTCGC_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCGC.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXTEMAIL.Focus()
        End If
    End Sub
    Private Sub TXTEMAIL_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTEMAIL.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMDSALVAR.Focus()
        End If
    End Sub

End Class
