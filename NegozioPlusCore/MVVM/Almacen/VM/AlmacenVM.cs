using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Almacen.VM
{
    class AlmacenVM : NotificadorGenerico
    {
        public ObservableCollection<AlmacenXAML> Coleccion { get; set; }

        public AlmacenVM()
        {
            Coleccion = new ObservableCollection<AlmacenXAML>();
            Coleccion.Add(new AlmacenXAML("Tiendita de Don Pepe", "Avenida Siempre Viva #45"));
            Coleccion.Add(new AlmacenXAML("Gatitos Shop", "Avenida Los Inkas #45"));

        }
    }
}
