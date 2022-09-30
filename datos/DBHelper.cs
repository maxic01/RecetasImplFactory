using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using recetasmasmasrapido.dominio;

namespace recetasmasmasrapido.datos
{
    internal class DBHelper : acceso
    {
        private static DBHelper instancia;
        public static DBHelper obtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new DBHelper();
            }
            return instancia;
        }
        public bool ejecutarReceta(Receta oReceta)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_INSERTAR_RECETA";
                comando.Parameters.AddWithValue("@nombre", oReceta.Nombre);
                comando.Parameters.AddWithValue("@cheff", oReceta.Cheff);
                comando.Parameters.AddWithValue("@tipo_receta", oReceta.TipoReceta);
                SqlParameter parametro = new SqlParameter("@id", SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();
                int idReceta = (int)parametro.Value;
                foreach (DetalleReceta detalle in oReceta.detalleReceta)
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_INSERTAR_DETALLES";
                    comando.Parameters.AddWithValue("@id_receta", idReceta);
                    comando.Parameters.AddWithValue("@id_ingrediente", detalle.ingrediente.IdIngrediente);
                    comando.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    comando.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;
                
            }
            finally
            {
                desconectar();
            }
            return ok;
        }
        public int proximaReceta()
        {
            SqlParameter parametro = new SqlParameter("@next", SqlDbType.Int);
            conectar();
            comando.Parameters.Clear();
            comando.CommandText = "SP_PROXIMO_ID";
            parametro.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery ();
            desconectar();
            return (int)parametro.Value;
        }
        public DataTable listarIngredientes()
        {
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "SP_CONSULTAR_INGREDIENTES";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
    }
}
