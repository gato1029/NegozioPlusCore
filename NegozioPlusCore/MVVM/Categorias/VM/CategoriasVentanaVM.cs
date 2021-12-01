using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Categorias.VM
{
    class CategoriasVentanaVM : NotificadorGenerico
    {
        private Visibility subCatVisible = Visibility.Hidden;
        private Visibility botonSubCatVisible;
        private bool catPadreHabilitar = false;

        private string nombre;
        private string padre;
        private string categoria;
        private string idRealm;
        private string subCatNombre;
        private CategoriaProducto categoriaProductoRealm;

        public ICommand ComandoClickAgregarSubCategoria => new RelayCommand<Object>(ClickAgregarSubCategoria, (o) => { return true; });
        public ICommand ComandoClickGuardar => new RelayCommand<Window>(ClickGuardar, (o) => { return true; });
        public ICommand ComandoClickCerrar => new RelayCommand<Object>(ClickCerrar, (o) => { return true; });

        private void ClickCerrar(object obj)
        {
            AdministradorVentanas.Instance.EliminarVentana<CategoriasVentana>(idRealm);
        }

        private void ClickAgregarSubCategoria(object obj)
        {
            SubCatVisible = Visibility.Visible;
            CatPadreHabilitar = true;
        }

        private async void ClickGuardar(Window obj)
        {
            if (categoriaProductoRealm.Id == null) // indica que es nuevo
            {
                categoriaProductoRealm.Id = ObjectId.GenerateNewId();
                categoriaProductoRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                categoriaProductoRealm.Nombre = nombre;
                categoriaProductoRealm.Padre = "/";
                categoriaProductoRealm.Categoria = "/" + nombre;
                await CategoriaProductoController.Instance.Insertar(categoriaProductoRealm);
                CategoriasUCVM UC = ServiceLocator.Instance.GetService<CategoriasUC>().DataContext as CategoriasUCVM;
                UC.RefrescarGrid(categoriaProductoRealm);
            }
            else
            {
                if (catPadreHabilitar)
                {
                    categoriaProductoRealm = new CategoriaProducto();
                    categoriaProductoRealm.Id = ObjectId.GenerateNewId();
                    categoriaProductoRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                    categoriaProductoRealm.Nombre = subCatNombre;
                    categoriaProductoRealm.Padre = categoria;
                    categoriaProductoRealm.Categoria = categoria + "/" + subCatNombre;
                    await CategoriaProductoController.Instance.Insertar(categoriaProductoRealm);
                    CategoriasUCVM UC = ServiceLocator.Instance.GetService<CategoriasUC>().DataContext as CategoriasUCVM;
                    UC.RefrescarGrid(categoriaProductoRealm);
                }
                else
                {
                    //modificacion
                    CategoriaProducto usuarioModificado = new CategoriaProducto();
                    usuarioModificado.Nombre = nombre;
                    //usuarioModificado.Padre = "/";
                    //usuarioModificado.Categoria = "/" + nombre;
                    await CategoriaProductoController.Instance.Modificar(categoriaProductoRealm.Id.Value, usuarioModificado);
                }   
            }
            obj.Close();
            AdministradorVentanas.Instance.EliminarVentana<CategoriasVentana>(idRealm);

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
        public string Padre
        {
            get { return this.padre; }
            set { SetValue(ref this.padre, value); }
        }
        public string Categoria
        {
            get { return this.categoria; }
            set { SetValue(ref this.categoria, value); }
        }
        public string SubCatNombre
        {
            get { return this.subCatNombre; }
            set { SetValue(ref this.subCatNombre, value); }
        }

        public CategoriasVentanaVM(CategoriaProducto categoriaProductoRealm)
        {
            this.categoriaProductoRealm = categoriaProductoRealm;

            if (categoriaProductoRealm.Id == null)
            {
                //nuevo dato      
                idRealm = "0";
                botonSubCatVisible = Visibility.Hidden;
            }
            else
            {
                idRealm = categoriaProductoRealm.Id.ToString();
                nombre = categoriaProductoRealm.Nombre;
                padre = categoriaProductoRealm.Padre;
                categoria = categoriaProductoRealm.Categoria;
                botonSubCatVisible = Visibility.Visible;
            }
        }
        public CategoriasVentanaVM()
        {

        }

        public Visibility SubCatVisible
        {
            get { return this.subCatVisible; }
            set { SetValue(ref this.subCatVisible, value); }
        }
        public Visibility BotonSubCatVisible
        {
            get { return this.botonSubCatVisible; }
            set { SetValue(ref this.botonSubCatVisible, value); }
        }
        public bool CatPadreHabilitar
        {
            get { return this.catPadreHabilitar; }
            set { SetValue(ref this.catPadreHabilitar, value); }
        }
    }
}
