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

namespace NegozioPlusCore.MVVM.Categorias.VM
{
    class CategoriasUCVM : NotificadorGenerico
    {
        private ObservableCollection<CategoriaProducto> coleccion;       

        private bool cargandoBusy;
        private CategoriaProducto itemSeleccionado;
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        public ICommand ComandoClickEliminar => new RelayCommand<Object>(ClickEliminar, (o) => { return true; });
        public ICommand ComandoVentanaCargada => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });
        public ICommand ComandoDobleClick => new RelayCommand<Object>(DobleClick, (o) => { return true; });

        private async void VentanaCargada(object obj)
        {
            CargandoBusy = true;
            Coleccion = await CategoriaProductoController.Instance.ObtenerTodo();
            CargandoBusy = false;
        }
        private async void ClickEliminar(object obj)
        {
            //luego creare una ventana personalizada
            MessageBoxResult Result = System.Windows.MessageBox.Show("Estas Seguro de eliminar la categoria", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                int index = Coleccion.IndexOf(itemSeleccionado);
                //coleccion.Remove(itemSeleccionado);
                await CategoriaProductoController.Instance.Eliminar(itemSeleccionado);
                coleccion.RemoveAt(index);   
            }
        }
        private void ClickAgregar(object obj)
        {
            CategoriaProducto nuevo = new CategoriaProducto();
            CategoriasVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<CategoriasVentana>("0", new CategoriasVentanaVM(nuevo));
            ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
            ventana.Show();
        }
        public void RefrescarGrid(CategoriaProducto nuevo)
        { //sirve para el refresco desde la otra ventanaxd
            coleccion.Add(nuevo);
        }
        private void DobleClick(object obj)
        {
            if (itemSeleccionado != null)
            {
                CategoriasVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<CategoriasVentana>(itemSeleccionado.Id.ToString(), new CategoriasVentanaVM(itemSeleccionado));
                ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
                ventana.Show();
            }
        }
        public CategoriasUCVM()
        {
        }

        public ObservableCollection<CategoriaProducto> Coleccion
        {
            get { return this.coleccion; }
            set { SetValue(ref this.coleccion, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
        public CategoriaProducto ItemSeleccionado
        {
            get { return this.itemSeleccionado; }
            set { SetValue(ref this.itemSeleccionado, value); }
        }
        
    }
}

