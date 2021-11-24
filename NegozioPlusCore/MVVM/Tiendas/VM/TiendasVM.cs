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

namespace NegozioPlusCore.MVVM.Tiendas.VM
{
    class TiendasVM : NotificadorGenerico
    {
        private TiendasAgregar tiendasAgregarNuevo;
        private double altoGridDatos;
        public ObservableCollection<TiendasXAML> Coleccion { get; set; }
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });

        private void ClickAgregar(object obj)
        {
            
            if (tiendasAgregarNuevo == null || tiendasAgregarNuevo.IsClosed)
            {
                tiendasAgregarNuevo = new TiendasAgregar();
            }
            tiendasAgregarNuevo.Show();
            
        }

        public TiendasVM()
        {
            PrincipalPaginaVM.EventoResizarVentana += PrincipalPaginaVM_EventoResizarVentana;
            Coleccion = new ObservableCollection<TiendasXAML>();
            Coleccion.Add(new TiendasXAML("Tienda 1", "Alamcen 1", "Avenida 1"));
            Coleccion.Add(new TiendasXAML("Tienda 2", "Almacen 2", "Avenida 2"));

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
