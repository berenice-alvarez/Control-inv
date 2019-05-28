using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS.modelo;
using MySql.Data.MySqlClient;
using DATOS.util;
using System.Data;

namespace DATOS.daos
{
    public class EntradaDAO
    {
        Conexion cn = new Conexion();
        public bool Registrar(int id, int can, decimal precio,decimal subt, int codUsu, string fech)
        {
            if (cn.Conectar())
            {
                try
                {               
                    /// AGREGAR EL REGISTRO A LA BASE DE DATOS
                    MySqlCommand comando = new MySqlCommand("call insertEntrada(@CodigoP, @cantidadPro,@precioUni,@subt,@codigoUsu, @fecha)", Conexion.conexion);
                    comando.Parameters.AddWithValue("CodigoP", id);
                    comando.Parameters.AddWithValue("cantidadPro", can);
                    comando.Parameters.AddWithValue("precioUni", precio);
                    comando.Parameters.AddWithValue("subt", subt);
                    comando.Parameters.AddWithValue("codigoUsu", codUsu);
                    comando.Parameters.AddWithValue("fecha", fech);

                    comando.ExecuteNonQuery();

                    /// FINALIZAMOS LA CONEXION CERRAMOS TODO
                    comando.Dispose();
                    Conexion.conexion.Close();
                    return true;
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
            return false;
        }
        public List<Entrada> getAllReporte()
        {
            List<Entrada> lista = new List<Entrada>();
            Conexion con = new Conexion();
            DataSet datos = con.LLenaComboGrid("SELECT * FROM Entrada;");
            DataTable dt = datos.Tables[0];
            Entrada e;
            foreach (DataRow r in dt.Rows)
            {
                e = new Entrada();
                e.codigo = (int)r.ItemArray[0];
                e.codigoProducto = (int)r.ItemArray[1];
                e.cantidadProductos = (int)r.ItemArray[2];
                e.precioUnitario = (decimal)r.ItemArray[3];
                e.subtotal = (decimal)r.ItemArray[4];
                e.codigoUsuario = (int)r.ItemArray[5];
                e.fecha = (DateTime)r.ItemArray[6];
                lista.Add(e);
            }
            return lista;
        }
    }
}
