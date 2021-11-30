using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Productos.VM
{
    class ProductoVentanaVM : NotificadorGenerico
    {
        private ObservableCollection<CategoriaProducto> checkListModulos;
        private ObservableCollection<CategoriaProducto> checkListModulosSeleccionados;

        private string descripcion;
        private string nombre;
        private double precio;
        private string unidad;
        private string idRealm;
        private bool habilitado;
        private bool reqAlmacen;
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
                checkListModulosSeleccionados = new ObservableCollection<CategoriaProducto>(CheckListModulos);
                productoRealm.Id = ObjectId.GenerateNewId();
                productoRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                productoRealm.Nombre = nombre;
                productoRealm.Descrip = descripcion;
                productoRealm.Precio = precio;
                productoRealm.Unidad = unidad;
                productoRealm.ReqAlmacen = reqAlmacen;
                productoRealm.Habilitado = habilitado;
                productoRealm.IdCatProd = checkListModulosSeleccionados[0];
                await ProductoController.Instance.Insertar(productoRealm);
                ProductoUCVM UC = ServiceLocator.Instance.GetService<ProductoUC>().DataContext as ProductoUCVM;
                UC.RefrescarGrid(productoRealm);
            }
            else
            {  //modificacion
                checkListModulosSeleccionados = new ObservableCollection<CategoriaProducto>(CheckListModulos);
                Producto usuarioModificado = new Producto();
                usuarioModificado.Nombre = nombre;
                usuarioModificado.Descrip = descripcion;
                usuarioModificado.Precio = precio;
                usuarioModificado.Unidad = unidad;
                usuarioModificado.ReqAlmacen = reqAlmacen;
                usuarioModificado.Habilitado = habilitado;
                usuarioModificado.IdCatProd = checkListModulosSeleccionados[0];
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
        public bool ReqAlmacen
        {
            get { return this.reqAlmacen; }
            set { SetValue(ref this.reqAlmacen, value); }
        }
        public bool Habilitado
        {
            get { return this.habilitado; }
            set { SetValue(ref this.habilitado, value); }
        }
        public ProductoVentanaVM(Producto productoRealm, ObservableCollection<CategoriaProducto> coleccion)
        {
            this.productoRealm = productoRealm;
            CheckListModulos = new ObservableCollection<CategoriaProducto>();
            foreach (var item in coleccion)
            {
                checkListModulos.Add(item);
            }
            if (productoRealm.Id == null)
            {
                //nuevo dato
                idRealm = "0";
                checkListModulosSeleccionados = new ObservableCollection<CategoriaProducto>(CheckListModulos);
            }
            else
            {               
                idRealm = productoRealm.Id.ToString();
                nombre = productoRealm.Nombre;
                precio = (double)productoRealm.Precio;
                unidad = productoRealm.Unidad;
                descripcion = productoRealm.Descrip;
                habilitado = (bool)productoRealm.Habilitado;
                reqAlmacen = (bool)productoRealm.ReqAlmacen;
                checkListModulosSeleccionados = new ObservableCollection<CategoriaProducto>(CheckListModulos);
                //CheckListModulos = new ObservableCollection<CategoriaProducto>(productoRealm.IdCatProd);
            }
        }
        public ProductoVentanaVM()
        {

        }

        public ObservableCollection<CategoriaProducto> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
        public ObservableCollection<CategoriaProducto> CheckListModulosSeleccionados { get => checkListModulosSeleccionados; set => checkListModulosSeleccionados = value; }
    }

}