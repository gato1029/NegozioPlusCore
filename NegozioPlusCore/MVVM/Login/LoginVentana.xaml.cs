using NegozioPlusCore.MVVM.Login.VM;
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
using System.Windows.Shapes;

namespace NegozioPlusCore.MVVM.Login
{
    /// <summary>
    /// Lógica de interacción para LoginVentana.xaml
    /// </summary>
    public partial class LoginVentana : Window
    {
        public LoginVentana()
        {
            InitializeComponent();
            this.DataContext = new LoginVentanaVM();
        }

        private void BarraTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
