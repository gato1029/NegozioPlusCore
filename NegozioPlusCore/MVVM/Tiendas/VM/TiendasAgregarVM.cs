using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Tiendas.VM
{
    class TiendasAgregarVM
    {
        private ObservableCollection<ModulosAlmacenes> checkListModulos;

        public TiendasAgregarVM()
        {
            CheckListModulos = new ObservableCollection<ModulosAlmacenes>();
            checkListModulos.Add(new ModulosAlmacenes("demo"));
            checkListModulos.Add(new ModulosAlmacenes("demo2"));
            checkListModulos.Add(new ModulosAlmacenes("demo3"));
            checkListModulos.Add(new ModulosAlmacenes("demo4"));
        }

        public ObservableCollection<ModulosAlmacenes> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
    }

    public class ModulosAlmacenes
    {
        public ModulosAlmacenes(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre { get; set; }
    }
}

