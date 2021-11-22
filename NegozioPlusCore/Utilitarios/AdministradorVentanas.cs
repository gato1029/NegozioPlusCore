using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NegozioPlusCore.Utilitarios
{
    public class AdministradorVentanas
    {
        public static AdministradorVentanas Instance => _instance ?? (_instance = new AdministradorVentanas());
        private static AdministradorVentanas _instance;

        private readonly Dictionary<Type, Dictionary<string,object>> _ventanas;

        public AdministradorVentanas()
        {
            _ventanas = new Dictionary<Type, Dictionary<string, object>>();
        }
        public W RegistrarVentana<W>(string idRealm, object ViewModel) where W : Window, new()
        {
            var type = typeof(W);
            if (!_ventanas.ContainsKey(type))
            {
                Dictionary<string, object> ventanasInternas = new Dictionary<string, object>();
                W wm = new W();
                wm.DataContext = ViewModel;
                ventanasInternas.Add(idRealm, wm);
                _ventanas.Add(type, ventanasInternas);
                return wm;
            }
            else
            {
                Dictionary<string, object> ventanasInternas = _ventanas[type];

                if (!ventanasInternas.ContainsKey(idRealm))
                {
                    W wm = new W
                    {
                        DataContext = ViewModel
                    };
                    ventanasInternas.Add(idRealm, wm);
                    return wm;
                }
                else
                {
                    return ventanasInternas[idRealm] as W;
                }
            }
           
        }
        public void EliminarVentana<W>(string idRealm) where W : Window
        {
            var type = typeof(W);
            if (_ventanas.ContainsKey(type))
            {
                Dictionary<string, object> ventanasInternas = _ventanas[type];
                if (ventanasInternas.ContainsKey(idRealm))
                {
                    ventanasInternas.Remove(idRealm);                    
                }
            }

        }
    }
}
