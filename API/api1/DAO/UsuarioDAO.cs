using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repository;
using MySql.Data.MySqlClient;

namespace api.DAO
{
    public class UsuarioDAO
    {
        private MySqlConnection _connection;

        public UsuarioDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM usuario";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = reader.GetInt32("id_usuario");
                        usuario.NomeCompleto = reader.IsDBNull("nome_completo") ? "" : reader.GetString("nome_completo");
                        usuario.Email = reader.IsDBNull("email") ? "" : reader.GetString("email");
                        usuario.Senha = reader.IsDBNull("senha") ? "" : reader.GetString("senha");
                        usuario.Telefone = reader.IsDBNull("telefone") ? "" : reader.GetString("telefone");
                        usuario.Perfil = reader.IsDBNull("perfil") ? "" : reader.GetString("perfil");
                        usuario.Status = reader.IsDBNull("status") ? "" :reader.GetString("status");
                        usuarios.Add(usuario);
                        
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

            return usuarios;
        }
    public Usuario GetId(int id)
        {
            Usuario usuario = new Usuario();
            string guery = $"SELECT * FROM bd_eventos_senailp.usuario where id_usuario = {id}";
            try 
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(guery, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        usuario.IdUsuario = reader.GetInt32("id_usuario");
                        usuario. NomeCompleto = reader.GetString("nome_completo");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetString("senha");
                        usuario.Telefone = reader.GetString("telefone");
                        usuario.Perfil = reader.GetString("perfil");
                        usuario.Status = reader.GetString("status");
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
            return usuario;
        }
        
        public void CriarUsuario(Usuario usuario)
        {
            string query = "INSERT INTO usuario (nome_completo, email, senha, telefone, perfil, status)" +
                        "VALUES (@NomeCompleto, @Email, @Senha, @Telefone, @Perfil, @Status)";

        
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@NomeCompleto", usuario.NomeCompleto);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Senha", usuario.Senha);
                    command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@Perfil", usuario.Perfil);
                    command.Parameters.AddWithValue("@Status", usuario.Status);
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

            public void AtualizarUsuario(int id, Usuario usuario)
            {
                string query = "UPDATE usuario SET" +
                                "nome_completo=@NomeCompleto, " +
                                "email=@Email, " +
                                "senha=@Senha, " +
                                "telefone=@Telefone, " +
                                "perfil=@Perfil " +
                                "status=@Status " +
                                "WHERE id_usuario=@id_usuario";

                
                try
                {
                    _connection.Open();
                    using (var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", id);
                        command.Parameters.AddWithValue("@NomeCompleto", usuario.NomeCompleto);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@Senha", usuario.Senha);
                        command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                        command.Parameters.AddWithValue("@Perfil", usuario.Perfil);
                        command.Parameters.AddWithValue("@Status", usuario.Status);
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


            public void DeletarUsuario(int id)
            {
                string query = "DELETE FROM usuario WHERE id_usuario = @id_usuario";

                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@id_usuario", id);
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