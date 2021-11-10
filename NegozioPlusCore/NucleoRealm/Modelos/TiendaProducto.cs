using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class TiendaProducto : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("idEmpresa")]
        public ObjectId? IdEmpresa { get; set; }
        [MapTo("idTienda")]
        public ObjectId? IdTienda { get; set; }
        [MapTo("lote")]
        public int? Lote { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("precios")]
        public IList<TiendaProducto_precios> Precios { get; }
        [MapTo("productos")]
        public IList<Producto> Productos { get; }
    }
}
