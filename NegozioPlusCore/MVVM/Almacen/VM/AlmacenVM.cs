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


namespace NegozioPlusCore.MVVM.Almacen.VM
{
    class AlmacenVM : NotificadorGenerico
    {
        //private UsuarioVentana usuarioVentanaNuevo;
        private double altoGridDatos;
        public ObservableCollection<AlmacenXAML> Coleccion { get; set; }
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

        public AlmacenVM()
        {
            PrincipalPaginaVM.EventoResizarVentana += PrincipalPaginaVM_EventoResizarVentana;
            Coleccion = new ObservableCollection<AlmacenXAML>();
            Coleccion.Add(new AlmacenXAML("Tiendita de Don Pepe", "Avenida Siempre Viva #45"));
            Coleccion.Add(new AlmacenXAML("Gatitos Shop", "Avenida Los Inkas #45"));

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
