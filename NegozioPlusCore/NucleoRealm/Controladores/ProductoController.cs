using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    class ProductoController : BaseController<Producto>
    {
        public static ProductoController Instance => _instance ?? (_instance = new ProductoController());
        private static ProductoController _instance;
        public ProductoController(Particion particion) : base(particion)
        {

        }

        public ProductoController() : base()
        {
        }
        public async override Task Modificar(ObjectId idOriginal, Producto datoNuevo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<Producto>(idOriginal);
                data.Nombre = datoNuevo.Nombre;
                data.Descrip = datoNuevo.Descrip;
                data.Precio = datoNuevo.Precio;
                data.Unidad = datoNuevo.Unidad;
                data.IdCatProd = datoNuevo.IdCatProd;
                data.Habilitado = datoNuevo.Habilitado;
                data.ReqAlmacen = datoNuevo.ReqAlmacen;
            });
        }
    }
}
