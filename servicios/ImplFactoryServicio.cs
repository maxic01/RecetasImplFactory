using recetasmasmasrapido.servicios.implementaciones;
using recetasmasmasrapido.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.servicios
{
    internal class ImplFactoryServicio : AbstractFactory
    {
        public override IServicio crearServicio()
        {
            return new RecetaServicio();
        }
    }
}
