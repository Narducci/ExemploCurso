Imports System.Data.SqlClient

Public Class DataAccess
#Region "Variáveis do Banco de Dados"
    Private conn As SqlConnection
    Private command As SqlCommand
    Private dr As SqlDataReader
    Private da As SqlDataAdapter
#End Region

#Region "Construtor"
    Sub New()
        conn = New SqlConnection("Server=GUERREIRO\SQLEXPRESS;Database=ExemploCurso;User Id=sa;Password=Vbn2-sql3-vsmrc;") 'Vbn2-sql3-vsmrc
        conn.Open()
    End Sub
#End Region

#Region "Funções"
    ''' <summary>
    ''' Verifica e, se o banco estiver aberto, fecha a conexão.
    ''' </summary>
    Public Sub CloseConn()
        Try
            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Executa uma procedure e retorna um DataReader.
    ''' </summary>
    ''' <param name="procedure">Nome da procedure.</param>
    ''' <param name="parametros">Lista de parametros do SQLParameter.</param>
    ''' <returns>DataReader com o resultado da consulta.</returns>
    Public Function ExecutaStoreProcedureReader(ByVal procedure As String,
                                                ByVal parametros As List(Of SqlParameter)) As IDataReader
        Dim retornoReader As IDataReader

        Try
            'PREPARANDO O COMANDO PARA EXECUTAR UMA PROCEDURE
            command = New SqlCommand
            command = conn.CreateCommand
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = procedure
            command.Parameters.Clear()

            'ADICIONAR OS PARAMETROS
            For Each Par As SqlParameter In parametros
                command.Parameters.Add(Par)
            Next

            'EXECUTA O COMANDO
            retornoReader = command.ExecuteReader

            Return retornoReader

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Função para executar comandos de (INSERT, UPDATE E DELETE).
    ''' </summary>
    ''' <param name="procedure">Nome da procedure.</param>
    ''' <param name="parametros">Lista de parametros.</param>
    ''' <returns>Boolean.</returns>
    Public Function ExecuteStoredProcedure(ByVal procedure As String,
                                           ByVal parametros As List(Of SqlParameter)) As Boolean
        Dim retorno As Boolean = False

        Try
            'PREPARANDO O COMANDO PARA EXECUTAR UMA PROCEDURE
            command = New SqlCommand
            command = conn.CreateCommand
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = procedure
            command.Parameters.Clear()

            'ADICIONAR OS PARAMETROS
            For Each Par As SqlParameter In parametros
                command.Parameters.Add(Par)
            Next

            'EXECUTA O COMANDO
            retorno = command.ExecuteNonQuery

            Return retorno

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try
    End Function
    ''' <summary>
    ''' Função para executar consultas e retornar um DataSet.
    ''' </summary>
    ''' <param name="procedure">Nome da procedure.</param>
    ''' <param name="parametros">Lista de parametros.</param>
    ''' <returns>DataSet com o resultado da consulta.</returns>
    Public Function ExecutaStoredProcedureDataSet(ByVal procedure As String,
                                                  ByVal parametros As List(Of SqlParameter)) As DataSet
        Dim retornoDataSet As New DataSet

        Try
            'PREPARANDO O COMANDO PARA EXECUTAR UMA PROCEDURE
            command = New SqlCommand
            command = conn.CreateCommand
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = procedure
            command.Parameters.Clear()

            'ADICIONAR OS PARAMETROS
            For Each Par As SqlParameter In parametros
                command.Parameters.Add(Par)
            Next

            'EXECUTA O COMANDO
            da = New SqlDataAdapter(command)
            da.Fill(retornoDataSet)


            Return retornoDataSet

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Função para executar consultas e retornar um DataTable.
    ''' </summary>
    ''' <param name="procedure">Nome da procedure.</param>
    ''' <param name="parametros">Lista de parametros.</param>
    ''' <returns>DataTable com o resultado da consulta.</returns>
    Public Function ExecutaStoredProcedureDataTable(ByVal procedure As String,
                                                  ByVal parametros As List(Of SqlParameter)) As DataTable
        Dim retornoDataTable As New DataTable

        Try
            'PREPARANDO O COMANDO PARA EXECUTAR UMA PROCEDURE
            command = New SqlCommand
            command = conn.CreateCommand
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = procedure
            command.Parameters.Clear()

            'ADICIONAR OS PARAMETROS
            For Each Par As SqlParameter In parametros
                command.Parameters.Add(Par)
            Next

            'EXECUTA O COMANDO
            da = New SqlDataAdapter(command)
            da.Fill(retornoDataTable)


            Return retornoDataTable

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try
    End Function
#End Region
End Class
