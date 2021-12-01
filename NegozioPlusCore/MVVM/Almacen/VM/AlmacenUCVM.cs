﻿using Microsoft.Toolkit.Mvvm.Input;
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


namespace NegozioPlusCore.MVVM.Almacen.VM
{
    class AlmacenUCVM : NotificadorGenerico
    {
        private ObservableCollection<NucleoRealm.Modelos.Almacen> coleccion;
        private bool cargandoBusy;
        private NucleoRealm.Modelos.Almacen itemSeleccionado;
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        public ICommand ComandoClickEliminar => new RelayCommand<Object>(ClickEliminar, (o) => { return true; });
        public ICommand ComandoVentanaCargada => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });
        public ICommand ComandoDobleClick => new RelayCommand<Object>(DobleClick, (o) => { return true; });
        private async void VentanaCargada(object obj)
        {
            CargandoBusy = true;
            Coleccion = await AlmacenController.Instance.ObtenerTodo();
            CargandoBusy = false;
        }
        private async void ClickEliminar(object obj)
        {
            //luego creare una ventana personalizada
            MessageBoxResult Result = System.Windows.MessageBox.Show("Estas Seguro de eliminar el almacen", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await AlmacenController.Instance.Eliminar(itemSeleccionado);
                coleccion.Remove(itemSeleccionado);
            }
        }
        private void ClickAgregar(object obj)
        {
            NucleoRealm.Modelos.Almacen nuevo = new NucleoRealm.Modelos.Almacen();
            AlmacenVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<AlmacenVentana>("0", new AlmacenVentanaVM(nuevo));
            ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
            ventana.Show();
        }
        public void RefrescarGrid(NucleoRealm.Modelos.Almacen nuevo)
        { //sirve para el refresco desde la otra ventana
            coleccion.Add(nuevo);
        }
        private void DobleClick(object obj)
        {
            if (itemSeleccionado != null)
            {
                AlmacenVentana ventana = AdministradorVentanas.Instance.RegistrarVentana<AlmacenVentana>(itemSeleccionado.Id.ToString(), new AlmacenVentanaVM(itemSeleccionado));
                ventana.Owner = ServiceLocator.Instance.GetService<VentanaPrincipal>();
                ventana.Show();
            }
        }
        public AlmacenUCVM()
        {
        }

        public ObservableCollection<NucleoRealm.Modelos.Almacen> Coleccion
        {
            get { return this.coleccion; }
            set { SetValue(ref this.coleccion, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
        public NucleoRealm.Modelos.Almacen ItemSeleccionado
        {
            get { return this.itemSeleccionado; }
            set { SetValue(ref this.itemSeleccionado, value); }
        }
    }
}