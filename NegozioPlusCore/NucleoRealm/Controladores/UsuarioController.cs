using NegozioPlusCore.MVVM.Usuarios.VM;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.NucleoRealm.ModelosBson;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    public class UsuarioController : BaseController<UsuarioXAML>
    {
        public UsuarioController(Particion particion) : base(particion)
        {
           
        }

        public UsuarioController() :base()
        {
        }

        public override void Eliminar(string idUnico)
        {
            
        }

        public  override void Insertar(UsuarioXAML dato)
        {
          
           
          
        }

        public override void Modificar(string idOriginal, UsuarioXAML datoNuevo)
        {
            
        }

        public async override Task <ObservableCollection<UsuarioXAML>> ObtenerTodo()
        {
            await Verificar(false);
            ObservableCollection<UsuarioXAML> lista = new ObservableCollection<UsuarioXAML>();
            var usuariosRealm = particion._realm.All<Usuario>();
            foreach (var item in usuariosRealm)
            {
                lista.Add(Convertir(item));
            }            
            return lista;
        }

        public UsuarioXAML Convertir(Usuario usuario)
        {
            UsuarioXAML usuarioXAML = new UsuarioXAML(usuario.UsuarioLocal,usuario.Nombre);
            return usuarioXAML;
        }

    
    }
}
