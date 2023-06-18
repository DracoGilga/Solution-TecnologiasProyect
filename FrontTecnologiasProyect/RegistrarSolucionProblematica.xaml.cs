using ServiceReference1;
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
    /// <summary>
    /// Lógica de interacción para RegistrarSolucionProblematica.xaml
    /// </summary>
    public partial class RegistrarSolucionProblematica : Window
    {
        public RegistrarSolucionProblematica(Problematica dato)
        {
            InitializeComponent();

        }

        private void Btn_CancelarSolucion(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_GuardarSolucion(object sender, RoutedEventArgs e)
        {

        }
    }
}
