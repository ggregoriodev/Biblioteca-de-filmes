using Crud_BD;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_joao.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Trabalho_joao.Repository
{
    public class UsuarioRepository
    {
        public bool Inserir(Usuario usuario)
        {
            using (var connection = Banco.conectar())
            {
                string sql = "INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha);";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine("Erro ao inserir usuário: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            using (var connection = Banco.conectar())
            {
                string sql = "SELECT * FROM Usuario WHERE Email = @Email AND Senha = @Senha;";
                
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Senha = reader["Senha"].ToString()
                            };
                        }
                    }
                }
            }
          
            return null;
           
        }
       



    }
}
