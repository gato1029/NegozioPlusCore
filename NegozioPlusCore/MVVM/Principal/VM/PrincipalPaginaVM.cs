using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.NucleoRealm;
using NegozioPlusCore.NucleoRealm.Controladores;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.NucleoRealm.ModelosBson;
using NegozioPlusCore.Recursos;
using NegozioPlusCore.Utilitarios;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.ObjectModel;
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
        private Configuracion configuracion;
        private Particion particion;
        private bool cargandoBusy;
        public static event EventHandler<Window> EventoResizarVentana;
        public ObservableCollection<MenuItemParticular> Items { get; set; }      
        public ICommand ComandoClick => new RelayCommand<Object>(MenuItemClick, (o) => { return true; });
        public ICommand ComandoHomeAbierto => new RelayCommand<Object>(HomeAbiertoClick, (o) => { return true; });
        public ICommand ComandoHomeCerrado => new RelayCommand<Object>(HomeCerradoClick, (o) => { return true; });
        public ICommand ComandoVentanaCambioTam => new RelayCommand<Object>(VentanaCambioTam, (o) => { return true; });

        public ICommand ComandoVentanaAparece => new RelayCommand<Object>(VentanaCargada, (o) => { return true; });

        public ICommand ComandoClickSalir => new RelayCommand<Window>(SalirClick, (o) => { return true; });

        private async void SalirClick(Window obj)
        {
            configuracion.CerrarParticiones();
            CargandoBusy = true;
            await configuracion.UsuarioRealm.LogOutAsync();
            CargandoBusy = false;
            obj.Close();
        }

        private async void VentanaCargada(object obj)
        {
            CargandoBusy = true;
            await Conectar();
            var usuarioData = ServiceLocator.Instance.GetService<UsuarioLogeado>();
            NucleoRealm.Modelos.Empresa emp = await EmpresaController.Instance.BuscarUno(usuarioData.idEmp.Value);
            ServiceLocator.Instance.RegisterService(emp);
            CargandoBusy = false;
        }

        public PrincipalPaginaVM()
        {
            controlSeleccionado = new ContentControl();
            Items = new ObservableCollection<MenuItemParticular>();
            objetosMenu = ObjetosMenu.Instancia;
            foreach (var item in objetosMenu.DiccionarioMenu)
            {
                Items.Add(item.Value);
            }
            gridAncho = 290;
            configuracion = Configuracion.Instanciar();                       
        }

        private async Task Conectar()
        {
            UsuarioLogeado usuarioLogeado = ServiceLocator.Instance.GetService<UsuarioLogeado>();
            particion = configuracion.InstanciarParticion(usuarioLogeado.particion);
            await particion.ConectarParticion();            
        }
        private void HomeAbiertoClick(object obj)
        {
            GridAncho = 290;                        
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
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
        public double GridAncho
        {            
            get { return this.gridAncho; }
            set { SetValue(ref this.gridAncho, value); }
        }
        private void VentanaCambioTam(object obj)
        {
            EventoResizarVentana?.Invoke(this,ServiceLocator.Instance.GetService<Window>());
        }   
        private  void MenuItemClick(object obj)
        {
            NavigationItemClickedEventArgs item = obj as NavigationItemClickedEventArgs;
            if (item!=null)
            {
                MenuItemParticular mi = item.Item.DataContext as MenuItemParticular;
                if (mi!=null)
                {
                    //obj?.GetType().Name
                    //DataContext es el objeto al cual hace referencia
                    if (mi.Item != null)
                    {                        
                        ControlSeleccionado.Content = objetosMenu.ItemMenuControl(mi.Item);
                    }
                }
               
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
