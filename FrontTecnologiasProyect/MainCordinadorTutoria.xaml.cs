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
    /// Lógica de interacción para MainCordinadorTutoria.xaml
    /// </summary>
    public partial class MainCordinadorTutoria : Window
    {
        Academico academicoLlave;
        public MainCordinadorTutoria(Academico traspasoAcademico)
        {
            InitializeComponent();
            academicoLlave = traspasoAcademico;
        }
        private void btn_LlenarReporteTA(object sender, RoutedEventArgs e)
        {
            LlenarReporteTA llenarReporteTA = new LlenarReporteTA(academicoLlave,0);
            llenarReporteTA.Show();
        }
        private void btn_RegistrarAlumno(object sender, RoutedEventArgs e)
        {
            RegistrarAlumno registrarAlumno = new RegistrarAlumno();
            registrarAlumno.Show();
        }
        private void btn_RegistrarTutorAcademico(object sender, RoutedEventArgs e)
        {
            RegistrarTutorAcademico registrarTutorAcademico = new RegistrarTutorAcademico();
            registrarTutorAcademico.Show();
        }
        private void btn_AsignarTutorAcademico(object sender, RoutedEventArgs e)
        {
            ModificarAlumno modificarAlumno = new ModificarAlumno();
            modificarAlumno.Show();
        }


        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
    }
}
