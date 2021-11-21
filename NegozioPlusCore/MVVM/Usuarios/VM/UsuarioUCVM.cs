using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.MVVM.Principal.VM;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioUCVM : NotificadorGenerico
    {        
        private ObservableCollection<Usuario> coleccion;
        private bool cargandoBusy;
        private Usuario itemSeleccionado;
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        public ICommand ComandoClickEliminar => new RelayCommand<Object>(ClickEliminar, (o) => { return true; });      
        public ICommand ComandoVentanaCargada => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });
        public ICommand ComandoDobleClick => new RelayCommand<Object>(DobleClick, (o) => { return true; });
       
        private async void VentanaCargada(object obj)
        {                        
            CargandoBusy = true;
            Coleccion = await UsuarioController.Instance.ObtenerTodo();
            CargandoBusy = false;
        }
        private async void ClickEliminar(object obj)
        {
            await UsuarioController.Instance.Eliminar(itemSeleccionado);
            coleccion.Remove(itemSeleccionado);
        }
        private void ClickAgregar(object obj)
        {
            Usuario nuevo = new Usuario();
            AdministradorVentanas.Instance.RegistrarVentana<UsuarioVentana>("0", new UsuarioVentanaVM(nuevo)).Show();            
        }
        public void RefrescarGrid(Usuario nuevo) 
        { //sirve para el refresco desde la otra ventana
            coleccion.Add(nuevo);
        }
        private void DobleClick(object obj)
        {
            if (itemSeleccionado != null)
            {
                AdministradorVentanas.Instance.RegistrarVentana<UsuarioVentana>(itemSeleccionado.Id.ToString(), new UsuarioVentanaVM(itemSeleccionado)).Show();
            }
        }
        public UsuarioUCVM()
        {           
        }
     
        public ObservableCollection<Usuario> Coleccion
        {
            get { return this.coleccion; }
            set { SetValue(ref this.coleccion, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
        public Usuario ItemSeleccionado
        {
            get { return this.itemSeleccionado; }
            set { SetValue(ref this.itemSeleccionado, value); }
        }
        
    }
}
