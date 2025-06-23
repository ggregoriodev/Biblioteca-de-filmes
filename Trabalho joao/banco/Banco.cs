using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms; 


namespace Crud_BD
{
    public static class Banco
    {
        private static string caminhoBanco = @"C:\Users\guilh\source\repos\Trabalho joao\Trabalho joao\bd.sqlite";

        public static SQLiteConnection conectar()
        {
            SQLiteConnection conexao = new SQLiteConnection($"Data Source={caminhoBanco};Version=3;");

            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            return conexao;
        }

        public static void CriarTabelas()
        {
            using (var conn = conectar())
            {
                string sqlUsuario = @"
                CREATE TABLE IF NOT EXISTS Usuario (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Email TEXT NOT NULL UNIQUE,
                    Senha TEXT NOT NULL
                );
            ";

                string sqlFilme = @"
                CREATE TABLE IF NOT EXISTS Filme (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Genero TEXT,
                    AnoLancamento INTEGER,
                    Diretor TEXT NOT NULL, 
                    UsuarioId INTEGER,
                    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
                );
            ";

                using (var cmd = new SQLiteCommand(sqlUsuario, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SQLiteCommand(sqlFilme, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
         

        }
    }
}