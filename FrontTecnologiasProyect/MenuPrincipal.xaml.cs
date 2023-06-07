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

namespace FrontTecnologiasProyect
{
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Btn_RegistrarFechasTutoria(object sender, RoutedEventArgs e)
        {
            RegistrarFechasTutoria ventanaRegistrarFechas = new RegistrarFechasTutoria();
            ventanaRegistrarFechas.Show();
            this.Close();
        }
    }
}
