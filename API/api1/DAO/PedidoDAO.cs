using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using api.Repository;
using MySql.Data.MySqlClient;
 
namespace api.DAO
{
    public class PedidoDAO
    {
        private MySqlConnection _connection;
 
        public PedidoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }
 
        public List<Pedido> GetAll()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            string query = "SELECT * FROM pedidos";
 
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Pedido pedido = new Pedido();
                        pedido.Idpedido = reader.GetInt32("id_pedido");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetString("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pagamento");
                        pedido.Ativo = reader.GetInt32("ativo");
                        pedido.ValidacaoIdUsuario = reader.GetString("validacao_Id_Usuario");
                        listaPedidos.Add(pedido);
                       
                    }
                }
            }
            catch(MySqlException ex)
            {
                //Mapeando os erros de banco
                Console.WriteLine($"Erro do Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
                //Mapeando os erros de forma geral
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                //Fecha a conexão com o banco
                _connection.Close();
            }
 
            return listaPedidos;
 
        }      
    public Pedido GetId(int id)
        {
            Pedido pedido = new Pedido();
            string guery = $"SELECT * FROM bd_eventos_senailp.pedido where id_pedido = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(guery, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        pedido.Idpedido = reader.GetInt32("id_pedido");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetString("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pagamento");
                        pedido.Ativo = reader.GetInt32("ativo");
                        pedido.ValidacaoIdUsuario = reader.GetString("validacao_Id_Usuario");
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: { ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return pedido;
        }
       
        public void CriarPedido(Pedido pedido)
        {
            string query = "INSERT INTO pedido (idpedido, data, total, quantidade, forma_pagamento, ativo, validacao_id_usuario)" +
                        "VALUES (@Idpedido, @Data, @Total, @Quantidade, @FormaPagamento, @Ativo, @ValidacaoIdUsuario)";
 
       
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Idpedido", pedido.Idpedido);
                    command.Parameters.AddWithValue("@Data", pedido.Data);
                    command.Parameters.AddWithValue("@Total", pedido.Total);
                    command.Parameters.AddWithValue("@Quantidade", pedido.Quantidade);
                    command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
                    command.Parameters.AddWithValue("@Ativo", pedido.Ativo);
                    command.Parameters.AddWithValue("@ValidacaoIdUsuario", pedido.ValidacaoIdUsuario);
                    command.ExecuteNonQuery();
                }
 
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: { ex.Message}");
            }
            finally
            {
                _connection.Close();
            }  
 
 
        }
 
            public void AtualizarPedido(int id, Pedido pedido)
            {
                string query = "UPDATE usuario SET" +
                                "Idpedido=@Idpedido, " +
                                "Data=@Data, " +
                                "Total=@Total, " +
                                "Quantidade=@Quantidade, " +
                                "FormaPagamento=@FormaPagamento " +
                                "Ativo=@Ativo " +
                                "ValidacaoIdUsuario=@ValidacaoIdUsuario " +
                                "WHERE id_usuario=@id_usuario";
 
               
                try
                {
                    _connection.Open();
                    using (var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@Idpedido", pedido.Idpedido);
                    command.Parameters.AddWithValue("@Data", pedido.Data);
                    command.Parameters.AddWithValue("@Total", pedido.Total);
                    command.Parameters.AddWithValue("@Quantidade", pedido.Quantidade);
                    command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
                    command.Parameters.AddWithValue("@Ativo", pedido.Ativo);
                    command.Parameters.AddWithValue("@ValidacaoIdUsuario", pedido.ValidacaoIdUsuario);
                    command.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro Desconhecido: { ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
                   
            }
 
 
            public void DeletarPedido(int id)
            {
                string query = "DELETE FROM pedido WHERE id_pedido = @id_pedido";
 
                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@id_pedido", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro Desconhecido: { ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
           
           
           
            }
 
    }
    }