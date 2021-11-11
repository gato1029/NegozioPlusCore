using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.Recursos;
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
        private ObjetosMenu objetosMenu;
        private ContentControl controlSeleccionado;
        private double gridAncho;
        public ObservableCollection<MenuItemParticular> Items { get; set; }      
        public ICommand ComandoClick => new RelayCommand<Object>(MenuItemClick, (o) => { return true; });
        public ICommand ComandoHomeAbierto => new RelayCommand<Object>(HomeAbiertoClick, (o) => { return true; });
        public ICommand ComandoHomeCerrado => new RelayCommand<Object>(HomeCerradoClick, (o) => { return true; });

        public PrincipalPaginaVM()
        {
            controlSeleccionado = new ContentControl();
            Items = new ObservableCollection<MenuItemParticular>();
            objetosMenu = ObjetosMenu.Instancia;
            foreach (var item in objetosMenu.DiccionarioMenu)
            {
                Items.Add(item.Value);
            }

            gridAncho = 280;                        
        }
        private void HomeAbiertoClick(object obj)
        {
            GridAncho = 280;                        
        }       
        private void HomeCerradoClick(object obj)
        {
            GridAncho = 80;                        
        }
        
        public ContentControl ControlSeleccionado
        {
            get { return this.controlSeleccionado; }
            set { SetValue(ref this.controlSeleccionado, value); }
        }
        
        public double GridAncho
        {            
            get { return this.gridAncho; }
            set { SetValue(ref this.gridAncho, value); }
        }

        private void MenuItemClick(object obj)
        {
            NavigationItemClickedEventArgs item = obj as NavigationItemClickedEventArgs;
            MenuItemParticular mi = item.Item.DataContext as MenuItemParticular;
            //obj?.GetType().Name
            //DataContext es el objeto al cual hace referencia
            if (mi.Item !=null)
            {
                ControlSeleccionado.Content = objetosMenu.ItemMenuControl(mi.Item);
            }      
        } 
    }
    public class MenuItemParticular
    {
        public ObservableCollection<MenuItemParticular> SubItems { get; set; }
        private string item;
        private object icon;

        public MenuItemParticular()
        {

        }

        public MenuItemParticular(string item, object icon)
        {
            this.item = item;
            this.icon = icon;
          
        }

        
        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        
        public object Icon
        {
            get { return icon; }
            set { icon = value; }
        }
    }
}
