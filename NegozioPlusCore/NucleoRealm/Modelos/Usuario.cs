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
        [MapTo("activo")]
        public bool? Activo { get; set; }
        [MapTo("correo")]
        public string Correo { get; set; }
        [MapTo("docIdentidad")]
        public string DocIdentidad { get; set; }
        [MapTo("idEmp")]
        public Empresa IdEmp { get; set; }
        [MapTo("idUsuario")]
        public string IdUsuario { get; set; }
        [MapTo("modulos")]
        [Required]
        public IList<string> Modulos { get; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("password")]
        public string Password { get; set; }
        [MapTo("rol")]
        public string Rol { get; set; }
        [MapTo("tipoDoc")]
        public string TipoDoc { get; set; }
        [MapTo("usuarioLocal")]
        public string UsuarioLocal { get; set; }
    }
}
