using System.Linq;
using System.Collections.Generic;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        
        private const string _strConection = "Database=Biblioteca;Data Source=localhost;User Id=root;";

        public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                u.Login = u.Login;
                u.Senha = u.Senha;

                bc.SaveChanges();
            }
        }

        //Listar Usuario
        public List<Usuario> Listar()
        {
            MySqlConnection connection = new MySqlConnection(_strConection);
            connection.Open();

            string sql = "SELECT * FROM Usuarios";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Usuario> list = new List<Usuario>();

            while (reader.Read())
            {
                Usuario u = new Usuario();

                u.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                    u.Login = reader.GetString("Login");

                list.Add(u);
            }
            connection.Close();
            return list;
        }

    }
}