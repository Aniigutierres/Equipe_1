using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repository;
using MySql.Data.MySqlClient;
 
namespace api.DAO
{
    public class EventoDAO
    {
        private MySqlConnection _connection;
        public EventoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }
 
        public List<Evento> GetAll()
        {
            List<Evento> eventos = new List<Evento>();
            string query = "SELECT * FROM eventos";
 
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evento evento = new Evento();
                        evento.IdEvento = reader.GetInt32("id_eventos");
                        evento.Descricao = reader.GetString("descricao");
                        evento.TotalIngresso = reader.GetInt32("total_ingressos");
                        evento.DataEvento = reader.GetDateTime("data_evento");
                        evento.ImagemUrl = reader.GetString("imagem_url");
                        evento.Local = reader.GetString("local");
                        evento.Ativo = reader.GetInt32("ativo");
                        eventos.Add(evento);
                    }
                }
            }
            catch (MySqlException ex) //mapeando os erros de banco
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex) //mapeando os erros de forma geral
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally //fecha conexão com o banco
            {
                _connection.Close();
            }
 
            return eventos;
        }
 
 
        public Evento GetId(int id)
        {
            Evento evento = new Evento();
            string query = $"SELECT * FROM eventos WHERE id_eventos = {id}";
        try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                      
                        evento.IdEvento = reader.GetInt32("id_eventos");
                        evento.Descricao = reader.GetString("descricao");
                        evento.TotalIngresso = reader.GetInt32("total_ingressos");
                        evento.DataEvento = reader.GetDateTime("data_evento");
                        evento.ImagemUrl = reader.GetString("imagem_url");
                        evento.Local = reader.GetString("local");
                        evento.Ativo = reader.GetInt32("ativo");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
 
 
            return evento;
        }
 
        public void CriarEvento(Evento evento)
        {
            string query = "insert into eventos (descricao, total_ingressos, data_evento, imagem_url, local, ativo)" +
                           "values (@descricao, @TotalIngressos, @DataEvento, @Imagemurl, @Local, @Ativo)";
 
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@descricao", evento.Descricao);
                    command.Parameters.AddWithValue("@TotalIngressos", evento.TotalIngresso);
                    command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
                    command.Parameters.AddWithValue("@Imagemurl", evento.ImagemUrl);
                    command.Parameters.AddWithValue("@Local", evento.Local);
                    command.Parameters.AddWithValue("@Ativo", evento.Ativo);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
 
        public void AtualizarEvento(int id, Evento evento)
            {
                string query = "UPDATE eventos SET " +
                                "descricao=@descricao, " +
                                "total_ingressos=@TotalIngressos, " +
                                "data_evento=@DataEvento, " +
                                "imagem_url=@Imagemurl, " +
                                "local=@Local, " +
                                "ativo=@Ativo " +
                                "WHERE id_eventos=@id_eventos";
 
               
                try
                {
                    _connection.Open();
                    using (var command = new MySqlCommand(query, _connection))
                    {
                    command.Parameters.AddWithValue("@id_eventos", evento.IdEvento);
                    command.Parameters.AddWithValue("@descricao", evento.Descricao);
                    command.Parameters.AddWithValue("@TotalIngressos", evento.TotalIngresso);
                    command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
                    command.Parameters.AddWithValue("@Imagemurl", evento.ImagemUrl);
                    command.Parameters.AddWithValue("@Local", evento.Local);
                    command.Parameters.AddWithValue("@Ativo", evento.Ativo);
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
         
        public void DeletarEvento (int id)
            {
                string query = "DELETE FROM eventos WHERE id_eventos = @id_eventos";
 
                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@id_eventos", id);
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