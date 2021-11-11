using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class TiendaProducto_precios : EmbeddedObject
    {
        [MapTo("idProd")]
        public ObjectId? IdProd { get; set; }
        [MapTo("precio")]
        public double? Precio { get; set; }
    }
}
