using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Productos.VM
{
    class ProductoXAML : NotificadorGenerico
    {
        string codigo;
        string precio;
        string nombre;

        public ProductoXAML(string codigo, string nombre, string precio)
        {
            this.codigo = codigo;
            this.precio = precio;
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Codigo { get => codigo; set => codigo = value; }
    }
}
