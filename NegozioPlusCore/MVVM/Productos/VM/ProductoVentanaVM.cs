using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Productos.VM
{
    class ProductoVentanaVM : NotificadorGenerico
    {
        //private ObservableCollection<String> checkListModulos;
        //private ObservableCollection<ModulosUsuario> checkListModulosSeleccionados;

        private string descripcion;
        private string nombre;
        private double precio;
        private string unidad;
        private string idRealm;
        private Producto productoRealm;
        public ICommand ComandoClickGuardar => new RelayCommand<Window>(ClickGuardar, (o) => { return true; });
        public ICommand ComandoClickCerrar => new RelayCommand<Object>(ClickCerrar, (o) => { return true; });

        private void ClickCerrar(object obj)
        {
            AdministradorVentanas.Instance.EliminarVentana<ProductoVentana>(idRealm);
        }

        private async void ClickGuardar(Window obj)
        {
            if (productoRealm.Id == null) // indica que es nuevo
            {
                productoRealm.Id = ObjectId.GenerateNewId();
                productoRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                productoRealm.Nombre = nombre;
                productoRealm.Descrip = descripcion;
                productoRealm.Precio = precio;
                productoRealm.Unidad = unidad;
                await ProductoController.Instance.Insertar(productoRealm);
                ProductoUCVM UC = ServiceLocator.Instance.GetService<ProductoUC>().DataContext as ProductoUCVM;
                UC.RefrescarGrid(productoRealm);
            }
            else
            {  //modificacion
                Producto usuarioModificado = new Producto();
                usuarioModificado.Nombre = nombre;
                usuarioModificado.Descrip = descripcion;
                usuarioModificado.Precio = precio;
                usuarioModificado.Unidad = unidad;
                await ProductoController.Instance.Modificar(productoRealm.Id.Value, usuarioModificado);
            }
            obj.Close();
            AdministradorVentanas.Instance.EliminarVentana<ProductoVentana>(idRealm);

            //foreach (var item in CheckListModulosSeleccionados)
            //{
            //    MessageBox.Show(item.Nombre);
            //}            
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { SetValue(ref this.descripcion, value); }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        
        public string Unidad
        {
            get { return this.unidad; }
            set { SetValue(ref this.unidad, value); }
        }
        public double Precio
        {
            get { return this.precio; }
            set { SetValue(ref this.precio, value); }
        }
        public ProductoVentanaVM(Producto productoRealm)
        {
            this.productoRealm = productoRealm;
            if (productoRealm.Id == null)
            {
                //nuevo dato
                idRealm = "0";
            }
            else
            {
                idRealm = productoRealm.Id.ToString();
                nombre = productoRealm.Nombre;
                precio = (double)productoRealm.Precio;
                unidad = productoRealm.Unidad;
                descripcion = productoRealm.Descrip;

                //CheckListModulos = new ObservableCollection<string>(productoRealm.Modulos);
            }
        }
        public ProductoVentanaVM()
        {

        }

        //public ObservableCollection<String> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
        //public ObservableCollection<ModulosUsuario> CheckListModulosSeleccionados { get => checkListModulosSeleccionados; set => checkListModulosSeleccionados = value; }
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