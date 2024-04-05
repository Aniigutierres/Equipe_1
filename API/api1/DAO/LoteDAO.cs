using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Repository;
using MySql.Data.MySqlClient;
 
namespace api.DAO
{
    public class LoteDAO
    {
        private MySqlConnection _connection;
 
        public LoteDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }
 
        public List<Lote> GetAll()
        {
            List<Lote> lotes = new List<Lote>();
            string query = "SELECT * FROM lote";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lote lote = new Lote();
                        lote.IdLote = reader.GetInt32("id_lote");
                        lote.descricao = reader.GetString("descricao");
                        lote.ValorUnitario = reader.GetDouble("valor_unitario");
                        lote.QuantidadeTotal = reader.GetInt16("quantidade_total");
                        lote.Saldo = reader.GetInt16("saldo");
                        lote.Ativo = reader.GetInt16("ativo");
                        lote.eventos_ideventos = reader.GetInt32("eventos_ideventos");
                        lotes.Add(lote);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
 
            return lotes;
        }
 
        public Lote GetId(int id)
        {
            Lote lote = new Lote();
            string query = $"SELECT * FROM lote WHERE id_lote = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        lote.IdLote = reader.GetInt32("id_lote");
                        lote.descricao = reader.GetString("descricao");
                        lote.ValorUnitario = reader.GetDouble("valor_unitario");
                        lote.QuantidadeTotal = reader.GetInt16("quantidade_total");
                        lote.Saldo = reader.GetInt16("saldo");
                        lote.Ativo = reader.GetInt16("ativo");
                        lote.eventos_ideventos = reader.GetInt32("eventos_ideventos");
                    
                    
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return lote;
        }
 
        public void CriarLote(Lote lote)
        {
            string query = "INSERT INTO lote (eventos_ideventos, valor_unitario, quantidade_total, saldo, ativo, descricao)" +
                           "VALUES (@eventos_ideventos, @valor_unitario, @quantidade_total, @saldo, @ativo, @descricao)";
 
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@eventos_ideventos", lote.eventos_ideventos);
                    command.Parameters.AddWithValue("@descricao", lote.descricao);
                    command.Parameters.AddWithValue("@valor_Unitario", lote.ValorUnitario);
                    command.Parameters.AddWithValue("@quantidade_Total", lote.QuantidadeTotal);
                    command.Parameters.AddWithValue("@saldo", lote.Saldo);
                    command.Parameters.AddWithValue("@ativo", lote.Ativo);
                    command.ExecuteNonQuery();
                }
 
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
 
        public void AtualizarLote(int id, Lote lote)
        {
            string query = "UPDATE lote SET " +
                            "eventos_ideventos = @eventos_ideventos, " +
                            "valor_unitario = @ValorUnitario, " +
                            "quantidade_total = @QuantidadeTotal, " +
                            "saldo = @Saldo, " +
                            "ativo = @Ativo " +
                            "WHERE id_lote = @IdLote";
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdLote", id);
                    command.Parameters.AddWithValue("@eventos_ideventos", lote.eventos_ideventos);
                    command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                    command.Parameters.AddWithValue("@QuantidadeTotal", lote.QuantidadeTotal);
                    command.Parameters.AddWithValue("@Saldo", lote.Saldo);
                    command.Parameters.AddWithValue("@Ativo", lote.Ativo);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro no Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
 
        }
     public void DeletarLote(int id)
    {
        string query = "DELETE FROM lote WHERE id_lote = @id_lote";
 
    try{
        _connection.Open();
        using(var command = new MySqlCommand(query, _connection))
    {
        command.Parameters.AddWithValue("@id_lote", id);
        command.ExecuteNonQuery();
    }
    }
     catch(MySqlException ex)
    {
        Console.WriteLine($"Erro no banco: {ex.Message}");
    }
      catch(Exception ex)
    {
      Console.WriteLine($"Erro no banco: {ex.Message}");
    }
    finally
    {
        _connection.Close();
    }
    }
    }
}