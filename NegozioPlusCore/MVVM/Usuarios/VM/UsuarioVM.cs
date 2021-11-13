using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.MVVM.Principal.VM;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioVM : NotificadorGenerico
    {
        private double altoGridDatos;
        public ObservableCollection<UsuarioXAML> Coleccion { get; set; }

        public UsuarioVM()
        {
            PrincipalPaginaVM.EventoResizarVentana += PrincipalPaginaVM_EventoResizarVentana;
            Coleccion = new ObservableCollection<UsuarioXAML>();
            Coleccion.Add(new UsuarioXAML("gatoaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato",  "duck"));
            Coleccion.Add(new UsuarioXAML("perico","bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
        }

        private void PrincipalPaginaVM_EventoResizarVentana(object sender, PrincipalPagina e)
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
