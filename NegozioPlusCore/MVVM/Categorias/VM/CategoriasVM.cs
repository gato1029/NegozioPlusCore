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

namespace NegozioPlusCore.MVVM.Categorias.VM
{
    class CategoriasVM : NotificadorGenerico
    {
        private CategoriasAgregar categoriaAgregarNuevo;
        private double altoGridDatos;
        public ObservableCollection<CategoriasXAML> Coleccion { get; set; }
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });
        private void ClickAgregar(object obj)
        {
            
            if (categoriaAgregarNuevo == null || categoriaAgregarNuevo.IsClosed)
            {
                categoriaAgregarNuevo = new CategoriasAgregar();
            }
            categoriaAgregarNuevo.Show();
            
        }
        public CategoriasVM()
        {
            PrincipalPaginaVM.EventoResizarVentana += PrincipalPaginaVM_EventoResizarVentana;
            Coleccion = new ObservableCollection<CategoriasXAML>();
            Coleccion.Add(new CategoriasXAML("Categoria 1"));
            Coleccion.Add(new CategoriasXAML("Categoria 2"));
            Coleccion.Add(new CategoriasXAML("Categoria 3"));

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
