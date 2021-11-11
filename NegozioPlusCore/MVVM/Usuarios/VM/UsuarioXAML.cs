using NegozioPlusCore.Utilitarios;

namespace NegozioPlusCore.MVVM.Usuarios.VM
{
    class UsuarioXAML: NotificadorGenerico
    {
        string usuario;
        string nombre;

        public UsuarioXAML(string usuario, string nombre)
        {
            this.usuario = usuario;
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
    }
}
