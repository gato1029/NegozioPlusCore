using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    public class TiendaController : BaseController<Tienda>
    {
        public static TiendaController Instance => _instance ?? (_instance = new TiendaController());
        private static TiendaController _instance;

        public TiendaController(Particion particion) : base(particion)
        {
        }

        public TiendaController() : base()
        {
        }

        public async override Task Modificar(ObjectId idOriginal, Tienda datoNuevo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<Tienda>(idOriginal);
                data.Nombre = datoNuevo.Nombre;
                data.Direccion = datoNuevo.Direccion;
                data.Longitud = datoNuevo.Longitud;
                data.Latitud = datoNuevo.Latitud;
            });
        }
    }
}
