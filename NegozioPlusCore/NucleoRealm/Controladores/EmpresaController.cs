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
            
        }
    }
}
