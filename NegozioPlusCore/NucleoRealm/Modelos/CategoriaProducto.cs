using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class CategoriaProducto : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("categoria")]
        public string Categoria { get; set; }
        [MapTo("idEmp")]
        public ObjectId? IdEmp { get; set; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("padre")]
        public string Padre { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
    }
}
