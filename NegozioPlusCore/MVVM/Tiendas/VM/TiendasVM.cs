using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Bson;
using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.MVVM.Principal.VM;
using NegozioPlusCore.NucleoRealm.ControladoresMongo;
using NegozioPlusCore.NucleoRealm.ModelosBson;
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

        private async void ClickAgregar(object obj)
        {
            TiendaControllerMongo tm = new TiendaControllerMongo();
            ObservableCollection<NucleoRealm.ModelosBson.TiendaMongo> lista = await tm.ObtenerTodosAsync();

          

            TiendaMongo tmongo = new TiendaMongo();
            tmongo._id = ObjectId.Parse("619f09f9a0634b8c0dc3a55a");
            //tmongo.direccion = "nueva direccion";
           // tmongo.nombre = "zafiros modificados";
            await tm.modificarAsync(tmongo);
            //if (tiendasAgregarNuevo == null || tiendasAgregarNuevo.IsClosed)
            //{
            //    tiendasAgregarNuevo = new TiendasAgregar();
            //}
            //tiendasAgregarNuevo.Show();
            
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
