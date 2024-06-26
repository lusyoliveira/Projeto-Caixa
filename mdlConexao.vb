Imports System.ServiceProcess
Module mdlConexao
    Public Servidor = GetNomeSQLServer()
    Public DataBase = "dbCaixa"
    Public user = "sa"
    Public password = "123456"
    Public strConexao As String

    ''' <summary>
    ''' Esta função gera a string de conexão e retorna o dados da conexão.
    ''' </summary>
    ''' <returns>Retorna string de conexão.</returns>
    Public Function GetConnection() As System.Data.IDbConnection
        strConexao = $"Data Source={Servidor};Initial Catalog={DataBase};User ID={user}; Password={password};Integrated Security=True"
    End Function
    Public Sub AlterarStringDeConexao()
        Dim Config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None)
        Dim ConnectionStrings = Config.ConnectionStrings
        For Each ConnectionString As System.Configuration.ConnectionStringSettings In ConnectionStrings.ConnectionStrings
            ConnectionString.ConnectionString = String.Format($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Servidor}\{DataBase}.mdb", Environment.CurrentDirectory)
        Next
        Config.Save(System.Configuration.ConfigurationSaveMode.Modified)
        System.Configuration.ConfigurationManager.RefreshSection("connectionStrings")
    End Sub
    ''' <summary>
    ''' Esta função obtem o nome do servidor SQL Server.
    ''' </summary>
    ''' <returns>Retorna o nome do servidor.</returns>
    Public Function GetNomeSQLServer() As String
        'Nome do PC local
        Dim strPCname As String = Environment.MachineName
        ' nome do serviço do SQL Server Express
        Dim strInstancia As String = "MSSQL$SQLEXPRESS"
        Dim strNomeSQLServer As String = String.Empty

        ' Inclua uma referência a : System.ServiceProcess;
        Dim servicos As ServiceController() = ServiceController.GetServices()
        ' percorre os serviços 
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
