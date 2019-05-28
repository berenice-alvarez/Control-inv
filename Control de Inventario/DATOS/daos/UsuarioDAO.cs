using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS.modelo;
using DATOS.util;
using MySql.Data.MySqlClient;

namespace DATOS.daos
{
    public class UsuarioDAO
    {
        Conexion cn = new Conexion();
        public bool Ingresar(String usu, String contra)
        {
            if (cn.Conectar())
            {
                try
                {
                    // Conexion.conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("select contrasenia from Usuario where usuario = @logan", Conexion.conexion);
                    cmd.Parameters.AddWithValue("@logan", usu);
                    string contraBD = (string)cmd.ExecuteScalar();
                    //para ingresar, eliminar, actualizar, Para ingresarlos utilizar executeNonQuery ya que no regresa nada
                    //para buscar, utilizar el executeReader
                    cmd.CommandText = "select sha1(@contra)";
                    cmd.Parameters.AddWithValue("@contra", contra);
                    string contraApli = (string)cmd.ExecuteScalar();
                    if (contraBD == contraApli)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {                    
                    return false;
                }
                finally
                {
                    Conexion.conexion.Close();
                }
            }
            else { return false; }
        }

        public bool insert(Usuario u)
        {
            try {
                Conexion con = new Conexion();
            String SQL = "INSERT INTO usuario (nombre,apellidoPaterno,apellidoMaterno,telefono,email,contrasenia,usuario,nivel)" +
                "VALUES (@nombre,@apellidoPaterno,@apellidoMaterno,@telefono,@email,sha1(@contrasenia),@usuario,@nivel);";

            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@nombre", u.Nombre);
            sqlCom.Parameters.AddWithValue("@apellidoPaterno", u.ApellidoPaterno);
            sqlCom.Parameters.AddWithValue("@apellidoMaterno", u.ApellidoMaterno);
            sqlCom.Parameters.AddWithValue("@telefono", u.Telefono);
            sqlCom.Parameters.AddWithValue("@email", u.Email);
            sqlCom.Parameters.AddWithValue("@contrasenia", u.Password);
            sqlCom.Parameters.AddWithValue("@usuario", u.User);
            sqlCom.Parameters.AddWithValue("@nivel", u.Nivel);
            con.EjecutaSQLComando(sqlCom);
            return true;
            }
            catch (Exception e) {
                return false;
            }
            
        }

        public void delete(Usuario u)
        {
            Conexion con = new Conexion();
            String SQL = "DELETE FROM usuario WHERE codigo=@id limit 1;";

            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@id", u.Codigo);
            con.EjecutaSQLComando(sqlCom);
        }

        public void delete2(int id)
        {
            Conexion con = new Conexion();
            String SQL = "DELETE FROM usuario WHERE codigo=@id limit 1;";
            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@id", id);
            con.EjecutaSQLComando(sqlCom);
        }

        public void update(Usuario u)
        {
            Conexion con = new Conexion();
            String SQL = "UPDATE usuario" +
                "SET nombre = @nombre,apellidoPaterno=@apellidoPaterno,apellidoMaterno=@apellidoMaterno,telefono=@telefono," +
                "email=@email,contrasenia=@contrasenia,usuario=@usuario,nivel=@nivel" +
                "WHERE codigo = @id limit 1;";

            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@id", u.Codigo);
            sqlCom.Parameters.AddWithValue("@nombre", u.Nombre);
            sqlCom.Parameters.AddWithValue("@apellidoPaterno", u.ApellidoPaterno);
            sqlCom.Parameters.AddWithValue("@apellidoMaterno", u.ApellidoMaterno);
            sqlCom.Parameters.AddWithValue("@telefono", u.Telefono);
            sqlCom.Parameters.AddWithValue("@email", u.Email);
            sqlCom.Parameters.AddWithValue("@contrasenia", u.Password);
            sqlCom.Parameters.AddWithValue("@usuario", u.User);
            sqlCom.Parameters.AddWithValue("@nivel", u.Nivel);
            con.EjecutaSQLComando(sqlCom);
        }


        public List<Usuario> getAll()
        {
            List<Usuario> lista = new List<Usuario>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("SELECT * FROM usuario");
            DataTable dt = datos.Tables[0];
            Usuario u;
            foreach (DataRow r in dt.Rows)
            {

                u = new Usuario();
                u.Codigo = (int)r.ItemArray[0];
                u.Nombre = (string)r.ItemArray[1];
                u.ApellidoPaterno = (String)r.ItemArray[2];
                u.ApellidoMaterno = (String)r.ItemArray[3];
                u.Telefono = (String)r.ItemArray[4];
                u.Email = (String)r.ItemArray[5];
                u.Password = (String)r.ItemArray[6];
                u.User = (String)r.ItemArray[7];
                u.Nivel = (String)r.ItemArray[8];
                lista.Add(u);
            }

            return lista;
        }

        public Usuario getOne(String usu)
        {
            if (cn.Conectar())
            {
                try
                {
                    string strSQL = "SELECT * FROM usuario where usuario='" + usu + "' limit 1";
                    MySqlCommand cm = new MySqlCommand(strSQL, Conexion.conexion);
                    MySqlDataReader dr = cm.ExecuteReader();
                    Usuario u = null;
                    while (dr.Read())
                    {

                        u = new Usuario();
                        u.Codigo = dr.GetInt32("codigo");
                        u.Nombre = dr.GetString("nombre");
                        u.ApellidoPaterno = dr.GetString("apellidoPaterno");
                        u.ApellidoMaterno = dr.GetString("apellidoMaterno");
                        u.Telefono = dr.GetString("telefono");
                        u.Email = dr.GetString("email");
                        u.Password = dr.GetString("contrasenia");
                        u.User = dr.GetString("usuario");
                        u.Nivel = dr.GetString("nivel");

                    }
                    cm.Dispose();
                    return u;
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    Conexion.conexion.Close();
                }

            }
            else { return null; }
        }

            public DataSet getAllDataset()
        {
            Conexion con = new Conexion();
            DataSet datos = con.LLenaComboGrid("SELECT * FROM usuario");
            return datos;
        }
    }
}
