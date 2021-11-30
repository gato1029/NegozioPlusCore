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
        private Visibility subCatVisible;
        private ObservableCollection<String> checkListModulos;
        private ObservableCollection<String> checkListModulosSeleccionados;
        //private ObservableCollection<CategoriaProducto> coleccion;

        private string nombre;
        private string padre;
        private string idRealm;
        private CategoriaProducto categoriaProductoRealm;

        public ICommand ComandoClickGuardar => new RelayCommand<Window>(ClickGuardar, (o) => { return true; });
        public ICommand ComandoClickCerrar => new RelayCommand<Object>(ClickCerrar, (o) => { return true; });

        private void ClickCerrar(object obj)
        {
            AdministradorVentanas.Instance.EliminarVentana<CategoriasVentana>(idRealm);
        }

        private async void ClickGuardar(Window obj)
        {
            if (categoriaProductoRealm.Id == null) // indica que es nuevo
            {
                categoriaProductoRealm.Id = ObjectId.GenerateNewId();
                categoriaProductoRealm.IdEmp = ServiceLocator.Instance.GetService<Empresa>().Id;
                categoriaProductoRealm.Nombre = nombre;
                await CategoriaProductoController.Instance.Insertar(categoriaProductoRealm);
                CategoriasUCVM UC = ServiceLocator.Instance.GetService<CategoriasUC>().DataContext as CategoriasUCVM;
                UC.RefrescarGrid(categoriaProductoRealm);
            }
            else
            {  //modificacion
                CategoriaProducto usuarioModificado = new CategoriaProducto();
                usuarioModificado.Nombre = nombre;
                await CategoriaProductoController.Instance.Modificar(categoriaProductoRealm.Id.Value, usuarioModificado);
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

        public CategoriasVentanaVM(CategoriaProducto categoriaProductoRealm)
        {
            this.categoriaProductoRealm = categoriaProductoRealm;
            
            if (categoriaProductoRealm.Id == null)
            {
                //nuevo dato      
                idRealm = "0";
                subCatVisible = Visibility.Hidden;
                /*CheckListModulos = new ObservableCollection<String>();
                checkListModulos.Add("Categoria Padre");
                foreach (var item in coleccion)
                {
                    if (item.Padre == "/") 
                    {
                        checkListModulos.Add(item.Nombre);
                    }
                    else
                    {
                        checkListModulos.Add(item.Padre);
                    }
                }*/
            }
            else
            {
                idRealm = categoriaProductoRealm.Id.ToString();
                //nombre = categoriaProductoRealm.Nombre;
                padre = categoriaProductoRealm.Padre;
            }
        }
        public CategoriasVentanaVM()
        {

        }

        public ObservableCollection<String> CheckListModulos { get => checkListModulos; set => checkListModulos = value; }
        public ObservableCollection<String> CheckListModulosSeleccionados { get => checkListModulosSeleccionados; set => checkListModulosSeleccionados = value; }
        public Visibility SubCatVisible
        {
            get { return this.subCatVisible; }
            set { SetValue(ref this.subCatVisible, value); }
        }

    }
}
