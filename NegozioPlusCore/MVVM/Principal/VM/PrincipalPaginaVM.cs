using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.Utilitarios;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Principal.VM
{
    class PrincipalPaginaVM : NotificadorGenerico
    {
        private ContentControl pagina;
        private double gridAncho;
        public ObservableCollection<MenuItem> Items { get; set; }      
        public ICommand ComandoClick => new RelayCommand<Object>(MenuItemClick, (o) => { return true; });
        public ICommand ComandoHomeAbierto => new RelayCommand<Object>(HomeAbiertoClick, (o) => { return true; });
        public ICommand ComandoHomeCerrado => new RelayCommand<Object>(HomeCerradoClick, (o) => { return true; });

        public PrincipalPaginaVM()
        {
            Pagina = new ContentControl();
            Items = new ObservableCollection<MenuItem>();
            gridAncho = 280;
            AgregarItems();
            AgregarItems();
            AgregarItems();
        }
        private void HomeAbiertoClick(object obj)
        {
            GridAncho = 280;                        
        }       
        private void HomeCerradoClick(object obj)
        {
            GridAncho = 65;                        
        }
        
        public ContentControl Pagina
        {
            get { return this.pagina; }
            set { SetValue(ref this.pagina, value); }
        }
        
        public double GridAncho
        {            
            get { return this.gridAncho; }
            set { SetValue(ref this.gridAncho, value); }
        }

        private void MenuItemClick(object obj)
        {
            NavigationItemClickedEventArgs item = obj as NavigationItemClickedEventArgs;
            MenuItem mi = item.Item.DataContext as MenuItem;
            //obj?.GetType().Name
            //DataContext es el objeto al cual hace referencia
            if (mi.Item !=null)
            {
                //obtengo el nombre del menu y tengo que buscarlo en el service locator
                //saco el elemento o lo creo, todo ello en el serviceLocator
            }

            if (mi.Item == "Producto")
            {
              
               
                //pagina.Content = new ProductosVM();

                // Pagina.NavigationService.Navigate( new ProductosPagina());
                //Pagina.Navigate(new System.Uri("/Paginas/ProductosPagina.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
           
              
                // pagina.Content = new VentasVM();


                //  Pagina.NavigationService.Navigate(new VentasPagina());
                //Pagina.Navigate(new System.Uri("/Paginas/VentasPagina.xaml",UriKind.RelativeOrAbsolute));
            }

        }


        void AgregarItems()
        {
            MenuItem producto = new MenuItem
            {
                Item = "Producto",
                Icon = "/Recursos/Imagenes/home.png",
                Url = "pagina1"

            };
            ObservableCollection<MenuItem> SubItems = new ObservableCollection<MenuItem>();
            SubItems.Add(new MenuItem() { Item = "item1", Icon = "/Recursos/Imagenes/home.png", Url = "pagina2" });
            producto.SubItems = SubItems;
            Items.Add(producto);
        }
    }
    public class MenuItem
    {
        public ObservableCollection<MenuItem> SubItems { get; set; }
        
        private string url;
        private string item;
        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        private object icon;
        public object Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string Url { get => url; set => url = value; }
    }
}
