Public Class FormListarListas
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        ActiveForm.Close()
    End Sub

    Private Sub BtnListar_Click(sender As Object, e As EventArgs) Handles BtnListar.Click

        Dim list = ListarListas.Listar()

        Dim LISTA1V16 = list.Where(Function(x) x.nserie.StartsWith("T26") Or x.nserie.StartsWith("M26")).ToList()
        ListarListas.Salvar(LISTA1V16, "LISTA-1V16")
        PBListarListas.Value = 25

        Dim LISTA1VXX = list.Where(Function(x) Not x.nserie.StartsWith("T26") And Not x.nserie.StartsWith("M26") And Not x.nserie.Equals("TXXAAA") And Not x.nserie.Equals("TXXBBB") And (x.nserie.StartsWith("T") Or x.nserie.StartsWith("M"))).ToList()
        ListarListas.Salvar(LISTA1VXX, "LISTA-1VXX")
        PBListarListas.Value = 50

        Dim LISTA2VAA = list.Where(Function(x) x.nserie.Equals("TXXAAA")).ToList()
        ListarListas.Salvar(LISTA2VAA, "LISTA-2VAA")
        PBListarListas.Value = 75

        Dim LISTA2VBB = list.Where(Function(x) x.nserie.Equals("TXXBBB")).ToList()
        ListarListas.Salvar(LISTA2VBB, "LISTA-2VBB")
        PBListarListas.Value = 100

        MessageBox.Show("Listagem concluída com sucesso!")
    End Sub
End Class