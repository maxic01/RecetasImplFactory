using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.dominio
{
    internal class DetalleReceta
    {
        public Ingrediente ingrediente;

        public DetalleReceta(Ingrediente ingrediente, int cantidad)
        {
            this.ingrediente = ingrediente;
            Cantidad = cantidad;
        }

        public int Cantidad { get; set; }

    }
}
