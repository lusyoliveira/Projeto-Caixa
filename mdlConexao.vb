Imports System.Configuration
Imports System.Data.SqlClient
Imports System.ServiceProcess
Module mdlConexao
    Public Servidor = GetNomeSQLServer()
    Public DataBase = "dbCryptoBank"
    Public user = "sa"
    Public password = "123456"
    Public strConexao As String

    ''' <summary>
    ''' Esta fun��o gera a string de conex�o e retorna o dados da conex�o.
    ''' </summary>
    ''' <returns>Retorna string de conex�o.</returns>
    Public Function GetConnection() As System.Data.IDbConnection
        strConexao = $"Data Source={Servidor};Initial Catalog={DataBase};User ID={user}; Password={password};Integrated Security=True"
    End Function

    ''' <summary>
    ''' Esta fun��o obtem o nome do servidor SQL Server.
    ''' </summary>
    ''' <returns>Retorna o nome do servidor.</returns>
    Public Function GetNomeSQLServer() As String
        'Nome do PC local
        Dim strPCname As String = Environment.MachineName
        ' nome do servi�o do SQL Server Express
        Dim strInstancia As String = "MSSQL$SQLEXPRESS"
        Dim strNomeSQLServer As String = String.Empty

        ' Inclua uma refer�ncia a : System.ServiceProcess;
        Dim servicos As ServiceController() = ServiceController.GetServices()
        ' percorre os servi�os 
        For Each servico As ServiceController In servicos
            If servico Is Nothing Then
                Continue For
            End If
            Dim strNomeDoServico As String = servico.ServiceName
            If strNomeDoServico.Contains(strInstancia) Then
                strNomeSQLServer = strNomeDoServico
            End If
        Next
        Dim IndiceInicio As Integer = strNomeSQLServer.IndexOf("$")
        If IndiceInicio > -1 Then
            'strSqlServerName=NomeDoSeuPC\SQLEXPRESS;
            strNomeSQLServer = strPCname + "\" + strNomeSQLServer.Substring(IndiceInicio + 1)
        End If
        Return strNomeSQLServer
    End Function

End Module
