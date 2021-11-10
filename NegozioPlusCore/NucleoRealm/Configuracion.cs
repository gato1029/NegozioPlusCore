using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm
{
    class Configuracion
    {
        string _usuario;
        string _cluster;
        string _mongoDB;
        string _appId;

        public Realms.Sync.App AppRealm;
        public User UsuarioRealm;
        MongoClient _mongoClient;
        MongoClient.Database _databaseMongo;

        Dictionary<string, Particion> _particiones;
        static Configuracion _instancia = null;

        public static Configuracion Instanciar()
        {
            if (_instancia != null)
            {
                return _instancia;
            }
            _instancia = new Configuracion();

            return _instancia;
        }

        Configuracion()
        {
            _appId = "miappgraphql1-fvizp";
            _cluster = "mongodb-atlas";
            _mongoDB = "Principal";
            AppRealm = Realms.Sync.App.Create(_appId);
            _particiones = new Dictionary<string, Particion>();
        }

        public Particion InstanciarParticion(string particion)
        {
            if (_particiones.ContainsKey(particion))
            {
                return _particiones[particion];
            }

            Particion nueva = new Particion(particion);
            _particiones.Add(particion, nueva);

            return nueva;
        }

        public void ConectarMongoDB()
        {
            try
            {
                _mongoClient = UsuarioRealm.GetMongoClient(_cluster);
                _databaseMongo = _mongoClient.GetDatabase(_mongoDB);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

        }


        public void CerrarParticiones()
        {
            foreach (var item in _particiones)
            {
                // item.Value.cerrar();
            }
        }
    }
}
