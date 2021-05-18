Imports BancoDados

Public Class Form1
    Private objBanco As Cliente

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        objBanco = New Cliente
        objBanco.nome = txtNome.Text
        objBanco.endereco = txtEndereco.Text
        objBanco.numero = txtNumero.Text
        If objBanco.NovoCliente = True Then
            MessageBox.Show("Cliente cadastrado.")
        Else
            MessageBox.Show("Cliente não cadastrado.")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        objBanco = New Cliente
        objBanco.id = txtID.Text
        objBanco.nome = txtNome.Text
        objBanco.endereco = txtEndereco.Text
        objBanco.numero = txtNumero.Text
        If objBanco.AtualizaCliente = True Then
            MessageBox.Show("Cliente atualizado.")
        Else
            MessageBox.Show("Cliente não atualizado.")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        objBanco = New Cliente
        objBanco.id = txtID.Text
        If objBanco.DeleteCliente = True Then
            MessageBox.Show("Cliente deletado.")
        Else
            MessageBox.Show("Cliente não deletado.")
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        objBanco = New Cliente
        objBanco.id = txtID.Text
        If objBanco.ConsultaCliente = True Then
            txtNome.Text = objBanco.nome
            txtEndereco.Text = objBanco.endereco
            txtNumero.Text = objBanco.numero
        Else
            MessageBox.Show("Cliente não cadastrado.")
        End If
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        objBanco = New Cliente
        Dim tabela As DataTable = objBanco.ListaCliente
        dgvDados.DataSource = tabela
    End Sub
End Class
