using recetasmasmasrapido.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetasmasmasrapido.servicios
{
    abstract class AbstractFactory
    {
        public abstract IServicio crearServicio();
    }
}
