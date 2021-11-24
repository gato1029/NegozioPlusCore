using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    public class AlmacenController : BaseController<Almacen>
    {
        public static AlmacenController Instance => _instance ?? (_instance = new AlmacenController());
        private static AlmacenController _instance;
        public AlmacenController(Particion particion) : base(particion)
        {

        }

        public AlmacenController() : base()
        {
        }
        public async override Task Modificar(ObjectId idOriginal, Almacen datoNuevo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<Almacen>(idOriginal);
                data.Nombre = datoNuevo.Nombre;
                data.Direccion = datoNuevo.Direccion;
                data.Latitud = datoNuevo.Latitud;
                data.Longitud = datoNuevo.Longitud;               
            });
        }
    }
}
