using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class Empresa_almacenes : EmbeddedObject
    {
        [MapTo("idAlmacen")]
        public ObjectId? IdAlmacen { get; set; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
    }
}
