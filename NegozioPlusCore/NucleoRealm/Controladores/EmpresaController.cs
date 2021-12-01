using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    class EmpresaController : BaseController<Empresa>
    {
        public static EmpresaController Instance => _instance ?? (_instance = new EmpresaController());
        private static EmpresaController _instance;
 
        public async override Task Modificar(ObjectId idOriginal, Empresa datoNuevo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<Empresa>(idOriginal);
                data.Nombre = datoNuevo.Nombre;
                data.NumDoc = datoNuevo.NumDoc;
                data.Latitud = datoNuevo.Latitud;
                data.Longitud = datoNuevo.Longitud;
               
            });
        }
        public async Task ModificarModulos(ObjectId idOriginal, string modulo)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<Empresa>(idOriginal);
                int pos =data.Modulos.IndexOf(modulo);
                data.Modulos[pos] = modulo;
            });
        }
        public async Task ModificarTiendas(ObjectId idOriginal, Empresa_tiendas tienda)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                var data = particion._realm.Find<Empresa>(idOriginal);
                int pos = data.Tiendas.IndexOf(tienda);
                if (pos != -1)
                {
                    data.Tiendas[pos].Nombre = tienda.Nombre;
                }
                else 
                {
                    
                    InsertarTiendaMongo(tienda);
                    data.Tiendas.Add(tienda);
                }
            });
        }

        private void InsertarTiendaMongo(Empresa_tiendas tienda)
        {
            
        }
    }
}
