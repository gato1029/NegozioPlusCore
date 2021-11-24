using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.NucleoRealm.Controladores;

namespace NegozioPlusCore.MVVM.Tiendas.VM
{
    class TiendasVentanaVM : NotificadorGenerico
    {
        private ObservableCollection<String> checkListModulos;
        private ObservableCollection<ModulosUsuario> checkListModulosSeleccionados; 

        private string direccion;
        private string nombre;
        private double latitud;
        private double longitud;
        private string idRealm;
        private Tienda tiendaRealm;
        public ICommand ComandoClickGuardar => new RelayCommand<Window>(ClickGuardar, (o) => { return true; });
        public ICommand ComandoClickCerrar => new RelayCommand<Object>(ClickCerrar, (o) => { return true; });

        private void ClickCerrar(object obj)
        {
            AdministradorVentanas.Instance.EliminarVentana<TiendasVentana>(idRealm);
        }

        private async void ClickGuardar(Window obj)
        {
            if (tiendaRealm.Id == null) // indica que es nuevo
            {
                tiendaRealm.Id = ObjectId.GenerateNewId();
                tiendaRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                tiendaRealm.Nombre = nombre;
                tiendaRealm.Direccion = direccion;
                tiendaRealm.Latitud = latitud;
                tiendaRealm.Longitud = longitud;
                await TiendaController.Instance.Insertar(tiendaRealm);
                TiendasUCVM UC = ServiceLocator.Instance.GetService<TiendasUC>().DataContext as TiendasUCVM;
                UC.RefrescarGrid(tiendaRealm);
            }
            else
            {  //modificacion
                Tienda usuarioModificado = new Tienda();
                usuarioModificado.Nombre = nombre;
                usuarioModificado.Direccion = direccion;
                usuarioModificado.Latitud = latitud;
                usuarioModificado.Longitud = longitud;
                await TiendaController.Instance.Modificar(tiendaRealm.Id.Value, usuarioModificado);
            }
            obj.Close();
            AdministradorVentanas.Instance.EliminarVentana<TiendasVentana>(idRealm);

            //foreach (var item in CheckListModulosSeleccionados)
            //{
            //    MessageBox.Show(item.Nombre);
            //}            
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { SetValue(ref this.direccion, value); }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public double Latitud
        {
            get { return this.latitud; }
            set { SetValue(ref this.latitud, value); }
        }
        public double Longitud
        {
            get { return this.longitud; }
            set { SetValue(ref this.longitud, value); }
        }

        public TiendasVentanaVM(Tienda tiendaRealm)
        {
            this.tiendaRealm = tiendaRealm;
            if (tiendaRealm.Id == null)
            {
                //nuevo dato
                idRealm = "0";
            }
            else
            {
                idRealm = tiendaRealm.Id.ToString();
                nombre = tiendaRealm.Nombre;
                direccion = tiendaRealm.Direccion;
                longitud = (double)tiendaRealm.Longitud;
                latitud = (double)tiendaRealm.Latitud;
                CheckListModulos = new ObservableCollection<string>(tiendaRealm.Usuarios);
            }
        }
        public TiendasVentanaVM()
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

