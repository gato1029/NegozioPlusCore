using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NegozioPlusCore.MVVM.Usuarios
{
    /// <summary>
    /// Lógica de interacción para UsuarioUC.xaml
    /// </summary>
    public partial class UsuarioUC : UserControl
    {
        public UsuarioUC()
        {
            InitializeComponent();
            this.DataContext = new Usuarios.VM.UsuarioVM();
        }
    }
}
