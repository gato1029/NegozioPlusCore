using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.NucleoRealm;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioVentanaVM: NotificadorGenerico
    {
        private ObservableCollection<ModulosUsuario> checkListModulos;
        private ObservableCollection<ModulosUsuario> checkListModulosSeleccionados;

        private string usuario;
        private string nombre;
        private string cargo;
        

        public ICommand ComandoClickGuardar => new RelayCommand<Object>(ClickGuardar, (o) => { return true; });

        private void ClickGuardar(object obj)
        {
            foreach (var item in CheckListModulosSeleccionados)
            {
                MessageBox.Show(item.Nombre);
            }            
        }                
        public string Usuario
        {
            get { return this.usuario; }
            set { SetValue(ref this.usuario, value); }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string Cargo
        {
            get { return this.cargo; }
            set { SetValue(ref this.cargo, value); }
        }

        public UsuarioVentanaVM()
        {
            CheckListModulos = new ObservableCollection<ModulosUsuario>();
            CheckListModulosSeleccionados = new ObservableCollection<ModulosUsuario>();
            checkListModulos.Add(new ModulosUsuario("demo"));
            checkListModulos.Add(new ModulosUsuario("demo2"));
            checkListModulos.Add(new ModulosUsuario("demo3"));
            checkListModulos.Add(new ModulosUsuario("demo4"));
            ConectarMongo();
        }

        private void ConectarMongo()
        {
            Configuracion configuracion = Configuracion.Instanciar();
           
        }

        public ObservableCollection<ModulosUsuario> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
        public ObservableCollection<ModulosUsuario> CheckListModulosSeleccionados { get => checkListModulosSeleccionados; set => checkListModulosSeleccionados = value; }
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
