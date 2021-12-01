using NegozioPlusCore.MVVM.Almacen;
using NegozioPlusCore.MVVM.Categorias;
using NegozioPlusCore.MVVM.Empresa;
using NegozioPlusCore.MVVM.Principal.VM;
using NegozioPlusCore.MVVM.Productos;
using NegozioPlusCore.MVVM.Tiendas;
using NegozioPlusCore.MVVM.Usuarios;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NegozioPlusCore.Recursos
{
    class ObjetosMenu
    {
        public static ObjetosMenu Instancia => _instancia ?? (_instancia = new ObjetosMenu());

        public Dictionary<string, MenuItemParticular> DiccionarioMenu => _diccionarioMenu;

        private static ObjetosMenu _instancia;

        private readonly Dictionary<String, MenuItemParticular> _diccionarioMenu;
        private readonly Dictionary<String, MenuItemParticular> _diccionarioSubMenu;

        public ObjetosMenu()
        {
            _diccionarioMenu = new Dictionary<String, MenuItemParticular>();
            _diccionarioSubMenu = new Dictionary<string, MenuItemParticular>();
            CargarItems();
        }

        private void CargarItems()
        {
            AgregarItemMenu("Empresa", "/Recursos/Imagenes/home.png");
            AgregarItemMenu("Productos", "/Recursos/Imagenes/productos.png");
            AgregarItemMenu("Almacen", "/Recursos/Imagenes/almacen.png");
            AgregarItemMenu("Comprobantes", "/Recursos/Imagenes/comprobantes.png");
            AgregarItemMenu("Usuarios", "/Recursos/Imagenes/users.png");
            AgregarItemMenu("Sunat", "/Recursos/Imagenes/home.png");
            AgregarItemMenu("Tiendas", "/Recursos/Imagenes/tiendas.png");            
            AgregarSubItemMenu("Productos", "Categorias", "/Recursos/Imagenes/home.png");
            AgregarSubItemMenu("Comprobantes", "Tickets", "/Recursos/Imagenes/comprobantes.png");
            AgregarSubItemMenu("Comprobantes", "Boletas", "/Recursos/Imagenes/comprobantes.png");
            AgregarSubItemMenu("Comprobantes", "Facturas", "/Recursos/Imagenes/comprobantes.png");
        }

        public void AgregarItemMenu(string itemMenu, object icono)
        {
            if (!DiccionarioMenu.ContainsKey(itemMenu))
            {
                MenuItemParticular menuItem = new MenuItemParticular(itemMenu, icono);
                DiccionarioMenu.Add(itemMenu, menuItem);                
            }
        }
        public void AgregarSubItemMenu(string itemMenuPadre, string subMenuItem, object icono)
        {
            if (DiccionarioMenu.ContainsKey(itemMenuPadre))
            {
                MenuItemParticular menuPadre = DiccionarioMenu[itemMenuPadre];
                ObservableCollection<MenuItemParticular> subMenu = menuPadre.SubItems;
                MenuItemParticular menuItem = new MenuItemParticular(subMenuItem, icono);
                if (subMenu == null)
                {
                    subMenu = new ObservableCollection<MenuItemParticular>();
                    subMenu.Add(menuItem);
                    menuPadre.SubItems = subMenu;
                    _diccionarioSubMenu.Add(subMenuItem, menuItem);
                    return;
                }                
                if (!subMenu.Contains(menuItem))
                {
                    subMenu.Add(menuItem);
                    _diccionarioSubMenu.Add(subMenuItem, menuItem);
                }                                                  
            }
        }
        public Object ItemMenuControl(string itemMenu)
        {
            if (DiccionarioMenu.ContainsKey(itemMenu))
            {
                switch (itemMenu)
                {
                    case "Empresa":
                        if (!ServiceLocator.Instance.ExistService<EmpresaUC>())
                        {
                            ServiceLocator.Instance.RegisterService(new EmpresaUC());
                        }
                        return ServiceLocator.Instance.GetService<EmpresaUC>();
                    case "Usuarios":
                        if (!ServiceLocator.Instance.ExistService<UsuarioUC>())
                        {
                            ServiceLocator.Instance.RegisterService(new UsuarioUC());                            
                        }
                        return ServiceLocator.Instance.GetService<UsuarioUC>();
                    case "Almacen":
                        if (!ServiceLocator.Instance.ExistService<Almacen>())
                        {
                            ServiceLocator.Instance.RegisterService(new Almacen());
                        }
                        return ServiceLocator.Instance.GetService<Almacen>();
                    case "Productos":
                        if (!ServiceLocator.Instance.ExistService<Producto>())
                        {
                            ServiceLocator.Instance.RegisterService(new Producto());
                        }
                        return ServiceLocator.Instance.GetService<Producto>();
                    case "Tiendas":
                        if (!ServiceLocator.Instance.ExistService<Tiendas>())
                        {
                            ServiceLocator.Instance.RegisterService(new Tiendas());
                        }
                        return ServiceLocator.Instance.GetService<Tiendas>();
                    default:
                        break;
                }
            }
            if (_diccionarioSubMenu.ContainsKey(itemMenu))
            {
                switch (itemMenu)
                {
                    case "Categorias":
                        if (!ServiceLocator.Instance.ExistService<Categorias>())
                        {
                            ServiceLocator.Instance.RegisterService(new Categorias());
                        }
                        return ServiceLocator.Instance.GetService<Categorias>();
                    default:
                        break;
                }
            }
                return null;
        }
        public MenuItemParticular ItemMenu(string itemMenu)
        {
            if (DiccionarioMenu.ContainsKey(itemMenu))
            {
                return DiccionarioMenu[itemMenu];
            }
            return null;
        }        
    }
}
