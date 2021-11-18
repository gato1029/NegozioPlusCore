using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Realms;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class Usuario : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("docIdentidad")]
        public string DocIdentidad { get; set; }
        [MapTo("idEmp")]
        public string IdEmp { get; set; }
        [MapTo("idUsuario")]
        public string IdUsuario { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("rol")]
        public string Rol { get; set; }
        [MapTo("tipoDoc")]
        public string TipoDoc { get; set; }
    }
}
