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

namespace NegozioPlusCore.MVVM.Tiendas.VM
{
    class TiendasUCVM : NotificadorGenerico
    {
        private ObservableCollection<Tienda> coleccion;
        private bool cargandoBusy;
        private Tienda itemSeleccionado;
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        public ICommand ComandoClickEliminar => new RelayCommand<Object>(ClickEliminar, (o) => { return true; });
        public ICommand ComandoVentanaCargada => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });
        public ICommand ComandoDobleClick => new RelayCommand<Object>(DobleClick, (o) => { return true; });

        private async void VentanaCargada(object obj)
        {
            CargandoBusy = true;
            Coleccion = await TiendaController.Instance.ObtenerTodo();
            CargandoBusy = false;
        }
        private async void ClickEliminar(object obj)
        {
            //luego creare una ventana personalizada
            MessageBoxResult Result = System.Windows.MessageBox.Show("Estas Seguro de eliminar la tienda", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await TiendaController.Instance.Eliminar(itemSeleccionado);
                coleccion.Remove(itemSeleccionado);
            }
        }
        private void ClickAgregar(object obj)
        {
            Tienda nuevo = new Tienda();
            TiendasVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<TiendasVentana>("0", new TiendasVentanaVM(nuevo));
            ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
            ventana.Show();
        }
        public void RefrescarGrid(Tienda nuevo)
        { //sirve para el refresco desde la otra ventana
            coleccion.Add(nuevo);
        }
        private void DobleClick(object obj)
        {
            if (itemSeleccionado != null)
            {
                TiendasVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<TiendasVentana>(itemSeleccionado.Id.ToString(), new TiendasVentanaVM(itemSeleccionado));
                ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
                ventana.Show();
            }
        }
        public TiendasUCVM()
        {
        }

        public ObservableCollection<Tienda> Coleccion
        {
            get { return this.coleccion; }
            set { SetValue(ref this.coleccion, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
        public Tienda ItemSeleccionado
        {
            get { return this.itemSeleccionado; }
            set { SetValue(ref this.itemSeleccionado, value); }
        }

    }
}
