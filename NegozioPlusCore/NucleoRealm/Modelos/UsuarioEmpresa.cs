using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Realms;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
  
    public class UsuarioEmpresa : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("activo")]
        public bool? Activo { get; set; }
        [MapTo("cargo")]
        public string Cargo { get; set; }
        [MapTo("idEmp")]
        public ObjectId? IdEmp { get; set; }
        [MapTo("modulos")]
        [Required]
        public IList<string> Modulos { get; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("usuario")]
        public string Usuario { get; set; }
    }
}
