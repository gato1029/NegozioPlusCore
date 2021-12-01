using MongoDB.Bson;
using System;
using System.Collections.Generic;
using Realms;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class Almacen : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("direccion")]
        public string Direccion { get; set; }
        [MapTo("idEmp")]
        public ObjectId? IdEmp { get; set; }
        [MapTo("latitud")]
        public string Latitud { get; set; }
        [MapTo("longitud")]
        public string Longitud { get; set; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
    }
}
