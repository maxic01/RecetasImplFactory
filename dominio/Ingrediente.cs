using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.dominio
{
    internal class Ingrediente
    {
        public Ingrediente(int idIngrediente, string nombre)
        {
            IdIngrediente = idIngrediente;
            Nombre = nombre;
        }

        public int IdIngrediente { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
