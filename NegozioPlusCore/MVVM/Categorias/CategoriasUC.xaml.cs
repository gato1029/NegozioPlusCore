using NegozioPlusCore.MVVM.Categorias.VM;
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

namespace NegozioPlusCore.MVVM.Categorias
{
    /// <summary>
    /// Interaction logic for Categorias.xaml
    /// </summary>
    public partial class CategoriasUC : UserControl
    {
        public CategoriasUC()
        {
            InitializeComponent();
            this.DataContext = new CategoriasUCVM();
        }
    }
}
