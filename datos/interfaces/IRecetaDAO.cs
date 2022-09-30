using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using recetasmasmasrapido.dominio;

namespace recetasmasmasrapido.datos.interfaces
{
    internal interface IRecetaDAO
    {
        DataTable getListarIngredientes();
        bool getEjecutarReceta(Receta oReceta);
        int getProximaReceta();
    }
}
