using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.Modelos;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncTask = System.Threading.Tasks.Task;
namespace NegozioPlusCore.NucleoRealm
{
    public class Particion
    {
        private string _particion;
        private SyncConfiguration _syncConfig;
        public Realms.Realm _realm;
        private Configuracion _inicioGlobal;

        //-----------------------

        public Particion(string particion)
        {
            _particion = particion;
            _inicioGlobal = Configuracion.Instanciar();

        }

        public async AsyncTask ConectarParticion()
        {
            try
            {
                _syncConfig = new SyncConfiguration(_particion, _inicioGlobal.AppRealm.CurrentUser);
                MessageBox.Show("PathRealm"+_syncConfig.DatabasePath);
                string ruta = _syncConfig.DatabasePath;
                _realm = await Realms.Realm.GetInstanceAsync(_syncConfig);
                /*   user = userRealm.Find<User>(App.RealmApp.CurrentUser.Id);

                   if (user == null && !Constants.AlreadyWarnedAboutBackendSetup)
                   {
                       // Either the trigger hasn't completed yet, has failed,
                       // or was never created on the backend
                       // So let's wait a few seconds and check again...
                       await System.Threading.Tasks.Task.Delay(5000);
                       user = userRealm.Find<User>(App.RealmApp.CurrentUser.Id);
                       if (user == null)
                       {
                           Console.WriteLine("NO USER OBJECT: This error occurs if " +
                               "you do not have the trigger configured on the backend " +
                               "or when there is a network connectivity issue. See " +
                               "https://docs.mongodb.com/realm/tutorial/realm-app/#triggers");

                           await DisplayAlert("No User object",
                               "The User object for this user was not found on the server. " +
                               "If this is a new user acocunt, the backend trigger may not have completed, " +
                               "or the tirgger doesn't exist. Check your backend set up and logs.", "OK");

                           Constants.AlreadyWarnedAboutBackendSetup = true;
                       }
                   }*/
                //SetUpProjectList();
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Particion no encontrada"+ ex.InnerException);
            }
        }
        public void cerrar()
        {
            _realm.Dispose();
        }

        public Tienda ObtenerTienda(ObjectId objectId, bool refresh)
        {

            if (refresh)
            {
                _realm.Refresh();
            }

            return _realm.Find<Tienda>(objectId); ;
        }
        public IQueryable<Tienda> ObtenerTiendas(bool refresh)
        {
            if (refresh)
            {
                _realm.Refresh();
            }
            return _realm.All<Tienda>();
        }
        public async System.Threading.Tasks.Task<IQueryable<Producto>> ObtenerProductosAsync(bool refresh)
        {
            if (_realm == null || _realm.IsClosed)
            {
                await ConectarParticion();
                return _realm.All<Producto>();
            }
            else
            {
                if (refresh)
                {
                    _realm.Refresh();
                }
                return _realm.All<Producto>();
            }
        }
        public IQueryable<Producto> ObtenerProductos(bool refresh, int cantidad)
        {
            if (refresh)
            {
                _realm.Refresh();
            }
            return _realm.All<Producto>();
        }
    }
}
