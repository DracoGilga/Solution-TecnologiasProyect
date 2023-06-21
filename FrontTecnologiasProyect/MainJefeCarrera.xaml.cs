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
    /// Lógica de interacción para MainJefeCarrera.xaml
    /// </summary>
    public partial class MainJefeCarrera : Window
    {
        Academico academicoLlave;
        public MainJefeCarrera(Academico traspasoAcademico)
        {
            InitializeComponent();
            academicoLlave = traspasoAcademico;
        }

        private void btn_LlenarReporteTA(object sender, RoutedEventArgs e)
        {
            LlenarReporteTA llenarReporteTA = new LlenarReporteTA(academicoLlave, 0);
            llenarReporteTA.ShowDialog();
        }
        private void btn_RegistraSolucionPA(object sender, RoutedEventArgs e)
        {
            ConsultarProblematicas consultarProblematicas = new ConsultarProblematicas();
            consultarProblematicas.ShowDialog();
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
    }
}
