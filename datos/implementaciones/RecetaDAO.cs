using recetasmasmasrapido.datos.interfaces;
using recetasmasmasrapido.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.datos.implementaciones
{
    internal class RecetaDAO : IRecetaDAO
    {
        public bool getEjecutarReceta(Receta oReceta)
        {
            return DBHelper.obtenerInstancia().ejecutarReceta(oReceta);
        }

        public DataTable getListarIngredientes()
        {
            return DBHelper.obtenerInstancia().listarIngredientes();
        }

        public int getProximaReceta()
        {
            return DBHelper.obtenerInstancia().proximaReceta();
        }
    }
}
