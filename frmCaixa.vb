Public Class frmCaixa
    Private Function VerificaConta() As Boolean
        Dim tbMovimento As ADODB.Recordset

        'verifica se é numero
        If Not IsNumeric(txtConta.Text) Then
            MsgBox("A conta deve ser númerica!", MsgBoxStyle.Critical)
            txtConta.Focus()
            Exit Function
        End If
        tbMovimento = RecebeTabela("Select * from tbMovimento where codconta= " & txtConta.Text)
        If tbMovimento.EOF Then
            MsgBox("A conta não existe!", MsgBoxStyle.Critical)
            txtConta.Focus()
            Exit Function
        End If
        Return True
    End Function
    Private Function VerificaValor() As Boolean
        'verifica se é numero
        If Not IsNumeric(txtValor.Text) Then
            MsgBox("A valor deve ser númerica!", MsgBoxStyle.Critical)
            txtValor.Focus()
            Exit Function
        End If
        Return True
    End Function
    Private Sub btnSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaldo.Click
        Dim tbMovimento As ADODB.Recordset

        VerificaConta()
        'soma valor
        ' tbMovimento = RecebeTabela("Select * from tbMovimento where codconta= " & txtConta.Text)
        ' Dim total As Decimal = 0
        'Do While tbMovimento.EOF
        'total += tbMovimento("valor").Value
        'tbMovimento.MoveNext()
        'Loop
        'txtValor.Text = total

        'soma valor
        tbMovimento = RecebeTabela("Select sum(valor) as valor from tbMovimento where codconta = " & txtConta.Text)
        If tbMovimento.RecordCount <> 0 Then
            txtValor.Text = FormatCurrency(tbMovimento("valor").Value)
        Else
            txtValor.Text = 0
        End If
        txtValor.Text = FormatCurrency(tbMovimento("valor").Value.ToString)

    End Sub

    Private Sub btnDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeposito.Click
        Dim tbMovimento, tbContas As ADODB.Recordset

        tbContas = RecebeTabela("select * from tbContas where codconta = " & txtConta.Text)
        If txtConta.Text = tbContas("codconta").Value Then
            If txtValor.Text > 0 Then
                tbMovimento = RecebeTabela("insert into tbMovimento (codconta,valor) values (" & txtConta.Text & ", " & txtValor.Text & ")")
            Else
                MsgBox("Digite um valor maior!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Essa conta não existe!", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub btnSaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaque.Click
        Dim tbMovimento As ADODB.Recordset

        VerificaValor()
        tbMovimento = RecebeTabela("select * from tbMovimento")
        If txtValor.Text > 0 Then
            If tbMovimento("saldo").Value < txtValor.Text Then
                MsgBox(" Saldo Insuficiente!", MsgBoxStyle.Critical)
            Else
                tbMovimento = RecebeTabela("Select * from tbMovimento where codconta= " & txtConta.Text)
                Dim total As Decimal = 0
                total -= tbMovimento("valor").Value
                txtValor.Text = total
            End If
        Else
            MsgBox("Digite um valor maior!", MsgBoxStyle.Information)
        End If
    End Sub
End Class
