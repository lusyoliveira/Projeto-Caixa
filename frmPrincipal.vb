Public Class frmPrincipal
    Private Sub CaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaixaToolStripMenuItem.Click
        Dim frmAbreCaixa = New frmCaixa()
        frmAbreCaixa.MdiParent = Me
        frmAbreCaixa.Show()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetConnection()
    End Sub
End Class