using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    class CategoriaProductoController : BaseController<CategoriaProducto>
    {
        public static CategoriaProductoController Instance => _instance ?? (_instance = new CategoriaProductoController());
        private static CategoriaProductoController _instance;
        public override Task Modificar(ObjectId idOriginal, CategoriaProducto datoNuevo)
        {
            throw new NotImplementedException();
        }
    }
}
