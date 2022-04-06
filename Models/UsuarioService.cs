using System.Linq;
using System.Collections.Generic;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        
        private const string _strConection = "Database=Biblioteca;Data Source=localhost;User Id=root;";

        // Atualizar usuario
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


        // Alterar Usuario
            //Encontrar Id
        public Usuario EncontrarId(int Id)
        {
            MySqlConnection connection = new MySqlConnection(_strConection);
            connection.Open();

            string sql = "SELECT * FROM Usuarios WHERE Id=@Id";

            MySqlCommand command = new MySqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader reader = command.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();

            if (reader.Read())
            {
                UsuarioEncontrado.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = reader.GetString("Login");

                if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = reader.GetString("Senha");
            }

            connection.Close();
            return UsuarioEncontrado;
        }
            //Editar noticas
        public void Editar(Usuario u)
        {
            MySqlConnection connection = new MySqlConnection(_strConection);
            connection.Open();

            string sql = "UPDATE Usuarios SET Login=@Login, Senha=@Senha";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Login", u.Login);
            command.Parameters.AddWithValue("@Senha", u.Senha);

            command.ExecuteNonQuery();
            connection.Close();
        }
    
        //Excluir Usuario
        public void Excluir(Usuario u)
       {
           MySqlConnection connection = new MySqlConnection(_strConection);
           connection.Open();

           string sql = "DELETE FROM Usuarios WHERE Id = @Id";

           MySqlCommand command = new MySqlCommand(sql, connection);

           command.Parameters.AddWithValue("@Id", u.Id);

           command.ExecuteNonQuery();
           connection.Close();
       }

       //Autenticacao para login
        public Usuario FazerLogin(Usuario u)
        {
            MySqlConnection connection = new MySqlConnection(_strConection);
            connection.Open();

            string sql = "SELECT * FROM Usuarios WHERE Login=@Login AND Senha=@Senha";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Login", u.Login);
            command.Parameters.AddWithValue("@Senha", u.Senha);

            MySqlDataReader reader = command.ExecuteReader();

            Usuario usr = null;

            if (reader.Read())
            {
                usr = new Usuario();
                usr.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                    usr.Login = reader.GetString("Login");

                if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    usr.Senha = reader.GetString("Senha");
            }
            connection.Close();
            return usr;
        }
    }
}