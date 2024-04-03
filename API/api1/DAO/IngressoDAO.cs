using api.Models;
using api.Repository;
using MySql.Data.MySqlClient;
 
namespace api.DAO
{
    public class IngressoDAO
    {
        private MySqlConnection _connection;
 
        public IngressoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }
        public List<Ingresso> GetAll()
        {
            List<Ingresso> ingressos = new List<Ingresso>();
            string query = "SELECT * FROM Usuario";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Ingresso ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_usuario");
                        ingresso.CodigoQr = reader.GetString("nome_completo");
                        ingresso.Valor = reader.GetString("email");
                        ingresso.Status = reader.GetString("senha");
                        ingresso.Tipo = reader.GetString("telefone");
                        ingresso.PedidoIdPedido = reader.GetString("perfil");
                        ingresso.PedidoUsuarioIdUsuario = reader.GetString("status");
                        ingresso.LoteIdLote = reader.GetString("status");
                        ingresso.LoteEventoIdEvento = reader.GetString("status");
                        ingressos.Add(ingresso);
                       
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
 
            return ingressos;
        }
    public Ingresso GetId(int id)
        {
            Ingresso ingresso = new Ingresso();
            string guery = $"SELECT * FROM bd_eventos_senailp.ingresso where id_ingresso = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(guery, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.CodigoQr  = reader.GetString("codigo_qr");
                        ingresso.Valor = reader.GetString("valor");
                        ingresso.Status = reader.GetString("status");
                        ingresso.Tipo = reader.GetString("tipos");
                        ingresso.PedidoIdPedido = reader.GetString("pedido_id_pedido");
                        ingresso.PedidoUsuarioIdUsuario = reader.GetString("pedido_usuario_id_usuario");
                        ingresso.LoteIdLote = reader.GetString("lote_id_lote");
                        ingresso.LoteEventoIdEvento = reader.GetString("lote_evento_id_evento");
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
            return ingresso;
        }
       
        public void CriarIngresso(Ingresso ingresso)
        {
            string query = "INSERT INTO ingresso (id_ingresso, codigo_qr, valor, status, tipos, pedido_id_pedido, pedido_usuario_id_usuario, lote_id_lote, lote_evento_id_evento)" +
                        "VALUES (@IdIngresso, @CodigoQr, @valor, @status, @tipos, @PedidoIdPedido, @PedidoUsuarioIdUsuario, @LoteIdLote, @LoteEventoIdEvento)";
 
       
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdIngresso", ingresso.IdIngresso);
                    command.Parameters.AddWithValue("@CodigoQr", ingresso.CodigoQr);
                    command.Parameters.AddWithValue("@Valor", ingresso.Valor);
                    command.Parameters.AddWithValue("@Status", ingresso.Status);
                    command.Parameters.AddWithValue("@Tipos", ingresso.Tipo);
                    command.Parameters.AddWithValue("@PedidoIdPedido", ingresso.PedidoIdPedido);
                    command.Parameters.AddWithValue("@PedidoUsuarioIdUsuario", ingresso.PedidoUsuarioIdUsuario);
                    command.Parameters.AddWithValue("@LoteIdLote", ingresso.LoteIdLote);
                    command.Parameters.AddWithValue("@LoteEventoIdEvento", ingresso.LoteEventoIdEvento);
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
 
            public void AtualizarIngresso(int id, Ingresso ingresso)
            {
                string query = "UPDATE usuario SET" +
                                "id=@IdIngresso, " +
                                "pedidos_id=@PedidoIdPedido, " +
                                "pedidos_usuarios_id=@PedidoUsuarioIdUsuario, " +
                                "tipo=@Tipos, " +
                                "status=@Status, " +
                                "lote_id=@LoteIdLote, " +
                                "valor=@Valor,"+
                                "data_utilizacao="+
                                "WHERE id_usuario=@id_usuario";
 
               
                try
                {
                     _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdIngresso", ingresso.IdIngresso);
                    command.Parameters.AddWithValue("@Valor", ingresso.Valor);
                    command.Parameters.AddWithValue("@Status", ingresso.Status);
                    command.Parameters.AddWithValue("@Tipos", ingresso.Tipo);
                    command.Parameters.AddWithValue("@PedidoIdPedido", ingresso.PedidoIdPedido);
                    command.Parameters.AddWithValue("@PedidoUsuarioIdUsuario", ingresso.PedidoUsuarioIdUsuario);
                    command.Parameters.AddWithValue("@LoteIdLote", ingresso.LoteIdLote);
                    command.Parameters.AddWithValue("@LoteEventoIdEvento", ingresso.LoteEventoIdEvento);
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
 
 
            public void DeletarIngresso(int id)
            {
                string query = "DELETE FROM ingresso WHERE id_ingresso = @id_ingresso";
 
                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@id_ingresso", id);
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