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

namespace NegozioPlusCore.MVVM.Productos
{
    /// <summary>
    /// Interaction logic for ProductoVentana.xaml
    /// </summary>
    public partial class ProductoVentana : Window
    {
        public bool IsClosed { get; private set; }
        public ProductoVentana()
        {
            InitializeComponent();
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BarraTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
