using MongoDB.Bson;
using System.Collections.Generic;

namespace NegozioPlusCore.NucleoRealm.ModelosBson
{
    public class UsuarioLogeado
    {
        public string _id { get; private set; }
        public  ObjectId? idEmp { get; private set; }
        public string idUsuario { get; set; }
        public string rol { get; set; }
        public string tipoDoc { get; set; }
        public string docIdentidad { get; set; }
        public string usuarioLocal { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }

        public IList<string> modulos { get; set; }
        public string correo { get; set; }
       
        public bool? activo { get; set; }
        public string particion { get; set; }

        public UsuarioLogeado()
        { 
        }
        public UsuarioLogeado(string id, string partition = "myPart")
        {
            this._id = id;
            this.particion = partition;
        }
    }
}
