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


namespace NegozioPlusCore.MVVM.Productos.VM
{
    class ProductoUCVM : NotificadorGenerico
    {
        private ObservableCollection<Producto> coleccion;
        private bool cargandoBusy;
        private Producto itemSeleccionado;
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        public ICommand ComandoClickEliminar => new RelayCommand<Object>(ClickEliminar, (o) => { return true; });
        public ICommand ComandoVentanaCargada => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });
        public ICommand ComandoDobleClick => new RelayCommand<Object>(DobleClick, (o) => { return true; });

        private async void VentanaCargada(object obj)
        {
            CargandoBusy = true;
            Coleccion = await ProductoController.Instance.ObtenerTodo();
            CargandoBusy = false;
        }
        private async void ClickEliminar(object obj)
        {
            //luego creare una ventana personalizada
            MessageBoxResult Result = System.Windows.MessageBox.Show("Estas Seguro de eliminar el producto", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await ProductoController.Instance.Eliminar(itemSeleccionado);
                coleccion.Remove(itemSeleccionado);
            }
        }
        private void ClickAgregar(object obj)
        {
            Producto nuevo = new Producto();
            ProductoVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<ProductoVentana>("0", new ProductoVentanaVM(nuevo));
            ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
            ventana.Show();
        }
        public void RefrescarGrid(Producto nuevo)
        { //sirve para el refresco desde la otra ventana
            coleccion.Add(nuevo);
        }
        private void DobleClick(object obj)
        {
            if (itemSeleccionado != null)
            {
                ProductoVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<ProductoVentana>(itemSeleccionado.Id.ToString(), new ProductoVentanaVM(itemSeleccionado));
                ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
                ventana.Show();
            }
        }
        public ProductoUCVM()
        {
        }

        public ObservableCollection<Producto> Coleccion
        {
            get { return this.coleccion; }
            set { SetValue(ref this.coleccion, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
        public Producto ItemSeleccionado
        {
            get { return this.itemSeleccionado; }
            set { SetValue(ref this.itemSeleccionado, value); }
        }

    }
}
