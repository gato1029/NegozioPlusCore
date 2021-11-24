using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class Tienda : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("almacenes")]
        public IList<ObjectId> Almacenes { get; }
        [MapTo("direccion")]
        public string Direccion { get; set; }
        [MapTo("idEmp")]
        public ObjectId? IdEmp { get; set; }
        [MapTo("latitud")]
        public double? Latitud { get; set; }
        [MapTo("longitud")]
        public double? Longitud { get; set; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("tipo")]
        public string Tipo { get; set; }
        [MapTo("usuarios")]
        [Required]
        public IList<string> Usuarios { get; }
    }
}
