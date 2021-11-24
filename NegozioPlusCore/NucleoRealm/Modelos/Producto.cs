using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegozioPlusCore.NucleoRealm.Modelos
{
    public class Producto : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId? Id { get; set; }
        [MapTo("descrip")]
        public string Descrip { get; set; }
        [MapTo("idCatProd")]
        public CategoriaProducto IdCatProd { get; set; }
        [MapTo("idEmp")]
        public ObjectId? IdEmp { get; set; }
        [MapTo("imagen")]
        public string Imagen { get; set; }
        [MapTo("nombre")]
        public string Nombre { get; set; }
        [MapTo("particion")]
        public string Particion { get; set; }
        [MapTo("precio")]
        public double? Precio { get; set; }
        [MapTo("unidad")]
        public string Unidad { get; set; }
    }
 
}
