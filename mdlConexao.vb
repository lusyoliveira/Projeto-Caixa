Imports System.Data.Common
Imports System.Configuration
Imports System.ServiceProcess
Module mdlConexao
    Private cn As DbConnection

    Const DataBase = "dbCaixa"
    Const user = "sa"
    Const password = "123456"
    Private Server = "(local)"

    Public Enum tpServidor
        Access = 0
        SqlServer = 1
        MySQL = 2
        PostgreSQL = 3
        Oracle = 4
        SQLite = 5
    End Enum

    Private Function GetConnectionString(ByVal servidor As tpServidor) As String
        Select Case servidor
            Case tpServidor.SqlServer
                Return $"Server={Server};Database={DataBase};User Id={user};Password={password};"
            Case tpServidor.MySQL
                Return $"Server={Server};Database={DataBase};User={user};Password={password};"
            Case tpServidor.PostgreSQL
                Return $"Host={Server};Database={DataBase};Username={user};Password={password};"
            Case tpServidor.Oracle
                Return $"Data Source={Server};User Id={user};Password={password};"
            Case tpServidor.SQLite
                Dim dbPath As String = My.Computer.FileSystem.CurrentDirectory & If(Right(My.Computer.FileSystem.CurrentDirectory, 1) = "\", "", "\") & DataBase & ".sqlite"
                Return $"Data Source={dbPath};Version=3;"
            Case Else ' Access
                Dim acess_db2 As String = My.Computer.FileSystem.CurrentDirectory
                acess_db2 &= If(Right(acess_db2, 1) = "\", "", "\")
                acess_db2 &= DataBase & ".mdb"
                Return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DataBase};Persist Security Info=False"
        End Select
    End Function

    Private Function GetProviderInvariantName(ByVal servidor As tpServidor) As String
        Select Case servidor
            Case tpServidor.SqlServer
                Server = GetNomeSQLServer()
                Return "System.Data.SqlClient"
            Case tpServidor.MySQL
                Return "MySql.Data.MySqlClient"
            Case tpServidor.PostgreSQL
                Return "Npgsql"
            Case tpServidor.Oracle
                Return "Oracle.ManagedDataAccess.Client"
            Case tpServidor.SQLite
                Return "System.Data.SQLite"
            Case Else ' Access
                Return "System.Data.OleDb"
        End Select
    End Function
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
    Public Function RecebeTabela(ByVal Sql As String, Optional ByVal servidor As tpServidor = tpServidor.Access) As DataTable
        Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(GetProviderInvariantName(servidor))
        cn = factory.CreateConnection()
        cn.ConnectionString = GetConnectionString(servidor)

        Dim dt As New DataTable()
        Try
            cn.Open()
            Dim cmd As DbCommand = cn.CreateCommand()
            cmd.CommandText = Sql
            Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
            adapter.SelectCommand = cmd
            adapter.Fill(dt)
        Catch ex As Exception
            dt = Nothing
            MsgBox("Banco de Dados não encontrado!")
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

        Return dt
    End Function

End Module
