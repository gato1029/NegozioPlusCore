using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Tiendas.VM
{
    class TiendasXAML : NotificadorGenerico
    {
        string nombre;
        string direccion;
        string almacen;

        public TiendasXAML(string nombre, string direccion, string almacen)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.almacen = almacen;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Almacen { get => almacen; set => almacen = value; }
    }
}
