using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
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
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Almacen.VM
{
    class AlmacenVentanaVM : NotificadorGenerico
    {
        private string nombre;
        private string direccion;
        private string latitud;
        private string longitud;
        private string idRealm;
        private NucleoRealm.Modelos.Almacen almacenRealm;
        public ICommand ComandoClickGuardar => new RelayCommand<Window>(ClickGuardar, (o) => { return true; });
        public ICommand ComandoClickCerrar => new RelayCommand<Object>(ClickCerrar, (o) => { return true; });
        private void ClickCerrar(object obj)
        {
            AdministradorVentanas.Instance.EliminarVentana<AlmacenVentana>(idRealm);
        }
        private async void ClickGuardar(Window obj)
        {
            if (almacenRealm.Id == null) // indica que es nuevo
            {
                almacenRealm.Id = ObjectId.GenerateNewId();
                almacenRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                almacenRealm.Nombre = nombre;
                almacenRealm.Direccion = direccion;
                almacenRealm.Latitud = latitud;
                almacenRealm.Longitud = longitud;
                await AlmacenController.Instance.Insertar(almacenRealm);
                AlmacenUCVM UC = ServiceLocator.Instance.GetService<AlmacenUC>().DataContext as AlmacenUCVM;
                UC.RefrescarGrid(almacenRealm);
            }
            else
            {  //modificacion
                NucleoRealm.Modelos.Almacen almacenModificado = new NucleoRealm.Modelos.Almacen();
                almacenModificado.Nombre = nombre;
                almacenModificado.Direccion = direccion;
                almacenModificado.Latitud = latitud;
                almacenModificado.Longitud = longitud;
                await AlmacenController.Instance.Modificar(almacenRealm.Id.Value, almacenModificado);
            }
            obj.Close();
            AdministradorVentanas.Instance.EliminarVentana<AlmacenVentana>(idRealm);

            //foreach (var item in CheckListModulosSeleccionados)
            //{
            //    MessageBox.Show(item.Nombre);
            //}            
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { SetValue(ref this.direccion, value); }
        }
        public string Longitud
        {
            get { return this.longitud; }
            set { SetValue(ref this.longitud, value); }
        }
        public string Latitud
        {
            get { return this.latitud; }
            set { SetValue(ref this.latitud, value); }
        }
        public AlmacenVentanaVM(NucleoRealm.Modelos.Almacen almacenRealm)
        {
            this.almacenRealm = almacenRealm;
            if (almacenRealm.Id == null)
            {
                //nuevo dato
                idRealm = "0";
            }
            else
            {
                idRealm = almacenRealm.Id.ToString();
                nombre = almacenRealm.Nombre;
                direccion = almacenRealm.Direccion;
                latitud = almacenRealm.Latitud;
                longitud = almacenRealm.Longitud;               
            }
        }
        public AlmacenVentanaVM()
        {

        }      
    }
}
