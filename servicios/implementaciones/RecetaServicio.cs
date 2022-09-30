using recetasmasmasrapido.datos.implementaciones;
using recetasmasmasrapido.datos.interfaces;
using recetasmasmasrapido.dominio;
using recetasmasmasrapido.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.servicios.implementaciones
{
    internal class RecetaServicio : IServicio
    {
        private IRecetaDAO DAO;
        public RecetaServicio()
        {
            DAO = new RecetaDAO();
        }
        public bool ejecutarReceta(Receta oReceta)
        {
            return DAO.getEjecutarReceta(oReceta);
        }

        public DataTable listarIngredientes()
        {
            return DAO.getListarIngredientes();
        }

        public int proximaReceta()
        {
            return DAO.getProximaReceta();
        }
    }
}
