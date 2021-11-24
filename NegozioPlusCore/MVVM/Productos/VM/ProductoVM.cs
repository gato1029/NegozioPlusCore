using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.MVVM.Principal.VM;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;


namespace NegozioPlusCore.MVVM.Productos.VM
{
    class ProductoVM : NotificadorGenerico
    {
        //private UsuarioVentana usuarioVentanaNuevo;
        private double altoGridDatos;
        public ObservableCollection<ProductoXAML> Coleccion { get; set; }
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });

        private void ClickAgregar(object obj)
        {
            /*
            if (usuarioVentanaNuevo == null || usuarioVentanaNuevo.IsClosed)
            {
                usuarioVentanaNuevo = new UsuarioVentana();
            }
            usuarioVentanaNuevo.Show();
            */
        }

        public ProductoVM()
        {
            PrincipalPaginaVM.EventoResizarVentana += PrincipalPaginaVM_EventoResizarVentana;
            Coleccion = new ObservableCollection<ProductoXAML>();
            Coleccion.Add(new ProductoXAML("1hvh123v","leche", "12"));
            Coleccion.Add(new ProductoXAML("2213123v", "agua", "10"));
            Coleccion.Add(new ProductoXAML("3h123v", "malta", "9"));
            Coleccion.Add(new ProductoXAML("4hvh123v", "harina", "2"));

        }
        private void PrincipalPaginaVM_EventoResizarVentana(object sender, Window e)
        {
            AltoGridDatos = e.Height - 220;

        }

        public double AltoGridDatos
        {
            get { return this.altoGridDatos; }
            set { SetValue(ref this.altoGridDatos, value); }
        }
    }
}
