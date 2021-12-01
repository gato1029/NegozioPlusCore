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
        public CategoriaProductoController(Particion particion) : base(particion)
        {

        }

        public CategoriaProductoController() : base()
        {
        }
        public async override Task Modificar(ObjectId idOriginal, CategoriaProducto datoNuevo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<CategoriaProducto>(idOriginal);
                data.Nombre = datoNuevo.Nombre;
                //data.Categoria = datoNuevo.Categoria;
                //data.Padre = datoNuevo.Padre;
            });
        }
    }
}
