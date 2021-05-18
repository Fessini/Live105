Imports MySqlConnector
Public Class Cliente
    'ATRIBUTOS
    Private conexao As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    '
    'CONTRUTOR
    Sub New()
        conexao = New MySqlConnection("Server=localhost;Database=live105;Uid=root;Pwd=@mar147;")
    End Sub
    '
    'PROPRIEDADES
    Public Property id As Integer
    Public Property nome As String
    Public Property endereco As String
    Public Property numero As String
    '
    'MÉTODOS
    Public Function NovoCliente() As Boolean
        Dim retorno As Boolean

        Try
            'CONFIGURANDO O COMANDO
            comando = New MySqlCommand
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexao
            comando.CommandText = "PR_NOVO_CLIENTE"
            comando.Parameters.AddWithValue("@PNOME", nome)
            If endereco.Length > 0 Then
                comando.Parameters.AddWithValue("@PENDERECO", endereco)
            Else
                comando.Parameters.AddWithValue("@PENDERECO", DBNull.Value)
            End If
            If numero.Length > 0 Then
                comando.Parameters.AddWithValue("@PNUMERO", numero)
            Else
                comando.Parameters.AddWithValue("@PNUMERO", DBNull.Value)
            End If
            '
            'ABRIR CONEXAO
            conexao.Open()
            '
            'EXECUTAR O COMANDO
            retorno = comando.ExecuteNonQuery
            '
            conexao.Close()
            '
            'Retorna 
            Return retorno

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AtualizaCliente() As Boolean
        Dim retorno As Boolean

        Try
            'CONFIGURANDO O COMANDO
            comando = New MySqlCommand
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexao
            comando.CommandText = "PR_ATUALIZA_CLIENTE"
            comando.Parameters.AddWithValue("@PNOME", nome)
            If endereco.Length > 0 Then
                comando.Parameters.AddWithValue("@PENDERECO", endereco)
            Else
                comando.Parameters.AddWithValue("@PENDERECO", DBNull.Value)
            End If
            If numero.Length > 0 Then
                comando.Parameters.AddWithValue("@PNUMERO", numero)
            Else
                comando.Parameters.AddWithValue("@PNUMERO", DBNull.Value)
            End If
            comando.Parameters.AddWithValue("@PID", id)
            '
            'ABRIR CONEXAO
            conexao.Open()
            '
            'EXECUTAR O COMANDO
            retorno = comando.ExecuteNonQuery
            '
            conexao.Close()
            '
            'Retorna 
            Return retorno

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DeleteCliente() As Boolean
        Dim retorno As Boolean

        Try
            'CONFIGURANDO O COMANDO
            comando = New MySqlCommand
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexao
            comando.CommandText = "PR_DELETE_CLIENTE"
            comando.Parameters.AddWithValue("@PID", id)
            '
            'ABRIR CONEXAO
            conexao.Open()
            '
            'EXECUTAR O COMANDO
            retorno = comando.ExecuteNonQuery
            '
            conexao.Close()
            '
            'Retorna 
            Return retorno

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultaCliente() As Boolean
        Dim retorno As Boolean = False

        Try
            'CONFIGURANDO O COMANDO
            comando = New MySqlCommand
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexao
            comando.CommandText = "PR_CONSULTA_CLIENTE"
            comando.Parameters.AddWithValue("@PID", id)
            '
            'ABRIR CONEXAO
            conexao.Open()
            '
            'EXECUTAR O COMANDO
            dr = comando.ExecuteReader
            Do While dr.Read
                nome = dr("NOME")
                If Not IsDBNull(dr("ENDERECO")) Then endereco = dr("ENDERECO")
                If Not IsDBNull(dr("NUMERO")) Then numero = dr("NUMERO")
                retorno = True
            Loop
            '
            conexao.Close()
            '
            'Retorna 
            Return retorno

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListaCliente() As DataTable
        Dim tabela As New DataTable

        Try
            'CONFIGURANDO O COMANDO
            comando = New MySqlCommand
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexao
            comando.CommandText = "PR_LISTA_CLIENTE"

            da = New MySqlDataAdapter(comando)
            da.Fill(tabela)

            Return tabela
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
