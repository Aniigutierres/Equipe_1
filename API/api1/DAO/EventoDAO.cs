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
            string query = "SELECT * FROM evento";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evento evento = new Evento();
                        evento.IdEvento = reader.GetInt32("id_evento");
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
            string query = $"SELECT * FROM bd_eventos_senailp WHERE id_evento = {id}";
        try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Evento e = new Evento();
                        e.IdEvento = reader.GetInt32("id_evento");
                        e.Descricao = reader.GetString("descricao");
                        e.TotalIngresso = reader.GetInt32("total_ingressos");
                        e.DataEvento = reader.GetDateTime("data_evento");
                        e.ImagemUrl = reader.GetString("imagem_url");
                        e.Local = reader.GetString("local");
                        e.Ativo = reader.GetInt32("ativo");
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
            string query = "insert into personagem (id_evento, descricao, total_ingresso, data_evento, imagem_Url, local, ativo)" +
                           "values (@IdEvento, @descricao, @TotalIngresso, @DataEvento, @ImagemUrl, @Local, @Ativo)";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                    command.Parameters.AddWithValue("@Descricao", evento.Descricao);
                    command.Parameters.AddWithValue("@TotalIngresso", evento.TotalIngresso);
                    command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
                    command.Parameters.AddWithValue("@ImagemUrl", evento.ImagemUrl);
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
                string query = "UPDATE evento SET" +
                                "id_evento=@IdEvento, " +
                                "descricao=@descricao, " +
                                "total_ingresso=@TotalIngresso, " +
                                "data_evento=@DataEvento, " +
                                "imagem_Url=@ImagemUrl " +
                                "local=@Local " +
                                "ativo=@Ativo " +
                                "WHERE id_evento=@id_evento";
 
               
                try
                {
                    _connection.Open();
                    using (var command = new MySqlCommand(query, _connection))
                    {
                    command.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                    command.Parameters.AddWithValue("@Descricao", evento.Descricao);
                    command.Parameters.AddWithValue("@TotalIngresso", evento.TotalIngresso);
                    command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
                    command.Parameters.AddWithValue("@ImagemUrl", evento.ImagemUrl);
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
                string query = "DELETE FROM evento WHERE id_evento = @id_evento";
 
                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@id_evento", id);
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
