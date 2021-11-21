using MongoDB.Bson;
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
    //Pasar  objeto realm
    public class UsuarioController : BaseController<Usuario>
    {
        public static UsuarioController Instance => _instance ?? (_instance = new UsuarioController());
        private static UsuarioController _instance;
        public UsuarioController(Particion particion) : base(particion)
        {
           
        }

        public UsuarioController() :base()
        {
        }      
        public async override Task Modificar(ObjectId idOriginal, Usuario datoNuevo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {               
                var data = particion._realm.Find<Usuario>(idOriginal);
                data.Nombre  = datoNuevo.Nombre;
                data.UsuarioLocal = datoNuevo.UsuarioLocal;
                data.Rol = datoNuevo.Rol;
            });
        }
   
    }
}
