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

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioVM : NotificadorGenerico
    {
        private UsuarioVentana usuarioVentanaNuevo;
        private double altoGridDatos;
        public ObservableCollection<UsuarioXAML> Coleccion { get; set; }
        public ICommand ComandoClickAgregar => new RelayCommand<Object>(ClickAgregar, (o) => { return true; });

        private void ClickAgregar(object obj)
        {
            
            if (usuarioVentanaNuevo==null || usuarioVentanaNuevo.IsClosed)
            {
                usuarioVentanaNuevo = new UsuarioVentana();
            }            
            usuarioVentanaNuevo.Show();
            
        }

        public UsuarioVM()
        {
            PrincipalPaginaVM.EventoResizarVentana += PrincipalPaginaVM_EventoResizarVentana;
            Coleccion = new ObservableCollection<UsuarioXAML>();
            Coleccion.Add(new UsuarioXAML("gatoaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "cat"));
<<<<<<< HEAD
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
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato", "duck"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
            Coleccion.Add(new UsuarioXAML("perico", "bird"));
        }


=======
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
          
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

>>>>>>> gato
    }
}
