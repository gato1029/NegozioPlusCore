using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class Empresa : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("almacenes")]
        public IList<Empresa_almacenes> Almacenes { get; }
        [MapTo("descripcion")]
        public string Descripcion { get; set; }
        [MapTo("direccion")]
        public string Direccion { get; set; }
        [MapTo("fechaInicio")]
        public DateTimeOffset? FechaInicio { get; set; }
        [MapTo("latitud")]
        public double? Latitud { get; set; }
        [MapTo("longitud")]
        public double? Longitud { get; set; }
        [MapTo("modulos")]
        [Required]
        public IList<string> Modulos { get; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("numDoc")]
        public int? NumDoc { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("tags")]
        [Required]
        public IList<string> Tags { get; }
        [MapTo("tiendas")]
        public IList<Empresa_tiendas> Tiendas { get; }
        [MapTo("ultFechaPago")]
        public DateTimeOffset? UltFechaPago { get; set; }
    }
}
