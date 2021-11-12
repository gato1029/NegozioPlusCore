using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Categorias.VM
{
    class CategoriasXAML : NotificadorGenerico
    {
        string nombre;

        public CategoriasXAML(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }

    }
}
