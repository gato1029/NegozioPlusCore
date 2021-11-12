using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Categorias.VM
{
    class CategoriasVM : NotificadorGenerico
    {
        public ObservableCollection<CategoriasXAML> Coleccion { get; set; }

        public CategoriasVM()
        {
            Coleccion = new ObservableCollection<CategoriasXAML>();
            Coleccion.Add(new CategoriasXAML("Categoria 1"));
            Coleccion.Add(new CategoriasXAML("Categoria 2"));
            Coleccion.Add(new CategoriasXAML("Categoria 3"));

        }
    }
}
