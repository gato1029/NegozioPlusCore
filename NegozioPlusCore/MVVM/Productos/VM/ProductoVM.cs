using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Productos.VM
{
    class ProductoVM : NotificadorGenerico
    {
        public ObservableCollection<ProductoXAML> Coleccion { get; set; }

        public ProductoVM()
        {
            Coleccion = new ObservableCollection<ProductoXAML>();
            Coleccion.Add(new ProductoXAML("1hvh123v","leche", "12"));
            Coleccion.Add(new ProductoXAML("2213123v", "agua", "10"));
            Coleccion.Add(new ProductoXAML("3h123v", "malta", "9"));
            Coleccion.Add(new ProductoXAML("4hvh123v", "harina", "2"));

        }
    }
}
