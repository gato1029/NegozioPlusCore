using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.ObjectModel;
using System.Windows;
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
            //luego creare una ventana personalizada
            MessageBoxResult Result = System.Windows.MessageBox.Show("Estas Seguro de eliminar el usuario","Advertencia",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await UsuarioController.Instance.Eliminar(itemSeleccionado);
                coleccion.Remove(itemSeleccionado);
            }            
        }
        private void ClickAgregar(object obj)
        {
            Usuario nuevo = new Usuario();
            UsuarioVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<UsuarioVentana>("0", new UsuarioVentanaVM(nuevo));
            ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
            ventana.Show();
        }
        public void RefrescarGrid(Usuario nuevo) 
        { //sirve para el refresco desde la otra ventana
            coleccion.Add(nuevo);
        }
        private void DobleClick(object obj)
        {
            if (itemSeleccionado != null)
            {
                UsuarioVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<UsuarioVentana>(itemSeleccionado.Id.ToString(), new UsuarioVentanaVM(itemSeleccionado));
                ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
                ventana.Show();
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
