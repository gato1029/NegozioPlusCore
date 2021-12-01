using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Almacen.VM
{
    class AlmacenXAML : NotificadorGenerico
    {
        string nombre;
        string direccion;

        public AlmacenXAML(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
