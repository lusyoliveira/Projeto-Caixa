<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaixa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.lblConta = New System.Windows.Forms.Label()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.btnSaldo = New System.Windows.Forms.Button()
        Me.btnDeposito = New System.Windows.Forms.Button()
        Me.btnSaque = New System.Windows.Forms.Button()
        Me.grpMovimento = New System.Windows.Forms.GroupBox()
        Me.grpMovimento.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtConta
        '
        Me.txtConta.Location = New System.Drawing.Point(71, 57)
        Me.txtConta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(132, 22)
        Me.txtConta.TabIndex = 0
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(71, 101)
        Me.txtValor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(132, 22)
        Me.txtValor.TabIndex = 1
        Me.txtValor.Text = "R$ 0.00"
        '
        'lblConta
        '
        Me.lblConta.AutoSize = True
        Me.lblConta.Location = New System.Drawing.Point(21, 65)
        Me.lblConta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConta.Name = "lblConta"
        Me.lblConta.Size = New System.Drawing.Size(42, 16)
        Me.lblConta.TabIndex = 2
        Me.lblConta.Text = "Conta"
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Location = New System.Drawing.Point(21, 110)
        Me.lblValor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(39, 16)
        Me.lblValor.TabIndex = 3
        Me.lblValor.Text = "Valor"
        '
        'btnSaldo
        '
        Me.btnSaldo.Location = New System.Drawing.Point(229, 79)
        Me.btnSaldo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaldo.Name = "btnSaldo"
        Me.btnSaldo.Size = New System.Drawing.Size(100, 28)
        Me.btnSaldo.TabIndex = 4
        Me.btnSaldo.Text = "Saldo"
        Me.btnSaldo.UseVisualStyleBackColor = True
        '
        'btnDeposito
        '
        Me.btnDeposito.Location = New System.Drawing.Point(25, 177)
        Me.btnDeposito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDeposito.Name = "btnDeposito"
        Me.btnDeposito.Size = New System.Drawing.Size(100, 28)
        Me.btnDeposito.TabIndex = 5
        Me.btnDeposito.Text = "Depósito"
        Me.btnDeposito.UseVisualStyleBackColor = True
        '
        'btnSaque
        '
        Me.btnSaque.Location = New System.Drawing.Point(195, 177)
        Me.btnSaque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaque.Name = "btnSaque"
        Me.btnSaque.Size = New System.Drawing.Size(100, 28)
        Me.btnSaque.TabIndex = 6
        Me.btnSaque.Text = "Saque"
        Me.btnSaque.UseVisualStyleBackColor = True
        '
        'grpMovimento
        '
        Me.grpMovimento.Controls.Add(Me.btnSaque)
        Me.grpMovimento.Controls.Add(Me.btnDeposito)
        Me.grpMovimento.Controls.Add(Me.txtConta)
        Me.grpMovimento.Controls.Add(Me.btnSaldo)
        Me.grpMovimento.Controls.Add(Me.txtValor)
        Me.grpMovimento.Controls.Add(Me.lblValor)
        Me.grpMovimento.Controls.Add(Me.lblConta)
        Me.grpMovimento.Location = New System.Drawing.Point(16, 15)
        Me.grpMovimento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpMovimento.Name = "grpMovimento"
        Me.grpMovimento.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpMovimento.Size = New System.Drawing.Size(347, 256)
        Me.grpMovimento.TabIndex = 7
        Me.grpMovimento.TabStop = False
        Me.grpMovimento.Tag = "0"
        Me.grpMovimento.Text = "Movimentos"
        '
        'frmCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 286)
        Me.Controls.Add(Me.grpMovimento)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmCaixa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tela de Movimento"
        Me.grpMovimento.ResumeLayout(False)
        Me.grpMovimento.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtConta As System.Windows.Forms.TextBox
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents lblConta As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents btnSaldo As System.Windows.Forms.Button
    Friend WithEvents btnDeposito As System.Windows.Forms.Button
    Friend WithEvents btnSaque As System.Windows.Forms.Button
    Friend WithEvents grpMovimento As System.Windows.Forms.GroupBox

End Class
