Imports System.Data.SqlClient
Imports System.Text
Public Class frmCaixa
    Private Function VerificaConta() As Boolean
        Dim tbMovimento As DataTable ' ou outro tipo de objeto para armazenar os resultados

        ' Verifica se é número
        If Not IsNumeric(txtConta.Text) Then
            MsgBox("A conta deve ser numérica!", MsgBoxStyle.Exclamation)
            txtConta.Focus()
            Return False
        ElseIf txtConta.Text = "" Then
            MsgBox("A conta deve ser preenchida!", MsgBoxStyle.Exclamation)
            Return False
        End If

        ' Consulta SQL para obter resultados
        Dim query As String = "SELECT * FROM tbMovimento WHERE codconta = " & txtConta.Text

        ' Conexão com o banco de dados e execução da consulta
        Using connection As New SqlConnection(strConexao)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Using adapter As New SqlDataAdapter(command)
                    tbMovimento = New DataTable()
                    adapter.Fill(tbMovimento)
                End Using
            End Using
        End Using

        ' Verifica se o resultado da consulta está vazio
        If tbMovimento.Rows.Count = 0 Then
            MsgBox("A conta não existe!", MsgBoxStyle.Critical)
            txtConta.Focus()
            Return False
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
        Dim tbMovimento As Decimal = 0

        VerificaConta()

        ' Consulta SQL para obter o valor somado
        Dim query As String = "SELECT SUM(valor) AS valor FROM tbMovimento WHERE codconta = " & txtConta.Text

        ' Conexão com o banco de dados e execução da consulta
        Using connection As New SqlConnection(strConexao)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    tbMovimento = Convert.ToDecimal(result)
                End If
            End Using
        End Using

        txtValor.Text = FormatCurrency(tbMovimento)

    End Sub

    Private Sub btnDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeposito.Click
        Dim tbContas As DataTable

        ' Consulta para verificar se a conta existe
        Dim queryContas As String = "SELECT codconta FROM tbContas WHERE codconta = " & txtConta.Text

        ' Conexão com o banco de dados e execução da consulta
        Using connection As New SqlConnection(strConexao)
            Using commandContas As New SqlCommand(queryContas, connection)
                connection.Open()
                tbContas = New DataTable()
                tbContas.Load(commandContas.ExecuteReader())
            End Using
        End Using

        If tbContas.Rows.Count > 0 AndAlso txtConta.Text = tbContas.Rows(0)("codconta").ToString() Then
            If Decimal.TryParse(txtValor.Text, New Decimal) AndAlso Convert.ToDecimal(txtValor.Text) > 0 Then
                ' Consulta para inserir um novo registro em tbMovimento
                Dim queryMovimento As String = "INSERT INTO tbMovimento (codconta, valor) VALUES (" & txtConta.Text & ", " & txtValor.Text & ")"

                ' Conexão com o banco de dados e execução da consulta
                Using connection As New SqlConnection(strConexao)
                    Using commandMovimento As New SqlCommand(queryMovimento, connection)
                        connection.Open()
                        commandMovimento.ExecuteNonQuery()
                    End Using
                End Using
            Else
                MsgBox("Digite um valor maior!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Essa conta não existe!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub btnSaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaque.Click

        Using connection As New SqlConnection(strConexao)
            connection.Open()

            Dim cmdMovimento As New SqlCommand("SELECT * FROM tbMovimento", connection)
            Dim readerMovimento As SqlDataReader = cmdMovimento.ExecuteReader()

            If txtValor.Text > 0 Then
                If readerMovimento.HasRows Then
                    readerMovimento.Read()
                    If readerMovimento("saldo") < Convert.ToDecimal(txtValor.Text) Then
                        MsgBox("Saldo Insuficiente!", MsgBoxStyle.Critical)
                    Else
                        readerMovimento.Close()
                        Dim cmdConta As New SqlCommand("SELECT * FROM tbMovimento WHERE codconta = @codconta", connection)
                        cmdConta.Parameters.AddWithValue("@codconta", txtConta.Text)

                        Dim readerConta As SqlDataReader = cmdConta.ExecuteReader()
                        If readerConta.HasRows Then
                            readerConta.Read()
                            Dim total As Decimal = Convert.ToDecimal(readerConta("valor"))
                            total -= Convert.ToDecimal(txtValor.Text)
                            txtValor.Text = total.ToString()
                        End If
                        readerConta.Close()
                    End If
                End If
                readerMovimento.Close()
            Else
                MsgBox("Digite um valor maior!", MsgBoxStyle.Information)
            End If

            connection.Close()
        End Using
    End Sub

    Private Sub frmCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
