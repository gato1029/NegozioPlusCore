using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.ModelosBson;
using NegozioPlusCore.Utilitarios;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    public abstract class BaseController<R> where R: RealmObject
    {
        public  Particion particion;

        public BaseController()
        {
            UsuarioLogeado usuarioLogeado = ServiceLocator.Instance.GetService<UsuarioLogeado>();
            this.particion = Configuracion.Instanciar().InstanciarParticion(usuarioLogeado.particion);
        }
        public BaseController(Particion particion)
        {
            this.particion = particion;
        }
        public async Task Verificar(bool refresh)
        {
            
            if (particion._realm == null || particion._realm.IsClosed)
            {
                
                await particion.ConectarParticion();
            }
            else
            {
                if (refresh)
                {
                    particion._realm.Refresh();
                }
            }
        }
        public async Task Insertar(R dato)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                particion._realm.Add(dato);
            });
        }
        public async Task<ObservableCollection<R>> ObtenerTodo()
        {
            await Verificar(false);           
            var datosRealm = particion._realm.All<R>();
            ObservableCollection<R> lista = new ObservableCollection<R>(datosRealm);          
            return lista;
        }

        public async Task<R> BuscarUno(ObjectId idRealm)
        {
            await Verificar(false);
            var dato = particion._realm.Find<R>(idRealm);            
            return dato;
        }
        public async Task Eliminar(R datoEliminar)
        {
            await Verificar(false);
            particion._realm.Write(() =>
            {
                particion._realm.Remove(datoEliminar);
                datoEliminar = null;
            });
        }
        public abstract Task Modificar(ObjectId idOriginal,R datoNuevo);
       
    }
}
