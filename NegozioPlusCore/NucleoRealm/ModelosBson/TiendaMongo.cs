using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.ModelosBson
{
    public class TiendaMongo
    {
        [BsonIgnoreIfDefault]
        [BsonElement("_id")]
        public ObjectId? _id { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("almacenes")]
        public IList<ObjectId> almacenes { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("usuarios")]
        public IList<string> usuarios { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("direccion")]
        public string direccion { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("idEmp")]
        public ObjectId? idEmp { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("latitud")]
        public double? latitud { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("longitud")]
        public double? longitud { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("particion")]
        public string particion { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("tipo")]
        public string tipo { get; set; }

      
    }
}
