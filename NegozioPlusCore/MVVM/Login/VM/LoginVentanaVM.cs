using Microsoft.Toolkit.Mvvm.Input;
using NegozioPlusCore.MVVM.Principal;
using NegozioPlusCore.NucleoRealm;
using NegozioPlusCore.NucleoRealm.Modelos;
using NegozioPlusCore.NucleoRealm.ModelosBson;
using NegozioPlusCore.Utilitarios;
using Realms.Sync;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace NegozioPlusCore.MVVM.Login.VM
{
    class LoginVentanaVM:NotificadorGenerico
    {
        private string usuarioLocal;
        private string passwordLocal;
        private string codigoEmpresa;
        private bool modoLogin;
        private bool cargandoBusy;
        private Configuracion configuracion;
        public LoginVentanaVM()
        {
            configuracion = Configuracion.Instanciar();
            usuarioLocal = "josue.ccama@gmail.com";
            passwordLocal = "123456";
            codigoEmpresa = "6170c2677552a959d787f54c";
            CargandoBusy = false;
        }

        public ICommand ComandoClickLogin => new RelayCommand<Window>(ClickLogin, (o) => { return true; });

        private  async void ClickLogin(Window obj)
        {           
            try
            {
                CargandoBusy = true;
                if (ModoLogin) //admin
                {
                    configuracion.UsuarioRealm = await configuracion.AppRealm.LogInAsync(Credentials.EmailPassword(usuarioLocal, passwordLocal));
                    
                }
                else
                {
                    var functionParameters = new
                    {
                        username = usuarioLocal,
                        password = passwordLocal,
                        idEmpresa  = codigoEmpresa,
                        modo = "LOGIN"
                    };
                    configuracion.UsuarioRealm = await configuracion.AppRealm.LogInAsync(Credentials.Function(functionParameters));
                }
                
                if (configuracion.UsuarioRealm != null)
                {                    
                    await configuracion.UsuarioRealm.RefreshCustomDataAsync();
                    UsuarioLogeado usuarioData = configuracion.UsuarioRealm.GetCustomData<UsuarioLogeado>();
                    CargandoBusy = false;
                    ServiceLocator.Instance.RegisterService<UsuarioLogeado>(usuarioData);
                    VentanaPrincipal vp = new VentanaPrincipal();
                    vp.Show();
                    obj.Close();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                CargandoBusy = false;
                System.Windows.MessageBox.Show("Error usuario no encontrado");
            }
        }
        public string UsuarioLocal
        {
            get { return this.usuarioLocal; }
            set { SetValue(ref this.usuarioLocal, value); }
        }
        public string Password
        {
            get { return this.passwordLocal; }
            set { SetValue(ref this.passwordLocal, value); }
        }
        public string CodigoEmpresa
        {
            get { return this.codigoEmpresa; }
            set { SetValue(ref this.codigoEmpresa, value); }
        }
        public bool ModoLogin
        {
            get { return this.modoLogin; }
            set { SetValue(ref this.modoLogin, value); }
        }
        public bool CargandoBusy
        {
            get { return this.cargandoBusy; }
            set { SetValue(ref this.cargandoBusy, value); }
        }
    }
}
