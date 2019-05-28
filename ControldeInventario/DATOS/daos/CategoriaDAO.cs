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
    public class CategoriaDAO
    {
        public List<Categoria> getAll()
        {
            List<Categoria> lista = new List<Categoria>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("SELECT * FROM categoria");
            DataTable dt = datos.Tables[0];
            Categoria ca;
            foreach (DataRow r in dt.Rows)
            {
                ca = new Categoria();
                ca.codigo = (int)r.ItemArray[0];
                ca.nombre = (string)r.ItemArray[1];
                ca.descripcion = (string)r.ItemArray[2];             
                lista.Add(ca);
            }

            return lista;
        }
        public bool Registrar(string nombre, string descripcion) {
            try
            {
                Conexion con = new Conexion();
                String SQL = "INSERT INTO categoria (nombre,descripcion)" +
                    "VALUES (@nombre,@descripcion);";

                MySqlCommand sqlCom = new MySqlCommand();
                sqlCom.CommandText = SQL;
                sqlCom.Parameters.AddWithValue("@nombre", nombre);
                sqlCom.Parameters.AddWithValue("@descripcion", descripcion);           
                con.EjecutaSQLComando(sqlCom);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
