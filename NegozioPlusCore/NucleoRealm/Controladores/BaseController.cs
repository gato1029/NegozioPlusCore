using NegozioPlusCore.NucleoRealm.ModelosBson;
using NegozioPlusCore.Utilitarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioPlusCore.NucleoRealm.Controladores
{
    public abstract class BaseController<T>
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
        public  abstract void Insertar(T dato);
        public  abstract Task<ObservableCollection<T>>ObtenerTodo();
        public abstract void Eliminar(string idUnico);
        public abstract void Modificar(string idOriginal,T datoNuevo);
    }
}
