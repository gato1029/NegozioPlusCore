using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioVM : NotificadorGenerico
    {
        public ObservableCollection<UsuarioXAML> Coleccion { get; set; }

        public UsuarioVM()
        {
            Coleccion = new ObservableCollection<UsuarioXAML>();
            Coleccion.Add(new UsuarioXAML("gato", "cat"));
            Coleccion.Add(new UsuarioXAML("perro", "dog"));
            Coleccion.Add(new UsuarioXAML("pato",  "duck"));
            Coleccion.Add(new UsuarioXAML("perico","bird"));

        }

      
    }
}
