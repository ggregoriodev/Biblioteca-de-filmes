using Crud_BD;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_joao.Models;

namespace Trabalho_joao.Repository
{
    internal class FilmeRepository
    {
        public bool Inserir(Filme filme)
        {
            using (var connection = Banco.conectar())
            {
                string sql = @"INSERT INTO Filme (Titulo, Genero, AnoLancamento, Diretor, UsuarioId) 
                               VALUES (@Titulo, @Genero, @AnoLancamento, @Diretor, @UsuarioId);";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@Genero", filme.Genero);
                    cmd.Parameters.AddWithValue("@AnoLancamento", filme.AnoLancamento);
                    cmd.Parameters.AddWithValue("@Diretor", filme.Diretor);
                    cmd.Parameters.AddWithValue("@UsuarioId", filme.UsuarioId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine("Erro ao inserir filme: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public Filme BuscarPorId(int id)
        {
            using (var connection = Banco.conectar())
            {
                string sql = "SELECT * FROM Filme WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Filme
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Titulo = reader["Titulo"].ToString(),
                                Genero = reader["Genero"].ToString(),
                                AnoLancamento = Convert.ToInt32(reader["AnoLancamento"]),
                                Diretor = reader["Diretor"].ToString(),
                                UsuarioId = Convert.ToInt32(reader["UsuarioId"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<Filme> ListarTodos()
        {
            var filmes = new List<Filme>();

            using (var connection = Banco.conectar())
            {
                string sql = "SELECT * FROM Filme;";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            filmes.Add(new Filme
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Titulo = reader["Titulo"].ToString(),
                                Genero = reader["Genero"].ToString(),
                                AnoLancamento = Convert.ToInt32(reader["AnoLancamento"]),
                                Diretor = reader["Diretor"].ToString(),
                                UsuarioId = Convert.ToInt32(reader["UsuarioId"])
                            });
                        }
                    }
                }
            }

            return filmes;
        }

        public bool Atualizar(Filme filme)
        {
            using (var connection = Banco.conectar())
            {
                string sql = @"UPDATE Filme 
                               SET Titulo = @Titulo, Genero = @Genero, AnoLancamento = @AnoLancamento, Diretor = @Diretor, UsuarioId = @UsuarioId 
                               WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@Genero", filme.Genero);
                    cmd.Parameters.AddWithValue("@AnoLancamento", filme.AnoLancamento);
                    cmd.Parameters.AddWithValue("@Diretor", filme.Diretor);
                    cmd.Parameters.AddWithValue("@UsuarioId", filme.UsuarioId);
                    cmd.Parameters.AddWithValue("@Id", filme.Id);

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine("Erro ao atualizar filme: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool Deletar(int id)
        {
            using (var connection = Banco.conectar())
            {
                string sql = "DELETE FROM Filme WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine("Erro ao deletar filme: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
    

