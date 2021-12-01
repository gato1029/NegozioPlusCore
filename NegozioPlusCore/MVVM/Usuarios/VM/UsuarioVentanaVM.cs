using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.NucleoRealm.ModelosBson;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioVentanaVM: NotificadorGenerico
    {
        private ObservableCollection<String> checkListModulos;
        private ObservableCollection<ModulosUsuario> checkListModulosSeleccionados;

        private string usuario;
        private string nombre;
        private string cargo;
        private string idRealm;
        private Usuario usuarioRealm;
        public ICommand ComandoClickGuardar => new RelayCommand<Window>(ClickGuardar, (o) => { return true; });
        public ICommand ComandoClickCerrar => new RelayCommand<Object>(ClickCerrar, (o) => { return true; });

        private void ClickCerrar(object obj)
        {
            AdministradorVentanas.Instance.EliminarVentana<UsuarioVentana>(idRealm);
        }

        private async  void ClickGuardar(Window obj)
        {                            
            if (usuarioRealm.Id==null) // indica que es nuevo
            {              
                usuarioRealm.Id = ObjectId.GenerateNewId();
                usuarioRealm.IdEmp = ServiceLocator.Instance.GetService<NucleoRealm.Modelos.Empresa>();
                usuarioRealm.Nombre = nombre;
                usuarioRealm.Rol = cargo;
                usuarioRealm.UsuarioLocal = usuario;
                await UsuarioController.Instance.Insertar(usuarioRealm);
                UsuarioUCVM UC = ServiceLocator.Instance.GetService<UsuarioUC>().DataContext as UsuarioUCVM;
                UC.RefrescarGrid(usuarioRealm);
            }
            else
            {  //modificacion
                Usuario usuarioModificado = new Usuario();
                usuarioModificado.Nombre = nombre;
                usuarioModificado.Rol = cargo;
                usuarioModificado.UsuarioLocal = usuario;
                await UsuarioController.Instance.Modificar(usuarioRealm.Id.Value, usuarioModificado);
            }
            obj.Close();
            AdministradorVentanas.Instance.EliminarVentana<UsuarioVentana>(idRealm);
            
            //foreach (var item in CheckListModulosSeleccionados)
            //{
            //    MessageBox.Show(item.Nombre);
            //}            
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

        public UsuarioVentanaVM(Usuario usuarioRealm)
        {
            this.usuarioRealm = usuarioRealm;
            if (usuarioRealm.Id == null)
            {
                //nuevo dato
                idRealm = "0";
            }
            else
            {
                idRealm = usuarioRealm.Id.ToString();
                usuario = usuarioRealm.UsuarioLocal;
                nombre = usuarioRealm.Nombre;
                cargo = usuarioRealm.Rol;
                CheckListModulos = new ObservableCollection<string>(usuarioRealm.Modulos);
            }
        }
        public UsuarioVentanaVM()
        {
                   
        }

        public ObservableCollection<String> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
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
