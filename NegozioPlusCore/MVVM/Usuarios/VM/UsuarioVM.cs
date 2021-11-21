using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.MVVM.Principal.VM;
using NegozioPlusCore.NucleoRealm.Controladores;
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
    class UsuarioVM : NotificadorGenerico
    {
        private UsuarioVentana usuarioVentanaNuevo;
        private ObservableCollection<UsuarioXAML> coleccion;
        private bool cargandoBusy;
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        public ICommand ComandoVentanaCargada => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });

        private async void VentanaCargada(object obj)
        {
            
            UsuarioController uc = new UsuarioController();
            CargandoBusy = true;
            Coleccion = await uc.ObtenerTodo();
            CargandoBusy = false;
        }

        private void ClickAgregar(object obj)
        {           
            if (usuarioVentanaNuevo == null || usuarioVentanaNuevo.IsClosed)
            {
                usuarioVentanaNuevo = new UsuarioVentana();
            }
            usuarioVentanaNuevo.Show();
        }

        public UsuarioVM()
        {

            Coleccion = new ObservableCollection<UsuarioXAML>();
        }

     
        public ObservableCollection<UsuarioXAML> Coleccion
        {
            get { return this.coleccion; }
            set { SetValue(ref this.coleccion, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
    }
}
