﻿using System;
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
    public class InventarioDAO
    {
        public List<Inventarios> getAll()
        {
            List<Inventarios> lista = new List<Inventarios>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("select * from ReporteInventario");
            DataTable dt = datos.Tables[0];
            Inventarios p;
            foreach (DataRow r in dt.Rows)
            {
                p = new Inventarios();
                p.CodigoPro = (int)r.ItemArray[0];
                p.Nombre = (string)r.ItemArray[1];
                p.Cantidad = (int)r.ItemArray[2];
                p.Inco = (int)r.ItemArray[3];
                if(r.ItemArray[4] != System.DBNull.Value)
                {
                    p.NombreEmp = (string)r.ItemArray[4];
                }
                if (r.ItemArray[4] != System.DBNull.Value)
                {
                    p.Fecha = (string)r.ItemArray[5];
                }
                lista.Add(p);
            }

            return lista;
        }
        public List<Inventarios> getAllInventario()
        {
            List<Inventarios> lista = new List<Inventarios>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("select p.Codigo,p.Nombre,p.Cantidad,(select c.nombre from categoria c where p.categoria = c.codigo) as Categoria from producto p");
            DataTable dt = datos.Tables[0];
            Inventarios p;
            foreach (DataRow r in dt.Rows)
            {
                p = new Inventarios();
                p.Codigo = (int)r.ItemArray[0];
                p.Nombre = (string)r.ItemArray[1];
                p.Cantidad = (int)r.ItemArray[2];
                p.Categoria = (string)r.ItemArray[3];
                lista.Add(p);
            }
            return lista;
        }

        public List<Producto> getById(int Id)
        {
            List<Producto> lista = new List<Producto>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("SELECT * FROM producto where ");
            DataTable dt = datos.Tables[0];
            Producto p;
            foreach (DataRow r in dt.Rows)
            {
                p = new Producto();
                p.Codigo = (int)r.ItemArray[0];
                p.Nombre = (string)r.ItemArray[1];
                p.Cantidad = (int)r.ItemArray[2];
                p.PrecioCosto = (Decimal)r.ItemArray[3];
                if (r.ItemArray[4] != null)
                {
                    p.PrecioPublico = (Decimal)r.ItemArray[4];
                }
                if (r.ItemArray[5] != null)
                {
                    p.PrecioMayoreo = (Decimal)r.ItemArray[5];
                }
                p.Categoria = (int)r.ItemArray[6]; ;
                lista.Add(p);
            }

            return lista;
        }

        public Producto Buscar2(int id)
        {
            Conexion cn = new Conexion();
            if (cn.Conectar())
            {
                try
                {
                    // Conexion.conexion.Open();

                    string strSQL = "select * from Producto where codigo = " + id;
                    MySqlCommand cm = new MySqlCommand(strSQL, Conexion.conexion);
                    MySqlDataReader dr = cm.ExecuteReader();
                    Producto x = null;
                    while (dr.Read())
                    {
                        x = new Producto();
                        x.Codigo = dr.GetInt32("Codigo");
                        x.Nombre = dr.GetString("Nombre");
                        x.Cantidad = dr.GetInt32("Cantidad");
                        x.PrecioCosto = dr.GetDecimal("PrecioCosto");
                        x.PrecioPublico = dr.GetDecimal("PrecioPublico");
                        x.PrecioMayoreo = dr.GetDecimal("PrecioMayoreo");
                        x.Categoria = dr.GetInt32("Categoria");
                    }
                    cm.Dispose();

                    return x;

                }
                catch (Exception ex)
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

        public Boolean insert(int id, int cant, int inco, int idEmp, string fecha)
        {
            try
            {
                Conexion con = new Conexion();
                String SQL = "INSERT INTO inventario(codigoPro,cantidad,inconsistencias,codigoEmp,fecha)" +
                    "VALUE (@id,@cant,@inco,@idEmp,@fecha);";

                MySqlCommand sqlCom = new MySqlCommand();
                sqlCom.CommandText = SQL;
                sqlCom.Parameters.AddWithValue("@id", id);
                sqlCom.Parameters.AddWithValue("@cant", cant);
                sqlCom.Parameters.AddWithValue("@inco",inco);
                sqlCom.Parameters.AddWithValue("@idEmp", idEmp);
                sqlCom.Parameters.AddWithValue("@fecha", fecha);                
                con.EjecutaSQLComando(sqlCom);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void delete(Producto p)
        {
            Conexion con = new Conexion();
            String SQL = "DELETE FROM producto WHERE codigo=@id limit 1;";

            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@id", p.Codigo);
            con.EjecutaSQLComando(sqlCom);
        }

        public void delete2(int id)
        {
            Conexion con = new Conexion();
            String SQL = "DELETE FROM producto WHERE codigo=@id limit 1;";
            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@id", id);
            con.EjecutaSQLComando(sqlCom);
        }

        public void update(Producto p)
        {
            Conexion con = new Conexion();
            String SQL = "UPDATE producto" +
                "SET nombre = @nombre,cantidad=@cantidad,precioCosto=@precioCosto,precioPublico=@precioPublico," +
                "precioMayoreo=@precioMayoreo,categoria=@categoria" +
                "WHERE codigo = @id limit 1;";

            MySqlCommand sqlCom = new MySqlCommand();
            sqlCom.CommandText = SQL;
            sqlCom.Parameters.AddWithValue("@id", p.Codigo);
            sqlCom.Parameters.AddWithValue("@nombre", p.Nombre);
            sqlCom.Parameters.AddWithValue("@cantidad", p.Cantidad);
            sqlCom.Parameters.AddWithValue("@precioCosto", p.PrecioCosto);
            sqlCom.Parameters.AddWithValue("@precioPublico", p.PrecioPublico);
            sqlCom.Parameters.AddWithValue("@precioMayoreo", p.PrecioMayoreo);
            sqlCom.Parameters.AddWithValue("@categoria", p.Categoria);
            con.EjecutaSQLComando(sqlCom);
        }

        public bool updateProducto(int id, int cantidad)
        {
            try
            {
                Conexion con = new Conexion();
                String SQL = "UPDATE producto SET cantidad = cantidad + (" + cantidad + ") WHERE codigo = " + id + " limit 1 ";
                MySqlCommand sqlCom = new MySqlCommand();
                sqlCom.CommandText = SQL;
                con.EjecutaSQLComando(sqlCom);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataSet getAllDataset()
        {
            Conexion con = new Conexion();
            DataSet datos = con.LLenaComboGrid("SELECT * FROM producto");
            return datos;
        }
    }
}
