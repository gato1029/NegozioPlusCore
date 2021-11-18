using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioVentanaVM
    {
        private ObservableCollection<ModulosUsuario> checkListModulos;

        public UsuarioVentanaVM()
        {
            CheckListModulos = new ObservableCollection<ModulosUsuario>();
            checkListModulos.Add(new ModulosUsuario("demo"));
            checkListModulos.Add(new ModulosUsuario("demo2"));
            checkListModulos.Add(new ModulosUsuario("demo3"));
            checkListModulos.Add(new ModulosUsuario("demo4"));
        }

        public ObservableCollection<ModulosUsuario> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
    }

    public class ModulosUsuario
    {
        public ModulosUsuario(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre { get; set; }
    }
}
