using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Tiendas.VM
{
    class TiendasVM : NotificadorGenerico
    {
        public ObservableCollection<TiendasXAML> Coleccion { get; set; }

        public TiendasVM()
        {
            Coleccion = new ObservableCollection<TiendasXAML>();
            Coleccion.Add(new TiendasXAML("Tienda 1", "Alamcen 1", "Avenida 1"));
            Coleccion.Add(new TiendasXAML("Tienda 2", "Almacen 2", "Avenida 2"));

        }
    }
}
