using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.dominio
{
    internal class Receta
    {
        public string Nombre { get; set; }
        public string Cheff { get; set; }
        public int TipoReceta { get; set; }
        public List<DetalleReceta> detalleReceta { get; set; }
        public Receta()
        {
            detalleReceta = new List<DetalleReceta>();
        }
        public void agregarDetalle(DetalleReceta detalle)
        {
            detalleReceta.Add(detalle);
        }
        public void quitarDetalle(int index)
        {
            detalleReceta.RemoveAt(index);
        }
    }
}
