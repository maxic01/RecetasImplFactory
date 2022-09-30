using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using recetasmasmasrapido.dominio;

namespace recetasmasmasrapido.servicios.interfaces
{
    internal interface IServicio
    {
        DataTable listarIngredientes();
        bool ejecutarReceta(Receta oReceta);
        int proximaReceta();
    }
}
